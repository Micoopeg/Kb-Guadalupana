<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="controlProcesosJudiciales.aspx.cs" Inherits="KB_Guadalupana.Views.MantenimientosControl.controlProcesosJudiciales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Seguridad Proceso</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
 
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
</head>
     <style>

        form 
{
  background: #003563;
  width: 700px;
  margin: 130px auto;
  border-radius: 0.4em;
  border: 1px solid #191919;
  overflow: hidden;
  position: relative;
  box-shadow: 0 5px 10px 5px rgba(0, 0, 0, 0.2);
}

form:after {
  content: "";
  display: block;
  position: absolute;
  height: 1px;
  width: 100px;
  left: 20%;
  background: linear-gradient(to right, #111111, #444444, #b6b6b8, #444444, #111111);
  top: 0;
}

form:before {
  content: "";
  display: block;
  position: absolute;
  width: 8px;
  height: 5px;
  border-radius: 50%;
  left: 34%;
  top: -7px;
  box-shadow: 0 0 6px 4px #fff;
}

.inset {
  padding: 20px;
  border-top: 1px solid #19191a;
  align-content:center;
  align-items:center;
  justify-content:center;
}

form h1 {
  font-size: 18px;
  text-shadow: 0 1px 0 black;
  text-align: center;
  padding: 15px 0;
  border-bottom: 1px solid black;
  position: relative;
}

form h1:after {
  content: "";
  display: block;
  width: 250px;
  height: 100px;
  position: absolute;
  top: 0;
  left: 50px;
  pointer-events: none;
  transform: rotate(70deg);
  background: linear-gradient(50deg, rgba(255, 255, 255, 0.15), rgba(0, 0, 0, 0));
}

label {
  color: #666;
  display: block;
  padding-bottom: 9px;
}

input[type=text],
input[type=password] {
  width: 100%;
  padding: 8px 5px;
  background: white;
  border: 1px solid #222;
  box-shadow: 0 1px 0 rgba(255, 255, 255, 0.1);
  border-radius: 0.3em;
  margin-bottom: 20px;
}

label[for=remember] {
  color: white;
  display: inline-block;
  padding-bottom: 0;
  padding-top: 5px;
}

input[type=checkbox] {
  display: inline-block;
  vertical-align: top;
}

.p-container {
  padding: 0 20px 20px 20px;
}

.p-container:after {
  clear: both;
  display: table;
  content: "";
}

.p-container span {
  display: block;
  float: left;
  color: #0d93ff;
  padding-top: 8px;
}

input[type=submit] {
  padding: 10px 40px;
  border: 1px solid rgba(0, 0, 0, 0.4);
  text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.4);
  box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.3), inset 0 10px 10px rgba(255, 255, 255, 0.1);
  border-radius: 0.3em;
  background: #69a43c;
  color: white;
  float:left;
  font-weight: bold;
  cursor: pointer;
  font-size: 13px;
  margin-left: 0px;
}

input[type=submit]:hover {
  box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.3), inset 0 -10px 10px rgba(255, 255, 255, 0.1);
}

input[type=text]:hover,
input[type=password]:hover,
label:hover ~ input[type=text],
label:hover ~ input[type=password] {
  background:gray;
}
body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}

.topnav {
  overflow: hidden;
  background-color: #333;
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
  background-color: #B80416;;
  color: White;
}

.topnav a.active {
  background-color: #69a43c;
  color: white;
}
        
.dis
{
padding: 8px;
    border: 1px solid #ccc;
    border-radius: 3px;
    margin-bottom: 10px;
    width: 101.5%;
    box-sizing: border-box;
    font-family: montserrat;
    color: #2C3E50;
    font-size: 13px;            
}
.dis2
{
padding: 8px;
    border: 1px solid #ccc;
    border-radius: 3px;
    margin-bottom: 10px;
    width: 50%;
    box-sizing: border-box;
    font-family: montserrat;
    color: #2C3E50;
    font-size: 13px;            
}
.dis3
{
padding: 8px;
    border: 1px solid #ccc;
    border-radius: 3px;
    margin-bottom: 10px;
    width: 100%;
    box-sizing: border-box;
    font-family: montserrat;
    color: #2C3E50;
    font-size: 13px;            
}
.BuscarM {
  padding: 0px;
  border: 1px solid rgba(0, 0, 0, 0.4);
  text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.4);
  box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.3), inset 0 10px 10px rgba(255, 255, 255, 0.1);
  border-radius: 0.3em;
  background: #69a43c;
  color: white;
  font-weight: bold;
  cursor: pointer;
  font-size: 13px;
  width:30%;
  height:35px;
}

