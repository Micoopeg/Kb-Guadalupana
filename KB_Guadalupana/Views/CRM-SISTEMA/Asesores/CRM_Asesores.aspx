<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Asesores.aspx.cs" ValidateRequest="false" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Asesores.CRM_Asesores" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CRM - GUADALUPANA</title>
    <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css'/>
    <link rel="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
	 <link rel="stylesheet" href="../../../CRM-Estilos/Estilos.css" type="text/css" />

    <style type="text/css">
        .img-fluid {
            height: 107px;
            width: 124px;
        }
        .chart1 {}
        .chart1 {}
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <header style="background-color:#005363; margin-top:10px" >           
        </header>
         <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer ID="Timer1" runat="server" Interval="3000"></asp:Timer>
        <!-- partial:index.partial.html -->
        <div id="responsive-admin-menu">
            <div id="responsive-menu">
                <div class="menuicon">≡</div>
            </div>
            <center>
			<div id="logo">
				<a href="../MenuPrincipal/CRM_MenuPrincipal.aspx"><img src="../../../Imagenes/logo.jpeg" class="img-fluid" style="width: auto;border-radius:49px;height: 100px;position: absolute;left: 44px;" alt="Responsive image" /></a>
    </div>
	</center>
            <!--Menu-->
         
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
          
            <ContentTemplate>    
                   <div id="menu">
                <a href="CRM_Alertas.aspx" title="Alertas"><i class="icon-bullhorn"></i><span>Alertas ( <asp:Label ID="Label2" runat="server" Text="1" ForeColor="White"></asp:Label> )</span></a>           
                <a href="CRM_Prospectosfinalizados.aspx" title="Asociadosfinalizados"><i class="icon-file-alt"></i><span>Prospectos Finalizados</span></a>
                <a href="CRM_Crearreferido.aspx" title="Crearasociadoreferido"><i class="icon-book"></i><span>Crear Referido</span></a>
          <%-- <a href="" title="cerarsesion"><i class="icon-signout"></i><span>  
			Cerrar Sesión</span></a>--%>
                   </div>
                </ContentTemplate>
                      <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
                
          
           
           
            <!--Menu-->
               
        </div>

        <div id="content-wrapper">
            <div style="border: 1px #e8e8e8 solid; width: 49%; float: left; margin: 10px 0px 10px 0px">
                <div style="border-bottom: 1px #e8e8e8 solid; background-color: #f3f3f3; padding: 8px; font-size: 13px; font-weight: 700; color: #45484d;">
                    ESTATUS DE CLIENTES
                    </div>
                <div style="padding: 2px; font-size: 13px;">
                     <center>
                          <asp:Chart  ID="Chart1" runat="server" canresize="true"  Palette="None" AlternateText="El grafico no se puede carga por la conexion a internet" BorderlineColor="Black" PaletteCustomColors="Yellow; 255, 128, 0; 192, 0, 0; 0, 192, 0" Width="280px">  
            <series>  
                <asp:Series Name="Series1" ChartType="Pie" Legend="Legend1" LabelBackColor="White" >  
                </asp:Series>   
                <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Series2" ChartType="Pie">
                </asp:Series>
            </series>    
            <chartareas>  
                <asp:ChartArea Name="ChartArea1">  
                </asp:ChartArea>  
            </chartareas>  
                              <Legends>
                                  <asp:Legend Name="Legend1">
                                  </asp:Legend>
                              </Legends>
                              <BorderSkin BackColor="Transparent" />
        </asp:Chart>              
                        </center>
                    </div>
                </div>

            <div style="border: 1px #e8e8e8 solid; width: 49%; float: right; margin: 10px 0px 10px 0px">
                <div style="border-bottom: 1px #e8e8e8 solid; background-color: #f3f3f3; padding: 8px; font-size: 13px; font-weight: 700; color: #45484d;">
                    ESTATUS DE ALERTAS
                </div>
                <div style="padding: 2px; font-size: 13px; height:300px">
                    <br />
                    <br />
                      <br />
                      <br />
                                        <center>
                          <asp:Chart Height="280px" ID="Chart2" runat="server" canresize="true"  Palette="None" AlternateText="El grafico no se puede carga por la conexion a internet" BorderlineColor="Black" PaletteCustomColors="Green">  
            <series>  
                <asp:Series Name="Series1" Legend="Legend1" IsVisibleInLegend="False" >  
                </asp:Series>   
                <asp:Series ChartArea="ChartArea2" Name="Series2" IsVisibleInLegend="False">
                </asp:Series>
            </series>    
            <chartareas>  
                <asp:ChartArea Name="ChartArea2" ShadowColor="White">  
                    <AxisY LineColor="OliveDrab">
                        <MajorGrid LineColor="Transparent" LineDashStyle="NotSet" />
                        <MinorGrid LineColor="Transparent" />
                        <MajorTickMark LineColor="SeaGreen" />
                    </AxisY>
                    <AxisX LineColor="OliveDrab">
                        <MajorGrid LineColor="Maroon" LineDashStyle="NotSet" />
                        <MinorGrid LineColor="Transparent" />
                        <MajorTickMark LineColor="SeaGreen" />
                        <LabelStyle ForeColor="Green" />
                    </AxisX>
                    <AxisX2>
                        <MajorGrid LineColor="Transparent" />
                        <MinorGrid LineColor="Transparent" />
                    </AxisX2>
                    <AxisY2>
                        <MajorGrid LineColor="Transparent" />
                        <MinorGrid LineColor="Transparent" />
                    </AxisY2>
                </asp:ChartArea>  
            </chartareas>  
                              <BorderSkin BackColor="Transparent" BackImageTransparentColor="White" BackSecondaryColor="Transparent" PageColor="Black" />
        </asp:Chart>              
                        </center>
               </div>
            </div>

            <br />
            <br />

            <div style="border: 1px #e8e8e8 solid; width: 100%; height:906px; float: right; margin: 10px 0px 10px 0px">
                <div style="border-bottom: 1px #e8e8e8 solid; background-color: #f3f3f3; padding: 8px; font-size: 13px; font-weight: 700; color: #45484d;">
                    CONTROL DE PROSPECTOS
                </div>
                <div style="padding: 8px; font-size: 13px;">
        <h4 style="text-align:center">INFORMACIÓN GENERAL</h4>
       <input id="txtnumerogeneral" style="margin-left:1%;" placeholder="DPI" visible="false" runat="server" type="text" tabindex="1" class="inputscortos"  autofocus="autofocus" />
       <input id="txtnumeroderegistro" style="margin-left:1%;" placeholder="DPI" visible="false" runat="server" type="text" tabindex="1" class="inputscortos"   autofocus="autofocus" />
      <input id="txtnumerodpi" disabled="disabled" onkeypress="return numeros(event);" style="margin-left:1%;" placeholder="DPI" runat="server" type="text" tabindex="1" class="inputscortos"  autofocus="autofocus" />

      <input id="txtnombrecompleto" onkeypress="return soloLetras(event)" style="margin-left:2%;" placeholder="Nombre Completo" runat="server" type="text" tabindex="2" class="inputslargos"   autofocus="autofocus"/>
      <input id="txttelefono"  onkeypress="return numeros(event);" style="margin-left:2%;" placeholder="Teléfono" runat="server" type="text" tabindex="3" class="inputscortos" maxlength="8"   autofocus="autofocus"/>
     <input id="txtemail" style="margin-left:2%;" placeholder="Correo electrónico" runat="server" type="text" tabindex="4" class="inputslargos"   autofocus="autofocus"/>
     <div style="border: 1px #e8e8e8 solid; width: 30%; float: left; margin: 10px 0px 10px 0px">
         <%-- AREA DE INGRESOS --%>           
         <h4 style="text-align:center" >ÁREA DE INGRESOS</h4>
    <input id="txtingreso" onkeypress="return solonumeros(event);" style="margin-left:3%; width:40%" placeholder="Q - Ingresos" runat="server" type="text" tabindex="5" class="inputscortos"   autofocus="autofocus"/>
     <input id="txtegresos" onkeypress="return solonumeros(event);" style="margin-left:3%; width:40%" placeholder="Q - Egresos" runat="server" type="text" tabindex="6" class="inputscortos"   autofocus="autofocus"/>
     </div>
   <div style="border: 1px #e8e8e8 solid; width: 68%; float: right; margin: 10px 0px 10px 0px">
       <%-- AREA DE EMPLEADOS --%>
     <h4 style="text-align:center" >ÁREA DE EMPLEO</h4>
    <input id="txtañoslaborados" onkeypress="return numeros(event);" style="margin-left:9%; width:18%; " placeholder="Años laborados" runat="server" type="text" tabindex="7" class="inputscortos"   autofocus="autofocus"/>
       <asp:DropDownList ID="combotienetrabajo" runat="server" style="margin-left:1%; width:24%;" TabIndex="8" CssClass="inputscortos">
            <asp:ListItem Text="¿Trabaja actualmente?" Value="0"></asp:ListItem>  
             <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="2"></asp:ListItem>
       </asp:DropDownList>
       <input id="txttabajoactual" style="margin-left:1%; width:33%" placeholder="Trabajo actual" runat="server" type="text" tabindex="9" class="inputscortos"   autofocus="autofocus"/>
     </div>
 <div id="divareaseguimiento" runat="server" style="border: 1px #e8e8e8 solid; width: 100%; margin: 10px 0px 10px 0px">
