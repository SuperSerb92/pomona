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



