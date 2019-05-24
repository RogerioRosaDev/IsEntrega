$("#btnCadastrar").click(function () {
    window.location.href = "/Ponto/Create";
});

$(".btnVisualizar").click(function () {
    var id = $(this).closest("tr").attr("data-codigo");
    var url = "/Ponto/ReadPonto?id=" + id;
    window.location.href = url;
});

$(".btnEditar").click(function () {
    var id = $(this).closest("tr").attr("data-codigo");
    var url = "/Ponto/AlterPonto?id=" + id;
    window.location.href = url;
});

$(".btnDeletar").click(function () {
    var id = $(this).closest("tr").attr("data-codigo");
    var col = $(this).closest("tr");
    var url = "/Ponto/DeletePonto?id=" + id;
    var conf = confirm("Deseja realmente excluir esta matriz?");
    if (conf == true) {
        $.ajax({
            url: url,
            type: "POST",
            success: function () {
                col.hide();
            },
            error: function (erro) {
                console.log(erro);
            }
        });
    }
    //});

});