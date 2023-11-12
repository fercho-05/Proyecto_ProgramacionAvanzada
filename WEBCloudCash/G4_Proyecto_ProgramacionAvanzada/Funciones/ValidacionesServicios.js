
$(document).ready(function () {

    $("#tipoServicio").change(function () {
        var seleccion = $(this).val();
        // MOSTRAR DEPENDIENDO DE LA CUENTA
        $("#pagoCelular").toggle(seleccion === "cel");
        $("#pagoInternet").toggle(seleccion === "wifi");
        $("#pagoLuz").toggle(seleccion === "light");
        $("#pagoTV").toggle(seleccion === "tv");
    });
 
});

function predefinirPrefijo() {
    var telefonoInput = document.getElementById("TELEFONO");

    if (!telefonoInput.value.startsWith("+506")) {
        telefonoInput.value = "+506" + telefonoInput.value;
    }
}