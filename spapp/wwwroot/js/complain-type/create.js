$(document).ready(function () {
    var complaintype;
    var complaintypeCategory;



    
   
   
    $('#ComplainTypeCategoryId').select2();

    $('#Priority').select2();

   

    $('#submit-complain-type-create').click(function (e) {


        if ($('#Priority').val() == "") {
            $('#Priority').addClass('border border-danger')
            $("#Priority-error").html(`<small>Priorité est obligatoire</small>`)
           
        }

        if ($('#ComplainTypeCategoryId').val() == "") {
            $('#ComplainTypeCategoryId').addClass('border border-danger')
            $("#ComplainTypeCategoryId-error").html(`<small>Categoria est obligatoire</small>`)
        }

        if ($('#Name').val() == "") { 
            $('#Name').addClass('border border-danger')
            $('#Name-error').html(`<small>Nom est obligatoire</small>`);
        }
    })


})