<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reasignar_prospecto.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Administracion.Reasignaciones.Reasignar_prospecto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css'/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="../../../../CRM-Estilos/Estilo_botones.css" />
    <link rel="stylesheet" href="../../../../CRM-Estilos/Estiloscombos.css" />
   <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <title>CRM - GUADALUPANA</title>
        <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>

    <style type="text/css">
        .img-fluid {
            height: 107px;
            width: 124px;
        }
    </style>
</head>
<body style="background-color:#2c3e50">
    <form id="form1" runat="server">
<header style="background-color:#69a43c">      
    <div class="container">   
        <div class="row">
                        <div class="col" style=" text-align:left;height:43px">
                                <asp:Button ID="btnmenuprincipal" style="text-align:left;color:white;" Height="100%" Width="100%" BackColor="#69a43c" runat="server" Text="  Menú principal" BorderStyle="None" OnClick="btnmenuprincipal_Click" />                            
                        </div>
                        <div class="col" style="width:940px">                            
                        </div>
                        <div class="col" style=" text-align:right" >
                         <asp:Button ID="asignarleed" Visible="true" style="text-align:right;color:white;" BackColor="#69a43c" Width="100%" Height="100%" runat="server" Text="Asignar Lead" BorderStyle="None" OnClick="btnasignarleed_Click" />                    
                        </div>
                      
                    </div>       
        </div>
	</header>
        <br />
        <div class="container">
    <div class="col-sm-6" >
        <asp:CheckBox ID="chkagenica" style="color:white;" runat="server" AutoPostBack="true" OnCheckedChanged="chkagenica_CheckedChanged" Text="TRANSEFERENCIA AGENCIA HACIA AGENCIA" />
    </div>   
    <div class="col-sm-6">
    <asp:CheckBox ID="chkagente" style="color:white;margin-left:10%; text-align:right"  runat="server"  AutoPostBack="true"  OnCheckedChanged="chkagente_CheckedChanged" Text="TRANSFERENCIA AGENTE HACIA AGENTE" />
    </div>
            </div>                  
        <br />
        <center>
        <div style="color:black;background-color:white;width:45%;border-radius:11px;text-align:center;height:300px">
      <asp:Label ID="lblerror" runat="server" Text="Error" Visible="false"></asp:Label>
            <asp:DropDownList ID="comboagenciadar" runat="server" CssClass="custom-dropdown big">
            <asp:ListItem Value="0">Agencia fuente</asp:ListItem>
            <asp:ListItem Value="central">Central</asp:ListItem>
        </asp:DropDownList>
            <br />
            <br />
          <asp:DropDownList  ID="comboagenciarecibir" runat="server" CssClass="custom-dropdown big" >
            <asp:ListItem Value="0">Agencia destino</asp:ListItem>
            <asp:ListItem Value="central">Central</asp:ListItem>
        </asp:DropDownList>
        <br />
     <asp:DropDownList ID="comboagenciaagentedar" AutoPostBack="true" OnSelectedIndexChanged="comboagenciaagentedar_SelectedIndexChanged" runat="server"  CssClass="custom-dropdown big">
            <asp:ListItem Value="0">Seleccione una agencia</asp:ListItem>
            <asp:ListItem Value="central">Central</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="comboagentedar"  runat="server" CssClass="custom-dropdown big">
            <asp:ListItem Value="0">Seleccione un agente</asp:ListItem>
        </asp:DropDownList>
           <asp:DropDownList ID="comboagenciaegenterecibir" AutoPostBack="true" OnSelectedIndexChanged="comboagenciagenterecibir_SelectedIndexChanged" runat="server" CssClass="custom-dropdown big">
            <asp:ListItem Value="0">Seleccione una agencia</asp:ListItem>
            <asp:ListItem Value="central">Central</asp:ListItem>
        </asp:DropDownList>
             <asp:DropDownList ID="comboagenterecibir" runat="server" CssClass="custom-dropdown big">
            <asp:ListItem Value="0">Seleccione un agente</asp:ListItem>
        </asp:DropDownList>
        <br />
             <asp:Label ID="lblaceptar" runat="server" Text="Error" Visible="false"></asp:Label>
        </div>
            </center>
        <br />
        <center>
            <asp:LinkButton CssClass="btn btn-4" ID="btnaceptar" runat="server" OnClick="btnaceptar_Click">Aceptar</asp:LinkButton>
        </center>
        
    </form>
</body>
</html>
