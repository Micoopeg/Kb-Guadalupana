<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.MenuPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script src='https://kit.fontawesome.com/a076d05399.js'></script>
    <title>Menu Principal</title>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
body{
    margin:0px;
    font-family:"Montserrat";
}
/* Add a black background color to the top navigation */
.topnav {
  background-color: #404040;
  overflow: hidden;
  margin:0px;
  border:0px;
}

/* Style the links inside the navigation bar */
.topnav a {
  float: left;
  display: block;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

/* Add an active class to highlight the current page */
.active {
  background-color: #69A43C;
  color: white;
}

/* Hide the link that should open and close the topnav on small screens */
.topnav .icon {
  display: none;
}

/* Dropdown container - needed to position the dropdown content */
.dropdown {
  float: left;
  overflow: hidden;
}

/* Style the dropdown button to fit inside the topnav */
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

/* Style the dropdown content (hidden by default) */
.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}

/* Style the links inside the dropdown */
.dropdown-content a {
  float: none;
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
  text-align: left;
}

/* Add a dark background on topnav links and the dropdown button on hover */
.topnav a:hover, .dropdown:hover .dropbtn {
  background-color: #3B5C22;
  color: white;
}

/* Add a grey background to dropdown links on hover */
.dropdown-content a:hover {
  background-color: #3B5C22;
  color: white;
}

/* Show the dropdown menu when the user moves the mouse over the dropdown button */
.dropdown:hover .dropdown-content {
  display: block;
}

/* When the screen is less than 600 pixels wide, hide all links, except for the first one ("Home"). Show the link that contains should open and close the topnav (.icon) */
@media screen and (max-width: 600px) {
  .topnav a:not(:first-child), .dropdown .dropbtn {
    display: none;
  }
  .topnav a.icon {
    float: right;
    display: block;
  }
}

/* The "responsive" class is added to the topnav with JavaScript when the user clicks on the icon. This class makes the topnav look good on small screens (display the links vertically instead of horizontally) */
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
           <div class="topnav" id="myTopnav">
              <a href="../Sesion/MenuBarra.aspx" class="active">Inicio</a>

               <div id="Opciones" runat="server" class="dropdown">
                <button class="dropbtn" onclick="return false;">Opciones
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">
                   <a href="Dashboard.aspx">Dashboard   <i class="fas fa-chart-bar"></i></a>
                   <a href="ControlIncidente.aspx">Control de Incidente    <i class="fas fa-pen"></i></a>
                   <a href="PendientePagoExtrajudicial.aspx">Pago extrajudicial   <i class="fas fa-coins"></i></a>
                </div>
              </div>
               
                       <div id="Menu" runat="server" class="dropdown">
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
