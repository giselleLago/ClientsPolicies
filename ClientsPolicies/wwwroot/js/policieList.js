var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Policies/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "18%" },
            { "data": "amountInsured", "width": "18%" },
            { "data": "email", "width": "18%" },
            { "data": "inceptionDate", "width": "18%" },
            { "data": "installmentPayment", "width": "18%" },
            { "data": "clientId", "width": "18%" },
            
        ]
    });
}