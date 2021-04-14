function OnSelectionChangedControlor(e) {
  
    $.ajax({
        url: virtualDirectory + '/ControlorEmployees/GetSelectedData?UserId=' + e.component.option("value"),
        type: 'GET',
        async: false,
        success: function (data) {
            if (data.success) {
                var dataGrid = $("#ControlorEmployeesGrid").dxDataGrid("instance");
                dataGrid.clearSelection();
                dataGrid.option("focusedRowIndex", -1);
                if (data.result) {
                  
                    var keys = dataGrid.getSelectedRowKeys();
                    dataGrid.deselectRows(keys);

                    var list = [];
                    if (data.result.length > 0) {
                        for (var i = 0; i < data.result.length; i++) {
                            list.push(data.result[i]);
                        }
                        dataGrid.selectRows(list, false);
                    }
                }
            }
            else {
                showInfo(data.result, "Kontrolori");
            }
        },
    });
}

function OnContentReadyControlors(e) {
    ("#ControlorsSelectBox").dxSelectBox("instance").option("value", 1); // 1 instead of "Dark"  
}

function OnCellPreparedCE(e) {
    if (e.rowType == "filter" && e.column.type == "selection") {
        var grid = e.component;
        var myEditor = $("<div />").dxSelectBox({
            dataSource: ["Svi", "Selektovani", "Deselektovani"],
            value: "Svi",
            onValueChanged: function (args) {
                if (args.value == "Svi") {
                    grid.clearFilter("dataSource");
                } else {
                    var keys = grid.getSelectedRowKeys();
                    var filter = [];
                    keys.forEach(function (key) {
                        filter.push(["EmployeeID", key]);
                        filter.push("or");
                    });
                    filter.pop();

                    if (args.value == "Deselektovani") {
                        filter = ["!", filter];
                    }

                    grid.filter(filter);
                }
            },
            dropDownOptions: { width: 200 }
        });

        e.cellElement.html(myEditor);
        e.cellElement.addClass("dx-editor-cell");
    }
}

//function onToolbarPreparingPlot(e) {
//    var dataGrid = e.component;

//    e.toolbarOptions.items.unshift({
//        location: "after",
//        widget: "dxButton",
//        options: {
//            icon: "filter",
//            onClick: function () {
//                if (filteredState)
//                    dataGrid.clearFilter();
//                else
//                    dataGrid.filter([["isActive", "=", true]]);

//                filteredState = !filteredState;
//            }
//        }
//    });
//}

var selectAllCheckBox;
var checkBoxUpdating = false;


function onEditorPreparingCE(e) {
    var dataGrid = e.component;
    //if (e.command === "select") {
    //    if (e.parentType === "headerRow") {

    //        e.editorOptions.onInitialized = function (e) {
    //            selectAllCheckBox = e.component;
    //        }
    //        e.editorOptions.onValueChanged = function (e) {
    //            if (!e.event) {
    //                if (e.previousValue && !checkBoxUpdating) {
    //                    e.component.option("value", e.previousValue);
    //                }
    //                return;
    //            }
    //            e.event.preventDefault();
    //        }
    //    }
    //}
}

function onSelectionChangedCE(e) {
    //var formData = $("#ControlorEmployeesRelationForm").dxForm("instance").option("formData");

    //e.currentSelectedRowKeys.forEach((key) => {
    //    e.component.byKey(key).done((item) => {
    //        if (formData.UserID ==0)
    //            e.component.deselectRows(key);
    //    });
    //});



}


function onSaveControlorEmployeeRelations(e) {
    var formData = $("#ControlorEmployeesRelationForm").dxForm("instance").option("formData");
    var selectedEmployees = $("#ControlorEmployeesGrid").dxDataGrid("instance").getSelectedRowsData();
    if (!formData.UserID) {
        showInfo("Morate izabrati kontrolora", "Kontrolori");
        return;
    }
    $.ajax({
        url: virtualDirectory + '/ControlorEmployees/SaveControlorEmployeeRelations',
        type: 'POST',
        async: false,
        data: {
            UserID: formData.UserID,
            employees: selectedEmployees
        },
        success: function (data) {
            if (data.success) {
                showInfo("Uspešno ste snimili kontrolore i radnike", "Kontrolori");
                //var popup = $("#popupForm").dxPopup('instance');
                //popup.hide();
            }
            else {
                showInfo(data.result, "Kontrolori");
            }
        },
    });

}

function onHidingControlorEmployees(e) {
     var popup = $("#popupForm").dxPopup('instance');
                popup.hide();
}