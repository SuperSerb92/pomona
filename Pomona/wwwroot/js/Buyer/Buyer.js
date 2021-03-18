function onRowInsertingBuyers(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).Name) || e.data.Name == undefined) {
        showInfo("Morate uneti ime radnika", "Radnici");
        e.cancel = true;
        return;
    }
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).Surname) || e.data.Surname == undefined) {
        showInfo("Morate uneti prezime radnika", "Radnici");
        e.cancel = true;
    }
}

function onRowUpdatingBuyers(e) {
    if (e.newData.Name != undefined) {
        if (jQuery.isEmptyObject(e.newData.Name) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.Name)))) {
            showInfo("Morate uneti ime radnika", "Radnici");
            e.cancel = true;
            return;
        }
    }
    if (e.newData.Surname != undefined) {
        if (jQuery.isEmptyObject(e.newData.Surname) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.Surname)))) {
            showInfo("Morate uneti prezime radnika", "Radnici");
            e.cancel = true;
            return;
        }
    }
}

function OnFocusedRowChangedBuyers(e) {
    //var editRowIndex = getBuyerGrid().option("editing.editRowKey");
    //if (editRowIndex != null) {
    //    e.component.saveEditData();
    //}
}


function getBuyerGrid() {
    return $("#buyerGrid").dxDataGrid("instance");
}


