<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prospectosrechazados.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Catalogo_clientes.Prospectosrechazados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRM-Prospecto rechazados</title>
        <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>
    <!--Load the AJAX API-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <link rel="stylesheet" href="../../../CRM-Estilos/Estiloparagraficas.css" />
    <link rel="stylesheet" href="../../../CRM-Estilos/EstiloGridClientes.css" />
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .seleccionarcelulargridview{

        }
    </style>

</head>
<body style="background-color:#2c3e50">
    <form id="form1" runat="server">
        <header style="background-color:#69a43c">
  <div class="row">
    <div class="col-sm-4" >
        <asp:LinkButton ID="LinkButton1" class="btn btn-success" style=" background-color:#003561; border-radius:0px; border-color:#003561; text-decoration:none; width:100%" value="Menu Principal" type="button" runat="server" tabindex="25" name="Guardar" title="Guardar" OnClick="btnmenuprincipal_Click" >Menú Principal</asp:LinkButton>
    </div>
    <div class="col-sm-4">
        <center>
                  
        </center>
    </div>
         <div class="col-sm-4">
             <asp:LinkButton ID="LinkButton3" class="btn btn-success" style="background-color:#003561; text-decoration:none; border-color:#003561; border-radius:0px; width:100%" value="Cerrar sesion" type="button" runat="server" tabindex="25" name="Guardar" title="Cerrar sesion" OnClick="btnmenucerrar_Click"  >Cerrar Sesión</asp:LinkButton>
    </div>
  </div>
        </header>

            <br />

            <%-- Inicio de los textbox --%>
                <%-- GRIDVIEW NUMEROS DE TELEFONO --%>
            <asp:Label ID="lblcriterio" style="color:white" runat="server" Text="Buscar:"></asp:Label>
            <input id="txtnombrecompleto"  style="margin-left:2%;" placeholder="Criterio de búsqueda" runat="server" type="text" tabindex="1" autofocus/>
            <asp:DropDownList TabIndex="2" ID="comboagencia" style="height:25px" runat="server" name="agencia" placeholder="[AGENCIA]" required="required">
             </asp:DropDownList>
            <asp:LinkButton ID="btnbuscar" style="color:white" runat="server" OnClick="btnbuscar_Click">Buscar</asp:LinkButton>
            <br />
            <br />
        <div id="divgridviewprospectos1" style="overflow: auto; height: 147px">
     <asp:GridView ID="gridviewprospectos" CssClass="container"  style="width: 692px;  text-align:center" runat="server"  HeaderStyle-ForeColor="Black"
    AutoGenerateColumns="False" OnSelectedIndexChanged="OnSelectedIndexChangedprospectos" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. Lead" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodprospeto" Text='<%# Eval("codcrminfoprospecto") %>' runat="server" />
                        </ItemTemplate>

<ControlStyle CssClass="dise&#241;o"></ControlStyle>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. DPI" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lbltipotelefono" Text='<%# Eval("crminfogeneral_prospectodpi") %>' runat="server" />
                        </ItemTemplate>

