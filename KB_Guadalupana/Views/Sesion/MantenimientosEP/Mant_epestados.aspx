<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mant_epestados.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.MantenimientosEP.Mant_epestados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mantenimiento Cambio De Estado</title>
     <link rel="shortcut icon" href="../../../Imagenes/Imagenes/KB.PNG"/>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
   <link rel="stylesheet" type="text/css" href="../../../CRM-Estilos/estiloparamantenimientos.css" />
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
        <div>
            <hr />
            <center>
            <asp:Label ID="lblcif" runat="server" Text="CIF:"></asp:Label><input type="text" runat="server" title="txtingreocif" onkeypress="return numeros(event);"  maxlength="9" id="txtingresocif"/>
            <span runat="server" id="lblcorrelativo">Correlativo:</span><input type="text" runat="server" title="txtxorrelativo" disabled="disabled" id="txtcorrelativo"/>
                <br />
                <br />
                <br />
                <asp:LinkButton class="btnepmant" ID="btncambiar" runat="server" OnClick="btncambiar_Click">Buscar</asp:LinkButton>            
               
            <br />
            <span id="lblcambioestado" runat="server">Cambio de estado:</span>
            <select runat="server" id="comboestado" style="color:black">
                <option value="2">EN PROCESO</option>
                <option value="3">CONFIRMADO</option>
             </select>
            <asp:LinkButton  CssClass="btnepmant" ID="btnefectuar" runat="server" OnClick="btnefectuar_Click" >Cambiar</asp:LinkButton>
            <br />
            <span runat="server" id="lblerror"></span>
                 </center>
        </div>
    </form>
        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../../CRM-Script/Script.js" type="text/javascript"></script>
</body>
</html>
