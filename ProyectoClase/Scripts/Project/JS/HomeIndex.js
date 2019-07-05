$(document).ready(() => {
    getProductsList();

    function getProductsList() {
        var url = $('#URLProducts').val();
        $.ajax({
            url: url,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: showProductsTable,
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert("error ", data.error, "No se pudieron recuperar los datos de productos");
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
                $("#ProductTable").DataTable({
                    columns: [
                    { data: 'sku' },
                    { data: 'nombre' },
                    { data: 'stock' },
                    { data: 'precio_venta' },
                    { data: 'precio_compra' }
                    ],
                    data: Productos,
                    fixedHeader: true,
                    responsive: true,
                    

                });

                /*
                for (var element of Productos) {
                    addProductoRow(element);
                }*/
            }
        } else {
            alert(data.Mensaje);
        }
    }

    function addProductoRow(productData) {
        let tr = document.createElement("TR");
        let sku = document.createElement("TD");
        let nombre = document.createElement("TD");
        let stock = document.createElement("TD");
        let precioVenta = document.createElement("TD");
        let precioCompra = document.createElement("TD");

        sku.innerHTML = productData.sku;
        nombre.innerHTML = productData.nombre;
        stock.innerHTML = productData.stock;
        precioCompra.innerHTML = productData.precio_compra;
        precioVenta.innerHTML = productData.precio_venta;

        tr.appendChild(sku);
        tr.appendChild(nombre);
        tr.appendChild(stock);
        tr.appendChild(precioVenta);
        tr.appendChild(precioCompra);

        $("#ProductTableBody").append(tr);
      
    }
});
