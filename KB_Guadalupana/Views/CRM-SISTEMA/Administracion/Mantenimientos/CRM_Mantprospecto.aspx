<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Mantprospecto.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Administracion.Mantenimientos.CRM_Mantprospecto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mantenimiento Clientes</title>
     <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
   <link rel="stylesheet" type="text/css" href="../../../../CRM-Estilos/estiloparamantenimientos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <center>
            <div id="menup">
                <asp:LinkButton ID="btnmenuprincipal" runat="server" class="btn btnmenuprincipal" OnClick="btnmenuprincipal_Click" >Menú principal</asp:LinkButton>
            </div>
                </center>
        </header>
<div class="container">
  <div class="row">
    <div class="col-md-4">
      <h3>Clientes</h3>
      <form id="datos" action="">
          <asp:LinkButton ID="btnnuevoingreso" Width="100%" runat="server" class="btn btn-primary form-control" type="submit" style="background-color:#69a43c; color:white;" OnClick="btnnuevoingreso_Click"><span>*</span>Nuevo Ingreso</asp:LinkButton>
        <div class="form-group">
            <input id="txtcodigo" visible="false" onkeypress="return numeros(event);" disabled="disabled" runat="server" class="form-control" type="text" name="codigo" placeholder="Correlativo" required="required" />
            </div>
        <div class="form-group">
         <span>Numero de DPI: </span> <input id="txtdpi" tabindex="1" onkeypress="return numeros(event);" runat="server" class="form-control" type="text" name="DPI" placeholder="DPI" maxlength="13" required="required" /><span style="text-align:center; color:orangered;" id="lbleror" runat="server"></span>
            </div>
        <div class="form-group">
         <span>Nombres: </span> <input  id="txtnombre" onkeypress="return soloLetras(event);" runat="server" tabindex="2"  class="form-control" type="text" name="nombres" placeholder="Nombres" required="required" />
        </div>
         <div class="form-group">
         <span>Apellidos: </span> <input  id="txtapellido" onkeypress="return soloLetras(event);" runat="server" tabindex="3" class="form-control" type="text" name="apellidos" placeholder="Apellidos" required="required" />
        </div>
       <div class="form-group">
         <span>Nombre completo: </span> <input  id="txtnombrecompleto" onkeypress="return soloLetras(event);" tabindex="4" runat="server"  class="form-control" type="text" name="nombre completo" placeholder="Nombre Completo" required="required" />
        </div>
       <div class="form-group">
         <input  id="txtlistanegra" visible="false" runat="server"  class="form-control" type="text" name="nombre" placeholder="Nombre" required="required" />
        </div>
          <div>
              <asp:LinkButton ID="btnmodificar" Width="100%" runat="server" class="btn btn-primary form-control" type="submit" OnClick="btnmodificar_Click"> Modificar</asp:LinkButton>
              <asp:LinkButton ID="btnguardar" Width="100%" runat="server" class="btn btn-primary form-control" type="submit" OnClick="btnguardar_Click"> Guardar</asp:LinkButton>
          </div>          
      </form>
    </div>     
    <div class="col-md-8">
      <h3>REGISTROS</h3>
        <asp:Label runat="server">Nombre de la persona:</asp:Label><input runat="server" id="txtbusqueda" placeholder="BUSCAR POR NOMBRE" style="margin-left:2%" /><asp:LinkButton runat="server" style="margin-left:2%; border-style:none; color:white" ID="btnbuscar" OnClick="btnbuscar_Click">Buscar</asp:LinkButton><br />
         <asp:GridView ID="gridviewmant" CssClass="table table-striped"  runat="server" HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedmantenimiento" BorderStyle="Solid" Width="100%" AllowPaging="True" OnPageIndexChanging="gridviewmantenimiento_PageIndexChanging" PageSize="3" >                 
                     <Columns>
                         <asp:TemplateField HeaderText="Correlativo" Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblcodigo" Text='<%# Eval("codcrminfogeneralprospecto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Número de DPI">
                           <ItemTemplate>
                            <asp:Label ID="lbldpi" Text='<%# Eval("crminfogeneral_prospectodpi") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Nombre">
                           <ItemTemplate>
                            <asp:Label ID="lblnombre" Text='<%# Eval("crminfogeneral_prospectonombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                      <asp:TemplateField HeaderText="Apellido">
                           <ItemTemplate>
                            <asp:Label ID="lblapellido" Text='<%# Eval("crminfogeneral_prospectoapellido") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Nombre Completo">
                           <ItemTemplate>
                            <asp:Label ID="lblnombrecompleto" Text='<%# Eval("crminfogeneral_prospectonombrecompleto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                       <asp:TemplateField HeaderText="Lista Negra" Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblblacklist" Text='<%# Eval("crminfogeneral_prospectoblacklist") %>' runat="server" />
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
