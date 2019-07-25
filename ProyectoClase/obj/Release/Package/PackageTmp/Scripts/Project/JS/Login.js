$(document).ready(() => {
    $("#formInicio").submit((event) => {
        event.preventDefault();
        console.log("submited");
        let userData = {
            Usuario: $("#nomUser").val(),
            Password: $("#userPass").val(),
        }
        $("#loginbtn").prop('disabled', true);
        login(userData);
    });

    function login(dataUsuario) {
        var url = $('#UrlLogueo').val();
        $.ajax({
            url: url,
            data: JSON.stringify({ dataUsuario }),
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: SuccessLlamadaIniciarSesion,
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                MensajeError("No se pudo conectar con el servidor");
            }
        });

    }

    function SuccessLlamadaIniciarSesion(data) {
        if (data.Exito) {
            var url = $('#SuccessLogin').val();
            window.location.href = url;
        }
        else if (data.Advertencia) {
            MensajeAdvertencia(data.Advertencia);
            $("#loginbtn").prop('disabled', false);
        }
        else {
            MensajeError(data.Error);
            $("#loginbtn").prop('disabled', false);
        }
    }


    $("#nomUsuario").on("input", (event) => {
        if (event.target.validity.valid) {
            $(".error").innerHTML = "";
            $(".error").className = "error";
        }
    }, false);


});