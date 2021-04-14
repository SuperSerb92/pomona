function onRowInsertingPackaging(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).PackagingType) || e.data.PackagingType == undefined) {
        showInfo("Morate uneti tip ambalaže", "Ambalaža");
        e.cancel = true;
        isCanceledPackaging = true;
        return;
    }
    if ( /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).Tara) || e.data.Tara == 0) {
        showInfo("Morate uneti taru", "Ambalaža");
        e.cancel = true;
        isCanceledPackaging = true;
        return;
    }
}

function onRowUpdatingPackaging(e) {
    if (e.newData.PackagingType != undefined) {
        if (jQuery.isEmptyObject(e.newData.PackagingType) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.PackagingType)))) {
            showInfo("Morate uneti tip ambalaže", "Ambalaža");
            e.cancel = true;
            isCanceledPackaging = true;
            return;
        }
    }

    if (e.newData.Tara != undefined) {
        if (/^\s*$/.test(JSON.parse(JSON.stringify(e.newData.Tara))) || e.newData.Tara == 0 )   {
            showInfo("Morate uneti taru", "Ambalaža");
            e.cancel = true;
            isCanceledPackaging = true;
            return;
        }
    }
}




var isCanceledPackaging = false;

function onToolbarPreparingPackaging(e) {
    $.each(e.toolbarOptions.items, function (i, v) {
        v.location = "before";
    })
    const addRowitem = e.toolbarOptions.items.find(item => item.name === 'addRowButton');
    addRowitem.options.onClick = function () {
        if (!e.component.option('editing.editRowKey')) {
            e.component.addRow();
        }
        else {
            isCanceledPackaging = false;
            e.component.saveEditData().done(function (data) {
                if (!isCanceledPackaging) {
                    e.component.addRow();
                }
            });
        }
    }
}


var PackagingForDelete;
function onPrepareDeletePackaging(e) {
    PackagingForDelete = e.row.rowIndex;
    ShowPopupYesNo("Da li ste sigurni da želite da obrišete ambalažu?", "PrepareDeletePackaging", "Ambalaža");
}

function onDeletePackaging() {
    $("#packagingGrid").dxDataGrid("instance").deleteRow(PackagingForDelete);
}
function PackagingCountPerPage(e) {
    return "Broj redova:  " + $("#packagingGrid").dxDataGrid("instance").getVisibleRows().length;
}