function onRowInsertingBuyers(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).BuyerName) || e.data.BuyerName == undefined) {
        showInfo("Morate uneti naziv otkupljivača", "Otkupljivači");
        e.cancel = true;
        return;
    }
 
}

function onRowUpdatingBuyers(e) {
    if (e.newData.Name != undefined) {
        if (jQuery.isEmptyObject(e.newData.BuyerName) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.BuyerName)))) {
            showInfo("Morate uneti naziv otkupljivača", "Otkupljivači");
            e.cancel = true;
            return;
        }
    }   
}


function getBuyerGrid() {
    return $("#buyerGrid").dxDataGrid("instance");
}


