function onRowInsertingEmployees(e) {
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).Name) || e.data.Name == undefined) {
        e.cancel = true;
    }  
    if (jQuery.isEmptyObject(e.data) || /^\s*$/.test(JSON.parse(JSON.stringify(e.data)).Surname) || e.data.Surname == undefined) {
        e.cancel = true;
    }  
} 

function onRowUpdatingEmployees(e) {
    //todo : validacija za prazno ime prezime
    //if (jQuery.isEmptyObject(e.newData) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData)).Name) || e.newData.Name == undefined) {
    //    e.cancel = true;
    //}
    //if (jQuery.isEmptyObject(e.newData) || /^\s*$/.test(JSON.parse(JSON.stringify(e.newData)).Surname) || e.newData.Surname == undefined) {
    //    e.cancel = true;
    //}  
} 
