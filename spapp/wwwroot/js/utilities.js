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
    let hasPropriteryName = false;
    let hasPropriteryDescription = false;
    let hasPropriterystreetName = false;
    $(`#${target}`).on('input', function () {

        $(`.${target_parrent} .autocomplete-ul`).remove();
        let ul = "<ul class='autocomplete-ul shadow-sm mt-1 rounded-2 list-group'>";
        let filtered = data.filter(mun => {
            if (Reflect.has(mun, 'name')) {
                hasPropriteryName = true;
                return mun.name.toLowerCase().includes($(this).val().toLowerCase())
            }

            if (Reflect.has(mun, 'description')) {
                hasPropriteryDescription = true;
                return mun.description.toLowerCase().includes($(this).val().toLowerCase())
            }

            if (Reflect.has(mun, 'streetName')) {
                hasPropriterystreetName = true;
                return mun.streetName.toLowerCase().includes($(this).val().toLowerCase())
            }
        });

        for (let add of filtered) {

            if (hasPropriteryName) {
                ul += `<li class="autocomplete-li" data-autocomplete-id=${add.id}>${add.name}</li>`;
            }

            if (hasPropriteryDescription) {
                ul += `<li class="autocomplete-li" data-autocomplete-id=${add.id}>${add.description}</li>`;
            }

            if (hasPropriterystreetName) {
                ul += `<li class="autocomplete-li" data-autocomplete-id=${add.id}>${add.streetName}</li>`;
            }
        }
        ul += "</ul>";



        $(`.${target_parrent} .autocomplete-spapp`).append(ul)
        selectedAutocompletItem(target_parrent);
    })

    function selectedAutocompletItem(target_parrent) {
        $(`.${target_parrent} .autocomplete-li`).click(function () {

            $(`#${target}`).val($(this).text())
            $(`#${target}`).attr('data-id', $(this).attr('data-autocomplete-id'))
            setTimeout(() => {
                $('.autocomplete-ul').remove();
            }, 100)
        })
    }
}
