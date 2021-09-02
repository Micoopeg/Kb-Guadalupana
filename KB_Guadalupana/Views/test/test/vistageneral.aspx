<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vistageneral.aspx.cs" Inherits="KB_Guadalupana.Views.test.test.vistageneral" %>
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
        <h2>Test Ingresados</h2>
        <div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Observaciones</th>
                        <th scope="col">Editar</th>
                        <th scope="col">Eliminar</th>
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
                    '<td>' + '<button type="button" class="btn btn-link" id="' + item.id_tes + '" onclick="eliminar(this.id)" ><img src="../../../estatico/imagenes/eliminar.jpg" class="img-fluid" style="max-width:30px; " /></button>' + '</td>' +    
                        '</tr>';

                });
                $("#tbodyx").append(d);
            }

        });
    }


    function eliminar(id) {

        var saber = 4
        var items = [

            {
                operacion: saber,
                id_tes: id,
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