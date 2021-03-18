function OnSelectionChangedControlor(e) {
    $.ajax({
        url: virtualDirectory + '/ControlorEmployees/GetSelectedData?UserId=' + e.component.option("value") ,
        type: 'POST',
        success: function (data) {
            if (data.success) {
                var dataGrid = $("#ControlorEmployeesGrid").dxDataGrid("instance");
                dataGrid.refresh();
               //  $("#ControlorEmployeesGrid").dxDataGrid("instance").getDataSource().reload();
             //   popupFormConfiguration("/Volume/AddEditVolume", 600, 410, "");
            }
            else {
                showInfo(data.result, "");
            }
        },
    });
}