.BuscarM:hover {
  box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.3), inset 0 -10px 10px rgba(255, 255, 255, 0.1);
}
.Modulos2{
    display:flex;
    flex-direction:row;
    justify-content:space-around;
    width:100%;
}
.row{
    display:flex;
    flex-direction:column;
    width:95%;
    justify-content:center;
    align-content:center;
    align-items:center;
    margin-left:0px;
}
</style>
<body>
       <div class="topnav">
            <a class="active" href="../Sesion/Inicio.aspx">Inicio</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b>Seguridad KB-Guadalupana</b></span>
            <a href="../Sesion/../CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
    </div>

    <form id="form1" runat="server">
         <h1 style="color:white">Estado Usuarios Procesos Judiciales</h1>
          <div class="inset">
    <div class="row">

          <p class="Modulos2">
              <asp:DropDownList ID="UsuarioPJ" runat="server" CssClass="dis2" AutoPostBack="false"></asp:DropDownList>
              <asp:Button ID="BuscarUsuario" runat="server" CssClass="BuscarM"  Text="Buscar Usuario" OnClick="BuscarUsuario_Click"></asp:Button>
          </p><br />

        <div class="row">
            <label  style="color:white">Seleccione área</label>
            <asp:DropDownList ID="Area" runat="server" CssClass="dis3" AutoPostBack="true" OnSelectedIndexChanged="Area_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div class="row">
            <label  style="color:white">Seleccione puesto</label>
            <asp:DropDownList ID="Puesto" runat="server" CssClass="dis3" AutoPostBack="false"></asp:DropDownList>
        </div>

        <div class="row">
            <label style="color:white">Seleccione rol</label>
             <asp:DropDownList ID="Rol" runat="server" CssClass="dis3" AutoPostBack="false"></asp:DropDownList>
        </div>

           <div class="row">
            <label style="color:white">Seleccione Estado</label>
             <asp:DropDownList ID="EstadoU" runat="server" CssClass="dis3" AutoPostBack="false"></asp:DropDownList>
        </div>
         <%--<p class="col-md-4">
            <label  style="color:white">Usuarios</label>
            <input style="color:white" type="text" name="email" id="email">
        </p>
        <p class="col-md-4">
            <label style="color:white">Usuarios</label>
            <input style="color:white" type="text" name="email" id="email">
        </p>
         <p class="col-md-4">
            <label style="color:white">Usuarios</label>
            <select class="dis">
                <option disabled selected>Departamento</option>
                <option value="">Informatica</option>
                <option value="">Cumplimiento</option>
            </select>
        </p>--%>
    </div>
       <%--<p >
            <label  style="color:white">Usuarios</label>
            <input style="color:white" type="text" name="email" id="email">
        </p>
      <p>
        <label style="color:white">Estado</label>
        <select class="dis">
                <option disabled selected>Departamento</option>
                <option value="">Informatica</option>
                <option value="">Cumplimiento</option>
            </select>
      </p>--%>
      </div>

          <div class="row">
   
            <asp:Button ID="btninsert" runat="server" CssClass="MGuardar" Text="Guardar Nuevo" OnClick="btninsert_Click"></asp:Button> <br />
              <asp:Button ID="Actualizar" runat="server" CssClass="MGuardar" Text="Actualizar datos" OnClick="Actualizar_Click"></asp:Button> <br />
          </div>

          <script>
          $('#<%=UsuarioPJ.ClientID%>').chosen();
          </script>
        <script>
            $('#<%=Area.ClientID%>').chosen();
        </script>
        <script>
            $('#<%=Rol.ClientID%>').chosen();
        </script>
    </form>
</body>
</html>