<%-- AREA DE SEGUIMIENTOS --%>
     <h4 style="text-align:left" >Área de segumiento</h4>
     <asp:DropDownList ID="combotiposervicio" runat="server" OnSelectedIndexChanged="tiposervicio_SelectedIndexChanged" AutoPostBack="true"  style="margin-left:1%; width:12%;" TabIndex="10" CssClass="inputscortos">
      <asp:ListItem Text="Tipo de servicio" Value="0"></asp:ListItem>  
         </asp:DropDownList>
      <input id="txtmonto" onkeypress="return solonumeros(event);" style="margin-left:1%; width:8%; " placeholder="Q - Monto" runat="server" type="text" tabindex="11" class="inputscortos"   autofocus="autofocus"/>
            <select id="combofinalidaddeservicio" runat="server" style="margin-left:1%; width:24%;" class="inputscortos">
            <option value="0">Seleccione la finalidad del servicio </option>
           </select> 
           <asp:DropDownList ID="combocontactollamadas" runat="server" style="margin-left:1%; width:18%;" TabIndex="12" CssClass="inputscortos">
      <asp:ListItem Text="Estado de la llamada" Value="0"></asp:ListItem>  
               </asp:DropDownList>
      <input id="txtfechainicio" style="margin-left:2%; width:13%; " runat="server" type="date" tabindex="13" class="inputscortos" value="2020-04-25" min="1950-01-01" max="2021-12-31"  autofocus="autofocus"/>
    <input id="txtfechafin" style="margin-left:2%; width:13%; " runat="server" type="date" tabindex="14" class="inputscortos" value="2020-04-25" min="1950-01-01" max="2021-12-31"   autofocus="autofocus"/>
   <hr style="border:groove" />   
     <asp:DropDownList ID="combosemaforoestado" OnSelectedIndexChanged="seleccionsemaforo_SelectedIndexChanged" AutoPostBack="true" runat="server" style="margin-left:21%; width:15%;" TabIndex="15" CssClass="inputscortos">
         <asp:ListItem Text="Seleccione el color" Value="0"></asp:ListItem>  
         </asp:DropDownList>
     <asp:TextBox style="margin-left:2%;"  Width="30px" Height="30px" ID="txtcolorestado" Enabled="false" runat="server" TabIndex="16"></asp:TextBox>
       <asp:DropDownList ID="combosemaforodescripcion" runat="server" style="margin-left:10%; width:21%; text-align:center;" TabIndex="17" CssClass="inputscortos">
     <asp:ListItem Text="Motivo del estado" Value="0"></asp:ListItem>  
           </asp:DropDownList>
   
      <hr style="border:groove" />   
     
       <h4 style="text-align:center" >INFORMACIÓN ADCIONAL</h4>
         <asp:DropDownList ID="combocuentaigss" runat="server" style="margin-left:2%; width:14%;" TabIndex="18" CssClass="inputscortos">
       <asp:ListItem Text="¿Cuenta con IGSS?" Value="0"></asp:ListItem>  
             <asp:ListItem Text="Si" Value="1"></asp:ListItem>  
             <asp:ListItem Text="No" Value="2"></asp:ListItem>  
         </asp:DropDownList>
       <asp:DropDownList ID="combotipodomicilio" runat="server" style="margin-left:2%; width:15%;" TabIndex="19" CssClass="inputscortos">
       <asp:ListItem Text="Tipo del domicilio" Value="0"></asp:ListItem> 
       </asp:DropDownList>
      <input id="txtañodomicilio" onkeypress="return numeros(event);" style="margin-left:1%;" placeholder="¿Años de residencia?" runat="server" type="text" tabindex="20" class="inputscortos"   autofocus="autofocus"/>
      <asp:DropDownList ID="comboposeecuentacoope" runat="server" style="margin-left:2%; width:20%;" TabIndex="21" CssClass="inputscortos">
      <asp:ListItem Text="¿Posee cuenta en cooperativa?" Value="0"></asp:ListItem>
          <asp:ListItem Text="Si" Value="1"></asp:ListItem>
          <asp:ListItem Text="No" Value="2"></asp:ListItem>
      </asp:DropDownList> 
     <asp:DropDownList ID="combosucursalmascerca" runat="server" style="margin-left:2%; width:22%;" TabIndex="22" CssClass="inputscortos">
      <asp:ListItem Text="¿Sucursal más cercana?" Value="0"></asp:ListItem>
         <asp:ListItem Text="Central" Value="1"></asp:ListItem>

     </asp:DropDownList>
     <center> 
         <input id="txtcontactadopor"  style="margin-left:1%;" placeholder="Contactado Por:" runat="server" type="text" tabindex="18" class="inputscortos"   autofocus="autofocus" />
       <input id="txtdpireferencia" onkeypress="return numeros(event);" style="margin-left:1%;" placeholder="Dpi de referencia" runat="server" type="text" tabindex="19" class="inputscortos"   autofocus="autofocus" />
         </center>
     <%-- AREA DE COMENTARIOS / DESCRIPCIÓN --%>
