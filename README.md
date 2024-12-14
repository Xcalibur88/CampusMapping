# BYU-Idaho Campus Mapping
This project will map routes between all your classes for a given semester at BYUI and display them in a webpage.

## Features
- Find the best route between buildings on campus.
- Directly import your schedule from a .ics file.
- Cycle between classes and the days of the week.

## Usage
### Initial setup
1. Clone the repository
   - Your choice of using a git integration in vscode, or a direct zip download.
2. Download OpenStreetMap's map of Idaho
   - Go to [download.geofabrik.de](https://download.geofabrik.de/north-america/us/idaho.html) and download the OSM region of Idaho
   - Take your downloaded `idaho-latest.osm.pbf` file and drop it in the `OpenRouteService` folder next to the `ors.jar` file

### Running the program
To start the application, I recommend using VSCode's built-in debugger.
VSCode should auto-detect the project, so simply run the "Default Configuration" and it should automatically open the map in your browser.

#### Upload your schedule
- Go to BYUI's website and locate your printable schedule. Here is a [link](https://web.byui.edu/Directory/student/schedule) for quick reference.
- Select the desired semester, and download the calendar.
- After starting the application select the "Choose File" button on the bottom right and upload your .ics schedule file.
> [!TIP]
> I have included a [sample schedule](Fall_2024_schedule.ics) for demonstration purposes if you simply wish to demo the project.

#### Navigating your routes
- Cycle between the 5 days of the week with the respective "Back Day" and "Next Day" buttons.
- Cycle between your class routes using the "Back Class" and "Next Class" buttons.
- Click the markers, or zoom in, to see the building names.

## Sources
This project uses three key components. [OpenRouteService](https://openrouteservice.org/) for routing, [Leaflet](https://leafletjs.com/index.html) for map display, and [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) to handle the web application. 