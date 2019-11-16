(function () {

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


    let numberOfSections = 8;
    let numberOfVisitedSection = 2;


    let section = {
        _0: { position: $("#sec_0").position().top, visited: false },
        _1: { position: $("#sec_1").position().top, visited: false },
        _2: { position: $("#sec_2").position().top, visited: false },
        _3: { position: $("#sec_3").position().top, visited: false },
        _4: { position: $("#sec_4").position().top, visited: false },
        _5: { position: $("#sec_5").position().top, visited: false },
        _6: { position: $("#sec_6").position().top, visited: false },
        _7: { position: $("#sec_7").position().top, visited: false }
    };


    $(window).scroll(function () {

        let windowBottomPosition = $(window).scrollTop() + $(window).height();

        if ((windowBottomPosition + 700) > section._1.position) {

            if (section._1.visited === false) {

                $.ajax({
                    url: `/ClientView/Section_1`,
                    type: "GET",
                    success: function (response) {

                        $(`#sec_1`).html(response);

                        section._1.visited = true;
                    },
                    error: function (response) {

                        $.ajax({
                            url: `/ClientView/Section_1`,
                            type: "GET",
                            success: function (response) {
                                console.log(response);
                                $(`#sec_1`).html(response);

                                section._1.visited = true;
                            },
                            error: function (response) {

                                $.ajax({
                                    url: "/Home/AjaxErrorView",
                                    type: "GET",
                                    success: function (response) {
                                        $(`#sec_1`).html(response);

                                        section._1.visited = true;
                                    }
                                });

                            }
                        });

                    }
                });
            }
        }

        if ((windowBottomPosition + 700) > section._2.position) {

            if (section._2.visited === false) {

                $.ajax({
                    url: `/ClientView/Section_2`,
                    type: "GET",
                    success: function (response) {
                        $(`#sec_2`).html(response);

                        section._2.visited = true;
                    },
                    error: function (response) {

                        $.ajax({
                            url: `/ClientView/Section_2`,
                            type: "GET",
                            success: function (response) {

                                section._2.visited = true;
                            },
                            error: function (response) {

                                $.ajax({
                                    url: "/Home/AjaxErrorView",
                                    type: "GET",
                                    success: function (response) {
                                        $(`#sec_2`).html(response);

                                        section._2.visited = true;
                                    }
                                });

                            }
                        });

                    }
                });
            }
        }

        if ((windowBottomPosition + 700) > section._3.position) {

            if (section._3.visited === false) {

                $.ajax({
                    url: `/ClientView/Section_3`,
                    type: "GET",
                    success: function (response) {

                        $(`#sec_3`).html(response);

                        section._3.visited = true;
                    },
                    error: function (response) {

                        $.ajax({
                            url: `/ClientView/Section_3`,
                            type: "GET",
                            success: function (response) {
                                $(`#sec_3`).html(response);

                                section._3.visited = true;
                            },
                            error: function (response) {

                                $.ajax({
                                    url: "/Home/AjaxErrorView",
                                    type: "GET",
                                    success: function (response) {
                                        $(`#sec_3`).html(response);

                                        section._3.visited = true;
                                    }
                                });

                            }
                        });

                    }
                });
            }
        }

        if ((windowBottomPosition + 700) > section._4.position) {

            if (section._4.visited === false) {

                $.ajax({
                    url: `/ClientView/Section_4`,
                    type: "GET",
                    success: function (response) {

                        $(`#sec_4`).html(response);

                        section._4.visited = true;
                    },
                    error: function (response) {

                        $.ajax({
                            url: `/ClientView/Section_4`,
                            type: "GET",
                            success: function (response) {
                                $(`#sec_4`).html(response);

                                section._4.visited = true;
                            },
                            error: function (response) {

                                $.ajax({
                                    url: "/Home/AjaxErrorView",
                                    type: "GET",
                                    success: function (response) {
                                        $(`#sec_4`).html(response);

                                        section._4.visited = true;
                                    }
                                });

                            }
                        });

                    }
                });
            }
        }

        if ((windowBottomPosition + 700) > section._5.position) {

            if (section._5.visited === false) {

                $.ajax({
                    url: `/ClientView/Section_5`,
                    type: "GET",
                    success: function (response) {

                        $(`#sec_5`).html(response);

                        section._5.visited = true;
                    },
                    error: function (response) {

                        $.ajax({
                            url: `/ClientView/Section_5`,
                            type: "GET",
                            success: function (response) {
                                $(`#sec_5`).html(response);

                                section._5.visited = true;
                            },
                            error: function (response) {

                                $.ajax({
                                    url: "/Home/AjaxErrorView",
                                    type: "GET",
                                    success: function (response) {
                                        $(`#sec_5`).html(response);

                                        section._5.visited = true;
                                    }
                                });

                            }
                        });

                    }
                });
            }
        }

        if ((windowBottomPosition + 700) > section._6.position) {

            if (section._6.visited === false) {

                $.ajax({
                    url: `/ClientView/Section_6`,
                    type: "GET",
                    success: function (response) {

                        $(`#sec_6`).html(response);

                        section._6.visited = true;
                    },
                    error: function (response) {

                        $.ajax({
                            url: `/ClientView/Section_6`,
                            type: "GET",
                            success: function (response) {
                                $(`#sec_6`).html(response);

                                section._6.visited = true;
                            },
                            error: function (response) {

                                $.ajax({
                                    url: "/Home/AjaxErrorView",
                                    type: "GET",
                                    success: function (response) {
                                        $(`#sec_6`).html(response);

                                        section._6.visited = true;
                                    }
                                });

                            }
                        });

                    }
                });
            }
        }

        if ((windowBottomPosition + 700) > section._7.position) {

            if (section._7.visited === false) {

                $.ajax({
                    url: `/ClientView/Section_7`,
                    type: "GET",
                    success: function (response) {

                        $(`#sec_7`).html(response);

                        section._7.visited = true;
                    },
                    error: function (response) {

                        $.ajax({
                            url: `/ClientView/Section_7`,
                            type: "GET",
                            success: function (response) {
                                $(`#sec_7`).html(response);

                                section._7.visited = true;
                            },
                            error: function (response) {

                                $.ajax({
                                    url: "/Home/AjaxErrorView",
                                    type: "GET",
                                    success: function (response) {
                                        $(`#sec_7`).html(response);

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