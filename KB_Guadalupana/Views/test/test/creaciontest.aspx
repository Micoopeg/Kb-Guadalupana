<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creaciontest.aspx.cs" Inherits="KB_Guadalupana.Views.test.test.creaciontest" %>
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
                <h2>Creación de Test</h2>
                <form action="/empleados00/pruebaajax.php">
                    <label for="inputdefault">Nombre del test</label>
                    <input class="form-control" id="nombre" type="text" placeholder="Test...">
                    <div class="form-group">
                        <label for="inputdefault">Observaciones</label>
                        <input class="form-control" id="observaciones" type="text" placeholder="Observaciones...">
                    </div>
                </form>
                <button type="button" class="btn btn-outline-primary" onclick="operacion(1)">Crear</button>
            </div>

        </div>



        <div class="table-responsive">
            <h2>Listado de Test</h2>
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Observaciones </th>
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



    window.addEventListener("load", function (event) {

        vistageneral();
        area00();

    });



    function vistageneral() {

        $("#tbodyx").empty();
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
            url: '../../../test/vistastest',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {


                    d +=
                        '<tr>' +
                        '<th scope="row">' + item.id_tes + '</th>' +
                        '<td>' + item.nom_tes + '</td>' +
                        '<td>' + item.obs_tes + '</td>' +
                        '<td>' + "<p><a href='/test/editar?codigo=" + item.id_tes + "'>Editar</a></p>" + '</td>' +
                        '</tr>';

                });
                $("#tbodyx").append(d);
            }

        });
    }


    function operacion(valor) {

        var saber = valor

        var items = [

            {
                operacion: saber,
                nom_tes: document.getElementById("nombre").value,
                obs_tes: document.getElementById("observaciones").value,


            }
        ];

        things = JSON.stringify({ 'items': items });

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../test/operaciontest',
            data: things,
            success: function (response) {

                if (response.success) {
                    // server returns true
                    alert("Listo");
                    vistageneral();
                } else {
                    // server returns false
                    alert(response.ex); // alert error message
                }
            }
        });

    }

</script>

<script>

    $('#menu').load('../barra.aspx');

</script>