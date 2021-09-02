<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaEliminar.aspx.cs" Inherits="KB_Guadalupana.Views.Hallazgos.VistaEliminar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reporte</title>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <link rel="stylesheet" href="../../DiseñoForms/style.css" />
     <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
<style>
     .tabla{
            width:100%;
            display: flex;
            align-items: center;
            align-content: center;
            justify-content: center;
     }
     .mGrid{
        width:100%;
     }
    table th{
           background-color:#0076DE;
           color: white;
           padding: 2px;
           font-size:15px;
           justify-content: center;
    }
    table td{
       border: 0.3px solid black;
    }
    table {
        margin: 0px 15px;
        border-collapse: collapse;
    }
      .etiquetas{
            font-size: 15px;
            justify-content: flex-start;
            display: flex;
            justify-content:center;
            margin: 3px;
            padding: 5px;
            width: 50%;
      }
      .general{
          display:flex;
          justify-content:center;
          flex-direction: column;
          padding: 20px;
      }
      .opcion{
          color:black;

      }
body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}

.topnav {
  overflow: hidden;
  background-color: #333;
}

.topnav a {
  float: left;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

.topnav a:hover {
  background-color: #ddd;
  color: black;
}

.topnav a.active {
  background-color: #4CAF50;
  color: white;
}
.topnav {
  overflow: hidden;
  background-color: #003563;
}

.topnav a {
  float: left;
  color: #f2f2f2;
  text-align: center;
  padding: 15px 35px;
  text-decoration: none;
  font-size: 17px;
}

.topnav a:hover {
  background-color: #B80416;;
  color: White;
}

.topnav a.active {
  background-color: #69a43c;
  color: white;
}

.button {
  border: none;
  color: white;
  padding: 4px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  transition-duration: 0.4s;
  cursor: pointer;
}

.button1 {
  background-color: white; 
  color: black; 
  border: 2px solid #69a43c;
}

.button1:hover {
  background-color: #69a43c;
  color: white;
}

 .fa-check-circle::before 
 {
  font-family: "FontAwesome", sans-serif;
  content: "\f0a5";
  font-size: 17px;
  color: #003563;
  text-decoration: none;
}


</style>
</head>
<body>
    <center><img class="sobre" src="Imagenes/SH-Guadalupana.png"/></center>
    <div class="menu"></div>
    <form id="form1" runat="server">
          <div class="topnav">
            <a class="active" href="ConsultarHallazgos.aspx">Regresar</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b>Consulta Hallazgos Eliminados</b></span>
            <a href="../Sesion/CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
    </div>
        <br />
        <br />
        <div class="general">
            <%-- <div style="display:flex; align-content:center;align-items:center; justify-content:center; flex-direction:row">
                <input type="number" runat="server"  id="RBuscarcif" style="font-size: 20px;width: 10%;border:0;" placeholder="Ingrese CIF" class="etiquetas"/>
                <asp:Button ID="RBuscar" runat="server" CssClass="button button1" OnClick="buscar_Click" Text="Buscar" />
                <asp:Button ID="VerTodos" runat="server" CssClass="button button1" OnClick="VerTodos_Click" Text="Ver todos" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <input type="number" runat="server"  id="RCif" style="font-size: 20px;width: 10%;border:0;" placeholder="CIF" class="etiquetas" readonly="readonly"/>
                <asp:Button ID="Buscar" runat="server" CssClass="button button1" OnClick="iniciarsesion_Click" Text="Generar Reporte" />
                <input id="Text6" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
            </div><br />--%>
            
              <div class="tabla">
     <asp:GridView ID="GridViewReporteH" CssClass="mGrid" style="width: 950px;text-align:center;text-decoration: none;Color: black;" runat="server"  HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid" >
                     <Columns>
                          <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="ID">
                        <ItemTemplate>
                           <asp:Label ID="idhallazgo" Text='<%# Eval("codshrespuestaasignacion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Rubro">
                        <ItemTemplate>
                           <asp:Label ID="lblrubro" Text='<%# Eval("sh_rubro") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Mes">
                           <ItemTemplate>
                           <asp:Label ID="Estado1" Text='<%# Eval("sh_mes") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Gerencia">
                           <ItemTemplate>
                           <asp:Label ID="Estado2" Text='<%# Eval("sh_gerencianombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Area">
                           <ItemTemplate>
                           <asp:Label ID="Estado3" Text='<%# Eval("sh_areanombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Estado">
                           <ItemTemplate>
                           <asp:Label ID="Estado4" Text='<%# Eval("sh_nombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>

                   </div>
        </div>
    </form>
</body>
    
</html>


