function onRowInsertingEmployees(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).Name) || e.data.Name == undefined) {
        showInfo("Morate uneti ime radnika", "Radnici");
        e.cancel = true;
        return;
    }  
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).Surname) || e.data.Surname == undefined) {
        showInfo("Morate uneti prezime radnika", "Radnici");
        e.cancel = true;
    }  
} 

function onRowUpdatingEmployees(e) {
    if (e.newData.Name != undefined) {
        if (jQuery.isEmptyObject(e.newData.Name) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.Name)))) {
            showInfo("Morate uneti ime radnika", "Radnici");
            e.cancel = true;
            return;
        }
    }
    if (e.newData.Surname != undefined) {
        if (jQuery.isEmptyObject(e.newData.Surname) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData.Surname)))) {
            showInfo("Morate uneti prezime radnika", "Radnici");
            e.cancel = true;
            return;
        }
    }
} 

//function onKeyDownEmployees(e) {
//    if (e.event.key === "+") {
//        console.log("Ctrl + N was pressed");
//        getEmployeeGrid().addRow();
//    }
//}

function onToolbarPreparingEmployees(e) {
    const addRowitem = e.toolbarOptions.items.find(item => item.name === 'addRowButton');
    addRowitem.options.onClick = function () {
        if (!e.component.option('editing.editRowKey')) {
            e.component.addRow();
        }
        else {
            showInfo("Morate sačuvati red u izmeni", "Radnici");
        }
    }
}

//var totalPageCount = $("#treeListContainer").dxTreeList("instance").pageCount();
var employeeForDelete;
function onPrepareDeleteEmployee(e) {
    employeeForDelete = e.row.rowIndex;
    ShowPopupYesNo("Da li ste sigurni da želite da obrišete radnika?", "PrepareDeleteEmployee", "Radnici");
}

function OnDeleteEmployee() {
    getEmployeeGrid().deleteRow(employeeForDelete);
}


function getEmployeeGrid() {    
    return $("#employeeGrid").dxDataGrid("instance");
}


function EmployeeCountPerPage(e) {
    return "Broj redova:  " + getEmployeeGrid().getVisibleRows().length;
}