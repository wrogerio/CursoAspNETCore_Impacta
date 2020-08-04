$(document).ready(function () {

    $("#idEvento").change(function (e) {
        e.preventDefault();
        var evento = $("option:selected", this).val();

        $("#resultado").html("");
        if (evento > 0) {
            $("#resultado").load("/Participantes/ListarParticipantesAjax?idEvento=" + evento);
        }
        else {
            $("#resultado").html("<div class='alert alert-danger'>Sem nenhum participante</div>");
        }
    });
});
