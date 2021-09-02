<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearpregunta.aspx.cs" Inherits="KB_Guadalupana.Views.test.administracion.crearpregunta" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Registro</title>

<script src="../../../estatico/js/jquery-1.11.0.min.js"></script>    
<link href="../../../estatico/css/creaciontest.css" rel="stylesheet" />
    
<link href="../../../estatico/css/completo.css" rel="stylesheet" />

    
</head>


    <div id="menu" class="manu"></div>


<body>
     

    <div class="container main">
        <div class="row">
            <div class="col-md-12">
                <h2>Crear pregunta</h2>
                <form action="/empleados00/pruebaajax.php">
                    <label for="inputdefault">Pregunta</label>
                    <input class="form-control" id="nombre" type="text" placeholder="Pregunta...">
                    <div class="form-group">
                        <label for="inputdefault">Punteo</label>
                        <input class="form-control" id="punteo" type="text" placeholder="punteo...">
                    </div>
                </form>
                <button type="button" class="btn btn-outline-primary" onclick="operacionenc(1,0)">Crear</button>
            </div>
        </div>

        <div class="table-responsive">
            <h2>Listado Preguntas</h2>
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Editar</th>
                        <th scope="col">Eliminar</th>
                    </tr>
                </thead>
                <tbody id="tbodyx">
                </tbody>
            </table>
        </div>
    </div>
    <div id="div1"></div>

</body>
</html>

         <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

<script>
    function operacionenc(valor, id) {

        var saber = valor

        var items = [

            {
                operacion: saber,
                pre_tit: document.getElementById("nombre").value,
                pre_pun: document.getElementById("punteo").value,
                id_preg: id,


            }
        ];

        things = JSON.stringify({ 'items': items });

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '../../../administracion/operacionpregunta',
            data: things,
            success: function (response) {

                if (response.success) {
                    // server returns true
                    alert("Listo");
                    preguntas();
                } else {
                    // server returns false
                    alert(response.ex); // alert error message
                }
            }
        });

    }

   

    function preguntas() {

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
            url: '../../../administracion/vistapregunta',
            data: things,
            success: function (response) {
                $.each(response, function (i, item) {
                    d +=
                        '<tr>' +
                        '<th scope="row">' + item.id_preg + '</th>' +
                        '<td>' + item.pre_tit + '</td>' +
                    '<td>' + "<p><a href='/administracion/editapregunta?codigo=" + item.id_preg + "'>Editar</a></p>" + '</td>' +
                    '<td>' + '<button type="button" class="btn btn-link" id="' + item.id_preg + '" onclick="operacionenc(4,this.id)" ><img src="../../../estatico/imagenes/eliminar.jpg" class="img-fluid" style="max-width:30px; " /></button>' + '</td>' +
                        '</tr>';
                });
                $("#tbodyx").append(d);


            }

        });

    }



    window.addEventListener("load", function (event) {

        
        preguntas();


        $('#menu').load('../barra.aspx');
        
    });


    
    </script>

  