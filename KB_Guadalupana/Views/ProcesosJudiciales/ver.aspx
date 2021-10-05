<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ver.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.ver" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
            <title>Registro</title>
    <script src="../../../estatico/js/jquery-1.11.0.min.js"></script>    
    <link href="../../../estatico/css/creaciontest.css" rel="stylesheet" />
    <link href="../../../estatico/css/barra.css" rel="stylesheet" />
    <link href="../../../estatico/css/creaciontest.css" rel="stylesheet" />
    <link href="../../../estatico/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../estatico/css/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>

</head>
    <%--<div id="menu" class="menu"></div>--%>
<body>
    <div class="container main">
        <br />
        <h2>Reporte General</h2>
        
        <div class="table-responsive">
            <input class="form-control" id="myInput" type="text" placeholder="Search..">
            <button type="button" class="btn btn-link" id="1" onclick="exportar2()"><img src="../../../estatico/imagenes/excel.png" class="img-fluid" style="max-width:40px; " /></button>
            <br>

            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">1 Agencia</th>
                        <th scope="col">2 Instrumento</th>
                        <th scope="col">3 Línea de crédito</th>
                        <th scope="col">4 Destino</th>
                        <th scope="col">5 Garantía</th>
                        <th scope="col">6 Plazo en meses</th>
                        <th scope="col">7 Estado</th>
                        <th scope="col">8 Tasa Q</th>
                        <th scope="col">9 Fecha solicitud</th>
                        <th scope="col">10 Fecha 1er. desembolso</th>
                        <th scope="col">11 Fecha de acta</th>
                        <th scope="col">12 Fecha Último Desembolso</th>
                        <th scope="col">13 Fecha desembolso</th>
                        <th scope="col">14 Fecha Última Cuota</th>
                        <th scope="col">15 Fecha Acta</th>
                        <th scope="col">16 No. Acta</th>
                        
                        <th scope="col">17 No.Crédito</th>
                        <th scope="col"></th>
                        <th scope="col">19 DPI</th>
                        <th scope="col">20 Codigo Cliente</th>
                        <th scope="col"></th>

                        <th scope="col">22 Nombre Cliente</th>
                        <th scope="col"></th>

                        <th scope="col">24 Monto Original</th>
                        <th scope="col">25 Capital Desembolsado</th>
                        <th scope="col">26 Descripción Documento</th>

                        <th scope="col">27 Nombre Oficial 1</th>
                        <th scope="col">28 Nombre Oficial 2</th>
                        <th scope="col">29 Nombre Oficial 3</th>
                        <th scope="col">30 Saldo Actual</th>
                        <th scope="col">31 Saldo capital</th>


                        <th scope="col">32 No. Incidente</th>
                        <th scope="col"></th>
                        <th scope="col">34 No. Tarjeta</th>
                        <th scope="col">35 No. Cuenta</th>
                        <th scope="col">36 CIF</th>
                        

                        <!-- segunda etapa Emisión de Certificación Contable -->

                        <th scope="col">37 Primer Nombre</th>
                        <th scope="col">38 Segundo Nombre</th>
                        <th scope="col">39 Otro Nombre</th>
                        <th scope="col">40 Apellido Casada</th>
                        <th scope="col">41 Primer Apellido</th>


                        <th scope="col">42 Segundo Apellido</th>
                        <th scope="col">43 Limite</th>
                        <th scope="col">44 Saldo</th>
                        <th scope="col">45 Gastos cobranza</th>
                        <th scope="col">46 Seguro</th>


                        <th scope="col">47 OtrosGastos</th>
                        <th scope="col">48 Comentario</th>
                        <th scope="col">49 Total</th>
                        
                        <th scope="col"></th>
                        <th scope="col"></th>
                        <th scope="col"></th>
                        
                        <th scope="col">53 Incendio</th>
                        <th scope="col">54 Intereses </th>
                        <th scope="col">55 Mora</th>
                        <th scope="col">56 Fecha Estado Cuenta</th>
                        <th scope="col">57</th>
                        <th scope="col">58 No. Registro</th>
                        <th scope="col">59 Contador General</th>
                        
                        
                        <th scope="col"></th>
                        

                        <th scope="col">61 Observaciones</th>
                        <th scope="col">62 No. Colegiado</th>
                        <th scope="col">63 Tipo proceso</th>
                        <th scope="col">64 Fecha asignación</th>
                        <th scope="col">65 Nombre abogado</th>
                        <th scope="col">66 Observaciones </th>

                        <th scope="col">67 Medidas obligatorias</th>
                        <th scope="col">68 Medidas solicitadas</th>
                        <th scope="col">69 Medidas otorgadas</th>
                        <th scope="col">70 Medidas autorizadas</th>
                        
                        <th scope="col">71 Estado demanda</th>
                        <th scope="col">72 Motivo rechazo</th>
                        <th scope="col">73 Fecha notificación</th>
                        <th scope="col"> </th>
                        <th scope="col"> </th>


                        <!-- hasta aca esta bien  !-->

                        <th scope="col">76 No. cheque</th>
                        <th scope="col">77 Fecha emisión</th>
                        <th scope="col">78 Observaciones</th>
                        <th scope="col">79 Monto</th>
                        <th scope="col">80 Nombre banco</th>




                        <!-- diligenciamiento -->   
                        <th scope="col"></th>


                        <th scope="col">82 Lugar trabajo</th>
                        <th scope="col">83 Fecha migración</th>
                        <th scope="col">84 Fecha</th>
                        <th scope="col"></th>
                          <!-- sin datos -->   
                        <th scope="col">86 Transacción voluntaria</th>


                        <th scope="col">87 Fecha presentación</th>

                        <th scope="col">88 Fecha resolución</th>
                        <th scope="col">89 Fecha notificación</th>
                        <th scope="col">90 Observación</th>
                             <!-- sin datos -->   
                        <th scope="col">91 Fecha</th>

                        <th scope="col"> </th>

                        <th scope="col"></th>
                        <th scope="col"></th>




                        <th scope="col">95 Fecha presentación</th>
                             <!-- sin datos -->   
                        <th scope="col">96 Fecha resolución</th>

                        <th scope="col">97 Fecha notificación</th>
                        <th scope="col">98 Observaciones</th>
                        <th scope="col">99 Fecha</th>
                        <th scope="col">100 hay resultado</th>
                             <!-- demanda nuevo  -->   
                        <th scope="col">101 Empresa trabajo</th>

                        <th scope="col">102 Fecha trabajo</th>
                        <th scope="col">103 Fecha presentación</th>
                        <th scope="col">104 Fecha apremio</th>
                        <th scope="col">105 Fecha</th>

                             <!-- sin datos -->   
                        <th scope="col">106 </th>
                        <th scope="col">107 Honorarios</th>
                        <th scope="col">108 Fecha</th>
                        <th scope="col">109 Aplicación pago</th>
                        <th scope="col">110 No. cheque</th>
                        <th scope="col">111 Fecha emisión</th>
                        <th scope="col">112 No. recibo</th>
                        <th scope="col">113 Monto</th>
                             <!-- agrega dos mas  -->   
                        <th scope="col">114 Banco</th>
                        <th scope="col">115 Fecha</th>


        

                        <th scope="col"></th>


                        <th scope="col">117 No. Factura</th>
                        <th scope="col">118 No. Serie</th>
                        <th scope="col">119 Descripción</th>
                        <th scope="col">120 Importe total</th>
                        <th scope="col">121 Fecha emisión</th>
                        <th scope="col">122 Importe caso</th>
                        
                        <th scope="col"></th>
                        
                        <th scope="col">124 Nombre motivo</th>
                        <th scope="col">125 CIF</th>
                        <th scope="col">126 Nombre asociado</th>
                        <th scope="col">127 Nombre cheque</th>
                        <th scope="col">128 Observaciones </th>
                        
                        <th scope="col"></th>
                        <th scope="col"></th>

                        <th scope="col">131 Fecha notificación</th>
                        <th scope="col">132 Actitud demandado</th>
                        <th scope="col">133 Fecha</th>
                        <th scope="col">134 Actitud positiva</th>
                        <th scope="col">135 Fecha sentencia</th>
                        <th scope="col">136 Notificación sentencia</th>
                        <th scope="col">137 Lugar</th>
                        <th scope="col">138 Observaciones</th>
                        
                        <th scope="col">139 pj_observaciones</th>
                        <th scope="col">140 pj_observaciones</th>


                        <th scope="col">141 idpj_sinotificacion</th>
                        <th scope="col">142 Fecha notificación</th>
                        <th scope="col">143 Actitud demandado</th>
                        <th scope="col">144 Fecha</th>
                        <th scope="col">145 Actitud negativa</th>
                        <th scope="col">146 Fecha sentencia</th>
                        <th scope="col">147 Lugar</th>
                        <th scope="col">148 Observaciones</th>
                        <th scope="col">149 </th>
                        <th scope="col">150 </th>
                        
                        <!-- TERCERA ETAPA !-->

                        
                    </tr>
                </thead>
                <tbody id="tbodyx">
                </tbody>
            </table>
        </div>
    </div>


