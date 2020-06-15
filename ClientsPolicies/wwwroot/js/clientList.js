var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/clients/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "25%" },
            { "data": "name", "width": "25%" },
            { "data": "email", "width": "25%" },
            { "data": "role", "width": "25%" },
        ]
    });
}
