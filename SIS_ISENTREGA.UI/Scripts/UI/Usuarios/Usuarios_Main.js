$("#btnSalvar").click(function () {
    console.log("chamou");
    $("span").removeClass("field-validation-error").addClass("field-validation-valid").text("");
    $.ajax({
        url: "/Account/Create",
        type: "POST",
        data:  $("#formcad").serialize() ,
        success: function (dataRet) {
         
            if (dataRet.Message === "sucesso") {
                window.location.href = "/Home/Index";
            } else {
                $.each(dataRet.Erros, function () {
                    if (this.PropertyName != "SenhaLogin" && this.PropertyName != "Login") {
                        $("span[data-valmsg-for='"+ this.PropertyName+"']")
                        .removeClass("field-validation-valid")
                        .addClass("field-validation-error")
                        .text(this.ErrorMessage);
                    }
                });
            }
           
        }
    });


});


$("#btnLogin").click(function () {
    $("span").removeClass("field-validation-error").addClass("field-validation-valid").text("");
    $.ajax({
        url: "/Account/Login",
        type: "POST",
        data: $("#formLogin").serialize(),
        success: function (dataRet) {

            if (dataRet.Message === "sucesso") {
                window.location.href = "/Home/Index";
            }
            else if (dataRet.Message === "usuario_not") {
                $("#spnUsuario").removeClass("field-validation-valid")
                    .addClass("field-validation-error").text("Usuário ou Senha diferentes");
            }
            else {
                $.each(dataRet.Erros, function () {
                    if (this.PropertyName === "SenhaLogin" || this.PropertyName === "Login") {
                        $("span[data-valmsg-for='" + this.PropertyName + "']")
                            .removeClass("field-validation-valid")
                            .addClass("field-validation-error")
                            .text(this.ErrorMessage);
                    }
                });
            }

        }
    });


});