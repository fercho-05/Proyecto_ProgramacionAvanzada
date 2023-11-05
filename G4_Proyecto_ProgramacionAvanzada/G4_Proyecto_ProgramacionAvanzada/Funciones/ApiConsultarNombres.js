function ConsultarNombre() {

    let cedula = $("#cedula").val();

    if (cedula.length > 0) {
        $.ajax({
            url: 'https://apis.gometa.org/cedulas/' + cedula,
            type: "GET",
            success: function (data) {
                $("#nombre").val(data.results[0].firstname);
                $("#apellidoUno").val(data.results[0].lastname1);
                $("#apellidoDos").val(data.results[0].lastname2);
            }
        });
    }
    else {
        $("#nombre").val("");
        $("#apellidoUno").val("");
        $("#apellidoDos").val("");
    } 
}