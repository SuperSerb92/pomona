function getBarCodeGrid() {
    return $("#summaryReportGrid").dxDataGrid("instance");
}
function getPlotList() {
    return $("#PlotListSelectBox").dxSelectBox("instance");
}


function OnClickbtnFill(e) {
   //treba da vrati podatke na formu
    var datedit1 = $("#dateFrom").dxDateBox("instance");
    var datedit2 = $("#dateTo").dxDateBox("instance");
    var localni1 = new Date(datedit1.option("value")).toISOString();
    var localni2 = new Date(datedit2.option("value")).toISOString();

    $.ajax({
        url: virtualDirectory + '/SummaryReport/GetSummary',
        type: 'GET',
        data: {
            DatumOd: localni1,
            DatumDo: localni2
        },
        success: function (data) {
            if (data.success) {
 
                var dataSource = $("#summaryReportGrid").dxDataGrid("instance");
                dataSource.option("dataSource", data.result)
                //dataSource.store().insert(data.result).then(function () {
                //    dataSource.reload();
                //})
            }
            else {
                showInfo(data.result, "Sumarni izvestaj");
            }
        },
    });
   
}
function customSummary(options) {
    if (options.name === "DistinctRadnik") {
        if (options.summaryProcess === "start") {
            options.totalValue = 0;
        }
        if (options.summaryProcess === "calculate") {

            if (options.value.DistinctNoWorkers) {
                options.totalValue = options.totalValue + options.value.DistinctNoWorkers;
            }
        }
        if (options.summaryProcess === "finalize") {
            //
        }
    }
}
function exporting(e) {
    var workbook = new ExcelJS.Workbook();
    var worksheet = workbook.addWorksheet('Sumarni izvestaj');

    DevExpress.excelExporter.exportDataGrid({
        component: e.component,
        worksheet: worksheet,
        autoFilterEnabled: true
    }).then(function () {
        workbook.xlsx.writeBuffer().then(function (buffer) {
            saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Sumarni izvestaj.xlsx');
        });
    });
    e.cancel = true;
}
function print() {
    window.jsPDF = window.jspdf.jsPDF;
    var doc = new jsPDF();
    var dataGrid = $("#summaryReportGrid").dxDataGrid("instance");
    DevExpress.pdfExporter.exportDataGrid({
        jsPDFDocument: doc,
        component: dataGrid
    }).then(function () {
        doc.save("Sumarni izvestaj.pdf");
    });
}
function printGrid() {
    var gridElement = $("#summaryReportGrid").dxDataGrid("instance"),
        printableContent = '',
        win = window.open('', '', 'width=800, height=500, resizable=1, scrollbars=1'),
        doc = win.document.open();


    //var gridHeader = gridElement.children('.k-grid-header');
    //if (gridHeader[0]) {
    //    var thead = gridHeader.find('thead').clone().addClass('k-grid-header');
    //    printableContent = gridElement
    //        .clone()
    //        .children('.k-grid-header').remove()
    //        .end()
    //        .children('.k-grid-content')
    //        .find('table')
    //        .first()
    //        .children('tbody').before(thead)
    //        .end()
    //        .end()
    //        .end()
    //        .end()[0].outerHTML;
    //} else {
        printableContent = gridElement.clone()[0].outerHTML;
   // }

    doc.write(printableContent);
    doc.close();
    win.print();

}

    