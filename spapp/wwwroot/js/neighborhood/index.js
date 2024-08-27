$(document).ready(function () {
    var neighborhood;
    
    $('.edit-neighborhood').click(function () {
        let id = $(this).attr('data-neighborhood-id')
        let selectCity = $('#select-city-id');
        let selectMunicipality = $('#select-municipality-id');
        ApiSpapp.get(`neighborhood/${id}`)
            .then(async response => {
                let result = await JSON.parse(response.data.value);
                neighborhood = result;
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

        ApiSpapp.put('neighborhood', data)
            .then(async response => {
                toastSpApi.success(await response.data.value);
                $('#editNeighborhoodModal').modal("hide")
                setTimeout(() => {
                    location.reload();
                }, 300)
            })
            .catch(error => {
                toastSpApi.error("une erreure est survenue");
                console.log(error);
            })
       
    })

    $('.delete-neighborhood').click(function () {
        ApiSpapp.delete(`neighborhood/${$(this).attr("data-neighborhood-id")}`)
            .then(async response => {
                toastSpApi.success(await response.data.value);
            })
            .catch(error => {
                toastSpApi.error("une erreure est survenue");
                console.log(error);
            })
    })
})