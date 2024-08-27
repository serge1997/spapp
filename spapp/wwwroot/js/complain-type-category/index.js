$(document).ready(function () {
    var ComplainTypeCategory;
    $('#IsActive').prop('checked', true)

    $('.edit-ComplainTypeCategory').click(function () {
        ComplainTypeCategory = null;
        let id = $(this).attr('data-ComplainTypeCategory-id');
        ApiSpapp.get(`complaint-type-category/${id}`)
            .then(async response => {
                ComplainTypeCategory = await response.data.value;
                $('#Name').val(ComplainTypeCategory.name);
                $('#Description').val(ComplainTypeCategory.description);
                if (ComplainTypeCategory.isActive == "Active") {
                    $('#IsActive').prop('checked', true);
                } else {
                    $('#IsActive').prop('checked', false);
                }
                $('#editComplainTypeCategoryModal').modal("show");
            })
            .catch(error => {
                console.log(error);
            })
    })

    $('.delete-ComplainTypeCategory').click(function () {
        let id = $(this).attr('data-ComplainTypeCategory-id');
        ApiSpapp.delete(`complaint-type-category/${id}`)
            .then(async response => {
                toast(await response.data.value, "success");
                setTimeout(() => {
                    location.reload();
                }, 300)
            })
            .catch(error => {
                toast("une erreur é survenue", "success");
                console.log(error);
            })
    })

    $('#editComplainTypeCategoryForm').submit(function (e) {
        e.preventDefault()
        let data = {
            Id: ComplainTypeCategory.id,
            Name: $('#Name').val(),
            Description: $('#Description').val()
        }
        $('#IsActive').is(':checked') ? data.IsActive = true : data.IsActive = false;
        console.log(data)
        ApiSpapp.put('complaint-type-category', data)
            .then(async response => {
                toastSpApi.success(await response.data.value);
                setTimeout(() => {
                    location.reload()
                }, 300);
            })
            .catch(error => {
                toastSpApi.error("une erreur é survenue " + error.toString());
            })
        
    })
})