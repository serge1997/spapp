$(document).ready(function () {
    $('#select-city-id').change(function () {
        let selectMunicipality = $('#select-municipality-id');
        let options = "";
        selectMunicipality.append("");
        ApiSpapp.get(`municipality-by-city/${$(this).val()}`)
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
})