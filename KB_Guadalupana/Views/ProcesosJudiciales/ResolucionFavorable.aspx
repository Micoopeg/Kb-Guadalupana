<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResolucionFavorable.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.ResolucionFavorable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Resolución Favorable</title>
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
                        <label style="font-size:18px" class="titulos">Gestión para entrega de fondos</label>
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
                   <%--  <div class="formato3">
                        <label class="titulos"><b>¿Resolución favorable?</b></label>
                        <asp:DropDownList id="Resolucion" runat="server" Width="100%" class="formatoinput2" AutoPostBack="true" OnSelectedIndexChanged="ResolucionFavorable_SelectedIndexChanged"></asp:DropDownList>
                    </div><br /><br />--%>

                    <div id="EntregaFondos" runat="server">
                        <label class="titulos"><b>Oficio para entrega de fondos</b></label><br />
                        <div class="formato">
                            <asp:DropDownList id="PTipoDocumento" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                            <asp:FileUpload id="FileUpload1" runat="server"></asp:FileUpload>
                            <asp:Button ID="Agregar" OnClick="agregar_Click" runat="server" Width="20%" Height="30px" CssClass="boton3" Text="Agregar" />
                        </div><br /><br />

                          <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 150px">
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
                                <asp:ButtonField   Text="Ver Documento" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="White">
                                    <ItemStyle Width="135px" ForeColor="White"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div><br /><br /><br />

                         <label class="titulos"><b>Solicitud de recibo de caja</b></label><br />
                        <div class="formato">
                            <asp:DropDownList id="ReciboCaja" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                            <asp:FileUpload id="FileUpload2" runat="server"></asp:FileUpload>
                            <asp:Button ID="Agregar2" OnClick="agregar2_Click" runat="server" Width="20%" Height="30px" CssClass="boton3" Text="Agregar" />
                        </div><br /><br />

                        <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 150px">
                        <asp:GridView ID="gridViewSolicitud" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedSolicitud" BorderStyle="Solid">
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

                    </div>

                </div>
                <br />

                <div class="encabezado">
                       <div id="aplicacionPago" runat="server">

                          <label style="font-size:15px" class="titulos"><b>Aplicación de Pago</b></label><br /><br />

                          <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>No. de cheque</b></label>
                            <label class="titulos" style="margin-left:22%"><b>Fecha de emisión de cheque</b></label>
                            <label class="titulos" style="margin-left:8%"><b>No. de recibo</b></label>
                        </div>
                        <div class="formato">
                            <input type="text" id="NumCheque" runat="server" class="formatoinput3" placeholder="Ingrese no. cheque" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <input id="FechaEmision" runat="server" type="date" class="formatoinput3"/>
                            <input type="text" id="NumRecibo" runat="server" class="formatoinput3" placeholder="Ingrese no. recibo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                    <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>Monto</b></label>
                            <label class="titulos" style="margin-left:48%"><b>Banco</b></label>
                        </div>

                        <div class="formato">
                             Q<input type="text" id="Monto" runat="server" class="formatoinput" onkeyup="format(this)" onchange="format(this);" placeholder="Ingrese monto" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                            <asp:DropDownList id="Banco" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>
                        </div><br />
                    </div>
                </div><br />

                <div class="encabezado">
                    <div id="SolicitudFacturacion" runat="server">
                          <label style="font-size:15px" class="titulos"><b>Solicitud Facturación</b></label><br />

                  <%--<div id="IntegracionC" runat="server" style="display:flex; justify-content:center" class="encabezado">

                    <div style="display:flex; justify-content:center">
                        <label style="font-size:15px" class="titulos">Integración de cuenta</label>
                    </div><br /><br />

                    <div style="display:flex; justify-content:center">
                         <div id="credito" style="display:flex; justify-content:flex-start; align-content:flex-start; flex-direction:column; align-items:flex-start;width:75%" runat="server">
                        
                             <div class="formato4" style="display:flex; justify-content:flex-start">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-start; width:130px"><b>Saldo capital:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Saldo1" style="width:32%;text-align:end" runat="server" type="text" min="0" class="formatoinput" placeholder="Saldo" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readonly="readonly"/>
                        </div><br />

                        <div class="formato4" style="display:flex; justify-content:flex-start">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-start; width:130px"><b>Intereses vencidos:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Interes1" style="width:32%;text-align:end" runat="server" type="text" min="0" class="formatoinput" placeholder="Intereses" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readonly="readonly"/>
                        </div><br />

                         <div class="formato4" style="display:flex; justify-content:flex-start">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-start; width:130px"><b>Mora:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                              <input id="Mora" style="width:32%;text-align:end" runat="server" type="text" min="0" class="formatoinput" placeholder="Mora" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                         <div class="formato4" style="display:flex; justify-content:flex-start">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-start; width:130px"><b>Gastos cobranza:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Gastos1" style="width:32%;text-align:end" onkeyup="format(this)" onchange="format(this), gastos1(this.value);" runat="server" type="text" min="0" class="formatoinput" value="0" maxlength="12" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                         <div class="formato4" style="display:flex; justify-content:flex-start">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-start; width:130px"><b>Gastos judiciales:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="GastosJudiciales" style="width:32%;text-align:end" runat="server" onkeyup="format(this)" onchange="format(this), gastosJudiciales(this.value);" type="text" min="0" class="formatoinput" value="0" maxlength="12" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div class="formato4" style="display:flex; justify-content:flex-start">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-start; width:130px"><b>Otros gastos:</b></label>
                             <label class="titulos" style="width:3%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="OtrosGastos" style="width:22%;text-align:end" runat="server" onkeyup="format(this)" onchange="format(this), otrosGastos(this.value);" type="text" min="0" class="formatoinput" value="0" maxlength="12" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                             <input id="Comentario" style="width:41%; margin-left:4%;" runat="server" type="text" class="formatoinput" placeholder="Comentario" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                          
                        </div><br />

                         <div class="formato4" style="display:flex; justify-content:flex-start;width:100%">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-start; width:130px"><b>Total:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b> </b></label>
                            <span id="Total1" style="width:30%" runat="server" class="formatoinput"></span>
                        </div>
                             <br /><br />
                               <%-- <div class="formato3">
                                <span class="titulos"><b>Observaciones del crédito</b></span>
                                <input id="Observaciones" runat="server" type="text" class="formatoinput2" placeholder="Ingrese Observaciones" maxlength="150" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" required/>
                            </div>--%>

                   <%-- </div>
                    </div>

                    <br /><br />
                  
                 </div>--%>

                        <div class="formato">
                              <label class="titulos"><b>Pago de honorarios</b></label>
                              <input type="text" id="Honorarios" runat="server" class="formatoinput" onkeyup="format(this)" onchange="format(this), gastos1(this.value);" placeholder="Ingrese pago de honorarios" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div>

                        <%--<div class="formato">
                              <label class="titulos"><b>Pago de transacción</b></label>
                              <input type="text" id="Transaccion" runat="server" class="formatoinput" onkeyup="format(this)" onchange="format(this), transaccion(this.value);" placeholder="Ingrese pago de transacción" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div class="formato">
                              <label class="titulos"><b>Total</b></label>
                              <span id="Total" runat="server"></span>
                        </div><br /><br />--%>

                         <div class="formato3">
                            <label class="titulos"><b>Observaciones</b></label>
                            <input id="Comentario" runat="server" type="text" class="formatoinput2" placeholder="Ingrese observaciones" maxlength="150" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                    </div>
                </div><br />

                <div class="formato2">
                    <asp:Button ID="Guardar" runat="server" CssClass="boton" Text="Guardar" OnClick="Guardar_Click"/>
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
            function gastos1(numero) {
                var cantidad = 0;
                var honorarios = 0;
                var Transaccion = 0;
                var Gastos1 = 0;
                var Mora = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('Total').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    honorarios = document.getElementById('Honorarios').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var otrosgastos = honorarios.split(',');

                        var otrosgastosfinal = "";

                        for (var i = 0; i < otrosgastos.length; i++) {
                            otrosgastosfinal = otrosgastosfinal + otrosgastos[i];
                        }
                        honorarios = otrosgastosfinal;
                    }

                    Transaccion = document.getElementById('Transaccion').value;
                    Transaccion = (Transaccion == null || Transaccion == undefined || Transaccion == "") ? 0 : Transaccion;
                    if (Transaccion != 0) {
                        var gastosc = Transaccion.split(',');

                        var gastofinal = "";

                        for (var i = 0; i < gastosc.length; i++) {
                            gastofinal = gastofinal + gastosc[i];
                        }
                        Transaccion = gastofinal;
                    }
                    

                    totaldinero = (parseFloat(honorarios) + parseFloat(Transaccion));

                    //alert(totaldinero);
                    document.getElementById('Total').innerHTML = formatter.format(totaldinero);
                }
                else {

                    honorarios = document.getElementById('Honorarios').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var otrosgastos = honorarios.split(',');

                        var otrosgastosfinal = "";

                        for (var i = 0; i < otrosgastos.length; i++) {
                            otrosgastosfinal = otrosgastosfinal + otrosgastos[i];
                        }
                        honorarios = otrosgastosfinal;
                    }

                    Transaccion = document.getElementById('Transaccion').value;
                    Transaccion = (Transaccion == null || Transaccion == undefined || Transaccion == "") ? 0 : Transaccion;
                    if (Transaccion != 0) {
                        var gastosc = Transaccion.split(',');

                        var gastofinal = "";

                        for (var i = 0; i < gastosc.length; i++) {
                            gastofinal = gastofinal + gastosc[i];
                        }
                        Transaccion = gastofinal;
                    }


                    totaldinero = (parseFloat(honorarios) + parseFloat(Transaccion));

                    //alert(formatter.format(Interes1));
                    document.getElementById('Total').innerHTML = formatter.format(totaldinero);
                }



            }

            function transaccion(numero) {
                var cantidad = 0;
                var honorarios = 0;
                var Transaccion = 0;
                var Gastos1 = 0;
                var Mora = 0;
                var Interes1 = 0;
                var Saldo1 = 0;
                var totaldinero = 0;

                //alert(new Intl.NumberFormat("de-DE").format(numero));
                var formatter = new Intl.NumberFormat('es-GT', {
                    style: 'currency',
                    currency: 'GTQ',
                });
                //document.getElementById('Total1').innerHTML = "Funciona";
                //alert(formatter.format(numero));


                cantidad = document.getElementById('Total').innerHTML;
                if (cantidad == null || cantidad == undefined || cantidad == "") {

                    honorarios = document.getElementById('Honorarios').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var otrosgastos = honorarios.split(',');

                        var otrosgastosfinal = "";

                        for (var i = 0; i < otrosgastos.length; i++) {
                            otrosgastosfinal = otrosgastosfinal + otrosgastos[i];
                        }
                        honorarios = otrosgastosfinal;
                    }

                    Transaccion = document.getElementById('Transaccion').value;
                    Transaccion = (Transaccion == null || Transaccion == undefined || Transaccion == "") ? 0 : Transaccion;
                    if (Transaccion != 0) {
                        var gastosc = Transaccion.split(',');

                        var gastofinal = "";

                        for (var i = 0; i < gastosc.length; i++) {
                            gastofinal = gastofinal + gastosc[i];
                        }
                        Transaccion = gastofinal;
                    }


                    totaldinero = (parseFloat(honorarios) + parseFloat(Transaccion));

                    //alert(formatter.format(Interes1));
                    document.getElementById('Total').innerHTML = formatter.format(totaldinero);
                }
                else {

                    honorarios = document.getElementById('Honorarios').value;
                    honorarios = (honorarios == null || honorarios == undefined || honorarios == "") ? 0 : honorarios;
                    if (honorarios != 0) {
                        var otrosgastos = honorarios.split(',');

                        var otrosgastosfinal = "";

                        for (var i = 0; i < otrosgastos.length; i++) {
                            otrosgastosfinal = otrosgastosfinal + otrosgastos[i];
                        }
                        honorarios = otrosgastosfinal;
                    }

                    Transaccion = document.getElementById('Transaccion').value;
                    Transaccion = (Transaccion == null || Transaccion == undefined || Transaccion == "") ? 0 : Transaccion;
                    if (Transaccion != 0) {
                        var gastosc = Transaccion.split(',');

                        var gastofinal = "";

                        for (var i = 0; i < gastosc.length; i++) {
                            gastofinal = gastofinal + gastosc[i];
                        }
                        Transaccion = gastofinal;
                    }


                    totaldinero = (parseFloat(honorarios) + parseFloat(Transaccion));

                    //alert(formatter.format(Interes1));
                    document.getElementById('Total').innerHTML = formatter.format(totaldinero);
                }



            }
        </script>
    </form>
</body>
</html>
