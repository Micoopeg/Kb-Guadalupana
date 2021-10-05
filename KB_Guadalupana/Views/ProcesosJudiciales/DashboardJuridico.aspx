<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardJuridico.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.DashboardJuridico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>DASHBOARD</title>
     <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
        html{
            width:100%;
            height:100%;
                background-color:#34495E;
            color:white;
        }

        .body{
            font-family:"Montserrat";
            background-color:#34495E;
            color:white;
        }

        .general{
            display:flex;
            justify-content:center;
            align-content:center;
            align-items:flex-start;
            width:100%;
            height:100%;
            margin-top:0px;
        }

        .formularioCobros{
            display:flex;
            flex-direction:column;
            width:65%;
        }

        .encabezado{
            padding:20px;
            background-color:lightgray;
            flex-direction:column;
            margin-top:10px;
        }

        .formato{
            display:flex;
            flex-direction:row;
            justify-content: space-between;
        }

          .formato3{
            display:flex;
            flex-direction:column;
            width:45%;
        }
             .formato4{
            display:flex;
            flex-direction:column;
            justify-content: space-between;
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

        .formatoinput2{
            width:98%;
            margin-top:15px;
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

        .formato2{
            display:flex;
            flex-direction:row;
            justify-content: space-around;
        }

        .boton{
            background-color: #69A43C;
            color: white;
            border:0px;
            width:45%;
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
         }
         

         .celda{
             display:flex;
             justify-content:center;
             font-size:15px;
             width:100%;
         }

         .tabla{
             width:100%
         }

      .menu2{
         display:flex;
         flex-direction:row;
         width: 850px;
         height: 460px;
         flex-wrap:wrap;
         align-items:flex-start;
         align-content:flex-start;
         justify-content:center;
     }
     .menu2:after{
         content: "";
          clear: both;
          display: table;
     }
     .boton{
         background-color: #0066BF;
         color: white;
         padding: 10px 10px;
         cursor: pointer;
         margin: 5px;
         width:180px;
         height:150px;
         border:0px;
         font-size:medium;
         display:flex;
         justify-content:center;
         align-content:center;
         flex-wrap:wrap;
     }
     .boton:hover{
         background-color: #69A43C;
     }
     .numero{
         text-align:center;
         font-size:65px;
     }
     .opciones{
         background-color:#435F7A;
         color: white;
         padding: 15px 15px;
         cursor: pointer;
         margin: 15px 30px;
         width:180px;
         height:150px;
         flex-direction:column;
     }
     .items{
         display:flex;
         align-content:center;
         align-items:center;
         justify-content:center;
         height:90%;
         flex-direction:column;
     }
     .area{
         height: 30%;
         width:100%;
         color:white;
         background-color:transparent;
         border: 1px white solid;
     }
    </style>
</head>
       <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
         <div class="general">
            <div class="formularioCobros">
                 <div style="display:flex; justify-content:center;margin-top:40px">
                        <label style="font-size:22px" class="titulos">Cantidad de créditos por etapa</label>
                    </div><br /><br />

                <div class="menu2">
                    <div class="opciones">
                        <div style="display:flex;justify-content:flex-end;align-items:flex-end;align-content:flex-end">
                            <i class='far fa-folder-open' style='font-size:24px'></i>
                        </div>
                        <div class="items">
                            <div class="numero"><b><span class="numero" id="Juridico" runat="server">0</span></b></div>
                            <asp:Button CssClass="area" runat="server" ID="BtnCobros"  Text="Verificación de expedientes" OnClick="BtnCobros_Click"/>
                        </div>
                     </div>

                    <div class="opciones">
                        <div style="display:flex;justify-content:flex-end;align-items:flex-end;align-content:flex-end">
                            <i class='far fa-folder-open' style='font-size:24px'></i>
                        </div>
                        <div class="items">
                            <div class="numero"><b><span class="numero" id="ReporteCant" runat="server">0</span></b></div>
                            <asp:Button CssClass="area" runat="server" ID="Reporte"  Text="Reporte asignaciones" OnClick="Reporte_Click"/>
                        </div>
                     </div>

                    <div class="opciones">
                        <div style="display:flex;justify-content:flex-end;align-items:flex-end;align-content:flex-end">
                            <i class='far fa-folder-open' style='font-size:24px'></i>
                        </div>
                        <div class="items">
                            <div class="numero"><b><span class="numero" id="RequerimientoCant" runat="server">0</span></b></div>
                            <asp:Button CssClass="area" runat="server" ID="RequerimientoPago"  Text="Requerimiento de pago" OnClick="RequerimientoPago_Click"/>
                        </div>
                     </div>

                </div>
            </div>
        </div>

          <script>
           $(document).ready(function () {
               $('.menu').load('MenuPrincipal.aspx');
           });
          </script>
    </form>
</body>
</html>
