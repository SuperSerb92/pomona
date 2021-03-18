var timeout = null;
var lastComponent = {};


function TreeViewPomonaItemClick(e) {

    if (!timeout) {
        lastComponent = e.itemData;
        timeout = setTimeout(function () {
            timeout = null;
        }, 300);
    }
    else if (e.itemData === lastComponent) {
        switch (e.node.key) {
            case 2:
                Redirect("/Employee/Employee", e.node.text);
                break;
            case 3:
                OpenPopup("/ControlorEmployees/ControlorEmployees", "", 750, 850,  e.node.text);
                break;
            case 4:
                Redirect("/Buyer/Buyer",  e.node.text);
                break;
            case 9:
                OpenPopup("/BarCodeGenerator/BarCodeGenerator","", 500,500, e.node.text, "");
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