function onRowInsertingBuyers(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).BuyerName) || e.data.BuyerName == undefined) {
        showInfo("Morate uneti naziv otkupljivača", "Otkupljivači");
        e.cancel = true;
        return;
    }
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).Pib) || e.data.Pib == undefined) {
        showInfo("Morate uneti PIB otkupljivača", "Otkupljivači");
        e.cancel = true;
        return;
    }

    $.ajax({
        url: virtualDirectory + '/Buyer/CheckForDuplicatePib',
        type: 'POST',

        data: {
            Pib: e.data.Pib
        },      
        async: false,
        success: function (data) {
            if (data.success) {

            }
            else {
                showInfo("Već ste uneli otkupljivača sa ovim PIB-om", "Otkupljivači");
                e.cancel = true;
                return;
            }
        },
    });

    //getBuyerGrid().getDataSource()._items.forEach(function (entry) {
    //    if (entry.Pib == e.data.Pib) {
    //        showInfo("Već ste uneli otkupljivača sa ovim PIB-om", "Otkupljivači");
    //        e.cancel = true;
    //    }
    //});

}

function onToolbarPreparingBuyers(e) {
    const addRowitem = e.toolbarOptions.items.find(item => item.name === 'addRowButton');
    addRowitem.options.onClick = function () {
        if (!e.component.option('editing.editRowKey')) {
            e.component.addRow();
        }
        else {
            showInfo("Morate sačuvati red u izmeni", "Otkupljivači");
        }
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

    if (e.newData.Pib != undefined) {
        if (jQuery.isEmptyObject(e.newData.Pib) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.Pib)))) {
            showInfo("Morate uneti pib otkupljivača", "Otkupljivači");
            e.cancel = true;
            return;
        }

        $.ajax({
            url: virtualDirectory + '/Buyer/CheckForDuplicatePib',
            type: 'POST',

            data: {
                Pib: e.newData.Pib
            },

         //   data: e.newData.Pib,
            async: false,
            success: function (data) {
                if (data.success) {
                 
                }
                else {
                    showInfo("Već ste uneli otkupljivača sa ovim PIB-om", "Otkupljivači");
                    e.cancel = true;
                    return;
                }
            },
        });


        //getBuyerGrid().getDataSource()._items.forEach(function (entry) {
        //    if (entry.Pib == e.newData.Pib) {
        //        showInfo("Već ste uneli otkupljivača sa ovim PIB-om", "Otkupljivači");
        //        e.cancel = true;
        //    }
        //});
    }

}
var buyerForDelete;
function onPrepareDeleteBuyer(e) {
    buyerForDelete = e.row.rowIndex;
    ShowPopupYesNo("Da li ste sigurni da želite da obrišete otkupljivača?", "PrepareDeleteBuyer", "Otkupljivači");
}

function OnDeleteBuyer() {
    getBuyerGrid().deleteRow(buyerForDelete);
}


function getBuyerGrid() {
    return $("#buyerGrid").dxDataGrid("instance");
}



function BuyerCountPerPage(e) {
    return "Broj redova:  " + getBuyerGrid().getVisibleRows().length;
}