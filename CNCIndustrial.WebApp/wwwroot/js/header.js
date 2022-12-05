// $(document).ready(function() {
//     $('.menu-mobile-toggle').click(function() {
//         $('.nav-mobile').slideToggle(400);
//     });

//     smallScreenMenu();
//     let temp;

//     function resizeEnd() {
//         smallScreenMenu();
//     }

//     $(window).resize(function() {
//         clearTimeout(temp);
//         temp = setTimeout(resizeEnd, 100);
//         resetMenu();
//     });
// });


// const subMenus = $('.nav-mobile-level-2');
// const menuLinks = $('.nav-mobile-level-1-item');

// function smallScreenMenu() {
//     if ($(window).innerWidth() <= 992) {
//         menuLinks.each(function(item) {
//             $(this).click(function() {
//                 $(this).next().slideToggle();
//             });
//         });
//     } else {
//         menuLinks.each(function(item) {
//             $(this).off('click');
//         });
//     }
// }