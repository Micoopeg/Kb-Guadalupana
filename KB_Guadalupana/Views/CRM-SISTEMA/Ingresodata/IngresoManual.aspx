<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoManual.aspx.cs" Inherits="KB_Guadalupana.Views.CRM_SISTEMA.Ingresodata.IngresoManual" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRM-Ingreso de datos </title>
     <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
   <link rel="stylesheet" type="text/css" href="../../../CRM-Estilos/estiloparamantenimientos.css" />
    <link rel="stylesheet" type="text/css" href="../../../CRM-Estilos/estiloparamodal.css" />
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
            <span>*DPI:</span><asp:TextBox style="margin-left:154px" ID="TextBox2" onkeypress="return solonumeros(event)" TabIndex="2" placeholder="DPI" runat="server"></asp:TextBox>
            <br />
            <span>*Nombre Completo:</span><asp:TextBox style="margin-left:61px" ID="TextBox5" onkeypress="return soloLetras(event)" TabIndex="5" placeholder="Nombre Completo" runat="server"></asp:TextBox>
            <br />
            <span>*Tipo de servicio:</span><asp:TextBox style="margin-left:55px" Text="1" onkeypress="return solonumeros(event)" ID="TextBox8" TabIndex="8" placeholder="Tipo de servicio"  runat="server"></asp:TextBox>
            <br />           
            <span>*Teléfono:</span><asp:TextBox style="margin-left:116px" ID="TextBox14" onkeypress="return solonumeros(event)" MaxLength="8" TabIndex="14" placeholder="Teléfono" runat="server"></asp:TextBox>
            <br />
            <span>*Correo:</span><asp:TextBox style="margin-left:131px" ID="TextBox15" TabIndex="15" placeholder="Correo"  runat="server"></asp:TextBox>
            <br />
            <span>*Monto:</span><asp:TextBox style="margin-left:140px" onkeypress="return solonumeros(event)" ID="TextBox18" TabIndex="18" placeholder="Monto"  runat="server"></asp:TextBox>
            <br />
            <span>*Contactado por:</span><asp:TextBox style="margin-left:70px" onkeypress="return soloLetras(event)" ID="TextBox29" TabIndex="29"  placeholder="contactado por"  runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
            <asp:LinkButton ID="btnguardar" style="margin-left:435px; margin-top:-252px" Width="123px" runat="server" class="btn btn-primary form-control" TabIndex="30" type="submit" OnClick="btnguardar_Click"> Guardar</asp:LinkButton>
            
        </div>
    </form>
    <script type="text/javascript" src="../../../CRM-Script/Script.js"></script>
</body>
</html>
