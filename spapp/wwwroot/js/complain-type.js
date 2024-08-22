$(document).ready(function () {
    var complaintype;
    $('#submit-complain-type-create').click(function (e) {


        if ($('#Priority').val() == "") {
            $('#Priority').addClass('border border-danger')
            $("#Priority-error").html(`<small>Priorité est obligatoire</small>`)
           
        }

        if ($('#ComplaintTypeCategoryId').val() == "") {
            $('#ComplaintTypeCategoryId').addClass('border border-danger')
            $("#ComplaintTypeCategoryId-error").html(`<small>Categoria est obligatoire</small>`)
        }

        if ($('#Name').val() == "") { 
            $('#Name').addClass('border border-danger')
            $('#Name-error').html(`<small>Nom est obligatoire</small>`);
        }
    })

    $('.edit-ComplainType').click(function () {
        let id = $(this).attr('data-ComplainType-id');
        ApiSpapp.get(`complain-type/${id}`)
            .then(async response => {
                complaintype = await response.data.value
                console.log(JSON.parse(complaintype))
            })
            .catch(error => {
                console.log(error);
            })
    })
    
    $('#editComplainTypeForm').submit(function () {

    })
})