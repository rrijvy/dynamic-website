(function () {
    $(window).scroll(function () {
        console.clear();

        console.log("Bottom:" + ($(window).scrollTop() + $(window).height()));



        //if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        //    console.log($(window).scrollTop());
        //    console.log($(document).height());
        //    console.log($(window).height());
        //}
    });


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