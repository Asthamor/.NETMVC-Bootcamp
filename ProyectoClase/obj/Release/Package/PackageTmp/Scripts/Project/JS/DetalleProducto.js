$(document).ready(() => {
    $("#TopBtn, #BottomBtn").click((event) => {
        $("#TopBtn, #BottomBtn").prop('disabled', true);
        addProductToCart();
    });

    $("#DelBtn").click(async (event) => {
        await Swal.fire({
            title: "Eliminar",
            text: '¿Eliminar producto permanentemente?',
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: '✔ Sí',
            cancelButtonText: "✖ No",
        }).then((result) => {
            if (result.value) {
                $("#DelBtn").prop('disabled', true);
                deleteProduct();
            } else if (result.dismiss) {
                return false;
            }
        });
    });

    function deleteProduct() {
        OpenLoadingModal();
        var url = $('#DelProduct').val();
        $.ajax({
            url: url,
            type: "POST",
            async: true,
            success: succesDeleteUser,
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                CloseLoadingModal();
                $("#DelBtn").prop('disabled', false);
                MensajeError("Ocurrió un error al intentar enviar los datos al servidor");
            }
        });

    }

    function addProductToCart() {
        OpenLoadingModal();
        let url = decodeURIComponent($('#AddToCart').val());
        let urlTemplate = jQuery.validator.format(url);
        url = urlTemplate($("#cantidadInput").val());
        $.ajax({
            url: url,
            type: "POST",
            async: true,
            success: successProductAdded,
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                CloseLoadingModal();
                $("#TopBtn, #BottomBtn").prop('disabled', false);
                MensajeError("Ocurrió un error al intentar añadir el producto");
            }
        });
    }

    function succesDeleteUser(data) {
        CloseLoadingModal();
        $("#DelBtn").prop('disabled', false);
        data = JSON.parse(data);
        console.log(data);
        if (data.success) {
            MensajeExito("Producto Eliminado");
        } else {
            MensajeAdvertencia(data.error);
            console.warn("Ocurrió un error al intentar eliminar el producto");
        }
    }

    function successProductAdded(data) {
        CloseLoadingModal();
        $("#TopBtn, #BottomBtn").prop('disabled', false);
        data = JSON.parse(data);
        console.log(data);
        if (data.success) {
            MensajeExito("Producto Añadido");
        } else {
            MensajeAdvertencia("Ocurrió un error al intentar eliminar el producto");
            console.error("Ocurrió un error al intentar añadir el producto");
        }
    }

});