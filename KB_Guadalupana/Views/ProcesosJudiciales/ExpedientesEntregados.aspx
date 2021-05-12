<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpedientesEntregados.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.ExpedientesEntregados" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Expedientes entregados</title>
     <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');



        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:"Montserrat";
        }

        .general{
            display:flex;
            justify-content:center;
            align-content:center;
            align-items:flex-start;
            width:100%;
            height:auto;
            margin-top:25px;
        }

        .formularioCobros{
            display:flex;
            flex-direction:column;
            width:750px;
        }

        .encabezado{
            padding:25px;
            background-color:lightgray;
            flex-direction:column;
            margin-top:10px;
        }

        .formato{
            display:flex;
            flex-direction:row;
            justify-content: space-between;
            align-items:center;
            width:100%;
        }

          .formato3{
            display:flex;
            flex-direction:column;
            width:100%;
        }

        .formato4{
             display:flex;
            flex-direction:row;
            justify-content: center;
        }

        .formatoinput {
            width: 46%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
        }

            .formatocheckbox {
            width: 25px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 25px;
            border-color: transparent;
            display: flex;
            align-items: flex-start;
            align-content:flex-start;
            justify-content:flex-start;
        }

        .formatoinput2{
            width:98%;
            margin-top:8px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
        }

        .formatoinput3 {
            width: 29%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
        }

           .formatoinput4 {
            width: 21%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
        }

        .formato2{
          display:flex;
            flex-direction:row;
            justify-content: center;
            align-content:center;
            align-items:center;
            width:100%;
        }

        .boton{
            background-color: #69A43C;
            color: white;
            border:0px;
            width:25%;
            margin-top:15px;
            height: 30px;
        }

        .boton:hover {
             background-color: white; 
             color: black; 
             border: 2px solid #69A43C;
        }

         .boton2{
             background-color: white; 
             color: black; 
             border: 2px solid #69A43C;
            width:45%;
            margin-top:15px;
            height: 30px;
        }

        .boton2:hover {
            background-color: #69A43C;
            color: white;
            border:0px;
        }

         .boton3{
            background-color: #003A6E;
            color: white;
            border:0px;
             width:22%;
             display: flex;
             align-items: center;
            align-content:center;
            justify-content:center;
        }

        .boton3:hover {
             background-color: white; 
             color: black; 
             border: 2px solid #003A6E;
            
        }

         .pagina{
            display:flex;
            flex-direction:row;
        }

         .header{
             background-color:#004078;
             color:white;
         }

         .titulos{
             font-size:13px;
             display:flex;
             align-items:center;
         }

        .formatoTitulo{
            display:flex;
            flex-direction:row;
            justify-content: flex-start;
        }

        .tabla{
            width:100%;
        }

        .tabla td{
            padding:7px;
        }

        .formatoinput5{
            width:90%;
            margin-top:8px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
        }

        .formatocheck{
            display:flex;
            justify-content:space-between;
            flex-direction:row;
            width:100%;
            margin-bottom: 5px;
        }

               .formatocheck2{
            display:flex;
            flex-direction:row;
            width:35%;
        }
             

        .header{ border-top:1px solid white;background:white; color:#333; height:0px; width:100%; font-family: 'Lobster', cursive; text-align:center}
.menu2{visibility:hidden; height:auto; width:17%; color:white; text-align:left;color:black; padding-top:5px; left:0; margin-left:0px;margin-top:125px;background-color:lightgray; border:2px #4B752B solid;padding-left:13px;}
.wrapper{ height:100px; width:100%; padding-top:20px}
 
.fixed{position:fixed; top:0;visibility:visible}

    </style>
</head>
    <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="encabezado">

                     <div style="display:flex; justify-content:center">
                    <label style="font-size:18px" class="titulos">Reporte de las asignaciones realizadas</label>
                 </div><br />

                    <div class="formato">
                         <label class="titulos"><b>Filtrar por abogado</b></label>
                         <asp:DropDownList id="Abogados" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                         <asp:Button ID="GenerarReporte" runat="server" CssClass="boton" Text="Generar" OnClick="Generar_Click"/>
                    </div><br /><br />

                    <div class="formato">
                        <rsweb:ReportViewer ID="ReporteAbogados" runat="server" style="min-width:100%; max-width:100%; width:25%  " ShowBackButton="False" ShowFindControls="False" ShowRefreshButton="False" ShowZoomControl="False" ></rsweb:ReportViewer>
                    </div>
                </div>

                <div class="encabezado">
                    <div class="formatoTitulo" style="margin-bottom:8px">
                        <label class="titulos"><b>Fecha de entrega física de expedientes</b></label>
                        <label class="titulos" style="margin-left:17%"><b>No. de reporte</b></label>
                    </div>

                       <div class="formato">
                             <input id="FechaEntrega" runat="server" type="date" class="formatoinput"/>
                             <input id="NumReporte" runat="server" type="text" class="formatoinput" placeholder="Ingrese número de reporte" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br /><br />

                      <label class="titulos" style="margin-bottom:15px"><b>Reporte de recibido de expedientes</b></label>
                      <div class="formato">
                       <asp:FileUpload id="FileUpload1" runat="server"></asp:FileUpload>
                       <asp:Button ID="Agregar" OnClick="agregar_Click" runat="server" Width="30%" Height="30px" CssClass="boton3" Text="Agregar" />
                    </div><br /><br />
                </div><br />
            </div>
        </div>

          <script>
           $(document).ready(function () {
               $('.menu').load('MenuPrincipal.aspx');
           });
          </script>
        <script>
            var texto1 = document.querySelector('#NumReporte');

            texto1.addEventListener('keypress', function (e) {
                // keyCode del punto decimal, también se puede cambiar por la coma que sería el 44
                const decimalCode = 46;
                // chequeo que el keyCode corresponda a las teclas de los números y al punto decimal
                if ((e.keyCode < 48 || e.keyCode > 57) && e.keyCode != decimalCode) {
                    e.preventDefault();
                }
                // chequeo que sólo exista un punto decimal
                else if (e.keyCode == decimalCode && /\./.test(this.value)) {
                    event.preventDefault();
                }
            }, true)
        </script>
    </form>
</body>
</html>
