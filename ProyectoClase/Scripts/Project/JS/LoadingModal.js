
async function OpenLoadingModal() {
    $("#loadMe").modal({
        backdrop: "static", //remove ability to close modal with click
        keyboard: false, //remove option to close with keyboard
        show: true //Display loader!
    });
}

function CloseLoadingModal() {
    $("#loadMe").modal("hide");
}

$('#loadMe').on('shown.bs.modal', function () {

    var $me = $(this);

    $me.delay(5000).hide(0, function () {
        if (($("#loadMe").data('bs.modal') || { isShown: false })._isShown) {
            $me.modal('hide');
            MensajeAdvertencia("Se ha excedido el tiempo de espera de la petición");
        }
        
    });
});