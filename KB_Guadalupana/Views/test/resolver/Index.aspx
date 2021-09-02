<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="KB_Guadalupana.Views.test.resolver.Index" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Edicion</title>
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
                <h1>Hola <%=nombre%> </h1>
                <h5> <%=nom_are%></h5>
                <br />
                <h3><%=id_eva%>.  <%=tit_eva%></h3>
                <h6><%=obs_eva%></h6>
                <h4><%=id_tes%>. <%=nom_tes%></h4>

                <h6>Termina <%=fec_fin%></h6>
                

            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12 ">
                <div class="form-group">
                    <label for="nombre">Seleccione Área / Seleccione Colaborador</label>
                    <div class="input-group">
                        <select class="form-control" id="area" onfocus="area00('area');">
                            <option value="0">Opción</option>
                        </select>
                        <span class="input-group-addon">-</span>
                        <select class="form-control" id="colaborador" onfocus="listacolaboradores('colaborador');">
                            <option value="0">Opción</option>
                        </select>

                    </div>
                </div>
            </div>

        </div>
        <button type="button" class="btn btn-outline-primary" onclick="operaciones(1)">Evaluar</button>
    </div>

    <input class="form-check-input" type="radio" name="radio" id="1" value="<%=nombre%>" hidden>
    <input class="form-check-input" type="radio" name="radio" id="2" value="<%=nom_are%>" hidden>
    <input class="form-check-input" type="radio" name="radio" id="3" value="<%=id_eva%>" hidden>
    <input class="form-check-input" type="radio" name="radio" id="4" value="<%=obs_eva%>" hidden>
    <input class="form-check-input" type="radio" name="radio" id="5" value="<%=id_tes%>" hidden>
    <input class="form-check-input" type="radio" name="radio" id="6" value="<%=colaborador%>" hidden>



</body>
</html>



<script>

    window.addEventListener("load", function (event) {

        valiadar();

    });





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
                    vistaevaluacion();


                } else {
                    // server returns false

                    window.location = "../../../Home/Index.aspx";
                }
            }
        });

    }

        function area00(nombre) {

        $("#" + nombre + "").empty();
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
                $("#" + nombre + "").append(d);
            }

        });

    }



    function listacolaboradores(nombre) {

        $("#" + nombre + "").empty();
        var d = '<option value="0">Opción</option>';
        var operacionx = 10;
        var items = [
            {
                operacion: operacionx,
                id_are: document.getElementById("area").value ,
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
                $("#" + nombre + "").append(d);
            }

        });

    }




    function operaciones(valor) {

        var saber = valor

        var items = [

            {
                operacion: saber,
                id_eva: document.getElementById("3").value,
                id_tes: document.getElementById("5").value,
                id_calificador: document.getElementById("6").value,
                id_calificado: document.getElementById("colaborador").value                

            }
        ];

        things = JSON.stringify({ 'items': items });

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../resolver/operar_tes_cal_enc',
            data: things,
            success: function (response) {

                if (response.success) {
                    // server returns true
                    alert(response.ex);
                    window.location = "../resolver/resolvertest/";


                } else {
                    // server returns false
                    alert(response.ex); // alert error message
                }
            }
        });

    }
</script>


<script>

    $('#menu').load('../barra1.aspx');

</script>