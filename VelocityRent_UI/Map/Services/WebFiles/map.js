mapboxgl.accessToken = 'pk.eyJ1IjoiYWJkZWxyYWhtYW5hc2hyZjEiLCJhIjoiY21rZHF2NTdwMGJhNjNjczd1NThoMXpqdiJ9.h62oi_6DQGS6PogZkTVp2g';

window.map = null;
window.mapReady = false;

window.initMap = function () {

    window.map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/abdelrahmanashrf1/cmkpbzphk002k01r06vlee5bl',
        center: [31.2357, 30.0444],
        zoom: 13,
        pitch: 45,
        bearing: -15,
        antialias: true 
    });

    map.on('load', () => {

        window.mapReady = true;

        if (window.chrome?.webview)
        {
            chrome.webview.postMessage("MAP_READY");
        }

        map.setConfigProperty('basemap', 'show3dBuildings', true);

        map.easeTo({
            zoom: 15,
            pitch: 60,
            bearing: -20,
            duration: 2000
        });
    });
};

window.moveMap = function (lat, lon, zoom = 15) {
    if (!window.mapReady) return;

    map.flyTo({
        center: [lon, lat],
        zoom: zoom,
        speed: 1.2,
        curve: 1.4,
        essential: true
    });
};

window.onload = window.initMap;
