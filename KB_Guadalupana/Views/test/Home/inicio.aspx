<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="KB_Guadalupana.Views.test.Home.inicio" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Registro</title>
    <link href="../../../estatico/css/iniciox.css" rel="stylesheet" />
    
    <link href="../../../estatico/css/barra.css" rel="stylesheet" />
    
<script src="../../../estatico/js/jquery-1.11.0.min.js"></script>    
    <link href="../../../estatico/css/barra.css" rel="stylesheet" />

    
</head>


    <div id="menu" class="manu"></div>

<body>
    <div class="main">

        <div class="row">
            <div class="col-12 text-center ">

                <img src="../../../estatico/imagenes/Logotipo.png" class="img-fluid"/>
            </div>

        </div>


    </div>

   

</body>
</html>

<script>

    window.addEventListener("load", function (event) {
       // location.reload(true);
        vista00();

    });

    function operaciones(valor) {
        var operacionx = valor;
        var items = [

            {

                Id: valor,
                operacion: 1
            }
        ];


        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../test/operacionestest',
            data: things,
            success: function (response) {
                if (response.success) {
                    // server returns true
                    alert("Listo");
                    limpiar()
                    vista00();
                } else {
                    // server returns false
                    //alert(response.ex); // alert error message
                    alert("Hubo un error al operar"); // alert error message
                }
            }
        });
    }

    function limpiar() {
        $("#tbodyx").empty();
    }


    function vista00() {

        var d = '';
        var url = '../../../usuario/vistausu';
        var data = '*';
        $.post(url, data).done(function (data) {

            var cuanto = data.length;

            $.each(data, function (i, item) {
                d +=
                    '<tr>' +
                    '<th scope="row">' + item.id_reg + '</th>' +
                    '<td>' + item.id_col + '</td>' +
                    '<td>' + item.nom_usu + '</td>' +
                '<td>' + "<p><a href='/usuario/editarusuario?codigo=" + item.id_reg + "'>Editar</a></p>" + '</td>' +
                    '</tr>';


            });
            $("#tbodyx").append(d);

        });
    }

</script>


<script>

    $('#menu').load('../barra.aspx');

</script>
