$(document).ready(function () {
    var complaintype;
    var complaintypeCategory;
    var selectComplainCategory = $('#ComplainTypeCategoryId-edit');

    

    listAllComplainTypeCategory();


    $('#Priority-edit').select2({
        dropdownCssClass: 'increasezindex',
        width: '100%'
    })

    $('#ComplainTypeCategoryId-edit').select2({
        dropdownCssClass: 'increasezindex',
        width: '100%'
    });
   

   

    $('#btn-close-complaint-editModal').click(function () {
        complaintype = null;
    })

   

   
  
    

    $('.edit-complain-type').click(function () {
        
        let id = $(this).attr('data-ComplainType-id');
        ApiSpapp.get(`complain-type/${id}`)
            .then(async response => {
                complaintype = await JSON.parse(response.data.value)
                $('#Name-edit').val(complaintype.Name);
                $('#Description-edit').val(complaintype.Description);
                $(`#ComplainTypeCategoryId-edit`).val(complaintype.ComplainTypeCategory.Id).trigger('change')
                $(`#Priority-edit`).val(complaintype.Priority).trigger('change')
                
                $('#PenalCode-edit').val(complaintype.PenalCode);
                    
            })
            .catch(error => {
                console.log(error);
            })
    })
   
    $('#editComplainTypeForm').submit(function (e) {
        e.preventDefault();
        let complaintypeEditData = {
            Id: complaintype.Id,
            Priority: Number($(`#Priority-edit`).val()),
            ComplainTypeCategoryId: $(`#ComplainTypeCategoryId-edit`).val(),
            PenalCode: $('#PenalCode-edit').val(),
            Name: $('#Name-edit').val(),
            Description: $('#Description-edit').val()
        }

        ApiSpapp.put('complain-type', complaintypeEditData)
            .then(async response => {
                toastSpApi.success(await response.data.value, "success");
                setTimeout(() => {
                    location.reload()
                }, 500)
            })
            .catch(error => {
                toastSpApi.success("une erreur est survenue", "error");

            })
    })

    $('.delete-ComplainType').click(function () {
        let id = $(this).attr('data-ComplainType-id');
        ApiSpapp.delete(`complain-type/${id}`)
            .then(async response => {
                toastSpApi.success(await response.data.value, "success");
                setTimeout(() => {
                    location.reload()
                },500)
            })
            .catch(error => {
                toastSpApi.success("une erreur est survenue", "error");
            })
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