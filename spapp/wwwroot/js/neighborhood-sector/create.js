$(document).ready(function () {
    var neighborhoodSector;
    $('#municipality-select').select2();
    $('#neighborhood-select').select2();


    setTimeout(() => {
        $('#municipality-select').val(1).trigger('change')
    }, 100);

    
    $('#municipality-select').change(function () {
        let neighborhoodSelect = $('#neighborhood-select');
        $('#neighborhood-select option').remove()
        let options = "";
        ApiSpapp.get(`neighborhood-by-municipality/${$(this).val()}`)
            .then(async response => {
                const results = await response.data.value;

                for await (let data of results) {
                    options += `<option value="${data.id}">${data.name}</option>`;
                }
                
                neighborhoodSelect.append(options);

            })
    })

   

})