function onRowInsertingCultures(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).CultureName) || e.data.CultureName == undefined) {
        showInfo("Morate uneti vrstu voća", "Vrsta voća");
        e.cancel = true;
        return;
    }

}

function onRowUpdatingCultures(e) {
    if (e.newData.CultureName != undefined) {
        if (jQuery.isEmptyObject(e.newData.CultureName) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.CultureName)))) {
            showInfo("Morate uneti vrstu voća", "Vrsta voća");
            e.cancel = true;
            return;
        }
    }
}



