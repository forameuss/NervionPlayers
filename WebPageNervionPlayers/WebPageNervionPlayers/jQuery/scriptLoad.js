$(function () {
    //$("#tabla").tablesorter( {sortList: [[0,0], [1,0]]} );
    //$("#call").click(getClientes);
    //$("#callId").click(getClientesId);
    //modificar por id de botones reales
    clickBtnRegistro();
    clickBtnLogin();
});

function clickBtnRegistro() {
    $("#btnRegistro").click(function () {
        window.location.href = "/Home/Registro";
    });
}

function clickBtnLogin() {
    $("#btnLogin").click(function () {
        var usuario = $("#txtUsuario").val;
        var passw = $("#txtPassword").val;
        var alumnos = getAlumnos();

        $.each(alumnos, function (index, value) {
            
            var persona = value;
            if ((usuario == persona.getNombre() || usuario == persona.getAlias()) && passw == persona.getContraseña()) {
                //correcto
                alert("CORRECTO");
            }
            else {
                alert("ESTO NO VA");
            }
        })

        window.location.href = "/Home/Login";
    });
}