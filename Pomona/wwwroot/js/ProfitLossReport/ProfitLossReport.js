function OnClickbtnFillProfit(e) {
    //treba da vrati podatke na formu
    var datedit1 = $("#dateFrom").dxDateBox("instance");
    var datedit2 = $("#dateTo").dxDateBox("instance");
    var localni1 = new Date(datedit1.option("value")).toISOString();
    var localni2 = new Date(datedit2.option("value")).toISOString();

    $.ajax({
        url: virtualDirectory + '/ProfitLossReport/GetProfitLoss',
        type: 'GET',
        data: {
            DatumOd: localni1,
            DatumDo: localni2
        },
        success: function (data) {
            if (data.success) {

                var dataSource = $("#profitLossReportGrid").dxDataGrid("instance");
                dataSource.option("dataSource", data.result)

                var dataSourceChart = $("#line-chart").dxChart("instance");
                dataSourceChart.option("dataSource", data.result)
             
            }
            else {
                showInfo(data.result, "Profit/Gubitak izveštaj");
            }
        },
    });

    $.ajax({
        url: virtualDirectory + '/ProfitLossReport/GetProfitLossSum',
        type: 'GET',
        data: {
            DatumOd: localni1,
            DatumDo: localni2
        },
        success: function (data) {
            if (data.success) {

                var pitaSource = $("#pita").dxPieChart("instance");
                pitaSource.option("dataSource", data.result);
                //dataSource.store().insert(data.result).then(function () {
                //    dataSource.reload();
                //})
            }
            else {
                showInfo(data.result, "Profit/Gubitak izveštaj");
            }
        },
    });


    $.ajax({
        url: virtualDirectory + '/ProfitLossReport/GetAvgPrice',
        type: 'GET',
        data: {
            DatumOd: localni1,
            DatumDo: localni2
        },
        success: function (data) {
            if (data.success) {

                if (data.result > 0) {
                    $("#ProsecnaCena")
                        .dxTextBox("instance")
                        .option("value", data.result + " RSD");
                }         

            }
            else {
                showInfo(data.result, "Profit/Gubitak izveštaj");
            }
        },
    });
}