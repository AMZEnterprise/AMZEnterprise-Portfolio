/*-----------------------------------------------------------
* Template Name    : Arshia | Responsive One Page HTML Template
* Author           : Retrina Group
* Version          : 1.0.0
* Created          : June 2020
* File Description : Main js file of the template
*------------------------------------------------------------
*/

// repeated variables
var $window = $(window);
var $root = $('html, body');

$(document).ready(function () {

    "use strict";
    themeOption();
    sidebarMenu();
    ColorPallet();
    PillMenuToggler();
    menuToggler();
    typedJS();
    skills();
    countUp();
    portfolioPopup();
    clientCarousel();
    BlogCarousel();
    postSidebar();
});

$window.on("load", (function() {
    $("#overlayer").delay(500).fadeOut('slow');
    $(".loader").delay(1000).fadeOut('slow');
    portfolioIsotop();
    scrollToAnchor();
}));

/*-----------------------------------------------------------------------------
                                   FUNCTIONS
-----------------------------------------------------------------------------*/

function scrollToAnchor(){
    //getting the anchor link in the URL and deleting the `#`
    var value =  window.location.hash.replace('#','');
    if(value.length > 0){
        var sectionAnchor = '#'+value;
        $("#main > section.active, #menu > li a").removeClass("active");
        $('#main > section'+sectionAnchor).addClass('active');
        $('#menu > li a[href$='+value+']').addClass('active');
    }
}

/*-------------------------
        Theme Option
-------------------------*/
function themeOption(){

    "use strict";

    $('.color-scheme li .dark-scheme').click(function() {
        $("body").addClass('arshia-dark');
        $('.color-scheme li a').removeClass('active');
        $(this).addClass('active');
    });

    $('.color-scheme li .light-scheme').click(function() {
        $("body").removeClass('arshia-dark');
        $('.color-scheme li a').removeClass('active');
        $(this).addClass('active');
    });

    $('.theme-skin li .flat-skin').click(function() {
        $("body").addClass('flat-demo');
        $('.theme-skin li a').removeClass('active');
        $(this).addClass('active');
    });

    $('.theme-skin li .neo-skin').click(function() {
        $("body").removeClass('flat-demo');
        $('.theme-skin li a').removeClass('active');
        $(this).addClass('active');
    });
}

/*-------------------------
      ColorFull Demo
-------------------------*/

var list = document.getElementsByClassName('data-background');

     for (var i = 0; i < list.length; i++) {
       var color = list[i].getAttribute('data-color');
       list[i].style.backgroundColor = "" + color + "";
     }

     
var allDivs = document.getElementsByClassName('data-text-color');

    for( var i =0; i < allDivs.length; ++i )
    {
        var color = allDivs[i].getAttribute('data-color');
        allDivs[i].style.color = "" + color + "";
    }

    
var allDivs = document.getElementsByClassName('timeline-border');

for( var i =0; i < allDivs.length; ++i )
{
    var color = allDivs[i].getAttribute('data-color');
    allDivs[i].style.borderLeftColor = "" + color + "";
    }
   

/*-------------------------
      Sidebar Menu
-------------------------*/
function sidebarMenu(){

    "use strict";

    var $menuLink = $("#menu > li a");
    var $main = $('#main');

    $menuLink.on("click" , function () {
        $("#main > section.active, #menu > li a").removeClass("active");
        $(this).addClass('active');
        var $id = $(this).attr('href');
        $main.children($id).addClass('active');
    });

    $(".to-contact").on('click', function(){
        $("#main > section.active, #menu > li a").removeClass("active");
        $('#menu > li:last-child a').addClass('active');
        $('#main > section#contact').addClass('active');
    })

    $(".next-page").on("click" , function () {
        if ($("#menu > li a.active").attr('href') !== '#contact'){
            $("#menu > li a.active").each(function (){
                $(this).parents('li').next('li').children('a').each(function(){
                    $(this).addClass('active');
                    var $id=$(this).attr('href');
                    $("#main > section.active").removeClass("active");
                    $main.children($id).addClass('active');
                })
                $(this).removeClass('active');
            })
        } else {
            $("#main > section.active, #menu > li a.active").removeClass("active");
            $("#menu > li:first-child a, main > section:first-child").addClass('active')
        }
    })

    $(".prev-page").on("click" , function () {
        if ($("#menu > li a.active").attr('href') !== '#hero'){
            $("#menu > li a.active").each(function (){
                $(this).parents('li').prev('li').children('a').each(function(){
                    $(this).addClass('active');
                    var $id=$(this).attr('href');
                    $("main > section.active").removeClass("active");
                    $main.children($id).addClass('active');
                })
                $(this).removeClass('active');
            })
        } else {
            $("main > section.active, #menu > li a.active").removeClass("active");
            $("#menu > li:last-child a, main > section:last-child").addClass('active')
        }
    })
}

