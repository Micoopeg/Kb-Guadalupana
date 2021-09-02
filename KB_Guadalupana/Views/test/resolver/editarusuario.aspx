<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarusuario.aspx.cs" Inherits="KB_Guadalupana.Views.test.resolver.editarusuario" %>
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
                <h2>Editar Usuarios</h2>
                <div class="input-group mb-3">
                    <input class="form-control" id="xusuario" type="text" placeholder="Usuario..." disabled>
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Pass</span>
                    </div>
                    <input type="password" class="form-control" id="pwd" placeholder="Ingrese Contraseña" name="pwd">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Confirm Pass</span>
                    </div>
                    <input type="password" class="form-control" id="pwdc" placeholder="Confirmar Contraseña" name="pwd">
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
                <button type="button" class="btn btn-outline-primary" onclick="actualizar()">Actualizar</button>

            </div>
        </div>
    </div>


</body>
</html>



<script>

  

    window.addEventListener("load", function (event) {
        valiadar();
      

    });



    function datosusuario() {

        $("#sucursaledit").empty();;
        $("#areaedit").empty();
        $("#rolusu").empty();
        var a = '', b = '', c = '', d = '';
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../resolver/llenar',
            data: '*',
            success: function (response) {
                $.each(response, function (i, item) {
                    document.getElementById("xusuario").value = item.nom_usu;
                    document.getElementById("pwd").value = item.usu_pas;
                    document.getElementById("pwdc").value = item.usu_cpa;

                    a += '<option value="' + item.id_suc + '">' + item.nom_suc + '</option>';
                    b += '<option value="' + item.id_are + '">' + item.nom_are + '</option>';
                    c += '<option value="' + item.id_rol + '">' + item.nom_rol + '</option>';

                });
                $("#sucursaledit").append(a);
                $("#areaedit").append(b);
                $("#rolusu").append(c);
            }

        });

    }



    function valiadar() {


        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: "../../../Home/validar",
            data: '',
            success: function (response) {

                if (response.success) {
                    // server returns true
                    
                    datosusuario();


                } else {
                    // server returns false
                    
                    window.location = "../Home/Index";
                }
            }
        });

    }




    function actualizar() {

 
        var items = [

            {
              
                usu_pas: document.getElementById("pwd").value,
                usu_cpa: document.getElementById("pwdc").value,
                nom_are: $("#areaedit option:selected").text(),
                nom_suc: $("#sucursaledit option:selected").text(),
                nom_cat: $("#tipus option:selected").text(),
                nom_rol: $("#rolusu option:selected").text(),
                id_are: document.getElementById("areaedit").value,
                id_suc: document.getElementById("sucursaledit").value,
                id_rol: document.getElementById("rolusu").value,
             

            }
        ];

        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../resolver/actusu',
            data: things,
            success: function (response) {

                if (response.success) {
                    // server returns true
                    alert("Listo");


                } else {
                    // server returns false
                    alert(response.ex); // alert error message
                }
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

    $('#menu').load('../barra1.aspx');

</script>