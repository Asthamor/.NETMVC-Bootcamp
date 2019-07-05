﻿$(document).ready(() => {
    $("#formInicio").submit((event) => {
        event.preventDefault();
        let userData = {
            Usuario: $("#nomUser").val(),
            Password: $("#userPass").val(),
        }
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
                alert("error ", data.Mensaje, "verificar info");
            }
        });

    }

    function SuccessLlamadaIniciarSesion(data) {
        if (data.Exito) {
            var url = $('#SuccessLogin').val();
            window.location.href = url;
        }
        else if (data.Advertencia) {
            alert("advertencia");

        }
        else {
            alert(data.Mensaje
            );
        }
    }


    $("#nomUsuario").on("input", (event) => {
        if (event.target.validity.valid) {
            $(".error").innerHTML = "";
            $(".error").className = "error";
        }
    }, false);


});