
$(document).ready(function () {

    $("#tipoCuenta").change(function () {
        var seleccion = $(this).val();
        // MOSTRAR DEPENDIENDO DE LA CUENTA
        $("#datosCostarricense").toggle(seleccion === "costarricense");
        $("#nombreCompletoInternacional").toggle(seleccion === "internacional");
        $("#montoTransferirContainer").toggle(true); //UNA VEZ SE ELIGE TIPO DE CUENTA SE MUESTRAN CAMPOS ASUNTO Y MONTO
        $("#asuntoContainer").toggle(true);
        $("#asuntoContainer").toggle(true);
        $("#botonTransfiere").toggle(true);
        $("#cuentaIban").toggle(true);
    });

    // VALIDA FORMATO CUENTA IBAN: DEBE EMPEZAR POR DOS LETRAS Y LUEGO HASTA 32 NUMEROS
    
    var valorOriginal; //AQUI SE GUARDAN LAS LETRAS PARA LUEGO SEGUIR CON LSO NUMEROS
     
    $("#ibanInput").on('input', function () {
        var ibanInput = $(this).val();
        var formatoIBAN = /^[A-Za-z]{2}[0-9]+$/;

        if (ibanInput.length <= 2) {
            // SOLO PERMITE DOS LETRAS
            valorOriginal = ibanInput.replace(/[^a-zA-Z]/g, '').toUpperCase();
        } else {
            // LUEGO DE INGRESAR LAS LETRAS DEL PAIS YA SOLO PERMITIR NUMS
            valorOriginal = valorOriginal.substring(0, 2) + ibanInput.substring(2,34).replace(/[^0-9]/g, '');
        }
        $(this).val(valorOriginal);       
    });
});