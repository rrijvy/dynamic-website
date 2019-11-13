(function () {

    //let images = $("img.lazy");

    //lazyload(images);

    const selector = {
        navigatonMenuBar: $("#navigationMenuBar"),
        companyLogo: $(".companyLogo"),
        contactUsFormDiv: $("#contactUsFormDiv"),
        contactUs: $("#contactUs"),
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


    let numberOfSections = 7;
    let numberOfVisitedSection = 2;



    $(window).scroll(function () {

        console.clear();

        console.log(numberOfSections);
        console.log(numberOfVisitedSection);

        let windowBottomPosition = $(window).scrollTop() + $(window).height();
        let sectionPosition = $(`#sec_${numberOfVisitedSection}`).position().top;

        console.log(windowBottomPosition);
        console.log(sectionPosition);

        if ((windowBottomPosition + 700) > sectionPosition) {

            if (numberOfVisitedSection <= numberOfSections) {

                $.ajax({
                    url: `/ClientView/Section_${numberOfVisitedSection}`,
                    type: "GET",
                    success: function (response) {
                        console.log(response);

                        $(`#sec_${numberOfVisitedSection}`).html(response);

                        ++numberOfVisitedSection;
                    },
                    error: function (response) {

                        $.ajax({
                            url: `/ClientView/Section_${numberOfVisitedSection}`,
                            type: "GET",
                            success: function (response) {
                                $(`#sec_${numberOfVisitedSection}`).html(response);

                                ++numberOfVisitedSection;
                            },
                            error: function (response) {

                                $.ajax({
                                    url: "/Home/AjaxErrorView",
                                    type: "GET",
                                    success: function (response) {
                                        $(`#sec_${numberOfVisitedSection}`).html(response);

                                        ++numberOfVisitedSection;
                                    }
                                });

                            }
                        });

                    }
                });
            }
        }
    });
})();