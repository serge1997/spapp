$(document).ready(function () {

    var neighborhoods;
    var municipalities;
    var sectors;

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

    //list municipality by city

    $('#city-select').change(function () {
        $('#select-municipality option').remove();
        ApiSpapp.get(`municipality-by-city/${$(this).val()}`)
            .then(async response => {
                municipalities = await response.data.value;
                populateSelect('select-municipality', municipalities);
            })
            .catch(error => {
                console.log(error);
            })
    })

    //list neighborhoods by municipality

    $('#select-municipality').change(function () {
        $('#neighborhood-select option').remove();
        ApiSpapp.get(`neighborhood-by-municipality/${$(this).val()}`)
            .then(async response => {
                neighborhoods = await response.data.value;
                populateSelect('neighborhood-select', neighborhoods)
            })
            .catch(error => {
                console.log(error);
            })
    })

    //list all sector

    $('#neighborhood-select').change(function () {
        $('#select-sector option').remove();
        ApiSpapp.get(`neighborhood-sector-by-neighborhood/${$(this).val()}`)
            .then(async response => {
                sectors = await response.data.value;
                populateSelect('select-sector', sectors);
            })
            .catch(error => {
                console.log(error);
            })
    })

    
})