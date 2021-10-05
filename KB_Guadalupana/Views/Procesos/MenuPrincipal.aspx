<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="KB_Guadalupana.Views.Procesos.MenuPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <title>Menu Principal</title>
    <style>
     @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
body {
  margin: 0;
  font-family:"Montserrat";
}

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

</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="topnav" id="myTopnav">
              <a href="./Sesion/MenuBarra.aspx" class="active">Inicio</a>
               <div id="Menu" runat="server" class="dropdown">
                <button class="dropbtn">Menú
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">
                  <a id="CrearDocumento" runat="server" href="RegistroDocumento.aspx">Crear Documento</a>
                  <a id="EditarDocumento" runat="server" href="DocumentosAEditar.aspx">Editar Documento</a>
                </div>
              </div>
              <a href="MenuCategorias.aspx">Categorías</a>
              <a href="BusquedaGeneral.aspx">Categorías</a>
              <a href="../Sesion/CerrarSesion.aspx">Cerrar sesión  <i class="fa fa-power-off"></i></a>
              <a href="javascript:void(0);" class="icon" onclick="myFunction()">&#9776;</a>
               <div class="logo2">
                <span class="logo" id="NombreUsuario" runat="server"><b></b></span>
               </div>
            </div>
        </div>

        <script>
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
