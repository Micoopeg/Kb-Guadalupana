<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarusuario.aspx.cs" Inherits="KB_Guadalupana.Views.test.usuario.agregarusuario" %>
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
                <h2>Registro usuarios</h2>

                <div class="form-group">
                    <label for="inputdefault">Seleccione Colaborador</label>
                    <select class="form-control" id="colaborador">
                        <option value="0">Opción</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="inputdefault">Seleccione Tipo Usuario</label>
                    <select class="form-control" id="tipus" onfocus="categoria();">
                        <option value="0">Opción</option>
                    </select>
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Usuario</span>
                    </div>
                    <input class="form-control" id="xusuario" type="text" placeholder="Usuario...">
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

                <button type="button" class="btn btn-outline-primary" onclick="operacion(1)">Crear</button>
            </div>
        </div>

        <div class="table-responsive">
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


    <script>


        window.addEventListener("load", function (event) {
            vistausuarios();
            listacolaboradores();
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


        function operacion(valor) {
            var saber = valor
            var items = [

                {
                    operacion: saber,
                    id_col: document.getElementById("colaborador").value,
                    nom_usu: document.getElementById("xusuario").value,
                    usu_pas: document.getElementById("pwd").value,
                    usu_cpa: document.getElementById("pwdc").value,
                    id_cat: document.getElementById("tipus").value,
                    nom_cat: $("#tipus option:selected").text(),
                  

                }
            ];

            things = JSON.stringify({ 'items': items });

            $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: '../../../usuario/operacionusuario',
                data: things,
                success: function (response) {

                    if (response.success) {
                        
                        alert("Listo");
                        vistausuarios();
                        
                    } else {
                        
                        alert(response.ex); 
                    }
                }
            });

        }


        function listacolaboradores() {

            $("#colaborador").empty();
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

                        d += '<option value="' + item.col_id + '">' + item.col_1no + " " + item.col_1ap + '</option>';

                    });
                    $("#colaborador").append(d);
                }

            });

        }



        function categoria() {
            $("#tipus").empty();
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
                url: '../../../usuario/vistatipus',
                data: things,
                success: function (response) {
                    $.each(response, function (i, item) {

                        d += '<option value="' + item.id_cat + '">' + item.cat_nom + '</option>';

                    });
                    $("#tipus").append(d);
                }

            });
        }




    </script>


</body>
</html>



<script>

    $('#menu').load('../barra.aspx');

</script>