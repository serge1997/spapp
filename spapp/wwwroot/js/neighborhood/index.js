$(document).ready(function () {
    var neighborhood;
    
    $('.edit-neighborhood').click(function () {
        let id = $(this).attr('data-neighborhood-id')
        let selectCity = $('#select-city-id');
        let selectMunicipality = $('#select-municipality-id');
        ApiSpapp.get(`neighborhood/${id}`)
            .then(async response => {
                let result = await response.data.value;
                neighborhood = result;
                $('#Name').val(neighborhood.name);
                $('#Population').val(neighborhood.population);
                $('#Latitude').val(neighborhood.latitude);
                $('#Longitude').val(neighborhood.longitude);
                selectCity.append(`<option value="${neighborhood.cityId}">${neighborhood.city}</option>`)
                selectMunicipality.append(`<option value="${neighborhood.municipalityId}">${neighborhood.municipality}</option>`)
            })
            .catch(error => {
                console.log(error)
            })
    })

    $('#editNeighborhoodForm').submit(function (e) {
        e.preventDefault();

        let data = {
            Id: neighborhood.id,
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