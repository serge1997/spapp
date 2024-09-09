$(document).ready(function () {

    //show locals toggle

    $('.show-patrol-locals').click(function () {
        let box = $(`#patrol-locals-${$(this).attr('data-patrol-id')}`);
        box.hasClass('d-none') ? box.removeClass('d-none') : box.addClass('d-none');
    })
})