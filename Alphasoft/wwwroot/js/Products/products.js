var dataTable = $("#productDatatable").dataTable({
    "processing": true,
    "serverSide": true,
    "filter": true,
    "pageLength": 50,
    "autoWidth": false,
    "lengthMenu": [[50, 100, 150, 200, 500, -1], [50, 100, 150, 200, 500, "All"]],
    "order": [[0, "desc"]],
    "ajax": {
        "url": "/Products/LoadProducts/",
        "type": "POST",
        "data": function (data) {
        },
        "complete": function (json) {
        }
    },
    "columns": [
        { "data": "id", "name": "Id", "autowidth": true, "className": "text_center" },
        { "data": "name", "name": "Name", "autowidth": true },
        { "data": "categoryName", "name": "ProductCategoryId", "autowidth": true },
        { "data": "purchasePrice", "name": "PurchasePrice", "autowidth": true, "className": "text_center" },
        { "data": "retailPrice", "name": "RetailPrice", "autowidth": true, "className": "text_center" },
        { "data": "wholeSellPrice", "name": "WholeSellPrice", "autowidth": true, "className": "text_center" },
        { "data": "discount", "name": "Discount", "autowidth": true, "className": "text_center" },
        { "data": "shortDescription", "name": "ShortDescription", "autowidth": true },
        { "data": "description", "name": "Description", "autowidth": true },
        { "data": "releaseDate", "name": "ReleaseDate", "autowidth": true },
        { "data": "isPopular", "name": "IsPopular", "autowidth": true },
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

    $("#product-modalBtn").on("click", function (e) {
        $.ajax({
            url: "/Products/CreateView",
            type: "GET",
            success: function (response) {
                $("#product-createFormDiv").html(response);
            }
        });
    });

    $("body").on("click", ".deleteBtn", function (e) {
        e.preventDefault();

        let data = {
            id: $(this).val()
        };

        $.ajax({
            url: "/Products/Delete",
            type: "GET",
            data: data,
            success: function (response) {
                dataTable.fnFilter();
            }
        });
    });

    $("body").on("click", ".editBtn", function (e) {
        e.preventDefault();

        $("#product-editModal").modal('show');

        let data = {
            id: $(this).val()
        };

        $.ajax({
            url: "/Products/EditView",
            type: "GET",
            data: data,
            success: function (response) {
                $("#product-editFormDiv").html(response);
            }
        });
    });

})();

function OnSuccessProductCreate(data) {
    if (data.indexOf("field-validation-error") > -1) {
        $("#alert").html("<div class='alert alert-danger' style='color:black'><strong> Failed!</strong> Validation Failed!</div>");
        $("#alert").fadeIn('slow').delay(2000).fadeOut('slow');
    } else {
        $("#alert").html("<div class='alert alert-success' style='color:black'><strong> Success!</strong> Created Successfully!</div>");
        $("#alert").fadeIn('slow').delay(2000).fadeOut('slow');
    }

    dataTable.fnFilter();
}

function OnFailureProductCreate() {
    $("#alert").html("<div class='alert alert-danger' style='color:black'><strong> Failed!</strong> Couldn't insert the data. Something went wrong!</div>");
    $("#alert").fadeIn('slow').delay(2000).fadeOut('slow');
}



