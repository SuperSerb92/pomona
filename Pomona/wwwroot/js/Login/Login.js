
$(function () {
    $('.focus :input').focus();
});

function OnClickbtnLogin(e) {
    if (e.validationGroup.validate().isValid) {

        $('#loginButton').dxButton('instance').option('disabled', true);

        var theForm = $("#loginForm").dxForm("instance");
        var formData = theForm.option("formData");
        $.ajax({
            url: virtualDirectory + '/Login/Login',
            type: 'POST',
            data: formData,
            success: function (data) {
                if (data.success) {
                    location.href = virtualDirectory + '/Home/Index';
                }
                else {
                    showInfo(data.message, "Login");
                    $('#loginButton').dxButton('instance').option('disabled', false);
                }
            },
        });
    }
}

var partialViewDataGlobalReg;

function OnClickCreateAccount(e) {
    openRegPopup("/Login/Registration", 670, 500, "Registracija");
}

function openRegPopup(urlPath, width, height, text) {
    $.ajax({
        url: virtualDirectory + urlPath,
        type: 'POST',
        async: false,
        success: function (partialViewData) {
            if (partialViewData.success == undefined) {
                partialViewDataGlobalReg = partialViewData;
                var popup = $("#popupFormRegistration").dxPopup('instance');
                popup.option("title", text);
                popup.option("width", width);
                popup.option("height", height);

                popup.option("contentTemplate", null);
                popup.option("contentTemplate", $("#popup-templateRegistration"));

                popup.show();
            } else {
                showInfo(partialViewData.result, "");
            }
        },
    });
}


function onContentReadyRegistration(e) {
    var contentElement = $('#scrollViewRegistration').dxScrollView('instance').content();
    contentElement.html(partialViewDataGlobalReg);
}


function OnRegistration(e) {
  //  var email = $("#Email").dxTextBox("instance").option("value");

    var theForm = $("#regForm").dxForm("instance");

    var formData = theForm.option("formData");
    $.ajax({
        url: virtualDirectory + '/Login/CreateAccount',
        type: 'POST',
        data: formData,
        success: function (data) {
            if (data.success) {
                location.href = virtualDirectory + '/Home/Index';
            }
            else {
                showInfo(data.message, "Registration");
            }
        },
    });
}
function onCancelRegistration(e) {

}

function showInfo(data, title) {
    var ins = $("#popup-message").dxPopup('instance');

    ins.option("contentTemplate", null);
    ins.option('contentTemplate', function (contentElement) {
        contentElement.append(data);
    })
    ins.option("title", title);
    ins.show();
}

function SubmitLoginForm(e) {
    document.getElementById("loginButton").click();
}

