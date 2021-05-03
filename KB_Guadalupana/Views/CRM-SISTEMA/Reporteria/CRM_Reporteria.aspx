<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Reporteria.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Reporteria.CRM_Reporteria" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reporteria</title>
     <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
   <link rel="stylesheet" type="text/css" href="../../../CRM-Estilos/estiloparamantenimientos.css"/>
    <link rel="stylesheet" type="text/css" href="../../../CRM-Estilos/EstiloReportes.css"/>
    
</head>
<body style="background-color:white">
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <header>
            <center>
            <div id="menup">
                <asp:LinkButton ID="btnmenuprincipal" runat="server" class="btn btnmenuprincipal" OnClick="btnmenuprincipal_Click" >Menú principal</asp:LinkButton>
            </div>
                </center>
        </header>
        <%-- diseño --%>
        <h3 style="width:190px">Filtros</h3>
                <div class="container">
                    <center>
                    <span>Fecha:</span>
            <input type="date" id="fechainicio" runat="server" name="fecha-inicio" />
            <input type="date" id="fechafin" runat="server" name="fecha-fin" />                        
                    </center>
                    <br /><br />
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chktiposervicio" style="color:black;" OnCheckedChanged="chktiposervicio_CheckedChanged" runat="server" AutoPostBack="true" Text="Tipo de servicio" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chkestadosemaforo" style="color:black;" runat="server" AutoPostBack="true" Text="Estado semáforo" OnCheckedChanged="chkestadosemaforo_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chkdescripcionsemaforo" style="color:black;" runat="server" AutoPostBack="true" Text="Descripción del semáforo" OnCheckedChanged="chkdescripcionsemaforo_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chktipodomicilio" style="color:black;" runat="server" AutoPostBack="true" Text="Tipo domicilio" OnCheckedChanged="chktipodomicilio_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chkfinalidadservicio" style="color:black;" runat="server" AutoPostBack="true" Text="Finalidad de servicio" OnCheckedChanged="chkfinalidadservicio_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chkingresos" style="color:black;" runat="server" AutoPostBack="true" Text="Ingresos" OnCheckedChanged="chkingresos_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chkmonto" style="color:black;" runat="server" AutoPostBack="true" Text="Monto" OnCheckedChanged="chkmonto_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chktrabajoactual" style="color:black;" runat="server" AutoPostBack="true" Text="Trabajo actual" OnCheckedChanged="chktrabajoactual_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chkcuentaconigss" style="color:black;" runat="server" AutoPostBack="true" Text="Cuenta con IGSS" OnCheckedChanged="chkcuentaconigss_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chkcuentaencooperativa" style="color:black;" runat="server" AutoPostBack="true" Text="Cuenta en cooperativa" OnCheckedChanged="chkcuentaencooperativa_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chkañosdomicilio" style="color:black;" runat="server" AutoPostBack="true" Text="Años de domicilio" OnCheckedChanged="chkañosdomicilio_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chktipocontacto" style="color:black;" runat="server" AutoPostBack="true" Text="Tipo de contacto" OnCheckedChanged="chktipocontacto_CheckedChanged" />
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chkporagencia" style="color:black;" runat="server" AutoPostBack="true" Text="Por Agencia" OnCheckedChanged="chkporagencia_CheckedChanged"/>
    </div>  
                        <div class="col-sm-3" style="border:double; color:black" >
        <asp:CheckBox ID="chkporusuario" style="color:black;" runat="server" AutoPostBack="true" Text="Por usuario" OnCheckedChanged="chkporusuario_CheckedChanged" />
    </div> 
    </div>    
        <br />
        <%-- diseño --%>
        <div class="container">
            <div class="col-sm-12" >
            <asp:DropDownList ID="combotiposervicio" runat="server">
                <asp:ListItem Value="0">Tipo de servicio</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="comboestadosemaforo" AutoPostBack="true" OnSelectedIndexChanged="seleccionsemaforo_SelectedIndexChanged" runat="server">
                <asp:ListItem Value="0">Estado de semáforo</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="combodescripcionestado" runat="server">
                <asp:ListItem Value="">Descripciòn del estado</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="combotipodomicilio" runat="server">
                <asp:ListItem Value="">Tipo del domicilio</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="combofinalidadservicio" runat="server">
                <asp:ListItem Value="">Finalidad de servicio</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox runat="server" CssClass="texto" ID="txtingresos" placeholder="Q - Ingresos"></asp:TextBox>
            <asp:TextBox runat="server" CssClass="texto" ID="txtmonto" placeholder="Q - Monto"></asp:TextBox>
            <asp:DropDownList ID="combotrabajoactual" runat="server">
                <asp:ListItem Value="">¿Poseè trabajo actual?</asp:ListItem>
                <asp:ListItem Value="1">Si</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="combocuentaigss" runat="server">
                <asp:ListItem Value="">¿Cuenta con IGSS?</asp:ListItem>
                <asp:ListItem Value="1">Si</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="combocuentacooperativa" runat="server">
                <asp:ListItem Value="">Tiene cuenta en cooperativa</asp:ListItem>
                <asp:ListItem Value="1">Si</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox runat="server" CssClass="texto" ID="txtañodomicilios" placeholder="Años de domicilio"></asp:TextBox>
            <asp:TextBox runat="server" CssClass="texto" ID="txttipodecontacto" placeholder="Tipo de contacto"></asp:TextBox>
            <asp:DropDownList ID="comboagencia" runat="server">
            <asp:ListItem Value="">Seleccione la agencia</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="combousuario" runat="server">
            <asp:ListItem Value="">Seleccione el usuario</asp:ListItem>
            </asp:DropDownList>
            
            </div>
            </div>
        <br />
        <center>            
        <asp:LinkButton style="background-color:bisque; height:33px; width:306px; color:black; display:inline-block" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text="Generar Reporte">Generar Reporte</asp:LinkButton>
        </center>
        <center>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" style="max-width:937px"  Width="100%"></rsweb:ReportViewer>
        </center>  
                <br />
            

    </form>
    
</body>
</html>
