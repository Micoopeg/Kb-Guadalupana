<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcesoJudicial.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.ProcesoJudicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Crédito</title>
     <style>

        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:'Montserrat';
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

    </style>
</head>
    <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">
                <div id="formulario" runat="server" class="encabezado">
                        <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Nombre de agencia</b></label>
                            <label class="titulos" style="margin-left:38%"><b>Instrumento</b></label>
                        </div>
                        <div class="formato">
                              <input id="Agencia" runat="server" type="text" class="formatoinput" placeholder="Nombre de agencia" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                             <input id="Instrumento" runat="server" type="text" class="formatoinput" placeholder="Instrumento" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                     <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Línea de crédito</b></label>
                            <label class="titulos" style="margin-left:40%"><b>Destino</b></label>
                        </div>
                        <div class="formato">
                              <input type="text" id="LineaCredito" runat="server" class="formatoinput" placeholder="Línea de crédito" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                             <input id="destino" runat="server" type="text" class="formatoinput" placeholder="Destino" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                     <div class="formato3">
                        <label class="titulos"><b>Garantía</b</label>
                         <input id="Garantia" runat="server" type="text" class="formatoinput2" placeholder="Garantía" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Plazo en meses</b></label>
                        <label class="titulos" style="margin-left:23%"><b>Método de cálculo</b></label>
                        <label class="titulos" style="margin-left:21%"><b>Estado</b></label>
                    </div>

                    <div class="formato">
                        <input id="Plazomeses" runat="server" type="number" class="formatoinput3" min="0" placeholder="Plazo en medes" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="Metodocalculo" runat="server" type="text" class="formatoinput3" placeholder="Método cálculo" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                         <input id="Estado" runat="server" type="text" class="formatoinput3" placeholder="Estado" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                       <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Moneda</b></label>
                            <label class="titulos" style="margin-left:46%"><b>Tasa</b></label>
                        </div>
                         <div class="formato">
                              <input id="Moneda" runat="server" type="text" class="formatoinput" placeholder="Moneda" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                             <input id="Tasa" runat="server" type="number" class="formatoinput" min="0" placeholder="Tasa" maxlength="10" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                     <div class="formato3">
                        <label class="titulos"><b>Fecha solicitud</b</label>
                        <input id="FechaSolicitud" runat="server" type="text" class="formatoinput2" placeholder="Fecha solicitud" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Fecha 1er. desembolso</b></label>
                        <label class="titulos" style="margin-left:35%"><b>Fecha último desembolso</b></label>
                    </div>

                    <div class="formato">
                           <input id="FechaDesembolso1" runat="server" type="text" class="formatoinput" placeholder="Fecha 1er. desembolso" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="FechaUltimoDes" runat="server" type="text" class="formatoinput" placeholder="Fecha último desembolso" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                     <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Fecha de vencimiento</b></label>
                        <label class="titulos" style="margin-left:35%"><b>Fecha última cuota</b></label>
                    </div>

                    <div class="formato">
                           <input id="FechaVencimiento" runat="server" type="text" class="formatoinput" placeholder="Fecha de vencimiento" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="FechaUltimaCuota" runat="server" type="text" class="formatoinput" placeholder="Fecha última cuota" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                      <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Fecha de acta</b></label>
                        <label class="titulos" style="margin-left:42%"><b>Número de acta</b></label>
                    </div>

                    <div class="formato">
                           <input id="FechaActa" runat="server" type="text" class="formatoinput" placeholder="Fecha de acta" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="NumActa" runat="server" type="text" class="formatoinput" placeholder="Número de acta" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                      <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Oficial - Primer Nombre</b></label>
                        <label class="titulos" style="margin-left:33%"><b>Oficial - Segundo Nombre</b></label>
                    </div>

                    <div class="formato">
                           <input id="OficialNombre1" runat="server" type="text" class="formatoinput" placeholder="Primer nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="OficialNombre2" runat="server" type="text" class="formatoinput" placeholder="Segundo nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                      <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Oficial - Primer Apellido</b></label>
                        <label class="titulos" style="margin-left:33%"><b>Oficial - Segundo Apellido</b></label>
                    </div>

                    <div class="formato">
                           <input id="OficialApellido1" runat="server" type="text" class="formatoinput" placeholder="Primer Apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="OficialApellido2" runat="server" type="text" class="formatoinput" placeholder="Segundo Apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                         <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>No. de prestamo</b></label>
                        <label class="titulos" style="margin-left:22%"><b>Agencia cliente</b></label>
                        <label class="titulos" style="margin-left:23%"><b>Código cliente</b></label>
                    </div>

                    <div class="formato">
                        <input id="NumPrestamo" runat="server" type="number" class="formatoinput3" min="0" placeholder="No. prestamo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="AgenciaCliente" runat="server" type="text" class="formatoinput3" placeholder="Agencia cliente" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                         <input id="CodigoCliente" runat="server" type="number" min="0" class="formatoinput3" placeholder="Código cliente" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                       <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Cliente - Primer Nombre</b></label>
                        <label class="titulos" style="margin-left:33%"><b>Cliente - Segundo Nombre</b></label>
                    </div>

                    <div class="formato">
                           <input id="ClienteNombre1" runat="server" type="text" class="formatoinput" placeholder="Primer nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="ClienteNombre2" runat="server" type="text" class="formatoinput" placeholder="Segundo nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Cliente - Primer Apellido</b></label>
                        <label class="titulos" style="margin-left:33%"><b>Cliente - Segundo Apellido</b></label>
                    </div>

                    <div class="formato">
                           <input id="ClienteApellido1" runat="server" type="text" class="formatoinput" placeholder="Primer Apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="ClienteApellido2" runat="server" type="text" class="formatoinput" placeholder="Segundo Apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                   <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Monto original</b></label>
                        <label class="titulos" style="margin-left:23%"><b>Capital desembolsado</b></label>
                        <label class="titulos" style="margin-left:18%"><b>Saldo actual</b></label>
                    </div>

                    <div class="formato">
                        <input id="MontoOriginal" runat="server" type="number" class="formatoinput3" min="0" placeholder="Monto original" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="CapitalDesem" runat="server" type="number" class="formatoinput3" min="0" placeholder="Capital desembolsado" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="SaldoActual" runat="server" type="number" min="0" class="formatoinput3" placeholder="Saldo actual" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formato3">
                        <label class="titulos"><b>Descripción Documento</b</label>
                        <input id="DescripcionDoc" runat="server" type="text" class="formatoinput2" placeholder="Fecha solicitud" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                </div><br />

                <div class="encabezado">
                    <label class="titulos"><b>Documentos para conformación de expediente</b></label><br /><br />

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
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. documento">
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
                             <HeaderStyle CssClass="prueba"  ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                    </div>
                </div><br />

                <div style="flex-direction:row;display:flex" class="encabezado">
                    <div>
                        <div class="formato4">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-end; width:100px"><b>Saldo capital:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Saldo1" runat="server" type="number" min="0" class="formatoinput" placeholder="Saldo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readonly="readonly"/>
                        </div><br />

                        <div class="formato4">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-end; width:100px"><b>Intereses:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Interes1" runat="server" type="number" min="0" class="formatoinput" placeholder="Intereses" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readonly="readonly"/>
                        </div><br />

                         <div class="formato4">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-end; width:100px"><b>Mora:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                              <input id="Number1" runat="server" type="number" min="0" class="formatoinput3" placeholder="Saldo actual" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                         <div class="formato4">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-end; width:100px"><b>Gastos cobranza:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Gastos1" runat="server" type="number" min="0" class="formatoinput" placeholder="Gastos cobranza" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readonly="readonly"/>
                        </div><br />

                         <div class="formato4">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-end; width:100px"><b>Total:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Total1" runat="server" type="number" min="0" class="formatoinput" placeholder="Total" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readonly="readonly"/>
                        </div>
                    </div>

                      <div>
                        <div class="formato4">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-end; width:100px"><b>Saldo capital:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Saldo2" type="number" min="0" class="formatoinput" placeholder="Saldo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div class="formato4">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-end; width:100px"><b>Intereses:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Intereses2" runat="server" type="number" min="0" class="formatoinput" placeholder="Intereses" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        </div><br />

                         <div class="formato4">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-end; width:100px"><b>Mora:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Mora2" runat="server" type="number" min="0" class="formatoinput" placeholder="Mora" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                         <div class="formato4">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-end; width:100px"><b>Gastos cobranza:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Gastos2" runat="server" type="number" min="0" class="formatoinput" placeholder="Gastos cobranza" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                         <div class="formato4">
                            <label class="titulos" style="display:flex;align-items:center;justify-content:flex-end; width:100px"><b>Total:</b></label>
                             <label class="titulos" style="width:4%;margin-left:20px;display:flex;align-items:center"><b>Q</b></label>
                            <input id="Total2" runat="server" type="number" min="0" class="formatoinput" placeholder="Total" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div>
                    </div>
                </div>

                  <div class="formato2">
                        <asp:Button ID="PCBoton" runat="server" CssClass="boton" Text="Guardar"/>
                    </div><br />
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
