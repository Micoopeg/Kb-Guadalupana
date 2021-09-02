﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Dashboard</title>
     <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
        html{
            width:100%;
            height:100%;
        }

        .body{
            font-family:"Montserrat";
        }

        .general{
            display:flex;
            justify-content:center;
            align-content:center;
            align-items:flex-start;
            width:100%;
            height:100%;
            margin-top:0px;
        }

        .formularioCobros{
            display:flex;
            flex-direction:column;
            width:65%;
        }

        .encabezado{
            padding:20px;
            background-color:lightgray;
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
            width:45%;
        }
             .formato4{
            display:flex;
            flex-direction:column;
            justify-content: space-between;
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
            margin-top:15px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
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
         

         .celda{
             display:flex;
             justify-content:center;
             font-size:15px;
             width:100%;
         }

         .tabla{
             width:100%
         }

      .menu2{
         display:flex;
         flex-direction:row;
         width: 850px;
         height: 460px;
         flex-wrap:wrap;
         align-items:flex-start;
         align-content:flex-start;
         justify-content:center;
     }
     .menu2:after{
         content: "";
          clear: both;
          display: table;
     }
     .boton{
         background-color: #0066BF;
         color: white;
         padding: 10px 10px;
         cursor: pointer;
         margin: 5px;
         width:180px;
         height:150px;
         border:0px;
         font-size:medium;
         display:flex;
         justify-content:center;
         align-content:center;
         flex-wrap:wrap;
     }
     .boton:hover{
         background-color: #69A43C;
     }
     .numero{
         text-align:center;
         font-size:65px;
     }
     .opciones{
         background-color: #0066BF;
         color: white;
         padding: 15px 15px;
         cursor: pointer;
         margin: 15px 30px;
         width:180px;
         height:150px;
         flex-direction:column;
     }
     .items{
         display:flex;
         align-content:center;
         align-items:center;
         justify-content:center;
         height:90%;
         flex-direction:column;
     }
     .area{
         height: 30%;
         width:100%;
         color:white;
         background-color:transparent;
         border: 1px white solid;
     }
    </style>
</head>
    <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">

                <div style="display:flex; justify-content:center;margin-top:40px">
                        <label style="font-size:22px" class="titulos">Cantidad de créditos por área</label>
                    </div><br /><br />

            <div class="menu2">
                <div class="opciones">
                    <div style="display:flex;justify-content:flex-end;align-items:flex-end;align-content:flex-end">
                        <i class='far fa-folder-open' style='font-size:24px'></i>
                    </div>
                    <div class="items">
                        <div class="numero"><b><span class="numero" id="CantidadCobros" runat="server">0</span></b></div>
                        <asp:Button CssClass="area" runat="server" ID="BtnCobros"  Text="Cobros" OnClick="BtnCobros_Click"/>
                    </div>
                </div>

                <div class="opciones">
                    <div style="display:flex;justify-content:flex-end;align-items:flex-end;align-content:flex-end">
                        <i class='far fa-folder-open' style='font-size:24px'></i>
                    </div>
                    <div class="items">
                        <div class="numero"><b><span class="numero" id="BtnConta" runat="server">0</span></b></div>
                        <asp:Button CssClass="area" runat="server" ID="Contabilidad" Text="Contabilidad" OnClick="Contabilidad_Click"/>
                    </div>
                </div>

                <div class="opciones">
                    <div style="display:flex;justify-content:flex-end;align-items:flex-end;align-content:flex-end">
                        <i class='far fa-folder-open' style='font-size:24px'></i>
                    </div>
                    <div class="items">
                        <div class="numero"><b><span class="numero" id="Juridico" runat="server">0</span></b></div>
                        <asp:Button CssClass="area" runat="server" ID="BtnJuridico" Text="Jurídico" OnClick="BtnJuridico_Click"/>
                    </div>
                </div>

                 <div class="opciones">
                    <div style="display:flex;justify-content:flex-end;align-items:flex-end;align-content:flex-end">
                        <i class='far fa-folder-open' style='font-size:24px'></i>
                    </div>
                    <div class="items">
                        <div class="numero"><b><span class="numero" id="Coordinador" runat="server">0</span></b></div>
                        <asp:Button CssClass="area" runat="server" ID="BtnCoordinador" Text="Coordinador Legal"/>
                    </div>
                </div>

                <div class="opciones">
                    <div style="display:flex;justify-content:flex-end;align-items:flex-end;align-content:flex-end">
                        <i class='far fa-folder-open' style='font-size:24px'></i>
                    </div>
                    <div class="items">
                        <div class="numero"><b><span class="numero" id="Asistente" runat="server">0</span></b></div>
                        <asp:Button CssClass="area" runat="server" ID="BtnAsistente" Text="Asistente Legal"/>
                    </div>
                </div>

                <div class="opciones">
                    <div style="display:flex;justify-content:flex-end;align-items:flex-end;align-content:flex-end">
                        <i class='far fa-folder-open' style='font-size:24px'></i>
                    </div>
                    <div class="items">
                        <div class="numero"><b><span class="numero" id="Abogado" runat="server">0</span></b></div>
                        <asp:Button CssClass="area" runat="server" ID="BtnAbogado" Text="Abogado Externo" OnClick="BtnJuridico_Click"/>
                    </div>
                </div>
             </div>

              <%--  <div>
                    <div class="encabezado">

                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Número de crédito</b></label>
                        <label class="titulos" style="margin-left:34%"><b>DPI</b></label>
                    </div>
                    <div class="formato">
                         <input id="NumCredito" runat="server" type="number" min="0" class="formatoinput" placeholder="Ingrese no. crédito" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                         <input id="DPI" runat="server" type="number" min="0" class="formatoinput" placeholder="Ingrese DPI" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    </div><br />
                      <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Primer Nombre</b></label>
                            <label class="titulos" style="margin-left:37%"><b>Segundo Nombre</b></label>
                     </div>
                     <div class="formato">
                            <input id="PrimerNombre" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput" placeholder="Ingrese primer nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                             <input id="SegundoNombre" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput" placeholder="Ingrese segundo nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                      </div><br />
                     <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Primer Apellido</b></label>
                            <label class="titulos" style="margin-left:37%"><b>Segundo Apellido</b></label>
                     </div>
                     <div class="formato">
                          <input id="Apellido1" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput" placeholder="Ingrese primer apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                          <input id="Apellido2" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput" placeholder="Ingrese segundo apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                     </div><br />
                    </div>
                </div> <br /><br />--%>

           <%--     <div style="overflow: auto; height: 300px">
                        <asp:GridView ID="gridViewAsignacion" runat="server" CssClass="tabla" AutoGenerateColumns="False"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedAsignacion" BorderStyle="Solid">
                            <Columns>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. de crédito">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnumcredito" Text='<%# Eval("gen_numprestamo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnombre" Text='<%# Eval("Nombre") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Fecha de asignación">
                                    <ItemTemplate>
                                       <asp:Label ID="lblfecha" Text='<%# Eval("gen_fechaasignacion", "{0:d}") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Ver crédito" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="Black">
                                    <ItemStyle Width="100px"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba"  ForeColor="White" BackColor="#0069C4"></HeaderStyle>
                        </asp:GridView>
                    </div>--%>
            </div>
        </div>

         <script>
           $(document).ready(function () {
               $('.menu').load('MenuPrincipal.aspx');
           });
         </script>

         <script type="text/javascript">
             function sololetras(evt) {
                 var charCode = (evt.which) ? evt.which : event.keyCode
                 if (charCode > 31 && (charCode < 48 || charCode > 57))
                     return true;

                 return false;
             }
         </script>

    </form>
</body>
</html>

