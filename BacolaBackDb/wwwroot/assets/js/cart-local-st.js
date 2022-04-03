    //cart-function

    //function getProductCount(list){
    //    return list.length;
    //}


    //let addButton = document.querySelectorAll(".btn.btn-warning");
    //let countElem = document.querySelector("sup");


    //if (JSON.parse(localStorage.getItem("products")) == null) {
    //    localStorage.setItem("products", JSON.stringify([]));
    //}
    //let products = JSON.parse(localStorage.getItem("products"));

    //addButton.forEach(btn => {
    //    btn.onclick = function (e) {
    //        e.preventDefault();
    //        //let productId = this.parentNode.parentNode.getAttribute("data-id");
    //        let productImg = this.parentNode.previousElementSibling.firstElementChild.firstElementChild.firstElementChild.getAttribute("src");
    //        let productName = this.parentNode.previousElementSibling.lastElementChild.children[2].innerText;
    //        let productPrice = parseFloat(this.parentNode.previousElementSibling.lastElementChild.children[6].firstElementChild.innerText);
    //        console.log(productPrice);
    //        let existProduct = products.find(m => m.img == productImg);

    //        if (existProduct == undefined) {
    //            products.push({
    //                //id: productId,
    //                img: productImg,
    //                name: productName,
    //                price : productPrice,
    //                count: 1
    //            })
    //        } else {
    //            existProduct.count += 1;
    //        }
    //        localStorage.setItem("products", JSON.stringify(products));
    //        //countElem.innerText = getProductCount(products);
    //    }
    //})

    //countElem.innerText = getProductCount(products);

    //let button = document.getElementById("button");