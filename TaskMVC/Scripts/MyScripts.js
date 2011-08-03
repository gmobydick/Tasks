/// <reference path="jquery-1.5.2.js" />
/// <reference path="jquery-ui.js" />

var menuIconWidth = 20;
var footer = 30;
var header = 75;
var floatingMenu = 60;
var mainPaddingAndMarginTopAndBottom = 30;
var topMargin = null;
var openImage = '<img src="/Content/Menues.png" alt="open" />';
var closeImage = '<img src="/Content/Menues.png" alt="close" />';
// floating div id  http://localhost:40664/Config/Country/Edit/@Url.Content(
var floatingDiv = "#floatingMenu";


$(document).ready(function () {
    // Getting Viewport size and setting 
    // div#main to fill all (-footer, header and mainPaddingAndMarginTopAndBottom)
    // div#floatingMenu to fill all (-footer and header)
    var viewportWidth = $(window).width() - floatingMenu;
    var viewportHeight = $(window).height() - footer - header;
    $("#main").height(viewportHeight - mainPaddingAndMarginTopAndBottom);
    $("#main").width(viewportWidth);
    $("#floatingMenu").height(viewportHeight);
    // Register event to handle any change in size (resize event)
    $(window).resize(function () {
        var viewportWidth = $(window).width() - floatingMenu;
        var viewportHeight = $(window).height() - footer - header;
        $("#main").height(viewportHeight);
        $("#main").width(viewportWidth - mainPaddingAndMarginTopAndBottom);
        $("#floatingMenu").height(viewportHeight);
    });


    $("#menuImage").html(openImage);
    topMargin = parseInt($(floatingDiv).css("top").substring(0, $(floatingDiv).css("top").indexOf("px")));
    $(floatingDiv).css({ left: menuIconWidth - $(floatingDiv).width() });
    // for floating menu
    $(floatingDiv).mouseenter(function () {
        // show menu
        $(this).stop().animate({ left: 0 }, "slow");
        $("#menuImage").html(closeImage);
    }).mouseleave(function () {
        // hide menu
        $(this).stop().animate({ left: menuIconWidth - $(this).width() }, "slow");
        $("#menuImage").html(openImage);
    });
    // handle the scroll event of the window.
    $(window).scroll(function () {
        // calculate the offset of the page scroll and animate the div for the floating effect.
        var offset = topMargin + $(document).scrollTop() + "px";
        $(floatingDiv).animate({ top: offset }, { duration: 500, queue: false });
    });

});