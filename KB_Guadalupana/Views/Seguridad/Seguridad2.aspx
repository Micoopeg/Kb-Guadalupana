<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Seguridad2.aspx.cs" Inherits="KB_Guadalupana.Views.Seguridad.Seguridad2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Seguridad</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" type="text/javascript"></script>
    <link rel="stylesheet"  href="../../EXDiseños/EstilosDashboard.css" />
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'><link rel="stylesheet" href="../../EXDiseños/stylebarra.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
</head>
    <style>
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
        
.item {
  box-sizing: border-box;
  max-width: 550px;
  position: relative;
  overflow: hidden;
  background:white;
  border: 1px solid #003563;
  box-shadow: 0px 0px 2px #003563;
  padding: 10px 20px 20px 20px;
  margin: 10px auto;
  font-family: sans-serif;
  width:90%;
}
.item p{
  font-family: 'Roboto', sans-serif;
  font-size:12px;
  width:100%;
}
.item label{
  font-weight: bold;
}
.item div{
  display: inline-block;
}
.item .texto{
   width: 50%;
   float: left;
   position:relative;
}
.item .botones span{
  width:calc(100% - 20px);
  text-align:center;
  font-family: 'Roboto', sans-serif;
      text-transform: uppercase;
}
.item .botones{
    position: absolute;
    width: 39%;
    top: 50%;
    right: 20px;
    transform: translateY(-50%);
}
.item:before{
    content: '';
    position: absolute;
    right: 289px;
    top: 0;
    background: #003563;
    width: 60%;
    height: 100%;
    z-index: 0;
    transform: skew(-15deg) translateX(45px);
  -webkit-transform: skew(-15deg) translateX(45px);
}
span.detalle_cita {
  border: 2px solid #003563;
  cursor: pointer;
    display: inline-block;
  margin-top:5px;
  background: white;
  color: #151515;
  border-radius: 3px;
    cursor: pointer;
    padding: 8px 10px;
    margin-right: 10px;
  font-weight:bold;
  margin-bottom:5px;
}
span.remove_cita {
   border: 2px solid #EEE54C;
      cursor: pointer;
    display: inline-block;
   margin-top:5px;
  font-weight: bold;
    border-radius: 3px;
    padding: 8px 10px;
    margin-right: 10px;
    cursor: pointer;
    background: #EEE54C;
    color: #151515;
}
.buscador label{
    color: #151515;
    font-weight: bold;
}
.buscador{
      box-sizing: border-box;
     max-width: 400px;
    border: 1px solid #EEE54C;
  box-shadow: 0px 0px 2px #EEE54C;
  margin:0 auto;
  width:90%;
  line-height:2;
  padding: 10px 10px 20px 10px;
 background: #EEE54C;
}
#buscador{
box-sizing: border-box;
    width: 100%;
    font-size: 20px;
    outline: none;
    border: 1px solid #151515;
}   
        
.button {
  background-color: #4CAF50; /* Green */
  border: none;
  color: white;
  padding: 8px 100px;
  text-align: center;
  text-decoration: none;
  display: inherit;
  font-size: 16px;
  margin: 4px -50px;
  transition-duration: 0.4s;
  cursor: pointer;
}
        
.button2 {
  background-color: #4CAF50; /* Green */
  border: none;
  color: white;
  padding: 8px 100px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: -11px -376px;
  transition-duration: 0.4s;
  cursor: pointer;
}

.button1 {
  background-color: white; 
  color: black; 
  border: 2px solid 003553;
}


.button1:hover {
  background-color: #69a43c;
  color: white;
}
        
.item1 {
  box-sizing: border-box;
  max-width: 750px;
  position: relative;
  overflow: hidden;
  background:white;
  border: 1px solid #003563;
  box-shadow: 0px 0px 2px #003563;
  padding: 10px 20px 20px 20px;
  margin: 10px auto;
  font-family: sans-serif;
  width:90%;
}
.item1 p{
  font-family: 'Roboto', sans-serif;
  font-size:12px;
  width:100%;
}
.item1 label{
  font-weight: bold;
}
.item1 div{
  display: inline-block;
}
.item1 .texto{
   width: 50%;
   float: left;
   position:relative;
}
.item1 .botones span{
  width:calc(100% - 20px);
  text-align:center;
  font-family: 'Roboto', sans-serif;
      text-transform: uppercase;
}
.item1 .botones{
    position: absolute;
    width: 39%;
    top: 50%;
    right: 20px;
    transform: translateY(-50%);
}
.item1:before{
    content: '';
    position: absolute;
    left: -54px;
    top: 0;
    background: #003563;
    width: 60%;
    height: 100%;
    z-index: 0;
    transform: skew(-15deg) translateX(45px);
  -webkit-transform: skew(-15deg) translateX(45px);
}        
</style>
    

<body>

     <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             

    <div class="topnav">
              <a class="active" href="../Sesion/MenuBarra.aspx">Inicio</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b>Seguridad Modulos KB-Guadalupana</b></span>
             <a href="../../Index.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
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

<br>
<br>
<br>

         <div class="container-fluid" style="margin-top:60px;">
    <asp:Repeater ID="repetirapp" runat="server">
        <ItemTemplate>
   <div class="item">
     
        <div class="botones" >
            <asp:Label ID="idapp" runat="server" Text='<%# Eval("codgenapp") %>' Visible="false" ></asp:Label>
            <asp:LinkButton ID="btn1seg" runat="server" CssClass="button button1 detalle_cita" style="padding: 10px 90px; min-width:90px ;" OnClick="btnmantenimiento_Click" ><%# Eval("gen_nombreapp") %></asp:LinkButton>
        </div> 
   </div>
    </ItemTemplate>
  </asp:Repeater>
             </div>

           <asp:LinkButton ID="btninicio" runat="server" OnClick="btninicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btninicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btninicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnmoduloscrear_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnModapp_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton5" runat="server" OnClick="btnmodulospermisos_Clicl" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton6" runat="server" OnClick="btnappuser_Click" ClientIDMode="Static"></asp:LinkButton>
          <asp:LinkButton ID="LinkButton7" runat="server" OnClick="btnestadouser_Click" ClientIDMode="Static"></asp:LinkButton>
    
     </form>


    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
      <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script><script  src="../../EXDiseños/scriptbarra.js"></script>
    <script src="../../EXDiseños/scriptdash.js"></script>
   
    
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