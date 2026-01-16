mapboxgl.accessToken = 'pk.eyJ1IjoiYWJkZWxyYWhtYW5hc2hyZjEiLCJhIjoiY21rZHF2NTdwMGJhNjNjczd1NThoMXpqdiJ9.h62oi_6DQGS6PogZkTVp2g';

window.map = null;
window.mapReady = false;

window.initMap = function () {
    window.map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mapbox/streets-v12',
        center: [31.2357, 30.0444],
        zoom: 10
    });

    map.on('load', () => {
        window.mapReady = true;
        chrome.webview.postMessage("MAP_READY");
    });
};

window.moveMap = function (lat, lon, zoom = 15) {
    if (!window.mapReady) return;

    window.map.flyTo({
        center: [lon, lat],
        zoom: zoom
    });
};

window.onload = window.initMap;
