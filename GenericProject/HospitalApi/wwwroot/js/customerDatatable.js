$(document).ready(function () {
    $("#customerDatatable").DataTable({
        processing: true,
        serverSide: true,
        filter: true,
        ajax: {
            url: "https://localhost:44358/api/doctor/getalldoctors",
            type: "POST",
            dataType: "json",
            contentType: "application/x-www-form-urlencoded",
        },
        columnDefs: [{
            targets: [0],
            visible: true,
            searchable: true,
        }],
        columns: [
            { data: "doctor_Id", "name": "doctor_Id", "autoWidth": true },
            { data: "doctor_Name", "name": "doctor_Name", "autoWidth": true },
            {
                render: function (data, row) {
                    return `<a href="#"  class="btn btn-danger" onclick=DeleteCustomer("${data}"); >Delete</a>`;
                }
            },
        ]
    });
  
});


var deleteData;
function DeleteCustomer(deleteData) {
    console.log(deleteData);
}
