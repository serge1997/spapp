$(document).ready(function () {

    var neighborhoods;
    var sectors;
    

    $('#driver-select').select2();

    $('#patrol-members').select2();

    $('#patrol-vehicle').select2();

    $('#patrol-municipality').select2();
    $('#patrol-neighborhood').select2();

    $('#patrol-specifique-zone').select2();

    $('#patrol-municipality').change(function () {
        $('#patrol-neighborhood option').remove();
        let ids = $(this).val().join(',');

        if (ids.length >= 1) {
            ApiSpapp.get(`neighborhood-by-municipality/${ids}`)
                .then(async response => {
                    console.log(response.data)
                    neighborhoods = await response.data.value;
                    setSelectOptions('patrol-neighborhood', neighborhoods);
                })
                .catch(error => {
                    console.log(error);

                })
        }
        
    })

    $('#patrol-neighborhood').change(function () {
        let ids = $(this).val().join(',');
        $('#patrol-specifique-zone option').remove();

        if (ids.length >= 1) {
            ApiSpapp.get(`neighborhood-sector-by-neighborhood/${ids}`)
                .then(async response => {
                    sectors = await response.data.value;
                    setSelectOptions('patrol-specifique-zone', sectors);
                })
                .catch(error => {
                    console.log(error);
                })
        }
       
    })

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