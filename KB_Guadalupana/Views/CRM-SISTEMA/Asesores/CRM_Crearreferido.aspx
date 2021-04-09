<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Crearreferido.aspx.cs" Inherits="CRM_Guadalupana.Views.CRM_SISTEMA.Asesores.CRM_Crearreferido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="margin-top:0px">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRM - CREAR REFERIDO</title>
        <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg"/>
       <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css'/>
    <link rel="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
          <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
	 <link rel="stylesheet" href="../../../CRM-Estilos/Estilos.css" type="text/css" />
</head>
<body style="margin-top:0px">
    <form id="form1" runat="server">
                <header style="background-color:#69a43c">
  <div class="row">
    <div class="col-sm-4" >
        <asp:LinkButton ID="LinkButton1" class="btn btn-success" style=" background-color:#003561; border-radius:0px; border-color:#003561; text-decoration:none; width:100%" value="Regresar" type="button" runat="server" tabindex="25" name="Guardar" title="Guardar" OnClick="btnmenuprincipal_Click" >Regresar</asp:LinkButton>
    </div>
    <div class="col-sm-4">
        <center>
                  
        </center>
    </div>
          <div class="col-sm-4">
        <center>
                  
        </center>
    </div>
  </div>
        </header>

        <div id="content-wrapper" style="margin-left:0px; margin-top:0px">
            <div style="border: 1px #e8e8e8 solid; width: 100%; float: right; margin: 10px 0px 10px 0px">
                <div style="border-bottom: 1px #e8e8e8 solid; background-color: #f3f3f3; padding: 8px; font-size: 13px; font-weight: 700; color: #45484d;">
                    CONTROL DE PROSPECTOS
                </div>
                <div style="padding: 8px; font-size: 13px;">
        <h4 style="text-align:center">INFORMACIÓN GENERAL</h4>       
       <input id="txtdpidereferido" style="margin-left:1%;" placeholder="DPI DE REFERIDO" visible="true" runat="server" type="text" tabindex="1" onkeypress="return numeros(event);" maxlength="13" class="inputscortos"  autofocus="autofocus" />
      <input id="txtnumerodpi" onkeypress="return numeros(event);" style="margin-left:1%;" placeholder="DPI" runat="server" type="text" tabindex="2" maxlength="13" class="inputscortos"  autofocus="autofocus" />
      <input id="txtnombrecompleto" onkeypress="return soloLetras(event)" style="margin-left:2%;" placeholder="Nombre Completo" runat="server" type="text" tabindex="3" class="inputslargos"  autofocus="autofocus"/>
      <input id="txttelefono"  onkeypress="return numeros(event);" style="margin-left:2%;" placeholder="Teléfono" runat="server" type="text" tabindex="4" class="inputscortos"  autofocus="autofocus"/>
     <input id="txtemail" style="margin-left:2%;" placeholder="Correo electrónico" runat="server" type="text" tabindex="5" class="inputslargos"  autofocus="autofocus"/>
     <div style="border: 1px #e8e8e8 solid; width: 30%; float: left; margin: 10px 0px 10px 0px">
         <%-- AREA DE INGRESOS --%>           
         <h4 style="text-align:center" >ÁREA DE INGRESOS</h4>
    <input id="txtingreso" onkeypress="return solonumeros(event);" style="margin-left:3%; width:40%" placeholder="Q - Ingresos" runat="server" type="text" tabindex="6" class="inputscortos"  autofocus="autofocus"/>
     <input id="txtegresos" onkeypress="return solonumeros(event);" style="margin-left:3%; width:40%" placeholder="Q - Egresos" runat="server" type="text" tabindex="7" class="inputscortos"  autofocus="autofocus"/>
     </div>
   <div style="border: 1px #e8e8e8 solid; width: 68%; float: right; margin: 10px 0px 10px 0px">
       <%-- AREA DE EMPLEADOS --%>
     <h4 style="text-align:center" >ÁREA DE EMPLEO</h4>
    <input id="txtañoslaborados" onkeypress="return numeros(event);" style="margin-left:9%; width:18%; " placeholder="Años laborados" runat="server" type="text" tabindex="8" class="inputscortos"  autofocus="autofocus"/>
       <asp:DropDownList ID="combotienetrabajo" runat="server" style="margin-left:1%; width:24%;" TabIndex="9" CssClass="inputscortos">
            <asp:ListItem Text="¿Trabaja actualmente?" Value="0"></asp:ListItem>  
             <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="2"></asp:ListItem>
       </asp:DropDownList>
       <input id="txttabajoactual" style="margin-left:1%; width:33%" placeholder="Trabajo actual" runat="server" type="text" tabindex="10" class="inputscortos"  autofocus="autofocus"/>
     </div>
 <div id="divareaseguimiento" runat="server" style="border: 1px #e8e8e8 solid; width: 100%; margin: 10px 0px 10px 0px">
