

var Pomona1 = (function () {

    var DRAWER_OPENED_KEY = "MetaDesigner-drawer-opened1";

    var breakpoints1 = {
        xSmallMedia: window.matchMedia("(max-width: 599.99px)"),
        smallMedia: window.matchMedia("(min-width: 600px) and (max-width: 959.99px)"),
        mediumMedia: window.matchMedia("(min-width: 960px) and (max-width: 1279.99px)"),
        largeMedia: window.matchMedia("(min-width: 1280px)")
    };

    function getDrawer1() {
        return $("#layout-drawer1").dxDrawer("instance");
    }

    function restoreDrawerOpened1() {
        var isLarge = breakpoints1.largeMedia.matches;
        if (!isLarge)
            return false;

        var state = sessionStorage.getItem(DRAWER_OPENED_KEY);
        if (state === null)
            return isLarge;

        return state === "true";
    }

    function saveDrawerOpened1() {
        if (getDrawer1() != undefined) {
            sessionStorage.setItem(DRAWER_OPENED_KEY, getDrawer1().option("opened"));
        }
    }

    function updateDrawer1() {
        var isXSmall = breakpoints1.xSmallMedia.matches,
            isLarge = breakpoints1.largeMedia.matches;

        if (getDrawer1() != undefined) {
            getDrawer1().option({
                //openedStateMode: isLarge ? "shrink" : "overlap",
                revealMode: isXSmall ? "slide" : "expand",
                //minSize: isXSmall ? 0 : 60,
                //shading: !isLarge,
            });
        }

        //if (isXSmall) { onMenuButtonClick(); }
    }

    function init1() {
        $("#layout-drawer-scrollview1").dxScrollView({ direction: "vertical" });

        $.each(breakpoints1, function (_, size) {
            size.addListener(function (e) {
                if (e.matches)
                    updateDrawer1();
            });
        });

        updateDrawer1();
    }

    function navigate1(url, delay) {
        if (url)
            setTimeout(function () { location.href = url }, delay);
    }

    function onMenuButtonClick1() {
        if (getDrawer1() != undefined) {
            getDrawer1().toggle();
            saveDrawerOpened1();
        }
    }

    function onTreeViewItemClick1(e) {
        var drawer = getDrawer1();
        var savedOpened = restoreDrawerOpened1();
        var actualOpened = drawer.option("opened");

        if (!actualOpened) {
            drawer.show();
        } else {
            var willHide = !savedOpened || !breakpoints1.largeMedia.matches;
            var willNavigate = !e.itemData.selected;

            if (willHide)
                drawer.hide();

            if (willNavigate)
                navigate1(e.itemData.path, willHide ? 400 : 0);
        }
    }

    return {
        init1: init1,
        restoreDrawerOpened1: restoreDrawerOpened1,
        onMenuButtonClick1: onMenuButtonClick1,
        onTreeViewItemClick1: onTreeViewItemClick1
    };
})();



function adjustSize() {

    var width;

    if ($("#userGrid").dxDataGrid("instance") != undefined) {
        var spanWidth = $('#scrollView').width() / 3;
        width = $('#scrollView').width() - spanWidth;

        $("#userGrid").dxDataGrid("instance").option("width", width);
        $("#userGrid")[0].offsetWidth = width;
    }
}

var actionType;



function ShowPopupYesNo(data, action, title) {
    var ins = $("#popup-messageYesNo").dxPopup('instance');
    ins.option("contentTemplate", null);
    ins.option("contentTemplate", $("#myPopupContentTemplate"));
    ins.content().append("<p>" + data + "</p>");
    ins.option("title", title);
    ins.show();

    actionType = action;
}


function onYes(e) {
    var popup = $("#popup-messageYesNo").dxPopup('instance');
    popup.hide();
    switch (actionType) { 
        case 'PrepareDeleteEmployee':
            OnDeleteEmployee();
            break;
        case 'PrepareDeleteBuyer':
            OnDeleteBuyer();
            break;
        case 'PrepareDeletePlot':
            OnDeletePlot();
            break;
        case 'HidingControlorEmployees':
            onHidingControlorEmployees();
            break;
        case 'PrepareDeleteCulture':
            onDeleteCulture();
            break;
        case 'PrepareDeleteCultureType':
            onDeleteCultureType();
            break;
        case 'PrepareDeletePackaging':
            onDeletePackaging();
            break;
            
    }
}

function onNo(e) {
    var popup = $("#popup-messageYesNo").dxPopup('instance');
    popup.hide();

    //var element = document.getElementById("popup-bottom");
    //element.style.display = "none";

    switch (actionType) {
        case 'HidingControlorEmployees':
            mainControl = "ControlorEmployees";
            break;
    }
}


var virtualDirectory = "";
var url = window.location.href.split('/');

//todo:
if (url != undefined && url != null)
    virtualDirectory = url[0] + "//" + url[2] + "/" + url[3];
   

if (virtualDirectory.slice(-1) == "/") 
    virtualDirectory = virtualDirectory.slice(0, -1);

if (virtualDirectory.slice(-1) == "#")
    virtualDirectory = virtualDirectory.slice(0, -1);


let searchParams = new URLSearchParams((new URL(window.location.href)).search);
var autentification = searchParams.get("autentification");
var token = searchParams.get("token");
console.log(searchParams);

function onLogoutClick(e) {    
    window.location.href = "/Pomona/Login/Login";
}


var partialViewDataGlobalCommon;

function OpenPopupCommon(urlPath, data, width, height, text) {
    $.ajax({
        url: virtualDirectory + urlPath,
        type: 'POST',
        data: data,
        success: function (partialViewData) {
            if (partialViewData.success == undefined) {
                partialViewDataGlobalCommon = partialViewData;
                var popup = $("#popupFormCommon").dxPopup('instance');
                popup.option("title", text);
                popup.option("width", width);
                popup.option("height", height);

                popup.option("contentTemplate", null);
                popup.option("contentTemplate", $("#popup-templateCommon"));

                popup.show();
            }        
           else { showInfo(partialViewData.result, "Error"); }
        },
    });
}

function onContentReadyCommon(e) {
    var contentElement = $('#scrollViewCommon').dxScrollView('instance').content();
    contentElement.html(partialViewDataGlobalCommon);
}

function onHidingCommon(s, e) {

}

function ValidateSelectBox(data) {
    if (data.value == 0 || data.value == null) return false;
    return true;
}

