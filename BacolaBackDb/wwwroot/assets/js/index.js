$(function () {
  //header
  $(".language-option").hover(function () {
    $(".language-menu").toggleClass("inactive");
  });
  $(".currency-option").hover(function () {
    $(".currency-menu").toggleClass("inactive");
  });
  $(".home-box").hover(function () {
    $(".home-menu").toggleClass("inactive");
  });
  $(".shop-box").hover(function () {
    $(".shop-menu").toggleClass("inactive");
  });
  $(".select-location button").on("click", function () {
    $(".select-location-back").toggleClass("inactive");
    $(".background-opacity").toggleClass("inactive");
  });
  $(".select-location-box i").on("click", function () {
    $(".select-location-back").toggleClass("inactive");
    $(".background-opacity").toggleClass("inactive");
  });  
    $(".all-catagories li").mouseover(function () {
        $(this).children('ul').eq(0).removeClass("inactive");
  });
  $(".all-catagories li:nth-child(4)").mouseout(function () {
      $(this).children('ul').eq(0).addClass("inactive");
  });
  $(".button-all-catagories").on("click", function () {
    $(".all-catagories").toggleClass("active collapsed");
  });
  $(".sidebar-icon").on("click", function () {
    $(".sidebar").css("transform", "translateX(0)");
    $(".sidebar").css("transition-duration", "1s");
    $(".background-opacity").toggleClass("inactive");
  });
  $(".sidebar i").on("click", function () {
    $(".sidebar").css("transform", "translateX(-25rem)");
    $(".sidebar").css("transition-duration", "1s");
    $(".background-opacity").toggleClass("inactive");
  });
    $(".carousel-inner").children().eq(0).addClass("active")
   

  //custom slider
  let leftIcon = document.querySelector(".left-icon");
  let rightIcon = document.querySelector(".right-icon");
  let sliderList = document.querySelector(".slider-scroll");
  let arrLi = document.querySelectorAll(".slider ul li");
    let clickCount = 0;

    //product categories
    $(".catagory-box .row").children().first().addClass("odd-item")

  rightIcon.addEventListener("click", function(){
    clickCount++;
    console.log(clickCount);
    // let valueProp = window.getComputedStyle(sliderList).getPropertyValue("transform");
    // let valueArr = valueProp.split(", ");
    // let translateXValue = parseInt(valueArr[4]);
        if (clickCount >=0 && clickCount < arrLi.length - 4) {
            sliderList.style.transform = "translateX(" + (($(".slider-scroll li").width() + 2) * - clickCount) + "px)";
        }
        else{
            clickCount = 0;
            sliderList.style.transform = "translateX(" + (($(".slider-scroll li").width() + 2) * - clickCount) + "px)";
        }
  });
  leftIcon.addEventListener("click", function(){
    
    clickCount--;
    // let valueProp = window.getComputedStyle(sliderList).getPropertyValue("transform");
    // let valueArr = valueProp.split(", ");
    // let translateXValue = parseInt(valueArr[4]);
    if (clickCount < 0) {
        clickCount = arrLi.length - 5;
        sliderList.style.transform = "translateX(" + (($(".slider-scroll li").width() + 2) * - clickCount) + "px)";
    }
    else{
        sliderList.style.transform = "translateX(" + (($(".slider-scroll li").width() + 2) * - clickCount) + "px)";
    }
       
  });


  //timer
  function getTimeRemaining(endtime) {
    const total = Date.parse(endtime) - Date.parse(new Date());
    const seconds = Math.floor((total / 1000) % 60);
    const minutes = Math.floor((total / 1000 / 60) % 60);
    const hours = Math.floor((total / (1000 * 60 * 60)) % 24);
    const days = Math.floor(total / (1000 * 60 * 60 * 24));
    
    return {
      total,
      days,
      hours,
      minutes,
      seconds
    };
  }
  
  function initializeClock(id, endtime) {
    const clock = document.querySelector(".timer-deals");
    const daysSpan = clock.querySelector('.timer-days');
    const hoursSpan = clock.querySelector('.timer-hours');
    const minutesSpan = clock.querySelector('.timer-minutes');
    const secondsSpan = clock.querySelector('.timer-seconds');
  
    function updateClock() {
      const t = getTimeRemaining(endtime);
  
      daysSpan.innerHTML = t.days;
      hoursSpan.innerHTML = ('0' + t.hours).slice(-2);
      minutesSpan.innerHTML = ('0' + t.minutes).slice(-2);
      secondsSpan.innerHTML = ('0' + t.seconds).slice(-2);
  
      if (t.total <= 0) {
        clearInterval(timeinterval);
      }
    }
  
    updateClock();
    const timeinterval = setInterval(updateClock, 1000);
  }
  
  const deadline = new Date(Date.parse(new Date()) + 15 * 24 * 60 * 60 * 1000);
  initializeClock('clockdiv', deadline);

  //$(".product-card").on("click", function () {
  //  window.location.href= "product-info.html";
  //})

  //function getProductCount(list) {
  //  return list.length;
  //  }

  //  let table = $(".products-added-cart .list-added");

  //  let products = [];
  //  if (JSON.parse(localStorage.getItem("products")) != null) {
  //    products = JSON.parse(localStorage.getItem("products"));
  //  }

  //  getProductList(products);
  //  function getProductList(list) {
  //      for (const product of list) {
  //          table.append(`<li>
  //          <div class="product-image"><img src="${product.img}" alt="img-product"></div>
  //          <div class="product-info-price">
  //          <p>${product.name}</p>
  //          $<span>${product.price}</span>
  //          </div>
  //      </li>`);
  //      }
  //  }
});
