<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_MenuPrincipal.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.MenuPrincipal.CRM_MenuPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRM - GUADALUPANA</title>
	 <link rel="shortcut icon" href="../../../Imagenes/logo.jpeg"/>
	 <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css'/>
	<link rel="stylesheet" type="text/css" href="../../../CRM-Estilos/Estilos.css" />

    <style type="text/css">
        .img-fluid {
            height: 107px;
            width: 124px;
        }
    </style>

</head>

<body>
	<form id="form1" runat="server">
	<header style="background-color:#005363; margin-top:10px ">
				
	</header>
<!-- partial:index.partial.html -->
<div id="responsive-admin-menu">
	<div id="responsive-menu">
		<div class="menuicon">≡</div>
	</div>
	<center>
			<div id="logo">
			<a href="CRM_MenuPrincipal.aspx"><img src="../../../Imagenes/logo.jpeg" class="img-fluid" style="width: auto;border-radius:49px;height: 100px;position: absolute;left: 44px;" alt="Responsive image" /></a>
    </div>
	</center>

	<!--Menu-->
	<div id="menu">
			<a href="~/Views/CRM-SISTEMA/Dashboard/CRM_Dashboard.aspx" title="Dashboard" id="btndashboards" runat="server"><i class="icon-dashboard"></i><span>Dashboard</span></a>		

			<a href="~/Views/CRM-SISTEMA/Ingresodata/CRM_Ingresodedatos.aspx" title="ingresodedatos" id="btningresodedatos" runat="server"><i class="icon-bullhorn"></i><span> Ingreso de datos</span></a>			
			<a href="../Asesores/CRM_Asesores.aspx" title="catalogodeprospectos" id="btncarteraasociados" runat="server"><i class="icon-file-alt"></i><span> Catálogo de prospectos</span></a>
			<a href="" title="Catalogodeclientes" class="submenu" name="media-sub" id="btncatalogodeclientes" runat="server"><i class="icon-eye-open"></i><span>  
			Catálogo de clientes</span></a>
			<!-- Media Sub Menu -->
				<div id="media-sub" style="display: none;">
                    <%-- TRABAJAR EN FINALIZADO Y RECHAZADO YA QUE QUEDO PENDIENTE DE VALIDACIÓN --%>
					<%--<a href="../Catalogo_clientes/ProspectosFinalizados.aspx" title="Procespectos Finalizados"><i class="icon-user"></i><span>  
					Prospectos Finalizados</span></a>--%>
					<a href="../Catalogo_clientes/Prospectoenprocesos.aspx" title="Prospectos en proceso"><i class="icon-user"></i><span>  
					Prospectos En Proceso</span></a>
					<%--<a href="../Catalogo_clientes/Prospectosrechazados.aspx" title="Prospectos Rechazados"><i class="icon-user"></i><span>  
					Prospectos Rechazados</span></a>--%>
				</div>
			<!-- Media Sub Menu --> 
			
			<a href="~/Views/CRM-SISTEMA/Reporteria/CRM_Reporteria.aspx" title="Graph &amp; Charts" id="btncharts" runat="server"><i class="icon-bar-chart"></i><span>  
			Reportes</span></a>
			<a href="" class="submenu" name="other-sub" title="Mantenimientos" id="btnmantenimientos" runat="server"><i class="icon-book"></i><span> 
			Mantenimientos</span></a>
			<!-- Other Contents Sub Menu -->
				<div id="other-sub" style="display: none;">
					<a href="../Administracion/Mantenimientos/CRM_Manttiposervicio.aspx" title="Forms"><i class="icon-book"></i><span>  
					Tipos de servicio</span></a>
					<a href="../Administracion/Mantenimientos/CRM_Manttipodomicilio.aspx" title="tiposervicio"><i class="icon-book"></i><span>  
					Tipos de domicilio</span></a>
					<a href="../Administracion/Mantenimientos/CRM_Mantdescripcionestado.aspx" title="tipodomicilio"><i class="icon-book"></i><span>  
					Descripción por estado</span></a>
					<a href="../Administracion/Mantenimientos/CRM_Mantcontactollamadas.aspx" title="descripcion"><i class="icon-book"></i><span>  
					Contacto llamada</span></a>
					<a href="../Administracion/Mantenimientos/CRM_Finalidaddeservicio.aspx" title="contacto"><i class="icon-book"></i><span>  
					Finalidad de servicio</span></a>
					<a href="../Administracion/Mantenimientos/CRM_Mantfrasesdeldia.aspx" title="finalidad"><i class="icon-book"></i><span>  
					Frases del día</span></a>
					<a href="../Administracion/Mantenimientos/CRM_Mantprospecto.aspx" title="frases"><i class="icon-book"></i><span>  
					 Clientes</span></a>
					<a href="../Administracion/Controldedespidos/Trasalado_por_despido.aspx" title="Despido"><i class="icon-book"></i><span>  
					 Control de despidos</span></a>
				</div>
		<a href="~/Views/CRM-SISTEMA/Administracion/Reasignaciones/Reasignar_prospecto.aspx" title="Graph &amp; Charts" id="btnasignacionforzosa" runat="server"><i class="icon-briefcase"></i><span>  
			Asignaciones Forzosa</span></a>
			<!-- Other Contents Sub Menu -->
			<a href="" title="cerarsesion" id="btncerrarsesion" runat="server" onserverclick="btncerrarsesion_ServerClick" ><i class='fas fa-door-open'></i><span>  
			Cerrar Sesión</span></a>
	</div>
	<!--Menu-->
</div>

<div id="content-wrapper">
	<br />
	<br />
		<div style="border:1px #e8e8e8 solid;width:100%;float:right;margin:10px 0px 10px 0px">
		<div style="border-bottom:1px #e8e8e8 solid;background-color:#f3f3f3;padding:8px;font-size:13px;font-weight:700;color:#45484d;">
			Mensaje del día - Cultura Servicio</div>
		<div style="padding:8px;font-size:13px;">
			<center>			
		<h1><asp:Label ID="lblfrase" runat="server" Text="Label"></asp:Label></h1>
			</center>
		</div>
			
	</div>

</div>
<!-- partial -->
  <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
  <script src="../../../CRM-Script/Script.js" type="text/javascript"></script>
		<script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>

    </form>

</body>
</html>
