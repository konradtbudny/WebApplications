$(window).on("load", function () {
    function getURLParameter(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'), results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, ' '));
    }
    //WORKING, DON'T REMOVE IT, it asks each response whether it should be ticked. Replaced with more efficint mechanism
    //(function () {
    //    //Code that goes through radio buttons and tick them, if backend returns them
    //    $(".answer-button").each(function () {
    //        var answerId = this.id;
    //        var addressId = getURLParameter("addressId");
    //        var radioButtonId = this.id;
    //        $.ajax({
    //            url: "/Survey/CheckAnswer?addressId=" + addressId + "&answerId=" + answerId,
    //            success: function (response) {
    //                $("#" + radioButtonId).prop('checked', true);
    //            }
    //        });
    //    });
    //})();


    $(".answer-button").on('load', function () {
        var answerId = this.id;
        var name = this.name;
        var addressId = getURLParameter("addressId");
        $.post({
            url: "/Survey/CheckAnswer?addressId=" + addressId + "&answerId=" + answerId,
            success: function (response) {
                alert(response);
                $("input[name'" + name + "'][value='" + answerId + "']").prop('checked', true);
            }
        });
    });

    $(".answer-button").click(function () {
        var answerId = this.id;
        var name = this.name;
        var addressId = getURLParameter("addressId");
        $.ajax({
            url: "/Survey/SaveAnswer?addressId=" + addressId + "&answerId=" + answerId,
            success: function (result, status, xhr) {
                alert("ok");
                $("input[name='" + name + "'][value='" + answerId + "']").prop('checked', true);
            },
            error: function (xhr, status, error) {
                alert("AddressId:" + addressId + "\nanswerId:" + answerId + "\nresult: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
            }
        });
        return false;
    });

});
