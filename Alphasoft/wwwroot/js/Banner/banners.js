var dataTable = $("#bannerDatatable").dataTable({
    "processing": true,
    "serverSide": true,
    "filter": true,
    "pageLength": 50,
    "autoWidth": false,
    "lengthMenu": [[50, 100, 150, 200, 500, -1], [50, 100, 150, 200, 500, "All"]],
    "order": [[0, "desc"]],
    "ajax": {
        "url": "/Banners/LoadBanner/",
        "type": "POST",
        "data": function (data) {
        },
        "complete": function (json) {
        }
    },
    "columns": [
        { "data": "id", "name": "Id", "autowidth": true, "className": "text_center" },
        { "data": "image", "name": "Image", "autowidth": true },
        { "data": "solganOne", "name": "SolganOne ", "autowidth": true },
        { "data": "solganTwo", "name": "SolganTwo", "autowidth": true },
        { "data": "solganThree", "name": "SolganThree", "autowidth": true },
       
        {
            "render": function (data, type, full, meta) {
                return `<button style="font-size: inherit;" class="btn btn-sm btn-rx btn-table detailsBtn" value="${full.id}" data-toggle="tooltip" title="Product details"><i class="fas fa-file-alt"></i></button>
                        <button style="font-size: inherit;" class="btn btn-sm btn-rx btn-table editBtn" value="${full.id}" data-toggle="tooltip" title="Update product info!"><i class="fa fa-pen-fancy"></i></button>
                        <button style="font-size: inherit;" class="btn btn-sm btn-rx btn-table deleteBtn" value="${full.id}" data-toggle="tooltip" title="Delete product!"><i class="fa fa-trash"></i></button>`;
            }
        }
    ]
});

$("#banner-modalBtn").on("click", function (e) {
    e.preventDefault();
    let data = objectifyForm($(this).serializeArray());
    $.ajax({
        url: "/Banners/CreateView",
        type: "GET",
        data: data,
        success: function (response) {
            $("#banner-createFormDiv").html(response);
        }

    });
});

$("body").on("click", ".editBtn", function (e) {
    e.preventDefault();
    $("#banner-editModal").modal('show');
    let data = {
        id: $(this).val()
    };
    $.ajax({
        url: "/Banners/EditView",
        type: "GET",
        data: data,
        success: function (response) {
            $("#banner-editFormDiv").html(response);

        }
    });
});

$("body").on("click", ".deleteBtn", function (e) {
    e.preventDefault();
    let data = {
        id: $(this).val()
    };
    $.ajax({
        url: "/Banners/Delete",
        type: "GET",
        data: data,
        success: function (response) {
            dataTable.fnFilter();
        }
    });
});