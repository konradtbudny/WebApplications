$(window).on("load", function () {
    $("#romanButton").click(function () {
        let button = $(this);
        if (button.hasClass("btn-primary")) {
            button.removeClass("btn-primary");
            button.addClass("btn-danger");
        } else {
            button.removeClass("btn-danger");
            button.addClass("btn-primary");
        }
    });
});
$(window).trigger("load");