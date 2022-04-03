$(function() {

    //pagination
    
    $(".pagination-numbers ul li span").on("click", function () {
        console.log($(this).parents().eq(3).siblings().first().children());
        $(this).parents().eq(3).siblings().first().children().addClass("inactive");
        const ids = $(this).parents().eq(3).siblings().first().children()
        for (const item of ids) {
            if($(this).attr("id") == item.id){           
                item.classList.remove("inactive")
            } 
        }
                       
    })





})