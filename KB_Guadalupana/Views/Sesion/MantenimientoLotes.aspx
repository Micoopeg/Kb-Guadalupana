<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoLotes.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.MantenimientoLotes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <title>Lotes</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <link rel="stylesheet" href="../../DiseñoForms/style.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
       <style>
           
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
          padding-top:20px;

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
            margin-top: 45px;
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

       .tabla {
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

        /*.formulario {
            -webkit-box-shadow: 1px 0px 15px 5px rgba(0,0,0,0.81); 
            box-shadow: 1px 0px 15px 5px rgba(0,0,0,0.81);
            width:auto;
            height:auto;
            padding:20px;
            display: flex;
            flex-direction: column;
            overflow:auto;
            margin-bottom:20px;
        }*/

           .encabezado {
               flex-direction: row;
               display: flex;
               justify-content: space-between;
               padding-top: 10px;
           }

           .buscar {
               flex-direction: row;
               display: flex;
               justify-content: center;
               margin: 5px;
           }
        .btnprueba{

        }

        .tablas {
            flex-direction: row;
            justify-content: center;
            display:flex;
            overflow: scroll;
            width: 900px;
            height: 250px;
        }
  .sobre 
        {
        position: absolute;
        top: 6%;
        left: 33%;
        margin-top: -40px;
        margin-left: -33px;
        max-width: 60%;
        /*width: 100px;
        height: 50px;*/
        }

</style>
</head>
<body>
    <%-- <img class="sobre" src="../../Imagenes/EP-Guadalupana.png"/>--%>
    <a class="button button5" style="right: 8%;position: absolute;margin-top: -500px;" target="_blank" href="Ayudas/AyudaLote.aspx" ><i class="fa fa-question"></i></a>

     <div class="menu"></div>
        <div class="mantenimientos">
          <a href="MantenimientoLotes.aspx" class="active">Crear Lotes</a>
          <a href="AsignacionLotes.aspx" >Asignar Lotes</a>
            
        </div>
  
     

 <form id="form1" runat="server">
 <div >
     <div class="encabezado">
         <h2 class="fs-title">
            <b>Registro Tipo Lotes</b>
        </h2>
        <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="width: 180px; height: 120px; top: 0; margin-left: 0px;" />
     </div>

  <input id="RLCodigo" disabled="disabled" readonly="readonly" runat="server" type="text" class="tam" style="width:10%;" required/>
  <div class="buscar">
    <asp:TextBox ID="TextBox1" placeholder="Ingrese fecha de inicio" runat="server" CssClass="tamp"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" CssClass="tam" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Ver todos" CssClass="tam" />
  </div>
        <br />
     <div class="tablas">
            <asp:GridView ID="gvPhoneBook" CssClass="tabla" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="codepadministracionlote"
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
                            <asp:Label  Text='<%# Eval("codepadministracionlote") %>' runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtFirstNameFooter" type="number" min="0" placeholder="Ingrese no. de lote" runat="server" />
                           <%-- <asp:TextBox ID="TextBox2" ReadOnly="true" runat="server"/>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de inicio">
                  <ItemTemplate>
                            <asp:Label Text='<%# Eval("ep_administracionlotefechainicio", "{0:d}") %>' runat="server" />
                        </ItemTemplate>
                          <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName3" Text='<%# Eval("ep_administracionlotefechainicio", "{0:d}") %>' runat="server" />
                     </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtContactFooter" placeholder="Ingrese fecha inicio" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Fecha de fin">
                  <ItemTemplate>
                            <asp:Label Text='<%# Eval("ep_administracionfechafin", "{0:d}") %>' runat="server" />
                        </ItemTemplate>
                         <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName2" Text='<%# Eval("ep_administracionfechafin", "{0:d}") %>' runat="server" />
                     </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtContactFooter2" placeholder="Ingrese fecha fin" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado de lote">
                     <ItemTemplate>
                       <asp:Label Text='<%# Eval("ep_administracionloteestado") %>' runat="server" />
                     </ItemTemplate>
                     <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName" Text='<%# Eval("ep_administracionloteestado") %>' runat="server" />
                     </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtContactFooter3" type="number" min="0" placeholder="Ingrese estado" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Opciones">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../../Imagenes/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            
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
         </div>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
     
  </div>
      </form>

</body>
    <script>
        var texto1 = document.querySelector('#txtContactFooter3');
        texto1.addEventListener('keypress', function (e) {
            // keyCode del punto decimal, también se puede cambiar por la coma que sería el 44
            const decimalCode = 46;
            // chequeo que el keyCode corresponda a las teclas de los números y al punto decimal
            if ((e.keyCode < 48 || e.keyCode > 57) && e.keyCode != decimalCode) {
                e.preventDefault();
            }
            // chequeo que sólo exista un punto decimal
            else if (e.keyCode == decimalCode && /\./.test(this.value)) {
                event.preventDefault();
            }
        }, true)
</script>
   <script>
       $(document).ready(function () {
           $('.menu').load('MenuBarra.aspx');
       });

       function MantenimientoMoneda() {
           document.getElementById('MantenimientoMoneda').click();
       }

       function agregarRegistro() {
           document.getElementById('agregarRegistro').click();
       }


   </script>
</html>