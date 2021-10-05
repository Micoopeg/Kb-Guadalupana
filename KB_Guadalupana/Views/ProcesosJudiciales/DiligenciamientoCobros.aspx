<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiligenciamientoCobros.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.DiligenciamientoCobros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
    <title>Diligenciamiento</title>
        <style>
            @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:'Montserrat';
            background-color:#34495E;
            color:white;
        }

        .general{
            display:flex;
            justify-content:center;
            align-content:center;
            align-items:flex-start;
            width:100%;
            height:auto;
            margin-top:25px;
        }

        .formularioCobros{
            display:flex;
            flex-direction:column;
            width:750px;
        }

        .encabezado{
            padding:25px;
            background-color:#435F7A;
            flex-direction:column;
            margin-top:10px;
        }

        .formato{
            display:flex;
            flex-direction:row;
            justify-content: space-between;
        }

          .formato3{
            display:flex;
            flex-direction:column;
            width:100%;
        }
             .formato4{
            display:flex;
            flex-direction:column;
            justify-content:center;
            align-items:center;
            width:45%;
        }

        .formatoinput {
            width: 46%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
            text-transform:uppercase;
        }

        .formatoinput2{
            width:98%;
            margin-top:8px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            text-transform:uppercase;
        }

        .formatoinput3 {
            width: 29%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
        }

        .formato2{
            display:flex;
            flex-direction:row;
            justify-content: space-around;
        }

        .boton{
            background-color: #69A43C;
            color: white;
            border:0px;
            width:45%;
            margin-top:15px;
            height: 30px;
        }

        .boton:hover {
             background-color: white; 
             color: black; 
             border: 2px solid #69A43C;
        }

         .boton2{
             background-color: white; 
             color: black; 
             border: 2px solid #69A43C;
            width:45%;
            margin-top:15px;
            height: 30px;
        }

        .boton2:hover {
            background-color: #69A43C;
            color: white;
            border:0px;
        }

         .pagina{
            display:flex;
            flex-direction:row;
        }

         .header{
             background-color:#004078;
             color:white;
         }

         .titulos{
             font-size:13px;
         }

        .formatoTitulo{
            display:flex;
            flex-direction:row;
            justify-content: flex-start;
        }

        .tabla{
            width:100%;
            text-align:center;
        }
        .tabla td{
            padding:5px;
        }
    </style>
</head>
       <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">
                <div style="display:flex; justify-content:center">
                    <span id="SolicitudInvestigacion" runat="server" style="font-size:18px" class="titulos">Solicitud de investigación</span>
                </div><br />

                      <div id="Div2" runat="server" style="overflow: auto; height: 300px">
                        <asp:GridView ID="gridViewInvestigacion" runat="server" CssClass="tabla" AutoGenerateColumns="False"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedInvestigacion" BorderStyle="Solid">
                              <Columns>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. de crédito">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnumcredito" Text='<%# Eval("Credito") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnombre" Text='<%# Eval("Nombre") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. Incidente">
                                    <ItemTemplate>
                                       <asp:Label ID="lblincidente" Text='<%# Eval("Incidente") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Fecha">
                                    <ItemTemplate>
                                       <asp:Label ID="lblfecha" Text='<%# Eval("Fecha"," {0:d}") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Investigacion" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="White">
                                    <ItemStyle Width="120px" ForeColor="White"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba"  ForeColor="White" BackColor="#0069C4"></HeaderStyle>
                        </asp:GridView>
                    </div><br /><br />

                <div style="display:flex; justify-content:center">
                    <span id="TransaccionVoluntaria" runat="server" style="font-size:18px" class="titulos">Solicitud transacción voluntaria</span>
                </div><br />

                     <div id="Div1" runat="server" style="overflow: auto; height: 300px">
                        <asp:GridView ID="gridViewVoluntaria" runat="server" CssClass="tabla" AutoGenerateColumns="False"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedVoluntaria" BorderStyle="Solid">
                              <Columns>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. de crédito">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnumcredito" Text='<%# Eval("Credito") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnombre" Text='<%# Eval("Nombre") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. Incidente">
                                    <ItemTemplate>
                                       <asp:Label ID="lblincidente" Text='<%# Eval("Incidente") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                        <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Fecha">
                                    <ItemTemplate>
                                       <asp:Label ID="lblfecha" Text='<%# Eval("Fecha"," {0:d}") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Transaccion" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="White">
                                    <ItemStyle Width="120px" ForeColor="White"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba"  ForeColor="White" BackColor="#0069C4"></HeaderStyle>
                        </asp:GridView>
                    </div><br /><br />
            </div>
        </div>

           <script>
               $(document).ready(function () {
                   $('.menu').load('MenuPrincipal.aspx');
               });
           </script>
    </form>
</body>
</html>
