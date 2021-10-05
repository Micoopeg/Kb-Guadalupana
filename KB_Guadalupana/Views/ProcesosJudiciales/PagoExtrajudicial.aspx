<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagoExtrajudicial.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.PagoExtrajudicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Pago extrajudiciales</title>
     <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');

        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:"Montserrat";
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
            width:100%;
            align-items: center;
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
             margin-top:8px;
        }

        .formatoinput2{
            width:99%;
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

        .formatoinput6 {
            width: 17%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 25px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
            justify-content:flex-end;
            text-align:right
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
             display:flex;
            align-items:center;
            align-content:center;
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
            font-family:"Montserrat";
            max-width: 90%;
            min-width: 90%;
            max-height:30px;
            min-height:30px;
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
            width:30%;
        }

        .header{ border-top:1px solid white;background:white; color:#333; height:0px; width:100%; font-family: 'Montserrat', cursive; text-align:center}
.menu2{visibility:hidden; height:auto; width:17%; color:white; text-align:left; padding-top:5px; left:0; margin-left:0px;margin-top:75px;background-color:#435F7A; border:2px #4B752B solid;padding-left:13px;}
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
                    <label style="font-size:18px" class="titulos">Pago extrajudicial</label>
                 </div><br />

                <div class="header"></div>

                <div id="Div1" runat="server" class="encabezado" style="border-color:#8DDB51; border:2px #4B752B solid">
                          <label style="font-size:15px" class="titulos"><b>Información principal</b></label><br /><br />

                        <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>No. de préstamo</b></label>
                        <label class="titulos" style="margin-left:11%"><b>Incidente</b></label>
                        <label class="titulos" style="margin-left:16%"><b>DPI</b></label>
                        <label class="titulos" style="margin-left:23%"><b>CIF</b></label>
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

                     <input id="Estado" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" visible="false"/>
                    <input id="Garantia" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" visible="false"/>
                    <input id="Morosidad" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" visible="false"/>
                     <input id="FechaActual" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" visible="false"/>
                     <input id="inSubtotalSaldo" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" visible="false"/>
                     <input id="inSubtotalDescuento" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" visible="false"/>
                     <input id="inSubtotalPorcentaje" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" visible="false"/>
                     <input id="inSubtotalPagar" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" visible="false"/>
                     <input id="Capitalporcentaje2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" visible="false"/>
                    <input id="CapitalPagar2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="InteresesPorcentaje2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="InteresesPagar2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="MoraPorcentaje2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="MoraPagar2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="GastosPorcentaje2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="GastosPagar2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="CobranzaPorcentaje2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="CobranzaPagar2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="TotalPorcentaje2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="TotalPagar2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="TotalSaldo2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="TotalDescuento2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="HonorariosPorcentaje2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="CostasPorcentaje2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="DesistimientoPorcentaje2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="HonorariosPagar2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="CostasPagar2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="DesistimientoPagar2" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="TotalPorcentaje3" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="TotalPagar3" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="TotalSaldo3" runat="server" type="text" class="formatoinput6" visible="false"/>
                    <input id="TotalDescuento3" runat="server" type="text" class="formatoinput6" visible="false"/>

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
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>
                </div>

                </div><br />

                <div class="encabezado">

                    <div class="formato3">
                        <label class="titulos"><b>Tipo de pago a realizar</b></label>
                        <asp:DropDownList id="TipoPago" runat="server" Width="100%" class="formatoinput2" OnSelectedIndexChanged="TipoPago_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div><br /><br />

                    <div id="TotalidadDeuda" runat="server">
                        <div id="datos" runat="server">
                            <div class="formatoTitulo">
                                <label class="titulos"><b>Cartera</b></label>
                                <label class="titulos" style="margin-left:46%"><b>Concentración</b></label>
                            </div>
                            <div class="formato">
                                <input id="Cartera" runat="server" type="text" class="formatoinput" placeholder="Ingrese cartera" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="Concentracion" runat="server" type="text" class="formatoinput" placeholder="Ingrese concentración" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            </div><br /><br />
                        </div>

                        <div id="fechas" runat="server" class="formato">
                            <label class="titulos">Para cubir cuotas de </label>
                            <input id="FechaInicio" runat="server" type="date" class="formatoinput3"/> a 
                            <input id="FechaFin" runat="server" type="date" class="formatoinput3"/>
                        </div><br /><br /><br />

                        <div id="tabladatos" runat="server">
                            <div class="formatoTitulo" style="margin-bottom:5px">
                                <label class="titulos"><b>Rubro</b></label>
                                <label class="titulos" style="margin-left:18%"><b>Saldo real</b></label>
                                <label class="titulos" style="margin-left:11%"><b>Descuento</b></label>
                                <label class="titulos" style="margin-left:11%"><b>Porcentaje</b></label>
                                <label class="titulos" style="margin-left:9%"><b>Saldo a pagar</b></label>
                            </div><br />

                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Capital vencido</b></label>
                                <input id="CapitalSaldo" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), capitalsaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="CapitalDescuento" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), capitaldescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <span id="CapitalPorcentaje" runat="server" style="background-color:white; color:black" class="formatoinput6" onchange="capitalporcentaje();" >0.00 %</span>
                                <span id="CapitalPago" style="background-color:white; color:black" runat="server" class="formatoinput6" onchange="capitalpagar(this.value);">Q 0.00</span>
                            </div><br />

                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Intereses vencidos</b></label>
                                <input id="InteresesSaldo" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), interesessaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="InteresesDescuento" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), interesesdescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <span id="InteresesPorcentaje" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="interesesporcentaje(this.value);">0.00 %</span>
                                <span id="InteresesPagar" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="interesessaldopagar(this.value);">Q 0.00</span>
                            </div><br />

                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Mora</b></label>
                                <input id="MoraSaldo" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), morasaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="MoraDescuento" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), moradescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <span id="MoraPorcentaje" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="moraporcentaje(this.value);">0.00 %</span>
                                <span id="MoraPagar" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="morasaldopagar(this.value);">Q 0.00</span>
                            </div><br />

                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Gastos</b></label>
                                <input id="GastosSaldo" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), gastossaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="GastosDescuento" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), gastosdescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <span id="GastosPorcentaje" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="gastosporcentaje(this.value);">0.00 %</span>
                                <span id="GastosPagar" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="gastossaldopagar(this.value);">Q 0.00</span>
                            </div><br />

                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Cobranza</b></label>
                                <input id="CobranzaSaldo" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), cobranzasaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="CobranzaDescuento" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), cobranzadescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <span id="CobranzaPorcentaje" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="cobranzaporcentaje(this.value);">0.00 %</span>
                                <span id="CobranzaPagar" style="background-color:white;color:black" runat="server" class="formatoinput6" onchange="cobranzasaldopagar(this.value);">Q 0.00</span>
                            </div><br />

                            <div class="formatoTitulo">
                                <span id="Total" runat="server" class="titulos"><b>Total</b></span>
                                <span id="subtotalSaldo" runat="server" class="titulos" style="width:17%; margin-left:12%; justify-content:flex-end"><b>Q 0.00</b></span>
                                <span id="subtotalDescuento" runat="server" class="titulos" style="width:17%; margin-left:3%; justify-content:flex-end"><b>Q 0.00</b></span>
                                <%--<span id="subtotalPorcentaje" runat="server" class="titulos" style="width:17%; margin-left:4%; justify-content:flex-end"><b>Q 0.00</b></span>--%>
                                <%--<span id="subtotalPagar" runat="server" class="titulos" style="width:17%; margin-left:5%; justify-content:flex-end"><b>Q 0.00</b></span>--%>
                            </div>
                            <br /><br /><br />
                        </div>

                        <div id="pagosextras" runat="server">
                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Honorarios profesionales</b></label>
                                <input id="HonorariosSaldo" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), honorariossaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="HonorariosDescuento" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), honorariosdescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <span id="HonorariosPorcentaje" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="honorariosporcentaje(this.value);"> 0.00 %</span>
                                <span id="HonorariosPagar" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="honorariospagar(this.value);"> Q 0.00</span>
                            </div><br />

                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Costas y gastos judiciales</b></label>
                                <input id="CostasSaldo" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), costassaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="CostasDescuento" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), costasdescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <span id="CostasPorcentaje" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="costasporcentaje(this.value);"> 0.00 %</span>
                                <span id="CostasPagar" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="costaspagar(this.value);"> Q 0.00</span>
                            </div><br />

                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Desistimiento</b></label>
                                <input id="DesistimientoSaldo" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), desistimientosaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="DesistimientoDescuento" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), desistimientodescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <span id="DesistimientoPorcentaje" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="diligenciamientoporcentaje(this.value);"> 0.00 %</span>
                                <span id="DesistimientoPagar" runat="server" style="background-color:white;color:black" class="formatoinput6" onchange="diligenciamientopagar(this.value);">Q 0.00</span>
                            </div><br />

                            <div class="formatoTitulo">
                                <span class="titulos"><b>Total</b></span>
                                <span id="TotalSaldo" runat="server" class="titulos" style="width:17%; margin-left:12%; justify-content:flex-end"><b>Q 0.00</b></span>
                                <span id="TotalDescuento" runat="server" class="titulos" style="width:17%; margin-left:3%; justify-content:flex-end"><b>Q 0.00</b></span>
                                <%--<span id="TotalPorcentaje" runat="server" class="titulos" style="width:17%; margin-left:4%; justify-content:flex-end"><b>Q 0.00</b></span>
                                <span id="TotalPagar" runat="server" class="titulos" style="width:17%; margin-left:5%; justify-content:flex-end"><b>Q 0.00</b></span>--%>
                            </div>
                        </div>
                    </div>

                   <%-- <div id="SaldoVencido" runat="server">
                        <div class="formatoTitulo">
                            <label class="titulos"><b>Cartera</b></label>
                            <label class="titulos" style="margin-left:46%"><b>Concentración</b></label>
                        </div>
                        <div class="formato">
                            <input id="Cartera2" runat="server" type="text" class="formatoinput" placeholder="Ingrese cartera" onkeyup="format(this)" onchange="format(this), capitalsaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="Concentracion2" runat="server" type="text" class="formatoinput" placeholder="Ingrese concentración" onkeyup="format(this)" onchange="format(this), capitalsaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br /><br /><br />

                        

                         <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>Rubro</b></label>
                            <label class="titulos" style="margin-left:18%"><b>Saldo real</b></label>
                            <label class="titulos" style="margin-left:11%"><b>Descuento</b></label>
                            <label class="titulos" style="margin-left:11%"><b>Porcentaje</b></label>
                            <label class="titulos" style="margin-left:9%"><b>Saldo a pagar</b></label>
                        </div><br />

                        <div class="formato">
                            <label class="titulos" style="width:19%"><b>Capital vencido</b></label>
                            <input id="CapitalSaldo2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), capitalsaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="CapitalDescuento2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), capitaldescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="CapitalPorcentaje2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese pocentaje" value="0" onkeyup="format(this)" onchange="format(this), capitalporcentaje(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="CapitalPago2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" value="0" onkeyup="format(this)" onchange="format(this), capitalsaldopagar(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div class="formato">
                            <label class="titulos" style="width:19%"><b>Intereses vencidos</b></label>
                            <input id="InteresSaldo2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), interesessaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="InteresesDescuento2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), interesesdescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="InteresesPorcentaje2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese pocentaje" value="0" onkeyup="format(this)" onchange="format(this), interesesporcentaje(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="InteresesPago2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" value="0" onkeyup="format(this)" onchange="format(this), interesessaldopagar(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div class="formato">
                            <label class="titulos" style="width:19%"><b>Mora</b></label>
                            <input id="MoraSaldo2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), morasaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="MoraDescuento2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), moradescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="MoraPorcentaje2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese pocentaje" value="0" onkeyup="format(this)" onchange="format(this), moraporcentaje(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="MoraPago2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" value="0" onkeyup="format(this)" onchange="format(this), morasaldopagar(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div class="formato">
                            <label class="titulos" style="width:19%"><b>Gastos</b></label>
                            <input id="GastosSaldo2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), gastossaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="GastosDescuento2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), gastosdescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="GastosPorcentaje2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese pocentaje" value="0" onkeyup="format(this)" onchange="format(this), gastosporcentaje(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="GastosPago2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" value="0" onkeyup="format(this)" onchange="format(this), gastossaldopagar(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div class="formato">
                            <label class="titulos" style="width:19%"><b>Cobranza</b></label>
                            <input id="CobranzaSaldo2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), cobranzasaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="CobranzaDescuento2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), cobranzadescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="CobranzaPorcentaje2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese pocentaje" value="0" onkeyup="format(this)" onchange="format(this), cobranzaporcentaje(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="CobranzaPago2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" value="0" onkeyup="format(this)" onchange="format(this), cobranzasaldopagar(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div class="formatoTitulo">
                            <label class="titulos"><b>Total</b></label>
                            <span class="titulos" style="width:19%; margin-left:15%; justify-content:flex-end"><b>Q 0.00</b></span>
                            <span class="titulos" style="width:19%; margin-left:4%; justify-content:flex-end"><b>Q 0.00</b></span>
                            <span class="titulos" style="width:19%; margin-left:4%; justify-content:flex-end"><b>Q 0.00</b></span>
                            <span class="titulos" style="width:19%; margin-left:5%; justify-content:flex-end"><b>Q 0.00</b></span>
                        </div>
                        <br /><br /><br />

                         <div id="pagoextras2" runat="server" visible="false">
                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Honorarios profesionales</b></label>
                                <input id="HonorariosSaldo2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), cobranzasaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="HonorariosDescuento2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), cobranzadescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="HonorariosPorcentaje2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese pocentaje" value="0" onkeyup="format(this)" onchange="format(this), cobranzaporcentaje(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="totalpagar" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" value="0" onkeyup="format(this)" onchange="format(this), cobranzasaldopagar(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            </div><br />

                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Costas y gastos judiciales</b></label>
                                <input id="CostasSaldo2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), cobranzasaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="CostasDescuento2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), cobranzadescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="CostasPorcentaje2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese pocentaje" value="0" onkeyup="format(this)" onchange="format(this), cobranzaporcentaje(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="CostasPagar2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" value="0" onkeyup="format(this)" onchange="format(this), cobranzasaldopagar(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            </div><br />

                            <div class="formato">
                                <label class="titulos" style="width:17%"><b>Desistimiento</b></label>
                                <input id="DesistimientoSaldo2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo real" value="0" onkeyup="format(this)" onchange="format(this), cobranzasaldo(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="DesistimientoDescuento2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese descuento" value="0" onkeyup="format(this)" onchange="format(this), desistimientodescuento(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="DesistimientoPorcentaje2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese pocentaje" value="0" onkeyup="format(this)" onchange="format(this), cobranzaporcentaje(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                <input id="DesistimientoPagar2" runat="server" type="text" class="formatoinput6" placeholder="Ingrese saldo a pagar" value="0" onkeyup="format(this)" onchange="format(this), cobranzasaldopagar(this.value);" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            </div><br />

                            <div class="formatoTitulo">
                                <span class="titulos"><b>Total</b></span>
                                <span id="TotalSaldo2" runat="server" class="titulos" style="width:17%; margin-left:12%; justify-content:flex-end"><b>Q 0.00</b></span>
                                <span id="TotalDescuento2" runat="server" class="titulos" style="width:17%; margin-left:3%; justify-content:flex-end"><b>Q 0.00</b></span>
                                <span id="TotalPorcentaje2" runat="server" class="titulos" style="width:17%; margin-left:4%; justify-content:flex-end"><b>Q 0.00</b></span>
                                <span id="TotalPagar2" class="titulos" style="width:17%; margin-left:5%; justify-content:flex-end"><b>Q 0.00</b></span>
                            </div>
                        </div>
                    </div>--%>

                    <br /><br /><br />

                     <div class="formato2">
                        <asp:Button ID="Generar" runat="server" Width="45%" CssClass="boton3" Text="Generar Integración" OnClick="Generar_Click" />
                     </div><br />

                    <div id="integracion" runat="server">
                        <label class="titulos"><b>Integración</b></label><br />
                        <div class="formato">
                            <asp:DropDownList id="DocumentoIntegracion" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                            <asp:FileUpload id="FileUpload1" runat="server"></asp:FileUpload>
                            <asp:Button ID="Agregar" OnClick="agregar_Click" runat="server" Width="20%" Height="30px" CssClass="boton3" Text="Agregar" />
                        </div><br /><br />
                     <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 150px">
                        <asp:GridView ID="gridViewIntegracion" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedIntegracion" BorderStyle="Solid">
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
                                <asp:ButtonField   Text="Ver Documento" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="White">
                                    <ItemStyle Width="135px" ForeColor="White"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div><br /><br /><br />

                        <div class="formato3">
                            <span class="titulos"><b>Observaciones</b></span>
                            <input id="Observaciones" runat="server" type="text" class="formatoinput2" placeholder="Ingrese observaciones " maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                    </div>
                    

                    <%--<label class="titulos"><b>Recibo de pago</b></label><br />
                        <div class="formato">
                            <asp:DropDownList id="DocumentoRecibo" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                            <asp:FileUpload id="FileUpload2" runat="server"></asp:FileUpload>
                            <asp:Button ID="Agregar2" OnClick="agregar2_Click" runat="server" Width="20%" Height="30px" CssClass="boton3" Text="Agregar" />
                        </div><br /><br />
                     <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 150px">
                        <asp:GridView ID="gridViewRecibo" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedRecibo" BorderStyle="Solid">
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
                                <asp:ButtonField   Text="Ver Documento" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="White">
                                    <ItemStyle Width="135px" ForeColor="White"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div><br /><br /><br />--%>

                </div>

                <div class="formato2">
                    <asp:Button ID="Solicitud" runat="server" CssClass="boton" Text="Enviar solicitud de desistimiento" OnClick="Solicitud_Click" />
                  </div><br />

                <div class="menu2" id="ventana" runat="server" style="overflow: auto; height: 450px">

                    <div class="formato3">
                           <label class="titulos"><b>No. de préstamo</b></label>
                          <input id="CreditoNumero" runat="server" type="text" class="formatoinput5" min="0" placeholder="No. prestamo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                     <div class="formato3">
                         <label class="titulos"><b>Incidente</b></label>
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

                         <label class="titulos"><b>Comentarios</b></label>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="formato3">
                                    <textarea id="Comentario1" runat="server" type="text" class="formatoinput5" maxlength="150" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"> <%# Eval("Comentario") %> </textarea>
                                </div><br />
                            </ItemTemplate>
                        </asp:Repeater>
                </div>

            </div>
        </div>

        <script>
           $(document).ready(function () {
               $('.menu').load('MenuPrincipal.aspx');
           });
        </script>

         <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
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

        <script>
            function format(input) {
                var num = input.value.replace(/\,/g, '');
                if (!isNaN(num)) {
                    num = num.toString().split('').reverse().join('').replace(/(?=\d*\,?)(\d{3})/g, '$1,');
                    num = num.split('').reverse().join('').replace(/^[\,]/, '');
                    input.value = num;
                }

                else {
                    alert('Solo se permiten numeros');
                    input.value = input.value.replace(/[^\d\,]*/g, '');
                }
            }

            $('#OtrosGastos').mask('000,000,000.00', { reverse: true });

        </script>

        <script>
            function capitalsaldo(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var totalsaldoapagar = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var porcentaje = 0;
                var totalporcentaje = 0;
                var porcentajecapital = 0;
                var porcentajeintereses = 0;
                var porcentajemora = 0;
                var porcentajegastos = 0;
                var porcentajecobranza = 0;
                var sumadeporcentajes = 0;
                var desistimiento = 0;
                var costas = 0;
                var honorarios = 0;
                var total = 0;
                

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalSaldo').innerHTML;
                
                if (cantidad == null || cantidad == undefined || cantidad == "") {
                    
                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CapitalDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    
                    //porcentajecapital = document.getElementById('CapitalPorcentaje').innerHTML;
                    //porcentajecapital = (porcentajecapital == null || porcentajecapital == undefined || porcentajecapital == "") ? 0 : porcentajecapital;
                    //var porcentajecapital2 = porcentajecapital.split(' ');
                    //porcentajecapital = porcentajecapital2[0];

                    //porcentajeintereses = document.getElementById('InteresesPorcentaje').innerHTML;
                    //porcentajeintereses = (porcentajeintereses == null || porcentajeintereses == undefined || porcentajeintereses == "") ? 0 : porcentajeintereses;
                    //var porcentajeinterese2 = porcentajeintereses.split(' ');
                    //porcentajeintereses = porcentajeintereses2[0];

                    //porcentajemora = document.getElementById('MoraPorcentaje').innerHTML;
                    //porcentajemora = (porcentajemora == null || porcentajemora == undefined || porcentajemora == "") ? 0 : porcentajemora;
                    //var porcentajemora2 = porcentajemora.split(' ');
                    //porcentajemora = porcentajemora2[0];

                    //porcentajegastos = document.getElementById('GastosPorcentaje').innerHTML;
                    //porcentajegastos = (porcentajegastos == null || porcentajegastos == undefined || porcentajegastos == "") ? 0 : porcentajegastos;
                    //var porcentajegastos2 = porcentajegastos.split(' ');
                    //porcentajegastos = porcentajegastos2[0];

                    //porcentajecobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
                    //porcentajecobranza = (porcentajecobranza == null || porcentajecobranza == undefined || porcentajecobranza == "") ? 0 : porcentajecobranza;
                    //var porcentajecobranza2 = porcentajecobranza.split(' ');
                    //porcentajecobranza = porcentajecobranza2[0];

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(capital) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(capital)) * 100);
                    //sumadeporcentajes = (parseFloat(porcentajecapital) + parseFloat(porcentajeintereses) + parseFloat(porcentajemora) + parseFloat(porcentajegastos) + parseFloat(porcentajecobranza));
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;
                    alert(totaldinero);
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CapitalPago').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CapitalPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    //document.getElementById('subtotalPorcentaje').innerHTML = sumadeporcentajes.toFixed(2) + ' %';
                }
                else {
                   
                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CapitalDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }
                    //alert('funciona');
                    //porcentajecapital = document.getElementById('CapitalPorcentaje').innerHTML;
                    //porcentajecapital = (porcentajecapital == null || porcentajecapital == undefined || porcentajecapital == "") ? 0 : porcentajecapital;
                    //var porcentajecapital2 = porcentajecapital.split(' ');
                    //porcentajecapital = porcentajecapital2[0];

                    //porcentajeintereses = document.getElementById('InteresesPorcentaje').innerHTML;
                    //porcentajeintereses = (porcentajeintereses == null || porcentajeintereses == undefined || porcentajeintereses == "") ? 0 : porcentajeintereses;
                    //var porcentajeinterese2 = porcentajeintereses.split(' ');
                    //porcentajeintereses = porcentajeintereses2[0];

                    //porcentajemora = document.getElementById('MoraPorcentaje').innerHTML;
                    //porcentajemora = (porcentajemora == null || porcentajemora == undefined || porcentajemora == "") ? 0 : porcentajemora;
                    //var porcentajemora2 = porcentajemora.split(' ');
                    //porcentajemora = porcentajemora2[0];

                    //porcentajegastos = document.getElementById('GastosPorcentaje').innerHTML;
                    //porcentajegastos = (porcentajegastos == null || porcentajegastos == undefined || porcentajegastos == "") ? 0 : porcentajegastos;
                    //var porcentajegastos2 = porcentajegastos.split(' ');
                    //porcentajegastos = porcentajegastos2[0];

                    //porcentajecobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
                    //porcentajecobranza = (porcentajecobranza == null || porcentajecobranza == undefined || porcentajecobranza == "") ? 0 : porcentajecobranza;
                    //var porcentajecobranza2 = porcentajecobranza.split(' ');
                    //porcentajecobranza = porcentajecobranza2[0];

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(capital) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(capital)) * 100);
                    total = (parseFloat(desistimiento) + parseFloat(costas) + parseFloat(desistimiento));
                    //alert(totaldinero);
                    //sumadeporcentajes = (parseFloat(porcentajecapital) + parseFloat(porcentajeintereses) + parseFloat(porcentajemora) + parseFloat(porcentajegastos) + parseFloat(porcentajecobranza));
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CapitalPago').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CapitalPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                }



            }

            function interesessaldo(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var totalsaldoapagar = 0;
                var porcentaje = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;
                

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalSaldo').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('InteresesDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    porcentaje = document.getElementById('InteresesDescuento').value;
                    porcentaje = (porcentaje == null || porcentaje == undefined || porcentaje == "") ? 0 : porcentaje;
                    if (porcentaje != 0) {
                        var porcentajesaldo = porcentaje.split(',');

                        var porcentajefinal = "";

                        for (var i = 0; i < porcentajesaldo.length; i++) {
                            porcentajefinal = porcentajefinal + porcentajesaldo[i];
                        }
                        porcentaje = porcentajefinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(intereses) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(intereses)) * 100);
                    
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('InteresesPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('InteresesPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('InteresesDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(intereses) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(intereses)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('InteresesPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('InteresesPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }



            }

            function morasaldo(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var totalsaldoapagar = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalSaldo').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('MoraDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(mora) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(mora)) * 100);

                    //document.getElementById('inSubtotalSaldo').value = totaldinero;
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('MoraPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('MoraPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('MoraDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(mora) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(mora)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('MoraPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('MoraPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }



            }

            function gastossaldo(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var totalsaldoapagar = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalSaldo').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('GastosDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(gastos) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(gastos)) * 100);
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('GastosPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('GastosPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('GastosDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(gastos) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(gastos)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('GastosPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('GastosPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }



            }

            function cobranzasaldo(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var totalsaldoapagar = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalSaldo').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CobranzaDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(cobranza) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(cobranza)) * 100);
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CobranzaPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CobranzaPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }



                    descuento = document.getElementById('CobranzaDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(cobranza) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(cobranza)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CobranzaPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CobranzaPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }



            }
        </script>


        <script>
            function capitaldescuento(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var totalsaldoapagar = 0;
                var descuento = 0;
                var porcentaje = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CapitalSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    porcentaje = document.getElementById('CapitalSaldo').value;
                    porcentaje = (porcentaje == null || porcentaje == undefined || porcentaje == "") ? 0 : porcentaje;
                    if (porcentaje != 0) {
                        var porcentajesaldo = porcentaje.split(',');

                        var porcentajefinal = "";

                        for (var i = 0; i < porcentajesaldo.length; i++) {
                            porcentajefinal = porcentajefinal + porcentajesaldo[i];
                        }
                        porcentaje = porcentajefinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(capital));
                    totalporcentaje = ((parseFloat(capital) / parseFloat(descuento)) * 100);

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CapitalPago').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CapitalPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CapitalSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    porcentaje = document.getElementById('CapitalSaldo').value;
                    porcentaje = (porcentaje == null || porcentaje == undefined || porcentaje == "") ? 0 : porcentaje;
                    if (porcentaje != 0) {
                        var porcentajesaldo = porcentaje.split(',');

                        var porcentajefinal = "";

                        for (var i = 0; i < porcentajesaldo.length; i++) {
                            porcentajefinal = porcentajefinal + porcentajesaldo[i];
                        }
                        porcentaje = porcentajefinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(capital));
                    totalporcentaje = ((parseFloat(capital) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CapitalPago').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CapitalPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);
                }



            }

            function interesesdescuento(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var totalsaldoapagar = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('InteresesSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(intereses));
                    totalporcentaje = ((parseFloat(intereses) / parseFloat(descuento)) * 100);

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('InteresesPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('InteresesPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('InteresesSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(intereses));
                    totalporcentaje = ((parseFloat(intereses) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('InteresesPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('InteresesPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);
                }



            }

            function moradescuento(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var totalsaldoapagar = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('MoraSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(mora));
                    totalporcentaje = ((parseFloat(mora) / parseFloat(descuento)) * 100);

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('MoraPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('MoraPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('MoraSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(mora));
                    totalporcentaje = ((parseFloat(mora) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('MoraPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('MoraPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);
                }



            }

            function gastosdescuento(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var saldototalapagar = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('GastosSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(gastos));
                    totalporcentaje = ((parseFloat(gastos) / parseFloat(descuento)) * 100);

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('GastosPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('GastosPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('GastosSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(gastos))
                    totalporcentaje = ((parseFloat(gastos) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('GastosPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('GastosPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);
                }



            }

            function cobranzadescuento(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var totalsaldoapagar = 0;
                var totalporcentaje = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CobranzaSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(cobranza));
                    totalporcentaje = ((parseFloat(cobranza) / parseFloat(descuento)) * 100);

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CobranzaPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CobranzaPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CobranzaSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalporcentaje = ((parseFloat(cobranza) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CobranzaPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CobranzaPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);
                }



            }
        </script>


        <script>
            function capitalporcentaje() {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                alert('funciones');
                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalPorcentaje').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalPorcentaje').innerHTML;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPorcentaje').innerHTML;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPorcentaje').innerHTML;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPorcentaje').innerHTML;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    alert(capital);
                    document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('CapitalPorcentaje').innerHTML;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPorcentaje').innerHTML;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPorcentaje').innerHTML;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPorcentaje').innerHTML;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    alert(capital);
                    document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }



            }

            function interesesporcentaje(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalPorcentaje').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPorcentaje').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPorcentaje').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('CapitalPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPorcentaje').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPorcentaje').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }



            }

            function moraporcentaje(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalPorcentaje').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPorcentaje').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPorcentaje').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('CapitalPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPorcentaje').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPorcentaje').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }



            }

            function gastosporcentaje(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalPorcentaje').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPorcentaje').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPorcentaje').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('CapitalPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPorcentaje').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPorcentaje').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }



            }

            function cobranzaporcentaje(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalPorcentaje').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPorcentaje').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPorcentaje').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('CapitalPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPorcentaje').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPorcentaje').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }



            }
        </script>


        <script>
            function capitalsaldopagar(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalPagar').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalPago').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPagar').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPagar').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPagar').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('CapitalPago').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPagar').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPagar').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPagar').innerHTML = formatter.format(totaldinero);
                }



            }

            function interesessaldopagar(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalPagar').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalPago').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPagar').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPagar').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPagar').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('CapitalPago').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPagar').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPagar').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPagar').innerHTML = formatter.format(totaldinero);
                }



            }

            function morasaldopagar(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalPagar').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalPago').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPagar').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPagar').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPagar').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('CapitalPago').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPagar').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPagar').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPagar').innerHTML = formatter.format(totaldinero);
                }



            }

            function gastossaldopagar(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalPagar').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalPago').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPagar').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPagar').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPagar').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('CapitalPago').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPagar').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPagar').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPagar').innerHTML = formatter.format(totaldinero);
                }



            }

            function cobranzasaldopagar(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalPagar').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalPago').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPagar').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPagar').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPagar').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('CapitalPago').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosPagar').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaPagar').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));

                    document.getElementById('subtotalPagar').innerHTML = formatter.format(totaldinero);
                }



            }
        </script>

        <script>

            function honorariossaldo(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var totalsaldoapagar = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var porcentaje = 0;
                var totalporcentaje = 0;
                var porcentajecapital = 0;
                var porcentajeintereses = 0;
                var porcentajemora = 0;
                var porcentajegastos = 0;
                var porcentajecobranza = 0;
                var sumadeporcentajes = 0;
                var costas = 0;
                var honorarios = 0;
                var desistimiento = 0;
                var total = 0;


                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalSaldo').innerHTML;

                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CapitalDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }


                    //porcentajecapital = document.getElementById('CapitalPorcentaje').innerHTML;
                    //porcentajecapital = (porcentajecapital == null || porcentajecapital == undefined || porcentajecapital == "") ? 0 : porcentajecapital;
                    //var porcentajecapital2 = porcentajecapital.split(' ');
                    //porcentajecapital = porcentajecapital2[0];

                    //porcentajeintereses = document.getElementById('InteresesPorcentaje').innerHTML;
                    //porcentajeintereses = (porcentajeintereses == null || porcentajeintereses == undefined || porcentajeintereses == "") ? 0 : porcentajeintereses;
                    //var porcentajeinterese2 = porcentajeintereses.split(' ');
                    //porcentajeintereses = porcentajeintereses2[0];

                    //porcentajemora = document.getElementById('MoraPorcentaje').innerHTML;
                    //porcentajemora = (porcentajemora == null || porcentajemora == undefined || porcentajemora == "") ? 0 : porcentajemora;
                    //var porcentajemora2 = porcentajemora.split(' ');
                    //porcentajemora = porcentajemora2[0];

                    //porcentajegastos = document.getElementById('GastosPorcentaje').innerHTML;
                    //porcentajegastos = (porcentajegastos == null || porcentajegastos == undefined || porcentajegastos == "") ? 0 : porcentajegastos;
                    //var porcentajegastos2 = porcentajegastos.split(' ');
                    //porcentajegastos = porcentajegastos2[0];

                    //porcentajecobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
                    //porcentajecobranza = (porcentajecobranza == null || porcentajecobranza == undefined || porcentajecobranza == "") ? 0 : porcentajecobranza;
                    //var porcentajecobranza2 = porcentajecobranza.split(' ');
                    //porcentajecobranza = porcentajecobranza2[0];

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(capital) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(capital)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));
                    //sumadeporcentajes = (parseFloat(porcentajecapital) + parseFloat(porcentajeintereses) + parseFloat(porcentajemora) + parseFloat(porcentajegastos) + parseFloat(porcentajecobranza));
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;
                    
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CapitalPago').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CapitalPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                    //document.getElementById('subtotalPorcentaje').innerHTML = sumadeporcentajes.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('HonorariosDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }


                    //porcentajecapital = document.getElementById('CapitalPorcentaje').innerHTML;
                    //porcentajecapital = (porcentajecapital == null || porcentajecapital == undefined || porcentajecapital == "") ? 0 : porcentajecapital;
                    //var porcentajecapital2 = porcentajecapital.split(' ');
                    //porcentajecapital = porcentajecapital2[0];

                    //porcentajeintereses = document.getElementById('InteresesPorcentaje').innerHTML;
                    //porcentajeintereses = (porcentajeintereses == null || porcentajeintereses == undefined || porcentajeintereses == "") ? 0 : porcentajeintereses;
                    //var porcentajeinterese2 = porcentajeintereses.split(' ');
                    //porcentajeintereses = porcentajeintereses2[0];

                    //porcentajemora = document.getElementById('MoraPorcentaje').innerHTML;
                    //porcentajemora = (porcentajemora == null || porcentajemora == undefined || porcentajemora == "") ? 0 : porcentajemora;
                    //var porcentajemora2 = porcentajemora.split(' ');
                    //porcentajemora = porcentajemora2[0];

                    //porcentajegastos = document.getElementById('GastosPorcentaje').innerHTML;
                    //porcentajegastos = (porcentajegastos == null || porcentajegastos == undefined || porcentajegastos == "") ? 0 : porcentajegastos;
                    //var porcentajegastos2 = porcentajegastos.split(' ');
                    //porcentajegastos = porcentajegastos2[0];

                    //porcentajecobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
                    //porcentajecobranza = (porcentajecobranza == null || porcentajecobranza == undefined || porcentajecobranza == "") ? 0 : porcentajecobranza;
                    //var porcentajecobranza2 = porcentajecobranza.split(' ');
                    //porcentajecobranza = porcentajecobranza2[0];

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(honorarios) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(honorarios)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));
                    //sumadeporcentajes = (parseFloat(porcentajecapital) + parseFloat(porcentajeintereses) + parseFloat(porcentajemora) + parseFloat(porcentajegastos) + parseFloat(porcentajecobranza));
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;
                    //alert(totaldinero + total);
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('HonorariosPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('HonorariosPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                    //document.getElementById('subtotalPorcentaje').innerHTML = sumadeporcentajes.toFixed(2) + ' %';
                }



            }

            function honorariossaldo2(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalSaldo').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalSaldo').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    
                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora));

                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalSaldo').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora));

                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero);
                }



            }

            function costassaldo(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var totalsaldoapagar = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var porcentaje = 0;
                var totalporcentaje = 0;
                var porcentajecapital = 0;
                var porcentajeintereses = 0;
                var porcentajemora = 0;
                var porcentajegastos = 0;
                var porcentajecobranza = 0;
                var sumadeporcentajes = 0;
                var costas = 0;
                var honorarios = 0;
                var desistimiento = 0;
                var total = 0;


                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalSaldo').innerHTML;

                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CapitalDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }


                    //porcentajecapital = document.getElementById('CapitalPorcentaje').innerHTML;
                    //porcentajecapital = (porcentajecapital == null || porcentajecapital == undefined || porcentajecapital == "") ? 0 : porcentajecapital;
                    //var porcentajecapital2 = porcentajecapital.split(' ');
                    //porcentajecapital = porcentajecapital2[0];

                    //porcentajeintereses = document.getElementById('InteresesPorcentaje').innerHTML;
                    //porcentajeintereses = (porcentajeintereses == null || porcentajeintereses == undefined || porcentajeintereses == "") ? 0 : porcentajeintereses;
                    //var porcentajeinterese2 = porcentajeintereses.split(' ');
                    //porcentajeintereses = porcentajeintereses2[0];

                    //porcentajemora = document.getElementById('MoraPorcentaje').innerHTML;
                    //porcentajemora = (porcentajemora == null || porcentajemora == undefined || porcentajemora == "") ? 0 : porcentajemora;
                    //var porcentajemora2 = porcentajemora.split(' ');
                    //porcentajemora = porcentajemora2[0];

                    //porcentajegastos = document.getElementById('GastosPorcentaje').innerHTML;
                    //porcentajegastos = (porcentajegastos == null || porcentajegastos == undefined || porcentajegastos == "") ? 0 : porcentajegastos;
                    //var porcentajegastos2 = porcentajegastos.split(' ');
                    //porcentajegastos = porcentajegastos2[0];

                    //porcentajecobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
                    //porcentajecobranza = (porcentajecobranza == null || porcentajecobranza == undefined || porcentajecobranza == "") ? 0 : porcentajecobranza;
                    //var porcentajecobranza2 = porcentajecobranza.split(' ');
                    //porcentajecobranza = porcentajecobranza2[0];

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(capital) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(capital)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));
                    //sumadeporcentajes = (parseFloat(porcentajecapital) + parseFloat(porcentajeintereses) + parseFloat(porcentajemora) + parseFloat(porcentajegastos) + parseFloat(porcentajecobranza));
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;

                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CapitalPago').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CapitalPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                    //document.getElementById('subtotalPorcentaje').innerHTML = sumadeporcentajes.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CostasDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }


                    //porcentajecapital = document.getElementById('CapitalPorcentaje').innerHTML;
                    //porcentajecapital = (porcentajecapital == null || porcentajecapital == undefined || porcentajecapital == "") ? 0 : porcentajecapital;
                    //var porcentajecapital2 = porcentajecapital.split(' ');
                    //porcentajecapital = porcentajecapital2[0];

                    //porcentajeintereses = document.getElementById('InteresesPorcentaje').innerHTML;
                    //porcentajeintereses = (porcentajeintereses == null || porcentajeintereses == undefined || porcentajeintereses == "") ? 0 : porcentajeintereses;
                    //var porcentajeinterese2 = porcentajeintereses.split(' ');
                    //porcentajeintereses = porcentajeintereses2[0];

                    //porcentajemora = document.getElementById('MoraPorcentaje').innerHTML;
                    //porcentajemora = (porcentajemora == null || porcentajemora == undefined || porcentajemora == "") ? 0 : porcentajemora;
                    //var porcentajemora2 = porcentajemora.split(' ');
                    //porcentajemora = porcentajemora2[0];

                    //porcentajegastos = document.getElementById('GastosPorcentaje').innerHTML;
                    //porcentajegastos = (porcentajegastos == null || porcentajegastos == undefined || porcentajegastos == "") ? 0 : porcentajegastos;
                    //var porcentajegastos2 = porcentajegastos.split(' ');
                    //porcentajegastos = porcentajegastos2[0];

                    //porcentajecobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
                    //porcentajecobranza = (porcentajecobranza == null || porcentajecobranza == undefined || porcentajecobranza == "") ? 0 : porcentajecobranza;
                    //var porcentajecobranza2 = porcentajecobranza.split(' ');
                    //porcentajecobranza = porcentajecobranza2[0];

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(costas) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(costas)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));
                    //sumadeporcentajes = (parseFloat(porcentajecapital) + parseFloat(porcentajeintereses) + parseFloat(porcentajemora) + parseFloat(porcentajegastos) + parseFloat(porcentajecobranza));
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;
                    //alert(totaldinero + total);
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CostasPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CostasPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                    //document.getElementById('subtotalPorcentaje').innerHTML = sumadeporcentajes.toFixed(2) + ' %';
                }



            }

            function costassaldo2(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalSaldo').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalSaldo').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalSaldo').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero);
                }



            }

            function desistimientosaldo(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var totalsaldoapagar = 0;
                var incendio = 0;
                var comisiones = 0;
                var descuento = 0;
                var porcentaje = 0;
                var totalporcentaje = 0;
                var porcentajecapital = 0;
                var porcentajeintereses = 0;
                var porcentajemora = 0;
                var porcentajegastos = 0;
                var porcentajecobranza = 0;
                var sumadeporcentajes = 0;
                var costas = 0;
                var honorarios = 0;
                var desistimiento = 0;
                var total = 0;


                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalSaldo').innerHTML;

                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CapitalDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }


                    //porcentajecapital = document.getElementById('CapitalPorcentaje').innerHTML;
                    //porcentajecapital = (porcentajecapital == null || porcentajecapital == undefined || porcentajecapital == "") ? 0 : porcentajecapital;
                    //var porcentajecapital2 = porcentajecapital.split(' ');
                    //porcentajecapital = porcentajecapital2[0];

                    //porcentajeintereses = document.getElementById('InteresesPorcentaje').innerHTML;
                    //porcentajeintereses = (porcentajeintereses == null || porcentajeintereses == undefined || porcentajeintereses == "") ? 0 : porcentajeintereses;
                    //var porcentajeinterese2 = porcentajeintereses.split(' ');
                    //porcentajeintereses = porcentajeintereses2[0];

                    //porcentajemora = document.getElementById('MoraPorcentaje').innerHTML;
                    //porcentajemora = (porcentajemora == null || porcentajemora == undefined || porcentajemora == "") ? 0 : porcentajemora;
                    //var porcentajemora2 = porcentajemora.split(' ');
                    //porcentajemora = porcentajemora2[0];

                    //porcentajegastos = document.getElementById('GastosPorcentaje').innerHTML;
                    //porcentajegastos = (porcentajegastos == null || porcentajegastos == undefined || porcentajegastos == "") ? 0 : porcentajegastos;
                    //var porcentajegastos2 = porcentajegastos.split(' ');
                    //porcentajegastos = porcentajegastos2[0];

                    //porcentajecobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
                    //porcentajecobranza = (porcentajecobranza == null || porcentajecobranza == undefined || porcentajecobranza == "") ? 0 : porcentajecobranza;
                    //var porcentajecobranza2 = porcentajecobranza.split(' ');
                    //porcentajecobranza = porcentajecobranza2[0];

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(capital) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(capital)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));
                    //sumadeporcentajes = (parseFloat(porcentajecapital) + parseFloat(porcentajeintereses) + parseFloat(porcentajemora) + parseFloat(porcentajegastos) + parseFloat(porcentajecobranza));
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;

                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CapitalPago').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CapitalPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                    //document.getElementById('subtotalPorcentaje').innerHTML = sumadeporcentajes.toFixed(2) + ' %';
                }
                else {

                    capital = document.getElementById('CapitalSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosSaldo').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaSaldo').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('DesistimientoDescuento').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    honorarios = document.getElementById('HonorariosSaldo').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasSaldo').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoSaldo').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }


                    //porcentajecapital = document.getElementById('CapitalPorcentaje').innerHTML;
                    //porcentajecapital = (porcentajecapital == null || porcentajecapital == undefined || porcentajecapital == "") ? 0 : porcentajecapital;
                    //var porcentajecapital2 = porcentajecapital.split(' ');
                    //porcentajecapital = porcentajecapital2[0];

                    //porcentajeintereses = document.getElementById('InteresesPorcentaje').innerHTML;
                    //porcentajeintereses = (porcentajeintereses == null || porcentajeintereses == undefined || porcentajeintereses == "") ? 0 : porcentajeintereses;
                    //var porcentajeinterese2 = porcentajeintereses.split(' ');
                    //porcentajeintereses = porcentajeintereses2[0];

                    //porcentajemora = document.getElementById('MoraPorcentaje').innerHTML;
                    //porcentajemora = (porcentajemora == null || porcentajemora == undefined || porcentajemora == "") ? 0 : porcentajemora;
                    //var porcentajemora2 = porcentajemora.split(' ');
                    //porcentajemora = porcentajemora2[0];

                    //porcentajegastos = document.getElementById('GastosPorcentaje').innerHTML;
                    //porcentajegastos = (porcentajegastos == null || porcentajegastos == undefined || porcentajegastos == "") ? 0 : porcentajegastos;
                    //var porcentajegastos2 = porcentajegastos.split(' ');
                    //porcentajegastos = porcentajegastos2[0];

                    //porcentajecobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
                    //porcentajecobranza = (porcentajecobranza == null || porcentajecobranza == undefined || porcentajecobranza == "") ? 0 : porcentajecobranza;
                    //var porcentajecobranza2 = porcentajecobranza.split(' ');
                    //porcentajecobranza = porcentajecobranza2[0];

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(desistimiento) - parseFloat(descuento));
                    totalporcentaje = ((parseFloat(descuento) / parseFloat(desistimiento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));
                    //sumadeporcentajes = (parseFloat(porcentajecapital) + parseFloat(porcentajeintereses) + parseFloat(porcentajemora) + parseFloat(porcentajegastos) + parseFloat(porcentajecobranza));
                    //document.getElementById('inSubtotalSaldo').value = totaldinero;
                    //alert(totaldinero + total);
                    document.getElementById('subtotalSaldo').innerHTML = formatter.format(totaldinero);
                    document.getElementById('DesistimientoPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('DesistimientoPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero + total);
                    //document.getElementById('subtotalPorcentaje').innerHTML = sumadeporcentajes.toFixed(2) + ' %';
                }



            }

            function desistimientosaldo2(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalSaldo').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalSaldo').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosSaldo').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasSaldo').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoSaldo').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalSaldo').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalSaldo').innerHTML = formatter.format(totaldinero);
                }



            }
        </script>


        <script>
            function honorariosdescuento(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var totalsaldoapagar = 0;
                var descuento = 0;
                var porcentaje = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('HonorariosSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    porcentaje = document.getElementById('CapitalSaldo').value;
                    porcentaje = (porcentaje == null || porcentaje == undefined || porcentaje == "") ? 0 : porcentaje;
                    if (porcentaje != 0) {
                        var porcentajesaldo = porcentaje.split(',');

                        var porcentajefinal = "";

                        for (var i = 0; i < porcentajesaldo.length; i++) {
                            porcentajefinal = porcentajefinal + porcentajesaldo[i];
                        }
                        porcentaje = porcentajefinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(honorarios));
                    totalporcentaje = ((parseFloat(honorarios) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('HonorariosPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('HonorariosPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);

                }
                else {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('HonorariosSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    porcentaje = document.getElementById('CapitalSaldo').value;
                    porcentaje = (porcentaje == null || porcentaje == undefined || porcentaje == "") ? 0 : porcentaje;
                    if (porcentaje != 0) {
                        var porcentajesaldo = porcentaje.split(',');

                        var porcentajefinal = "";

                        for (var i = 0; i < porcentajesaldo.length; i++) {
                            porcentajefinal = porcentajefinal + porcentajesaldo[i];
                        }
                        porcentaje = porcentajefinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(honorarios));
                    totalporcentaje = ((parseFloat(honorarios) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('HonorariosPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('HonorariosPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);
                }



            }

            function honorariosdescuento2(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalDescuento').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalDescuento').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero);
                }



            }

            function costasdescuento(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var totalsaldoapagar = 0;
                var descuento = 0;
                var porcentaje = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CostasSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    porcentaje = document.getElementById('CapitalSaldo').value;
                    porcentaje = (porcentaje == null || porcentaje == undefined || porcentaje == "") ? 0 : porcentaje;
                    if (porcentaje != 0) {
                        var porcentajesaldo = porcentaje.split(',');

                        var porcentajefinal = "";

                        for (var i = 0; i < porcentajesaldo.length; i++) {
                            porcentajefinal = porcentajefinal + porcentajesaldo[i];
                        }
                        porcentaje = porcentajefinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(capital));
                    totalporcentaje = ((parseFloat(costas) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));
                    
                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CapitalPago').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CostasPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);

                }
                else {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('CostasSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    porcentaje = document.getElementById('CapitalSaldo').value;
                    porcentaje = (porcentaje == null || porcentaje == undefined || porcentaje == "") ? 0 : porcentaje;
                    if (porcentaje != 0) {
                        var porcentajesaldo = porcentaje.split(',');

                        var porcentajefinal = "";

                        for (var i = 0; i < porcentajesaldo.length; i++) {
                            porcentajefinal = porcentajefinal + porcentajesaldo[i];
                        }
                        porcentaje = porcentajefinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(costas));
                    totalporcentaje = ((parseFloat(costas) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));
                    
                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CostasPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('CostasPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);
                }



            }

            function costasdescuento2(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalDescuento').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalDescuento').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero);
                }



            }

            function desistimientodescuento(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;
                var totalsaldoapagar = 0;
                var descuento = 0;
                var porcentaje = 0;
                var totalporcentaje = 0;
                var honorarios = 0;
                var costas = 0;
                var desistimiento = 0;
                var total = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('subtotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('DesistimientoSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    porcentaje = document.getElementById('CapitalSaldo').value;
                    porcentaje = (porcentaje == null || porcentaje == undefined || porcentaje == "") ? 0 : porcentaje;
                    if (porcentaje != 0) {
                        var porcentajesaldo = porcentaje.split(',');

                        var porcentajefinal = "";

                        for (var i = 0; i < porcentajesaldo.length; i++) {
                            porcentajefinal = porcentajefinal + porcentajesaldo[i];
                        }
                        porcentaje = porcentajefinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(capital));
                    totalporcentaje = ((parseFloat(desistimiento) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('CapitalPago').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('DesistimientoPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);

                }
                else {

                    capital = document.getElementById('CapitalDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('InteresesDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('MoraDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('GastosDescuento').value;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    cobranza = document.getElementById('CobranzaDescuento').value;
                    cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
                    if (cobranza != 0) {
                        var cobranzasaldo = cobranza.split(',');

                        var cobranzafinal = "";

                        for (var i = 0; i < cobranzasaldo.length; i++) {
                            cobranzafinal = cobranzafinal + cobranzasaldo[i];
                        }
                        cobranza = cobranzafinal;
                    }

                    descuento = document.getElementById('DesistimientoSaldo').value;
                    descuento = (descuento == null || descuento == undefined || descuento == "") ? 0 : descuento;
                    if (descuento != 0) {
                        var descuentocapital = descuento.split(',');

                        var descuentofinal = "";

                        for (var i = 0; i < descuentocapital.length; i++) {
                            descuentofinal = descuentofinal + descuentocapital[i];
                        }
                        descuento = descuentofinal;
                    }

                    porcentaje = document.getElementById('CapitalSaldo').value;
                    porcentaje = (porcentaje == null || porcentaje == undefined || porcentaje == "") ? 0 : porcentaje;
                    if (porcentaje != 0) {
                        var porcentajesaldo = porcentaje.split(',');

                        var porcentajefinal = "";

                        for (var i = 0; i < porcentajesaldo.length; i++) {
                            porcentajefinal = porcentajefinal + porcentajesaldo[i];
                        }
                        porcentaje = porcentajefinal;
                    }

                    honorarios = document.getElementById('HonorariosDescuento').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var honorariosabo = honorarios.split(',');

                        var honorariosfinal = "";

                        for (var i = 0; i < honorariosabo.length; i++) {
                            honorariosfinal = honorariosfinal + honorariosabo[i];
                        }
                        honorarios = honorariosfinal;
                    }

                    costas = document.getElementById('CostasDescuento').value;
                    costas = (costas == null || costas == undefined || costas == "") ? 0 : costas;
                    if (costas != 0) {
                        var costaspagar = costas.split(',');

                        var costasfinal = "";

                        for (var i = 0; i < costaspagar.length; i++) {
                            costasfinal = costasfinal + costaspagar[i];
                        }
                        costas = costasfinal;
                    }


                    desistimiento = document.getElementById('DesistimientoDescuento').value;
                    desistimiento = (desistimiento == null || desistimiento == undefined || desistimiento == "") ? 0 : desistimiento;
                    if (desistimiento != 0) {
                        var desistimientopagar = desistimiento.split(',');

                        var desistimientofinal = "";

                        for (var i = 0; i < desistimientopagar.length; i++) {
                            desistimientofinal = desistimientofinal + desistimientopagar[i];
                        }
                        desistimiento = desistimientofinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
                    totalsaldoapagar = (parseFloat(descuento) - parseFloat(desistimiento));
                    totalporcentaje = ((parseFloat(desistimiento) / parseFloat(descuento)) * 100);
                    total = (parseFloat(honorarios) + parseFloat(costas) + parseFloat(desistimiento));

                    document.getElementById('subtotalDescuento').innerHTML = formatter.format(totaldinero);
                    document.getElementById('DesistimientoPagar').innerHTML = formatter.format(totalsaldoapagar);
                    document.getElementById('DesistimientoPorcentaje').innerHTML = totalporcentaje.toFixed(2) + ' %';
                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero + total);
                }



            }

            function desistimientodescuento2(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalDescuento').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalDescuento').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosDescuento').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasDescuento').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoDescuento').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalDescuento').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalDescuento').innerHTML = formatter.format(totaldinero);
                }



            }
        </script>


        <script>
            //function capitalporcentaje() {
            //    var cantidad = 0;
            //    var capital = 0;
            //    var intereses = 0;
            //    var mora = 0;
            //    var gastos = 0;
            //    var Interes1 = 0;
            //    var Saldo1 = 0;
            //    var totaldinero = 0;
            //    var incendio = 0;
            //    var comisiones = 0;
            //    alert('funciones');
            //    //alert(new Intl.NumberFormat("de-DE").format(numero));
            //    var formatter = new Intl.NumberFormat('es-GT', {
            //        style: 'currency',
            //        currency: 'GTQ',
            //    });
            //    //document.getElementById('Total1').innerHTML = "Funciona";
            //    //alert(formatter.format(numero));


            //    cantidad = document.getElementById('subtotalPorcentaje').innerHTML;
            //    if (cantidad == null || cantidad == undefined || cantidad == "") {

            //        capital = document.getElementById('CapitalPorcentaje').innerHTML;
            //        capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
            //        if (capital != 0) {
            //            var capitalvencido = capital.split(',');

            //            var capitalfinal = "";

            //            for (var i = 0; i < capitalvencido.length; i++) {
            //                capitalfinal = capitalfinal + capitalvencido[i];
            //            }
            //            capital = capitalfinal;
            //        }

            //        intereses = document.getElementById('InteresesPorcentaje').innerHTML;
            //        intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
            //        if (intereses != 0) {
            //            var interesesvencidos = intereses.split(',');

            //            var interesesfinal = "";

            //            for (var i = 0; i < interesesvencidos.length; i++) {
            //                interesesfinal = interesesfinal + interesesvencidos[i];
            //            }
            //            intereses = interesesfinal;
            //        }

            //        mora = document.getElementById('MoraPorcentaje').innerHTML;
            //        mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
            //        if (mora != 0) {
            //            var morasaldo = mora.split(',');

            //            var morafinal = "";

            //            for (var i = 0; i < morasaldo.length; i++) {
            //                morafinal = morafinal + morasaldo[i];
            //            }
            //            mora = morafinal;
            //        }

            //        gastos = document.getElementById('GastosPorcentaje').innerHTML;
            //        gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
            //        if (gastos != 0) {
            //            var gastossaldo = gastos.split(',');

            //            var gastosfinal = "";

            //            for (var i = 0; i < gastossaldo.length; i++) {
            //                gastosfinal = gastosfinal + gastossaldo[i];
            //            }
            //            gastos = gastosfinal;
            //        }

            //        cobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
            //        cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
            //        if (cobranza != 0) {
            //            var cobranzasaldo = cobranza.split(',');

            //            var cobranzafinal = "";

            //            for (var i = 0; i < cobranzasaldo.length; i++) {
            //                cobranzafinal = cobranzafinal + cobranzasaldo[i];
            //            }
            //            cobranza = cobranzafinal;
            //        }



            //        totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
            //        alert(capital);
            //        document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
            //    }
            //    else {

            //        capital = document.getElementById('CapitalPorcentaje').innerHTML;
            //        capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
            //        if (capital != 0) {
            //            var capitalvencido = capital.split(',');

            //            var capitalfinal = "";

            //            for (var i = 0; i < capitalvencido.length; i++) {
            //                capitalfinal = capitalfinal + capitalvencido[i];
            //            }
            //            capital = capitalfinal;
            //        }

            //        intereses = document.getElementById('InteresesPorcentaje').innerHTML;
            //        intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
            //        if (intereses != 0) {
            //            var interesesvencidos = intereses.split(',');

            //            var interesesfinal = "";

            //            for (var i = 0; i < interesesvencidos.length; i++) {
            //                interesesfinal = interesesfinal + interesesvencidos[i];
            //            }
            //            intereses = interesesfinal;
            //        }

            //        mora = document.getElementById('MoraPorcentaje').innerHTML;
            //        mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
            //        if (mora != 0) {
            //            var morasaldo = mora.split(',');

            //            var morafinal = "";

            //            for (var i = 0; i < morasaldo.length; i++) {
            //                morafinal = morafinal + morasaldo[i];
            //            }
            //            mora = morafinal;
            //        }

            //        gastos = document.getElementById('GastosPorcentaje').innerHTML;
            //        gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
            //        if (gastos != 0) {
            //            var gastossaldo = gastos.split(',');

            //            var gastosfinal = "";

            //            for (var i = 0; i < gastossaldo.length; i++) {
            //                gastosfinal = gastosfinal + gastossaldo[i];
            //            }
            //            gastos = gastosfinal;
            //        }

            //        cobranza = document.getElementById('CobranzaPorcentaje').innerHTML;
            //        cobranza = (cobranza == null || cobranza == undefined || cobranza == "") ? 0 : cobranza;
            //        if (cobranza != 0) {
            //            var cobranzasaldo = cobranza.split(',');

            //            var cobranzafinal = "";

            //            for (var i = 0; i < cobranzasaldo.length; i++) {
            //                cobranzafinal = cobranzafinal + cobranzasaldo[i];
            //            }
            //            cobranza = cobranzafinal;
            //        }

            //        totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos) + parseFloat(cobranza));
            //        alert(capital);
            //        document.getElementById('subtotalPorcentaje').innerHTML = formatter.format(totaldinero);
            //    }



            //}

            function honorariosporcentaje(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalPorcentaje').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPorcentaje').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPorcentaje').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }



            }

            function costasporcentaje(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalPorcentaje').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPorcentaje').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPorcentaje').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }



            }

            function diligenciamientoporcentaje(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalPorcentaje').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPorcentaje').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosPorcentaje').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPorcentaje').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPorcentaje').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPorcentaje').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPorcentaje').innerHTML = formatter.format(totaldinero);
                }



            }
        </script>

        <script>
            function honorariospagar(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalPagar').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosPagar').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPagar').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPagar').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosPagar').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPagar').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPagar').innerHTML = formatter.format(totaldinero);
                }
            }

            function costaspagar(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalPagar').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosPagar').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPagar').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPagar').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosPagar').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPagar').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPagar').innerHTML = formatter.format(totaldinero);
                }
            }

            function diligenciamientopagar(numero) {
                var cantidad = 0;
                var capital = 0;
                var intereses = 0;
                var mora = 0;
                var gastos = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;
                var incendio = 0;
                var comisiones = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('TotalPagar').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    capital = document.getElementById('HonorariosPagar').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPagar').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }


                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPagar').innerHTML = formatter.format(totaldinero);
                }
                else {

                    capital = document.getElementById('HonorariosPagar').value;
                    capital = (capital == null || capital == undefined || capital == "") ? 0 : capital;
                    if (capital != 0) {
                        var capitalvencido = capital.split(',');

                        var capitalfinal = "";

                        for (var i = 0; i < capitalvencido.length; i++) {
                            capitalfinal = capitalfinal + capitalvencido[i];
                        }
                        capital = capitalfinal;
                    }

                    intereses = document.getElementById('CostasPagar').value;
                    intereses = (intereses == null || intereses == undefined || intereses == "") ? 0 : intereses;
                    if (intereses != 0) {
                        var interesesvencidos = intereses.split(',');

                        var interesesfinal = "";

                        for (var i = 0; i < interesesvencidos.length; i++) {
                            interesesfinal = interesesfinal + interesesvencidos[i];
                        }
                        intereses = interesesfinal;
                    }

                    mora = document.getElementById('DesistimientoPagar').value;
                    mora = (mora == null || mora == undefined || mora == "") ? 0 : mora;
                    if (mora != 0) {
                        var morasaldo = mora.split(',');

                        var morafinal = "";

                        for (var i = 0; i < morasaldo.length; i++) {
                            morafinal = morafinal + morasaldo[i];
                        }
                        mora = morafinal;
                    }

                    gastos = document.getElementById('subtotalPagar').innerText;
                    gastos = (gastos == null || gastos == undefined || gastos == "") ? 0 : gastos;
                    if (gastos != 0) {
                        var gastossaldo = gastos.split(',');

                        var gastosfinal = "";

                        for (var i = 0; i < gastossaldo.length; i++) {
                            gastosfinal = gastosfinal + gastossaldo[i];
                        }
                        gastos = gastosfinal;
                    }

                    totaldinero = (parseFloat(capital) + parseFloat(intereses) + parseFloat(mora) + parseFloat(gastos));

                    document.getElementById('TotalPagar').innerHTML = formatter.format(totaldinero);
                }
            }
        </script>

        <script>
            $('#subtotalSaldo').text();
            document.getElementById('inSubtotalSaldo').value = $('#subtotalSaldo span').text();
            $('#subtotalDescuento span').text();
            document.getElementById('inSubtotalDescuento').value = $('#subtotalDescuento span').text();
            $('#subtotalPorcentaje span').text();
            document.getElementById('inSubtotalPorcentaje').value = $('#subtotalPorcentaje span').text();
            $('#subtotalPagar span').text();
            document.getElementById('inSubtotalPagar').value = $('#subtotalPagar span').text();
        </script>

    </form>
</body>
</html>
