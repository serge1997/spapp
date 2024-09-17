$(document).ready(function () {

    initialize();
    var map;
    var marker;
    function initialize() {
        mountMap();
    }
    function mountMap(lat = 5.3291, lon = -4.0213, markerLat = 5.329125, markerLon = -4.021350) {
        if (marker) {
            marker.remove();
        }
        if (!map) {
            map = L.map('create-complain-require-map')
        }
        map.setView([lat, lon], 13)
        marker = L.marker([markerLat, markerLon]).addTo(map);


        //L.circle([5.303612, -3.985395], {radius: 200}).addTo(map);

        L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 19,
            attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
        }).addTo(map);
    }

    getMunicipalityLatLon();
    function getMunicipalityLatLon() {
        $('#municipality').on('blur', function () {
            setTimeout(() => {
                axios.get(`https://nominatim.openstreetmap.org/search?q=abidjan+${$(this).val()}&format=json`)
                    .then(async response => {
                        if (response.data[0]) {
                            const result = await response.data[0];
                            mountMap(result.lat, result.lon, result.lat, result.lon)
                        }
                    })
            }, 200)
        })

    }

   
})