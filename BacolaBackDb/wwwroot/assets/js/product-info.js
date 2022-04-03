$(function () {
    console.log($(".slider-img ul"));
    $(".slider-controller .controller-box").on("click", function () {

        $(this).children().first().removeClass("border")
        if ($(this).hasClass("1")) {
            $(".slider-img ul").css("transform", "translate(0)");
            $(this).children().first().addClass("border")
            $(this).siblings().children().removeClass("border")
        }
        if ($(this).hasClass("2")) {
            $(".slider-img ul").css("transform", "translate(-33.33%)");
            $(this).children().first().addClass("border")
            $(this).siblings().children().removeClass("border")
        }
        if ($(this).hasClass("3")) {
            $(".slider-img ul").css("transform", "translate(-66.66%)");
            $(this).children().first().addClass("border")
            $(this).siblings().children().removeClass("border")
        }
    })

    let headers = document.querySelectorAll(".tab-menu .header div");
    let contents = document.querySelectorAll(".tab-menu .content div[data-id]");

    headers.forEach(header => {
        header.addEventListener("click", function () {
            let activeElem = document.querySelector(".active");
            activeElem.classList.remove("active");
            this.classList.add("active");

            contents.forEach(content => {
                if (this.getAttribute("data-id") != content.getAttribute("data-id")) {
                    content.classList.add("d-none")
                } else {
                    content.classList.remove("d-none")
                }
            })

        })
    })






});