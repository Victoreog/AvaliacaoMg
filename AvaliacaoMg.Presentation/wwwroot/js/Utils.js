$(document).ajaxSend(function () {
    Util.load.gifLoad.show();
    Util.load.modalInner.showTo("body");
});

$(document).ajaxComplete(function () {
    Util.load.gifLoad.hide();
    Util.load.modalInner.hideTo("body");
});

$(document).ajaxError(function (x, status, error) {

    var msg

    switch (x.status) {
        case 403:
            msg = "Sessão expirada!";
            break;
        case 401:
            msg = "HTTP Error 401 - Não autorizado.";
            break;
        case 408:
            msg = "HTTP Erro 408 - A requisição atingiu Time-out.";
            break;
        case 404:
            msg = "Http Error 404 - Pagina não encontrada.";
            break;
        default:
            msg = "Um erro ocorreu: " + status.responseText; //+ "nError: " + error
            break;
    }

    alert(msg);
});

var Util =
    {
        load: {
            gifLoad: {
                show: function () {
                    $("#global_load").fadeTo(0, 500);
                },
                hide: function () {
                    $("#global_load").fadeTo(500, 0);
                }
            },
            modalInner: {
                showTo: function (container) {
                    var el = $(container);
                    //var w = el.css("width");
                    //var h = el.css("height");

                    var modal = el.find(".element-modal-background");

                    if (modal.length === 0) {

                        var modal = $('<div/>', {
                            "class": "element-modal-background",
                            "width": "100%",// w,
                            "height": "100%"//h
                        }).css(
                            {
                                "display": "none",
                                "background-color": "rgba(0, 0, 0, 0.3)",
                                "position": "absolute",
                                "z-index": "1000",
                                "left": "1px"
                                //,"top": "50px"

                            }).prependTo(el);
                    }

                    modal.show();
                },
                hideTo: function (container) {
                    var el = $(container);
                    var modal = el.find(".element-modal-background");
                    modal.hide();
                }
            }
        },

        getQueryStringParameter: function (paramName, queryString) {

            if (typeof queryString === 'undefined')
                queryString = window.location.href;

            paramName = paramName.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regexS = "[\\?&]" + paramName + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(queryString);
            if (results === null)
                return null;
            else
                return results[1];
        },

        showModalInner: function (container) {
            var el = $(container);
            var w = el.css("width");
            var h = el.css("height");

            var modal = el.find(".element-modal-background");

            if (modal.length === 0) {

                var modal = $('<div/>', {
                    "class": "element-modal-background",
                    "width": w,
                    "height": h,
                }).css("display", "none").prependTo(el);
            }

            modal.fadeIn(160);
        },

        form: {
            validade:
            {
                rebuild: function (formSelector) {
                    var form = $(formSelector);
                    form.removeData('validator');
                    form.removeData('unobtrusiveValidation');
                    $.validator.unobtrusive.parse(form);
                }
            },
            elements: {

                _colIndex: 0,
                clone: function (clonedSelector, containerSelector) {
                    this._colIndex = $(clonedSelector).length;

                    $(clonedSelector).first().clone()
                        .appendTo(containerSelector)
                        .attr("id", clonedSelector + this._colIndex)
                        .find("input, select")
                        .each(function () {

                            $(this).val('');
                            $(this).prop('selected', this.defaultSelected);

                            Util.form.elements.replaceClonedAttr(this);
                        });
                },
                remove(elSelector, clonedSelector) {

                    var eclass = $(elSelector).attr('class');

                    if ($("." + eclass).length > 1) {
                        this._colIndex = $("." + eclass).length - 1;
                    }

                    $(elSelector).remove();

                    $("." + eclass).each(function () {

                        Util.form.elements._colIndex--;

                        $(this)
                            .attr("id", $(this).attr("class") + Util.form.elements._colIndex)
                            .find("input, select")
                            .each(function () {
                                Util.form.elements.replaceClonedAttr(this);
                            });
                    });

                },
                replaceClonedAttr(el) {
                    var re = /[0-9][0-9]|[0-9]/i;
                    var m;

                    if ((m = re.exec(el.id)) !== null) {
                        if (m.index === re.lastIndex) {
                            re.lastIndex++;
                        }

                        el.id = el.id.replace(re, this._colIndex);
                        el.name = el.name.replace(re, this._colIndex);
                    }
                }
            }
        }
    }