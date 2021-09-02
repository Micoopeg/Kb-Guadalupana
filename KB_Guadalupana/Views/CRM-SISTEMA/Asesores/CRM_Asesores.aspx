<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Asesores.aspx.cs" ValidateRequest="false" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Asesores.CRM_Asesores" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CRM - GUADALUPANA</title>
    <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg" />
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css' />
    <link rel="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../../CRM-Estilos/Estilos.css" type="text/css" />

    <style type="text/css">
        .img-fluid {
            height: 107px;
            width: 124px;
        }

        body, html {
            margin: 0;
            padding: 0;
        }

        .header {
            border-top: 1px solid white;
            background: white;
            color: #333;
            height: 150px;
            width: 100%;
            font-family: 'Lobster', cursive;
            text-align: center
        }

        .menu {
            height: 180px;
            width: 100%;
            background: white;
            color: black;
            text-align: center
        }

        .wrapper {
            height: 1000px;
            width: 100%;
            padding-top: 20px
        }

        .fixed {
            position: fixed;
            top: 4px;
            width: 81%;
        }
        .sub12{
        background-color:#004078;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <header style="background-color: #005363; margin-top: 10px">
        </header>
        <!-- partial:index.partial.html -->
        <div id="responsive-admin-menu" style="height: 1963px">
            <div id="responsive-menu">
                <div class="menuicon">≡</div>
            </div>
            <center>
			<div id="logo">
				<a href="../MenuPrincipal/CRM_MenuPrincipal.aspx"><img src="../../../Imagenes/logo.jpeg" class="img-fluid" style="width: auto;border-radius:49px;height: 100px;position: absolute;left: 44px;" alt="Responsive image" /></a>                
    </div>
	</center>
            <!--Menu-->
            <div id="menu">
                <a href="CRM_Alertas.aspx" title="Alertas"><i class="icon-bullhorn"></i><span>Alertas (
                            <asp:Label ID="Label2" runat="server" Text="1" ForeColor="White"></asp:Label>
                    )</span></a>
               <%-- <a href="CRM_Prospectosfinalizados.aspx" title="Asociadosfinalizados"><i class="icon-file-alt"></i><span>Prospectos Finalizados</span></a>
                <a href="CRM_Prospectosenproceso.aspx" title="AsociadosAprobados"><i class="icon-file-alt"></i><span>Prospectos Aprobados</span></a>
                --%><a href="CRM_Crearreferido.aspx" title="Crear Referido"><i class="icon-book"></i><span>Crear Referido</span></a>
                <asp:LinkButton ID="btnmostrartodoproceso" style="margin-left:6px"  runat="server" OnClick="btnmostrartodoproceso_Click">|-[MOSTRAR TODOS]-|</asp:LinkButton>                
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>                       
                <asp:LinkButton ID="btn12" runat="server" CssClass="sub12" Text='<%# Eval("crmestado_descripcionnombre") %>' OnClick="btn12_Click" Style="display: table-caption; width:inherit; margin-left:1px"><i class="icon-bullhorn"></i>                       
                 </asp:LinkButton>                        
                        <asp:Label ID="Label3" Visible="false" runat="server" Text='<%# Eval("codcrmestadodescripcion") %>'></asp:Label>                     
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <!--Menu-->
        </div>

        <div id="content-wrapper" style="height: 1931px">
            <div style="border: 1px #e8e8e8 solid; width: 100%; float: right; margin: 10px 0px 10px 0px">
                <div style="border-bottom: 1px #e8e8e8 solid; background-color: #f3f3f3; padding: 8px; font-size: 13px; font-weight: 700; color: #45484d;">
                    ESTATUS DE POSPECTOS
                </div>
                <div class="menu" style="border-style: groove;">
                    <center>            
                  <%-- GRIDVIEW Inversiones--%>
                        <%-- GRIDVIEW Inversione2s--%>
                        <span runat="server" id="bnombre">Buscar por nombre:</span><asp:TextBox BorderStyle="Groove" runat="server" style="margin-left:1%"  ID="txtbusquedaprospecto"></asp:TextBox>
                        <asp:LinkButton runat="server" style="text-decoration:none" ID="busquedaporfiltro" OnClick="busquedaporfiltro_Click">Buscar</asp:LinkButton>
                         <asp:CheckBox ID="chkproceso" OnCheckedChanged="chkproceso_CheckedChanged" AutoPostBack="true" runat="server" Text="Proceso"></asp:CheckBox>
                        <asp:CheckBox ID="chknocontesta" runat="server" OnCheckedChanged="chknocontesta_CheckedChanged" AutoPostBack="true" Text="No contesta"></asp:CheckBox>
                       <br />
                        <asp:Label ID="mensajeprospecto" runat="server" Visible="false"></asp:Label>
                        <div id="divGridprospecto" style="overflow: auto; height: 153px" runat="server">
                 <asp:GridView ID="gridviewprospectos" CssClass="mGrid"  runat="server" HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedprospectos" BorderStyle="Solid" Width="90%" >
                     <Columns>
                         <asp:TemplateField HeaderText="Numero" Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblcodigo" Text='<%# Eval("codcrminfoprospecto")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Numero" Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblcodigogeneralprospecto" Text='<%# Eval("codcrminfogeneralprospecto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Número de DPI">
                           <ItemTemplate>
                            <asp:Label ID="lbldpi" Text='<%# Eval("crminfogeneral_prospectodpi") %>' runat="server" />

                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Nombre completo">
                           <ItemTemplate>
                            <asp:Label ID="lblnombre" Text='<%# Eval("crminfogeneral_prospectonombrecompleto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Numero telefonico">
                           <ItemTemplate>
                            <asp:Label ID="lbltelefono" Text='<%# Eval("crminfo_prospectotelefono") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="email" Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblcorreo" Text='<%# Eval("crminfo_prospectoemail") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>    
                         <asp:TemplateField HeaderText="ingresos" Visible="false" >
                           <ItemTemplate>
                            <asp:Label ID="lblingresos" Text='<%# Eval("crminfo_prospectoingresos") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="egresos" Visible="false" >
                           <ItemTemplate>
                            <asp:Label ID="lblegresos" Text='<%# Eval("crminfo_prospectoegresos") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="años laborados"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblañoslaborados" Text='<%# Eval("crminfo_prospectoañoslaborados") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                           <asp:TemplateField HeaderText="trabaja actualmente"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lbltabajaactualmente" Text='<%# Eval("crminfo_prospectotrabajaactualmente") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="descripcion del trabajo"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lbldescripciondeltrabajo" Text='<%# Eval("crminfo_prospectodescripciontrabajoactual") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="tipo de sevicio"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblservicio" Text='<%# Eval("codcrmtiposervicio") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                              <asp:TemplateField HeaderText="Monto"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblmonto" Text='<%# Eval("crminfo_prospectomonto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                              <asp:TemplateField HeaderText="finalidad de servicio"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblfinalidadservicio" Text='<%# Eval("codcrmfinalidadservicio") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                              <asp:TemplateField HeaderText="contacto de llamada"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblcontactollamada" Text='<%# Eval("codcrmcontactollamadas") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                              <asp:TemplateField HeaderText="Primera llamada" Visible="false" >
                           <ItemTemplate>
                            <asp:Label ID="lblprimerallamada" Text='<%# string.Format("{0: yyyy-MM-dd}",Eval("crminfo_prospectofechaprimerllamada")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                              <asp:TemplateField HeaderText="Ultima llamada"  Visible="true">
                           <ItemTemplate>

                            <asp:Label ID="lblultimallamada" Text='<%# string.Format("{0: yyyy-MM-dd}",Eval("crminfo_prospectofechaultimallamada")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                              <asp:TemplateField HeaderText="semaforo estado"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblsemaforoestado" Text='<%# Eval("codcrmsemaforoestado") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                              <asp:TemplateField HeaderText="descripcion de estado"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblsemaforodescripcion" Text='<%# Eval("codcrmestadodescripcion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                              <asp:TemplateField HeaderText="igss"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lbligss" Text='<%# Eval("crminfo_prospectocuentaconigss") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="tipo de domicilio"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lbltipodomicilio" Text='<%# Eval("codcrmtipodomicilio") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="años de domicilio"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblañosendomicilio" Text='<%# Eval("crminfo_prospectoañosdomicilio") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="cuenta en coope"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblcuentaencoope" Text='<%# Eval("crminfo_prospectocuentaencooperativa") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Sucursal"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblsucursalcercana" Text='<%# Eval("crminfo_prospectosucursalcerca") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Comentario o descripción"  Visible="true">
                           <ItemTemplate>
                            <asp:Label ID="lbldescripcion" Text='<%# Eval("crminfo_prospectodescripcion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                 <asp:TemplateField HeaderText="Contactado por"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblcontactado" Text='<%# Eval("crminfo_contactadopor") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Dpi de referencia"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lbldpireferencia" Text='<%# Eval("crminfo_prospectoreferenciado") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass=" seleccionarprospectogridview  fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="20px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#0084F7" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                  </div>          
          </center>
                </div>
            </div>
            <div class="wrapper">
                <div style="border: 1px #e8e8e8 solid; width: 100%; height: 1148px; float: right; margin: 10px 0px 10px 0px">
                    <div style="border-bottom: 1px #e8e8e8 solid; background-color: #f3f3f3; padding: 8px; font-size: 13px; font-weight: 700; color: #45484d;">
                        CONTROL DE PROSPECTOS
                    </div>
                    <div style="padding: 8px; font-size: 13px;">
                        <h4 style="text-align: left">INFORMACIÓN GENERAL</h4>
                        <input id="txtnumerogeneral" style="margin-left: 1%;" placeholder="DPI" visible="false" runat="server" type="text" tabindex="1" class="inputscortos" autofocus="autofocus" />
                        <input id="txtnumeroderegistro" style="margin-left: 1%;" placeholder="DPI" visible="false" runat="server" type="text" tabindex="1" class="inputscortos" autofocus="autofocus" />

                        <span>Documento DPI:</span>
                        <input id="txtnumerodpi" disabled="disabled" onkeypress="return numeros(event);" style="margin-left: 112px; width:296px; font-size:26px;text-align:center" placeholder="DPI" runat="server" type="text" tabindex="1" class="inputscortos" autofocus="autofocus" />
                        <br />
                        <span>Nombre Completo:</span>
                        <input id="txtnombrecompleto" onkeypress="return soloLetras(event)" style="margin-left: 93px; width:296px; text-align:center" placeholder="Nombre Completo" runat="server" type="text" tabindex="2" class="inputslargos" autofocus="autofocus" />
                        <br />
                        <span>Numero de teléfono:</span>
                        <input id="txttelefono" onkeypress="return numeros(event);" style="margin-left: 83px; width:296px; text-align:center" placeholder="Teléfono" runat="server" type="text" tabindex="3" class="inputscortos" maxlength="8" autofocus="autofocus" />
                        <br />
                        <span>Correo Electrónico:</span>
                        <input id="txtemail" style="margin-left: 93px;width:296px; text-align:center; " placeholder="Correo electrónico" runat="server" type="text" tabindex="4" class="inputslargos" autofocus="autofocus" />
                        <br />
                        <span>Monto:</span>
                        <span style="margin-left: 141px; font-size: 16px">Q</span><input id="txtmonto" style="width:296px; font-size:18px; text-align:center; margin-left:9px" placeholder="Q - Monto" runat="server" type="text" tabindex="5" class="inputscortos" autofocus="autofocus" />
                        <br />
                    </div>
                    <%-- AREA DE INGRESOS --%>
                    <h4 style="text-align: left">ÁREA DE INGRESOS</h4>
                    <span>Ingresos:</span>
                    <span style="margin-left: 2%; font-size: 16px">Q</span><input id="txtingreso" onkeypress="return solonumeros(event);" style="width: 296px; margin-left:109px; text-align:center" placeholder="Q - Ingresos" runat="server" type="text" tabindex="6" class="inputscortos" autofocus="autofocus" />
                    <br />
                    <span>Egresos:</span>
                    <span style="margin-left: 2%; font-size: 16px">Q</span><input id="txtegresos" onkeypress="return solonumeros(event);" style="width: 296px; margin-left:113px; text-align:center" placeholder="Q - Egresos" runat="server" type="text" tabindex="7" class="inputscortos" autofocus="autofocus" />
                    <br />
                    <div style="padding: 2px; font-size: 13px;">
                        <%-- AREA DE EMPLEADOS --%>
                        <h4 style="text-align: left">ÁREA DE EMPLEO</h4>
                        <span>Años laborados</span>
                        <input id="txtañoslaborados" onkeypress="return numeros(event);" style="margin-left: 118px; width: 296px;" placeholder="Años laborados" runat="server" type="text" tabindex="8" class="inputscortos" autofocus="autofocus" />
                        <br />
                        <span>¿Trabaja actualmente?</span>
                        <asp:DropDownList ID="combotienetrabajo" runat="server" Style="margin-left: 75px; width: 296px;" TabIndex="9" CssClass="inputscortos">
                            <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <span>¿En que empresa labora o que actividad realiza?</span>
                        <input id="txttabajoactual" style="margin-left: 6px; width: 212px" placeholder="Trabajo actual" runat="server" type="text" tabindex="10" class="inputscortos" autofocus="autofocus" />
                        <br />
                        <span>¿Cuenta con IGSS?</span>
                        <asp:DropDownList ID="combocuentaigss" runat="server" Style="margin-left: 96px; width: 299px;" TabIndex="11" CssClass="inputscortos">
                            <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </div>
                    <%-- AREA DE SEGUIMIENTOS --%>
                    <h4 style="text-align: left">Área de seguimiento</h4>
                    <span>Tipo de servicio:</span>
                    <asp:DropDownList ID="combotiposervicio" runat="server" OnSelectedIndexChanged="tiposervicio_SelectedIndexChanged" AutoPostBack="true" Style="margin-left: 123px; width: 249px; text-align:center" TabIndex="12" CssClass="inputscortos">
                        <asp:ListItem Text="Tipo de servicio" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>Destino o Finalidad de servicio:</span>
                    <select id="combofinalidaddeservicio" runat="server" style="margin-left: 11px; width: 249px; text-align:center" tabindex="13" class="inputscortos">
                        <option value="0">Seleccione la finalidad del servicio </option>
                    </select>
                    <br />
                    <span>Estado de la llamada:</span>
                    <asp:DropDownList ID="combocontactollamadas" runat="server" Style="margin-left: 82px; width: 249px; text-align:center" TabIndex="14" CssClass="inputscortos">
                        <asp:ListItem Text="Estado de la llamada" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>Primera llamada</span>
                    <input id="txtfechainicio" style="margin-left: 117px; width: 249px; text-align:center" runat="server" type="date" tabindex="15" class="inputscortos" value="2020-04-25" min="1950-01-01" max="2021-12-31" autofocus="autofocus" />
                    <br />
                    <span>Ultima llamada</span>
                    <input id="txtfechafin" style="margin-left: 127px; width: 249px; text-align:center" runat="server" type="date" tabindex="16" class="inputscortos" value="2020-04-25" min="1950-01-01" max="2021-12-31" autofocus="autofocus" />
                    <hr style="border: groove" />
                    <br />
                    <span>Color de semáforo:</span>
                    <asp:DropDownList ID="combosemaforoestado" OnSelectedIndexChanged="seleccionsemaforo_SelectedIndexChanged" AutoPostBack="true" runat="server" Style="margin-left: 96px; width: 250px;" TabIndex="17" CssClass="inputscortos">
                        <asp:ListItem Text="Seleccione el color" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox Style="margin-left: 5%;" Width="30px" Height="30px" ID="txtcolorestado" Enabled="false" runat="server" TabIndex="18"></asp:TextBox>
                    <br />
                    <span>Motivo del estado:</span>
                    <asp:DropDownList ID="combosemaforodescripcion" runat="server" Style="margin-left: 100px; width: 250px; text-align: center;" TabIndex="19" CssClass="inputscortos">
                        <asp:ListItem Text="Motivo del estado" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <hr style="border: groove" />
                    <h4 style="text-align: left">INFORMACIÓN ADCIONAL</h4>
                    <span>Tipo de domicilio:</span>
                    <asp:DropDownList ID="combotipodomicilio" runat="server" Style="margin-left: 112px; width: 250px;" TabIndex="20" CssClass="inputscortos">
                        <asp:ListItem Text="Tipo del domicilio" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>¿Años en domicilio?</span>
                    <input id="txtañodomicilio" onkeypress="return numeros(event);" style="margin-left: 97px; width: 250px;" placeholder="¿Años de residencia?" runat="server" type="text" tabindex="21" class="inputscortos" autofocus="autofocus" />
                    <br />
                    <span>¿Posee cuenta en cooperativa?</span>
                    <asp:DropDownList ID="comboposeecuentacoope" runat="server" Style="margin-left: 14px; width: 250px;" TabIndex="22" CssClass="inputscortos">
                        <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>Sucursal más cercana:</span>
                    <asp:DropDownList ID="combosucursalmascerca" runat="server" Style="margin-left: 77px; width: 250px;" TabIndex="23" CssClass="inputscortos">
                        <asp:ListItem Text="¿Sucursal más cercana?" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Central" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>Contactado por:</span>
                    <input id="txtcontactadopor" style="margin-left: 123px; width: 250px;" placeholder="Contactado Por:" runat="server" type="text" tabindex="24" class="inputscortos" autofocus="autofocus" />
                    <br />
                    <span>DPI de referencia:</span>
                    <input id="txtdpireferencia" maxlength="13" onkeypress="return numeros(event);" style="margin-left: 111px; width: 250px;" placeholder="DPI de referencia" runat="server" type="text" tabindex="25" class="inputscortos" autofocus="autofocus" />
                    <%-- AREA DE COMENTARIOS / DESCRIPCIÓN --%>
                    <div class="form-group" style="float: none">
                        <textarea class="form-control rounded-0" style="margin-left: 28px; width: 95%; text-align:center" placeholder="Descripción" tabindex="26" id="exampleFormControlTextarea1" runat="server" rows="5" maxlength="150"></textarea>
                    </div>
                    <br />
                    <%-- AREA DE BOTONES --%>
                    <center>
   
    <asp:LinkButton ID="LinkButton1" class="btn btn-warning" style=" text-decoration:none; width:45%" value="Crear Alerta" type="button" runat="server" tabindex="28" name="Crear Alerta" title="Crear Alerta" OnClick="Btn_abriralerta_Click" >Crear Alerta</asp:LinkButton>
         <asp:LinkButton ID="LinkButton2" class="btn btn-success" style=" text-decoration:none; width:45%" value="Guardar" type="button" runat="server" tabindex="27" name="Guardar" title="Guardar" OnClick="Btn_Guardarprospecto_Click" >Guardar</asp:LinkButton>
   
   
         </center>

                    <%-- AREA DEL GRIDVIEW --%>
                </div>
            </div>
        </div>
        </div>
        </div>

        <br />
        <br />
        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../../CRM-Script/Script.js" type="text/javascript"></script>
    </form>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script>
        $("#txtmonto").on({
            "focus": function (event) {
                $(event.target).select();
            },
            "keyup": function (event) {
                $(event.target).val(function (index, value) {
                    return value.replace(/\D/g, "")
                        .replace(/([0-9])([0-9]{2})$/, '$1,$2')
                        .replace(/\B(?=(\d{3})+(?!\d)\,?)/g, ",");
                });
            }
        });
        $("#txtingreso").on({
            "focus": function (event) {
                $(event.target).select();
            },
            "keyup": function (event) {
                $(event.target).val(function (index, value) {
                    return value.replace(/\D/g, "")
                        .replace(/([0-9])([0-9]{2})$/, '$1,$2')
                        .replace(/\B(?=(\d{3})+(?!\d)\,?)/g, ",");
                });
            }
        });
        $("#txtegresos").on({
            "focus": function (event) {
                $(event.target).select();
            },
            "keyup": function (event) {
                $(event.target).val(function (index, value) {
                    return value.replace(/\D/g, "")
                        .replace(/([0-9])([0-9]{2})$/, '$1,$2')
                        .replace(/\B(?=(\d{3})+(?!\d)\,?)/g, ",");
                });
            }
        });
    </script>

    <script>
        posicionarMenu();
        $(window).scroll(function () {
            posicionarMenu();
        });

        function posicionarMenu() {
            var altura_del_header = 35;
            var altura_del_menu = $('.menu').outerHeight(true);

            if ($(window).scrollTop() >= altura_del_header) {
                $('.menu').addClass('fixed');
                $('.wrapper').css('margin-top', (altura_del_menu) + 'px');
            } else {
                $('.menu').removeClass('fixed');
                $('.wrapper').css('margin-top', '0');
            }
        }

    </script>
</body>
</html>
