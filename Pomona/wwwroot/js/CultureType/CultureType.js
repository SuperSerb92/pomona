function onRowInsertingCultureTypes(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).CultureTypeName) || e.data.CultureTypeName == undefined) {
        showInfo("Morate uneti sortu voća", "Sorta voća");
        e.cancel = true;
        return;
    }

}

function onRowUpdatingCultureTypes(e) {
    if (e.newData.CultureTypeName != undefined) {
        if (jQuery.isEmptyObject(e.newData.CultureTypeName) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.CultureTypeName)))) {
            showInfo("Morate uneti sortu voća", "Sorta voća");
            e.cancel = true;
            return;
        }
    }
}



