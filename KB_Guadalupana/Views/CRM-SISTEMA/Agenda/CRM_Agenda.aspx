<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Agenda.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Agenda.CRM_Agenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>CRM - ALERTAS</title>
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css'/>
    <link rel="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-top:-18px">
             <div style="border: 1px #e8e8e8 solid; width: 100%; float: right; margin: 10px 0px 10px 0px">
                <div style="border-bottom: 1px #69a43c solid; text-align:center; background-color: #69a43c; padding: 8px; font-size: 13px; font-weight: 700; color: #003563;">
                    CREACIÓN DE ALERTA
                </div>
                <div style="padding: 8px; font-size: 13px;">
                    <center>
                        <br />
            <asp:Label ID="lblfechaincio" runat="server" Text="Fecha de creacion:"></asp:Label>
              <br />
               <input id="txtcodigo" type="text" runat="server" visible="false" />        
              <input id="txtfechainicio" style="width:100%; " runat="server" type="date" tabindex="13" class="inputscortos" value="2020-04-25" min="1950-01-01" max="2021-12-31"  autofocus/>
            <br />
            <asp:Label ID="lblfechafinal" runat="server" Text="Recordatorio para el dia:"></asp:Label>
            <br />
    <input id="txtfechafin" style=" width:100%; "  runat="server" type="date" tabindex="14" class="inputscortos" value="2020-04-25" min="1950-01-01" max="2021-12-31"  autofocus/>
            <br />
                        <br />
                <asp:Label ID="lblencabezado" runat="server" Text="Encabezado:"></asp:Label>
                        <input id="txtencabezado" type="text" runat="server" visible="true" />   
                        <br />
                        <br />
                         <asp:Label ID="lbldetalle" runat="server" Text="Detalle:"></asp:Label>
            <textarea id="TextArea1" runat="server" cols="20" name="S1" rows="2" style="width:100%;"></textarea><br />
                        <br />
                          <br />
            <asp:Button ID="btnagendar" runat="server" Text="Agendar" OnClick="btnagendar_Click"  />
                    </center>   
                </div>
      </div>
        </div>
    </form>
</body>
</html>