/*-------------------------
        Color Panel
-------------------------*/
function ColorPallet() {

    "use strict";

    $("ul.pattern .color1").click(function () {
        return $("#option-color").attr("href", "assets/css/color/green-color.css")
    });
    $("ul.pattern .color2").click(function () {
        return $("#option-color").attr("href", "assets/css/color/yellow-color.css")
    });
    $("ul.pattern .color3").click(function () {
        return $("#option-color").attr("href", "assets/css/color/golden-color.css")
    });
    $("ul.pattern .color4").click(function () {
        return $("#option-color").attr("href", "assets/css/color/sky-blue-color.css")
    });
    $("ul.pattern .color5").click(function () {
        return $("#option-color").attr("href", "assets/css/color/blue-color.css")
    });
    $("ul.pattern .color6").click(function () {
        return $("#option-color").attr("href", "assets/css/color/purple-color.css")
    });
    $("ul.pattern .color7").click(function () {
        return $("#option-color").attr("href", "assets/css/color/orange-color.css")
    });
    $("ul.pattern .color8").click(function () {
        return $("#option-color").attr("href", "assets/css/color/pink-color.css")
    });
    $("ul.pattern .color9").click(function () {
        return $("#option-color").attr("href", "assets/css/color/red-color.css")
    });
    $("#color-switcher .pallet-button").click(function () {
        $("#color-switcher .color-pallet").toggleClass('show')
    })
}

/*-------------------------
     MENU TOGGLER
-------------------------*/
function PillMenuToggler() {

    "use strict";
    $(".overlay-menu-toggler").click(function(){
        $(".overlay-menu").addClass("show");
    });
    $(".overlay-menu").click(function(){
        $(this).removeClass("show");
    });
}

function  menuToggler() {
    "use strict";
    var $menuToggler = $(".menu-toggler");
    var $header = $('header');
    $menuToggler.click(function () {
        $(this).toggleClass('open').find('i').toggleClass('fa-list fa-times');
        $header.toggleClass('open');
    });
    if ($window.width() < 1200){
        $('header li a').click(function () {
            $header.removeClass('open');
            $menuToggler.removeClass('open').find('i').removeClass('fa-times').addClass('fa-list');
        })
    }
}

/*-------------------------
        TYPED JS
-------------------------*/
function typedJS() {

    "use strict";

    var $element = $('.element');
    if ($element.length > 0) {
        var options = {
            strings: $element.attr('data-elements').split(','),
            typeSpeed: 100,
            backDelay: 3000,
            backSpeed: 50,
            loop: true
        };
        var typed = new Typed(".element", options);
    }
}

/*-------------------------
          Skills
-------------------------*/
function skills() {

    "use strict";
    $('.skillbar').each(function () {
        $(this).find('.skillbar-bar').animate({
            width: $(this).attr('data-percent')
        }, 6000);
    });
}

