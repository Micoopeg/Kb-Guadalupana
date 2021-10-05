<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpedientesEntregados.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.ExpedientesEntregados" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
       <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script src='https://kit.fontawesome.com/a076d05399.js'></script>
    <title>Expedientes entregados</title>
     <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');

         /*MENU*/
            @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
body{
    margin:0px;
    font-family:"Montserrat";
}

.topnav {
  background-color: #404040;
  overflow: hidden;
  margin:0px;
  border:0px;
}

.topnav a {
  float: left;
  display: block;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

.active {
  background-color: #69A43C;
  color: white;
}

.topnav .icon {
  display: none;
}

.dropdown {
  float: left;
  overflow: hidden;
}

.dropdown .dropbtn {
  font-size: 17px;
  border: none;
  outline: none;
  color: white;
  padding: 14px 16px;
  background-color: inherit;
  font-family: inherit;
  margin: 0;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}

.dropdown-content a {
  float: none;
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
  text-align: left;
}


.topnav a:hover, .dropdown:hover .dropbtn {
  background-color: #3B5C22;
  color: white;
}


.dropdown-content a:hover {
  background-color: #3B5C22;
  color: white;
}

.dropdown:hover .dropdown-content {
  display: block;
}

@media screen and (max-width: 600px) {
  .topnav a:not(:first-child), .dropdown .dropbtn {
    display: none;
  }
  .topnav a.icon {
    float: right;
    display: block;
  }
}

@media screen and (max-width: 600px) {
  .topnav.responsive {position: relative;}
  .topnav.responsive a.icon {
    position: absolute;
    right: 0;
    top: 0;
  }
  .topnav.responsive a {
    float: none;
    display: block;
    text-align: left;
  }
  .topnav.responsive .dropdown {float: none;}
  .topnav.responsive .dropdown-content {position: relative;}
  .topnav.responsive .dropdown .dropbtn {
    display: block;
    width: 100%;
    text-align: left;
  }
}
.logo{
    max-height:25px;
    color: white;
    font-size: 20px;
}
.logo2{
    padding:0px;
    height:48px;
    display:flex;
    align-items:center;
    justify-content:flex-end;
    margin-right:15px;
}


        html{
            width:100%;
            height:100%;
        }

        body{
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
            background-color:#435F7A;
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
            width:30%;
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
             

        .header{ border-top:1px solid white;background:white; color:#333; height:0px; width:100%; font-family: 'Montserrat', cursive; text-align:center}
.menu2{visibility:hidden; height:auto; width:17%; color:white; text-align:left; padding-top:5px; left:0; margin-left:0px;margin-top:125px;background-color:#435F7A; border:2px #4B752B solid;padding-left:13px;}
.wrapper{ height:100px; width:100%; padding-top:20px}
 
.fixed{position:fixed; top:0;visibility:visible}

    </style>
</head>
          <%-- <script>
               $(document).ready(function () {
                   $('.menu').load('MenuPrincipal.aspx');
               });
           </script>--%>
      <div id="menu" runat="server" class="menu"></div>
<body>
           <div class="topnav" id="myTopnav">
              <a href="../Sesion/MenuBarra.aspx" class="active">Inicio</a>

               <div id="Div1" runat="server" class="dropdown">
                <button class="dropbtn" onclick="return false;">Opciones
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">
                   <a href="Dashboard.aspx">Dashboard   <i class="fas fa-chart-bar"></i></a>
                   <a href="ControlIncidente.aspx">Control de Incidente    <i class="fas fa-pen"></i></a>
                   <a href="PendientePagoExtrajudicial.aspx">Pago extrajudicial   <i class="fas fa-coins"></i></a>
                </div>
              </div>
               
                       <div id="Div2" runat="server" class="dropdown">
                        <button class="dropbtn" onclick="return false;">Menú
                          <i class="fa fa-caret-down"></i>
                        </button>
                        <div class="dropdown-content">
                            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="true">
                                <ItemTemplate>
                                    <a id="Opciones" runat="server" href='<%# Eval("Ruta") %>'><%# Eval("Nombre") %></a>
                                </ItemTemplate>
                            </asp:Repeater> 
                       </div>
                      </div>
                  
             
              <%-- <div id="Opciones" runat="server" class="dropdown">
                <button class="dropbtn">Opciones
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">
                   <a href="Dashboard.aspx">Dashboard   <i class="fas fa-chart-bar"></i></a>
                   <a href="ControlIncidente.aspx">Control de Incidente    <i class="fas fa-pen"></i></a>
                   <a href="PendientePagoExtrajudicial.aspx">Pago extrajudicial   <i class="fas fa-coins"></i></a>
                </div>
              </div>

             <div id="MenuCobros" runat="server" class="dropdown">
                <button class="dropbtn">Menú
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">
                  <a id="Cobros" runat="server" href="AsignarProceso.aspx">Creación Expediente de Origen</a>
                  <a id="SonSuficientes" runat="server" href="DiligenciamientoCobros.aspx">Diligenciamiento</a>
                  <a id="ResolucionFav" runat="server" href="PendienteResolucionFavorable.aspx">Gestión para entrega de fondos</a>
       
                </div>
              </div>

             <div id="MenuConta" runat="server" class="dropdown">
                <button class="dropbtn">Menú
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">
                  <a id="Certificacion" runat="server" href="PendienteCertificacion.aspx">Emisión de Certificación Contable</a>
                  <a id="Solicitud" runat="server" href="PendienteSolicitudCheque.aspx">Solicitud de cheque</a>
                </div>
              </div>

             <div id="MenuJuridico" runat="server" class="dropdown">
                <button class="dropbtn">Menú
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">
                  <a id="Expedientes" runat="server" href="CreditosCertificacionJuridico.aspx">Verificación de expedientes</a>
                  <a id="Reporte" runat="server" href="ExpedientesEntregados.aspx">Reporte Asignaciones</a>
                </div>
              </div>

             <div id="MenuAbogado" runat="server" class="dropdown">
                <button class="dropbtn">Menú
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">
                  <a id="Demanda" runat="server" href="PendientePresentacionDemanda.aspx">Presentación de Demanda</a>
                  <a id="Diligenciamiento" runat="server" href="PendienteDiligenciamiento.aspx">Diligenciamiento a medidas precautorias</a>
                  <a id="NotificacionEVA" runat="server" href="PendienteNotificacionApremio.aspx">Notificación al asociado E.V.A.</a>
                  <a id="Facturacion" runat="server" href="PendienteFacturacionAbogado.aspx">Facturación</a>
                  <a id="Notificacion" runat="server" href="PendienteNotificacion.aspx">Notificación al asociado</a>
                 
                </div>
              </div>

             <div id="MenuAsistente" runat="server" class="dropdown">
                <button class="dropbtn">Menú
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">
                  <a id="RequerimientoPago" runat="server" href="PendienteRequerimientoPago.aspx">Requerimiento de pago</a>
                </div>
              </div>--%>


              <a href="../Sesion/CerrarSesion.aspx">Cerrar sesión  <i class="fa fa-power-off"></i></a>
              <a href="javascript:void(0);" class="icon" onclick="myFunction()">&#9776;</a>
               <div class="logo2">
                <span class="logo" id="NombreUsuario" runat="server"><b></b></span>
               </div>
            </div>

    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">
                 <asp:ScriptManager ID="ScriptManager1" runat="server">

                 

                 </asp:ScriptManager>

                <div class="encabezado" id="Opciones" runat="server">
                      <div class="formato2">
                        <asp:Button ID="GenerarNuevoReporte" runat="server" CssClass="boton" Text="Generar Reporte" OnClick="GenerarNuevoReporte_Click"/>
                     </div><br />
                    <div class="formato2">
                        <asp:Button ID="SubirReporte" runat="server" CssClass="boton" Text="Subir Reporte" OnClick="SubirReporte_Click"/>
                     </div><br />
                </div>

                <div class="encabezado" id="AreaReporte" runat ="server">

                     <div style="display:flex; justify-content:center">
                    <label style="font-size:18px" class="titulos">Reporte de las asignaciones realizadas</label>
                 </div><br />

                    <div class="formato">
                         <label class="titulos"><b>Filtrar por abogado</b></label>
                         <asp:DropDownList id="Abogados" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>
                         
                    </div><br /><br />

                     <div class="formato">
                         <label class="titulos"><b>Filtrar por fecha</b></label>
                         <input id="Fecha" runat="server" class="formatoinput" type="date"/>
                    </div><br /><br />

                     <div class="formato2">
                    <asp:Button ID="GenerarReporte" runat="server" CssClass="boton" Text="Generar" OnClick="Generar_Click"/>
                   
                         </div>
                    <br /><br />

                    <div class="formato">
                        <rsweb:ReportViewer ID="ReporteAbogados" runat="server" style="min-width:100%; max-width:100%; width:25%  " ShowBackButton="False" ShowFindControls="False" ShowRefreshButton="False" ShowZoomControl="False" ></rsweb:ReportViewer>
                    </div>

                    <div class="formato2">
                         <asp:Button ID="GuardarReporte" runat="server" CssClass="boton" Text="Guardar" OnClick="GuardarReporte_Click"/>
                    </div>

                </div>

                <div class="encabezado" id="ReporteSubir" runat="server">
                    <div class="formatoTitulo" style="margin-bottom:8px">
                        <label class="titulos"><b>Fecha de entrega física de expedientes</b></label>
                        <label class="titulos" style="margin-left:17%"><b>No. de reporte</b></label>
                    </div>

                       <div class="formato">
                             <input id="FechaEntrega" runat="server" type="date" class="formatoinput"/>
                             <input id="NumReporte" runat="server" type="text" class="formatoinput" readonly="readonly" placeholder="Ingrese número de reporte" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br /><br />

                      
                        <div class="formato">
                        <label class="titulos" style="margin-bottom:15px"><b>Reporte de recibido de expedientes</b></label>
                        <%--<asp:DropDownList id="PTipoDocumento" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>--%>
                       <asp:FileUpload id="FileUpload1" runat="server"></asp:FileUpload>
                    </div><br /><br />

                    <label class="titulos">Observaciones</label>
                          <input id="ObservacionesCredito" runat="server" type="text" class="formatoinput2" placeholder="Ingrese observaciones" maxlength="150" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    <br />
                      <%--      <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 145px">
                        <asp:GridView ID="gridViewDocumentos" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedDocumento" BorderStyle="Solid">
                             <Columns>
                                <asp:TemplateField ControlStyle-CssClass="diseño" Visible="false" HeaderText="No. documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblid" Text='<%# Eval("Codigo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Tipo documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lbltipodoc" Text='<%# Eval("TipoDocumento") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnombredoc" Text='<%# Eval("Nombre") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Ver Documento" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="Black">
                                    <ItemStyle Width="135px"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div>--%>
                </div><br />

                    <div class="formato2">
                        <asp:Button ID="Guardar" runat="server" CssClass="boton" Text="Guardar" OnClick="Guardar_Click"/>
<%--                    <asp:LinkButton ID="guardar" runat="server" CssClass="boton" Text="Guardar" OnClick="Guardar_Click" ></asp:LinkButton>   --%> 
                  </div><br />
            </div>
        </div>

        
     <%--   <script>
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
        </script>--%>

            <script type="text/javascript">
            function myFunction() {
                var x = document.getElementById("myTopnav");
                if (x.className === "topnav") {
                    x.className += " responsive";
                } else {
                    x.className = "topnav";
                }
            }
            </script>
    </form>
   
</body>
       
</html>
