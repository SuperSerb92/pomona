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