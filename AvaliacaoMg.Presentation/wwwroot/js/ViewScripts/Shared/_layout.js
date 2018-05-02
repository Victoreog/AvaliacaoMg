$(document).on('click', '.homeLink', function () { GoToHome(); })

var GoToHome = function () {
    var request = $.ajax({
        url: urlBase + "Home/Index",
        method: "GET"
    });

    request.done(function (retorno) {
        $("#content_container").html(retorno);
    });
}

