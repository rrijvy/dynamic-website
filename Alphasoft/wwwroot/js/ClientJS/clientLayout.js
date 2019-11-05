(function () {
    const selector = {
        navigatonMenuBar: $("#navigationMenuBar"),
        companyLogo: $(".companyLogo"),
        contactUsFormDiv: $("#contactUsFormDiv"),
        contactUs: $("#contactUs")
    };

    selector.contactUs.on("click", function (e) {
        e.preventDefault();

        $.ajax({
            url: "/Home/ContactUsFormShow",
            type: "GET",
            success: function (response) {
                selector.contactUsFormDiv.html(response).slideToggle("fast", "swing");
            }
        });
    });
})();