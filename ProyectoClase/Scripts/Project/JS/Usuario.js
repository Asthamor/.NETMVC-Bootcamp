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
        if (form.valid()) {
            let data = new FormData(document.querySelector("#createUserForm"));
            createUser(data);
        } else {
            validator.showErrors();
        }
        
    })

    function createUser(dataUsuario) {
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
                alert("error ", data.Error, "");
            }
        });
    }

    function successCreateUser(data) {
        if (data.success) {
            alert("Usuario guardado")
        } else {
            alert(data.error);
            console.error(data.error);
        }
    }

        


});