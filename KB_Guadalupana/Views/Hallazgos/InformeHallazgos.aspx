<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeHallazgos.aspx.cs" Inherits="KB_Guadalupana.Views.Hallazgos.InformeHallazgos" %>

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
           background-color:#69a43c;
            color: white;
            font-weight: bold;
            text-align: center;
           padding: 2px;
           font-size:15px;
           justify-content: center;
           padding: .75rem;
           vertical-align: top;
           text-align: justify;
    }

diseñodep
{

}
table tr:nth-child(odd) 
{
    background-color: #CAD2E0;
}

table tr:nth-child(even) 
{
    background-color: white;
}
    table td
    {
           border: 0.3px solid black;
           vertical-align: middle;
           padding: .75rem;
           vertical-align: top;
           text-align: justify;
    }
    table 
    {
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
  background-color: #69a43c; /* Green */
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  cursor: pointer;
  float: left;
}

.button:hover {
  background-color: #003563;
}

 .fa-check-circle::before 
 {
  font-family: "FontAwesome", sans-serif;
  content: "\f0a5";
  font-size: 17px;
  color: #003563;
  text-decoration: none;
}

 .prueba
 {
     background-color: #003563;
 }


</style>
</head>
<body>
    <center><img class="sobre" src="Imagenes/SH-Guadalupana.png"/></center>
    <div class="menu"></div>
    <form id="form1" runat="server">
          <div class="topnav">
            <a class="active" href="MatrizHallazgos.aspx">Regresar</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b>Matriz de Seguimiento de </b><b id="mess" runat="server"></b><b>/</b><b id="B1" runat="server"></b></span>
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
            <asp:GridView ID="GridViewEjemplo" runat="server"></asp:GridView>

            
        </div>
        <asp:Button ID="btnExcel" class="button" style="margin-top: -60px;position: absolute;right: 631px;" runat="server" Text="Exportar a Excel" OnClick="btnExcel1_Click"/>
        <asp:Button ID="Button1" class="button" style="margin-top: -60px;margin-left:550px; position: absolute;" runat="server" Text="Exportar a Excel" OnClick="btnExcel_Click"/>
                    

              <div class="tabla">
     <asp:GridView ID="GridViewReporteH" CssClass="mGrid"  style="width: 97%;text-align:center;text-decoration: none;Color: black;text-align: center;vertical-align:middle;" runat="server"  HeaderStyle-ForeColor="black"
    AutoGenerateColumns="False" BorderStyle="Solid"  OnSelectedIndexChanged = "OnSelectedIndexChangedReporte">
        
         <Columns>
                   <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No.">
                        <ItemTemplate>
                           <asp:Label ID="idhallazgo" Text='<%# Eval("codshrespuestaasignacion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Mes">
                        <ItemTemplate>
                           <asp:Label ID="lblrubro" Text='<%# Eval("sh_mes") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Gerencia">
                           <ItemTemplate>
                           <asp:Label ID="Estado1" Text='<%# Eval("sh_gerencianombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ControlStyle-CssClass="diseñodep"  HeaderText="Departamento">
                           <ItemTemplate>
                           <asp:Label ID="Estado2" Text='<%# Eval("sh_areanombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Rubro">
                           <ItemTemplate>
                           <asp:Label ID="Estado3" Text='<%# Eval("sh_rubro") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Hallazgo">
                           <ItemTemplate>
                           <asp:Label ID="Estado4" Text='<%# Eval("sh_hallazgo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Recomendacion">
                           <ItemTemplate>
                           <asp:Label ID="Estado5" Text='<%# Eval("sh_recomendacion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Usuario Repuesta">
                           <ItemTemplate>
                           <asp:Label ID="Estado6" Text='<%# Eval("sh_usuario") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Fecha Repuesta">
                           <ItemTemplate>
                           <asp:Label ID="Estado6" Text='<%# Eval("sh_fecha") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Repuesta Gerencia">
                           <ItemTemplate>
                           <asp:Label ID="Estado7" Text='<%# Eval("sh_comentario") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Estatus" >
                           <ItemTemplate >
                           <asp:Label ID="Estado7" Text='<%# Eval("sh_nombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Calificación" >
                           <ItemTemplate >
                           <asp:Label ID="Estado7" Text='<%# Eval("sh_calificacion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                 <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Comentario de auditor" >
                           <ItemTemplate >
                           <asp:Label ID="Estado7" Text='<%# Eval("sh_comentarioauditor") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>             
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="white" BackColor="#003563" ></HeaderStyle>
        </asp:GridView>

                  
                  <asp:GridView ID="GridView1" CssClass="mGrid" style="width: 97%;text-align:center;text-decoration: none;Color: black;text-align: center;vertical-align:middle;" runat="server"  HeaderStyle-ForeColor="black"
    AutoGenerateColumns="False" BorderStyle="Solid"  OnSelectedIndexChanged = "OnSelectedIndexChangedReporte">
                     <Columns>
                   <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No.">
                        <ItemTemplate>
                           <asp:Label ID="idhallazgo" Text='<%# Eval("codshrespuestaasignacion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Mes">
                        <ItemTemplate>
                           <asp:Label ID="lblrubro" Text='<%# Eval("sh_mes") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Gerencia">
                           <ItemTemplate>
                           <asp:Label ID="Estado1" Text='<%# Eval("sh_gerencianombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ControlStyle-CssClass="diseñodep"  HeaderText="Departamento">
                           <ItemTemplate>
                           <asp:Label ID="Estado2" Text='<%# Eval("sh_areanombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Rubro">
                           <ItemTemplate>
                           <asp:Label ID="Estado3" Text='<%# Eval("sh_rubro") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Hallazgo">
                           <ItemTemplate>
                           <asp:Label ID="Estado4" Text='<%# Eval("sh_hallazgo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Recomendacion">
                           <ItemTemplate>
                           <asp:Label ID="Estado5" Text='<%# Eval("sh_recomendacion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Fecha Repuesta">
                           <ItemTemplate>
                           <asp:Label ID="Estado6" Text='<%# Eval("sh_fecha") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Repuesta Gerencia">
                           <ItemTemplate>
                           <asp:Label ID="Estado7" Text='<%# Eval("sh_comentario") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Estatus">
                           <ItemTemplate>
                           <asp:Label ID="Estado7" Text='<%# Eval("sh_nombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Calificación" >
                           <ItemTemplate >
                           <asp:Label ID="Estado7" Text='<%# Eval("sh_calificacion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Comentario de auditor" >
                           <ItemTemplate >
                           <asp:Label ID="Estado7" Text='<%# Eval("sh_comentarioauditor") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>       
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="white" BackColor="#003563"></HeaderStyle>
        </asp:GridView>
    </div>
        </div>
    </form>
</body>
    
</html>

