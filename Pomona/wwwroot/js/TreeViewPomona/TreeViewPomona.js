var timeout = null;
var lastComponent = {};


function TreeViewPomonaItemClick(e) {

    setTimeout(() => {
        e.component.unselectAll();
        e.component.selectItem(e.itemData);
    }, 300)

    //if (!timeout) {
    //    lastComponent = e.itemData;
    //    timeout = setTimeout(function () {
    //        timeout = null;
    //    }, 300);
    //}

    //todo: ako je row u editu 
    //var datagrid = $("#employeeGrid").dxDataGrid("instance");

    //if (datagrid != null) {
    //    var editRowIndex = $("#employeeGrid").dxDataGrid("instance").option("editing.editRowKey");
    //    if (editRowIndex != null) {
    //        datagrid.saveEditData();
    //    }
    //}

    //else if (e.itemData === lastComponent) {
    switch (e.node.key) {
        case 2:
            Redirect("/Employee/Employee", e.node.text);
            break;
        case 3:
            Redirect("/Home/EmptyView", e.node.text);
            OpenPopup("/ControlorEmployees/ControlorEmployees", "", 800, 850, e.node.text, "ControlorEmployees");
            break;
        case 4:
            Redirect("/Buyer/Buyer", e.node.text);
            break;
        case 5:
            Redirect("/Plot/Plot", e.node.text);
            break;
        case 6:
            Redirect("/Culture/Culture", e.node.text);
            break;
        case 7:
            Redirect("/CultureType/CultureType", e.node.text);
            break;
        case 8:
            Redirect("/Packaging/Packaging", e.node.text);
            break;
        case 10:
            Redirect("/BarCodeMenu/BarCodeMenu", e.node.text);
          //  OpenPopup("/BarCodeMenu/BarCodeGenerator", "", 550, 600, e.node.text, "");
            break;
        case 11:
            Redirect("/BarCodeReader/BarCodeReader", e.node.text);
            break;
        case 12:
            Redirect("/BarcodeStorn/BarcodeStorn", e.node.text);
            break;
        case 14:
            Redirect("/WorkEvaluation/WorkEvaluation", e.node.text);       
            break;      
        case 15:
            Redirect("/SummaryReport/SummaryReport", e.node.text);
            break;
        case 16:
            Redirect("/Repurchase/Repurchase", e.node.text);
            break;
        case 17:
            Redirect("/SummaryReportRepurchase/SummaryReportRepurchase", e.node.text);
            break;      
        case 18:
            Redirect("/ProfitLossReport/ProfitLossReport", e.node.text);
            break;
        case 19:
            Redirect("/Scheduler/Scheduler", e.node.text);
            break;
       
    }
    // }


}

function mapData(item) {
    if (item.ImageUrl) {
        item.icon = item.ImageUrl;
    }
    return item;
}



function Redirect(urlPath) {
    $.ajax({
        url: virtualDirectory + urlPath,
        type: "POST",
        success: function (data) {
            $("#renderbody").html(data);
            Pomona1.init1();
        }
    })
}