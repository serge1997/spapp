$(document).ready(function () {

    //map create patrol
    initialize();

    function initialize() {
        mountMap('create-patrol-map');
    }
    function mountMap(divId) {

        let map = L.map(divId).setView([5.3291, -4.0213], 13)
        let marker = L.marker([5.329125, -4.021350]).addTo(map);

        L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 19,
            attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
        }).addTo(map);
    }
})