<ControlStyle CssClass="dise&#241;o"></ControlStyle>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre completo">
                           <ItemTemplate>
                            <asp:Label ID="lblnombretelefono" Text='<%# Eval("crminfogeneral_prospectonombrecompleto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarcelulargridview icon-prev"  CommandName="Select" ItemStyle-Width="150">
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>
             
            </div>   
     <asp:GridView ID="gridview1" CssClass="container"  style="width: 90%;  text-align:center" runat="server"  HeaderStyle-ForeColor="Black"
    AutoGenerateColumns="False" OnSelectedIndexChanged="OnSelectedIndexChangedprospectos" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Tipo de servicio" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono" Text='<%# Eval("crmtipo_servicionombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Finalidad" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono" Text='<%# Eval("crm_finalidaddescripcion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Estado de llamada" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono" Text='<%# Eval("crmcontacto_llamadasnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Estado de semáforo" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono" Text='<%# Eval("crmsemaforo_estadodescripcion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Descripción de estado" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono" Text='<%# Eval("crmestado_descripcionnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Monto" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono" Text='<%# Eval("crminfo_prospectomonto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>                        
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>
               <br />
     <asp:GridView ID="gridview2" CssClass="container"  style="width: 90%; text-align:center" runat="server"  HeaderStyle-ForeColor="Black"
    AutoGenerateColumns="False" OnSelectedIndexChanged="OnSelectedIndexChangedprospectos" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Tipo de domicilio" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono1" Text='<%# Eval("crmtipo_domicilionombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="¿Años de domicilio?" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lbltipotelefono2" Text='<%# Eval("crminfo_prospectoañosdomicilio") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Número de teléfono">
                           <ItemTemplate>
                            <asp:Label ID="lblnombretelefono3" Text='<%# Eval("crminfo_prospectotelefono") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Correo electrónico">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotelefono4" Text='<%# Eval("crminfo_prospectoemail") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>    
                      <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Ingresos">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotelefono5" Text='<%# Eval("crminfo_prospectoingresos") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Egresos">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotelefono6" Text='<%# Eval("crminfo_prospectoegresos") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>      
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>
                    <br />
     <asp:GridView ID="gridview3" CssClass="container"  style="width: 90%; text-align:center" runat="server"  HeaderStyle-ForeColor="Black"
    AutoGenerateColumns="False" OnSelectedIndexChanged="OnSelectedIndexChangedprospectos" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="¿Años laborados?" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono1" Text='<%# Eval("crminfo_prospectoañoslaborados") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="¿Trabaja actualmente?" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lbltipotelefono2" Text='<%# Eval("crminfo_prospectotrabajaactualmente") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Descripción del trabajo actual">
                           <ItemTemplate>
                            <asp:Label ID="lblnombretelefono3" Text='<%# Eval("crminfo_prospectodescripciontrabajoactual") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>                          
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>
                    <br />
     <asp:GridView ID="gridview4" CssClass="container"  style="width: 90%; text-align:center" runat="server"  HeaderStyle-ForeColor="Black"
    AutoGenerateColumns="False" OnSelectedIndexChanged="OnSelectedIndexChangedprospectos" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Primer contacto" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono1" Text='<%# string.Format("{0: yyyy-MM-dd}",Eval("crminfo_prospectofechaprimerllamada")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Ultimo contacto" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lbltipotelefono2"  Text='<%# string.Format("{0: yyyy-MM-dd}",Eval("crminfo_prospectofechaultimallamada")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Comentarios de prospecto">
                           <ItemTemplate>
                            <asp:Label ID="lblnombretelefono3" Text='<%# Eval("crminfo_prospectodescripcion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Sucursal Cercana">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotelefono4" Text='<%# Eval("crminfo_prospectosucursalcerca") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>         
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>
         <br />
     <asp:GridView ID="gridview5" CssClass="container"  style="width: 90%; text-align:center" runat="server"  HeaderStyle-ForeColor="Black"
    AutoGenerateColumns="False" OnSelectedIndexChanged="OnSelectedIndexChangedprospectos" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="¿Cuenta con IGSS?" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono1" Text='<%# Eval("crminfo_prospectocuentaconigss") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="¿Tiene cuenta en cooperativa?" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lbltipotelefono2"  Text='<%# Eval("crminfo_prospectocuentaencooperativa") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Contactado por">
                           <ItemTemplate>
                            <asp:Label ID="lblnombretelefono3" Text='<%# Eval("crminfo_contactadopor") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="DPI de referencia">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotelefono4" Text='<%# Eval("crminfo_prospectoreferenciado") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                          <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Agencia">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotelefono5" Text='<%# Eval("crmcontrol_ingresosucursal") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Usuario Asignado">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotelefono6" Text='<%# Eval("crmcontrol_ingresousuario") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>
             
         
                <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../../CRM-Script/Script.js" type="text/javascript"></script>
    </form>
</body>
</html>
