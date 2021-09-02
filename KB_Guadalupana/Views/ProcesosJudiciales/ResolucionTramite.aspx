<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResolucionTramite.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.ResolucionTramite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Resolución de trámite</title>
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
            width: 29%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
        }

          .formatoinput4 {
            width: 21%;
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

         .boton3{
            background-color: #003A6E;
            color: white;
            border:0px;
             width:22%;
             display: flex;
             align-items: center;
            align-content:center;
            justify-content:center;
             height: 25px;
        }

        .boton3:hover {
             background-color: white; 
             color: black; 
             border: 2px solid #003A6E;
            
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
        }

        .tabla td{
            padding:7px;
        }
           .ventana{
             display:flex;
             align-content:flex-start;
             justify-content:flex-start;
             justify-items:flex-start;
             flex-direction:column;
             margin-left:0px;
         }
        .formatoinput5{
            width:90%;
            margin-top:8px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
        }

        .formatocheckbox {
            width: 25px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 25px;
            border-color: transparent;
            display: flex;
            align-items: flex-start;
            align-content:flex-start;
            justify-content:flex-start;
        }

        .formatocheck{
            display:flex;
            justify-content:space-between;
            flex-direction:row;
            width:100%;
            margin-bottom: 5px;
        }

        .formatocheck2{
            display:flex;
            flex-direction:row;
            width:35%;
        }
        .header{ border-top:1px solid white;background:white; color:#333; height:0px; width:100%; font-family: 'Lobster', cursive; text-align:center}
.menu2{visibility:hidden; height:auto; width:17%; color:white; text-align:left;color:black; padding-top:5px; left:0; margin-left:0px;margin-top:125px;background-color:lightgray; border:2px #4B752B solid;padding-left:13px;}
.wrapper{ height:100px; width:100%; padding-top:20px}
 
.fixed{position:fixed; top:0;visibility:visible}

    </style>
</head>
      <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">

                  <div style="display:flex; justify-content:center">
                    <label style="font-size:18px" class="titulos">Resolución de trámite</label>
                 </div><br />

                 <div class="header"></div>

                    <div id="Div1" runat="server" class="encabezado" style="border-color:#8DDB51; border:2px #4B752B solid">
                          <label style="font-size:15px" class="titulos"><b>Información principal</b></label><br /><br />

                        <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>No. de préstamo</b></label>
                        <label class="titulos" style="margin-left:11%"><b>No. de incidente</b></label>
                        <label class="titulos" style="margin-left:11%"><b>DPI</b></label>
                        <label class="titulos" style="margin-left:22%"><b>CIF</b></label>
                    </div>

                    <div class="formato">
                        <input id="NumPrestamo" runat="server" type="text" class="formatoinput4" min="0" placeholder="No. prestamo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                          <input id="NumIncidente" runat="server" type="text" class="formatoinput4" min="0" placeholder="No. incidente" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="DPI" runat="server" type="text" class="formatoinput4" placeholder="DPI" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                         <input id="CodigoCliente" runat="server" type="text" min="0" class="formatoinput4" placeholder="Código cliente" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formato3">
                        <label class="titulos"><b>Cliente - Nombre</b></label>
                        <input id="NombreCliente" runat="server" type="text" class="formatoinput2" placeholder="Cliente - Nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                      <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Monto original</b></label>
                        <label class="titulos" style="margin-left:21%"><b>Capital desembolsado</b></label>
                        <label class="titulos" style="margin-left:15%"><b>Saldo actual</b></label>
                    </div>

                    <div class="formato">
                        <input id="MontoOriginal" runat="server" type="text" class="formatoinput3" min="0" placeholder="Monto original" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="CapitalDesem" runat="server" type="text" class="formatoinput3" min="0" placeholder="Capital desembolsado" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="SaldoActual" runat="server" type="text" min="0" class="formatoinput3" placeholder="Saldo actual" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br /><br />

                     <div id="divgridviewprospectos1" style="overflow: auto; height: 147px">
     <asp:GridView ID="gridview1" CssClass="container"  style="width: 692px;  text-align:center" runat="server"  HeaderStyle-ForeColor="Black"
    AutoGenerateColumns="False" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. de prestamo" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblcodprospeto" Text='<%# Eval("COBNUMPRODUCT") %>' runat="server" />
                        </ItemTemplate>

<ControlStyle CssClass="dise&#241;o"></ControlStyle>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lbltipotelefono" Text='<%# Eval("CIFNOMBRECLIE") %>' runat="server" />
                        </ItemTemplate>

<ControlStyle CssClass="dise&#241;o"></ControlStyle>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Relación">
                           <ItemTemplate>
                            <asp:Label ID="lblnombretelefono" Text='<%# Eval("COBDESRELACION") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="Black"></HeaderStyle>
        </asp:GridView>
                </div>

                </div><br />

               

                      <div class="menu2" id="ventana" runat="server">

                    <div class="formato3">
                           <label class="titulos"><b>No. de préstamo</b></label>
                          <input id="CreditoNumero" runat="server" type="text" class="formatoinput5" min="0" placeholder="No. prestamo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                     <div class="formato3">
                         <label class="titulos"><b>No. de incidente</b></label>
                        <input id="NumeroIncidente" runat="server" type="text" class="formatoinput5" min="0" placeholder="No. incidente" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formato3">
                         <label class="titulos"><b>CIF</b></label>
                        <input id="NumCif" runat="server" type="text" class="formatoinput5" min="0" placeholder="CIF" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formato3">
                        <label class="titulos"><b>Cliente - Nombre</b></label>
                        <textarea id="ClienteNombre" runat="server" type="text" class="formatoinput5" placeholder="Cliente - Nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"></textarea>
                    </div><br />
                </div>

                <div class="encabezado">

                    <div style="display:flex; justify-content:center">
                        <label style="font-size:15px" class="titulos">Resolución de trámite</label>
                    </div><br /><br />

                  <label class="titulos" style="margin-bottom:10px"><b>Tipo de documento </b></label>
                    
                     <div class="formato">
                        <asp:DropDownList id="PTipoDocumento" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                       <asp:FileUpload id="FileUpload1" runat="server"></asp:FileUpload>
                         <asp:Button ID="Agregar" OnClick="agregar_Click" runat="server" Width="20%" Height="30px" CssClass="boton3" Text="Agregar" />
                    </div><br /><br />

                    <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 123px">
                        <asp:GridView ID="gridViewDocumentos" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedDocumento" BorderStyle="Solid">
                             <Columns>
                                <asp:TemplateField ControlStyle-CssClass="diseño" Visible="false" HeaderText="No. documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblid" Text='<%# Eval("Codigo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Tipo documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lbltipodoc" Text='<%# Eval("TipoDocumento") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnombredoc" Text='<%# Eval("Nombre") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Ver Documento" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="Black">
                                    <ItemStyle Width="135px"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div>

                     <div class="formato3">
                        <label class="titulos"><b>Estado de la demanda</b></label>
                        <asp:DropDownList id="EstadoDemanda" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>
                      </div><br />

                   <div class="formato3">
                        <label class="titulos"><b>Fecha de notificación</b</label>
                        <input id="FechaNotificacion" runat="server" type="date" class="formatoinput2" />
                    </div><br />

                    <label class="titulos">Seleccione las medidas precautorias otorgadas</label><br /><br />
                           <div class="formatocheck">
                             <div class="formatocheck2">
                                <input id="MedidasPre1" runat="server" type="checkbox" class="formatocheckbox" value="1" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="MedidasPre1" class="titulos">&nbsp;&nbsp;Embargo de Salario</label>
                             </div>
                              <div class="formatocheck2">
                                <input id="MedidasPre2" runat="server" type="checkbox" class="formatocheckbox" value="2" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="MedidasPre2" class="titulos">&nbsp;&nbsp;Embargo de cuentas bancarias</label>
                              </div>
                         </div>

                         <div class="formatocheck">
                             <div class="formatocheck2">
                                 <input id="MedidasPre3" runat="server" type="checkbox" class="formatocheckbox" value="3" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                              <label for="MedidasPre3" class="titulos">&nbsp;&nbsp;Arraigo</label>
                             </div>
                             <div class="formatocheck2">
                                <input id="MedidasPre4" runat="server" type="checkbox" class="formatocheckbox" value="4" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="MedidasPre4" class="titulos">&nbsp;&nbsp;Embargo en cooperativas</label>
                             </div>
                         </div>

                         <div class="formatocheck">
                             <div class="formatocheck2">
                                <input id="MedidasPre5" runat="server" type="checkbox" class="formatocheckbox" value="4" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="MedidasPre5" class="titulos">&nbsp;&nbsp;<b>Embargo de bienes</b></label>
                             </div>
                             <div class="formatocheck2">
                                <input id="MedidasPre6" runat="server" type="checkbox" class="formatocheckbox" value="5" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="MedidasPre6" class="titulos">&nbsp;&nbsp;Otra</label>
                             </div>
                         </div>
                      <input id="OtrasMedidas" runat="server" type="text" class="formatoinput2" placeholder="Ingrese nombre de otra medida" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    </div><br /><br />

                 <div class="formato2">
                    <asp:Button ID="Guardar" runat="server" CssClass="boton" Text="Guardar" OnClick="Guardar_Click"/>
                  </div><br />
            </div>
        </div>

        <script>
            $(document).ready(function () {
                $('.menu').load('MenuPrincipal.aspx');
            });
        </script>

        <script>
            posicionarMenu();

            $(window).scroll(function () {
                posicionarMenu();
            });

            function posicionarMenu() {
                var altura_del_header = $('.header').outerHeight(true);
                var altura_del_menu = $('.menu2').outerHeight(true);

                if ($(window).scrollTop() >= altura_del_header) {
                    $('.menu2').addClass('fixed');
                    $('.menu2').addClass('fixed');
                    $('.wrapper').css('margin-top', (altura_del_menu) + 'px');
                } else {
                    $('.menu2').removeClass('fixed');
                    $('.wrapper').css('margin-top', '0');
                }
            }

        </script>

    </form>
</body>
</html>
