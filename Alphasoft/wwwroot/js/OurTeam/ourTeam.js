
var dataTable = $("#ourDatatable").dataTable({
    "processing": true,
    "serverSide": true,
    "filter": true,
    "pageLength": 50,
    "autoWidth": false,
    "lengthMenu": [[50, 100, 150, 200, 500, -1], [50, 100, 150, 200, 500, "All"]],
    "order": [[0, "desc"]],
    "ajax": {
        "url": "/OurTeams/LoadOurTeam/",
        "type": "POST",
        "data": function (data) {
        },
        "complete": function (json) {
        }
    },
    "columns": [
        { "data": "id", "name": "Id", "autowidth": true, "className": "text_center" },
        { "data": "name", "name": "Name", "autowidth": true },
        { "data": "image", "name": "Image", "autowidth": true },
        { "data": "departmentName", "name": "DepartmentName ", "autowidth": true },
        { "data": "designationName", "name": "DesignationName", "autowidth": true },
        { "data": "description", "name": "Description", "autowidth": true },
        { "data": "facebook", "name": "Facebook", "autowidth": true },
        { "data": "twitter", "name": "Twitter", "autowidth": true },
        { "data": "linkedIn", "name": "LinkedIn", "autowidth": true },
     
     

        {
            "render": function (data, type, full, meta) {
                return `<button style="font-size: inherit;" class="btn btn-sm btn-rx btn-table detailsBtn" value="${full.id}" data-toggle="tooltip" title="Product details"><i class="fas fa-file-alt"></i></button>
                        <button style="font-size: inherit;" class="btn btn-sm btn-rx btn-table editBtn" value="${full.id}" data-toggle="tooltip" title="Update product info!"><i class="fa fa-pen-fancy"></i></button>
                        <button style="font-size: inherit;" class="btn btn-sm btn-rx btn-table deleteBtn" value="${full.id}" data-toggle="tooltip" title="Delete product!"><i class="fa fa-trash"></i></button>`;
            }
        }
    ]
});



(function () {

    $("#ourteam-modalBtn").on("click", function (e) {

        e.preventDefault();
        $.ajax({
            url: "/OurTeams/CreateView",
            type: "GET",
            success: function (response) {
                console.log(response);
                $("#ourTeam-createFormDiv").html(response);
            }
        });
    });

    $("body").on("click", ".editBtn", function (e) {
        e.preventDefault();
        $("#ourTeams-editModal").modal('show');
        let data = {
            id: $(this).val()
        };
        $.ajax({
            url: "/OurTeams/EditView",
            data: data,
            type: "GET",
            success: function (response) {
                $("#ourTeam-editFormDiv").html(response);
            }
        });
    });

    $("body").on("click", ".deleteBtn", function (e) {
        e.preventDefault();
        let data = {
            id: $(this).val()
        };
        $.ajax({
            url: "/OurTeams/Delete",
            type: "GET",
            data: data,
            success: function (response) {
                console.log(response);
                dataTable.fnFilter();
            }

        });

    });



})();