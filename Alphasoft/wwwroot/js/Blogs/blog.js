var dataTable = $("#blogDatatable").dataTable({
    "processing": true,
    "serverSide": true,
    "filter": true,
    "pageLength": 50,
    "autoWidth": false,
    "lengthMenu": [[50, 100, 150, 200, 500, -1], [50, 100, 150, 200, 500, "All"]],
    "order": [[0, "desc"]],
    "ajax": {
        "url": "/Blogs/LoadBlog/",
        "type": "POST",
        "data": function (data) {
        },
        "complete": function (json) {
        }
    },
    "columns": [
        { "data": "id", "name": "Id", "autowidth": true, "className": "text_center" },
        { "data": "thumbnail", "name": "Thumbnail", "autowidth": true },
        { "data": "title", "name": "Title ", "autowidth": true },
        { "data": "description", "name": "Description", "autowidth": true },
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

    $("#blog-createmodalBtn").on("click", function (e) {

    e.preventDefault();
    let data = objectifyForm($(this).serializeArray());
    $.ajax({
        url: "/Blogs/CreateView",
        type: "GET",
        data: data,
        success: function (response) {
            $("#blog-createFormDiv").html(response);
        }
    })
    });

    $("body").on("click", ".editBtn", function (e) {
        e.preventDefault();
        $("#blogs-editModal").modal('show');
        let data = {
            id: $(this).val()
        };
        $.ajax({
            url: "Blogs/EditView",
            data: data,
            type: "GET",
            success: function (response) {
                $("#blog-editFormDiv").html(response);
            }
        });
    });

    $("body").on("click", ".deleteBtn", function (e) {
        e.preventDefault();
        let data = {
            id: $(this).val()
        };
        console.log(data);
        $.ajax({
            url: "/Blogs/Delete",
            type: "GET",
            data: data,
            success: function (response) {
                console.log(response);
                dataTable.fnFilter();
            }

        });

    });
})();