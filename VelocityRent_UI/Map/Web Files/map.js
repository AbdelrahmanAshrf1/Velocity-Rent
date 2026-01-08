mapboxgl.accessToken = 'YOUR_TOKEN';

let map;
let markers = [];

function initMap() {
    map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mapbox/navigation-night-v1',
        center: [31.2357, 30.0444], // lon, lat
        zoom: 15,
        pitch: 60,
        bearing: -17
    });

    map.on('load', () => {
        add3DBuildings();
    });
}

function add3DBuildings() {
    map.addLayer({
        id: '3d-buildings',
        source: 'composite',
        'source-layer': 'building',
        filter: ['==', 'extrude', 'true'],
        type: 'fill-extrusion',
        minzoom: 15,
        paint: {
            'fill-extrusion-color': '#aaa',
            'fill-extrusion-height': ['get', 'height'],
            'fill-extrusion-base': ['get', 'min_height'],
            'fill-extrusion-opacity': 0.6
        }
    });

    map.easeTo({
        pitch: 60,
        bearing: -17,
        duration: 2000
    });
}

function moveMap(lat, lon, zoom = 15) {
    if (!map) return;

    map.flyTo({
        center: [lon, lat],
        zoom: zoom,
        speed: 1.2,
        curve: 1.4
    });
}

function addMarker(lat, lon) {
    if (!map) return;

    const marker = new mapboxgl.Marker()
        .setLngLat([lon, lat])
        .addTo(map);

    markers.push(marker);
}

window.onload = initMap;
