<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteUsuarios.aspx.cs" Inherits="KB_Guadalupana.Views.Procesos.ReporteUsuarios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reporte Usuarios</title>
     <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:"Montserrat";
        }

        .formularioCobros{
            display:flex;
            flex-direction:column;
            width:750px;
            justify-items: center;
            align-content: center;
            justify-content: center;
            align-items: center;
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

        .encabezado{
            padding:25px;
            flex-direction:column;
            margin:15px;
            width: 80%;
        }

        .linea{
            border-bottom: 3px #69A43C solid;
            height:5px;
            width:100%;
        }

         .formatoinput {
            width: 46%;
            border: 0.5px black solid;
            height: 30px;
            display: flex;
            align-items: center;
            align-content:center;
        }

        .formatoinput2{
            width:99%;
            margin-top:8px;
            border: 0.5px black solid;
            height: 30px;
        }

        .formatoinput3 {
            width: 29%;
            border: 0.5px black solid;
            height: 30px;
            display: flex;
            align-items: center;
            align-content:center;
        }

          .formatoinput4 {
            width: 21%;
            border: 0.5px black solid;
            height: 30px;
            display: flex;
            align-items: center;
            align-content:center;
        }

        .formato{
            display:flex;
            flex-direction:row;
            justify-content: space-between;
            width:100%;
        }

        .formato2{
            display:flex;
            flex-direction:row;
            justify-content: space-around;
        }

        .formato3{
            display:flex;
            flex-direction:column;
            width:100%;
        }

         .titulos{
             font-size:13px;
             display:flex;
            align-items:center;
            align-content:center;
         }

        .formatoTitulo{
            display:flex;
            flex-direction:row;
            justify-content: flex-start;
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

         .boton3{
            background-color: #003A6E;
            color: white;
            border:0px;
             width:22%;
             display: flex;
             align-items: center;
            align-content:center;
            justify-content:center;
             height: 25px;
        }

        .boton3:hover {
             background-color: white; 
             color: black; 
             border: 2px solid #003A6E;
            
        }

        .tabla{
            width:100%;
        }

      .tabla td{
            padding:7px;
        }

        .linea2{
            border-left: 1px black solid;
            height:25px;
            width:5px;
        }

        /*MENU*/
        .topnav {
  overflow: hidden;
  background-color: #00325E;
}

.topnav a {
  float: left;
  display: block;
  color: white;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

.topnav a:hover, .dropdown:hover .dropbtn {
  background-color: #ddd;
  color: black;
}

.topnav a.active {
  background-color: #69A43C;
  color: white;
}

.topnav .icon {
  display: none;
}

@media screen and (max-width: 600px) {
  .topnav a:not(:first-child) {display: none;}
  .topnav a.icon {
    float: right;
    display: block;
  }
}

@media screen and (max-width: 600px) {
  .topnav.responsive {position: relative;}
  .topnav.responsive .icon {
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

.logo2{
    padding:0px;
    height:48px;
    display:flex;
    align-items:center;
    justify-content:flex-end;
    margin-right:15px;
    color:white;
}
    </style>
</head>
<body>
    <div style="width:100%">
           <div class="topnav" id="myTopnav">
              <a href="../Sesion/MenuBarra.aspx" class="active">Inicio</a>
               <div id="Procesos" runat="server" class="dropdown">
                <button class="dropbtn">Menú
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">
                  <a id="CrearDocumento" runat="server" href="RegistroDocumento.aspx">Crear Documento</a>
                  <a id="EditarDocumento" runat="server" href="DocumentosAEditar.aspx">Editar Documento</a>
                  <a id="Reporte" runat="server" href="Reporte.aspx">Reporte Documentos</a>
                    <a id="Rusuarios" runat="server" href="ReporteUsuarios.aspx">Reporte Usuarios</a>
                  <a id="Usuarios" runat="server" href="MantenimientoUsuarios.aspx">Usuarios</a>
                  <a id="Areas" runat="server" href="MantenimientoAreas.aspx">Categorías y subcategorías</a>
                </div>
              </div>
              <a href="MenuCategorias2.aspx">Categorías</a>
              <a href="BusquedaGeneral.aspx">Búsqueda  <i class='fas fa-search'></i></a>
              <a href="../Sesion/CerrarSesion.aspx">Cerrar sesión  <i class="fa fa-power-off"></i></a>
              <a href="javascript:void(0);" class="icon" onclick="myFunction()">&#9776;</a>
               <div class="logo2">
                <span class="logo" id="NombreUsuario" runat="server"><b></b></span>
               </div>
            </div>
        </div>
    <form id="form1" runat="server">
       <div class="general">
            <div class="formularioCobros">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                 <div style="display:flex; justify-content:center">
                    <label style="font-size:18px" class="titulos"><b>Reporte de Usuarios</b></label>
                 </div><br />

                 <div class="formato">
                     <rsweb:reportviewer id="FormularioUsuarios2" runat="server" style="min-width: 100%; max-width: 100%; width: 25%" showbackbutton="False" showfindcontrols="False" showrefreshbutton="False" showzoomcontrol="False"></rsweb:reportviewer>
                    </div>

            </div>
        </div>
    </form>
</body>
</html>
