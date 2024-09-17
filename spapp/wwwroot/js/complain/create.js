$(document).ready(function () {

    var municipalities;
    var neighborhoods;
   
    initialize();
    async function initialize() {
        await getMunicipality();
    }
    $('#form-complain-btn').click(function () {
        $('#form-complain-info').removeClass('d-none');
        $('#form-victim-info').addClass('d-none')
        $('#form-address-info').addClass('d-none')

    })

    $('#form-address-btn').click(function () {
        $('#form-address-info').removeClass('d-none');
        $('#form-victim-info').addClass('d-none')
        $('#form-complain-info').addClass('d-none')

    })

    $('#form-victim-btn').click(function () {
        $('#form-victim-info').removeClass('d-none');
        $('#form-address-info').addClass('d-none')
        $('#form-complain-info').addClass('d-none')

    })


    setTimeout(() => {
        mountAutoComplete('autocomplete-municipality-parrent', 'municipality', municipalities);
    }, 1000)

    //clean all this input when selected municipality 
    $('#municipality').on('blur', function () {
        $('#neighborhood').val("");
        $('#neighborhood-sector').val("");
        $('#street-name').val("");
    })

    $('#neighborhood').on('input', function () {
        ApiSpapp.get(`neighborhood-by-name`, { name: $(this).val() })
            .then(async response => {
                neighborhoods = await response.data.value;            
                mountAutoComplete('autocomplete-neighborhood-parrent', 'neighborhood', neighborhoods);              
            })
    })

    $('#street-name').on('input', function () {
        ApiSpapp.get(`address-by-streetname`, { streetname: $(this).val() })
            .then(async response => {
                let addresses = await response.data.value;
                mountAutoComplete('autocomplete-streetname-parrent', 'street-name', addresses);
                getAddressById();
            })
    })
    async function getAddressById() {
        $('.autocomplete-streetname-parrent .autocomplete-li').click(function () {
            let streetnameInput = $('#street-name');
            let addressId = streetnameInput.attr('data-id')

            ApiSpapp.get(`address-by-id/${addressId}`)
                .then(async response => {
                    $('#risk-observation').html("");
                    let result = await response.data.value;
                    $('#municipality').val(result.municipality);
                    $('#neighborhood').val(result.neighborhood);
                    $('#neighborhood-sector').val(result.neighborhoodSector);                

                    if (result.isRiskedArea === true) {
                        let obsHtml = `<br>
                            <span class="d-flex flex-column align-items-start justify-content-start">
                                <span class="d-flex align-items-center">
                                    <i class="bi bi-exclamation-triangle fs-4"></i>
                                </span>
                                <span class="fw-bold">Zone a risque</span>
                            </span>
                            <span>
                                ${result.riskObservation}
                            </span>
                            `
                        $('.risk-area-alert-div').removeClass('d-none');
                        $('#risk-observation').append(obsHtml);
                    } else {
                        $('.alert_error').addClass('d-none')
                        $('#risk-observation').html("");
                    }
                })
        })
    }
    async function getMunicipality() {
        ApiSpapp.get("municipality")
            .then(async response => {
                municipalities = await response.data.value;
            })
            .catch(error => {
                toastSpApi.error(error.toString())
            })
    }

    $('#neighborhood').on('blur', function () {

        setTimeout(() => {
            let selected = $(this).val();
            let obj = neighborhoods.find(nei => nei.name = selected);
            $("#municipality").val(obj.municipality)
            axios.get(`https://nominatim.openstreetmap.org/search?q=abidjan+${obj.municipality}+${$(this).val()}&format=json`)
                .then(async response => {
                    if (response.data[0]) {
                        const result = await response.data[0];
                        mountMap(result.lat, result.lon, result.lat, result.lon)
                    }
                })
        
        }, 500)
    })
   
})