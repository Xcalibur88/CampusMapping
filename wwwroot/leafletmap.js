export function load_map() {
  let map = L.map("map").setView({ lon: -111.78327855565847, lat: 43.819511901490934 }, 16);
  document.getElementById("map").leafletMap = map;
  L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    maxZoom: 19,
  }).addTo(map);
  return "";
}

export function draw_route(geoJson) {
  const map = document.getElementById("map").leafletMap;
  L.geoJSON(JSON.parse(geoJson)).addTo(map);
  console.log("GeoJSON processed and added to the map.");
  return "";
}
