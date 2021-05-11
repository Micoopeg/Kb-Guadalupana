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
       <span>DPI de la persona que esta referenciando:</span>
       <input id="txtdpidereferido" style="margin-left:1%;" placeholder="DPI DE REFERIDO" visible="true" runat="server" type="text" tabindex="1" onkeypress="return numeros(event);" maxlength="13" class="inputscortos"  autofocus="autofocus" />
       <span>DPI del nuevo cliente:</span>
      <input id="txtnumerodpi" onkeypress="return numeros(event);" style="margin-left:1%;" placeholder="DPI" runat="server" type="text" tabindex="2" maxlength="13" class="inputscortos"  autofocus="autofocus" />
      <span>Nombre completo:</span>
      <input id="txtnombrecompleto" onkeypress="return soloLetras(event)" style="margin-left:1%; width:250px" placeholder="Nombre Completo" runat="server" type="text" tabindex="3" class="inputslargos"  autofocus="autofocus"/>
      <br />
                    <span>Teléfono:</span>
      <input id="txttelefono"  onkeypress="return numeros(event);" style="margin-left:1%;" placeholder="Teléfono" maxlength="8" runat="server" type="text" tabindex="4" class="inputscortos"  autofocus="autofocus"/>
      <span>Corre electrónico:</span>
                    <input id="txtemail" style="margin-left:1%;" placeholder="Correo electrónico" runat="server" type="text" tabindex="5" class="inputslargos"  autofocus="autofocus"/>
                    <br />
                    <center>
     <%-- AREA DE COMENTARIOS / DESCRIPCIÓN --%>
          <span>Comentarios:</span>
<div class="form-group" style="float:initial">
  <textarea class="form-control rounded-0" maxlength="500" style="width:95%; margin-left:28px; text-align:center;" placeholder="Comentarios" tabindex="24" id="exampleFormControlTextarea1" runat="server" rows="5"></textarea>
</div>
     <br />
     <%-- AREA DE BOTONES --%> 
     <center>
   
    
    <asp:LinkButton ID="LinkButton2" class="btn btn-success" style=" text-decoration:none; width:95%" value="Guardar" type="button" runat="server" tabindex="25" name="Guardar" title="Guardar" OnClick="LinkButton2_Click" >Guardar</asp:LinkButton>
   
   
         </center>
                        </center>
                    <%-- AREA DEL GRIDVIEW --%>      
      </div>                
      </div>
            </div>
    </form>
    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../../CRM-Script/Script.js" type="text/javascript"></script>
</body>
</html>
