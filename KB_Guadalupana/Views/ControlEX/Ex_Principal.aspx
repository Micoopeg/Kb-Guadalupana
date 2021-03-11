<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_Principal.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
    <title></title>
    <link rel="stylesheet"  href="../../EXDiseños/EstilosDashboard.css" />
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'><link rel="stylesheet" href="../../EXDiseños/stylebarra.css">
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
				<a id="inicio" runat="server" href="javascript:void(0);" class="links">
					<span class="span fa fa-home"></span>Inicio
				</a>
			</li>

			<li class="li">
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-suitcase"></span>Enviar expediente
				</a>
			</li>

			<li class="li submenu">
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-rocket"></span>Expedientes con Hallazgos
					<span class="span fa fa-arrow-down"></span>
				</a>

				<ul class="children">
					<li class="li">
						<a href="javascript:void(0);" class="links">Subelemento #1
							<span class="span fa fa-play"></span>
						</a>
					</li>  
					<li class="li">
						<a href="javascript:void(0);" class="links">Subelemento #2
							<span class="span fa fa-play"></span>
						</a>
					</li>  
					<li class="li">
						<a href="javascript:void(0);" class="links">Subelemento #3
							<span class="span fa fa-play"></span>
						</a>
					</li>  
				</ul>
			</li>

			<li class="li">
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-users"></span>Pendientes de envío
				</a>
			</li>
		
		</ul>
	</nav>
</header>

    <section class="overview">
        <div class="wrapper">
			
			<h2>02/03/2021</h2>
            <h2>Expedientes del día</h2>
			
			<br />
            <div class="grid">
            <div class="card-small">
                <p class="card-small-views">Expedientes Generados</p>
                <p class="card-small-icon">
                    <img src="images/favicon-32x32.png" alt="">
                </p>
                <p class="card-small-number">10</p>
                <span>
                <p class="card-small-percentage">3%</p>
                </span>
            </div>
            <div class="card-small">
                <p class="card-small-views">Expedientes Enviados</p>
                <p class="card-small-icon">
                    <img src="images/favicon-32x32.png" alt="">
                </p>
                <p class="card-small-number">6</p>
                <span>
                <p class="card-small-percentage">3%</p>
                </span>
            </div>
            <div class="card-small">
                <p class="card-small-views">Expedientes por enviar</p>
                <p class="card-small-icon">
                    <img src="images/instagram-32.png" alt="">
                </p>
                <p class="card-small-number">4</p>
                <span>
                <p class="card-small-percentage">15%</p>
                </span>
            </div>
            <div class="card-small">
                <p class="card-small-views">Expedientes con hallazgos</p>
                <p class="card-small-icon">
                    <img src="images/instagram-32.png" alt="">
                </p>
                <p class="card-small-number">3</p>
                <span>
                <p class="card-small-percentage">13%</p>
                </span>
            </div>
            
        </div>
    </section>


		
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<h2>hola esto es una prueba</h2>

	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="inicio" EventName="Click" />

	</Triggers>
</asp:UpdatePanel>
	--%>


		

         <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script><script  src="../../EXDiseños/scriptbarra.js"></script>
    <script src="../../EXDiseños/scriptdash.js"></script>
    </form>
</body>
</html>
