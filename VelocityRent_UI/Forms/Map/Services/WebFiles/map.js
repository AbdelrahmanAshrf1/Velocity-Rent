mapboxgl.accessToken = window.mapboxToken;
window.map = null;
window.mapReady = false;
window.selectedMarker = null;

function showSelectButton() {
    document.getElementById('btnSelectAddress').style.display = 'block';
}
function hideSelectButton() {
    document.getElementById('btnSelectAddress').style.display = 'none';
}

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
        if (window.chrome?.webview) {
            chrome.webview.postMessage("MAP_READY");
        }
        map.setConfigProperty('basemap', 'show3dBuildings', true);
        map.easeTo({ zoom: 15, pitch: 60, bearing: -20, duration: 2000 });
    });

    map.on('click', (e) => {
        const { lng, lat } = e.lngLat;

        if (window.selectedMarker) {
            window.selectedMarker.setLngLat([lng, lat]);
        } else {
            window.selectedMarker = new mapboxgl.Marker({ color: '#f97316', draggable: true })
                .setLngLat([lng, lat])
                .addTo(map);

            // if the user drags the pin after dropping it, keep the button in sync
            window.selectedMarker.on('dragend', () => {
                const pos = window.selectedMarker.getLngLat();
                window.selectedLat = pos.lat;
                window.selectedLng = pos.lng;
            });
        }

        window.selectedLat = lat;
        window.selectedLng = lng;
        showSelectButton();
    });
};

document.getElementById('btnSelectAddress').addEventListener('click', () => {
    if (window.selectedLat == null || window.selectedLng == null) return;

    if (window.chrome?.webview) {
        const payload = JSON.stringify({
            type: "PIN_SELECTED",
            lat: window.selectedLat,
            lon: window.selectedLng
        });
        chrome.webview.postMessage(payload);
    }
});

document.getElementById('btnSelectAddress').addEventListener('click', () => {
    if (window.selectedLat == null || window.selectedLng == null) return;

    if (window.chrome?.webview) {
        const payload = JSON.stringify({
            type: "PIN_SELECTED",
            lat: window.selectedLat,
            lon: window.selectedLng
        });
        chrome.webview.postMessage(payload);
    }

    hideSelectButton();   // NEW — this pin is confirmed, nothing left to "select"
});

window.moveMap = function (lat, lon, zoom = 15) {
    if (!window.mapReady) return;
    map.flyTo({ center: [lon, lat], zoom: zoom, speed: 1.2, curve: 1.4, essential: true });
};

function moveToCurrentLocation() {
    if (!navigator.geolocation) {
        alert("Geolocation is not supported.");
        return;
    }

    navigator.geolocation.getCurrentPosition(function (position) {
        const lat = position.coords.latitude;
        const lon = position.coords.longitude;

        window.moveMap(lat, lon, 16);

        chrome.webview.postMessage(JSON.stringify({
            type: "CURRENT_LOCATION",
            lat: lat,
            lon: lon
        }));

    }, function (error) {
        alert(error.message);
    }, {
        enableHighAccuracy: true,
        timeout: 10000,
        maximumAge: 0
    });
}

window.onload = window.initMap;
