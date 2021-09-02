<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="controlCRM.aspx.cs" Inherits="KB_Guadalupana.Views.MantenimientosControl.controlCRM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRM-Usuarios</title>
     <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
   <link rel="stylesheet" type="text/css" href="../../CRM-Estilos/estiloparamantenimientos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <center>
            <div id="menup">
                <asp:LinkButton ID="btnmenuprincipal" runat="server" class="btn btnmenuprincipal" OnClick="btnmenuprincipal_Click" >Menuprincipal</asp:LinkButton>
            </div>
                </center>
        </header>
<div class="container">
  <div class="row">
    <div class="col-md-4">
      <h3>Control de usuarios</h3>
      <form id="datos" action="">
          <asp:LinkButton ID="btnnuevoingreso" Width="100%" runat="server" class="btn btn-primary form-control" type="submit" style="background-color:#69a43c; color:white;" OnClick="btnnuevoingreso_Click"><span>*</span>Nuevo Ingreso</asp:LinkButton>
        <div class="form-group">
         <span>Correlativo: </span> <input id="txtcodigo" onkeypress="return numeros(event);" disabled="disabled" runat="server" class="form-control" type="text" name="codigo" placeholder="Correlativo" required="required" tabindex="1" autofocus="autofocus"  />        
            </div>
           <div class="form-group">
         <span>Agencia: </span> 
               <asp:DropDownList TabIndex="2" ID="comboagencia" runat="server" class="form-control" name="agencia" placeholder="[AGENCIA]" required="required">
               </asp:DropDownList>
            </div>
           <div class="form-group">
         <span>Usuario:</span>
          <asp:DropDownList TabIndex="3" ID="combousuario" runat="server" class="form-control" name="Usuario" placeholder="[Usuario]" required="required">
           </asp:DropDownList>
        </div>
           <div class="form-group">
         <span>Roles:</span>
          <asp:DropDownList TabIndex="4" ID="comboroles" runat="server" class="form-control" name="Roles" placeholder="[Roles]" required="required">
          <asp:ListItem Value="0">Seleccione un rol</asp:ListItem> 
          <asp:ListItem Value="1">Ingreso de datos</asp:ListItem> 
          <asp:ListItem Value="2">Jefes</asp:ListItem> 
          <asp:ListItem Value="3">Asesores</asp:ListItem>  
          <asp:ListItem Value="4">Area administrativa</asp:ListItem>  
          <asp:ListItem Value="5">Jefe de agencia</asp:ListItem>  
          <asp:ListItem Value="7">Coordinador de agencia</asp:ListItem> 
          </asp:DropDownList>
        </div>
          <div>
              <asp:LinkButton ID="btnmodificar" Width="100%" runat="server" class="btn btn-primary form-control" type="submit" OnClick="btnmodificar_Click"> Modificar</asp:LinkButton>
              <asp:LinkButton ID="btnguardar" Width="100%" runat="server" class="btn btn-primary form-control" type="submit" OnClick="btnguardar_Click"> Guardar</asp:LinkButton>
          </div>          
      </form>
    </div>     
    <div class="col-md-8">
      <h3>REGISTROS</h3>
        <asp:Label runat="server">Nombre de usuario:</asp:Label><input id="txtbusqueda" placeholder="BUSCAR POR NOMBRE" style="margin-left:2%" runat="server" /><asp:LinkButton runat="server" style="margin-left:2%; border-style:none; color:white" ID="btnbuscar" OnClick="btnbuscar_Click">Buscar</asp:LinkButton><br />
         <asp:GridView ID="gridviewmant" CssClass="table table-striped"  runat="server" HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedmantenimiento" BorderStyle="Solid" Width="100%" AllowPaging="True" OnPageIndexChanging="gridviewmantenimiento_PageIndexChanging" PageSize="6" >                 
                     <Columns>
                         <asp:TemplateField HeaderText="Correlativo" Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblcodigousuario" Text='<%# Eval("codcrmcontrolingreso") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Agencia">
                           <ItemTemplate>
                            <asp:Label ID="lblagencia" Text='<%# Eval("crmcontrol_ingresosucursal") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>  
                <asp:TemplateField HeaderText="Nombre de usuario">
                           <ItemTemplate>
                            <asp:Label ID="lblusuario" Text='<%# Eval("crmcontrol_ingresousuario") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="Rol asignado">
                           <ItemTemplate>
                            <asp:Label ID="lblrol" Text='<%# Eval("crmcontrol_ingresorol") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>  
                   <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarmantenimientogridview" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="20px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#0084F7" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
    </div>
  </div>
</div>
        <%-- Javascript --%>
        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../../../CRM-Script/Script.js" type="text/javascript"></script>
    </form>
</body>
</html>
