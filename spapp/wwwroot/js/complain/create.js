$(document).ready(function () {

    var municipalities;
   
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
        mountAutoComplete('autocomplete-applicant-municipality-parrent', 'applicant-complain-municipality', municipalities);
    }, 1000)

    //clean all this input when selected municipality 
    $('#applicant-complain-municipality').on('blur', function () {
        $('#applicant-complain-neighborhood').val("");
        $('#applicant-complain-neighborhood-sector').val("");
        $('#applicant-complain-street-name').val("");
    })


    $('#applicant-complain-street-name').on('input', function () {
        ApiSpapp.get(`address-by-streetname`, { streetname: $(this).val() })
            .then(async response => {
                let addresses = await response.data.value;
                mountAutoComplete('autocomplete-applicant-streetname-parrent', 'applicant-complain-street-name', addresses);
                getAddressById();
            })
    })
    async function getAddressById() {
        $('.autocomplete-applicant-streetname-parrent .autocomplete-li').click(function () {
            let streetnameInput = $('#applicant-complain-street-name');
            let addressId = streetnameInput.attr('data-id')

            ApiSpapp.get(`address-by-id/${addressId}`)
                .then(async response => {
                    $('#risk-observation').html("");
                    let result = await response.data.value;
                    $('#applicant-complain-municipality').val(result.municipality);
                    $('#applicant-complain-neighborhood').val(result.neighborhood);
                    $('#applicant-complain-neighborhood-sector').val(result.neighborhoodSector); 
                    $('#applicant-complain-city').val(result.cityId)

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

    $('#create-complain-form').on('submit', function (e) {
        e.preventDefault();
        let isAnonyme = $('#applicant-complain-anonyme').is(':checked') ? true : false;

        const complainData = {

            ApplicantFullname: $('#applicant-complain-fullname').val(),
            applicantPhoneNumber: $('#applicant-complain-street-name').val(),
            ApplicantAddressStreetName: "",
            ApplicantCNINumber: "",
            ApplicantAtestationNumber: "",
            ApplicantHouseNumber: "",
            ApplicantAddressComplement: "",
            ApplicantAddressCityId: 1,
            IsAnonyme: isAnonyme,
            ApplicantAddressMunicipalityId: parseInt($('#applicant-complain-municipality').attr('data-id')),
            ApplicantAddressNeighborhood: parseInt($('#applicant-complain-neighborhood').attr('data-id')),
                ApplicantAddressNeighborhoodSector: parseInt($('#applicant-complain-neighborhood').attr('data-id'))                     
        }

        ApiSpapp.post("complain", complainData)

    })
   
})