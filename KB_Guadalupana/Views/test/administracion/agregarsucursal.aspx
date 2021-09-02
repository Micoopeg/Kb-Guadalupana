<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarsucursal.aspx.cs" Inherits="KB_Guadalupana.Views.test.administracion.agregarsucursal" %>
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
                <h2>Crear Unidad Operativa</h2>
                <form action="/empleados00/pruebaajax.php">
                    <div class="form-group">
                        <label for="">Informacion General</label>
                        <div class="input-group">
                            <input name="remitosucursal" id="nombre" type="text" required class="form-control" placeholder="Nombre">
                            <span class="input-group-addon">-</span>
                            <input name="remitonumero" id="direccion" type="text" required class="form-control" placeholder="Dirección">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <input name="remitosucursal" id="telefono" type="text" required class="form-control" placeholder="Teléfono">
                            <span class="input-group-addon">-</span>
                            <input name="remitonumero" id="email" type="text" required class="form-control" placeholder="Email">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputdefault">Encargado</label>
                        <div class="input-group">
                            <select class="form-control" id="colaboradores">
                                <option value="0">Opción</option>
                            </select>

                        </div>
                    </div>

                </form>
                <button type="button" class="btn btn-outline-primary" onclick="operacion(1)">Crear</button>
            </div>
        </div>

        <div class="table-responsive">
            <h2>Listado Unidades</h2>
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Dirección</th>
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
        vistasucursales();
        listadocolaboradores();
    });


    function operacion(valor) {
        var operacionx = valor;
        var items = [

            {
                operacion: operacionx,
                suc_nom: document.getElementById("nombre").value,
                suc_dir: document.getElementById("direccion").value,
                suc_tel: document.getElementById("telefono").value,
                suc_cor: document.getElementById("email").value,
                id_enc: document.getElementById("colaboradores").value
                
            }
        ];

        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../administracion/operacionsucursal',
            data: things,
            success: function (response) {
                if (response.success) {
                    // server returns true
                    alert("Listo");
                    limpiar();
                    vistasucursales();
                    listadocolaboradores();
                } else {
                    // server returns false
                    //alert(response.ex); // alert error message
                    alert("Hubo un error al operar"); // alert error message
                }
            }
        });

    }

  

    function vistasucursales() {

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
            url: '../../../administracion/datossucursal',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {

                    d +=
                        '<tr>' +
                        '<th scope="row">' + item.id_reg + '</th>' +
                        '<td>' + item.suc_nom + '</td>' +
                        '<td>' + item.suc_dir + '</td>' +
                        '<td>' + "<p><a href='/administracion/editarsucursal?codigo=" + item.id_reg + "'>Editar</a></p>" + '</td>' +
                        '</tr>';

                });
                $("#tbodyx").append(d);
            }

        });

    }


    function listadocolaboradores() {

        $("#colaboradores").empty();
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
                $("#colaboradores").append(d);
            }

        });

    }

    </script>


<script>


    $('#menu').load('../barra.aspx');

</script>

