<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuBarra.aspx.cs" Inherits="Login_Web.Control" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <meta http-equiv="X-UA-Compatible" content="IE=edge" />
      <meta name="viewport" content="width=device-width, initial-scale=1" />
      <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <script src='https://kit.fontawesome.com/a076d05399.js'></script>
      <meta name="viewport" content="width=device-width, initial-scale=1" />
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
      <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
      <link rel="stylesheet" href="../../bower_components/bootstrap/dist/css/bootstrap.min.css" />
      <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css" />
      <link rel="stylesheet" href="../../dist/css/MaterialAdminLTE.min.css" />
      <title>Panel de Control</title>
     <link rel="stylesheet" href="../../Diseño/style.css" />
    <style>
             .responsive 
        {
            max-width: 100%;
            height: auto;
        }
        .seguridad{
            flex-direction: row;
            display: flex;
            justify-content: space-between;
            position: absolute;
            align-items: center;
          
        }

        .seguridad:hover {
            color:#fff;
            background-color:#69a43c;
        }
        .opc2{
           display:flex;
            justify-content: flex-start;
            background-color: #003563;
        }

        .opc2:hover {
            color:#fff;
            background-color:#69a43c;
        }

    </style>
</head>
<body>
   <form id="form1" runat="server">
    <div class="area"></div>
       <div class="menu"></div>
         <img src="../../Imagenes/f_logo.png" alt="Nature" class="responsive"  style="width: 455px; position: absolute; top: 46%;left: 40%; margin-top: -75px; margin-left: -75px;" />
   
       <nav class="main-menu">
         <header class="main-header">
            <a href="#" class="logo" style="background-color: #0061B5;">   
            <img src="../../Imagenes/Logo.png" class="logo-lg" style="max-width: 141px;margin-top: -24px;margin-left: 31px;" alt="User Image"/>
            <img src="../../Imagenes/Logo.png" class="logo-mini" style="max-width: 102px;margin-top: -9px;margin-left: -23px;" alt="User Image"/>
        </a>
      </header>
        <br />
        <br />
        <br />
            <ul class ="opc1" runat="server"  onclick="inicio()" style="cursor:pointer;">
                <li>
                    <a href="MenuBarra.aspx" >
                        <i class="fa fa-home fa-2x"></i>
                        <span class="nav-text">
                            Inicio
                        </span>
                    </a>
                </li>
            </ul>
         
           <ul id="Button3" runat="server" class ="opc1">
               <li>
                    <a href="MantenimientoAreas.aspx">
                       <i class="fa fa-info fa-2x"></i>
                        <span class="nav-text">
                            Seguridad
                        </span>
                    </a>
                </li>
            </ul>
  <asp:Repeater ID="RepetirAreas" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
      <ItemTemplate>
        <ul class ="opc1"  runat="server"  disable style="cursor:pointer;">
                <li class="has-subnav">
                    <a >
                       <i class="fa fa-angle-double-right"></i>
                        <span class="nav-text">
                          <asp:Label ID="lblarea" runat="server" Visible="false" Text='<%# Eval("gen_areanombre") %>'></asp:Label>
                           <%# Eval("gen_areanombre") %>
                            <div class="w3-dropdown-hover">
                                <button class="" style="background: transparent;padding: 0px 86px;margin-top: -60px;margin-left: 126px;border: none;display: inline-block;vertical-align: middle;overflow: hidden;text-decoration: none;color: inherit;text-align: center;cursor: pointer;white-space: nowrap;">
                                    <i class="fa fa-caret-down"></i>
                                </button>
                                 <div class="w3-dropdown-content w3-bar-block"  style="color: white; background-color: #69a43c; min-width: 230px;margin-left: 193px;margin-top: -55px;">
                                 

                                     <asp:Repeater ID="repetirapp" runat="server" >
                                         <ItemTemplate>
                                              <asp:Label ID="idapp" runat="server" Visible="false" Text='<%# Eval("codegenapp") %>'></asp:Label>
                                     <asp:LinkButton ID="btnOpciones" OnClick="btnredirigir_Click" class="w3-bar-item w3-button" runat="server" Text='<%# Eval("gen_nombreapp") %>'></asp:LinkButton>
                                  
                                         </ItemTemplate>
                                     </asp:Repeater>
                                     
                                </div>
                            </div> 
                        </span>
                    </a>
                </li>
            </ul>

          </ItemTemplate>
  </asp:Repeater>
           

     


        <ul class="Usuario">
                <li>
                   <a href="#">
                         <i class="fa fa-powder-off fa-2x" style="color:black;font-family: 'Montserrat', sans-serif;font-size: 22px;" ><b runat="server" id="abreuser"></b></i>
                         <span class="nav-text" style="color:black; height: 20px;"><b runat="server" id="nombreuser"></b>
                         </span>
                    </a>
                </li>  
            </ul>
            <ul class="logout" runat="server"  onclick="cerrar_sesion()" style="cursor:pointer;"> 
                <li>
                   <a href="CerrarSesion.aspx">
                        <i class="fa fa-power-off fa-2x"></i>
                        <span class="nav-text" >
                            Cerrar Sesion
                        </span>
                    </a>
                </li>  
            </ul>
        </nav>
          
            <asp:LinkButton ID="cerrarsession" runat="server" OnClick="cerrarsession_Click" ClientIDMode="Static"></asp:LinkButton>
            <asp:LinkButton ID="tickets" runat="server" OnClick="tickets_Click" ClientIDMode="Static"></asp:LinkButton>
            <asp:LinkButton ID="inicio" runat="server" OnClick="inicio_Click" ClientIDMode="Static"></asp:LinkButton>
       </form>

    <script type="text/javascript">

        function cerrar_sesion() {
            document.getElementById('cerrarsession').click();
        }
        function ticket() {
            document.getElementById('tickets').click();
        }
        function inicio() {
            document.getElementById('inicio').click();
        }
    </script>
  </body>
 </html>
