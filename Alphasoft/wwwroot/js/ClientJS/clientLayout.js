(function () {
    $(window).scroll(function () {
        console.clear();


        let numberOfSections = 7;
        let numberOfVisitedSection = 3;

        let windowBottomPosition = $(window).scrollTop() + $(window).height();
        let sectionPosition = $(`#sec${numberOfVisitedSection}`).position().top;

        if ((windowBottomPosition + 700) > sectionPosition) {

            if (numberOfVisitedSection >= 7) {

                $.ajax({
                    url: `/Home/Section_${numberOfVisitedSection}`,
                    type: "GET",
                    success: function (response) {
                        $(`#sec${numberOfVisitedSection}`).html(response);

                        ++numberOfVisitedSection;
                    },
                    error: function (response) {

                        $.ajax({
                            url: "/Home/Section_0",
                            type: "GET",
                            success: function (response) {
                                $(`#sec${numberOfVisitedSection}`).html(response);

                                ++numberOfVisitedSection;
                            },
                            error: function (response) {

                                $.ajax({
                                    url: "/Home/AjaxErrorView",
                                    type: "GET",
                                    success: function (response) {
                                        $(`#sec${numberOfVisitedSection}`).html(response);

                                        ++numberOfVisitedSection;
                                    }
                                });

                            }
                        });

                    }
                });
            }
        }

        


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