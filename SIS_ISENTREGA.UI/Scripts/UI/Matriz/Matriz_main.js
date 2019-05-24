$("#btnSalvar").click(function () {
    $("span").removeClass("field-validation-error").addClass("field-validation-valid").text("");

    $.ajax({
        url: "/Matriz/Create",
        type: "POST",
        data: $("#formCamposMatriz").serialize(),
        success: function (retorno) {

            
            if (retorno.Message === "sucesso") {
                $("#btnSalvar").hide();
                window.location.href = "/Matriz/Index";
               
            } else {
                $.each(retorno.Erros, function () {
                    $("span[data-valmsg-for='" + this.PropertyName + "']")
                        .removeClass("field-validation-valid")
                        .addClass("field-validation-error")
                        .text(this.ErrorMessage);
                });

                
            }
        }

    });
});
$("#btnVoltar").click(function () {

    window.location.href = "/Matriz/Index";

});

