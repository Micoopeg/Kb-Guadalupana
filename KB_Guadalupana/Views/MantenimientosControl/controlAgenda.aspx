<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="controlAgenda.aspx.cs" Inherits="KB_Guadalupana.Views.MantenimientosControl.controlAgenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="controlAgenda.aspx" />
    <title>Agenda Mantenimiento</title>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" type="text/javascript"></script>
    <link rel="stylesheet"  href="../../EXDiseños/EstilosDashboard.css" />
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'><link rel="stylesheet" href="../../EXDiseños/stylebarra.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
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
  margin-left: 260px;
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
</style>
<body>

     <div class="topnav">
              <a class="active" href="../Sesion/MenuBarra.aspx">Inicio</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b>Seguridad Modulos KB-Guadalupana</b></span>
             <a href="../Sesion/../CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
    </div>

                 <header class="encabezado" style="text-align:center;">
	<div class="menu-bar">
		<div class="three col">
			<div class="hamburger" id="hamburger-pro">
				<span class="line"></span>
				<span class="line"></span>
				<span class="line"></span>
			</div>
		</div>

		<a href="javascript:void(0);" class="links" class="bt-menu">
			<span class="span fa fa-list"></span>
		</a>
	</div>  

	<nav class="nav">
		<ul class="ul">
			<li class="li">
				<a id="inicio" runat="server" href="javascript:void(0);" onclick="redirigir()"  class="links">
					<span class="span fa fa-home" ></span>Usuario
				</a>
			</li>

			<li class="li submenu">
				<a href="javascript:void(0);" class="links" onclick="redirigir2()">
					<span class="span fa fa-suitcase"></span> Modulos
                    <span class="span fa fa-arrow-down"></span>
				</a>

                <ul class="children">
					<li class="li">
						<a href="javascript:void(0);" onclick="redirigir3()" class="links">Agregar Modulo
							<span class="span fa fa-play"></span>
						</a>
					</li>  
					<li class="li">
						<a href="javascript:void(0);" onclick="redirigir4()" class="links">Modificar Modulos
							<span class="span fa fa-play"></span>
						</a>
					</li>  
					
				</ul>
			</li>

			<li class="li">
				<a href="javascript:void(0);" onclick="redirigir5()" class="links">
					<span class="span fa fa-rocket"></span>Modulos y permisos
					
				</a>

				
			</li>

			<li class="li">
				<a href="javascript:void(0);" onclick="redirigir6()" class="links">
					<span class="span fa fa-users"></span>Modulos y Usuarios
				</a>
			</li>
            	<li class="li">
				<a href="javascript:void(0);" onclick="redirigir7()" class="links">
					<span class="span fa fa-users"></span>Estado de Usuarios
				</a>
			</li>
		
		</ul>
	</nav>
</header>
    <form id="form1" runat="server">
      


          <h1 style="color:white">Mantenimiento sistema Agenda</h1>
  <div class="inset" >
<div class="row" id="mantuser" runat="server">
    <p class="col-md-6">
        <label  style="color:white">Usuario</label>
        
        <asp:DropDownList ID="DDUSER" runat="server" CssClass="dis" AutoPostBack="true" OnSelectedIndexChanged="DDUSER_SelectedIndexChanged"  ></asp:DropDownList>
     
        <label  style="margin-left: 16px;color:white;padding-bottom: 0px;margin-bottom: -17px;margin-top: 10px;">Nuevo usuario</label>
        <asp:CheckBox ID="chk" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" />
        <input style="color:black" type="text" name="email" id="NUEVOUSER" disabled="disabled" runat="server">
        <label  style="color:white">CIF</label>
        <input style="color:black" class="form-control form-control-lg"  name="email" id="CIF" runat="server" maxlength="6" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" type="number" min="0" required>
  
    </p>
    
    <p class="col-md-6">
        <label style="color:white">Area</label>
         <asp:DropDownList ID="DDAREA" runat="server" CssClass="dis" AutoPostBack="false"></asp:DropDownList>

        <label  style="color:white">Rol</label>
      
         <asp:DropDownList ID="DDROL" runat="server" CssClass="dis" AutoPostBack="false"></asp:DropDownList>
          <label  style="margin-left: 16px;color:white;padding-bottom: 0px;margin-bottom: -17px;margin-top: 75px;">Mantenimiento area y rol</label>
        <asp:CheckBox ID="checkarea" runat="server" OnCheckedChanged="checkarea_CheckedChanged" AutoPostBack="true" />
    </p>


 
  
 
     
</div>
 
  </div>

           <div class="inset" style="align-items:center; " id="mantarea" runat="server"  >
            
        <h1 style="color:white; text-align:center;">Mantenimiento rol y area</h1>
            
        <div class="row">

              
     <p class="col-md-6">

        <label style="color:white">Area</label>
         <input style="color:black; font-size:15px; " class="form-control form-control-lg"  name="email" id="AREA" runat="server"  type="text"  >
   <label  style="color:white">Tipo Sucursal</label>
      
         <asp:DropDownList ID="DDTIPO" runat="server" CssClass="dis" AutoPostBack="false"></asp:DropDownList>
         <p class="col-md-6">
        <label  style="color:white">Rol</label>
      <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged2" AutoPostBack="true" />
          <input style="color:black; font-size:15px;" class="form-control form-control-lg"  name="email" id="ROL" runat="server"  type="text"  >
   <label  style="margin-left: 16px;color:white;padding-bottom: 0px;margin-bottom: -17px;margin-top: 85px;">Mantenimiento usuarios</label>
        <asp:CheckBox ID="chkusers" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged1" AutoPostBack="true" />
</p>
    </p>
        </div>

    </div>
  <p class="p-container">
    
      <asp:Button ID="Button1" runat="server" Text="Rol y Area"  OnClick="Button1_Click" Visible="false"/>
       <asp:Button ID="Button2" runat="server" Text="Guardar" OnClick="SGuardar_Click" />
  </p>
  <asp:LinkButton ID="btninicio" runat="server" OnClick="btninicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btninicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btninicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnmoduloscrear_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnModapp_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton5" runat="server" OnClick="btnmodulospermisos_Clicl" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton6" runat="server" OnClick="btnappuser_Click" ClientIDMode="Static"></asp:LinkButton>
          <asp:LinkButton ID="LinkButton7" runat="server" OnClick="btnestadouser_Click" ClientIDMode="Static"></asp:LinkButton>
    
    </form>
     <script>
         $('#<%=DDUSER.ClientID%>').chosen();
         $('#<%=DDROL.ClientID%>').chosen();
         $('#<%=DDAREA.ClientID%>').chosen();
         $('#<%=DDTIPO.ClientID%>').chosen();
     </script>

    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
      <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script><script  src="../../EXDiseños/scriptbarra.js"></script>


    <script type="text/javascript">

        function redirigir() {

            document.getElementById('btninicio').click();
            
          }
          function redirigir2() {

              document.getElementById('LinkButton3').click();

          }
          function redirigir3() {

              document.getElementById('LinkButton3').click();

          }
          function redirigir4() {

              document.getElementById('LinkButton4').click();

          }
          function redirigir5() {

              document.getElementById('LinkButton5').click();

          }
          function redirigir6() {

              document.getElementById('LinkButton6').click();

          }
          function redirigir7() {

              document.getElementById('LinkButton7').click();

          }
    </script>
</body>
</html>
