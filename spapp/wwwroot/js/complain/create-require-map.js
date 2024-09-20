$(document).ready(function () {

    initialize();
    var map;
    var marker;
    var neighborhoods;
    var neighborhoodSectors;

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

    $('#neighborhood').on('input', function () {
        if ($(this).val() != "" && $(this).val().length >= 3) {
            ApiSpapp.get(`neighborhood-by-name`, { name: $(this).val() })
                .then(async response => {
                    neighborhoods = await response.data.value;
                    mountAutoComplete('autocomplete-neighborhood-parrent', 'neighborhood', neighborhoods);
                })
        }       
    })

    $('#neighborhood-sector').on('input', function () {
        if ($(this).val() != "" && $(this).val().length >= 2) {
            ApiSpapp.get(`neighborhood-sector/find-by-name`, { name: $(this).val() })
                .then(async response => {
                    neighborhoodSectors = await response.data.value;
                    mountAutoComplete('autocomplete-neighborhood-sector-parrent', 'neighborhood-sector', neighborhoodSectors);
                })
        }
    })

    $('#neighborhood').on('blur', function () {
        setTimeout(() => {
            let selected = $(this).val();
            if (neighborhoods !== undefined && neighborhoods.length) {
                console.log(neighborhoods);
                let obj = neighborhoods.find(nei => nei.name == selected);
                $("#municipality").val(obj.municipality)
                axios.get(`https://nominatim.openstreetmap.org/search?q=abidjan+${obj.municipality}+${$(this).val()}&format=json`)
                    .then(async response => {
                        if (response.data[0]) {
                            const result = await response.data[0];
                            mountMap(result.lat, result.lon, result.lat, result.lon)
                        }
                    })
         
            }
        }, 500)
    })

    $('#neighborhood-sector').on('blur', function () {

        setTimeout(() => {
            let selected = $(this).val();

            if (neighborhoodSectors != undefined && neighborhoodSectors.length) {
                let obj = neighborhoodSectors.find(nei => nei.name == selected);
                $("#municipality").val(obj.municipality);
                $('#neighborhood').val(obj.neighborhood)
                axios.get(`https://nominatim.openstreetmap.org/search?q=abidjan+${obj.municipality}+${obj.neighborhood}+${$(this).val()}&format=json`)
                    .then(async response => {
                        if (!response.data[0]) {
                            return toastSpApi.warning(`secteur (${$(this).val()}) non localisée sur la carte`, 10000)
                        }
                        const result = await response.data[0];
                        mountMap(result.lat, result.lon, result.lat, result.lon)
                        return toastSpApi.info(`Secteur (${$(this).val()}) localisée sur la carte`, 10000)
                    })

            }
        }, 500)
    })

    $('#street-name').on('blur', function () {
        if ($(this).val() !== "") {
            setTimeout(() => {
                let municipality = $('#municipality').val();
                axios.get(`https://nominatim.openstreetmap.org/search?q=abidjan+${municipality}+${$(this).val()}&format=json`)
                    .then(async response => {
                        if (!response.data[0]) {
                            return toastSpApi.warning(`Address (${$(this).val()}) non localisée sur la carte`, 10000)
                        }

                        const result = await response.data[0];
                        mountMap(result.lat, result.lon, result.lat, result.lon)
                        return toastSpApi.info(`Rue (${$(this).val()}) localisée sur la carte`, 10000)
                    })

            }, 500)
        }
    })

   
})