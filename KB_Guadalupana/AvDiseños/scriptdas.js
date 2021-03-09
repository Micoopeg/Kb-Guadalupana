$(document).ready(function () {

    $("#BODYCIF").slideToggle("fast"); // The Body of "Messages" is already opened in the design sample.

    $("#ENCABAREA").click(function () {
        $(".tab").removeClass("tabSelected");
        $(".tab").addClass("tabNoSelected");
        $(this).removeClass("tabNoSelected");
        $(this).addClass("tabSelected");
        $(".tabBody").slideUp("fast");
        $("#BODYAREA").slideToggle("fast");
    });
    $("#ENCABFECHA").click(function () {
        $(".tab").removeClass("tabSelected");
        $(".tab").addClass("tabNoSelected");
        $(this).removeClass("tabNoSelected");
        $(this).addClass("tabSelected");
        $(".tabBody").slideUp("fast");
        $("#BODYFECHA").slideToggle("fast");
    });
    $("#ENCABCIF").click(function () {
        $(".tab").removeClass("tabSelected");
        $(".tab").addClass("tabNoSelected");
        $(this).removeClass("tabNoSelected");
        $(this).addClass("tabSelected");
        $(".tabBody").slideUp("fast");
        $("#BODYCIF").slideToggle("fast");
    });
    $("#ENCABESTADO").click(function () {
        $(".tab").removeClass("tabSelected");
        $(".tab").addClass("tabNoSelected");
        $(this).removeClass("tabNoSelected");
        $(this).addClass("tabSelected");
        $(".tabBody").slideUp("fast");
        $("#BODYESTADO").slideToggle("fast");
    });
});