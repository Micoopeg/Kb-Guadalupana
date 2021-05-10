<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CertificacionJuridico.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.CertificacionJuridico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Certificación contable</title>
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

        .formatoinput5{
            width:90%;
            margin-top:8px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
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
                    <label style="font-size:18px" class="titulos">Emisión de Certificación Contable</label>
                 </div><br />
                 <div class="header"></div>


 <div id="Div1" runat="server" class="encabezado" style="border-color:#8DDB51; border:2px #4B752B solid">
     <label style="font-size:15px" class="titulos"><b>Información principal</b></label><br /><br />

                        <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>No. de préstamo</b></label>
                        <label class="titulos" style="margin-left:11%"><b>No. de incidente</b></label>
                        <label class="titulos" style="margin-left:11%"><b>DPI</b></label>
                        <label class="titulos" style="margin-left:22%"><b>Código cliente</b></label>
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


                <div id="formulario" runat="server" class="encabezado">
                     <label style="font-size:15px" class="titulos"><b>Información general</b></label><br /><br />

                        <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Nombre de agencia</b></label>
                            <label class="titulos" style="margin-left:35%"><b>Instrumento</b></label>
                        </div>
                        <div class="formato">
                              <input id="Agencia" runat="server" type="text" class="formatoinput" placeholder="Nombre de agencia" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                             <input id="Instrumento" runat="server" type="text" class="formatoinput" placeholder="Instrumento" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                     <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Línea de crédito</b></label>
                            <label class="titulos" style="margin-left:38%"><b>Destino</b></label>
                        </div>
                        <div class="formato">
                              <input type="text" id="LineaCredito" runat="server" class="formatoinput" placeholder="Línea de crédito" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                             <input id="destino" runat="server" type="text" class="formatoinput" placeholder="Destino" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                     <div class="formato3">
                        <label class="titulos"><b>Garantía</b></label>
                         <input id="Garantia" runat="server" type="text" class="formatoinput2" placeholder="Garantía" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Plazo en meses</b></label>
                        <%--<label class="titulos" style="margin-left:20%"><b>Método de cálculo</b></label>--%>
                        <label class="titulos" style="margin-left:40%"><b>Estado</b></label>
                    </div>

                    <div class="formato">
                        <input id="Plazomeses" runat="server" type="text" class="formatoinput" min="0" placeholder="Plazo en medes" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                     <%--   <input id="Metodocalculo" runat="server" type="text" class="formatoinput3" placeholder="Método cálculo" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>--%>
                         <input id="Estado" runat="server" type="text" class="formatoinput" placeholder="Estado" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                       <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Moneda</b></label>
                            <label class="titulos" style="margin-left:46%"><b>Tasa</b></label>
                        </div>
                         <div class="formato">
                              <input id="Moneda" runat="server" type="text" class="formatoinput" placeholder="Moneda" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                             <input id="Tasa" runat="server" type="text" class="formatoinput" min="0" placeholder="Tasa" maxlength="10" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                     <div class="formato3">
                        <label class="titulos"><b>Fecha solicitud</b></label>
                        <input id="FechaSolicitud" runat="server" type="text" class="formatoinput2" placeholder="Fecha solicitud" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Fecha 1er. desembolso</b></label>
                        <label class="titulos" style="margin-left:32%"><b>Fecha último desembolso</b></label>
                    </div>

                    <div class="formato">
                           <input id="FechaDesembolso1" runat="server" type="text" class="formatoinput" placeholder="Fecha 1er. desembolso" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="FechaUltimoDes" runat="server" type="text" class="formatoinput" placeholder="Fecha último desembolso" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                     <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Fecha de vencimiento</b></label>
                        <label class="titulos" style="margin-left:32%"><b>Fecha última cuota</b></label>
                    </div>

                    <div class="formato">
                           <input id="FechaVencimiento" runat="server" type="text" class="formatoinput" placeholder="Fecha de vencimiento" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="FechaUltimaCuota" runat="server" type="text" class="formatoinput" placeholder="Fecha última cuota" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                      <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Fecha de acta</b></label>
                        <label class="titulos" style="margin-left:40%"><b>Número de acta</b></label>
                    </div>

                    <div class="formato">
                           <input id="FechaActa" runat="server" type="text" class="formatoinput" placeholder="Fecha de acta" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="NumActa" runat="server" type="text" class="formatoinput" placeholder="Número de acta" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                      <div class="formato3">
                        <span id="Oficial1" runat="server" class="titulos"><b>Oficial 1 - Nombre</b></span>
                        <input id="NombreOficial" runat="server" type="text" class="formatoinput2" placeholder="Oficial - Nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                  <div class="formato3">
                        <span id="Oficial2" runat="server" class="titulos"><b>Oficial 2 - Nombre</b></span>
                        <input id="NombreOficial2" runat="server" type="text" class="formatoinput2" placeholder="Oficial - Nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                     <div class="formato3">
                        <span id="Oficial3" runat="server" class="titulos"><b>Oficial 3 - Nombre</b></span>
                        <input id="NombreOficial3" runat="server" type="text" class="formatoinput2" placeholder="Oficial - Nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formato3">
                        <label class="titulos"><b>Descripción Documento</b</label>
                        <input id="DescripcionDoc" runat="server" type="text" class="formatoinput2" placeholder="Fecha solicitud" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                </div><br />

                   <div class="menu2">
      <div class="formato3">
                           <label class="titulos"><b>No. de préstamo</b></label>
                          <input id="CreditoNumero" runat="server" type="text" class="formatoinput5" min="0" placeholder="No. prestamo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                     <div class="formato3">
                         <label class="titulos"><b>No. de incidente</b></label>
                        <input id="NumeroIncidente" runat="server" type="text" class="formatoinput5" min="0" placeholder="No. incidente" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formato3">
                        <label class="titulos"><b>Cliente - Nombre</b></label>
                        <textarea id="ClienteNombre" runat="server" type="text" class="formatoinput5" placeholder="Cliente - Nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"></textarea>
                    </div><br />
</div>

                <div class="encabezado">
                    <label class="titulos"><b>Documentos para conformación de expediente</b></label><br /><br />

                    <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 123px">
                        <asp:GridView ID="gridViewDocumentos" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedDocumento" BorderStyle="Solid">
                             <Columns>
                                <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No. documento">
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
                </div><br />

                <div class="encabezado">

                    <div style="display:flex; justify-content:center">
                        <label style="font-size:15px" class="titulos">Integración de cuenta</label>
                    </div><br /><br />

                     <div id ="tarjeta" runat="server">
                        <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>No. de tarjeta</b></label>
                            <label class="titulos" style="margin-left:40%"><b>No. de cuenta</b></label>
                        </div>

                        <div class="formato">
                               <input id="NumTarjeta" runat="server" type="number" class="formatoinput" placeholder="Ingrese no. de tarjeta" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                               <input id="NumCuenta" runat="server" type="number" class="formatoinput" placeholder="Ingrese no. de cuenta" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        </div><br />

                         <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>CIF</b></label>
                            <label class="titulos" style="margin-left:32%"><b>Primer nombre</b></label>
                            <label class="titulos" style="margin-left:21%"><b>Segundo nombre</b></label>
                        </div>

                        <div class="formato">
                             <input id="CIF" runat="server" type="number" class="formatoinput3" placeholder="Ingrese CIF" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                             <input id="PrimerNombre" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput3" placeholder="Ingrese primer nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                             <input id="SegundoNombre" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput3" placeholder="Ingrese segundo nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        </div><br />

                         <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>Otro nombre</b></label>
                            <label class="titulos" style="margin-left:40%"><b>Apellido de casada</b></label>
                        </div>

                        <div class="formato">
                               <input id="OtroNombre" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput" placeholder="Ingrese primer apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                               <input id="ApellidoCasada" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput" placeholder="Ingrese segundo apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        </div><br />

                        <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>Primer apellido</b></label>
                            <label class="titulos" style="margin-left:38%"><b>Segundo apellido</b></label>
                        </div>

                         <div class="formato">
                               <input id="PrimerApellido" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput" placeholder="Ingrese primer apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                               <input id="SegundoApellido" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput" placeholder="Ingrese segundo apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        </div><br />

                        <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>Limite</b></label>
                            <label class="titulos" style="margin-left:47%"><b>Saldo</b></label>
                        </div>

                         <div class="formato">
                               <input id="Limite" runat="server" type="text" class="formatoinput" placeholder="Ingrese el limite" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                               <input id="Saldo" runat="server" type="text" class="formatoinput" placeholder="Ingrese el saldo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        </div><br />
                    </div><br />
                     
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
                            <input id="Gastos1" style="width:32%;text-align:end" runat="server" onchange="gastos1(this.value);" type="text" min="0" class="formatoinput" value="0" maxlength="12" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                         <div class="formato4" style="display:flex; justify-content:flex-start">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-start; width:130px"><b>Gastos judiciales:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="GastosJudiciales" style="width:32%;text-align:end" runat="server" onchange="gastosJudiciales(this.value);" type="text" min="0" class="formatoinput" value="0" maxlength="12" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div class="formato4" style="display:flex; justify-content:flex-start">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-start; width:130px"><b>Otros gastos:</b></label>
                             <label class="titulos" style="width:3%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="OtrosGastos" style="width:21%;text-align:end" runat="server" onchange="otrosGastos(this.value);" type="text" min="0" class="formatoinput" value="0" maxlength="12" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                             <input id="Comentario" style="width:41%; margin-left:4%;" runat="server" type="text" class="formatoinput" placeholder="Comentario" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                          
                        </div><br />

                         <div class="formato4" style="display:flex; justify-content:flex-start;width:100%">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-start; width:130px"><b>Total:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b> </b></label>
                            <span id="Total1" style="width:30%" runat="server" class="formatoinput"></span>
                        </div>
                    </div>
                    </div>

                    
                 </div>

                  <div class="formato2">
                    <asp:Button ID="Validar" runat="server" CssClass="boton" Text="Aceptar" OnClick="Validar_Click"/>
                    <asp:Button ID="Regresar" runat="server" CssClass="boton2" Text="Rechazar" OnClick="Regresar_Click"/>
                  </div><br />

                   <div id="validado" runat="server" class="encabezado">
                        <div class="formato3">
                            <label class="titulos">Razones de rechazo</label>
                            <input id="Observaciones" runat="server" onkeypress="return sololetras(event);" type="text" class="formatoinput2" placeholder="Ingrese observaciones" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        </div><br />
                       <div class="formato3">
                            <label class="titulos">Área a la que se regresa el crédito</label>
                           <asp:DropDownList id="AreaCredito" runat="server" class="formatoinput2" AutoPostBack="false"></asp:DropDownList>
                        </div><br />
                   </div><br />

                  <div id="enviar" class="formato2">
                    <asp:Button ID="Enviar" runat="server" CssClass="boton" Text="Enviar" OnClick="Enviar_Click"/>
                  </div><br />
            </div>
        </div>

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
