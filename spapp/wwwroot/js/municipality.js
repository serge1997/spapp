$(document).ready(function () {
    var municipality;
    $('body #form-create-municipality').submit(function (e) {
        if ($('#name-municipality').val() == "" || $('#municipality-cityId') == "") {
            e.preventDefault();
            return alert("cannot be null")
        }
    })

    $('.edit-municipality').click(function () {
        let id = $(this).attr('data-municipality-id');
        let select = $('#cityId');
        axios.get(`/api/municipality/${id}`)
            .then(async response => {
                municipality = await JSON.parse(response.data.value);
                $('#Name').val(municipality.Name);
                $('#Population').val(municipality.Population);
                $('#Latitude').val(municipality.Latitude);
                $('#Longitude').val(municipality.Longitude);
                select.html(`<option selected>${municipality.City.Name}</option>`)
                console.log(municipality.City.Name)
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

        axios.put('/api/municipality', data)
            .then(async response => {
                if (response.data.statusCode === 200) {
                    toast(await response.data.value, "success");
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
        axios.delete(`/api/municipality/${id}`)
            .then(async response => {
                toast(await response.data.value, "success");

                setTimeout(() => {
                    location.reload()
                }, 500)
            })
            .catch(error => {
                toast("une erreure est survenue", "error");
                console.log(error)
            })
    })
    function toast(message, icon = null) {
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.onmouseenter = Swal.stopTimer;
                toast.onmouseleave = Swal.resumeTimer;
            }
        });

        return Toast.fire({
            icon: icon,
            text: message
        });;
    }
})