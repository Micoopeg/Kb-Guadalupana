<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_Principal.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
    <title></title>
    <link rel="stylesheet"  href="../../EXDiseños/EstilosDashboard.css" />
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'/><link rel="stylesheet" href="../../EXDiseños/stylebarra.css"/>
   

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>



<header class="encabezado">
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

			<li class="li submenu">
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-suitcase"></span>Expedientes
                    <span class="span fa fa-arrow-down"></span>
				</a>
                <ul class="children">
                    <li class="li">
						<a href="javascript:void(0);" onclick="redirigir2()" class="links">Expedientes General
							<span class="span fa fa-play"></span>
						</a>
					</li>  
				
					
				</ul>
			</li>

			<li class="li ">
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-eye"></span>Expedientes con Hallazgos
					
				</a>

				
			</li>

			<li class="li">
				<a href="javascript:void(0);" onclick="redirigir4()" class="links">
					<span class="span fa fa-location-arrow"></span>Pendientes de envío
				</a>
			</li>
		<li class="li">
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-user"></span>Cerrar Sesion
				</a>
			</li>
		</ul>
	</nav>
</header>

    <section class="overview">
        <div class="wrapper">
			<h2 id="NombreAgencia" runat="server" >Area no cargada</h2>
			<h2 id="Date" runat="server" >sin fecha error</h2>
            <h2>Expedientes del día</h2>
			
			<br />
            <div class="grid">
            <div class="card-small">
                <p class="card-small-views">Mensajería</p>
                <p class="card-small-icon">
                     <span class="fa fa-folder-open"></span>
                </p>
                <p id="expgen" runat="server" class="card-small-number">10</p>
                
            </div>
            <div class="card-small">
                <p class="card-small-views">En transito</p>
                <p class="card-small-icon">
                    <span class="span fa fa-suitcase"></span>
                </p>
                <p id="expenv" runat="server" class="card-small-number">6</p>
               
            </div>
            <div class="card-small">
                <p class="card-small-views">Agencia</p>
                <p class="card-small-icon">
                     <span class="fa fa-location-arrow"></span>
                </p>
                <p id="exppenv" runat="server" class="card-small-number">4</p>
               
            </div>
            <div class="card-small">
                <p class="card-small-views">Mesa de control</p>
                <p class="card-small-icon">
                     <span class="fa fa-eye"></span>
                </p>
                <p id="exphall" runat="server" class="card-small-number">3</p>
              
            </div>
                 <div class="card-small">
                <p class="card-small-views">Juridico</p>
                <p class="card-small-icon">
                     <span class="fa fa-eye"></span>
                </p>
                <p id="P1" runat="server" class="card-small-number">3</p>
              
            </div>
                 <div class="card-small">
                <p class="card-small-views">Archivo</p>
                <p class="card-small-icon">
                     <span class="fa fa-eye"></span>
                </p>
                <p id="P2" runat="server" class="card-small-number">3</p>
              
            </div>
                 <div class="card-small">
                <p class="card-small-views">Retenidos</p>
                <p class="card-small-icon">
                     <span class="fa fa-eye"></span>
                </p>
                <p id="P3" runat="server" class="card-small-number">3</p>
              
            </div>
            
        </div>
            </div>
    </section>
         <asp:LinkButton ID="btninicio" runat="server" OnClick="btnInicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnEXGEN_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnNuevo_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnpendiente" ClientIDMode="Static"></asp:LinkButton>

       <%--  <asp:LinkButton ID="LinkButton5" runat="server" OnClick="btnModapp_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton6" runat="server" OnClick="btnmodulospermisos_Clicl" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton7" runat="server" OnClick="btnappuser_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="LinkButton8" runat="server" OnClick="btnestadouser_Click" ClientIDMode="Static"></asp:LinkButton>--%>

		



		

         <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script><script  src="../../EXDiseños/scriptbarra.js"></script>
    <script src="../../EXDiseños/scriptdash.js"></script>
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
</body>
</html>
