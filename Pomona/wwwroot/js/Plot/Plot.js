function onRowInsertingPlot(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).PlotName) || e.data.PlotName == undefined) {
        showInfo("Morate uneti parcelu", "Parcela");
        e.cancel = true;
        return;
    }
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).PlotLabel) || e.data.PlotLabel == undefined) {
        showInfo("Morate uneti oznaku parcele", "Parcela");
        e.cancel = true;
        return;
    }
}

function onRowUpdatingPlot(e) {
    if (e.newData.PlotName != undefined) {
        if (jQuery.isEmptyObject(e.newData.PlotName) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.PlotName)))) {
            showInfo("Morate uneti parcelu", "Parcela");
            e.cancel = true;
            return;
        }
    }

    if (e.newData.PlotLabel != undefined) {
        if (jQuery.isEmptyObject(e.newData.PlotLabel) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.PlotLabel)))) {
            showInfo("Morate oznaku parcele", "Parcela");
            e.cancel = true;
            return;
        }
    }
}


function onToolbarPreparingPlot(e) {
    const addRowitem = e.toolbarOptions.items.find(item => item.name === 'addRowButton');
    addRowitem.options.onClick = function () {
        if (!e.component.option('editing.editRowKey')) {
            e.component.addRow();
        }
        else {
            showInfo("Morate sačuvati red u izmeni", "Radnici");
        }
    }
}


var plotForDelete;
function onPrepareDeletePlot(e) {
    plotForDelete = e.row.rowIndex;
    ShowPopupYesNo("Da li ste sigurni da želite da obrišete parcelu?", "PrepareDeletePlot", "Parcela");
}

function OnDeletePlot() {
    getPlotGrid().deleteRow(plotForDelete);
}


function PlotCountPerPage(e) {
    return "Broj redova:  " + getPlotGrid().getVisibleRows().length;
}



function getPlotGrid() {
    return $("#plotGrid").dxDataGrid("instance");
}

