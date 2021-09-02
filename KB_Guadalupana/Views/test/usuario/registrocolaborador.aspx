﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrocolaborador.aspx.cs" Inherits="KB_Guadalupana.Views.test.usuario.registrocolaborador" %>
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
        <div class="col-12 ">
            <h2>Registro de Colaborador</h2>
            <form action="/empleados00/pruebaajax.php">

                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">DPI</span>
                    </div>
                    <input class="form-control" id="dpi" type="text" placeholder="DPI...">
                    <div class="input-group-prepend">
                        <span class="input-group-text">CIF</span>
                    </div>
                    <input class="form-control" id="cif" type="text" placeholder="CIF...">

                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Nombres</span>
                    </div>
                    <input class="form-control" id="p1nombre" type="text" placeholder="Primer Nombre...">
                    <input class="form-control" id="p2nombre" type="text" placeholder="Segundo Nombre...">
                </div>

                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Apellidos</span>
                    </div>
                    <input class="form-control" id="p1apellido" type="text" placeholder="Primer Apellido...">
                    <input class="form-control" id="p2apellido" type="text" placeholder="Segundo Apellido...">

                </div>


                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">teléfono</span>
                    </div>
                    <input class="form-control" id="telefono" type="text" placeholder="Telefono">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Email</span>
                    </div>
                    <input type="email" class="form-control" id="email" placeholder="Enter email" name="email">

                </div>


                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Fecha Nac.</span>
                    </div>
                    <input type="date" id="fecha" name="trip-start" class="form-control"
                           value="2018-07-22"
                           min="1995-01-01" max="2030-12-31">

                </div>
                <div class="form-group">
                    <label for="inputdefault">Seleccione Unidad Operativa</label>
                    <select class="form-control" id="sucursaledit" onfocus="sucursales00();">
                        <option value="0">Opción</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="inputdefault">Seleccione Área</label>
                    <select class="form-control" id="areaedit" onfocus="area00();">
                        <option value="0">Opción</option>
                    </select>
                </div>

                <div class="form-group">
                    <label for="inputdefault">Seleccione Rol</label>
                    <select class="form-control" id="rolusu" onfocus="vistaroles();">
                        <option value="0">Opción</option>
                    </select>
                </div>




            </form>
            <button type="button" class="btn btn-outline-primary" onclick="operacion(1)">Crear</button>
        </div>

    </div>


    <div class="table-responsive">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">DPI</th>
                    <th scope="col">CIF</th>
                    <th scope="col">Nombre</th>
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
    function operacion(valor) {

        var saber = valor
        
        var items = [

            {

                operacion: saber,
                col_dpi: document.getElementById("dpi").value,
                col_cif: document.getElementById("cif").value,
                col_1no: document.getElementById("p1nombre").value,
                col_2no: document.getElementById("p2nombre").value,
                col_1ap: document.getElementById("p1apellido").value,
                col_2ap: document.getElementById("p2apellido").value,
                col_tel: document.getElementById("telefono").value,
                col_ema: document.getElementById("email").value,
                col_nac: document.getElementById("fecha").value,
                nom_are: $("#areaedit option:selected").text(),
                nom_suc: $("#sucursaledit option:selected").text(),
                nom_cat: $("#tipus option:selected").text(),
                nom_rol: $("#rolusu option:selected").text(),
                id_are: document.getElementById("areaedit").value,
                id_suc: document.getElementById("sucursaledit").value,
                id_rol: document.getElementById("rolusu").value

            }
        ];

        things = JSON.stringify({ 'items': items });

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../usuario/operacioncolaborador',
            data: things,
            success: function (response) {

                if (response.success) {
                    // server returns true
                    alert("Listo");
                    listacolaboradores();
                } else {
                    // server returns false
                    alert(response.ex); // alert error message
                }
            }
        });

    }




    window.addEventListener("load", function (event) {
        listacolaboradores();

    });



    function listacolaboradores() {

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
            url: '../../../usuario/vistacolaboador',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {

                    d +=
                        '<tr>' +
                        '<th scope="row">' + item.col_id + '</th>' +
                        '<td>' + item.col_dpi + '</td>' +
                        '<td>' + item.col_cif + '</td>' +
                        '<td>' + item.col_1no + ' ' + item.col_1ap  +'</td>' +
                        '<td>' + "<p><a href='/usuario/editarcolaborador?codigo=" + item.col_id + "'>Editar</a></p>" + '</td>' +
                        '</tr>';

                });
                $("#tbodyx").append(d);
            }

        });

    }



    function vistaroles() {

        $("#rolusu").empty();
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
            url: '../../../administracion/vistaroles',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {

                    d += '<option value="' + item.id_rol + '">' + item.rol_nom + '</option>';

                });
                $("#rolusu").append(d);
            }
        });

    }




    function sucursales00() {

        $("#sucursaledit").empty();
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
            url: '../../../administracion/datossucursal',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {

                    d += '<option value="' + item.id_reg + '">' + item.suc_nom + '</option>';

                });
                $("#sucursaledit").append(d);
            }

        });

    }


    function area00() {

        $("#areaedit").empty();
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
                $("#areaedit").append(d);
            }

        });

    }

</script>



<script>

    $('#menu').load('../barra.aspx');

</script>