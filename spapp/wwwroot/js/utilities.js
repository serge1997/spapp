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