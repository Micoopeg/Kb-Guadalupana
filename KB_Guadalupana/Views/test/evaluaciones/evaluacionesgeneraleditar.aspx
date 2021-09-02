<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="evaluacionesgeneraleditar.aspx.cs" Inherits="KB_Guadalupana.Views.test.evaluaciones.evaluacionesgeneraleditar" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Envio</title>
    <link href="~/estatico/css/enviareva.css" rel="stylesheet" />
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
            <div class="col-md-12 text-center">

                <h2>General</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h3>Datos de Evaluación</h3>

                <div class="form-group">

                </div>
                <div class="form-group">
                    <div class="input-group">
                        <input class="form-control" id="nombre" type="text" placeholder="Nombre...">
                        <span class="input-group-addon">-</span>
                        <input class="form-control" id="observaciones" type="text" placeholder="Observaciones...">
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputdefault">Seleccione un Test</label>
                    <div class="input-group">
                        <select class="form-control" name="select" id="listtest" onfocus="vistatest('listtest');">
                            <option value="0">Opción</option>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputdefault">Estado</label>
                    <div class="input-group">
                        <select class="form-control" name="select" id="estado" onfocus="estados('estado');">
                            <option value="0">Suspendido</option>
                            <option value="1">Activo</option>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputdefault">Fecha Inicio</label>
                    <div class="input-group">
                        <input type="date" id="fecini" name="trip-start" class="form-control"
                               value=""
                               min="1975-01-01" max="2030-12-31">
                    </div>
                    <label for="inputdefault">Fecha Limite</label>
                    <div class="input-group">
                        <input type="date" id="fecfin" name="trip-start" class="form-control"
                               value=""
                               min="1975-01-01" max="2030-12-31">
                    </div>
                </div>
                <button type="button" class="btn btn-outline-primary" onclick="operaciones(2);">Actualizar</button>
            </div>


        </div>
    </div>

</body>
</html>

<script>



    var vtipeva = 0;
    var vidage = 0;
    var vidare = 0;
    var vidrol = 0;
    var vidcol = 0;
    var vidtes = 0;
    var vfeclim = 0;


    var scodigo = 0;
    const valores = window.location.search;
    const urlParams = new URLSearchParams(valores);
    var xcodigo = urlParams.get('codigo');
    scodigo = xcodigo;

    window.addEventListener("load", function (event) {

        cargardatos();


    });


    function cargardatos() {



        $("#estado").empty();
        $("#listtest").empty();

        var a = '', b = '';

        var operacionx = 2;
        var items = [
            {
                operacion: operacionx,
                id_eva: scodigo,
            }
        ];

        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../evaluaciones/vistageneral',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {

                
                    
                    document.getElementById("nombre").value = item.tit_eva;
                    document.getElementById("observaciones").value = item.obs_eva;
                    document.getElementById("fecini").value = item.fec_ini;
                    document.getElementById("fecfin").value = item.fec_fin;
                    


                    a += '<option value="' + item.estado + '">' + item.nom_est + '</option>';
                    b += '<option value="' + item.id_tes + '">' + item.nom_tes + '</option>';




                });
                $("#estado").append(a);
                $("#listtest").append(b);
            }

        });

    }







    function operaciones(valor) {

        var saber = valor

        var items = [

            {
                operacion: saber,
                id_eva: scodigo,
                id_tes: document.getElementById("listtest").value,
                tit_eva: document.getElementById("nombre").value,
                obs_eva: document.getElementById("observaciones").value,
                fec_ini: document.getElementById("fecini").value,
                fec_fin: document.getElementById("fecfin").value,
                estado: document.getElementById("estado").value,
                nom_tes: $("#listtest option:selected").text(),
                nom_est: $("#estado option:selected").text()

            }
        ];

        things = JSON.stringify({ 'items': items });

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../evaluaciones/operargeneral',
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



    function vistadetalle() {

        var d = '';
        $("#tbodyx").empty();
        var operacionx = 2;
        var items = [
            {
                operacion: operacionx,
                id_eva: scodigo,
            }
        ];

        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../evaluaciones/vistadetalle',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {

                    d +=
                        '<tr>' +
                        '<th scope="row">' + item.id_reg + '</th>' +
                        '<td>' + item.id_usu + '</td>' +
                        '<td>' + item.nom_usu +
                        '<td>' + '<button type="button" class="btn btn-link" id="' + item.id_reg + '" onclick="eliminar(this.id)" ><img src="../estatico/imagenes/eliminar.jpg" class="img-fluid" style="max-width:30px; " /></button>' + '</td>' +
                        '</tr>';

                });
                $("#tbodyx").append(d);
            }

        });
    }








    function vistatest(nombre) {


        $("#" + nombre + "").empty();
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


                    d += '<option value="' + item.id_tes + '">' + item.nom_tes + '</option>';

                });
                $("#" + nombre + "").append(d);
            }

        });
    }




    function estados(nombre) {

        var d = "";
        $("#" + nombre + "").empty();
        d += '<option value=1>' + "Activo"+ '</option> <option value=0>' + "Suspendido" + '</option>';
        $("#" + nombre + "").append(d);
           
    }



</script>



<script>

    $('#menu').load('../barra.aspx');

</script>