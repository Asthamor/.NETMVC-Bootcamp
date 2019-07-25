$(document).ready(async () => {
    await OpenLoadingModal();

    function getProductsList() {
        var url = $('#URLProducts').val();
        $.ajax({
            url: url,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: ((data) => {
                showProductsTable(data);
                CloseLoadingModal();
            }),
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                CloseLoadingModal();
                MensajeError("error ", data.error, "No se pudieron recuperar los datos de productos");

            }
        });

    }

    function showProductsTable(data) {
        const { Exito, Advertencia, Error } = data;
        const Productos = JSON.parse(data.Productos);

        if (Exito) {
            if ($.isEmptyObject(Productos)) {
                alert(Advertencia);
            } else {
                var tableProductos = $("#ProductTable").DataTable({
                    columns: [
                        { data: 'sku' },
                        { data: 'nombre' },
                        { data: 'stock' },
                        { data: 'precio_venta' },
                        { data: 'precio_compra' }
                    ],
                    columnDefs: [
                        {
                            "targets": 5,
                            "data": null,
                            "defaultContent": "<button class='btn btn-link btnView'><i class='material-icons'>visibility</i></button>"
                        },
                        {
                            "targets": 6,
                            "data": null,
                            "defaultContent": "<button class='btn btn-link btnDelete'><i class='material-icons'>delete</i></button>"
                        },
                    ],
                    data: Productos,
                    fixedHeader: true,
                    responsive: true,
                });

                $('#ProductTable .btnView').on('click', function () {
                    let data = tableProductos.row($(this).parents('tr')).data();
                    let urlTemplate = decodeURIComponent($("#URLViewProductDetail").val());
                    let url = `${urlTemplate}/${data["sku"]}`;
                    window.location.href = url;
                });

                $('#ProductTable .btnDelete').on('click', function () {
                    var rowdata = tableProductos.row($(this).parents('tr')).data();
                    Swal.fire({
                        title: "Eliminar",
                        text: '¿Eliminar producto permanentemente?',
                        type: 'warning',
                        showCancelButton: true,
                        confirmButtonText: '✔ Sí',
                        cancelButtonText: "✖ No",
                    }).then((result) => {
                        if (result.value) {
                            let urlTemplate = decodeURIComponent($("#URLDeleteProduct").val());
                            urlTemplate = jQuery.validator.format(urlTemplate);
                            let url = urlTemplate(rowdata["sku"]);
                            deleteProduct(url);
                        } else if (result.dismiss) {
                            return false;
                        }
                    });
                });
            }
        } else {
    alert(data.Mensaje);
        }
    }


    function succesDeleteUser(data) {
        CloseLoadingModal();
        data = JSON.parse(data);
        console.log(data);
        if (data.success) {
            MensajeExito("Producto Eliminado");
        } else {
            MensajeAdvertencia(data.error);
            console.warn("Ocurrió un error al intentar eliminar el producto");
        }
    }
    


function deleteProduct(url) {
    OpenLoadingModal();
    $.ajax({
        url: url,
        type: "POST",
        async: true,
        success: succesDeleteUser,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            CloseLoadingModal();
            MensajeError("Ocurrió un error al intentar enviar los datos al servidor");
        }
    });

}


getProductsList();

});
