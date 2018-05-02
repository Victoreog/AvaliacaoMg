var IncluirClienteGet = function () {
    var request = $.ajax({
        url: urlBase + "Home/Incluir",
        method: "GET",
        dataType: "html"
    });

    request.done(function (retorno) {
        $("#content_container").html(retorno);

    });
};

var EditarClienteGet = function (idcliente) {
    var request = $.ajax({
        url: urlBase + "Home/Editar",
        method: "GET",
        data: { IdCliente: idcliente },
        dataType: "html"
    });

    request.done(function (retorno) {
        $("#content_container").html(retorno);
    });
};

var CadastrarClientePost = function (idcliente) {

    Util.form.validade.rebuild("#formCadastrar");

    if ($("#formCadastrar").valid()) {
        var request = $.ajax({
            url: urlBase + $("#formCadastrar").attr("action"),
            method: "POST",
            data: $('#formCadastrar').serializeArray()
        });

        request.done(function (retorno) {
            $("#content_container").html(retorno);
        });
    }

    
};


function resetFormValidator(formId) {
    $(formId).removeData('validator');
    $(formId).removeData('unobtrusiveValidation');
    $.validator.unobtrusive.parse(formId);
}

$(document).on('click', 'button#btnAddSocio', function () {
    Util.form.elements.clone(".itemSocio", "#itemSocioContainer");
    resetFormValidator("#formCadastrar");
});

$(document).on('click', 'button#btnAddContato', function () {
    Util.form.elements.clone(".itemContato", "#itemContatoContainer");
    resetFormValidator("#formCadastrar");
});

var btn_removeSocio = function (eThis) {

    var itemRemove = $(eThis).parents(".itemSocio");

    if ($(".itemSocio").length > 1) {
        Util.form.elements.remove(itemRemove, "#itemSocioContainer");
    }
        
    else
        alert("Deve haver ao menos um item!");

};

var btn_removeContato = function (eThis) {

    var itemRemove = $(eThis).parents(".itemContato");

    if ($(".itemContato").length > 1)
        Util.form.elements.remove(itemRemove, "#itemContatoContainer");
    else
        alert("Deve haver ao menos um item!");

};




$(document).ready(function () {

    function limpa_formulário_cep() {
        // Limpa valores do formulário de cep.
        $("#Endereco").val("");
        //$("#bairro").val("");
        //$("#cidade").val("");
        //$("#uf").val("");
        //$("#ibge").val("");
    }

    //Quando o campo cep perde o foco.
    $(document).on('blur', '#Cep', function () { 

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#Endereco").val("...");
                //$("#bairro").val("...");
                //$("#cidade").val("...");
                //$("#uf").val("...");
                //$("#ibge").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#Endereco").val(dados.logradouro);
                        //$("#bairro").val(dados.bairro);
                        //$("#cidade").val(dados.localidade);
                        //$("#uf").val(dados.uf);
                        //$("#ibge").val(dados.ibge);
                    } 
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } 
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } 
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });
});