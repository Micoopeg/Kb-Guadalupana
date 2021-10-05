<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevueltosSolicitudCheque.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.DevueltosSolicitudCheque" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Verificación requerimiento de pago</title>
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
             align-items:center;
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
            width:45%;
        }
        .header{ border-top:1px solid white;background:white; color:#333; height:0px; width:100%; font-family: 'Lobster', cursive; text-align:center}
.menu2{visibility:hidden; height:auto; width:17%; color:white; text-align:left; padding-top:5px; left:0; margin-left:0px;margin-top:75px;background-color:#435F7A; border:2px #4B752B solid;padding-left:13px;}
.wrapper{ height:100px; width:100%; padding-top:20px}
 
.fixed{position:fixed; top:0;visibility:visible}

    </style>
</head>
     <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="general">
            <div class="formularioCobros">

                  <div style="display:flex; justify-content:center">
                    <label style="font-size:18px" class="titulos">Verificación del requerimiento de pago</label>
                 </div><br />
                
                   <div class="header"></div>

                <div class="encabezado">

                    <label class="titulos"><b>Documentos</b></label><br /><br />

                    <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 175px">
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
                                <asp:ButtonField   Text="Ver Documento" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="White">
                                    <ItemStyle Width="135px" ForeColor="White"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div><br /><br />

                      <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>No. de factura</b></label>
                            <label class="titulos" style="margin-left:40%"><b>No. de serie</b></label>
                        </div>
                        <div class="formato">
                              <input id="NumFactura" runat="server" type="text" class="formatoinput" placeholder="Ingrese no. factura" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                             <input id="Serie" runat="server" type="text" class="formatoinput" placeholder="Ingrese no. serie" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                      <div class="formato3">
                        <label class="titulos"><b>Descripción</b></label>
                         <input id="Descripcion" runat="server" type="text" class="formatoinput2" onkeypress="return sololetras(event);" placeholder="Ingrese descripcion" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                    </div><br />

                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Importe total</b></label>
                        <label class="titulos" style="margin-left:23%"><b>Fecha de emisión</b></label>
                        <label class="titulos" style="margin-left:18%"><b>Importe del caso</b></label>
                    </div>
                     <div class="formato">
                        Q<input id="ImporteTotal2" runat="server" type="text" class="formatoinput3" min="0" onkeyup="format(this)" onchange="format(this);" placeholder="Ingrese importe total" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        <input id="FechaEmision" runat="server" type="date" class="formatoinput3"/>
                        Q<input id="ImporteCaso" runat="server" type="text" min="0" class="formatoinput3" onkeyup="format(this)" onchange="format(this);" placeholder="Ingrese importe del caso" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                    </div><br />

                        
                      <div class="formato3">
                         <label class="titulos"><b>Nombre a quién se emite el cheque</b></label>
                         <input id="NombreCheque" runat="server" type="text" class="formatoinput2" placeholder="Ingrese nombre" onkeypress="return sololetras(event);" maxlength="60" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                    </div><br />

                      <div class="formato3">
                        <label class="titulos"><b>Motivo de pago</b></label>
                        <asp:DropDownList id="MotivoPago" runat="server" Width="100%" class="formatoinput2" AutoPostBack="true" OnSelectedIndexChanged="MotivoPago_SelectedIndexChanged1"></asp:DropDownList>
                    </div><br />

                     <input id="Otro" runat="server" type="text" min="0" class="formatoinput2" onkeypress="return sololetras(event);" placeholder="Ingrese otro motivo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                    <br /><br />

                        <div class="formato2">
                            <asp:Button ID="Actualizar" runat="server" Width="45%" CssClass="boton3" Text="Actualizar Datos" OnClick="Actualizar_Click" />
                        </div><br />

                    <div id="ObservacionesFactura" visible="false" runat="server">
                        <span id="Span1" runat="server" class="titulos">Razones de rechazo</span>
                        <input id="Text1" runat="server" type="text" class="formatoinput2" placeholder="Ingrese razones de rechazo (si es el caso)" maxlength="150" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        <br />
                    </div>

                    <div class="formato2">
                        <asp:Button ID="Validar" runat="server" CssClass="boton" Text="Validar" OnClick="Validar_Click" />
                        <asp:Button ID="Rechazar" runat="server" CssClass="boton" Text="Rechazar" OnClick="Rechazar_Click" Visible="false"/>
                    </div><br />

                    <br /><br />

                    <div id="pfd" runat="server">

                 
                      <div style="display:flex; justify-content:center">
                        <label style="font-size:18px" class="titulos">Solicitud de cheque</label>
                    </div><br />

                   <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>Observaciones </b></label>
                            <label class="titulos" style="margin-left:39%"><b>Concepto</b></label>
                        </div>
                        <div class="formato">
                             <input id="Observaciones" runat="server" type="text" class="formatoinput" placeholder="Ingrese observaciones" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                             <input id="Concepto" runat="server" type="text" class="formatoinput" placeholder="Ingrese concepto" maxlength="600" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        </div><br /><br />

                        <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>Nombre de la cuenta</b></label>
                            <label class="titulos" style="margin-left:15%"><b>No. de cuenta</b></label>
                            <label class="titulos" style="margin-left:17%"><b>Centro de costo</b></label>
                        </div>
                        <div class="formato">
                            <input id="NombreCuenta" runat="server" type="text" class="formatoinput3" placeholder="Ingrese observaciones" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                             <input id="NumCuenta" runat="server" type="text" class="formatoinput3" placeholder="Ingrese concepto" maxlength="600" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                             <input id="CentroCosto" runat="server" type="text" class="formatoinput3" placeholder="Ingrese centro de costo" maxlength="600" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        </div>

                       <%-- <label class="titulos">Concepto</label>
                          <input id="" runat="server" type="text" class="formatoinput2" placeholder="Ingrese concepto" maxlength="600" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />--%>

                        <br /><br /><br />
                        <label class="titulos"><b>Seleccione las personas encargadas de firmar la solicitud</b></label><br /><br /><br />
                           <div class="formatocheck">
                             <div class="formatocheck2">
                                <input id="Nombre1" runat="server" type="checkbox" class="formatocheckbox" value="1" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="Nombre1" class="titulos">&nbsp;&nbsp;<b>Lhea Sandoval - Jefe Jurídico</b></label>
                             </div>
                              <div class="formatocheck2">
                                <input id="Nombre2" runat="server" type="checkbox" class="formatocheckbox" value="2" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="Nombre2" class="titulos">&nbsp;&nbsp;<b>Daniel Fuentes - Gerente Jurídico</b></label>
                              </div>
                         </div><br />

                         <div class="formatocheck">
                             <div class="formatocheck2">
                                <input id="Nombre3" runat="server" type="checkbox" class="formatocheckbox" value="1" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="Nombre3" class="titulos">&nbsp;&nbsp;<b>Danielo Morales - Gerente Financiero</b></label>
                             </div>
                              <div class="formatocheck2">
                                <input id="Nombre4" runat="server" type="checkbox" class="formatocheckbox" value="2" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="Nombre4" class="titulos">&nbsp;&nbsp;<b>Juan Carlos Herrera - Subgerente General</b></label>
                              </div>
                         </div>
                    <br /><br /><br />

                   </div>

                    <input id="NombreUsuario" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="FechaActual" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="ImporteTotal" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="NumCredito" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                     <input id="NombreCliente" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="NombreFirma1" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="PuestoFirma1" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="Linea1" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="NombreFirma2" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="PuestoFirma2" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="Linea2" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="NombreFirma3" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="PuestoFirma3" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="Linea3" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="NombreFirma4" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="PuestoFirma4" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="Linea4" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>

                         <div class="formato2">
                            <asp:Button ID="Generar" runat="server" Width="30%" Height="30px" CssClass="boton3" Text="Generar solictud de cheque" OnClick="Generar_Click" />
                         </div><br />

                     <span id="TituloObservaciones" runat="server" class="titulos">Observaciones</span>
                          <input id="ObservacionesCredito" runat="server" type="text" class="formatoinput2" placeholder="Ingrese observaciones" maxlength="150" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    <br />

                </div>

                   <div class="formato2">
                    <asp:Button ID="Guardar" runat="server" CssClass="boton" Text="Guardar" OnClick="Guardar_Click" />
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
                         <label class="titulos"><b>No. Proceso</b></label>
                        <input id="NumProceso" runat="server" type="text" class="formatoinput5" min="0" placeholder="No. Proceso" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
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

                  <%--<div class="encabezado" id="voucher" runat="server">
                       <label class="titulos"><b>Voucher</b></label>
                        <div class="formato">
                            <asp:DropDownList id="PTipoDocumento" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                            <asp:FileUpload id="FileUpload1" runat="server"></asp:FileUpload>
                            <asp:Button ID="Agregar" OnClick="agregar_Click" runat="server" Width="20%" Height="30px" CssClass="boton3" Text="Agregar" />
                        </div><br /><br />

                           <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 145px">
                        <asp:GridView ID="gridViewDocumentos2" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedDocumento2" BorderStyle="Solid">
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
                       </div>

                      <label class="titulos">Observaciones</label>
                          <input id="ObservacionesCredito2" runat="server" type="text" class="formatoinput2" placeholder="Ingrese observaciones" maxlength="150" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    <br />
                    </div>

                    <div class="formato2">
                    <asp:Button ID="GuardarVoucher" runat="server" CssClass="boton" Text="Guardar" OnClick="GuardarVoucher_Click" />
                  </div><br />--%>

            </div>
        </div>

            <script type="text/javascript">
                function sololetras(evt) {
                    var charCode = (evt.which) ? evt.which : event.keyCode
                    if (charCode > 31 && (charCode < 48 || charCode > 57))
                        return true;

                    return false;
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
                    var texto1 = document.querySelector('#NumFactura');

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
             var texto1 = document.querySelector('#RegistroContable');

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
    </form>
</body>
</html>
