export function load_map() {
  let map = L.map("map").setView(
    { lon: -111.78327855565847, lat: 43.819511901490934 },
    16
  );
  document.getElementById("map").leafletMap = map;
  L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    maxZoom: 19,
  }).addTo(map);
  return "";
}

export function draw_route(geoJson, color, opacity) {
  const map = document.getElementById("map").leafletMap;
  const style = {
    color: color,
    weight: 4,
    opacity: opacity,
  };
  L.geoJSON(JSON.parse(geoJson), { style: style }).addTo(map);
  console.log("GeoJSON processed and added to the map.");
  return "";
}

export function clear_map() {
  const map = document.getElementById("map").leafletMap;
  map.eachLayer((layer) => {
    if (layer instanceof L.Polyline) {
      map.removeLayer(layer);
    }
  });
  console.log("Routes cleared");
  return "";
}
