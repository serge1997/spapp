async function populateSelect(idAtrr, data) {
    let select = $(`#${idAtrr}`);
    let options = "<option selected></option>";

    if (typeof data == "object") {

        for await (let dt of data) {
            options += `<option value="${dt.id}">${dt.name}</option>`
        }

        select.append(options);

        return;
    }

    throw "Uncorrect data type";
}

function mountAutoComplete(target_parrent, target, data) {
    $(`#${target}`).on('input', function () {

        $(`.${target_parrent} .autocomplete-ul`).remove();
        let ul = "<ul class='autocomplete-ul shadow-sm mt-1 rounded-2 list-group'>";
        let filtered = data.filter(mun => {
            if (Reflect.has(mun, 'name')) {
                return mun.name.toLowerCase().includes($(this).val().toLowerCase())
            }

            if (Reflect.has(mun, 'description')) {
                return mun.description.toLowerCase().includes($(this).val().toLowerCase())
            }
        });

        for (let add of filtered) {
            ul += `<li class="autocomplete-li" data-autocomplete-id=${add.id}>${add.name}</li>`;
        }
        ul += "</ul>";



        $(`.${target_parrent} .autocomplete-spapp`).append(ul)
        $(`.${target_parrent} .autocomplete-li`).click(function () {

            $(`#${target}`).val($(this).text())
            $(`#${target}`).attr('data-id', $(this).attr('data-autocomplete-id'))
            setTimeout(() => {
                $('.autocomplete-ul').remove();
            }, 100)
        })
    })
}