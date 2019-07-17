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

    $("#createProductForm").submit((event) => {
        event.preventDefault();
        if (form.valid()) {
            let data = new FormData(document.querySelector("#createProductForm"));
            createProduct(data);
        } else {
            validator.showErrors();
        }

    })

    function createProduct(dataProducto) {
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
                alert("error ", data.Error, "Ocurrió un error al intentar enviar los datos al servidor");
            }
        });
    }

    function successCreatedProduct(data) {
        if (data.success) {
            alert("Producto guardado")
        } else {
            alert(data.error);
            console.error(data.error);
        }
    }


});