<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Dashboard.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Dashboard.CRM_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRM-Dashboard</title>
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
  <div class="row">
    <div class="col-sm-4" >
        <asp:LinkButton ID="LinkButton1" class="btn btn-success" style=" text-decoration:none; width:100%" value="Menu Principal" type="button" runat="server" tabindex="25" name="Guardar" title="Guardar" OnClick="btnmenuprincipal_Click" >Menu Principal</asp:LinkButton>
    </div>
    <div class="col-sm-4">
        <center>
                  
        </center>
    </div>
         <div class="col-sm-4">
             <asp:LinkButton ID="LinkButton3" class="btn btn-success" style=" text-decoration:none; width:100%" value="Cerrar sesion" type="button" runat="server" tabindex="25" name="Guardar" title="Cerrar sesion"  >Cerrar Sesion</asp:LinkButton>
    </div>
  </div>
        </header>
        <div>
            <div class="ui-widget">
  <h1 class="ui-value">
      <asp:Label ID="lblaprobados" runat="server" Text="Label"></asp:Label></h1>
  <span class="ui-label">Aprobados</span>
</div>

<div class="ui-widget">
  <h1 class="ui-value"><asp:Label ID="lblenproceso" runat="server" Text="Label"></asp:Label></h1>
  <span class="ui-label">En proceso</span>
</div>

<div class="ui-widget">
  <h1 class="ui-value"><asp:Label ID="lblnocontestada" runat="server" Text="Label"></asp:Label></h1>
  <span class="ui-label">No contesta</span>
</div>

<div class="ui-widget">
  <h1 class="ui-value"><asp:Label ID="lblnoaplica" runat="server" Text="Label"></asp:Label></h1>
  <span class="ui-label">No aplican</span>
</div>

        </div>
  <div class="container">
  <div class="row">
    <div class="col-sm-6" >
      <h3>Gr&aacute;fica total de prospectos </h3>
       <center>
      <asp:Chart  ID="Chart1" style="margin-top:15px" runat="server" canresize="true"  Palette="None" AlternateText="El grafico no se puede carga por la conexion a internet" BorderlineColor="Black" PaletteCustomColors="Yellow; 255, 128, 0; 192, 0, 0; 0, 192, 0" Width="280px">  
            <series>  
                <asp:Series Name="Series1" ChartType="Pie" Legend="Legend1" LabelBackColor="White" >  
                </asp:Series>   
                <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Series2" ChartType="Pie">
                </asp:Series>
            </series>    
            <chartareas>  
                <asp:ChartArea Name="ChartArea1">  
                </asp:ChartArea>  
            </chartareas>  
                              <Legends>
                                  <asp:Legend Name="Legend1">
                                  </asp:Legend>
                              </Legends>
                              <BorderSkin BackColor="Transparent" />
        </asp:Chart>              
                        </center>
    </div>
   
    <div class="col-sm-6">
      <h3>Gr&aacute;fica por agencia</h3>  
        <asp:DropDownList ID="combosucursales" Width="75%" runat="server" style="text-align-last: center;">
            <asp:ListItem Value="0" >Seleccione una agencia</asp:ListItem>
            <asp:ListItem Value="1" >Central</asp:ListItem>

        </asp:DropDownList>
     <asp:Chart  ID="Chart2" runat="server" canresize="true"  Palette="None" AlternateText="El grafico no se puede carga por la conexion a internet" BorderlineColor="Black" PaletteCustomColors="Yellow; 255, 128, 0; 192, 0, 0; 0, 192, 0" Width="280px">  
            <series>  
                <asp:Series Name="Series1" ChartType="Pie" Legend="Legend1" LabelBackColor="White" >  
                </asp:Series>   
                <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Series2" ChartType="Pie">
                </asp:Series>
            </series>    
            <chartareas>  
                <asp:ChartArea Name="ChartArea1">  
                </asp:ChartArea>  
            </chartareas>  
                              <Legends>
                                  <asp:Legend Name="Legend1">
                                  </asp:Legend>
                              </Legends>
                              <BorderSkin BackColor="Transparent" />
        </asp:Chart>              
                        </center>
    </div>
  </div>
</div>

        
        <footer style="margin-top:-216px">
            <center>
<img src="../../../Imagenes/f_logo.svg" width="28%">
<p style="font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">
    OFICINAS CENTRALES · 14 Avenida 1-65 Zona 14, Ciudad de Guatemala, GT 01014
    <br />
    ©2019. Cooperativa Guadalupana. Reservados Todos los Derechos.</p>
                </center>
</footer>
    </form>
</body>
</html>
