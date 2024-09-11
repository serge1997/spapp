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

    const addresses = [
        { street: "Street one" },
        { street: "Street two" },
        { street: "Street three" }
    ]

    setTimeout(() => {
        mountAutoComplete('autocomplete-municipality-parrent', 'municipality', municipalities);
    }, 800)


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