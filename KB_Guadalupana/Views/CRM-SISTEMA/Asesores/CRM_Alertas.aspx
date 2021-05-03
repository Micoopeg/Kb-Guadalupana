<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Alertas.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Asesores.CRM_Alertas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title>CRM - GUADALUPANA</title>
        <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css'/>
    <link rel="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
      <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Montserrat:300,400,700'/>
	 <link rel="stylesheet" href="../../../CRM-Estilos/Estilosalertas.css" type="text/css" />


</head>
<body>
    <form id="form1" runat="server">
		<header style="background-color:#69a43c;height:50px;margin-top:-16px">
               
                        <div class="col" style=" text-align:left;height:43px">
                                <asp:Button ID="btnmenuprincipal" style="text-align:center;font-size:20px;margin-left:-12px;" Height="100%" Width="100%" BackColor="#69a43c" runat="server" Text="Catálogo de prospecto" BorderStyle="None" OnClick="btnmenuprincipal_Click" />                            
                        </div>

                        <div class="col">
                            
                        </div>


               
	</header>
       <div>
		     <h1>Alertas programadas para el día de hoy</h1>
		 <div class="wrapper">
  <div class="cols">
           <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
 
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://unsplash.it/500/500/)">
						<div class="inner">
							<p>¡Alerta!</p>
              <span><asp:Label ID ="lbl1" runat="server" Text='<%# Eval("crmalertas_programadasnobre") %>'></asp:Label></span>
						</div>
					</div>
					<div class="back">
						<div class="inner">
						  <span><asp:Label ID ="Label1" runat="server" Text='<%# Eval("crmalertas_programadasdescripcion") %>'></asp:Label></span>
						</div>
					</div>
				</div>
			</div>	                    
                </ItemTemplate>
            </asp:Repeater>
	  		</div>
 </div>
       </div>
    </form>
</body>
</html>
