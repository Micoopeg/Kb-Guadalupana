<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vistausuarios.aspx.cs" Inherits="KB_Guadalupana.Views.test.usuario.vistausuarios" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
            <title>Registro</title>
    <script src="../../../estatico/js/jquery-1.11.0.min.js"></script>    
    <link href="../../../estatico/css/creaciontest.css" rel="stylesheet" />
    <link href="../../../estatico/css/barra.css" rel="stylesheet" />
    <link href="../../../estatico/css/creaciontest.css" rel="stylesheet" />
</head>
    <div id="menu" class="manu"></div>
<body>
    <div class="container main">
        <h2>Usuarios Ingresados</h2>
        
        <div class="table-responsive">
            <input class="form-control" id="myInput" type="text" placeholder="Search..">
            <br>

            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Colaborador</th>
                        <th scope="col">Usuario</th>
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
        vistausuarios();
    });

    function vistausuarios() {

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
            url: '../../../usuario/vistausuarios',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {

                    d +=
                        '<tr>' +
                        '<th scope="row">' + item.id_reg + '</th>' +
                        '<td>' + item.id_col + '</td>' +
                        '<td>' + item.nom_usu + '</td>' +
                        '<td>' + "<p><a href='/usuario/editarusuario?codigo=" + item.id_reg + "'>Editar</a></p>" + '</td>' +
                        '</tr>';

                });
                $("#tbodyx").append(d);
            }
        });
    }
</script>


<script>
    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#tbodyx tr").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });
</script>



<script>

    $('#menu').load('../barra.aspx');

</script>