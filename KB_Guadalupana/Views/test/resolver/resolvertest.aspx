<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resolvertest.aspx.cs" Inherits="KB_Guadalupana.Views.test.resolver.resolvertest" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Edicion</title>

    <link href="../../../../estatico/css/respuestas.css" rel="stylesheet" />
        
    
    <link href="../../../../estatico/css/creaciontest.css" rel="stylesheet" />
    <link href="../../../../estatico/css/barra.css" rel="stylesheet" />
    <script src="../../../../estatico/js/jquery-1.11.0.min.js"></script>
</head>
    <div id="menu" class="manu"></div>
<body>

    <div class="container main">
        <div class="row">
            <div class="col-12 ">
              <h1>Hola <%=nombre%> - <%=colaborador%> </h1>
                <h3><%=nom_are%> </h3>
                <br />
                <h5>Evaluación #<%=id_eva%> . </h5>
                <h5>Nombre: <%=tit_eva%> </h5>

                <h5>Observaciones:</h5>
                <h5><%=obs_eva%> </h5>
                <h5>Test #: <%=id_tes%> </h5>
                <h5>Nombre: <%=nom_tes%> </h5>
                <h5>Datos del Evaluado:</h5>

                <h2><%=evaluadonombre%> </h2>

                <h5> <%=evaluadoarea%></h5>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12 ">
                <div class="form-group">
                    <h1>Lista de preguntas</h1>

                </div>
            </div>

        </div>

        <div class="container">
            <div class="row">
                <div class="col-12 " id="preguntas">
                    <h6>pregunta</h6>
                </div>
                <h6>Su opinión es importante para nosotros, por favor exprese algún comentario sobre el colaborador evaluado. </h6>
                <textarea class="form-control" rows="3" id="comentario"></textarea>

                <button id="botonx" type="button" class="btn btn-outline-primary" onclick="saber20()">Finalizar</button>
            </div>
        </div>
    </div>


    <!-- datos evaluacion -->
    <input type="radio" name="ideva" value="<%=id_eva%>" hidden>
    <input type="radio" name="titeva" value="<%=tit_eva%>" hidden>
    <input type="radio" name="obseva" value="<%=obs_eva%>" hidden>

    <input type="radio" name="idtes" value="<%=id_tes%>" hidden>
    <input type="radio" name="nomtes" value="<%=nom_tes%>" hidden>



    <!-- datosevaluador-->

    <input type="radio" name="idcol" value="<%=colaborador%>" hidden>
    <input type="radio" name="nomcol" value="<%=nombre%>" hidden>

    <!-- datosevaluado -->
    <input type="radio" name="evanom" value="<%=evaluadonombre%>" hidden>
    <input type="radio" name="evaid" value="<%=evaluadoid%>" hidden>


</body>
</html>



<script>


    var array = [];
    var contador = 0;

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

                    window.location = "../Home/Index/";
                }
            }
        });

    }




    function vistaevaluacion() {


        d = '';
        $("#preguntas").empty();

        //datos evaluacion

        var ideva = $('input:radio[name=ideva]').val();
        var titeva = $('input:radio[name=titeva]').val();
        var obseva = $('input:radio[name=obseva]').val();

        var idtes = $('input:radio[name=idtes]').val();
        var nomtes = $('input:radio[name=nomtes]').val();
        //datos evaluador



        var idcol = $('input:radio[name=idcol]').val();
        var nomcol = $('input:radio[name=nomcol]').val();

        //datos evaluado


        var nomcal = $('input:radio[name=evanom]').val();
        var idcal = $('input:radio[name=evaid]').val();




        var eva = "";
        eva = 1;


        var items = [

            {
                evaluador: eva
            }
        ];


        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../resolver/vistaprueba',
            data: things,
            success: function (response) {

                $.each(response, function (i, item) {
                    contador += 1;
                    var ss = reacciones(item.id_pre);
                    d +=
                        '<div>' +
                        '<label for="' + item.pre_tes + '"><b> ' + contador + ". " + item.id_pre + " " + item.pre_tes + '</b></label>' +
                        '<div class="row">' +
                        '<div class="col-sm-12 text-center">' +
                        '<div class="card">' +
                        '<div class="card-body">' +
                        ss +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '</div>'
                    '</div>';






                    //array.push([item.id_pre, item.pre_tes, contador, eva, sevaluado]);
                    // array.push([item.id_pre, 0, ideva, idtes, nomeva, nomtes, idcol, idusu, nomcol, nomusu, idtes]);
                    array.push([ideva, titeva, idtes, nomtes, idcol, nomcol, idcal, nomcal, item.id_pre, item.pre_tes, 0, "NA"]);

                });
                $("#preguntas").append(d);

            }
        });
    }


    function reacciones(nombre) {

        var res = "";

        for (let i = 1; i < 6; i++) {

            res += '' +
                '<input type="radio" name="' + nombre + '" value="' + i + '">  <img src="/estatico/imagenes/emotes/transparente/' + i + '.png" class="img-fluid" style="max-width:160px;" />'
                ;

        }


        return res;

    }



    function saber20() {

        var pasa = true;

        for (let i = 0; i < contador; i++) {

            array[i][10] = $('input:radio[name=' + array[i][8] + ']:checked').val();
            array[i][11] = document.getElementById("comentario").value;

            if ($('input:radio[name=' + array[i][8] + ']:checked').val() == null) {
                pasa = false;

            }

        }


        if (pasa) {

            if (validaVacio(document.getElementById("comentario").value)) {

                alert("Por favor ingrese sus observaciones.");

            }
            else {

                var items = array;
                things = JSON.stringify(array);

                $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    type: 'POST',
                    url: '../../../resolver/terminar',
                    data: things,
                    success: function (response) {

                        if (response.success) {
                            // server returns true
                            alert("Listo");
                            window.location = "../../resolver/Index";

                        } else {
                            // server returns false
                            alert(response.ex); // alert error message
                            window.location = "../../resolver/Index";
                        }
                    }
                });
            }
        }
        else {
            alert("Responda todas las preguntas");
        }



    }

    function validaVacio(valor) {
        valor = valor.replace("&nbsp;", "");
        valor = valor == undefined ? "" : valor;
        if (!valor || 0 === valor.trim().length) {
            return true;
        }
        else {
            return false;
        }
    }


</script>



<script>

    $('#menu').load('../../barra1.aspx');

</script>