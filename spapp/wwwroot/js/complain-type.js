$(document).ready(function () {
    var complaintype;
    var complaintypeCategory;
    var selectComplainCategory = $('#ComplainTypeCategoryId');

    listAllComplainTypeCategory();
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
                complaintype = await JSON.parse(response.data.value)
                $('#Name').val(complaintype.Name);
                $('#Description').val();
                $(`#ComplainTypeCategoryId option[value=${complaintype.ComplainTypeCategory.Id}]`).attr('selected', 'selected')
                $(`#Priority option[value=${complaintype.Priority}]`).attr('selected', 'selected');
                console.log(complaintype)
            })
            .catch(error => {
                console.log(error);
            })
    })
    
    $('#editComplainTypeForm').submit(function () {

    })


    function listAllComplainTypeCategory() {
        let options = `<option value="3">teste</option>`;
        ApiSpapp.get('complaint-type-category')
            .then(async response => {
                complaintypeCategory = await response.data.value;
                for (let cat of complaintypeCategory) {
                    options += `<option value="${cat.id}">${cat.name}</option>`
                }

                selectComplainCategory.append(options);
                
            })
            .catch(error => {

            })
    }
})