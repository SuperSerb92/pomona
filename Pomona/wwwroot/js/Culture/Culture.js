function onRowInsertingCultures(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).CultureName) || e.data.CultureName == undefined) {
        showInfo("Morate uneti vrstu voća", "Vrsta voća");
        e.cancel = true;
        isCanceledCultures = true;
        return;
    }

}

function onRowUpdatingCultures(e) {
    if (e.newData.CultureName != undefined) {
        if (jQuery.isEmptyObject(e.newData.CultureName) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.CultureName)))) {
            showInfo("Morate uneti vrstu voća", "Vrsta voća");
            e.cancel = true;
            isCanceledCultures = true;
            return;
        }
    }
}

var isCanceledCultures = false;

function onToolbarPreparingCultures(e) {
    $.each(e.toolbarOptions.items, function (i, v) {
        v.location = "before";
    })
    const addRowitem = e.toolbarOptions.items.find(item => item.name === 'addRowButton');
    addRowitem.options.onClick = function () {
        if (!e.component.option('editing.editRowKey')) {
            e.component.addRow();
        }
        else {
            isCanceledCultures = false;
            e.component.saveEditData().done(function (data) {
                if (!isCanceledCultures) {
                    e.component.addRow();
                }
            });
        }
    }
}


var cultureForDelete;
function onPrepareDeleteCulture(e) {
    cultureForDelete = e.row.rowIndex;
    ShowPopupYesNo("Da li ste sigurni da želite da obrišete vrstu voća?", "PrepareDeleteCulture", "Vrsta voća");
}

function onDeleteCulture() {
    $("#cultureGrid").dxDataGrid("instance").deleteRow(cultureForDelete);
}


function CultureCountPerPage(e) {
    return "Broj redova:  " + $("#cultureGrid").dxDataGrid("instance").getVisibleRows().length;
}