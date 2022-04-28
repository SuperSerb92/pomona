var dateEditor;
var millisecondsInDay = 24 * 60 * 60 * 1000;


function dateOnInitializedR(e) {
    dateEditor = e.component;
}

function todayR() {
    dateEditor.option("value", new Date().getTime());
}
var datumPrethodni;
function prevDateR() {
    dateEditor.option("value", dateEditor.option("value") - millisecondsInDay);
}

function nextDateR() {
    dateEditor.option("value", dateEditor.option("value") + millisecondsInDay);
}
function filterGridOnStartR(e) {
    var datum = new Date(dateEditor.option("value")).toLocaleDateString();
    var dataGrid = $("#repurchaseGrid").dxDataGrid("instance");
    dataGrid.filter(["Date", "=", Date.parse(datum)]);
}
function dateChangedR(data) {
    console.log(data);
    var localni = new Date(data.value).toLocaleDateString();
    var dataGrid = $("#repurchaseGrid").dxDataGrid("instance");
    dataGrid.filter(["Date", "=", Date.parse(localni)]);
} 
function onInitNewRowR(args) {

    args.data.Date = dateEditor.option("value"); //new Date(); 
   
 
}
function setStateValueNeto(rowData, value) {
    rowData.BuyerId = value;
    
    //if (rowData.CultureId != undefined) {
       
    rowData.Neto = neto;
    rowData.NoOfBoxes = brojKutija;
 //   }
}
function onRowInsertingRepurchase(e) {
    if (jQuery.isEmptyObject(e.data) || e.data.Date == undefined) {
        showInfo("Morate izabrati datum", "Otkup");
        e.cancel = true;
        isCanceled = true;
        return;
    } else {
        const start = new Date(e.data.Date);
        const offset = start.getTimezoneOffset();
        if (offset < 0) {
            start.setHours(12, 0, 0);
            e.data.Date = start.toLocaleDateString();
        }
    }
}
function onToolbarPreparingR(e) {
    $.each(e.toolbarOptions.items, function (i, v) {
        v.location = "before";
    })
    const addRowitem = e.toolbarOptions.items.find(item => item.name === 'addRowButton');
    addRowitem.options.onClick = function () {
        if (!e.component.option('editing.editRowKey')) {
            e.component.addRow();
        }
        else {
            isCanceled = false;
            e.component.saveEditData().done(function (data) {
                if (!isCanceled) {
                    e.component.addRow();
                }
            });
        }
    }
}
var RowForDelete;
function onPrepareDeleteRep(e) {
    RowForDelete = e.row.rowIndex;
    ShowPopupYesNo("Da li ste sigurni da želite da obrišete red?", "PrepareDeleteRep", "Otkup");
}
function OnDeleteRepurchase() {
    $("#repurchaseGrid").dxDataGrid("instance").deleteRow(RowForDelete);
}
var neto = 0;
var brojKutija = 0;
function cellChanged(e) {
    if (e.row.data.CultureId != undefined) {
        $.ajax({
            url: virtualDirectory + '/Repurchase/GetNeto',
            type: 'GET',
            data: {
                key: e.row.data.CultureId,
                date: new Date(dateEditor.option("value")).toLocaleDateString()
            },
            key: "Id",
            success: function (data) {
                if (data.success) {
                    neto = data.result;
                }
                else {
                    showInfo(data.result, "Otkup");
                }
            },
        });
        $.ajax({
            url: virtualDirectory + '/Repurchase/GetNoOfBoxes',
            type: 'GET',
            data: {
                key: e.row.data.CultureId,
                date: new Date(dateEditor.option("value")).toLocaleDateString()
            },
            key: "Id",
            success: function (data) {
                if (data.success) {
                    brojKutija = data.result;
                }
                else {
                    showInfo(data.result, "Otkup");
                }
            },
        });
    }
}