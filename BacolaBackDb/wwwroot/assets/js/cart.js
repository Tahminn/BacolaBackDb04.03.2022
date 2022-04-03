$(function () {

    $("#cart-product .product-added .product-quantity i.fa-minus").on("click", function () {
        let countNum = parseInt($(this).next().html());
        let price = $(this).parent().prev().children().first().html();
        countNum--;
        if (countNum > 0) {
            $(this).next().html(countNum);
            $(this).parent().next().children().first().html(countNum * price);
        }
    })
    $("#cart-product .product-quantity i.fa-plus").on("click", function () {
        let countNum = parseInt($(this).prev().text());
        let price = $(this).parent().prev().children().first().html();
        countNum++;
        $(this).prev().html(countNum);
        $(this).parent().next().children().first().html(countNum * price);
    })

    function getProductCount(list) {
        return list.length;
    }

    let table = $("table tbody");

    let products = [];
    if (JSON.parse(localStorage.getItem("products")) != null) {
        products = JSON.parse(localStorage.getItem("products"));
    }

    getProductList(products);
    function getProductList(list) {
        for (const product of list) {
            table.append(`<tr class="product-added">
            <td class="product-image">
              <img src="${product.img}" alt="">
            </td>
            <td class="product-name">
              <span>${product.name}</span>
            </td>
            <td class="product-price">
              $
              <span>${product.price}</span>
            </td>
            <td class="product-quantity">
              <i class="fal fa-minus"></i>
              <span>${product.count}</span>
              <i class="fal fa-plus"></i>                      
            </td>
            <td class="product-subtotal">
              $
              <span>7.25</span>
            </td>
            <td class="product-delete">
              <i class="fal fa-times"></i>
            </td>
            </tr>`);
        }
    }
    // $.get('shop.html', function(text){

    //     let aa = $(text).find('.btn-warning')

    //     aa.on('click', function(){
    //         console.log("click");;
    //     })
    // });

    let deleteIcons = document.querySelectorAll(".product-delete .fa-times");
    console.log(deleteIcons);
    deleteIcons.forEach(deleteIcon => {
        deleteIcon.addEventListener("click", function () {
            for (const product of products) {
                if (this.parentNode.parentNode.firstElementChild.firstElementChild.getAttribute("src") == product.img) {
                    const index = products.indexOf(product);
                    if (index > -1) {
                        products.splice(index, 1);
                        localStorage.setItem("products", JSON.stringify(products));
                    }
                    document.location.reload(true);
                }
            }
        });
    });

















})