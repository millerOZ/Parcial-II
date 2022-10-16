var oTabla = $('#tblPrestamos').DataTable();

$(document).ready(function () {

    $('#tblPrestamos tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

    $("#btnInsertar").click(function () {
        ProcesarComandos("Insertar");
    });
    $("#btnConsultar").click(function () {
        ProcesarComandos("Consultar");
    });
    LlenarComboLibro();

    LlenarGridPrestamos();
    $('#tblPrestamos tbody').on('click', 'tr', function () {
        EditarFila(oTabla.row(this).data());
    });
});
function EditarFila(DatosFila) {
    //Selecciona los datos de la fila seleccionada
    $("#txtNombre").val(DatosFila[0]);
    $("#txtApellidos").val(DatosFila[1]);
    $("#txtEmail").val(DatosFila[2]);
    $("#cboLibro").val(DatosFila[3]);
    $("#txtFechaPrestamo").val(DatosFila[4]);
    $("#txtFechaDevolucion").val(DatosFila[5]);
}

function LlenarComboLibro() {
    LlenarComboControlador("../Comunes/ControladorCombos.ashx", "LIBRO", null, "#cboLibro");
}

function LlenarGridPrestamos() {
    LlenarGridControlador("../Comunes/ControladorGrids.ashx", "TABLAPRESTAMOS", null, "#tblPrestamos");
}

function ProcesarComandos(Comando) {
    var Documento = $("#txtDocumento").val();
    var Nombre = $("#txtNombre").val();
    var Apellidos = $("#txtApellidos").val();
    var Telefono = $("#txtTelefono").val();
    var Email = $("#txtEmail").val();

    var libro = $("#cboLibro").val();

    var FechaPrestamo = $("#txtFechaPrestamo").val();
    var FechaDevolucion = $("#txtFechaDevolucion").val();

    var DatosProducto = {
        Documento: Documento,
        Nombre: Nombre,
        Apellidos: Apellidos,
        Telefono: Telefono,
        Email: Email,
        libro: libro,
        FechaPrestamo: FechaPrestamo,
        FechaDevolucion: FechaDevolucion,
        Comando: Comando
    }
    $.ajax({
        //Función Ajax
        type: "POST",
        url: "../Controladores/BibliotecaControlador.ashx",
        contentType: "json",
        data: JSON.stringify(DatosProducto),
        success: function (RespuestaProducto) {
            //Hay que procesar la respuesta para identificar si hay un error
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(RespuestaProducto);
            LlenarGridPrestamos();
        },
        error: function (RespuestaError) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(RespuestaError);
        }
    });
}