</body>
</html>

<%--<script>
    $(document).ready(function () {
        $('.menu').load('MenuPrincipal.aspx');
    });
</script>--%>

<script>

    window.addEventListener("load", function (event) {
        vistausuarios();
    });

    function vistausuarios() {

        var d = "";

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
            url: '../reportesaida/reporetegeneraldatatable',
            data: things,
            success: function (response) {
                var data = jQuery.parseJSON(response);
                $.each(data, function (i, item) {

                    d +=
                        '<tr>' +
                    '<th scope="row">' + item.d0 + '</th>' +
                        '<th scope="row">' + item.d1 + '</th>' +
                    '<td>' + item.d2 + '</td>' +
                    '<td>' + item.d3 + '</td>' +
                    '<td>' + item.d4 + '</td>' +
                    '<td>' + item.d5 + '</td>' +
                    '<td>' + item.d6 + '</td>' +
                    '<td>' + item.d7 + '</td>' +
                    '<td>' + item.d8 + '</td>' +
                    '<td>' + item.d9 + '</td>' +
                    '<td>' + item.d10 + '</td>' +
                    '<td>' + item.d11 + '</td>' +
                    '<td>' + item.d12 + '</td>' +
                    '<td>' + item.d13 + '</td>' +
                    '<td>' + item.d14 + '</td>' +
                    '<td>' + item.d15 + '</td>' +
                    '<td>' + item.d16 + '</td>' +
                    '<td>' + item.d17 + '</td>' +
                    '<td>' + item.d18 + '</td>' +
                    '<td>' + item.d19 + '</td>' +
                    '<td>' + item.d20 + '</td>' +
                    '<td>' + item.d21 + '</td>' +
                    '<td>' + item.d22 + '</td>' +
                    '<td>' + item.d23 + '</td>' +
                    '<td>' + item.d24 + '</td>' +
                    '<td>' + item.d25 + '</td>' +
                    '<td>' + item.d26 + '</td>' +
                    '<td>' + item.d27 + '</td>' +
                    '<td>' + item.d28 + '</td>' +
                    '<td>' + item.d29 + '</td>' +
                    '<td>' + item.d30 + '</td>' +
                    '<td>' + item.d31 + '</td>' +
                    '<td>' + item.d32 + '</td>' +
                    '<td>' + item.d33 + '</td>' +
                    '<td>' + item.d34 + '</td>' +
                    '<td>' + item.d35 + '</td>' +
                    '<td>' + item.d36 + '</td>' +
                    '<td>' + item.d37 + '</td>' +
                    '<td>' + item.d38 + '</td>' +
                    '<td>' + item.d39 + '</td>' +
                    '<td>' + item.d40 + '</td>' +
                    '<td>' + item.d41 + '</td>' +
                    '<td>' + item.d42 + '</td>' +
                    '<td>' + item.d43 + '</td>' +
                    '<td>' + item.d44 + '</td>' +
                    '<td>' + item.d45 + '</td>' +
                    '<td>' + item.d46 + '</td>' +
                    '<td>' + item.d47 + '</td>' +
                    '<td>' + item.d48 + '</td>' +
                    '<td>' + item.d49 + '</td>' +
                    '<td>' + item.d50 + '</td>' +
                    '<td>' + item.d51 + '</td>' +
                    '<td>' + item.d52 + '</td>' +
                    '<td>' + item.d53 + '</td>' +
                    '<td>' + item.d54 + '</td>' +
                    '<td>' + item.d55 + '</td>' +
                    '<td>' + item.d56 + '</td>' +
                    '<td>' + item.d57 + '</td>' +
                    '<td>' + item.d58 + '</td>' +
                    '<td>' + item.d59 + '</td>' +
                    '<td>' + item.d60 + '</td>' +
                    '<td>' + item.d61 + '</td>' +
                    '<td>' + item.d62 + '</td>' +
                    '<td>' + item.d63 + '</td>' +
                    '<td>' + item.d64 + '</td>' +
                    '<td>' + item.d65 + '</td>' +
                    '<td>' + item.d66 + '</td>' +
                    '<td>' + item.d67 + '</td>' +
                    '<td>' + item.d68 + '</td>' +
                    '<td>' + item.d69 + '</td>' +

                    '<td>' + item.d70 + '</td>' +
                    '<td>' + item.d71 + '</td>' +
                    '<td>' + item.d72 + '</td>' +
                    '<td>' + item.d73 + '</td>' +
                    '<td>' + item.d74 + '</td>' +
                    '<td>' + item.d75 + '</td>' +
                    '<td>' + item.d76 + '</td>' +
                    '<td>' + item.d77 + '</td>' +
                    '<td>' + item.d78 + '</td>' +
                    '<td>' + item.d79 + '</td>' +

                    '<td>' + item.d80 + '</td>' +
                    '<td>' + item.d81 + '</td>' +
                    '<td>' + item.d82 + '</td>' +
                    '<td>' + item.d83 + '</td>' +
                    '<td>' + item.d84 + '</td>' +
                    '<td>' + item.d85 + '</td>' +
                    '<td>' + item.d86 + '</td>' +
                    '<td>' + item.d87 + '</td>' +
                    '<td>' + item.d88 + '</td>' +
                    '<td>' + item.d89 + '</td>' +

                    '<td>' + item.d90 + '</td>' +
                    '<td>' + item.d91 + '</td>' +
                    '<td>' + item.d92 + '</td>' +
                    '<td>' + item.d93 + '</td>' +
                    '<td>' + item.d94 + '</td>' +
                    '<td>' + item.d95 + '</td>' +
                    '<td>' + item.d96 + '</td>' +
                    '<td>' + item.d97 + '</td>' +
                    '<td>' + item.d98 + '</td>' +
                    '<td>' + item.d99 + '</td>' +


                    '<td>' + item.d100 + '</td>' +
                    '<td>' + item.d101 + '</td>' +
                    '<td>' + item.d102 + '</td>' +
                    '<td>' + item.d103 + '</td>' +
                    '<td>' + item.d104 + '</td>' +
                    '<td>' + item.d105 + '</td>' +
                    '<td>' + item.d106 + '</td>' +
                    '<td>' + item.d107 + '</td>' +
                    '<td>' + item.d108 + '</td>' +
                    '<td>' + item.d109 + '</td>' +

                    '<td>' + item.d110 + '</td>' +
                    '<td>' + item.d111 + '</td>' +
                    '<td>' + item.d112 + '</td>' +
                    '<td>' + item.d113 + '</td>' +
                    '<td>' + item.d114 + '</td>' +
                    '<td>' + item.d115 + '</td>' +
                    '<td>' + item.d116 + '</td>' +
                    '<td>' + item.d117 + '</td>' +
                    '<td>' + item.d118 + '</td>' +
                    '<td>' + item.d119 + '</td>' +

                    '<td>' + item.d120 + '</td>' +
                    '<td>' + item.d121 + '</td>' +
                    '<td>' + item.d122 + '</td>' +
                    '<td>' + item.d123 + '</td>' +
                    '<td>' + item.d124 + '</td>' +
                    '<td>' + item.d125 + '</td>' +
                    '<td>' + item.d126 + '</td>' +
                    '<td>' + item.d127 + '</td>' +
                    '<td>' + item.d128 + '</td>' +
                    '<td>' + item.d129 + '</td>' +

                    '<td>' + item.d130 + '</td>' +
                    '<td>' + item.d131 + '</td>' +
                    '<td>' + item.d132 + '</td>' +
                    '<td>' + item.d133 + '</td>' +
                    '<td>' + item.d134 + '</td>' +
                    '<td>' + item.d135 + '</td>' +
                    '<td>' + item.d136 + '</td>' +
                    '<td>' + item.d137 + '</td>' +
                    '<td>' + item.d138 + '</td>' +
                    '<td>' + item.d139 + '</td>' +

                    '<td>' + item.d140 + '</td>' +
                    '<td>' + item.d141 + '</td>' +
                    '<td>' + item.d142 + '</td>' +
                    '<td>' + item.d143 + '</td>' +
                    '<td>' + item.d144 + '</td>' +
                    '<td>' + item.d145 + '</td>' +
                    '<td>' + item.d146 + '</td>' +
                    '<td>' + item.d147 + '</td>' +
                    '<td>' + item.d148 + '</td>' +
                    '<td>' + item.d149 + '</td>' +

                    '<td>' + item.d150 + '</td>' +
                    
                        '</tr>';

                });
                $("#tbodyx").append(d);
            }
        });
    }




    function exportar2() {

        window.location = '/reportesaida/Download2';

    }


</script>


<script>
    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#tbodyx tr").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });
</script>


