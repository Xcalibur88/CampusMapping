export function load_map() {
  let map = L.map("map").setView(
    { lon: -111.78329552340168, lat: 43.816511802068376 },
    16
  );
  document.getElementById("map").leafletMap = map;
  L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    maxZoom: 19,
  }).addTo(map);
  return "";
}

function get_map() {
  return document.getElementById("map").leafletMap;
}

export function draw_route(geoJson, color, opacity) {
  const style = {
    color: color,
    weight: 4,
    opacity: opacity,
  };
  L.geoJSON(JSON.parse(geoJson), { style: style }).addTo(get_map());
  console.log("GeoJSON processed and added to the map.");
  return "";
}

export function add_marker(lat, lng, popup) {
  var marker = L.marker([lat, lng]).addTo(get_map());
  if (popup != null) {
    marker.bindPopup(`<b>${popup}</b>`);
  }
}

export function clear_map() {
  const map = get_map();
  map.eachLayer((layer) => {
    if (layer instanceof L.Polyline || layer instanceof L.Marker) {
      map.removeLayer(layer);
    }
  });
  console.log("Routes cleared");
  return "";
}
