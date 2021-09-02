<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preguntas.aspx.cs" Inherits="KB_Guadalupana.Views.test.resolver.preguntas" %>
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
                <h2>
                    <b>  Evaluando a @ViewBag.snomusu</b>
                </h2>

                <h4>
                    <b>  Evaluador:  @ViewBag.snomcol</b>
                </h4>
                <h6>Observaciones : @ViewBag.sobseva</h6>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-12 " id="preguntas">
                <h6>pregunta</h6>
            </div>
            <button id="botonx" type="button" class="btn btn-outline-primary" onclick="saber20()">Finalizar</button>
        </div>
    </div>

    <input type="radio" name="idcol" value="@ViewBag.sidcol" hidden>
    <input type="radio" name="ideva" value="@ViewBag.sideva" hidden>
    <input type="radio" name="nomeva" value="@ViewBag.snomeva" hidden>
    <input type="radio" name="obseva" value="@ViewBag.sobseva" hidden>
    <input type="radio" name="nomcol" value="@ViewBag.snomcol" hidden>
    <input type="radio" name="nomtes" value="@ViewBag.snomtes" hidden>
    <input type="radio" name="nomusu" value="@ViewBag.snomusu" hidden>
    <input type="radio" name="idusu" value="@ViewBag.sidusu" hidden>
    <input type="radio" name="feclim" value="@ViewBag.sfeclim" hidden>
    <input type="radio" name="idtes" value="@ViewBag.sidtes" hidden>




</body>
</html>



<script>

    var scodigo = 0;
    const valores = window.location.search;
    const urlParams = new URLSearchParams(valores);
    var eva = urlParams.get('evaluacion');
    var sevaluado = urlParams.get('persona');
    var contador = 0;

    var d = '';
    var x = '';
    var array = [];

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

                    window.location = "/Home/Index/";
                }
            }
        });

    }

    function vistaevaluacion() {


        $("#preguntas").empty();
        var idcol = $('input:radio[name=idcol]').val();
        var ideva = $('input:radio[name=ideva]').val();
        var nomeva = $('input:radio[name=nomeva]').val();
        var obseva = $('input:radio[name=obseva]').val();
        var nomcol = $('input:radio[name=nomcol]').val();
        var nomtes = $('input:radio[name=nomtes]').val();
        var nomusu = $('input:radio[name=nomusu]').val();
        var idusu = $('input:radio[name=idusu]').val();
        var idtes = $('input:radio[name=idtes]').val();


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
                    var ss = respuestas(item.id_pre);
                    d +=
                        '<div>' +
                        '<label for="' + item.pre_tes + '"><b> ' + contador + ". " + item.id_pre + " " + item.pre_tes + '</b></label>' +
                        '<br>' +
                        '<p>' +
                        ss +
                        '</p>' +
                        '</div>';

                    //array.push([item.id_pre, item.pre_tes, contador, eva, sevaluado]);
                    array.push([item.id_pre, 0, ideva, idtes, nomeva, nomtes, idcol, idusu, nomcol, nomusu, idtes]);

                });
                $("#preguntas").append(d);

            }
        });
    }


    function respuestas(pregunta) {

        var res = "";
        var items = [

            {
                id_pre: pregunta
            }
        ];

        x = "";
        things = JSON.stringify({ 'items': items });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            async: false,
            url: '../../../resolver/obtenerrespuestas',
            data: things,
            success: function (response) {

                $.each(response, function (i, item) {

                    x +=

                        '<p>' +
                        '<input type="radio" name="' + item.id_pre + '" value="' + item.id_reg + '"> ' + item.res_nom + '<br>' +
                        '</p>';


                });
                res = x;

            }

        });
        return res;

    }


    function saber20() {


        //alert($('input:radio[name=obseva]').val());
        var pasa = true;


        for (let i = 0; i < contador; i++) {

            // alert(array[i][0]);
            //alert(array[i][1]);
            array[i][1] = $('input:radio[name=' + array[i][0] + ']:checked').val();
            //alert($('input:radio[name=' + array[i][0] + ']:checked').val());
            if ($('input:radio[name=' + array[i][0] + ']:checked').val() == null) {
                pasa = false;

            }
        }
        if (pasa) {

            alert("todo bien");
            alert(array[0][0]);
            alert(array[0][1]);
            alert(array[0][2]);
            alert(array[0][3]);
            alert(array[0][4]);
            alert(array[0][5]);
            alert(array[0][6]);
            alert(array[0][7]);
            alert(array[0][8]);
            alert(array[0][9]);
            alert(array[0][10]);
            



        }
        else {

            alert("Responda todas las preguntas");
        }



    }


</script>

<script>
    $('#menu').load('../barra1.aspx');
</script>