<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoPep.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.MantenimientoPep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <title>PEP</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <link rel="stylesheet" href="../../DiseñoForms/style.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
       <style>  
        .responsive 
        {
            max-width: 100%;
            height: auto;
        }
        body {
           display: flex;
            justify-content: center;
            justify-items: center;
            align-items: center;
            align-content:center;
            width: 100%;
            height: 100%;
            flex-direction: column;
          font-family: Arial, Helvetica, sans-serif;
          padding-top:50px;
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
                   background-color: #B80416;
                   ;
                   color: White;
               }

               .topnav a.active {
                   background-color: #69a43c;
                   color: white;
               }

           .tampe {
               margin: 4px;
               padding: 6px;
               border: 1px lightgray solid;
               width: 100px;
           }

          .tamp {
            margin: 0px;
            padding: 6px;
            border: 1px lightgray solid;
            width: 200px;
            margin: 5px;
        }

        .tam {
            margin-right: 10px;
            padding: 6px;
            border: 1px lightgray solid;
            width: 100px;
           margin: 5px;
           color: white;
           background-color: #003A6E;
        }
        
        
        .mantenimientos {
             display: flex;
            flex-direction: row;
            justify-content: center;
            align-content: center;
            align-items:center;
            margin-top: 100px;
            /*padding: 15px;*/
            /*position: absolute;*/
            left: 24%;
            /*margin-left: 400px;*/
            height: 100px;
            width: 700px;
            /*position: absolute;*/
        }

           .mantenimientos a {
              display: flex;
              flex-direction: row;
              justify-content: center;
              align-content: center;
              align-items:center;
              background-color: #0066BF; /* Green background */
              border: 0px; /* Green border */
              color: white; /* White text */
              padding: 5px; /* Some padding */
              cursor: pointer; /* Pointer/hand icon */
              float: left; /* Float the buttons side by side */
              padding: 5px;
              margin: 1px;
              width: 110px;
              height: 30px;
              font-family: 'Montserrat';
              font-size: 10px;
           }

         
        h2.fs-title {
            justify-content: center;
            align-items: center;
            display: flex;
        }

       .tabla{
           border-collapse:collapse;
           align-items: center;
           align-content: center;
           justify-content:center;
       }

       .tabla th {
           align-items: center;
           justify-content:center;
           border: 0.5px solid black;
           align-content:center;  
           padding: 5px;
       }

       .tabla tr {
           align-items: center;
           justify-content:center;
           border: 0.5px solid black;
           align-content:center;
           padding: 5px;
       }

       .tabla td {
             align-items: center;
           justify-content:center;
           border: 0.5px solid black;
         align-content:center;
           padding: 5px;
       }
        .encabezado {
            flex-direction:row;
            display: flex;
            justify-content: space-between;
            padding-top:10px;
        }

        .buscar {
            flex-direction: row;
            display: flex;
            justify-content: center;
            margin: 5px;
        }
          .button 
{
  background-color: #69a43c; 
  border: none;
  color: white;
  padding: 0px 0px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  transition-duration: 0.4s;
  cursor: pointer;
}
.button5:hover
{
  background-color: #555555;
  color: white;
}
</style>
</head>
<body>

    <a class="button button5" style="right: 8%;position: absolute;margin-top: -500px;" target="_blank" href="Ayudas/AyudaPep.aspx" ><i class="fa fa-question"></i></a>

     <div class="menu"></div>
        <div class="mantenimientos">
          <a href="MantenimientoVehiculos.aspx" class="active" onclick="MantenimientoVehiculos()">Vehículos</a>
          <a href="MantenimientoMoneda.aspx" onclick="MantenimientoMoneda()" id="MantenimientoMoneda">Moneda</a>
          <%--<a href="MantenimientoCuentas.aspx">Cuentas</a>--%>
          <a href="MantenimientoInmueble.aspx">Inmueble</a>
          <a href="MantenimientoTelefono.aspx">Teléfono</a>
          <%--<a href="MantenimientoPep.aspx">PEP</a>--%>
          <a href="MantenimientoPrestamos.aspx">Prestamos</a>
          <a href="MantenimientoEstado.aspx">Estado</a>
          <a href="MantenimientoEstatus.aspx">Estatus Cuentas</a>
        </div>
    <form id="form1" runat="server">
    <div>
    <div class="encabezado">
         <h2 class="fs-title" style="margin-left:0">
            <b>Registro Tipo PEP</b>
        </h2>
        <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="width: 180px; height: 120px; top: 0; margin-left: 0px;" />
     </div>
   <input id="RPCodigo" disabled="disabled" readonly="readonly" runat="server" type="text" class="tam" style="width:10%;" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" required/>
   <div class="buscar">
    <asp:TextBox ID="TextBox1" placeholder="Ingrese tipo pep" runat="server" CssClass="tamp"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" CssClass="tam" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Ver todos" CssClass="tam" />
  </div>
        <br />

       <asp:GridView ID="gvPhoneBook" CssClass="tabla" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="codeptipopep"
                ShowHeaderWhenEmpty="true"
                OnRowCommand="gvPhoneBook_RowCommand" OnRowEditing="gvPhoneBook_RowEditing" OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit"
                OnRowUpdating="gvPhoneBook_RowUpdating" OnRowDeleting="gvPhoneBook_RowDeleting"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="496px">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066"/>
                <HeaderStyle BackColor="#0071D4" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
                <Columns>
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("codeptipopep") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstName" Text='<%# Eval("codeptipopep") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtFirstNameFooter" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo PEP">
                  <ItemTemplate>
                            <asp:Label Text='<%# Eval("ep_tipopep") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContact" Text='<%# Eval("ep_tipopep") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtContactFooter" placeholder="Ingrese tipo pep" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../../Imagenes/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="../../Imagenes/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="../../Imagenes/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="../../Imagenes/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="../../Imagenes/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
     
  </div>
      </form>
</body>
   <script>
       $(document).ready(function () {
           $('.menu').load('MenuBarra.aspx');
       });
       ////function MantenimientoVehiculos() {
       ////    document.getElementById('MantenimientoVehiculos').click();
       ////}

       function MantenimientoMoneda() {
           document.getElementById('MantenimientoMoneda').click();
       }

       function agregarRegistro() {
           document.getElementById('agregarRegistro').click();
       }


   </script>
</html>

