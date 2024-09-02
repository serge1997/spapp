$(document).ready(function () {

    $('#general-info-btn').click(function () {
        $('#general-info-tab').removeClass('d-none')
        $('#address-info-tab').addClass('d-none')
        $('#familly-info-tab').addClass('d-none')
    })

    $('#address-info-btn').click(function () {
        $('#address-info-tab').removeClass('d-none')
        $('#familly-info-tab').addClass('d-none')
        $('#general-info-tab').addClass('d-none')
    })

    $('#familly-info-btn').click(function () {
        $('#familly-info-tab').removeClass('d-none')
        $('#address-info-tab').addClass('d-none')
        $('#general-info-tab').addClass('d-none')
    })
})