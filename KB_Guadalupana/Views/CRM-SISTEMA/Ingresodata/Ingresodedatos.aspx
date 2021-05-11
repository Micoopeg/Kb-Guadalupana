<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingresodedatos.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Ingresodata.Ingresodedatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CRM - GUADALUPANA</title>
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css' />
    <link rel="stylesheet" href="../../../CRM-Estilos/Estilos.css" type="text/css" />

    <style type="text/css">
        .img-fluid {
            height: 107px;
            width: 124px;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <header>
            <h4 style="color: #005363; text-align: right;">BIENVENIDO ASESOR: JOSÉ ALEJANDRO GONZALEZ TEO</h4>
        </header>
        <!-- partial:index.partial.html -->
<div id="responsive-admin-menu">
	<div id="responsive-menu">
		<div class="menuicon">≡</div>
	</div>
	<center>
			<div id="logo">
			<a href="CRM_MenuPrincipal.aspx"><img src="../../../Imagenes/logo.jpeg" class="img-fluid" style="width: auto;height: 100px;position: absolute;left: 44px;" alt="Responsive image" /></a>
    </div>
	</center>

	<!--Menu-->
	<div id="menu">
			<a href="" title="Dashboard" id="btndashboards" runat="server"><i class="icon-dashboard"></i><span>Dashboard</span></a>
			<a href="" title="alertas" id="btnalertas" runat="server"><i class="icon-bullhorn"></i><span> Alertas (1)</span></a>
			<a href="" title="ingresodedatos" id="btningresodedatos" runat="server"><i class="icon-bullhorn"></i><span> Ingreso de datos</span></a>			
			<a href="../Asesores/CRM_Asesores.aspx" title="asociados" id="btncarteraasociados" runat="server"><i class="icon-file-alt"></i><span> Catalogo de clientes</span></a>
			<a href="" title="Media" class="submenu" name="media-sub" id="btnmedia" runat="server"><i class="icon-eye-open"></i><span>  
			Media</span></a>
			<!-- Media Sub Menu -->
				<div id="media-sub" style="display: none;">
					<a href="" title="Video Gallery"><i class="icon-film"></i><span>  
					Video Gallery</span></a>
					<a href="" title="Photo Gallery"><i class="icon-picture"></i><span>  
					Photo Gallery</span></a>
				</div>
			<!-- Media Sub Menu -->
			
			<a href="" title="Graph &amp; Charts" id="btncharts" runat="server"><i class="icon-bar-chart"></i><span>  
			Graph &amp; Charts</span></a>
			<a href="" title="Events" id="btnevenetos" runat="server"><i class="icon-calendar"></i><span>  
			Events</span></a>

			<a href="" class="submenu" name="other-sub" title="Other Contents" id="btnotrocontenido" runat="server"><i class="icon-book"></i><span> 
			Other Contents</span></a>
			<!-- Other Contents Sub Menu -->
				<div id="other-sub" style="display: none;">
					<a href="" title="Forms"><i class="icon-list"></i><span>  
					Forms</span></a>
					<a href="" title="Mail Lists"><i class="icon-list-ul"></i><span>  
					Mail Lists</span></a>
					<a href="" title="Maps"><i class="icon-map-marker"></i><span>  
					Maps</span></a>	
					<a href="" title="Maps"><i class="icon-map-marker"></i><span>  
						Match</span></a>
				</div>
			<!-- Other Contents Sub Menu -->
			<a href="" title="cerarsesion" id="btnadmintools" runat="server"><i class='fas fa-door-open'></i><span>  
			Cerrar Sesión</span></a>
	</div>
	<!--Menu-->
</div>

        <div id="content-wrapper">
            <div style="border: 1px #e8e8e8 solid; width: 49%; float: left; margin: 10px 0px 10px 0px">
                <div style="border-bottom: 1px #e8e8e8 solid; background-color: #f3f3f3; padding: 8px; font-size: 13px; font-weight: 700; color: #45484d;">
                    ESTATUS DE CLIENTES
                </div>
                <div style="padding: 8px; font-size: 13px;">
                     <center>
                          <asp:Chart ID="Chart1" runat="server" canresize="true" CssClass="table  table-bordered table-condensed table-responsive"  Palette="None" AlternateText="El grafico no se puede carga por la conexion a internet" BackColor="105, 164, 60" BackGradientStyle="VerticalCenter" BorderlineColor="Black" PaletteCustomColors="0, 53, 99">  
            <series>  
                <asp:Series Name="Series1" XValueMember="0" YValueMembers="2" >  
                </asp:Series>   
            </series>    
            <chartareas>  
                <asp:ChartArea Name="ChartArea1">  
                </asp:ChartArea>  
            </chartareas>  
        </asp:Chart> 
                        </center>
                    </div>
            </div>

            <div style="border: 1px #e8e8e8 solid; width: 49%; float: right; margin: 10px 0px 10px 0px">
                <div style="border-bottom: 1px #e8e8e8 solid; background-color: #f3f3f3; padding: 8px; font-size: 13px; font-weight: 700; color: #45484d;">
                    ESTATUS DE ALERTAS
                </div>
                <div style="padding: 8px; font-size: 13px;">
                   
               </div>
            </div>

            <br />
            <br />

            <div style="border: 1px #e8e8e8 solid; width: 100%; float: right; margin: 10px 0px 10px 0px">
                <div style="border-bottom: 1px #e8e8e8 solid; background-color: #f3f3f3; padding: 8px; font-size: 13px; font-weight: 700; color: #45484d;">
                    CONTROL DE PROSPECTOS
                </div>
                <div style="padding: 8px; font-size: 13px;">
        <h4 style="text-align:center">INFORMACIÓN GENERAL</h4>
      <input id="txtdpi"style="margin-left:1%;" placeholder="DPI" type="text" tabindex="1" class="inputscortos"  autofocus/>
      <input id="txtnombrecompleto" style="margin-left:2%;" placeholder="Nombre Completo" type="text" tabindex="2" class="inputslargos"  autofocus/>
      <input id="txttelefono" style="margin-left:2%;" placeholder="Teléfono" type="text" tabindex="3" class="inputscortos"  autofocus/>
     <input id="txtemail" style="margin-left:2%;" placeholder="Correo electrónico" type="text" tabindex="4" class="inputslargos"  autofocus/>
     <div style="border: 1px #e8e8e8 solid; width: 30%; float: left; margin: 10px 0px 10px 0px">
         <%-- AREA DE INGRESOS --%>           
         <h4 style="text-align:center" >ÁREA DE INGRESOS</h4>
    <input id="txtingreso" style="margin-left:3%; width:40%" placeholder="Q - Ingresos" type="text" tabindex="5" class="inputscortos"  autofocus/>
     <input id="txtegresos" style="margin-left:3%; width:40%" placeholder="Q - Egresos" type="text" tabindex="6" class="inputscortos"  autofocus/>
     </div>
   <div style="border: 1px #e8e8e8 solid; width: 68%; float: right; margin: 10px 0px 10px 0px">
       <%-- AREA DE EMPLEADOS --%>
     <h4 style="text-align:center" >ÁREA DE EMPLEO</h4>
    <input id="txtañoslaborados" style="margin-left:9%; width:18%; " placeholder="Años laborados" type="text" tabindex="7" class="inputscortos"  autofocus/>
       <asp:DropDownList ID="combotienetrabajo" runat="server" style="margin-left:1%; width:24%;" TabIndex="8" CssClass="inputscortos">
            <asp:ListItem Text="¿Trabaja actualmente?" Value="0"></asp:ListItem>  
             <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="2"></asp:ListItem>
       </asp:DropDownList>
       <input id="txttabajoactual" style="margin-left:1%; width:33%" placeholder="Trabajo actual" type="text" tabindex="9" class="inputscortos"  autofocus/>
     </div>
 <div style="border: 1px #e8e8e8 solid; width: 100%; margin: 10px 0px 10px 0px">
<%-- AREA DE SEGUIMIENTOS --%>
     <h4 style="text-align:left" >Área de segumiento</h4>
     <asp:DropDownList ID="combotiposervicio" runat="server" style="margin-left:1%; width:12%;" TabIndex="8" CssClass="inputscortos">
      <asp:ListItem Text="Tipo de servicio" Value="0"></asp:ListItem>  
         </asp:DropDownList>
      <input id="txtmonto" style="margin-left:1%; width:8%; " placeholder="Q - Monto" type="text" tabindex="10" class="inputscortos"  autofocus/>
            <select id="combofinalidaddeservicio" runat="server" style="margin-left:1%; width:24%;" class="inputscortos">
            <option value="0">Seleccione la finalidad del servicio </option>
           </select> 
           <asp:DropDownList ID="combocontactollamadas" runat="server" style="margin-left:1%; width:18%;" TabIndex="8" CssClass="inputscortos">
      <asp:ListItem Text="Estado de la llamada" Value="0"></asp:ListItem>  
               </asp:DropDownList>
      <input id="txtfechainicio" style="margin-left:2%; width:13%; " type="date" tabindex="10" class="inputscortos"  autofocus/>
    <input id="txtfechafin" style="margin-left:2%; width:13%; " type="date" tabindex="10" class="inputscortos"  autofocus/>
   <hr style="border:groove" />   
     <asp:DropDownList ID="combosemaforoestado" runat="server" style="margin-left:21%; width:15%;" TabIndex="8" CssClass="inputscortos">
         <asp:ListItem Text="Seleccione el color" Value="0"></asp:ListItem>  
         </asp:DropDownList>
     <asp:TextBox style="margin-left:2%;"  Width="30px" Height="30px" ID="txtcolorestado" Enabled="false" runat="server"></asp:TextBox>
       <asp:DropDownList ID="combosemaforodescripcion" runat="server" style="margin-left:10%; width:21%; text-align:center;" TabIndex="8" CssClass="inputscortos">
     <asp:ListItem Text="Motivo del estado" Value="0"></asp:ListItem>  
           </asp:DropDownList>
      <hr style="border:groove" />   
     
       <h4 style="text-align:center" >INFORMACIÓN ADCIONAL</h4>
         <asp:DropDownList ID="combocuentaigss" runat="server" style="margin-left:2%; width:14%;" TabIndex="8" CssClass="inputscortos">
       <asp:ListItem Text="¿Cuenta con IGSS?" Value="0"></asp:ListItem>  
         </asp:DropDownList>
       <asp:DropDownList ID="combotipodomicilio" runat="server" style="margin-left:2%; width:15%;" TabIndex="8" CssClass="inputscortos">
       <asp:ListItem Text="Tipo del domicilio" Value="0"></asp:ListItem> 
       </asp:DropDownList>
      <input id="txtañodomicilio" style="margin-left:1%;" placeholder="¿Años de residencia?" type="text" tabindex="10" class="inputscortos"  autofocus/>
      <asp:DropDownList ID="comboposeecuentacoope" runat="server" style="margin-left:2%; width:20%;" TabIndex="8" CssClass="inputscortos">
      <asp:ListItem Text="¿Posee cuenta en cooperativa?" Value="0"></asp:ListItem>  
      </asp:DropDownList> 
     <asp:DropDownList ID="combosucursalmascerca" runat="server" style="margin-left:2%; width:22%;" TabIndex="8" CssClass="inputscortos">
      <asp:ListItem Text="¿Sucursal más cercana?" Value="0"></asp:ListItem>    
     </asp:DropDownList>
     <%-- AREA DE COMENTARIOS / DESCRIPCIÓN --%>
<div class="form-group" style="float">
  <textarea class="form-control rounded-0" style="width:95%; margin-left:28px; text-align:center;" placeholder="Descripción" id="exampleFormControlTextarea1" rows="5"></textarea>
</div>
</div>
                    <%-- AREA DEL GRIDVIEW --%>
          <center>
             <div>
                 <asp:FileUpload ID="FileUpload1" runat="server" />
                 <asp:Button ID="btncargardatos" runat="server" Text="Button" OnClick="btncargardatos_Click"></asp:Button>
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"></asp:Button>
              <h4>GRIDVIEW</h4>
                </div>
    <asp:Label ID="lblOculto" runat="server" Text="" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GridView1" runat="server" Height="251px" Width="420px">
    </asp:GridView>
                </div>
          </center>
      
      </div>
      </div>

        </div>
        <!-- partial -->
        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../../CRM-Script/Script.js" type="text/javascript"></script>

    </form>

</body>
</html>