﻿$(document).ready(function () {
    var city;
    $('.edit-city').click(function () {
        city = null;
        axios.get(`/api/ville/${$(this).attr('data-city-id')}`)
            .then(async response => {              
                city = await response.data;
                
                $('#Name').val(city.name)
                $('#Region').val(city.region)
                $('#District').val(city.district)
                $('#Latitude').val(city.latitude)
                $('#Population').val(city.population)
                $('#Area').val(city.area)
                $('#Longitude').val(city.longitude)
             
            })
    })

    $('body #editCityForm').submit(function (e) {
        e.preventDefault();
        if ($('#Name').val() == "") {
            return $('#error-name-city').text("Nome de la commune est obligatoire");
        }

        if ($('#Region').val() == "") {
            return $('#error-region-city').text("Region est obligatoire");
        }
        console.log($('#Latitude').val() == "");
        let data = {
            Id: city.id,
            Name: $('#Name').val(),
            Region: $('#Region').val(),
            District: $('#District').val(),
            Area: $('#Area').val(),
        }
        $('#Latitude').val() != "" ? Reflect.set(data, "Latitude", $('#Latitude').val()) : null;
        $('#Longitude').val() != "" ? Reflect.set(data, "Longitude", $('#Longitude').val()) : null;
        $('#Population').val() != "" ? Reflect.set(data, "Population", $('#Population').val()) : null;
        $('#Area').val() != "" ? Reflect.set(data, "Area", $('#Area').val()) : null;
        

        axios.put('/api/ville', data)
            .then(async response => {

                if (response.data.statusCode === 200) {
                    toast(await response.data.value, "success");
                }

                if (response.data.statusCode === 204) {
                    toast("Les données ne peuvents pas être null", "error");
                }

            })
            .catch(error => {
                console.log(error)
                toast("une erreure est survenue", "error");               
            })
            .finally(() => {
                $('#editCityModal').modal("hide")
            })
    })

    $('body #delete-city').click(function () {
        let id = $(this).attr('data-city-id');
        axios.delete(`/api/ville/${id}`)
            .then(async response => {
                if (response.data.statusCode === 200) {
                    toast(await response.data.value, "success");
                }
                setTimeout(() => {
                    location.reload()
                }, 200)
            })
            .catch(error => {
                toast("une erreure est survenue", "error");
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