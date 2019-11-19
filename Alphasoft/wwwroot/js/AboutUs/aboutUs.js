var dataTable = $("#aboutUsDatatable").dataTable({
    "processing": true,
    "serverSide": true,
    "filter": true,
    "pageLength": 50,
    "autoWidth": false,
    "lengthMenu": [[50, 100, 150, 200, 500, -1], [50, 100, 150, 200, 500, "All"]],
    "order": [[0, "desc"]],
    "ajax": {
        "url": "/AboutUses/LoadAboutUs/",
        "type": "POST",
        "data": function (data) {
        },
        "complete": function (json) {
        }
    },
    "columns": [
        { "data": "id", "name": "Id", "autowidth": true, "className": "text_center" },
        { "data": "aboutMainSologan", "name": "AboutMainSologan", "autowidth": true },
        { "data": "ourMissionDescription", "name": "OurMissionDescription", "autowidth": true },
        { "data": "ourVisionDescription", "name": "OurVisionDescription", "autowidth": true },
        { "data": "whyUsDescription", "name": "WhyUsDescription", "autowidth": true },
        { "data": "whoWeAreDescription", "name": "WhoWeAreDescription", "autowidth": true },
        { "data": "whoWeAreImageOne", "name": "WhoWeAreImageOne", "autowidth": true },
        { "data": "whoWeAreImageTwo", "name": "WhoWeAreImageTwo", "autowidth": true },
      
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

    $("#aboutus-modalBtn").on("click", function (e) {
        e.preventDefault();

        $.ajax({
            url: "/AboutUses/CreateView",
            type: "GET",
            success: function (response) {
                console.log(response);
                $("#aboutus-createFormDiv").html(response);
            }
        });
    });


    $("body").on("click", ".editBtn", function (e) {
        e.preventDefault();
        $("#aboutus-editModal").modal('show');
        let data = {
            id: $(this).val()
        };
        $.ajax({
            url: "/AboutUses/EditView",
            type: "GET",
            data: data,
            success: function (response) {
                $("#aboutus-editFormDiv").html(response);
            }
        });
    });

    $("body").on("click", ".deleteBtn", function (e) {
        e.preventDefault();
        let data = {
            id: $(this).val()
        };
        $.ajax({
            url: "/AboutUses/Delete",
            type: "GET",
            data: data,
            success: function () {
                dataTable.fnFilter();
            }

        });
    });


})();
