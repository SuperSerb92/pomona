function getSummaryRepurchaseGrid() {
    return $("#summaryReportRepurchaseGrid").dxDataGrid("instance");
}

function OnClickbtnFillRep(e) {
    //treba da vrati podatke na formu
    var datedit1 = $("#dateFromRep").dxDateBox("instance");
    var datedit2 = $("#dateToRep").dxDateBox("instance");
    var localni1 = new Date(datedit1.option("value")).toISOString();
    var localni2 = new Date(datedit2.option("value")).toISOString();

    $.ajax({
        url: virtualDirectory + '/SummaryReportRepurchase/GetSummaryRepurchase',
        type: 'GET',
        data: {
            DatumOd: localni1,
            DatumDo: localni2
        },
        success: function (data) {
            if (data.success) {

                var dataSource = $("#summaryReportRepurchaseGrid").dxDataGrid("instance");
                dataSource.option("dataSource", data.result)
                //dataSource.store().insert(data.result).then(function () {
                //dataSource.reload();
                //})
            }
            else {
                showInfo(data.result, "Sumarni izvestaj - Otkup");
            }
        },
    });

}

function printRep() {

    window.jsPDF = window.jspdf.jsPDF;
    var doc = new jsPDF();
    //doc.addFileToVFS('./fonts/Roboto-Regular.ttf', './Roboto-Regular-normal.js');
    //doc.addFileToVFS('./fonts/Roboto-Bold.ttf', './Roboto-Bold-bold.js');

    //doc.addFont('./fonts/Roboto-Regular.ttf', 'Roboto', 'normal')
    //doc.addFont('./fonts/Roboto-Regular.ttf', 'Roboto', 'bold')
    //doc.setFont('Roboto')

   
    var dataGrid = $("#summaryReportRepurchaseGrid").dxDataGrid("instance");
    DevExpress.pdfExporter.exportDataGrid({
        jsPDFDocument: doc,
        component: dataGrid                
    }).then(function () {
        doc.save("Sumarni izvestaj - Otkup.pdf");
    });
}

function onRowUpdatingSummaryRep(e) {

    if (e.newData.Comment == undefined) {
        e.newData.Comment = null;
    }
    var datum;
    var paid;
    if (e.newData.PaidDate == undefined) {
        datum = e.oldData.PaidDate;
    } else {
        datum = e.newData.PaidDate;
    }
    if (e.newData.Paid == undefined) {
        paid = e.oldData.Paid;
    } else {
        paid = e.newData.Paid;
    }
    var datumP = new Date(datum).toISOString();
    $.ajax({
        url: virtualDirectory + '/SummaryReportRepurchase/UpdateReportRepurchase',
        type: 'Put',
        data: {
            key: e.oldData.Id,
            values: e.newData.Comment,
            datumPlacanja: datumP,
            placeno: paid
        }//,
        //success: function (data) {
        //    if (data.success) {

        //        var dataSource = $("#summaryReportRepurchaseGrid").dxDataGrid("instance");
        //        dataSource.option("dataSource", data.result)
        //        //dataSource.store().insert(data.result).then(function () {
        //        //dataSource.reload();
        //        //})
        //    }
        //    else {
        //        showInfo(data.result, "Sumarni izvestaj - Otkup");
        //    }
        //},
    });
}