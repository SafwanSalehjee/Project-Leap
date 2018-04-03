$(document).ready(function () {

    //Click event to scroll to top
    $("#scrollerA").click(function () {
        $('html, body').animate({
            scrollTop: $("#scrolleeA").offset().top
        }, 500);
    });

    $("#scrollerB").click(function () {
        $('html, body').animate({
            scrollTop: $("#scrolleeB").offset().top
        }, 500);
    });

    $("#scrollerC").click(function () {
        $('html, body').animate({
            scrollTop: $("#scrolleeC").offset().top
        }, 500);
    });

    $("#scrollerD").click(function () {
        $('html, body').animate({
            scrollTop: $("#scrolleeD").offset().top
        }, 500);
    });
});