<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.Reporte" %>

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
</style>
</head>
<body>
    <div class="menu"></div>
    <form id="form1" runat="server">
        <div class="general">
             <div style="display:flex; align-content:center;align-items:center; justify-content:center; flex-direction:row">
                <input type="number" id="RCif" placeholder="CIF" runat="server" class="etiquetas"/>
                <asp:Button ID="Buscar" runat="server" CssClass="boton" Text="Buscar" />
                  <input id="Text6" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
            </div><br />
            
              <div class="tabla">
     <asp:GridView ID="GridViewReporte" CssClass="mGrid" style="width: 950px;text-align:center" runat="server"  HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False"  OnSelectedIndexChanged = "OnSelectedIndexChangedReporte" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre">
                           <ItemTemplate>
                           <asp:Label ID="lblnombre" Text='<%# Eval("gen_usuarionombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="CIF">
                           <ItemTemplate>
                           <asp:Label ID="lblcif" Text='<%# Eval("codepinformaciongeneralcif") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:ButtonField ItemStyle-CssClass="opcion" Text="Seleccionar" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="120px"></ItemStyle>
                         </asp:ButtonField>
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>
            </div>
        </div>
    </form>
</body>
    <script>
        $(document).ready(function () {
            $('.menu').load('MenuBarra.aspx');
        });
    </script>
</html>