<div class="form-group" style="float:none">
  <textarea class="form-control rounded-0" style="width:95%; margin-left:28px; text-align:center;" placeholder="Descripción" tabindex="23" id="exampleFormControlTextarea1" runat="server" rows="5"></textarea>
</div>
     <br />
     <%-- AREA DE BOTONES --%> 
     <center>
   
    <asp:LinkButton ID="LinkButton1" class="btn btn-warning" style=" text-decoration:none; width:45%" value="Crear Alerta" type="button" runat="server" tabindex="24" name="Crear Alerta" title="Crear Alerta" OnClick="Btn_abriralerta_Click" >Crear Alerta</asp:LinkButton>
         <asp:LinkButton ID="LinkButton2" class="btn btn-success" style=" text-decoration:none; width:45%" value="Guardar" type="button" runat="server" tabindex="25" name="Guardar" title="Guardar" OnClick="Btn_Guardarprospecto_Click" >Guardar</asp:LinkButton>
   
   
         </center>

                    <%-- AREA DEL GRIDVIEW --%>      
 
                </div>   
                    </div>
<center>
            
                 <h4>Prospectos pendientes</h4>
                  <%-- GRIDVIEW Inversiones--%>
               <div id="divGridprospecto" style="overflow: auto; height: 100px" runat="server">
                 <asp:GridView ID="gridviewprospectos" CssClass="mGrid"  runat="server" HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedprospectos" BorderStyle="Solid" Width="82%" >
                     <Columns>
                         <asp:TemplateField HeaderText="Numero" Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblcodigo" Text='<%# Eval("codcrminfoprospecto") %>' runat="server" />
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
                              <asp:TemplateField HeaderText="Ultima llamada"  Visible="false">
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
                          <asp:TemplateField HeaderText="Descripcion"  Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lbldescripcion" Text='<%# Eval("crminfo_prospectosucursalcerca") %>' runat="server" />
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
        <!-- partial -->
        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../../CRM-Script/Script.js" type="text/javascript"></script>
    </form>
</body>
</html>
