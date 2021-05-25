<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuMantenimientos.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.MantenimientosEP.MenuMantenimientos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menú Mantenimiento</title>
     <link rel="shortcut icon" href="../../../Imagenes/Imagenes/KB.PNG"/>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
   <link rel="stylesheet" type="text/css" href="../../../CRM-Estilos/estiloparamantenimientos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center> <h1><p>Mantenimientos</p></h1></center>                       
                <asp:LinkButton  style="text-decoration: none;" class="btnepmant" runat="server" ID="btnmantcambioestado" OnClick="btnmantcambioestado_Click">Cambio de estado</asp:LinkButton>
        </div>
    </form>
</body>
</html>