<%-- AREA DE SEGUIMIENTOS --%>
     <h4 style="text-align:left" >Área de segumiento</h4>
     <asp:DropDownList ID="combotiposervicio" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="tiposervicio_SelectedIndexChanged"  style="margin-left:1%; width:12%;" TabIndex="11" CssClass="inputscortos">
      <asp:ListItem Text="Tipo de servicio" Value="0"></asp:ListItem>  
         </asp:DropDownList>
      <input id="txtmonto" onkeypress="return solonumeros(event);" style="margin-left:1%; width:8%; " placeholder="Q - Monto" runat="server" type="text" tabindex="12" class="inputscortos"  autofocus="autofocus"/>
            <select id="combofinalidaddeservicio" runat="server" style="margin-left:1%; width:24%;"  class="inputscortos">
            <option value="0">Seleccione la finalidad del servicio </option>
           </select> 
           <asp:DropDownList ID="combocontactollamadas" runat="server" style="margin-left:1%; width:18%;" TabIndex="13" CssClass="inputscortos">
      <asp:ListItem Text="Estado de la llamada" Value="0"></asp:ListItem>  
               </asp:DropDownList>
      <input id="txtfechainicio" style="margin-left:2%; width:13%; " runat="server" type="date" tabindex="14" class="inputscortos" value="2020-04-25" min="1950-01-01" max="2021-12-31"  autofocus="autofocus"/>
    <input id="txtfechafin" style="margin-left:2%; width:13%; " runat="server" type="date" tabindex="15" class="inputscortos" value="2020-04-25" min="1950-01-01" max="2021-12-31"  autofocus="autofocus"/>
   <hr style="border:groove" />   
     <asp:DropDownList ID="combosemaforoestado" OnSelectedIndexChanged="seleccionsemaforo_SelectedIndexChanged" AutoPostBack="true" runat="server" style="margin-left:21%; width:15%;" TabIndex="16" CssClass="inputscortos">
         <asp:ListItem Text="Seleccione el color" Value="0"></asp:ListItem>  
         </asp:DropDownList>
     <asp:TextBox style="margin-left:2%;"  Width="30px" Height="30px" ID="txtcolorestado" Enabled="false" runat="server" TabIndex="17"></asp:TextBox>
       <asp:DropDownList ID="combosemaforodescripcion" runat="server" style="margin-left:10%; width:21%; text-align:center;" TabIndex="18" CssClass="inputscortos">
     <asp:ListItem Text="Motivo del estado" Value="0"></asp:ListItem>  
           </asp:DropDownList>
      <hr style="border:groove" />   
     
       <h4 style="text-align:center" >INFORMACIÓN ADCIONAL</h4>
         <asp:DropDownList ID="combocuentaigss" runat="server" style="margin-left:2%; width:14%;" TabIndex="19" CssClass="inputscortos">
       <asp:ListItem Text="¿Cuenta con IGSS?" Value="0"></asp:ListItem>  
             <asp:ListItem Text="Si" Value="1"></asp:ListItem>  
             <asp:ListItem Text="No" Value="2"></asp:ListItem>  
         </asp:DropDownList>
       <asp:DropDownList ID="combotipodomicilio" runat="server" style="margin-left:2%; width:15%;" TabIndex="20" CssClass="inputscortos">
       <asp:ListItem Text="Tipo del domicilio" Value="0"></asp:ListItem> 
       </asp:DropDownList>
      <input id="txtañodomicilio" onkeypress="return numeros(event);" style="margin-left:1%;" placeholder="¿Años de residencia?" runat="server" type="text" tabindex="21" class="inputscortos" autofocus="autofocus"/>
      <asp:DropDownList ID="comboposeecuentacoope" runat="server" style="margin-left:2%; width:20%;" TabIndex="22" CssClass="inputscortos">
      <asp:ListItem Text="¿Posee cuenta en cooperativa?" Value="0"></asp:ListItem>
          <asp:ListItem Text="Si" Value="1"></asp:ListItem>
          <asp:ListItem Text="No" Value="2"></asp:ListItem>
      </asp:DropDownList> 
     <asp:DropDownList ID="combosucursalmascerca" runat="server" style="margin-left:2%; width:22%;" TabIndex="23" CssClass="inputscortos">
      <asp:ListItem Text="¿Sucursal más cercana?" Value="0"></asp:ListItem>
         <asp:ListItem Text="Central" Value="1"></asp:ListItem>         
     </asp:DropDownList>
     <%-- AREA DE COMENTARIOS / DESCRIPCIÓN --%>
<div class="form-group" style="float:initial">
  <textarea class="form-control rounded-0" style="width:95%; margin-left:28px; text-align:center;" placeholder="Descripción" tabindex="24" id="exampleFormControlTextarea1" runat="server" rows="5"></textarea>
</div>
     <br />
     <%-- AREA DE BOTONES --%> 
     <center>
   
    
    <asp:LinkButton ID="LinkButton2" class="btn btn-success" style=" text-decoration:none; width:95%" value="Guardar" type="button" runat="server" tabindex="25" name="Guardar" title="Guardar" OnClick="LinkButton2_Click" >Guardar</asp:LinkButton>
   
   
         </center>
</div>
                    <%-- AREA DEL GRIDVIEW --%>      
      </div>                
      </div>
            </div>
    </form>
</body>
</html>
