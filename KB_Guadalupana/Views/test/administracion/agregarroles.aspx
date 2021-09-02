<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarroles.aspx.cs" Inherits="KB_Guadalupana.Views.test.administracion.agregarroles" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Registro</title>
    
<script src="../../../estatico/js/jquery-1.11.0.min.js"></script>    
<link href="../../../estatico/css/creaciontest.css" rel="stylesheet" />
    
    <link href="../../../estatico/css/barra.css" rel="stylesheet" />
<link href="../../../estatico/css/creaciontest.css" rel="stylesheet" />
    
</head>


    <div id="menu" class="manu"></div>

<body>
    <div class="container main">
        <div class="row">
            <div class="col-md-12">
                <h2>Crear Rol</h2>
                <form action="/empleados00/pruebaajax.php">

                    <div class="form-group">
                        <label for="inputdefault">Área</label>
                        <select class="form-control" id="area">
                            <option value="0">Opción</option>
                        </select>
                    </div>
                    <label for="inputdefault">Nombre Rol</label>
                    <input class="form-control" id="rolnom" type="text" placeholder="Rol...">
                    <div class="form-group">
                        <label for="inputdefault">Observaciones</label>
                        <input class="form-control" id="rolobs" type="text" placeholder="Obs...">
                    </div>
                </form>
                <button type="button" class="btn btn-outline-primary" onclick="operacion(1)">Crear</button>
            </div>
        </div>

        <div class="table-responsive">
            <h2>Listado Roles</h2>
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Observaciones</th>
                        <th scope="col">Operaciones</th>
                    </tr>
                </thead>
                <tbody id="tbodyx">
                </tbody>
            </table>
        </div>
    </div>
</body>
</html>

    

<script>


    function limpiar() {
        $("#tbodyx").empty();
    }


    window.addEventListener("load", function (event) {
        vistaroles();
        area00();
    });


    function operacion(valor) {
        var operacionx = valor;
        var items = [

            {
                operacion: operacionx,
                rol_nom: document.getElementById("rolnom").value,
                rol_obs: document.getElementById("rolobs").value,
                id_are: document.getElementById("area").value,
                nom_are: $("#area option:selected").text(),

            }
        ];

        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../administracion/operacionesrol',
            data: things,
            success: function (response) {
                if (response.success) {
                    // server returns true
                    alert("Listo");
                    limpiar();
                    vistaroles();
                } else {
                    // server returns false
                    //alert(response.ex); // alert error message
                    alert("Hubo un error al operar"); // alert error message
                }
            }
        });

    }

    function vistaroles() {

        var d = '';
        var operacionx = 1;
        var items = [

            {
                operacion: operacionx,
            }
        ];

        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../administracion/vistaroles',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {

                    d +=
                        '<tr>' +
                    '<th scope="row">' + item.id_rol + '</th>' +
                    '<td>' + item.rol_nom + '</td>' +
                    '<td>' + item.rol_obs + '</td>' +
                    '<td>' + "<p><a href='/administracion/editarrol?codigo=" + item.id_rol + "'>Editar</a></p>" + '</td>' +
                     '</tr>';

                });
                $("#tbodyx").append(d);
            }
        });
    }


    function area00() {


        $("#area").empty();
        var d = '<option value="0">Opción</option>';
        var operacionx = 1;
        var items = [
            {
                operacion: operacionx,
            }
        ];

        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../administracion/datosarea',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {

                    d += '<option value="' + item.id_reg + '">' + item.nom_are + '</option>';

                });
                $("#area").append(d);
            }

        });

    }

</script>



<script>


    $('#menu').load('../barra.aspx');

                </script>