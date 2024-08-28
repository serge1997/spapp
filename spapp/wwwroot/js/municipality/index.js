$(document).ready(function () {
    var municipality;

    
    $('#cityId').select2({
        dropdownCssClass: 'increasezindex',
        width: '100%'
    });
    

    

    $('body #form-create-municipality').submit(function (e) {
        if ($('#name-municipality').val() == "" || $('#municipality-cityId') == "") {
            e.preventDefault();
            return alert("cannot be null")
        }
    })

    $('.edit-municipality').click(function () {
        let id = $(this).attr('data-municipality-id');
        let select = $('#cityId');
        ApiSpapp.get(`municipality/${id}`)
            .then(async response => {
                municipality = await JSON.parse(response.data.value);
                $('#Name').val(municipality.Name);
                $('#Population').val(municipality.Population);
                $('#Latitude').val(municipality.Latitude);
                $('#Longitude').val(municipality.Longitude);
                select.html(`<option selected>${municipality.City.Name}</option>`)
            })
            .catch(error => {
                console.log(error)
            })
    })

    $('#editMunicipalityForm').submit(function (e) {
        e.preventDefault();

        if ($('#Name').val() == "") {
            return $('#error-name-municipality').text("Nome de la commune est obligatoire");
        }


        let data = {
            Id: municipality.Id,
            Name: $('#Name').val()
        }

        $('#Latitude').val() != "" ? Reflect.set(data, "Latitude", $('#Latitude').val()) : null;
        $('#Longitude').val() != "" ? Reflect.set(data, "Longitude", $('#Longitude').val()) : null;
        $('#Population').val() != "" ? Reflect.set(data, "Population", $('#Population').val()) : null;

        ApiSpapp.put('municipality', data)
            .then(async response => {
                if (response.data.statusCode === 200) {
                    toastSpApi.success(await response.data.value);
                }
                setTimeout(() => {
                    location.reload()
                }, 500)
            })
            .catch(error => {
                toast("une erreure est survenue", "error");
                console.log(error)
            })
    })

    $('.delete-municipality').click(function () {
        let id = $(this).attr('data-municipality-id');

        Swal.fire({
            text: "Voulez vous supprimer cette commune ?",
            showDenyButton: true,
            confirmButtonText: "Confirmer",
            denyButtonText: `Annuler`,
            confirmButtonColor: "#0f766e",
            icon: "question"
        })
        .then(result => {
            if (result.isConfirmed) {
                ApiSpapp.delete(`municipality/${id}`)
                    .then(async response => {
                        toastSpApi.success(await response.data.value);

                        setTimeout(() => {
                            location.reload()
                        }, 500)
                    })
                    .catch(error => {
                        toastSpApi.error("une erreure est survenue");
                        console.log(error)
                    })
            }
        })       
    })
})