<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuCategorias.aspx.cs" Inherits="KB_Guadalupana.Views.Procesos.MenuCategorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
<%--<meta name="viewport" content="width=device-width, initial-scale=1"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>--%>
    <title>Menú</title>
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
            width:900px;
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


        .formato3{
            display:flex;
            flex-direction:column;
            width:100%;
        }

        /*MENU PRINCIPAL*/

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

.topnav a:hover, .dropdown3:hover .dropbtn3 {
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
  .topnav.responsive .dropdown3 {float: none;}
  .topnav.responsive .dropdown-content3 {position: relative;}
  .topnav.responsive .dropdown3 .dropbtn3 {
    display: block;
    width: 100%;
    text-align: left;
  }
}

.dropdown-content3 a:hover {
  background-color: #3B5C22;
  color: white;
}

/* Show the dropdown menu when the user moves the mouse over the dropdown button */
.dropdown3:hover .dropdown-content3 {
  display: block;
}

/* When the screen is less than 600 pixels wide, hide all links, except for the first one ("Home"). Show the link that contains should open and close the topnav (.icon) */
@media screen and (max-width: 600px) {
  .topnav a:not(:first-child), .dropdown3 .dropbtn3 {
    display: none;
  }
  .topnav a.icon {
    float: right;
    display: block;
  }
}

.dropdown3 {
  float: left;
  overflow: hidden;
}

