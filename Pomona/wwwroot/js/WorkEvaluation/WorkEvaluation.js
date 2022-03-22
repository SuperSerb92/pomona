function getWorkEvaluationGrid() {
    return $("#workEvaluationGrid").dxDataGrid("instance");
}

var dateEditor;
var millisecondsInDay = 24 * 60 * 60 * 1000;
function dateOnInitialized(e) {
    dateEditor = e.component;

}

function today() {
    dateEditor.option("value", new Date().getTime());
}
var datumPrethodni;
function prevDate() {
    dateEditor.option("value", dateEditor.option("value") - millisecondsInDay);
}

function nextDate() {
    dateEditor.option("value", dateEditor.option("value") + millisecondsInDay);
}
function dateChanged(data) {
    console.log(data);
    var localni = new Date(data.value).toLocaleDateString();
    var dataGrid = $("#workEvaluationGrid").dxDataGrid("instance");
    dataGrid.filter(["Date", "=", Date.parse(localni)]);
} 
function filterGridOnStart(e) {
    var datum = new Date(dateEditor.option("value")).toLocaleDateString();
    var dataGrid = $("#workEvaluationGrid").dxDataGrid("instance");
    dataGrid.filter(["Date", "=", Date.parse(datum)]);
}
function onRowUpdating(e) {
    if (e.newData.PayPerDay > 0 && e.newData.ExpenseKg>0) {
        showInfo("Možete uneti vrednost samo u jedno polje (Dnevnica ili Iznos po kg)", "Evidencija ocene radnika");
        e.cancel = true;
        isCanceled = true;

        return;
    }
    if (e.newData.PayPerDay > 0 && e.oldData.ExpenseKg > 0 && e.newData.ExpenseKg == undefined) {
        showInfo("Možete uneti vrednost samo u jedno polje (Dnevnica ili Iznos po kg)", "Evidencija ocene radnika");
       // e.newData.PayPerDay = 0;
        e.cancel = true;
        isCanceled = true;

        return;
    }
    if (e.oldData.PayPerDay > 0 && e.newData.ExpenseKg > 0 && e.newData.PayPerDay == undefined) {
        showInfo("Možete uneti vrednost u samo u jedno polje (Dnevnica ili Iznos po kg)", "Evidencija ocene radnika");
      //  e.newData.ExpenseKg = 0;
        e.cancel = true;
        isCanceled = true;

        return;
    }
    if (e.newData.PayPerDay < 0 || e.newData.ExpenseKg < 0) {
        showInfo("Vrednost ne može biti negativna", "Evidencija ocene radnika");
        e.cancel = true;
        isCanceled = true;

        return;
    }
}