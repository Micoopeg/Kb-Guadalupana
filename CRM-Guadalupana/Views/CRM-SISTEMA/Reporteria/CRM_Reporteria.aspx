<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Reporteria.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Reporteria.CRM_Reporteria" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <center>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" style="max-width:937px" Width="100%"></rsweb:ReportViewer>
            </center>
                <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>

        </div>
    </form>
    
</body>
</html>