/* Style the dropdown button to fit inside the topnav */
.dropdown3 .dropbtn3 {
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
.dropdown-content3 {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}

/* Style the links inside the dropdown */
.dropdown-content3 a {
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

      /*MENU*/
/*      .accordion {
          background-color: #69A43C;
          color: white;
          cursor: pointer;
          padding: 18px;
          width: 100%;
          border: none;
          text-align: left;
          outline: none;
          font-size: 15px;
          transition: 0.4s;
          border-bottom: 0.5px #476E29 solid;
        }

       .accordion2 {
          background-color: #69A43C;
          color: white;
          cursor: pointer;
          padding: 18px;
          width: 100%;
          border: none;
          text-align: left;
          outline: none;
          font-size: 15px;
          transition: 0.4s;
            border-bottom: 0.5px #476E29 solid;
        }

       .accordion2:hover {
          background-color: #476E29; 
        }

        .accordion3 {
          background-color: #0062B8;
          color:white;
          cursor: pointer;
          padding: 18px;
          width: 100%;
          border: none;
          text-align: left;
          outline: none;
          font-size: 15px;
          transition: 0.4s;
           border-bottom: 0.5px #003563 solid;
           border-left: 0.5px #003563 solid;
        }

       .accordion3:hover {
          background-color: #003563; 
        }

        .active, .accordion:hover {
          background-color: #476E29; 
        }

        .panel {
          padding: 0 18px;
          display: none;
          background-color: white;
          overflow: hidden;
          width:100%;
        }

        .panel2 {
          display:flex; 
          flex-wrap:wrap;
          flex-direction:row;
          justify-content:center;
        }*/

        /*MENU2*/
.dropbtn {
  background-color: #04AA6D;
  color: white;
  padding: 16px;
  font-size: 16px;
  border: none;
}

.dropbtn2 {
  background-color: #04AA6D;
  color: white;
  padding: 10px;
  font-size: 15px;
  border: none;
  width:120px;
  height:75px;
  margin:7px;
}

.dropbtn3 {
  background-color: #006DCC;
  color: white;
  padding: 10px;
  font-size: 15px;
  border: none;
  width:120px;
  margin:7px;
}

              .dropbtn2:hover{
background-color: #3e8e41;
              }

.dropbtn3:hover{
background-color: #003563;
              }

.dropdown {
  position: relative;
  display: flex;
   flex-wrap:wrap;
  justify-content:space-between;
}

.dropdown2 {
  position: relative;
  display: flex;
  flex-wrap:wrap;
  justify-content:space-between;
}

.formatoDrop{
    position: relative;
  display: flex;
  flex-wrap:wrap;
  justify-content:space-between;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f1f1f1;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}

.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

.dropdown-content a:hover {background-color: #ddd;}

.dropdown:hover .dropdown-content {display: block;}

.dropdown2:hover .dropdown-content {display: block;}

.dropdown:hover .dropbtn{background-color: #3e8e41;}
.dropdown2:hover .dropbtn2{background-color: #3e8e41;}

        * {box-sizing: border-box}
        body {font-family: "Lato", sans-serif;}

        /* Style the tab */
        .tab {
          float: left;
          border: 1px solid #ccc;
          background-color: #f1f1f1;
          width: 40%;
          height: auto;
        }

        /* Style the buttons inside the tab */
        .tab button {
          display: block;
          background-color: inherit;
          color: black;
          padding: 13px 8px;
          width: 100%;
          border: none;
          outline: none;
          text-align: left;
          cursor: pointer;
          font-size: 17px;
        }

        /* Change background color of buttons on hover */
        .tab button:hover {
          background-color: #ddd;
        }

        /* Create an active/current "tab button" class */
        .tab button.active {
          background-color: #ccc;
        }

        /* Style the tab content */
        .tabcontent {
          float: left;
          padding: 0px 12px;
          border: 1px solid #ccc;
          width: 60%;
          border-left: none;
          height: auto;
          display: flex;
          flex-wrap:wrap;
          flex-direction:row;
        }

        /* Clear floats after the tab */
        .clearfix::after {
          content: "";
          clear: both;
          display: table;
        }

        .estilo{
            display:flex;
            flex-wrap:wrap;
            flex-direction:row;
            justify-content:space-between;
        }
    </style>
</head>
<body>
     <div class="topnav" id="myTopnav">
              <a href="../Sesion/MenuBarra.aspx" class="active">Inicio</a>

               <div id="Menu" runat="server" class="dropdown3">
                <button class="dropbtn3">Menú
                  <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content3">
                  <a id="CrearDocumento" runat="server" href="RegistroDocumento.aspx">Crear Documento</a>
                  <a id="EditarDocumento" runat="server" href="DocumentosAEditar.aspx">Editar Documento</a>
                  <a id="Reporte" runat="server" href="Reporte.aspx">Reporte</a>
                </div>
              </div>
              <a href="MenuCategorias.aspx">Categorías</a>
              <a href="BusquedaGeneral.aspx">Búsqueda</a>
              <a href="../Sesion/CerrarSesion.aspx">Cerrar sesión  <i class="fa fa-power-off"></i></a>
              <a href="javascript:void(0);" class="icon" onclick="myFunction()">&#9776;</a>
               <div class="logo2">
                <span class="logo" id="NombreUsuario" runat="server"><b></b></span>
               </div>
            </div>


    <form id="form1" runat="server">
            <div class="general">

        <div class="formularioCobros">
              <div style="display:flex; justify-content:center">
                    <label style="font-size:20px" class="titulos"><b>Gestor Documental</b></label>
                 </div><br /><br />

            <div style="display:flex;flex-direction:row; width: 100%;">
          

           <%--  <a class="accordion2" onclick="redirigir5()" runat="server">Auditoría Interna</a>

            <a class="accordion2" onclick="redirigir2()" runat="server">Comisión de Vigilancia</a>

            <a class="accordion2" onclick="redirigir4()" runat="server">Consejo de Administración</a>

            <a class="accordion" runat="server">Gerencia Administrativa</a>
                    <div class="panel">
                        <div class="panel2">
                            <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="formato3">
                                    <asp:Button ID="subcategoria1" CssClass="accordion3" runat="server" OnClick="subcategoria1_Click" Text='<%# Eval("Subcategoria") %>'/>
                                </div><br />
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                    </div>

                   <a class="accordion" runat="server">Gerencia de Negocios y Mercadeo</a>
                    <div class="panel" >
                        <div class="panel2">
                            <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <div class="formato3">
                                      <asp:Button ID="subcategoria2" CssClass="accordion3" runat="server" OnClick="subcategoria2_Click" Text='<%# Eval("Subcategoria") %>'/>
                                </div><br />
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                    </div>

                <a class="accordion" runat="server">Gerencia Financiera</a>
                        <div class="panel">
                            <div class="panel2">
                                <asp:Repeater ID="Repeater4" runat="server">
                                <ItemTemplate>
                                    <div class="formato3">
                                         <asp:Button ID="subcategoria4" CssClass="accordion3" runat="server" OnClick="subcategoria4_Click" Text='<%# Eval("Subcategoria") %>'/>
                                    </div><br />
                                </ItemTemplate>
                            </asp:Repeater>
                            </div>
                        </div>

                    <a class="accordion" runat="server">Gerencia General</a>
                        <div class="panel">
                            <div class="panel2">
                                <asp:Repeater ID="Repeater5" runat="server">
                                <ItemTemplate>
                                    <div class="formato3">
                                         <asp:Button ID="subcategoria5" CssClass="accordion3" runat="server" OnClick="subcategoria5_Click" Text='<%# Eval("Subcategoria") %>'/>
                                    </div><br />
                                </ItemTemplate>
                            </asp:Repeater>
                            </div>
                        </div>

                     <a class="accordion" runat="server">Gerencia Jurídica</a>
                    <div class="panel">
                        <div class="panel2">
                            <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <div class="formato3">
                                     <asp:Button ID="subcategoria3" CssClass="accordion3" runat="server" OnClick="subcategoria3_Click" Text='<%# Eval("Subcategoria") %>'/>
                                </div><br />
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                    </div>


                    <a class="accordion2" onclick="redirigir()" runat="server">Unidad de Cumplimiento</a>--%>
          
                    <%--<div class="tab">
                          <asp:Repeater ID="RepeaterCategoria" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <div class="formato3">
                                    <button id="Categorias" runat="server" class="tablinks" onmouseover="openCity(event, 'AuditoriaInterna')" ><%# Eval("Categoria") %></button>
                                </div><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>--%>

                   <div class="tab">
                        <div class="formato3">
                            <button id="Categorias" runat="server" class="tablinks" onmouseover="openCity(event, '<%%>')" >Auditoría Interna</button>
                            <button id="Button1" runat="server" class="tablinks" onmouseover="openCity(event, 'ComisionVigilancia')" >Comisión de Vigilancia</button>
                            <button id="Button2" runat="server" class="tablinks" onmouseover="openCity(event, 'ConsejoAdministracion')" >Consejo de Administración</button>
                            <button id="Button3" runat="server" class="tablinks" onmouseover="openCity(event, 'GrenciaAdministrativa')" >Gerencia Administrativa</button>
                            <button id="Button4" runat="server" class="tablinks" onmouseover="openCity(event, 'GrenciaNegocios')" >Gerencia de Negocios y Mercadeo</button>
                            <button id="Button5" runat="server" class="tablinks" onmouseover="openCity(event, 'GerenciaFinanciera')" >Grencia Financiera</button>
                            <button id="Button6" runat="server" class="tablinks" onmouseover="openCity(event, 'GerenciaGeneral')" >Gerencia General</button>
                            <button id="Button7" runat="server" class="tablinks" onmouseover="openCity(event, 'GerenciaJuridica')" >Gerencia Jurídica</button>
                            <button id="Button8" runat="server" class="tablinks" onmouseover="openCity(event, 'UnidadCumplimiento')" >Unidad de Cumplimiento</button>
                        </div><br />
                    </div>

               <div id="AuditoriaInterna" class="tabcontent">
                   <h3>Auditoria Interna</h3>
                   <div class="dropdown2">
                   <asp:button runat="server" class="dropbtn3" Text="Política" OnClick="Button1_Click"></asp:button>
                  <asp:button runat="server" class="dropbtn3" Text="Reglamento" OnClick="Button1_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Manual" OnClick="Button1_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Instructivo" OnClick="Button1_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Protocolo" OnClick="Button1_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Procedimiento" OnClick="Button1_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Normativo" OnClick="Button1_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Guía" OnClick="Button1_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Formato" OnClick="Button1_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Ley" OnClick="Button1_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Estatutos" OnClick="Button1_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Código" OnClick="Button1_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Otro" OnClick="Button1_Click"></asp:button>
            </div>
                 </div>

                 <div id="ComisionVigilancia" class="tabcontent">
                     <h3>Comisión de Vigilancia</h3>
                   <div class="dropdown2">
                   <asp:button runat="server" class="dropbtn3" Text="Política" OnClick="Button2_Click"></asp:button>
                  <asp:button runat="server" class="dropbtn3" Text="Reglamento" OnClick="Button2_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Manual" OnClick="Button2_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Instructivo" OnClick="Button2_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Protocolo" OnClick="Button2_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Procedimiento" OnClick="Button2_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Normativo" OnClick="Button2_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Guía" OnClick="Button2_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Formato" OnClick="Button2_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Ley" OnClick="Button2_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Estatutos" OnClick="Button2_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Código" OnClick="Button2_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Otro" OnClick="Button2_Click"></asp:button>
                 </div>
                     </div>
               
                  <div id="ConsejoAdministracion" class="tabcontent">
                   <h3>Consejo de Adminsitración</h3>
                   <div class="dropdown2">
                   <asp:button runat="server" class="dropbtn3" Text="Política" OnClick="Button3_Click"></asp:button>
                  <asp:button runat="server" class="dropbtn3" Text="Reglamento" OnClick="Button3_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Manual" OnClick="Button3_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Instructivo" OnClick="Button3_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Protocolo" OnClick="Button3_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Procedimiento" OnClick="Button3_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Normativo" OnClick="Button3_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Guía" OnClick="Button3_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Formato" OnClick="Button3_Click"></asp:button>
                        <asp:button runat="server" class="dropbtn3" Text="Ley" OnClick="Button3_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Estatutos" OnClick="Button3_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Código" OnClick="Button3_Click"></asp:button>
                       <asp:button runat="server" class="dropbtn3" Text="Otro" OnClick="Button3_Click"></asp:button>
                 </div>
                      </div>

                   <div id="GrenciaAdministrativa" class="tabcontent">
                       <h3>Gerencia Administrativa</h3>
                       <h4>Subcategorías</h4>
                        <div class="formatoDrop">
                            <div class="dropdown">
                              <button class="dropbtn2">Capacitación y Desarrollo</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn3" Text="Manual" OnClick="Button4_Click"></asp:button>
                               <asp:button runat="server" class="dropbtn3" Text="Instructivo" OnClick="Button4_Click"></asp:button>
                                <asp:button runat="server" class="dropbtn3" Text="Protocolo" OnClick="Button4_Click"></asp:button>
                                <asp:button runat="server" class="dropbtn3" Text="Procedimiento" OnClick="Button4_Click"></asp:button>
                                <asp:button runat="server" class="dropbtn3" Text="Normativo" OnClick="Button4_Click"></asp:button>
                                <asp:button runat="server" class="dropbtn3" Text="Guía" OnClick="Button4_Click"></asp:button>
                                <asp:button runat="server" class="dropbtn3" Text="Formato" OnClick="Button4_Click"></asp:button>
                                <asp:button runat="server" class="dropbtn3" Text="Ley" OnClick="Button4_Click"></asp:button>
                               <asp:button runat="server" class="dropbtn3" Text="Estatutos" OnClick="Button4_Click"></asp:button>
                               <asp:button runat="server" class="dropbtn3" Text="Código" OnClick="Button4_Click"></asp:button>
                               <asp:button runat="server" class="dropbtn3" Text="Otro" OnClick="Button4_Click"></asp:button>
                              </div>
                            </div>

                            <div class="dropdown">
                                  <button class="dropbtn2">Mantenimiento e Infraestructura</button>
                                  <div class="dropdown-content">
                                    <asp:button runat="server" class="dropbtn3" Text="Manual" OnClick="Button5_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Instructivo" OnClick="Button5_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Protocolo" OnClick="Button5_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Procedimiento" OnClick="Button5_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Normativo" OnClick="Button5_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Guía" OnClick="Button5_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Formato" OnClick="Button5_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Ley" OnClick="Button5_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Estatutos" OnClick="Button5_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Código" OnClick="Button5_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Otro" OnClick="Button5_Click"></asp:button>
                                  </div>
                                </div>

                            <div class="dropdown">
                                  <button class="dropbtn2">Procesos y aseguramiento de calidad</button>
                                  <div class="dropdown-content">
                                    <asp:button runat="server" class="dropbtn3" Text="Manual" OnClick="Button6_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Instructivo" OnClick="Button6_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Protocolo" OnClick="Button6_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Procedimiento" OnClick="Button6_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Normativo" OnClick="Button6_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Guía" OnClick="Button6_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Formato" OnClick="Button6_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Ley" OnClick="Button6_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Estatutos" OnClick="Button6_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Código" OnClick="Button6_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Otro" OnClick="Button6_Click"></asp:button>
                                  </div>
                                </div>

                            <div class="dropdown">
                                  <button class="dropbtn2">Recepción</button>
                                  <div class="dropdown-content">
                                    <asp:button runat="server" class="dropbtn3" Text="Manual" OnClick="Button7_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Instructivo" OnClick="Button7_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Protocolo" OnClick="Button7_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Procedimiento" OnClick="Button7_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Normativo" OnClick="Button7_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Guía" OnClick="Button7_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Formato" OnClick="Button7_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Ley" OnClick="Button7_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Estatutos" OnClick="Button7_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Código" OnClick="Button7_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Otro" OnClick="Button7_Click"></asp:button>
                                  </div>
                                </div>

                            <div class="dropdown">
                                  <button class="dropbtn2">Seguridad</button>
                                  <div class="dropdown-content">
                                    <asp:button runat="server" class="dropbtn3" Text="Manual" OnClick="Button8_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Instructivo" OnClick="Button8_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Protocolo" OnClick="Button8_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Procedimiento" OnClick="Button8_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Normativo" OnClick="Button8_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Guía" OnClick="Button8_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Formato" OnClick="Button8_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Ley" OnClick="Button8_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Estatutos" OnClick="Button8_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Código" OnClick="Button8_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Otro" OnClick="Button8_Click"></asp:button>
                                  </div>
                                </div>

                            <div class="dropdown">
                                  <button class="dropbtn2">Talento Humano</button>
                                  <div class="dropdown-content">
                                    <asp:button runat="server" class="dropbtn3" Text="Manual" OnClick="Button9_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Instructivo" OnClick="Button9_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Protocolo" OnClick="Button9_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Procedimiento" OnClick="Button9_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Normativo" OnClick="Button9_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Guía" OnClick="Button9_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Formato" OnClick="Button9_Click"></asp:button>
                                    <asp:button runat="server" class="dropbtn3" Text="Ley" OnClick="Button9_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Estatutos" OnClick="Button9_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Código" OnClick="Button9_Click"></asp:button>
                                   <asp:button runat="server" class="dropbtn3" Text="Otro" OnClick="Button9_Click"></asp:button>
                                  </div>
                                </div>
                       </div>
                 </div>

               
                <div id="GrenciaNegocios" class="tabcontent">
                     <h3>Gerencia de Negocios y Mercadeo</h3>
                       <h4>Subcategorías</h4>
                           <div class="dropdown">
                              <button class="dropbtn2">Agencias</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                      <div class="dropdown">
                              <button class="dropbtn2">Mercadeo y Promoción</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                    <div class="dropdown">
                              <button class="dropbtn2">QA</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                    <div class="dropdown">
                              <button class="dropbtn2">Ventas</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                 </div>

                 <div id="GerenciaFinanciera" class="tabcontent">
                    <h3>Gerencia Financiera</h3>
                       <h4>Subcategorías</h4>
                     <div class="estilo">
                           <div class="dropdown">
                              <button class="dropbtn2">Contabilidad</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>
                         </div>
                      <div class="dropdown">
                              <button class="dropbtn2">Nómina y Prestaciones</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                      <div class="dropdown">
                              <button class="dropbtn2">Seguros</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                      <div class="dropdown">
                              <button class="dropbtn2">Tesorería</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>
                 </div>

                <div id="GerenciaGeneral" class="tabcontent">
                    
                  <h3>Gerencia General</h3>
                       <h4>Subcategorías</h4>
                           <div class="dropdown">
                              <button class="dropbtn2">Gerencia General</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                    <div class="dropdown">
                              <button class="dropbtn2">Informática</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>
                 </div>

               <div id="GerenciaJuridica" class="tabcontent">
                   <h3>Gerencia Jurídica</h3>
                       <h4>Subcategorías</h4>
                           <div class="dropdown">
                              <button class="dropbtn2">Archivo</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                    <div class="dropdown">
                              <button class="dropbtn2">Cartera Depurada</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                    <div class="dropdown">
                              <button class="dropbtn2">Cobros</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                    <div class="dropdown">
                              <button class="dropbtn2">Créditos</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>

                    <div class="dropdown">
                              <button class="dropbtn2">Jurídico</button>
                              <div class="dropdown-content">
                                <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                                <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                               <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                              </div>
                            </div>
                 </div>

                  <div id="UnidadCumplimiento" class="tabcontent">
                  <h3>Unidad de Cumplimiento</h3>
                   <div class="dropdown2">
                   <asp:button runat="server" class="dropbtn2" Text="Política"></asp:button>
                  <asp:button runat="server" class="dropbtn2" Text="Reglamento"></asp:button>
                       <asp:button runat="server" class="dropbtn2" Text="Manual"></asp:button>
                       <asp:button runat="server" class="dropbtn2" Text="Instructivo"></asp:button>
                        <asp:button runat="server" class="dropbtn2" Text="Protocolo"></asp:button>
                        <asp:button runat="server" class="dropbtn2" Text="Procedimiento"></asp:button>
                        <asp:button runat="server" class="dropbtn2" Text="Normativo"></asp:button>
                        <asp:button runat="server" class="dropbtn2" Text="Guía"></asp:button>
                        <asp:button runat="server" class="dropbtn2" Text="Formato"></asp:button>
                        <asp:button runat="server" class="dropbtn2" Text="Ley"></asp:button>
                       <asp:button runat="server" class="dropbtn2" Text="Estatutos"></asp:button>
                       <asp:button runat="server" class="dropbtn2" Text="Código"></asp:button>
                       <asp:button runat="server" class="dropbtn2" Text="Otro"></asp:button>
                 </div>
                      </div>

         <div id="London" class="tabcontent">
  <h3>Gerencia Administrativa</h3>
  <div class="dropdown">
  <label class="dropbtn">Talento Humano</label>
  <div class="dropdown-content">
    <a href="#">Manual</a>
    <a href="#">Política</a>
    <a href="#">Otro</a>
  </div>
</div>
</div>

            <div id="Paris" class="tabcontent">
              <h3>Paris</h3>
              <p>Paris is the capital of France.</p> 
            </div>

            <div id="Tokyo" class="tabcontent">
              <h3>Tokyo</h3>
              <p>Tokyo is the capital of Japan.</p>
            </div>

            <div class="clearfix"></div>


             <br /><br />

             <asp:LinkButton ID="categoria" runat="server" OnClick="categoria_Click" ClientIDMode="Static"></asp:LinkButton>
             <asp:LinkButton ID="categoria2" runat="server" OnClick="categoria2_Click" ClientIDMode="Static"></asp:LinkButton>
             <asp:LinkButton ID="categoria3" runat="server" OnClick="categoria3_Click" ClientIDMode="Static"></asp:LinkButton>
             <asp:LinkButton ID="categoria4" runat="server" OnClick="categoria4_Click" ClientIDMode="Static"></asp:LinkButton>
             <asp:LinkButton ID="categoria5" runat="server" OnClick="categoria5_Click" ClientIDMode="Static"></asp:LinkButton>
       
            </div>
         </div>
               
    </div>
        <br /><br />
         <script>
             $(document).ready(function () {
                 $('.menu').load('MenuPrincipal.aspx');
             });
         </script>
    </form>
    <script type="text/javascript">
        function redirigir() {
            document.getElementById('categoria').click();
        }

        function redirigir2() {
            document.getElementById('categoria2').click();
        }

        function redirigir3() {
            document.getElementById('categoria3').click();
        }

        function redirigir4() {
            document.getElementById('categoria4').click();
        }

        function redirigir5() {
            document.getElementById('categoria5').click();
        }
    </script>
    <script>
        function openCity(evt, cityName) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(cityName).style.display = "block";
            evt.currentTarget.className += " active";
        }
    </script>

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
         
          <%--  <script>
                var acc = document.getElementsByClassName("accordion");
                var i;

                for (i = 0; i < acc.length; i++) {
                    acc[i].addEventListener("click", function () {
                        this.classList.toggle("active");
                        var panel = this.nextElementSibling;
                        if (panel.style.display === "block") {
                            panel.style.display = "none";
                        } else {
                            panel.style.display = "block";
                        }
                    });
                }
            </script>--%>
</body>
</html>
