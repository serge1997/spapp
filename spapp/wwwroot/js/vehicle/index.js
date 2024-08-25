$(document).ready(function () {
    var vehicle;
    var vehicleBrands;
    var select = $('#VehicleBrandId');

    listAllVehicleBrand();

    $('.edit-vehicle').click(function () {
        let id = $(this).attr('data-vehicle-id');
        ApiSpapp.get(`vehicle/${id}`)
            .then(async response => {
                vehicle = await response.data;
                $('#Model').val(vehicle.Model);
                $('#LicensePlate').val(vehicle.LicensePlate);
                $('#KM').val(vehicle.KM);
                $('#Year').val(vehicle.Year);
                $('#Remark').val(vehicle.Remark);
                $(`#VehicleBrandId`).val(vehicle.BrandId).trigger('change')
            })
            .catch(error => {
                toastSpApi.error("une errure est survenue", "error");
            })
    })

    //edit vehicle

    $('#editVehicleForm').submit(function (e) {

        e.preventDefault();
        let data = {
            Id: vehicle.Id,
            Model: $('#Model').val(),
            LicensePlate: $('#LicensePlate').val(),
            KM: $('#KM').val(),
            Year: $('#Year').val(),
            Remark: $('#Remark').val(),
            VehicleBrandId: $('#VehicleBrandId').val()
        }

        ApiSpapp.put('vehicle', data)
            .then(async response => {
                toastSpApi.success(await response.data.value, "success");
                setTimeout(() => {
                    location.reload()
                }, 700)
            })
            .catch(error => {
                toastSpApi.error(`une erreure survenue (actualisation vehiclue): ${error.toString()}`);
            })
    })

    $('.delete-vehicle').click(function () {
        let id = $(this).attr('data-vehicle-id');
        Swal.fire({
            text: "Voulez vous supprimer ce vehicule ?",
            showDenyButton: true,
            confirmButtonText: "Confirmer",
            denyButtonText: `Annuler`,
            confirmButtonColor: "#0f766e"
        })
         .then(result => {
             if (result.isConfirmed) {
                ApiSpapp.delete(`vehicle/${id}`)
                .then(async response => {
                    toastSpApi.success(await response.data.value, "success");
                    setTimeout(() => {
                        location.reload()
                    }, 700)
                })
                .catch(error => {
                    toastSpApi.error("une erreure est survenue", "error")
                })
             }
         })
      
    })

    //list all vehicle brand

    function listAllVehicleBrand() {
        let options = "";
        ApiSpapp.get('vehicle-brand')
            .then(async response => {
                vehicleBrands = await response.data.value;

                for (let brand of vehicleBrands) {
                    options += `<option value="${brand.id}">${brand.name}</option>`;
                }

                select.append(options)
                select.select2({
                    dropdownCssClass: 'increasezindex',
                    width: '100%'
                });
            })
            .catch(error => {
                toastSpApi.error("une erreure est survenue (list marque vehicle)" + error.toString(), "error");
            })
    }
})