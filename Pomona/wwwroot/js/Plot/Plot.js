function onRowInsertingPlot(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).PlotName) || e.data.PlotName == undefined) {
        showInfo("Morate uneti parcelu", "Parcela");
        e.cancel = true;
        isCanceledPlot = true;
        return;
    }
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).PlotLabel) || e.data.PlotLabel == undefined) {
        showInfo("Morate uneti oznaku parcele", "Parcela");
        e.cancel = true;
        isCanceledPlot = true;
        return;
    }
}

function onRowUpdatingPlot(e) {
    if (e.newData.PlotName != undefined) {
        if (jQuery.isEmptyObject(e.newData.PlotName) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.PlotName)))) {
            showInfo("Morate uneti parcelu", "Parcela");
            e.cancel = true;
            isCanceledPlot = true;
            return;
        }
    }

    if (e.newData.PlotLabel != undefined) {
        if (jQuery.isEmptyObject(e.newData.PlotLabel) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.PlotLabel)))) {
            showInfo("Morate oznaku parcele", "Parcela");
            e.cancel = true;
            isCanceledPlot = true;
            return;
        }
    }
}

var isCanceledPlot = false;
var test = false;
function onToolbarPreparingPlot(e) {
    $.each(e.toolbarOptions.items, function (i, v) {
        v.location = "before";
    })
    const addRowitem = e.toolbarOptions.items.find(item => item.name === 'addRowButton');
    addRowitem.options.onClick = function () {
        if (test) {
            e.component.addRow();
        } else {
            OpenPopup("/Plot/AddingPlotRows", "", 600, 300, "Redovi parcele", "AddingPlotRows");
        }
        //if (!e.component.option('editing.editRowKey')) {
        //    e.component.addRow();
        //}
        //else {
        //    isCanceledPlot = false;
        //    e.component.saveEditData().done(function (data) {
        //        if (!isCanceledPlot) {
        //            e.component.addRow();
        //        }
        //    });
        //}
      
    }
}


var plotForDelete;
function onPrepareDeletePlot(e) {
    plotForDelete = e.row.rowIndex;
    ShowPopupYesNo("Da li ste sigurni da želite da obrišete red parcele?", "PrepareDeletePlot", "Parcela");
}

function OnDeletePlot() {
    getPlotGrid().deleteRow(plotForDelete);
}


function PlotCountPerPage(e) {
    return "Broj redova:  " + getPlotGrid().getVisibleRows().length;
}

function addPlotRowsClick(e) {
    OpenPopup("/Plot/AddingPlotRows", "", 600, 300, "Redovi parcele", "AddingPlotRows");
}

function onSavePlotRows(e) {
    if (e.validationGroup.validate().isValid) {
        var theForm = $("#AddPlotRows").dxForm("instance");
        var formData = theForm.option("formData");
        $.ajax({
            url: virtualDirectory + '/Plot/SavePlotRows',
            type: 'POST',
            data: formData,
            success: function (data) {
                if (data.success) {
                    // var popup = $("#popupFormConfiguration").dxPopup('instance');
                   // popup.hide();                   
                    getPlotGrid().refresh();
                }
                else {
                    showInfo(data.result, "");
                }
            },
        });
    }
}

function getPlotGrid() {
    return $("#plotGrid").dxDataGrid("instance");
}


//DevExpress.ui.dxDataGrid.defaultOptions({
//    device: { deviceType: "desktop" },
//    options: {
//        customizeColumns: function (columns) {
//            columns.forEach((col) => {
//                if (col.lookup) {
//                    col.editorOptions = { placeholder: "test" }
//                }
//            });
//        }  
//    }
//});

//todo ne radi
function OnEditorPreparingPlot(e) {
    if (e.dataField == "PlotListId" && e.parentType === "dataRow") {
        e.editorOptions.placeholder = "test";
    }
}