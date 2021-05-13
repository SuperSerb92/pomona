function onRowInsertingCultureTypes(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).CultureTypeName) || e.data.CultureTypeName == undefined) {
        showInfo("Morate uneti sortu voća", "Sorta voća");
        e.cancel = true;
        isCanceledCultureTypes = true;
        return;
    }
    if (/^\s*$/.test(JSON.parse(JSON.stringify(e.data)).CultureId) || e.data.CultureId == undefined) {
        showInfo("Morate uneti vrstu voća", "Sorta voća");
        e.cancel = true;
        isCanceledCultureTypes = true;
        return;
    }

}

function onRowUpdatingCultureTypes(e) {
    if (e.newData.CultureTypeName != undefined) {
        if (jQuery.isEmptyObject(e.newData.CultureTypeName) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.CultureTypeName)))) {
            showInfo("Morate uneti sortu voća", "Sorta voća");
            e.cancel = true;
            isCanceledCultureTypes = true;
            return;
        }
    }
}



var isCanceledCultureTypes = false;

function onToolbarPreparingCultureTypes(e) {
    $.each(e.toolbarOptions.items, function (i, v) {
        v.location = "before";
    })
    const addRowitem = e.toolbarOptions.items.find(item => item.name === 'addRowButton');
    addRowitem.options.onClick = function () {
        if (!e.component.option('editing.editRowKey')) {
            e.component.addRow();
        }
        else {
            isCanceledCultureTypes = false;
            e.component.saveEditData().done(function (data) {
                if (!isCanceledCultureTypes) {
                    e.component.addRow();
                }
            });
        }
    }
}


var cultureTypeForDelete;
function onPrepareDeleteCultureType(e) {
    cultureTypeForDelete = e.row.rowIndex;
    ShowPopupYesNo("Da li ste sigurni da želite da obrišete sortu voća?", "PrepareDeleteCultureType", "Sorta voća");
}

function onDeleteCultureType() {
    $("#cultureTypeGrid").dxDataGrid("instance").deleteRow(cultureTypeForDelete);
}


function CultureTypeCountPerPage(e) {
    return "Broj redova:  " + $("#cultureTypeGrid").dxDataGrid("instance").getVisibleRows().length;
}


function onCultureTypesGridEditorPreparing(e) {
    if (e.parentType == "dataRow" && e.dataField == "CultureId") {
        e.editorOptions.searchEnabled = false;
    }
    //if (e.parentType === "filterRow" && e.dataField === "CultureId") {
    //    e.editorName = "dxTextBox"
    //    e.editorOptions.valueChangeEvent = "keyup";
    //}
}

//function CalculateFilterExpressionCT(filterValue, selectedFilterOperation, target) {
//    console.log(selectedFilterOperation);
//    let column = this;
//    if (target === "filterRow") {
//        return [
//            function (item) {
//                console.log("column" + column);
//                let lookUpName = column.lookup.dataSource.filter((data) => {
//                    return data.ID === item.CultureId;
//                });
//                switch (selectedFilterOperation) {
//                    case "contains":
//                        return lookUpName[0].CultureName.includes(filterValue);
//                    case "notcontains":
//                        return !lookUpName[0].CultureName.includes(filterValue);
//                }
//            },
//            "=",
//            true
//        ];
//    }
//    return this.defaultCalculateFilterExpression.apply(this, arguments);
//}

