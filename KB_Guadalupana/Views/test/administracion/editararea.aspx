﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editararea.aspx.cs" Inherits="KB_Guadalupana.Views.test.administracion.editararea" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <link href="~/estatico/css/barra.css" rel="stylesheet" />

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
                <h2>Editar Area</h2>
                <form action="/empleados00/pruebaajax.php">
                    <label for="inputdefault">Nombre del Area</label>
                    <input class="form-control" id="nombre" type="text" placeholder="Nombre...">
                    <div class="form-group">
                        <label for="inputdefault">Observaciones</label>
                        <input class="form-control" id="observaciones" type="text" placeholder="Observaciones...">
                    </div>
                </form>
                <button type="button" class="btn btn-outline-primary" onclick="operaciones(1)">Actualizar</button>
                <button type="button" class="btn btn-danger" onclick="operaciones(2)">Eliminar</button>
            </div>
        </div>
    </div>

</body>
</html>


<script>


    var scodigo = 0;
    const valores = window.location.search;
    console.log(valores);
    const urlParams = new URLSearchParams(valores);
    var xcodigo = urlParams.get('codigo');
    scodigo = xcodigo;

    var d = '';

    window.addEventListener("load", function (event) {

        cenc();


    });



    function cenc() {

        var d = '';
        var operacionx = 2;
        var items = [
            {
                operacion: operacionx,
                id_reg: scodigo,
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
                    document.getElementById("nombre").value = item.nom_are;
                    document.getElementById("observaciones").value = item.obs_are;
                });


            }
        });


        
    }


    function operaciones(valor) {

        var operacionx = valor;
      
        var items = [

            {
                nom_are: document.getElementById("nombre").value,
                obs_are: document.getElementById("observaciones").value,
                id_reg: scodigo,
                operacion: operacionx
              
            }
        ];

       

        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../administracion/operacionesarea',
            data: things,
            success: function (response) {

                if (response.success) {
                    // server returns true
                    alert("Listo");
                    
                    window.location = "../administracion/creararea/";

                } else {
                    // server returns false
                    //alert(response.ex); // alert error message
                    alert("Hubo un error al operar"); // alert error message
                }
            }
        });

    }


  

</script>



<script>


    $('#menu').load('../barra.aspx');

</script>
