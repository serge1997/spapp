$(document).ready(function () {

    var municipalities;
    var neighborhoods;

    listAllMunicipality();
    listAllNeighborhood();

    $('.single-select2-spapp').select2({
        dropdownCssClass: 'increasezindex',
        width: '100%'
    });
 
    $('.edit-sector').click(function () {
        let id = $(this).attr('data-sector-id');
        ApiSpapp.get(`neighborhood-sector/${id}`)
            .then(async response => {
                neighborhoodSector = await response.data;
                console.log(neighborhoodSector);
                $('#Name').val(neighborhoodSector.Name);
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

    //list all municipality


    //list all neighborhood

    function listAllMunicipality() {

        ApiSpapp.get('municipality')
            .then(async response => {
                municipalities = await response.data.value
            })
    }

    function listAllNeighborhood() {
        ApiSpapp.get('neighborhood')
            .then(async response => {
                neighborhoods = await response.data.value
            })
    }
})