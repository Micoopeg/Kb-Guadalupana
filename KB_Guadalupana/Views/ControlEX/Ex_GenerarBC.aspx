<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_GenerarBC.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_GenerarBC1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
      <%--  <asp:Button ID="btnGenerar" runat="server" Text="buscar" Width="154px" OnClick="btngenerar_Click"/>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%>

         <asp:Button ID="generarcaratula" runat="server" Text="Generar Caratula" Width="154px" OnClick="generarcaratula_Click"/>
              <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Numero de crédito" ></asp:Label>


         <div class="form-group"> 
              <asp:Button ID="btncambio" runat="server" Text="Cambiar estado" Width="154px" OnClick="btncambio_Click"/>
             <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Numero de crédito" ></asp:Label>
                     <br />
                  <span id="span4" runat="server" style="font-size:15px">Estado </span> <asp:DropDownList ID="estatus" runat="server" CssClass="dis" AutoPostBack="true" Width="160px" ></asp:DropDownList>
             <br />
                <span id="span1" runat="server" style="font-size:15px">Etapa </span> <asp:DropDownList ID="etapa" runat="server" CssClass="dis" AutoPostBack="true" Width="160px" ></asp:DropDownList>
     
           </div>
            
    </form>
</body>
</html>
