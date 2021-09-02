<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Dashboard.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Dashboard.CRM_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRM-Dashboard</title>
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
                                <asp:Button ID="btnmenuprincipal" style="text-align:center;color:white;" Width="100%" Height="100%" BackColor="#69a43c" runat="server" Text="  Menú principal" BorderStyle="None" OnClick="btnmenuprincipal_Click" />                            
                        </div>
                        <div class="col" style="width:940px">                            
                        </div>
                        <div class="col" style=" text-align:right" >
                         
                        </div>
                      
                    </div>       
        </div>
	</header>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">          
            <ContentTemplate>    
                           <div>
            <div class="ui-widget">
  <h1 class="ui-value">
      <asp:Label ID="lblaprobados" runat="server" Text="Label"></asp:Label></h1>
  <span class="ui-label"><a href="CRM_SubestadoAprobado">Aprobados</a></span>
</div>

            <div class="ui-widget">
  <h1 class="ui-value"><asp:Label ID="lblenproceso" runat="server" Text="Label"></asp:Label></h1>
  <span class="ui-label"><a href="CRM_SubestadoProceso.aspx">En proceso</a></span>
</div>

            <div class="ui-widget">
  <h1 class="ui-value"><asp:Label ID="lblnocontestada" runat="server" Text="Label"></asp:Label></h1>
  <span class="ui-label"><a href="CRM_SubestadoNocontesta">No contesta</a></span>
</div>

            <div class="ui-widget">
  <h1 class="ui-value"><asp:Label ID="lblnoaplica" runat="server" Text="Label"></asp:Label></h1>
  <span class="ui-label"><a href="CRM_SubestadoNoaprobado">No aplica</a></span>
</div>

        </div>
                </ContentTemplate>
                      <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>

  <div class="container">
  <div class="row">
    <div class="col-sm-6" >
      <h3>Gr&aacute;fica total de prospectos(%) </h3>
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
      <h3>Gr&aacute;fica por agencia(%)</h3>  
        <asp:DropDownList ID="comboagencias" OnSelectedIndexChanged="seleccionagencia_SelectedIndexChanged" AutoPostBack="true" Width="75%" runat="server" style="text-align-last: center; text-align:center">
            <asp:ListItem Value="0">Seleccione una agencia</asp:ListItem>


        </asp:DropDownList>
        <center>
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
<img src="../../../Imagenes/f_logo.svg" width="28%"/>
<p style="font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">
    OFICINAS CENTRALES · 14 Avenida 1-65 Zona 14, Ciudad de Guatemala, GT 01014
    <br />
    ©2019. Cooperativa Guadalupana. Reservados Todos los Derechos.</p>
                </center>
</footer>
    </form>
</body>
</html>
