$(document).ready(() => {

    let form = $("#createProductForm");
    let validator = form.validate({
        lang: "es",
        rules: {
            stock: {
                digits: true,
            },
            precio_venta: {
                number: true,
            },
            precio_compra: {
                number: true,
            },
            imagen: {
                required: false,
                extension: "jpeg|jpg|png|svg"
            },
        }
    });

    $("#imagen").fileinput({
        language: "es",
        showUpload: false,
        showClose: false,
        autoOrientImage: false,
    });

    $("#createProductForm").submit((event) => {
        event.preventDefault();
        if (form.valid()) {
            let data = new FormData(document.querySelector("#createProductForm"));
            $("#addProductSubmit").prop('disabled', true);
            createProduct(data);
        } else {
            validator.showErrors();
        }

    })

    function createProduct(dataProducto) {
        OpenLoadingModal();
        var url = $('#URLCreateProduct').val();
        $.ajax({
            url: url,
            data: dataProducto,
            type: "POST",
            cache: false,
            contentType: false,
            processData: false,
            async: true,
            success: successCreatedProduct,
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                CloseLoadingModal();
                MensajeError("Ocurrió un error al intentar enviar los datos al servidor");
                $("#addProductSubmit").prop('disabled', false);
            }
        });
    }

    function successCreatedProduct(data) {
        CloseLoadingModal();
        data = JSON.parse(data);
        $("#addProductSubmit").prop('disabled', false);
        if (data.success) {
            MensajeExito("Producto guardado");
        } else {
            MensajeAdvertencia(data.error);
            console.warn(data.error);
        }
        document.querySelector("#createProductForm").reset();
        $('#input-id').fileinput('reset');
    }


});