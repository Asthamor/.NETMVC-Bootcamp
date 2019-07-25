$(document).ready(() => {
    $("#fechaNacimiento").datepicker({
        format: "dd-mm-yyyy",
    });
    let form = $("#createUserForm");
    let validator = form.validate({
        lang: "es",
        rules: {
            ConfirmPasswd: {
                equalTo: "#password",
            },
            password: {
                pattern: "(?=.*[1-9])(?=.*[a-z])(?=.*[A-Z]).{8,}",
            },

        },
    });

    $("#createUserForm").submit((event) => {
        event.preventDefault();
        $("#addUsuarioSubmit").prop('disabled', true);
        if (form.valid()) {
            let data = new FormData(document.querySelector("#createUserForm"));
            createUser(data);
        } else {
            $("#addUsuarioSubmit").prop('disabled', false);
            validator.showErrors();
        }
        
    })

    function createUser(dataUsuario) {
        OpenLoadingModal();
        var url = $('#URLCreateUser').val();
        $.ajax({
            url: url,
            data: JSON.stringify(Object.fromEntries(dataUsuario)),
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: successCreateUser,
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                CloseLoadingModal();
                $("#addUsuarioSubmit").prop('disabled', false);
                MensajeError("Ocurrió un error al intentar enviar los datos al servidor");
            }
        });
    }

    function successCreateUser(data) {
        CloseLoadingModal();
        $("#addUsuarioSubmit").prop('disabled', false);
        if (data.success) {
            MensajeExito("Usuario guardado");
        } else {
            MensajeAdvertencia(data.error);
            console.warn(data.error);
        }
        document.querySelector("#createUserForm").reset();

    }

        


});