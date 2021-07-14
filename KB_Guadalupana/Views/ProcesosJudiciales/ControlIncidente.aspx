﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlIncidente.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.ControlIncidente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Control Incidente</title>
    <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');



        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:"Montserrat";
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
            background-color:lightgray;
            flex-direction:column;
            margin-top:10px;
        }

        .formato{
            display:flex;
            flex-direction:row;
            justify-content: space-between;
            width:100%;
        }

          .formato3{
            display:flex;
            flex-direction:column;
            width:100%;
        }

        .formato4{
             display:flex;
            flex-direction:row;
            justify-content: center;
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
        }

        .formatoinput2{
            width:98%;
            margin-top:8px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
        }

        .formatoinput3 {
            width: 22%;
            border: 1px black solid;
            height: 30px;
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
             width: 22%;
            margin-top:0px;
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

         .boton3{
            background-color: #003A6E;
            color: white;
            border:0px;
             width:22%;
             display: flex;
             align-items: center;
            align-content:center;
            justify-content:center;
        }

        .boton3:hover {
             background-color: white; 
             color: black; 
             border: 2px solid #003A6E;
            
        }

         .pagina{
            display:flex;
            flex-direction:row;
            align-content:center;
            justify-content: space-around;
            align-items:center;
        }

         .header{
             background-color:#004078;
             color:white;
         }

         .titulos{
             font-size:13px;
              width: 29%;
             display:flex;
             justify-content: flex-end;
         }

        .formatoTitulo{
            display:flex;
            flex-direction:row;
            justify-content: flex-start;
        }

        .tabla{
            width:100%;
        }

        .tabla td{
            padding:7px;
        }

         .seleccionarcelulargridview{
        }

    </style>
</head>
     <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">
                <div style="display:flex; justify-content:center">
                    <label style="font-size:20px" class="titulos"><b>Control de incidente</b></label>
                 </div><br /><br /><br />

                <div class="pagina">
                    <label class="titulos">Ordenar incidentes por fecha:</label>
                    <asp:DropDownList id="OrdenarFecha" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                    <asp:Button ID="Buscar" runat="server" CssClass="boton" Text="Buscar" OnClick="Buscar_Click"/>
                </div>
                <br /><br />

                    <div style="overflow: auto; height: 400px">
                        <asp:GridView ID="gridViewIncidente" runat="server" CssClass="tabla" AutoGenerateColumns="False"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedIncidente" BorderStyle="Solid">
                            <Columns>
                                  <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. de proceso">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnumincidente" Text='<%# Eval("idpj_incidente") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. de crédito">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnumcredito" Text='<%# Eval("pj_numcredito") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnombre" Text='<%# Eval("pj_nombre") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Fecha de creación">
                                    <ItemTemplate>
                                       <asp:Label ID="lblfecha" Text='<%# Eval("pj_fechacreacion") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Días transcurridos">
                                    <ItemTemplate>
                                       <asp:Label ID="lbldias" Text='<%# Eval("Dias") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Ver Bitácora" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="Black">
                                    <ItemStyle Width="100px"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba"  ForeColor="White" BackColor="#0069C4"></HeaderStyle>
                        </asp:GridView>
                    </div>
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
