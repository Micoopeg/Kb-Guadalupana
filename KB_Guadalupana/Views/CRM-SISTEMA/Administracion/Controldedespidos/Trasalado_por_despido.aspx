<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trasalado_por_despido.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Administracion.Controldedespidos.Trasalado_por_despido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario de despido</title>
     <link rel="shortcut icon" href="../../../../Imagenes/Logo.png"/>
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
<div class="container" >
  <div class="row">
    <div class="col-md-12">
      <h3>Control de despido</h3>
      <form id="datos" action="">  
          <center>
           <asp:CheckBox ID="chkadministrativo" AutoPostBack="true" Text="Administrativo" OnCheckedChanged="chkadministrativo_CheckedChanged" runat="server" />
           <asp:CheckBox ID="chkasesores" AutoPostBack="true" OnCheckedChanged="chkasesores_CheckedChanged" Text="Asesor" runat="server" />
           </center>
          <br />
              <div class="form-group">
              <center><asp:Label ID="lblerror" runat="server"></asp:Label></center>
         <span id="lblusuarioadm" runat="server">Usuario: </span>
               <asp:DropDownList TabIndex="1" ID="combousuarioadministrativo" runat="server" class="form-control" name="tiposervicio" placeholder="Usuario administrativo" required="required">
               </asp:DropDownList>
         <span id="lblagenciafuente" runat="server">Agencia Fuente: </span> 
               <asp:DropDownList TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="comboagenciafuente_SelectedIndexChanged" ID="comboagenciafuente" runat="server" class="form-control"  required="required">
               </asp:DropDownList>
         <span id="lblusuariofuente" runat="server">Usuario despedido: </span> 
               <asp:DropDownList TabIndex="2" ID="combousuariofuente" runat="server" class="form-control" name="tiposervicio" placeholder="usuario" required="required">
               </asp:DropDownList>
         <span id="lblagenciadestino" runat="server">Agencia Destino: </span> 
               <asp:DropDownList TabIndex="3" AutoPostBack="true" OnSelectedIndexChanged="comboagenciadestino_SelectedIndexChanged" ID="comboagenciadestino" runat="server" class="form-control" required="required">
               </asp:DropDownList>
         <span id="lblusuariodestino" runat="server">Usuario de traslado: </span> 
               <asp:DropDownList TabIndex="4" ID="combousuariodestino" runat="server" class="form-control" required="required">
               </asp:DropDownList>
            </div>
          <br />
          <div>              
              <asp:LinkButton ID="btndespedir" Width="100%" runat="server" class="btn btn-primary form-control" type="submit" OnClick="btnguardar_Click"> Despedir</asp:LinkButton>
          </div>          
      </form>
    </div>     
  </div>
</div>
        <%-- Javascript --%>
        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../../../CRM-Script/Script.js" type="text/javascript"></script>
    </form>
</body>
</html>
