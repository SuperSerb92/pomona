function saveBarCodeClick(e) {

    showInfo("Nisi sacuvao ovo je samo fora", "BarCode");
}

function getBarCodeGrid() {
    return $("#barcodeGrid").dxDataGrid("instance");
}
function getBarCodeGridReader() {
    return $("#barcodeReaderGrid").dxDataGrid("instance");
}

var source = [];
var source1 = [];
var clonedItem = null;
function onCloneIconClick(e) {

    //source = getBarCodeGrid().getDataSource();
    var source3 = $("#barcodeGrid").dxDataGrid("instance");
    clonedItem = $.extend({}, e.row.data, { BarCode: ++source3.BarCode });
    if (clonedItem.IndPrint == undefined || clonedItem.IndPrint == 0) {
        showInfo("Morate prvo generisati Barkod.", "Barcode");
        e.cancel = true;
        isCanceled = true;
        return;
    }
        if (clonedItem.Status == 0) {
            //  source.items().splice(e.row.rowIndex, 0, clonedItem);
            // source.store().insert(clonedItem).then(function () {
            ///   source.reload();
            // });
            clonedItem.BarCode = "";
            clonedItem.StatusDisplay = "";
            clonedItem.IndPrint = 0;
            clonedItem.Status = 0;
            clonedItem.Bruto = 0;
            clonedItem.Neto = 0;
            clonedItem.Rbr = 0;
            if (clonedItem.PlotId == 0) {
                clonedItem.PlotId = null;
            }
            source3.addRow();       
    }
   // e.component.refresh(true);
    e.event.preventDefault();
}
function onInitNewRow(args) {
    if (clonedItem) {
        args.data = clonedItem;
    }
    else { args.data.DateGenerated = new Date(); }
    clonedItem = null;
}
var barcodeForDelete;
var barcodeForDelete1;
function onPrepareDeleteBarcode(e) {
    barcodeForDelete1 = e.row.rowIndex;
    ShowPopupYesNo("Da li ste sigurni da želite da stornirate Barcode?", "PrepareStornBarcode", "BarCode");
}
function onPrepareDeleteBarcodeRead(e) {
    barcodeForDelete = e.row.rowIndex;
    ShowPopupYesNo("Da li ste sigurni da želite da stornirate Barcode?", "PrepareStornBarcodeRead", "BarCode");
}
function OnDeleteBarcode() {
    $("#barcodeGrid").dxDataGrid("instance").deleteRow(barcodeForDelete1);
}
function OnDeleteBarcodeReader() {
    getBarCodeGridReader().deleteRow(barcodeForDelete);
}

