$(document).ready(function () {

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
})