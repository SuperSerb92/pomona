function onRowInsertingPackaging(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).PackagingType) || e.data.PackagingType == undefined) {
        showInfo("Morate uneti tip ambalaže", "Ambalaža");
        e.cancel = true;
        return;
    }
    if ( /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).Tara) || e.data.Tara == undefined) {
        showInfo("Morate uneti taru", "Ambalaža");
        e.cancel = true;
        return;
    }
}

function onRowUpdatingPackaging(e) {
    if (e.newData.PackagingType != undefined) {
        if (jQuery.isEmptyObject(e.newData.PackagingType) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.PackagingType)))) {
            showInfo("Morate uneti tip ambalaže", "Ambalaža");
            e.cancel = true;
            return;
        }
    }

    if (e.newData.Tara != undefined) {
        if ( /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.Tara)))) {
            showInfo("Morate uneti taru", "Ambalaža");
            e.cancel = true;
            return;
        }
    }
}



