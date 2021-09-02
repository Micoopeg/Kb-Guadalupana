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

			<li id="negocios" runat="server" class="li">
				<a href="javascript:void(0);" onclick="redirigir2()"  class="links">
					<span class="span fa fa-suitcase"></span>Control de Negocios
                    <span class="span fa fa-arrow-down"></span>
				</a>
             
			</li>

			<li id="mesareg" runat="server" class="li " visible="false">
				<a href="javascript:void(0);" onclick="redirigir3();" class="links">
					<span class="span fa fa-eye"></span>Expedientes Legalizados
					
				</a>

				
			</li>

            <li id="archivo" runat="server" class="li " visible="false">
				<a href="javascript:void(0);" onclick="redirigir3();" class="links">
					<span class="span fa fa-suitcase"></span>Recepción de Archivo
					
				</a>
                    <li id="repo" runat="server" class="li" visible="false" >
				<a href="javascript:void(0);" onclick="redirigir8()" class="links">
					<span class="span fa fa-eye"></span>Reporte
				</a>
			</li>
				
			</li>
            <li id="hallazgos" runat="server" class="li">
				<a href="javascript:void(0);" onclick="redirigir6()" class="links">
					<span class="span fa fa-eye"></span>Expedientes con hallazgos
				</a>
			</li>
              <li id="Generador" runat="server" class="li" visible="false">
				<a href="javascript:void(0);" onclick="redirigir9()" class="links">
					<span class="span fa fa-eye"></span>Generador
				</a>
			</li>
			<li id="pendientes" runat="server" class="li">
				<a href="javascript:void(0);" onclick="redirigir4()" class="links">
					<span class="span fa fa-location-arrow"></span>Pendientes de envío
				</a>
			</li>
		<li class="li">
				<a href="javascript:void(0);" onclick="redirigir7()" class="links">
					<span class="span fa fa-user"></span>Cerrar Sesion
				</a>
			</li>
		</ul>
	</nav>
</header>
         <div id="contenedorperfil" runat="server" visible="false" style="text-align: right; margin-right:120px">
                 <label  id="encabasignados" runat="server" style="color:red; font-size:15px">Ya puedes cambiar tu Perfil</label><br />
               <asp:DropDownList ID="permiso" runat="server" CssClass="dis" AutoPostBack="true" Width="177px" OnSelectedIndexChanged="permiso_SelectedIndexChanged" ></asp:DropDownList><br/>
 </div>
    <section class="overview">
        <div class="wrapper">
            <h2 id="usuarioent" runat="server" >usuario</h2>
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
                <p id="esmens" runat="server" class="card-small-number">0</p>
                
            </div>
            <div class="card-small">
                <p class="card-small-views">En transito</p>
                <p class="card-small-icon">
                    <span class="span fa fa-suitcase"></span>
                </p>
                <p id="extran" runat="server" class="card-small-number">0</p>
               
            </div>
            <div class="card-small">
                <p class="card-small-views">Agencias</p>
                <p class="card-small-icon">
                     <span class="fa fa-location-arrow"></span>
                </p>
                <p id="exppenv" runat="server" class="card-small-number">0</p>
               
            </div>
            <div class="card-small">
                <p class="card-small-views">Mesa de control</p>
                <p class="card-small-icon">
                     <span class="fa fa-eye"></span>
                </p>
                <p id="exmesa" runat="server" class="card-small-number">0</p>
              
            </div>
                 <div class="card-small">
                <p class="card-small-views">Jurídico</p>
                <p class="card-small-icon">
                     <span class="fa fa-eye"></span>
                </p>
                <p id="exjur" runat="server" class="card-small-number">0</p>
              
            </div>
                 <div class="card-small">
                <p class="card-small-views">Archivo</p>
                <p class="card-small-icon">
                     <span class="fa fa-eye"></span>
                </p>
                <p id="exarch" runat="server" class="card-small-number">0</p>
              
            </div>
                 <div class="card-small">
                <p class="card-small-views">Retenidos</p>
                <p class="card-small-icon">
                     <span class="fa fa-eye"></span>
                </p>
                <p id="exret" runat="server" class="card-small-number">0</p>
              
            </div>
            
        </div>
            </div>
    </section>
         <asp:LinkButton ID="btninicio" runat="server" OnClick="btnInicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnEXGEN_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnpendiente" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click" ClientIDMode="Static"></asp:LinkButton>
       <%--  
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
         function redirigir8() {

             document.getElementById('LinkButton8').click();

         }
         function redirigir9() {

             document.getElementById('LinkButton9').click();

         }
     </script>
</body>
</html>
