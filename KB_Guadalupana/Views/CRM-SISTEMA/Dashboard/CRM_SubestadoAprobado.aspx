<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_SubestadoAprobado.aspx.cs" Inherits="KB_Guadalupana.Views.CRM_SISTEMA.Dashboard.CRM_SubestadoAprobado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRM-Estados</title>
    <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>
    <!--Load the AJAX API-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <link rel="stylesheet" href="../../../CRM-Estilos/Estiloparagraficas.css" />
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
     <header style="background-color:#69a43c">      
    <div class="container">   
        <div class="row">
                        <div class="col" style=" text-align:center;height:43px">
                                <asp:Button ID="btnmenuprincipal" style="text-align:center;color:white;" Width="100%" Height="100%" BackColor="#69a43c" runat="server" Text="Regresar" BorderStyle="None" OnClick="btnmenuprincipal_Click" />                            
                        </div>
                        <div class="col" style="width:940px">                            
                        </div>
                        <div class="col" style=" text-align:right" >
                         
                        </div>
                      
                    </div>       
        </div>
	</header>
                   <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>

                    <div class="ui-widget">
                    <h3 class="ui-value">
                    <asp:Label ID="lblaprobados" runat="server" Text='<%# Eval("totalestado") %>'></asp:Label></h3>
                    <span class="ui-label"><asp:Label ID ="lbl1" runat="server" Text='<%# Eval("crmestado_descripcionnombre") %>'></asp:Label></span>
                        </div>

                </ItemTemplate>
                       </asp:Repeater>
    </form>
</body>
</html>