/*-------------------------
         Count up
-------------------------*/
function countUp() {

    "use strict";

    $('.timer').countTo();
    $('.count-number').removeClass('timer');

}
/*-------------------------
     MAGNIFIC POPUP JS
-------------------------*/
function portfolioPopup() {

    "use strict";

    if (('.portfolio-items').length > 0) {
        $('.portfolio-items').each(function() {
            $(this).magnificPopup({
                delegate: '.js-zoom-gallery',
                type: 'image',
                gallery: {
                    enabled:true
                }
            });
        });
    }
}
/*-------------------------
        ISOTOPE JS
-------------------------*/
function portfolioIsotop() {

    "use strict";

    // init Isotope
    var initial_items = $('#showMore-initials').data("initial");
    var next_items = $('#showMore-initials').data("next");
    var $pfilter = $('#portfolio-filter');
    var $grid = $('.portfolio-items');
    var $showMore = $('#showMore');
    $grid.isotope({
        itemSelector: '.portfolio-item',
        layoutMode: 'masonry',
    });
    $pfilter.find('a').on("click",function() {
        var filterValue = $(this).attr('data-filter');
        $pfilter.find('a').removeClass('active');
        $(this).addClass('active');
        $grid.isotope({
            filter: filterValue,
        });
        updateFilterCounts();
        return false;
    });
    function updateFilterCounts() {
        var itemElems = $grid.isotope('getFilteredItemElements');
        var count_items = $(itemElems).length;
        if (count_items > initial_items) {
            $showMore.show();
            $showMore.parent('.button-border').addClass('mr-2 mr-sm-4').removeClass('p-0');
            
        } else {
            $showMore.hide();
            $showMore.parent('.button-border').removeClass('mr-2 mr-sm-4').addClass('p-0');
        }
        if ($('.portfolio-item').hasClass('visible_item')) {
            $('.portfolio-item').removeClass('visible_item');
        }
        var index = 0;

        $(itemElems).each(function() {
            if (index >= initial_items) {
                $(this).addClass('visible_item');
            }
            index++;
        });
        $grid.isotope('layout');
    }
    function showNextItems(pagination) {
        var itemsMax = $('.visible_item').length;
        var itemsCount = 0;
        $('.visible_item').each(function() {
            if (itemsCount < pagination) {
                $(this).removeClass('visible_item');
                itemsCount++;
            }
        });
        if (itemsCount >= itemsMax) {
            $showMore.hide();
            $showMore.parent('.button-border').removeClass('mr-2 mr-sm-4').addClass('p-0');
        }
        $grid.isotope('layout');
    }
    // function that hides items when page is loaded
    function hideItems(pagination) {
        var itemsMax = $('.portfolio-item').length;
        var itemsCount = 0;
        $('.portfolio-item').each(function() {
            if (itemsCount >= pagination) {
                $(this).addClass('visible_item');
            }
            itemsCount++;
        });
        if (itemsCount < itemsMax || initial_items >= itemsMax) {
            $showMore.hide();
            $showMore.parent('.button-border').removeClass('mr-2 mr-sm-4').addClass('p-0');
        }
        $grid.isotope('layout');
    }
    $showMore.on('click', function(e) {
        e.preventDefault();
        showNextItems(next_items);
    });
hideItems(initial_items);
}

/*-------------------------
  Testimonial CAROUSEL JS
-------------------------*/
function clientCarousel() {
    $(".testimonial .owl-carousel").owlCarousel({
        loop: true,
        margin: 30,
        stagePadding: 5,
        nav: false,
        autoplay: false,
        dots: true,
        mouseDrag: true,
        touchDrag: true,
        smartSpeed: 700,
        autoplayHoverPause: false,
        responsiveClass: true,
        rtl: true,
        responsive: {
            0: {
                items: 1,
                nav: false
            },
            992: {
                items: 3,
                nav: false,
            },

        }
    });
}
/*-------------------------
     Blog CAROUSEL JS
-------------------------*/
function BlogCarousel() {

    "use strict";

    $(".blog .owl-carousel").owlCarousel({
        items: 1,
        nav: false,
        autoplay: false,
        loop: true,
        dots: true,
        margin: 30,
        mouseDrag: true,
        touchDrag: true,
        smartSpeed: 1000,
        autoplayHoverPause: true,

    });
}
/*-------------------------
    POST SIDEBAR TOGGLER
-------------------------*/
function postSidebar(){
    $('.post-sidebar-toggle').on('click', function(){
        $(this).toggleClass('open');
        $('.post-sidebar').toggleClass('open');
        $('#main > section.active').toggleClass('section-z-index');
    })
}