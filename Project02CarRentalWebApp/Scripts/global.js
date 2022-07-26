$(window).on("load", function () {
    $(".gradient-button-js").hover(
        function () {
            alert("i hover");
        }
    );
});
$(window).trigger("load");