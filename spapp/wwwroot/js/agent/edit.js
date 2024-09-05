$(document).ready(function () {
    var cities;
    var municipalities;
    var neighborhoods;
    var neighborhoodSectors;

    initialize();

    $('#form-agent-btn').click(function () {
        $('#form-agent-info').removeClass('d-none');
        $('#form-address-info').addClass('d-none')
        $('#form-familly-info').addClass('d-none')

    })

    $('#form-address-btn').click(function () {
        $('#form-address-info').removeClass('d-none');
        $('#form-agent-info').addClass('d-none')
        $('#form-familly-info').addClass('d-none')

    })

    $('#form-familly-btn').click(function () {
        $('#form-familly-info').removeClass('d-none');
        $('#form-address-info').addClass('d-none')
        $('#form-agent-info').addClass('d-none')

    })


    function initialize() {
        listCities();
        listMunicipalities();
        listNeighborhoods();
        listNeighborhoodSectors();
    }

    function listCities() {
        ApiSpapp.get('city')
            .then(async response => {
                cities = await response.data.value;
                populateSelect('city-select', cities);
            })
            .catch(error => {
                toastSpApi.error("une erreure est survenue en listant les villes");
            })
    }

    function listNeighborhoods() {
        ApiSpapp.get('neighborhood')
            .then(async response => {
                neighborhoods = await response.data.value;
                populateSelect('neighborhood-select', neighborhoods);
            })
            .catch(error => {
                toastSpApi.error("une erreure est survenue en listant les quarties");
            })
    }

    function listMunicipalities() {
        ApiSpapp.get('municipality')
            .then(async response => {
                municipalities = await response.data.value;
                populateSelect('select-municipality', municipalities)

                setTimeout(() => {
                    $('#select-municipality').val($('#municipality-id').val()).trigger('change')
                })
                
            })
            .catch(error => {
                toastSpApi.error("une erreure est survenue en listant les communes");
            })
    }

    function listNeighborhoodSectors() {
        ApiSpapp.get('neighborhood-sector')
            .then(async response => {
                neighborhoodSectors = await response.data.value;
                populateSelect('select-sector', neighborhoodSectors)
            })
            .catch(error => {
                toastSpApi.error("une erreure est survenue en listant les secteurs");
            })
    }


})