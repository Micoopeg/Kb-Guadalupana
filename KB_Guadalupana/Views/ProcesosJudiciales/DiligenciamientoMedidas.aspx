<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiligenciamientoMedidas.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.DiligenciamientoMedidas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Diligenciamiento Medidas Precautorias</title>
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
                    <label style="font-size:18px" class="titulos">Diligenciamiento a medidas precautorias</label>
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
                     <label style="font-size:15px" class="titulos"><b>Diligenciamiento a medidas precautorias</b></label><br /><br />

                                              <label class="titulos"><b>Seleccione las medidas precautorias obligatorias</b></label><br /><br />
                           <div class="formatocheck">
                             <div class="formatocheck2">
                                <input id="MedidasPre1" runat="server" type="checkbox" class="formatocheckbox" value="1" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="MedidasPre1" class="titulos">&nbsp;&nbsp;<b>Embargo de Salario</b></label>
                             </div>
                              <div class="formatocheck2">
                                <input id="MedidasPre2" runat="server" type="checkbox" class="formatocheckbox" value="2" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="MedidasPre2" class="titulos">&nbsp;&nbsp;<b>Embargo de cuentas bancarias</b></label>
                              </div>
                         </div>

                         <div class="formatocheck">
                             <div class="formatocheck2">
                                 <input id="MedidasPre3" runat="server" type="checkbox" class="formatocheckbox" value="3" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                              <label for="MedidasPre3" class="titulos">&nbsp;&nbsp;<b>Arraigo</b></label>
                             </div>
                             <div class="formatocheck2">
                                <input id="MedidasPre4" runat="server" type="checkbox" class="formatocheckbox" value="4" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="MedidasPre4" class="titulos">&nbsp;&nbsp;<b>Embargo en cooperativas</b></label>
                             </div>
                         </div>

                         <div class="formatocheck">
                              <div class="formatocheck2">
                                <input id="MedidasPre5" runat="server" type="checkbox" class="formatocheckbox" value="4" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="MedidasPre5" class="titulos">&nbsp;&nbsp;<b>Embargo de bienes</b></label>
                             </div>
                             <div class="formatocheck2">
                                <input id="MedidasPre6" runat="server" type="checkbox" class="formatocheckbox" value="5" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                <label for="MedidasPre6" class="titulos">&nbsp;&nbsp;<b>Otra</b></label>
                             </div>
                         </div>
                        <input id="OtrasMedidas" runat="server" type="text" class="formatoinput2" placeholder="Ingrese nombre de otra medida" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        <br /><br /><br />

                     <div class="formato3">
                        <label class="titulos"><b>¿Son efectivas?</b></label>
                        <asp:DropDownList id="SonEfectivas" runat="server" class="formatoinput2" AutoPostBack="true" OnSelectedIndexChanged="SonEfectivas_SelectedIndexChanged"></asp:DropDownList>
                    </div><br /><br />

                    <div id="SiEfectivas" runat="server">
                        <br />
                         <label class="titulos"><b>Informe de la efectividad de las medidas precautorias</b></label><br />
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

                        <div class="formato3">
                            <span id="TituloBanco" runat="server" class="titulos"><b>Banco</b></span>
                             <asp:DropDownList id="Banco" runat="server" Width="100%" class="formatoinput2" AutoPostBack="false"></asp:DropDownList>
                        </div>
                        <div class="formato3">
                            <span id="TituloCooperativa" runat="server" class="titulos"><b>Cooperativa</b></span>
                             <asp:DropDownList id="Cooperativa" runat="server" Width="100%" class="formatoinput2" AutoPostBack="false"></asp:DropDownList>
                        </div><br />

                        <div class="formato3">
                              <span id="TituloMonto" runat="server" class="titulos"><b>Monto</b></span>
                            <input id="Monto" runat="server" type="text" class="formatoinput2" placeholder="Ingrese arraigo" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div>

                        <div class="formato3">
                            <span id="TituloTrabajo" runat="server" class="titulos"><b>Lugar de trabajo</b></span>
                            <input id="LugarTrabajo" runat="server" type="text" class="formatoinput2" placeholder="Ingrese lugar de trabajo" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                   
                        <div class="formato3">
                            <span id="TituloArraigo" runat="server" class="titulos"><b>Arraigo</b></span>
                            <input id="Arraigo" runat="server" type="text" class="formatoinput2" placeholder="Ingrese arraigo" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div>

                        <br /><br />
                    </div>

                    <div class="formato3" id="Suficientes" runat ="server">
                        <label class="titulos"><b>¿Son suficientes?</b></label>
                        <asp:DropDownList id="SonSuficientes" runat="server" class="formatoinput2" AutoPostBack="true" OnSelectedIndexChanged="SonSuficientes_SelectedIndexChanged"></asp:DropDownList>
                    <br /><br />
                     </div>

                    <div id="NoEfectivas" runat="server">
                         <div class="formato3">
                            <label class="titulos"><b>Comentario</b></label>
                            <input id="Comentario" runat="server" type="text" class="formatoinput2" placeholder="Ingrese comentario" maxlength="150" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>Días de mora</b></label>
                        </div>
                          <div class="formato">
                            <input id="DiasMora" runat="server" type="text" class="formatoinput" placeholder="Días de mora" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readonly="readonly"/>
                            <asp:Button ID="EnviarSolicitud" runat="server" Width="35%" Height="30px" CssClass="boton3" Text="Enviar Solicitud" />
                        </div><br />

                    </div>

                    
                    
                    <div class="formato3" id="HayResultado" runat="server">
                        <br /><br />
                        <label class="titulos"><b>¿Hay Resultados?</b></label>
                        <asp:DropDownList id="Resultado" runat="server" class="formatoinput2" AutoPostBack="true" OnSelectedIndexChanged="Resultado_SelectedIndexChanged"></asp:DropDownList>
                    <br /><br />
                    </div>

                     <div id="SiResultados" runat="server">
                          <label class="titulos"><b>Documentación de soporte</b></label><br />
                        <div class="formato">
                            <asp:DropDownList id="TipoDocumentacion" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                            <asp:FileUpload id="FileUpload4" runat="server"></asp:FileUpload>
                            <asp:Button ID="Agregar4" OnClick="agregar4_Click" runat="server" Width="20%" Height="30px" CssClass="boton3" Text="Agregar" />
                        </div><br /><br />

                      <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 150px">
                        <asp:GridView ID="gridViewDocumentacion" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedDocumentacion" BorderStyle="Solid">
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
                       </div><br /><br />

                          <div class="formato3">
                            <label class="titulos"><b>Empresa donde labora</b></label>
                            <input id="EmpresaLabora" runat="server" type="text" class="formatoinput2" placeholder="Ingrese empresa donde labora" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <label style="font-size:13px" class="titulos"><b>Vehículo(s)</b></label><br /><br />

                        <div class="formato" style="align-items:center">
                            <div style="width:100%">
                                <div class="formatoTitulo" style="margin-bottom:5px">
                                    <label class="titulos"><b>NIT</b></label>
                                    <label class="titulos" style="margin-left:46%"><b>Placa</b></label>
                                </div>
                                <div class="formato">
                                    <input id="NIT" runat="server" type="text" class="formatoinput" placeholder="Ingrese NIT" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                    <input id="Placa" runat="server" type="text" class="formatoinput" placeholder="Ingrese Placa" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                </div><br />

                                <div class="formatoTitulo" style="margin-bottom:5px">
                                    <label class="titulos"><b>Modelo</b></label>
                                    <label class="titulos" style="margin-left:38%"><b>Marca</b></label>
                                </div>
                                <div class="formato">
                                    <input id="Modelo" runat="server" type="text" class="formatoinput" placeholder="Ingrese Marca" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                    <input id="Marca" runat="server" type="text" class="formatoinput" placeholder="Ingrese Modelo" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                </div><br />
                            </div>
                            <div style="justify-content:center;width:100%;display:flex;">
                             <asp:Button ID="AgregarVehiculo" runat="server" Width="50%" Height="30px" CssClass="boton3" Text="Agregar Vehículo" />
                            </div>
                         </div><br /><br />

                        <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 150px">
                        <asp:GridView ID="gridViewVehiculo" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedVehiculo" BorderStyle="Solid">
                             <Columns>
                                <asp:TemplateField ControlStyle-CssClass="diseño" Visible="false" HeaderText="No. documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblid" Text='<%# Eval("Codigo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Tipo documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnit" Text='<%# Eval("Nit") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblplaca" Text='<%# Eval("Placa") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblmodelo" Text='<%# Eval("Modelo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblmarca" Text='<%# Eval("Marca") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Ver Registro" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="White">
                                    <ItemStyle Width="135px" ForeColor="White"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div><br /><br />

                         <label style="font-size:13px" class="titulos"><b>Bienes Inmuebles</b></label><br /><br />

                        <div class="formato" style="align-items:center">
                            <div style="width:100%">
                                 <div class="formatoTitulo" style="margin-bottom:5px">
                                    <label class="titulos"><b>Finca</b></label>
                                    <label class="titulos" style="margin-left:39%"><b>Folio</b></label>
                                </div>
                                 <div class="formato">
                                    <input id="Finca" runat="server" type="text" class="formatoinput" placeholder="Ingrese Finca" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                    <input id="Folio" runat="server" type="text" class="formatoinput" placeholder="Ingrese Folio" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                </div><br />

                                <div class="formato3">
                                    <label class="titulos"><b>Libro</b></label>
                                    <input id="Libro" runat="server" type="text" class="formatoinput2" placeholder="Ingrese Libro" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                                </div><br />
                            </div>
                            <div style="justify-content:center;width:100%;display:flex;">
                                <asp:Button ID="AgregarBienes" runat="server" Width="50%" Height="30px" CssClass="boton3" Text="Agregar Bien Inmueble" />
                            </div>
                            </div>

                             <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 150px">
                        <asp:GridView ID="gridViewBienes" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedBienes" BorderStyle="Solid">
                             <Columns>
                                <asp:TemplateField ControlStyle-CssClass="diseño" Visible="false" HeaderText="No. documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblid" Text='<%# Eval("Codigo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Tipo documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblfinca" Text='<%# Eval("Finca") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblfolio" Text='<%# Eval("Folio") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lbllibro" Text='<%# Eval("Libro") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Ver Registro" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="White">
                                    <ItemStyle Width="135px" ForeColor="White"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div><br /><br />
                         
                          <label class="titulos"><b>Memorial</b></label><br />
                        <div class="formato">
                            <asp:DropDownList id="TipoMemorial" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                            <asp:FileUpload id="FileUpload5" runat="server"></asp:FileUpload>
                            <asp:Button ID="Agregar5" OnClick="agregar5_Click" runat="server" Width="20%" Height="30px" CssClass="boton3" Text="Agregar" />
                        </div><br /><br />

                          <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 150px">
                        <asp:GridView ID="gridViewMemorial" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedMemorial" BorderStyle="Solid">
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
                       </div><br /><br />

                         <label style="font-size:13px" class="titulos"><b>Gestión realizada para cada medida</b></label><br /><br />

                        <div class="formato">
                             <label class="titulos"><b>Embargo de Salario</b></label>
                             <asp:DropDownList id="Gestion1" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                        </div><br />

                        <div class="formato">
                            <label class="titulos"><b>Embargo de cuentas bancarias</b></label>
                            <asp:DropDownList id="Gestion2" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                        </div><br />

                        <div class="formato">
                            <label class="titulos"><b>Arraigo</b></label>
                            <asp:DropDownList id="Gestion3" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                        </div><br />

                        <div class="formato">
                            <label class="titulos"><b>Embargo en cooperativas</b></label>
                            <asp:DropDownList id="Gestion4" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                        </div><br />

                         <div class="formato">
                            <label class="titulos"><b>Embargo de bienes</b></label>
                            <asp:DropDownList id="Gestion5" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                        </div><br /><br /><br />

                         <div class="formato3">
                            <label class="titulos"><b>Fecha de presentación del memorial</b></label>
                            <input id="FechaMemorial" runat="server" type="date" class="formatoinput2"/>
                         </div><br />

                    </div>

                     <div class="formato3" id="EsVoluntaria" runat="server">
                        <label class="titulos"><b>¿La transacción es voluntaria?</b></label>
                        <asp:DropDownList id="Voluntaria" runat="server" class="formatoinput2" AutoPostBack="true" OnSelectedIndexChanged="Voluntaria_SelectedIndexChanged"></asp:DropDownList>
                    </div><br /><br />

                    <div id="TransaccionVoluntaria" runat="server"><br />
                        <br />
                        <div class="formato3">
                            <label class="titulos" style="margin-left:39%"><b>Fecha de presentación</b></label>
                            <input id="FechaPresentacion" runat="server" type="date" class="formatoinput"/>
                        </div><br />

                        <div id="InfoMonto" runat="server" class="formato3">
                             <label class="titulos"><b>Monto a transar</b></label>
                             <input id="MontoTransar" runat="server" type="text" class="formatoinput" placeholder="Ingrese monto a transar" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div>

                         <div id="InfoTrabajo" runat="server" class="formato3">
                            <label class="titulos"><b>Lugar de trabajo</b></label>
                            <input id="LugarTrabajo2" runat="server" type="text" class="formatoinput2" placeholder="Ingrese lugar de trabajo" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                        <div id="InfoBanco" runat="server" class="formato3">
                            <label class="titulos"><b>Banco</b></label>
                            <asp:DropDownList id="Banco2" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>
                        </div>

                        <div id="InfoCooperativa" runat="server" class="formato3">
                            <label class="titulos"><b>Cooperativa</b></label>
                            <asp:DropDownList id="Cooperativa2" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>
                        </div><br /><br />

                        <label class="titulos"><b>Memorial de transacción</b></label><br />
                         <div class="formato">
                            <asp:DropDownList id="TipoDocumentoMemorial" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                            <asp:FileUpload id="FileUpload2" runat="server"></asp:FileUpload>
                            <asp:Button ID="Agregar2" OnClick="agregar2_Click" runat="server" Width="20%" Height="30px" CssClass="boton3" Text="Agregar" />
                        </div><br /><br />

                         <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 150px">
                        <asp:GridView ID="gridViewDocumentoMemorial" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedDocumentoMemorial" BorderStyle="Solid">
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
                       </div><br /><br />
                    </div>


                    <div id="ResolucionTransaccion" runat="server">
                        <br />
                         <label class="titulos"><b>Resolución de transacción</b></label><br />
                        <div class="formato">
                            <asp:DropDownList id="TipoDocumentoResolucion" runat="server" class="formatoinput3" AutoPostBack="false"></asp:DropDownList>
                            <asp:FileUpload id="FileUpload3" runat="server"></asp:FileUpload>
                            <asp:Button ID="Agregar3" OnClick="agregar3_Click" runat="server" Width="20%" Height="30px" CssClass="boton3" Text="Agregar" />
                        </div><br /><br />
                          <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 150px">
                        <asp:GridView ID="gridViewDocumentoResolucion" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedDocumentoResolucion" BorderStyle="Solid">
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
                       </div><br /><br />

                          <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>Fecha de resolución</b></label>
                            <label class="titulos" style="margin-left:39%"><b>Fecha de notificación</b></label>
                        </div>
                        <div class="formato">
                            <input id="FechaResolucion" runat="server" type="date" class="formatoinput"/>
                            <input id="FechaNotificacion" runat="server" type="date" class="formatoinput"/>
                        </div><br />
                    </div>


                </div>

                <div class="formato2">
                    <asp:Button ID="Guardar" runat="server" CssClass="boton" Text="Guardar"/>
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
            document.getElementById('OtrasMedidas').style.visibility = "hidden";

            function on() {
                //alert("Hemos pulsado en on");
                document.getElementById('OtrasMedidas').style.visibility = "visible";
            }

            function off() {
                //alert("Hemos pulsado en off");
                document.getElementById('OtrasMedidas').style.visibility = "hidden";
            }

            var checkbox6 = document.getElementById('MedidasPre6');
            checkbox6.addEventListener("change", comprueba, false);

            function comprueba() {
                if (checkbox6.checked) {
                    on();
                } else {
                    off();
                }
            }

        </script>
    <%--    <script>
            document.getElementById('LugarTrabajo').style.visibility = "hidden";
            document.getElementById('TituloTrabajo').style.visibility = "hidden";
            document.getElementById('Banco').style.visibility = "hidden";
            document.getElementById('TituloBanco').style.visibility = "hidden";
            document.getElementById('Cooperativa').style.visibility = "hidden";
            document.getElementById('TituloCooperativa').style.visibility = "hidden";
            document.getElementById('Arraigo').style.visibility = "hidden";
            document.getElementById('TituloArraigo').style.visibility = "hidden";
            document.getElementById('Monto').style.visibility = "hidden";
            document.getElementById('TituloMonto').style.visibility = "hidden";

            function on() {
                //alert("Hemos pulsado en on");
                document.getElementById('LugarTrabajo').style.visibility = "visible";
                document.getElementById('TituloTrabajo').style.visibility = "visible";
            }

            function off() {
                //alert("Hemos pulsado en off");
                document.getElementById('LugarTrabajo').style.visibility = "hidden";
                document.getElementById('TituloTrabajo').style.visibility = "hidden";
            }

            function on2() {
                //alert("Hemos pulsado en on");
                document.getElementById('Banco').style.visibility = "visible";
                document.getElementById('TituloBanco').style.visibility = "visible";
                document.getElementById('Monto').style.visibility = "visible";
                document.getElementById('TituloMonto').style.visibility = "visible";
            }

            function off2() {
                //alert("Hemos pulsado en off");
                document.getElementById('Banco').style.visibility = "hidden";
                document.getElementById('TituloBanco').style.visibility = "hidden";
                document.getElementById('Monto').style.visibility = "hidden";
                document.getElementById('TituloMonto').style.visibility = "hidden";
            }

            function on3() {
                //alert("Hemos pulsado en on");
                document.getElementById('Arraigo').style.visibility = "visible";
                document.getElementById('TituloArraigo').style.visibility = "visible";
            }

            function off3() {
                //alert("Hemos pulsado en off");
                document.getElementById('Arraigo').style.visibility = "hidden";
                document.getElementById('TituloArraigo').style.visibility = "hidden";
            }

            function on4() {
                //alert("Hemos pulsado en on");
                document.getElementById('Cooperativa').style.visibility = "visible";
                document.getElementById('TituloCooperativa').style.visibility = "visible";
                document.getElementById('Monto').style.visibility = "visible";
                document.getElementById('TituloMonto').style.visibility = "visible";
            }

            function off4() {
                //alert("Hemos pulsado en off");
                document.getElementById('Cooperativa').style.visibility = "hidden";
                document.getElementById('TituloCooperativa').style.visibility = "hidden";
                document.getElementById('Monto').style.visibility = "hidden";
                document.getElementById('TituloMonto').style.visibility = "hidden";
            }

            function on5() {
                
            }

            function off5() {
                
            }

            var checkbox = document.getElementById('MedidasPre1');
            var checkbox2 = document.getElementById('MedidasPre2');
            var checkbox3 = document.getElementById('MedidasPre3');
            var checkbox4 = document.getElementById('MedidasPre4');
            var checkbox5 = document.getElementById('MedidasPre5');
            var checkbox6 = document.getElementById('MedidasPre6');

            checkbox.addEventListener("change", comprueba, false);
            checkbox2.addEventListener("change", comprueba2, false);
            checkbox3.addEventListener("change", comprueba3, false);
            checkbox4.addEventListener("change", comprueba4, false);
            checkbox5.addEventListener("change", comprueba5, false);
            checkbox6.addEventListener("change", comprueba6, false);

            function comprueba() {
                if (checkbox.checked) {
                    on();
                } else {
                    off();
                }
            }

            function comprueba2() {
                if (checkbox2.checked) {
                    on2();
                } else {
                    off2();
                }
            }

            function comprueba3() {
                if (checkbox3.checked) {
                    on3();
                } else {
                    off3();
                }
            }

            function comprueba4() {
                if (checkbox4.checked) {
                    on4();
                } else {
                    off4();
                }
            }

            function comprueba5() {
                if (checkbox5.checked) {
                    on5();
                } else {
                    off5();
                }
            }
        </script>--%>

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
    </form>
</body>
</html>
