<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_VistaMensajeria.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_VistaMensajeria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mensajería</title>
 <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.css'><link rel="stylesheet" href="../../EXDiseños/EstilosMensajeria.css">
	    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'/><link rel="stylesheet" href="../../EXDiseños/stylebarra.css"/>
   <link rel="stylesheet" type="text/css" href="../../EXDiseños/ExtiloExEnvio.css" />
     <link type="text/css" rel="stylesheet" href="../../EXDiseños/estilolector.css" />
      <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" type="text/javascript"></script>
        
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" class="form" runat="server">
        
       
        
            <center>   <header class="encabezado">
	<div class="menu-bar">
		<div class="three col">
			<div class="hamburger" id="hamburger-pro">
				<span class="line"></span>
				<span class="line"></span>
				<span class="line"></span>
			</div>
		</div>

		<a href="javascript:void(0);" class="links" class="bt-menu">
			<span class="span fa fa-list"></span>
		</a>
	</div>  

	<nav class="nav">
		<ul class="ul">
			<li class="li">
				<a id="inicio" runat="server" href="javascript:void(0);" onclick="redirigir()" class="links">
					<span class="span fa fa-home"></span>Inicio
				</a>


			</li>

		<li class="li">
				<a href="javascript:void(0);" onclick="redirigir2()" class="links">
					<span class="span fa fa-user"></span>Cerrar Sesion
				</a>
			</li>
		</ul>
	</nav>
</header></center>
        <div class="center">
<div id="form-main">
  <div id="form-div">

      <h3>AGENCIA-MENSAJERÍA</h3>
      <p class="name">
          <span id="span1" runat="server" style="font-size:15px; color:white; " >Número de Lote Recibido : </span>  <asp:TextBox Enabled="false" ID="name" name="name" style="margin-left:73px" onkeypress="return numeros(event);"  runat="server"  Width="20%" > </asp:TextBox><asp:RadioButton ID="RadioButton1" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true" />
 <span id="span3" runat="server" style="font-size:15px; color:white; " >Número de Lote Entregado en Mesa        : </span>  <asp:TextBox Enabled="false" ID="LOTEENTREGA" name="name"  onkeypress="return numeros(event);"  runat="server"  Width="20%" > </asp:TextBox><asp:RadioButton ID="RadioButton2" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="true" />
      
      </p>
        <br />
        <h3>MENSAJERÍA-ARCHIVO</h3>
     <p class="name">

          <span id="span2" runat="server" style="font-size:15px; color:white; " >Número de Lote Salida Recibido     : </span>  <asp:TextBox Enabled="false" ID="LOTEARCHIVO" name="name" style="margin-left:17px;" onkeypress="return numeros(event);"  runat="server"  Width="20%" > </asp:TextBox><asp:RadioButton ID="RadioButton3" runat="server" OnCheckedChanged="RadioButton3_CheckedChanged" AutoPostBack="true" />
            <span id="span4" runat="server" style="font-size:15px; color:white; " >Número de Lote Enviado al Archivo : </span>  <asp:TextBox Enabled="false" ID="txtname" name="name" style="margin-left:-7px;"  onkeypress="return numeros(event);"  runat="server"  Width="20%" > </asp:TextBox><asp:RadioButton ID="RadioButton4" runat="server" OnCheckedChanged="RadioButton4_CheckedChanged" AutoPostBack="true" />
      
      </p>
        
    <br />

     
    
      
      <div class="submit">
        
          <asp:LinkButton Text="Validar Lote" ID="buttoblue" runat="server" OnClick="envio_Click"   > </asp:LinkButton>

        <div class="ease"></div>
      </div>
    
  
  </div>
</div>
            </div>


         <div class="center" >
<div id="form-main2">
  <div id="form-div2" style="margin-top:392px">

      <h3>Código aleatorio</h3>
      <p class="name">
          <center>
         <asp:DropDownList  ID="mensajero" runat="server" CssClass="dis"  Width="150px"   ></asp:DropDownList> </center>
   
      </p>
<h3 id="cod" runat="server" style="text-align:center">  <span style="font-size:15px; color:white;" >Código </span> </h3>
      
    <br />

     
    
      
      <div class="submit"  id="btnvis" runat="server">
      
          <asp:LinkButton  Text="Generar Código" ID="buttoblues" runat="server" OnClick="generar_Click" type="submit"  > </asp:LinkButton>

        <div class="ease"></div>
      </div>
    

  </div>
</div>
            </div>
      
         <script>
             $('#<%=mensajero.ClientID%>').chosen();
         </script>
         <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

          <asp:LinkButton ID="btninicio" runat="server" OnClick="btninicio_click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btncerrar" ClientIDMode="Static"></asp:LinkButton>
    </form>
        <script type="text/javascript">

           function redirigir() {

               document.getElementById('btninicio').click();

           }
           function redirigir2() {

               document.getElementById('LinkButton1').click();

           }
           function redirigir3() {

               document.getElementById('LinkButton3').click();

           }
           function redirigir4() {

               document.getElementById('LinkButton4').click();

           }
           function redirigir5() {

               document.getElementById('LinkButton5').click();

           }
           function redirigir6() {

               document.getElementById('LinkButton6').click();

           }
           function redirigir7() {

               document.getElementById('LinkButton7').click();

           }

        </script>
    <script type="text/javascript" src="../../EXDiseños/scriptvalidar.js" >  </script>
</body>
</html>
