var timeout = null;
var lastComponent = {};


function TreeViewPomonaItemClick(e) {

    if (!timeout) {
        lastComponent = e.itemData;
        timeout = setTimeout(function () {
            timeout = null;
        }, 300);
    }

    //todo: ako je row u editu 
    //var datagrid = $("#employeeGrid").dxDataGrid("instance");

    //if (datagrid != null) {
    //    var editRowIndex = $("#employeeGrid").dxDataGrid("instance").option("editing.editRowKey");
    //    if (editRowIndex != null) {
    //        datagrid.saveEditData();
    //    }
    //}

    else if (e.itemData === lastComponent) {
        switch (e.node.key) {
            case 2:
                Redirect("/Employee/Employee", e.node.text);
                break;
            case 3:
                 OpenPopup("/ControlorEmployees/ControlorEmployees", "", 800, 850,  e.node.text);
                break;
            case 4:
                Redirect("/Buyer/Buyer", e.node.text);
                break;
            case 5:
              //  Redirect("/Plot/Plot", e.node.text);
                break;
            case 6:
             //   Redirect("/Culture/Culture", e.node.text);
                break;
            case 7:
             //   Redirect("/CultureType/CultureType", e.node.text);
                break;
            case 8:
               // Redirect("/Packaging/Packaging", e.node.text);
                break;
            case 9:
                //OpenPopup("/BarCodeGenerator/BarCodeGenerator","", 500,500, e.node.text, "");
                break;
        }
    }


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