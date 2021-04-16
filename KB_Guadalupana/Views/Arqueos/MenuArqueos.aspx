<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuArqueos.aspx.cs" Inherits="Modulo_de_arqueos.Views.MenuArqueos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
     body{
            display:flex;
            align-items:center;
            justify-content: center;
            font-family: Arial, Helvetica, sans-serif;
           flex-direction: column;
           margin: 0px;
      }
     .menu{
         display:flex;
         flex-direction:row;
         width: 550px;
         height: 460px;
         flex-wrap:wrap;
         align-items:center;
         align-content:center;
         justify-content:center;
     }
     .menu:after{
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
         width:230px;
         height:200px;
         border:0px;
         font-style:'Montserrat';
         font-size:large;
         display:flex;
         justify-content:center;
         align-content:center;
         flex-wrap:wrap;
     }
     .boton:hover{
         background-color: #69A43C;
     }
     .boton:not(:last-child){
         border-right: none;
     }
       /*menu*/
        .topnav {
          overflow: hidden;
          background-color: #333;
          width:100%;
        }

        .topnav a {
          float: left;
          color: #f2f2f2;
          text-align: center;
          padding: 14px 16px;
          text-decoration: none;
          font-size: 17px;
        }

        .topnav a:hover {
          background-color: #ddd;
          color: black;
        }

        .topnav a.active {
          background-color: #4CAF50;
          color: white;
        }
        .topnav {
          overflow: hidden;
          background-color: #003563;
          width: 100%;
        }

        .topnav a {
          float: left;
          color: #f2f2f2;
          text-align: center;
          padding: 15px 35px;
          text-decoration: none;
          font-size: 17px;
        }
        .topnav a:hover {
          background-color: #B80416;
          color: White;
        }
        .topnav a.active {
              background-color: #69a43c;
              color: white;
        }
        .logo{
            max-width:100px;
        }
        .logoArqueos{
            display:flex;
            justify-content:center;
            align-items:center;
            padding-top:20px;
        }
    </style>
</head>
<body>
    <div class="topnav">
           
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b runat="server" id="NombreUsuario"></b></span>
            <a class="active" href="../Sesion/MenuBarra.aspx" runat="server" id="nombreuser">Inicio</a>    
            <a href="../Sesion/CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
        </div>
    <form id="form1" runat="server">
        <div class="logoArqueos">
             <img src="../../Imagenes/Imagenes_arqueos/SA-Guadalupana-Azul.png" style="top: 0; max-width: 330px; margin:0px; margin-left:0px;" />
        </div>
       
        <div class="menu">
            <asp:Button runat="server" CssClass="boton" OnClick="Cajero_Click" Text="Arqueo Cajero"/>
            <asp:Button runat="server" CssClass="boton" OnClick="CajeroAutomatico_Click" Text="Arqueo Cajero Automático"/>
            <asp:Button runat="server" CssClass="boton" OnClick="Tesoreria_Click" Text="Arqueo Tesorería"/>
            <asp:Button runat="server" CssClass="boton" OnClick="CajaChica_Click" Text="Arqueo Caja Chica"/>
          
        </div>
    </form>
</body>
</html>
