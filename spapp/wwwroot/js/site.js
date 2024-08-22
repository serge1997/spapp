$(document).ready(function () {
    $('#main-menu').smartmenus()

    $('.dt-table').DataTable();
    $("#sidebar-toogle").click(function () {
        $('#sidebar').css({ 'width': '270px', 'transition': 'ease-in .2s' })
        $('body #sidebar-close').removeClass('d-none')
    })
    $("#sidebar").mouseenter(function () {
        $('#sidebar').css({ 'width': '270px', 'transition': 'ease-in .2s' })
        $('body #sidebar-close').removeClass('d-none')
    })
    $('#sidebar-close').click(function () {
        $('#sidebar').css({ 'width': '55px', 'transition': 'ease-in .2s' })
        $(this).addClass('d-none')
    })
   
})