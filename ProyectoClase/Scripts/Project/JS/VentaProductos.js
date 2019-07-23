$(document).ready(() => {

    $("#productSearch").autocomplete({
        serviceUrl: '/Producto/SearchProductByName',
        onSelect: function (suggestion) {
            alert('You selected: ' + suggestion.value + ', ' + suggestion.data);
        }
    });


    function getProductsCart() {
        var url = $('#URLCart').val();
        $.ajax({
            url: url,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: showProductsTable,
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                CloseLoadingModal();
                MensajeError("error ", data.error, "No se pudieron recuperar los datos de productos");

            }
        });

    }


    function showProductsTable(data) {
        CloseLoadingModal();
        for (var element in data) {
            console.log(data[element])   
            let tr = document.createElement("tr");
            let tdSku = document.createElement("td");
            tdSku.innerText = data[element].sku;
            tr.append(tdSku);

            let tdNombre = document.createElement("td");
            tdNombre.innerText = data[element].nombre;
            tr.append(tdNombre);

            let tdPrecio = document.createElement("td");
            tdPrecio.innerHTML = data[element].precio_venta;
            tr.append(tdPrecio);

            let tdCantida = document.createElement("td");
            tdCantida.innerHTML = data[element].cantidad;
            tr.append(tdCantida);
            let tdImporte = document.createElement("td");
            tdImporte = data[element].cantidad * data[element].precio_venta;
            tr.append(tdImporte);

            $("#ProductsTableBody").append(tr);
        }



        console.log(data);
    };

    getProductsCart();

})