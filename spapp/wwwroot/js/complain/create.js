$(document).ready(function () {

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
})