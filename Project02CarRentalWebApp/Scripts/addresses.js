$(window).on("load", function () {
    function filter() {
        var searchPhrase = search ? $("#addressLookUp").val() : null;
        var order = getURLParameter("order") === null ? "" : getURLParameter("order");
        var pageSize = getURLParameter("PageSize");
        window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&order=" + order + "&pageNumber=" + this.value + "&PageSize=" + pageSize);
    }
    function sort() {
        var searchPhrase = search ? $("#addressLookUp").val() : null;
        var pageSize = getURLParameter("PageSize");
        window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&order=" + this.id + "&PageSize=" + pageSize);
    }
    function getURLParameter(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'), results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, ' '));
    }
    $("#search").click(filter);
    $("#addressLookUp").keypress(function (e) {
        if (e.which === 13) {
            filter();
        }
    });
    $("#clearSearch").click(function () {
        window.location.assign("/Address/Index?pageNumber =" + 1);
    });
    $("#PageNumber").keypress(function (e) {
        if (e.which === 13) {
            filter.apply(this);
            $("#addressLookUp").val = searchPhrase;
        }
    });
    $('#pagesizelist').on('change', function () {
        var searchPhrase = search ? $("#addressLookUp").val() : null;
        var order = getURLParameter("order");
        pageSize = $('#pagesizelist').val();
        if (order === null) {
            window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&PageSize=" + pageSize);
        }
        else {
            window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&PageSize=" + pageSize + "&order=" + order);
        }
    });
    $("#CityName_Asc").click(sort);
    $("#CityName_Desc").click(sort);
    $("#StreetName_Asc").click(sort);
    $("#StreetName_Desc").click(sort);
    $("#ZipCode_Asc").click(sort);
    $("#ZipCode_Desc").click(sort);
    $("#PhoneNumber_Asc").click(sort);
    $("#PhoneNumber_Desc").click(sort);
    $("#FillSurvey").click(function () {
        window.location.assign("/Survey/Fill?id=" + $("#SurveyDropdown").val() + "&addressId=" + addressId);
    }
    );
    $('.alert').hide();
    var alertHandler = function (message) {
        $('.alert').show().fadeTo(500, 1);
        $("#message").text(message);
        window.setTimeout(function () {
            $('.alert').fadeTo(500, 0).slideUp(500, function () {
                $(this).hide();
            });
        }, 3000);
    };

    $("#sendEmail").click(function () {
        var addressId = window.location.href.split("/").pop();
        $.ajax({
            url: "/Address/SendEmail?addressId=" + addressId,
            data: { messageText: $("#emailMsg").val() },
            success: function (result, status, xhr) {
                alertHandler("E-mail sent");
            },
            error: function (result, status, xhr) {
                alertHandler("Failed to send an e-mail");
            }
        });
    });
    $.ajax({
        type: "POST",
        url: "/Address/GetNumberPages",
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function () {
            //uncomment do overwite whatever is in TotalPageNumber div
            // $("#TotalPageNumber").text(result);
        },
        error: function (xhr, status, error) {
            $("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
        }
    });
});
$(window).trigger("load");