$(function () {

    let login = $(".login input[value='Log in']")

    login.on("click", function (e) {
        debugger;
        if ($(".username input").val() == "admin" && $(".password input").val() == "admin12") {
            window.location.href = "products/index";
        }
        else {
            $(".error-message").removeClass("d-none")
        }
    });

});
