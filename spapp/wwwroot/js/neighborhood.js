$(document).ready(function () {
    var neighborhood;
    $('#select-city-id').change(function () {
        let selectMunicipality = $('#select-municipality-id');
        let options = "";
        selectMunicipality.append("");
        axios.get(`/api/municipality-by-city/${$(this).val()}`)
            .then(async response => {
                const results = await response.data.value;

                for (let result of results) {
                    options += `<option value="${result.id}">${result.name}</option >`;
                }
                selectMunicipality.html(options);
            })
            .catch(error => {
                console.log(error)
            })
    })

    $('.edit-neighborhood').click(function () {
        let id = $(this).attr('data-neighborhood-id')
        let selectCity = $('#select-city-id');
        let selectMunicipality = $('#select-municipality-id');
        axios.get(`/api/neighborhood/${id}`)
            .then(async response => {
                let result = await JSON.parse(response.data.value);
                neighborhood = result;
                console.log(neighborhood)
                $('#Name').val(neighborhood.Name);
                $('#Population').val(neighborhood.Population);
                $('#Latitude').val(neighborhood.Latitude);
                $('#Longitude').val(neighborhood.Longitude);
                selectCity.append(`<option value="${neighborhood.Municipality.City.Id}">${neighborhood.Municipality.City.Name}</option>`)
                selectMunicipality.append(`<option value="${neighborhood.Municipality.Id}">${neighborhood.Municipality.Name}</option>`)
            })
            .catch(error => {
                console.log(error)
            })
    })

    $('#editNeighborhoodForm').submit(function (e) {
        e.preventDefault();

        let data = {
            Id: neighborhood.Id,
            Name: $('#Name').val()
        }
        $('#Latitude').val() != "" ? Reflect.set(data, "Latitude", $('#Latitude').val()) : null;
        $('#Longitude').val() != "" ? Reflect.set(data, "Longitude", $('#Longitude').val()) : null;
        $('#Population').val() != "" ? Reflect.set(data, "Population", $('#Population').val()) : null;

        axios.put('/api/neighborhood', data)
            .then(async response => {
                toast(await response.data.value, "success");
            })
            .catch(error => {
                toast("une erreure est survenue", "error");
                console.log(error);
            })
       
    })

    $('.delete-neighborhood').click(function () {
        axios.delete(`/api/neighborhood/${$(this).attr("data-neighborhood-id")}`)
            .then(async response => {
                toast(await response.data.value, "success");
            })
            .catch(error => {
                toast("une erreure est survenue", "error");
                console.log(error);
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