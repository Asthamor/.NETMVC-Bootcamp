
function MensajeError(mensaje) {
    Swal.fire(
      'Ha ocurrido un error',
      mensaje,
      'error'
   )
}


function MensajeAdvertencia(mensaje) {
    Swal.fire(
      'Advertencia',
      mensaje,
      'warning'
   )
}


function MensajeExito(mensaje) {
    Swal.fire(
      'Completado',
      mensaje,
      'success'
   )
}