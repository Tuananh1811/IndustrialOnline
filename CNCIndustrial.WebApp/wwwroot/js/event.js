const icon = document.getElementById("icon");
const navMobileLevel1 = document.getElementById("menuCap1");

icon.addEventListener("click", function(e) {
    e.preventDefault();

    if (navMobileLevel1.style.display === "block") {
        navMobileLevel1.style.display = "none";
    } else {
        navMobileLevel1.style.display = "block";
    }

})
const liArayy = document.getElementsByClassName("nav-mobile-level-1-item");
console.log(liArayy);
const navMobileLevel2 = document.getElementById("menuCap2");
const navMobileLevel2New = document.getElementById("menuCap2News");
console.log(navMobileLevel2);
for (let i = 0; i < liArayy.length; i++) {
    const liItem = liArayy[i];

    liItem.addEventListener("click", function(e) {

        e.preventDefault();
        if (liItem.lastElementChild.classList.contains("nav-mobile-level-2")) {
            if (navMobileLevel2.style.display == "block") {
                navMobileLevel2.style.display = "none";
            } else {
                navMobileLevel2.style.display = "block";

            }

        }

    })
}

function animateNumber(finalNumber, duration = 5000, startNumber = 50, callback) {
    const final_number = parseFloat(finalNumber);
    // console.log(typeof(final_number, final_number));
    let currentNumber = parseFloat(startNumber);
    const interval = window.setInterval(updateNumber, 15)

    function updateNumber() {
        if (currentNumber >= final_number) {
            clearInterval(interval)
        } else {
            let inc = Math.ceil(final_number / (duration / 15))
            if (currentNumber + inc > final_number) {
                currentNumber = final_number
                clearInterval(interval)
            } else {
                currentNumber += inc
            }
            callback(currentNumber)
        }
    }
}
// DOMContentLoaded

$(document).ready(function() {
    $(window).scroll(function() {
        if ($(this).scrollTop() > 40) {
            $('#scroll').fadeIn();
            $('.header-top').fadeOut("slow")
        }
        if ($(this).scrollTop() < 40) {

            $('.header-top').fadeIn();
            $('#scroll').fadeOut();

        }
    });
    $('#scroll').click(function() {
        $("html, body").animate({ scrollTop: 0 }, 40);
        return false;
    });
});

var btnFormHomePage = document.getElementById("request-form");
var btnModalForm = document.getElementById("modal-form");
var btnIcon = document.getElementById("btnIconI");
btnFormHomePage.addEventListener("click", function(e) {
    e.preventDefault();
    btnModalForm.style.display = "block";

})
btnIcon.addEventListener("click", function(e) {
    e.preventDefault();
    btnModalForm.style.display = "none";

})

// function resetMenu() {
//     if ($(window).innerWidth() < 600) {
//         navMobileLevel1.each(function(item) {
//             $(this).css('display', 'none');
//         });
//     }
// }

// var blockHeaderTop = document.getElementsByClassName("header-top")[0];
// var blockHeaderMain = document.getElementsByClassName("header-main");
// window.addEventListener("scroll", function() {
//     blockHeaderTop.style.display = "none";
// })


// SLIDE AUTO
const myCarouselElement = document.querySelector('#carouselExampleControls')
const carousel = new bootstrap.Carousel(myCarouselElement, {
    interval: 1500,
    wrap: true
})