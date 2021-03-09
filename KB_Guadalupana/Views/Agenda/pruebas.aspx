<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pruebas.aspx.cs" Inherits="KBGuada.Views.session.pruebas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        <asp:Button id="btnhacer" runat="server" ClientIDMode="AutoID" OnClick="btnhacer_Click" >      </asp:Button>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>


            <a> <h1 id="estado" runat="server">  </h1>   </a>
               

            </ContentTemplate>
            <Triggers>

                <asp:AsyncPostBackTrigger  ControlID="btnhacer" EventName="Click"     />
                
            </Triggers>


        </asp:UpdatePanel>

        

    </form>
</body>
</html>
