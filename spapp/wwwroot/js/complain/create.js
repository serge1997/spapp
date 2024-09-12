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
        mountAutoComplete('autocomplete-municipality-parrent', 'municipality', municipalities);
    }, 1000)

    $('#street-name').on('input', function () {
        ApiSpapp.get(`address-by-streetname`, { streetname: $(this).val() })
            .then(async response => {
                let addresses = await response.data.value;
                mountAutoComplete('autocomplete-streetname-parrent', 'street-name', addresses);
            })
    })

    async function getAddressById(id) {

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
})