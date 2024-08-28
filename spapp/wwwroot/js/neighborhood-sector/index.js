$(document).ready(function () {

    var municipalities;
    var neighborhoods;
    var neighborhoodSector;

    listAllMunicipality();
    listAllNeighborhoodByMunicipality();

    $('.single-select2-spapp').select2({
        dropdownCssClass: 'increasezindex',
        width: '100%'
    });
 
    $('.edit-sector').click(function () {
        let id = $(this).attr('data-sector-id');
        ApiSpapp.get(`neighborhood-sector/${id}`)
            .then(async response => {
                neighborhoodSector = await response.data.value;
                console.log(neighborhoodSector);
                $('#Name').val(neighborhoodSector.name);
                $('#Observation').val(neighborhoodSector.observation)
                $('#Latitude').val(neighborhoodSector.latitude);
                $('#Longitude').val(neighborhoodSector.longitude);
                neighborhoodSector.isRisked == true ? $('#IsRiskArea').prop('checked', true) : $('#IsRiskArea').prop('checked', false)
                $('#MunicipalityId').val(neighborhoodSector.municipalityId).trigger('change')
            })
            .catch(error => {
                toastSpApi.error("une erreure est survenue " + error.toString());
            })
    })

    $('.delete-sector').click(function () {
        let id = $(this).attr('data-sector-id');

        Swal.fire({
            text: "Voulez vous supprimer ce secteur ?",
            showDenyButton: true,
            confirmButtonText: "Confirmer",
            denyButtonText: `Annuler`,
            confirmButtonColor: "#0f766e"
        })
            .then(result => {
                if (result.isConfirmed) {
                    ApiSpapp.delete(`neighborhood-sector/${id}`)
                        .then(async response => {
                            neighborhoodSector = await JSON.parse(response.data);
                        })
                        .catch(error => {
                            toastApiSpapp.error("une erreure est survenue " + error.toSTring());
                        })
                }
            })

    })

    $('#form-edit').submit(function (e) {
        e.preventDefault();

        let data = {
            Id: neighborhoodSector.id,
            Name: $('#Name').val(),
            Observation: $('#Observation').val(),
            IsRiskArea: $('#IsRiskArea').is(':checked') ? true : false,
            MunicipalityId: $('#MunicipalityId').val(),
            NeighborhoodId: $('#NeighborhoodId').val()
        }
        $('#Latitude').val() != "" ? Reflect.set(data, 'Latitude', Number($('#Latitude').val())) : null;
        $('#Longitude').val() != "" ? Reflect.set(data, 'Longitude', Number($('#Longitude').val())) : null;

        console.log(data);

        ApiSpapp.put('neighborhood-sector', data)
            .then(async response => {
                
                if (response.data.statusCode !== 200) {
                    console.log(response.data)
                    return toastSpApi.error(await response.data.value, 10000)                  
                }

                toastSpApi.success(await response.data.value);
                setTimeout(() => {
                    location.reload();
                }, 300)
                
                
            })
            .catch(error => {
                console.log(error);
                toastSpApi.error(error.toString());
            })
    })

    //list all municipality


    //list all neighborhood

    function listAllMunicipality() {

        ApiSpapp.get('municipality')
            .then(async response => {
                municipalities = await response.data.value;
                setSelectOptions('MunicipalityId', municipalities);
            })
            .catch(error => {
                toastSpApi.error(`une erreur est survenue (listMunicipality): ${error.toString()}`)
            })
    }

    function listAllNeighborhoodByMunicipality() {
        $('#MunicipalityId').change(function () {
            $('#NeighborhoodId option').remove()
            ApiSpapp.get(`neighborhood-by-municipality/${$(this).val()}`)
                .then(async response => {
                    neighborhoods = await response.data.value

                    setSelectOptions('NeighborhoodId', neighborhoods);

                    setTimeout(() => {
                        $('#NeighborhoodId').val(neighborhoodSector.neighborhoodId).trigger('change')
                    },0)
                })
                .catch(error => {
                    toastSpApi.error(`une erreur est survenue (listAllNeighborhoodByMunicipality): ${error.toString()}`)
                })
        })
    }

    async function setSelectOptions(idAtrr, data) {
        let select = $(`#${idAtrr}`);
        let options = "";

        if (typeof data == "object") {

            for await (let dt of data) {
                options += `<option value="${dt.id}">${dt.name}</option>`
            }

            select.append(options);

            return;
        }

        throw "Uncorrect data type";
    }
})