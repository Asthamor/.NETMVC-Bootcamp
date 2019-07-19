$(document).ready(() => {
    $("#TopBtn, #BottomBtn").click((event) => {
        addProductToCart();
    });

    function addProductToCart() {
        console.log("ajax");
        let url = decodeURIComponent($('#AddToCart').val());
        let urlTemplate = jQuery.validator.format(url);
        url = urlTemplate($("#cantidadInput").val());

        console.log(url);
        $.ajax({
            url: url,
            type: "POST",
            async: true,
            success: successProductAdded,
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert("error ", data.Error, "Ocurrió un error al intentar añadir el producto");
            }
        });
    }

    function successProductAdded(data) {
        data = JSON.parse(data);
        console.log(data);
        if (data.success) {
            alert("Producto Añadido");
        } else {
            alert("Ocurrió un error al intentar añadir el producto");
            console.error("Ocurrió un error al intentar añadir el producto");
        }
    }

    String.format = function () {
        let s = arguments[0];
        for (var i = 0; i < arguments.length - 1; i++) {
            let reg = new RegExp("\\{" + i + "\\}", "gm");
            s = s.replace(reg, arguments[i + 1]);
        }

        return s;
    }

});