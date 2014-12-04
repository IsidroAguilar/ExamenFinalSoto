/// Autor: Roberto Orozco Rodríguez
/// Fecha: 11/09/2014
/// Descripción: Scripts de la vista Index de Home MicoAdm.

$(document).ready(function () {
    // Cargar los datos de los indicadores.
    ObtenerDatos();
});

// Obtener y cargar los datos de los indicadores.
function ObtenerDatos() {
    $.ajax({
        url: $('#ObtenerDatos').attr('data-url'),
        type: 'GET',
        success: function (data) {
            // Consultorios activos.
            $('#consultoriosActivos').hide();
            $('#consultoriosActivos').html(data.datos[0]);
            $('#consultoriosActivos').fadeIn('slow');
        },
        error: function (data) {
            bootbox.alert("Ha ocurrido un error.");
        }
    });
}
