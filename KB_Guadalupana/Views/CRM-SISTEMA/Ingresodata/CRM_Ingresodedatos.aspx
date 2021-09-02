<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Ingresodedatos.aspx.cs" ValidateRequest="false" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Ingresodata.CRM_Ingresodedatos"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css'/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
   <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <title>Ingreso de datos</title>
    <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>
</head>
<body>
    <form id="form1" runat="server">
        	<header style="background-color:#69a43c">
               
                    <div class="row">
                        <div class="col" style=" text-align:left;height:43px">
                                <asp:Button ID="btnmenuprincipal" style="text-align:left" Height="100%" Width="100%" BackColor="#69a43c" runat="server" Text="  Menú principal" BorderStyle="None" OnClick="btnmenuprincipal_Click" />                            
                        </div>
                        <div class="col">
                            
                        </div>
                        <div class="col" style=" text-align:right" >
                         <asp:Button ID="btncerrasesion" Visible="true" style="text-align:right" BackColor="#69a43c" Width="100%" Height="100%" runat="server" Text="Ingreso Manual" BorderStyle="None" OnClick="btncerrasesion_Click" />                    
                        </div>
                    </div>
               
	</header>

        <%-- BODY --%>
        <div>
            <br />
            <br />
            <h4 style="text-align:center">INGRESO DE DATOS</h4>
            <center>
              <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="#69a43c" BorderStyle="Double" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
              <asp:Button ID="btncargardatos" runat="server" Text="Cargar datos" OnClick="btncargardatos_Click"></asp:Button>
             
                <asp:Button ID="btngridview" runat="server" Text="Mostrar Gridview" OnClick="btnmostrardatos_Click"></asp:Button>
               <asp:CheckBox ID="Chkautorizar" Text="Autorizar Envío" runat="server" Font-Bold="True" ></asp:CheckBox>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" Onclick="btnguardarenbasededatos_Click" ></asp:Button>
            
               </center>
          
            <%-- GRIDVIEW --%>
            <center>
                <asp:Label ID="lblOculto" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                  <hr style="border:double;color:black;" />
                 <br />
                   <img id="imgdelestandar" src="../../../Imagenes/imagendeformato.PNG"/>
                <br />
                <br />
                <h5>EL FORMATO EN EL QUE SE SUBE EL ARCHIVO ES DELIMITADO POR COMA (.CSV)</h5>
                <div style="overflow: auto; height: 1px;">
                                     <asp:GridView ID="GridView1"  runat="server" Height="251px" Width="420px">
                                    </asp:GridView>
                              </div>
                            <%-- GW EDITABLE --%>
                             <asp:GridView ID="gvPhoneBook" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="codcrmtamporalcargadedatos"
                ShowHeaderWhenEmpty="true"

                OnRowCommand="gvPhoneBook_RowCommand" OnRowEditing="gvPhoneBook_RowEditing" OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit"
                OnRowUpdating="gvPhoneBook_RowUpdating" OnRowDeleting="gvPhoneBook_RowDeleting"

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="100px" Width="50px">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#003563" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />               
                <Columns>
                        <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("codcrmtamporalcargadedatos") %>' runat="server" Width="31px"  />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtnumeroregistro" Text='<%# Eval("codcrmtamporalcargadedatos") %>' runat="server" Width="31px" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="fecha">
                        <ItemTemplate>
                            <asp:Label Text='<%# string.Format("{0: yyyy-MM-dd}",Eval("crmtamporal_cargadedatosfecha")) %>' runat="server" Width="101px" />
                        </ItemTemplate>
                        <EditItemTemplate>   
                            <asp:TextBox ID="txtfecha" Text='<%# string.Format("{0: yyyy-MM-dd}",Eval("crmtamporal_cargadedatosfecha")) %>' runat="server" Width="101px"  />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="nombre completo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("crmtamporal_cargadedatosnombre") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtnmombrecompleto" Text='<%# Eval("crmtamporal_cargadedatosnombre") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Telefono">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("crmtamporal_cargadedatostelefono") %>' runat="server" Width="80px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txttelefono" Text='<%# Eval("crmtamporal_cargadedatostelefono") %>' runat="server" Width="80px" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Correo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("crmtamporal_cargadedatoscorreo") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtcorreo" Text='<%# Eval("crmtamporal_cargadedatoscorreo") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="DPI">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("crmtamporal_cargadedatosdpi") %>' runat="server" Width="120px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtdpi" Text='<%# Eval("crmtamporal_cargadedatosdpi") %>' runat="server" Width="120px"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Monto">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("crmtamporal_cargadedatoscantidad") %>' runat="server" Width="85px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtmonto" Text='<%# Eval("crmtamporal_cargadedatoscantidad") %>' runat="server" Width="85px" />
                        </EditItemTemplate>
                    </asp:TemplateField>
       
                      <asp:TemplateField HeaderText="Finalidad">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("crmtamporal_cargadedatosfinalidad") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtfinalidad" Text='<%# Eval("crmtamporal_cargadedatosfinalidad") %>' runat="server" Width="80px" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Zona">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("crmtamporal_cargadedatoszona") %>' runat="server" Width="90px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtzona" Text='<%# Eval("crmtamporal_cargadedatoszona") %>' runat="server" Width="90px" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Tipo de servicio">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("crmtamporal_cargadedatotiposervicio") %>' runat="server" Width="57px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txttiposervicio" Text='<%# Eval("crmtamporal_cargadedatotiposervicio") %>' runat="server" Width="57px" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Contactado por">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("crmtamporal_cargadedatocontactadopor") %>' runat="server" Width="115px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtcontacatdopor" Text='<%# Eval("crmtamporal_cargadedatocontactadopor") %>' runat="server" Width="115px" />
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Imagenes/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Imagenes/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Imagenes/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Imagenes/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Imagenes/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
                            </div>
            </center>
      

        <footer style="margin-top:227px">
            <center>
<img src="../../../Imagenes/f_logo.svg" width="28%">
<p style="font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">
    OFICINAS CENTRALES · 14 Avenida 1-65 Zona 14, Ciudad de Guatemala, GT 01014
    <br />
    ©2019. Cooperativa Guadalupana. Reservados Todos los Derechos.</p>
                </center>
</footer>
     

    </form>
       
</body>
</html>