function onPreparePrint(e) {

    var Barcode = e.row.key; //if you want to pass an Id parameter
   
    $.ajax({
        url: virtualDirectory + '/BarCodeMenu/Print',
        type: 'POST',
        data: { Barcode:Barcode },
        success: function (data) {
            if (data.success) {
                popupWithHidden = 'Registration';
                showInfoWithHidden("Uspešno ste se odštampali", "BarCode");
                
                //   $("#popupFormRegistration").dxPopup('instance').hide();
            }
            else {
                showInfo(data.result, "Štampa barkoda");
            }
        },
    });
}
function onToolbarPreparing(e) {
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
function getCultureTypes(options) {
    return {
        store: DevExpress.data.AspNet.createStore({
            key: "CultureTypeId",
            loadUrl: virtualDirectory + '/BarCodeMenu/Get'
        }),
        filter: options.data ? ["CultureId", "=", options.data.CultureId] : null
    };
}
function setStateValue(rowData, value) {
    rowData.CultureId = value;
    rowData.CultureTypeId = null;
}
function getPlots(options) {
    return {
        store: DevExpress.data.AspNet.createStore({
            key: "PlotId",
            loadUrl: virtualDirectory + '/BarCodeMenu/GetPl'
        }),
        filter: options.data ? ["PlotListId", "=", options.data.PlotListId] : null
    };
}
function setPlotStateValue(rowData, value) {
    rowData.PlotListId = value;
    rowData.PlotId = null;  
}
function toolbar_preparing(e) {
    var dataGrid = e.component;

    e.toolbarOptions.items.unshift({
        location: "before",
        widget: "dxDateBox",
        options: {
            width: 200           
            //onValueChanged: function (e) {
            //    dataGrid.clearGrouping();
            //    dataGrid.columnOption(e.value, "groupIndex", 0);
            //    $(".informer .count").text(getGroupCount(e.value));
            //}
        }
    });
}
function onRowInsertingBarCode(e) {
    if (jQuery.isEmptyObject(e.data) || e.data.EmployeeID==0 || e.data.EmployeeID == undefined) {
        showInfo("Morate izabrati radnika", "Barcode");
        e.cancel = true;
        isCanceled = true;
        return;
    }
    if (jQuery.isEmptyObject(e.data) || e.data.UserID==0 || e.data.UserID == undefined) {
        showInfo("Morate izabrati kontrolora", "Barcode");
        e.cancel = true;
        isCanceled = true;
        return;
    }
    if (jQuery.isEmptyObject(e.data)  || e.data.DateGenerated == undefined) {
        showInfo("Morate izabrati datum", "Barcode");
        e.cancel = true;
        isCanceled = true;
        return;
    } else {
        const start =new Date(e.data.DateGenerated);
        const offset = start.getTimezoneOffset();
        if (offset < 0) {
            start.setHours(12, 0, 0);
            e.data.DateGenerated = start.toLocaleDateString();
        }
    }
    if (jQuery.isEmptyObject(e.data) || e.data.PlotListId == 0 || e.data.PlotListId == undefined) {
        showInfo("Morate izabrati parcelu", "Barcode");
        e.cancel = true;
        isCanceled = true;
        return;
    }
    if (jQuery.isEmptyObject(e.data) || e.data.CultureId == 0 || e.data.CultureId == undefined) {
        showInfo("Morate izabrati vrstu voća", "Barcode");
        e.cancel = true;
        isCanceled = true;
        return;
    }
    if (jQuery.isEmptyObject(e.data) || e.data.CultureTypeId == 0 || e.data.CultureTypeId == undefined) {
        showInfo("Morate izabrati sortu voća", "Barcode");
        e.cancel = true;
        isCanceled = true;
        return;
    }
    if (jQuery.isEmptyObject(e.data) || e.data.PackagingId == 0 || e.data.PackagingId == undefined) {
        showInfo("Morate izabrati tip ambalaže", "Barcode");
        e.cancel = true;
        isCanceled = true;
        return;
    }
} 
function onRowUpdatingRead(e) {
    if (e.newData.Bruto <= e.oldData.Tara) {
        showInfo("Bruto je manja od Tare", "Barcode");
        e.cancel = true;
        isCanceled = true;
        
        return;
    }
    $("#barcodeReaderGrid").dxDataGrid("instance").clearFilter();
}
function Measure(e) {

    var Barcode = e.row.key; 
    $.ajax({
        url: virtualDirectory + '/BarCodeReader/Measure',
        type: 'GET',
        data: { key: Barcode },
        key: "BarCode",
        success: function (data) {
            if (data.success) {
                var dataSource = $("#barcodeReaderGrid").dxDataGrid("instance");               
                dataSource.option("dataSource", data.result);
                dataSource.clearFilter();
            }
            else {
                showInfo(data.result, "Merenje");
            }
        },
    });
  
}
var user = 0;
function cellValueWorker(rowData, value) {
    rowData.EmployeeID = value;
    $.ajax({
        url: virtualDirectory + '/BarCodeMenu/GetSuperVisor',
        type: 'GET',
        data: { key: value },
        key: "BarCode",
        success: function (data) {
            if (data.success) {
                user = data.result;
                if (user != 0) {
                    $("#barcodeGrid").dxDataGrid("instance").cellValue(0, "UserID", user);
                }
              //  rowData.UserID = user;
            }
            else {
               user = 0;
            }
        },
    });
}


