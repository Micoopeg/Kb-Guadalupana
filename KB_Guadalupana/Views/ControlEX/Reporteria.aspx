<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporteria.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Reporteria" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.css'><link rel="stylesheet" href="../../EXDiseños/EstilosMensajeria.css">
	    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'/><link rel="stylesheet" href="../../EXDiseños/stylebarra.css"/>
   <link rel="stylesheet" type="text/css" href="../../EXDiseños/ExtiloExEnvio.css" />
     <link type="text/css" rel="stylesheet" href="../../EXDiseños/estilolector.css" />
      <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" type="text/javascript"></script>
        
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>


    <title>Reportes</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

     <center>   <header class="encabezado">
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
				<a id="inicio" runat="server" href="javascript:void(0);" onclick="redirigir()" class="links">
					<span class="span fa fa-home"></span>Inicio
				</a>


			</li>

		<li class="li">
				<a href="javascript:void(0);" onclick="redirigir2()" class="links">
					<span class="span fa fa-user"></span>Cerrar Sesion
				</a>
			</li>
		</ul>
	</nav>
</header></center>
        <center>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
        </center>
		   <asp:LinkButton ID="btninicio" runat="server" OnClick="btninicio_click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btncerrar" ClientIDMode="Static"></asp:LinkButton>
    </form>
	   <script type="text/javascript">

           function redirigir() {

               document.getElementById('btninicio').click();

           }
           function redirigir2() {

               document.getElementById('LinkButton1').click();

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
    <script type="text/javascript" src="../../EXDiseños/scriptvalidar.js" >  </script>
</body>
</html>
