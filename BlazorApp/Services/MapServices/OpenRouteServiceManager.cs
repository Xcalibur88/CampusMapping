using System.Diagnostics;

class OpenRouteServiceManager : IDisposable {
    private Process? orsProcess;
    private static readonly string pidFilePath = "./Properties/ors_process.pid";
    private static readonly ProcessStartInfo startInfo = new() {
        FileName = "java",
        Arguments = $"-jar ../OpenRouteService/ors.jar ../OpenRouteService/ors-config.yml", //-Dors.engine.config_output=ors-config.yml
        WorkingDirectory = "../OpenRouteService",
        RedirectStandardOutput = true,
        RedirectStandardError = true
    };
    
    public async void Start() {
        if (File.Exists(pidFilePath)) {
            int savedPid = int.Parse(File.ReadAllText(pidFilePath));
            try {
                var existingProcess = Process.GetProcessById(savedPid);
                if (!existingProcess.HasExited) {
                    Console.WriteLine($"OpenRouteService is already running with PID: {savedPid}");
                    orsProcess = existingProcess;
                    await PollORSHealth();
                    return;
                }
                throw new Exception();
            } catch (Exception) {
                File.Delete(pidFilePath);
            }
        }
        
        orsProcess = new Process { StartInfo = startInfo };
        
        //orsProcess.OutputDataReceived += (sender, args) => Console.WriteLine($"ORS: {args.Data}");
        orsProcess.ErrorDataReceived += (sender, args) => Console.WriteLine($"ORS Error: {args.Data}");
        try {
            Console.WriteLine("OpenRouteService starting...");
            orsProcess.Start();
            orsProcess.BeginOutputReadLine();
            orsProcess.BeginErrorReadLine();
            File.WriteAllText(pidFilePath, orsProcess.Id.ToString());
        } catch (Exception ex) {
            Console.WriteLine($"Error starting ORS: {ex.Message}");
        }

        await PollORSHealth();
    }

    private async Task PollORSHealth() {
        using var httpClient = new HttpClient();
        var healthUrl = "http://localhost:8082/ors/v2/health";
        var retries = 20;
        var delay = 1000;
        var started = false;
        while (retries-- > 0) {
            try {
                var response = await httpClient.GetAsync(healthUrl);
                if (response.IsSuccessStatusCode) {
                    started = true;
                    break;
                }
            } catch (HttpRequestException) {}
            await Task.Delay(delay);
        }

        if (started) {
            Console.WriteLine("OpenRouteService started!");
        } else {
            Console.WriteLine($"Failed to start ORS within 20 seconds");
        }
    }

    public void Dispose() {
        if (orsProcess != null && !orsProcess.HasExited) {
            orsProcess.Kill();
            orsProcess.WaitForExit();
            orsProcess.Dispose();
            Console.WriteLine("OpenRouteService stopped.");
        }
    }
}