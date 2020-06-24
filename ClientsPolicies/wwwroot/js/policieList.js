var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/admin/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "20%" },
            { "data": "amountInsured", "width": "20%" },
            { "data": "email", "width": "20%" },
            { "data": "inceptionDate", "width": "20%" },
            { "data": "installmentPayment", "width": "20%" },
            { "data": "clientId", "width": "20%" },
            
        ]
    });
}