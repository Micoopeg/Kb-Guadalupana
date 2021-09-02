<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Tracking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../../EXDiseños/Trackestilo.css">
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'/><link rel="stylesheet" href="../../EXDiseños/stylebarra.css"/>

   <link rel="stylesheet" type="text/css" href="../../EXDiseños/ExtiloExEnvio.css" />
   
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

      <header class="encabezado">
	<div class="menu-bar">
		<div class="three col">
			<div class="hamburger" id="hamburger-pro">
				<span class="line"></span>
				<span class="line"></span>
				<span class="line"></span>
			</div>
		</div>

		<a href="javascript:void(0);" class="links"  class="bt-menu">
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
				<a href="javascript:void(0);" onclick="redirigir2()"  class="links">
					<span class="span fa fa-suitcase"></span>Control de Negocios
   
				</a>
           
			</li>

			<%--<li class="li ">
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-eye"></span>Expedientes con Hallazgos
					
				</a>

				
			</li>--%>

		<%--	<li class="li">
				<a href="javascript:void(0);" onclick="redirigir4()" class="links">
					<span class="span fa fa-location-arrow"></span>Pendientes de envío
				</a>
			</li>--%>
		<li class="li">
				<a href="javascript:void(0);" onclick="redirigir4()" class="links">
					<span class="span fa fa-user"></span>Cerrar Sesion
				</a>
			</li>
		</ul>
	</nav>
</header>


 

            <center><h3 id="numeroexp" runat="server" >Expediente Agencia</h3></center>
        <center><h3 id="procesoesp" runat="server">proceso especifico en el que se encuentra</h3></center>
         <center><h3 id="nocred" runat="server">04005878</h3></center>
        
        
      <div class='progress' style="position: relative; margin-top: 17%; margin-bottom: -156px">
  <div class='progress_inner'>
    <div class='progress_inner__step'>
  <%--        <label for='step-5' id="fechaagin" style="margin-top: -89px">Ingreso: 24/11/2021</label>--%>
      <label for='step-1' style="color:aqua" >Agencia</label>
 <%--         <label for='step-5' id="fechaag" style="padding-top:10px;">Salida: 24/11/2021</label>--%>
    </div>
    <div class='progress_inner__step'>
         <%-- <label for='step-5' id="fechamensajein" style="margin-top: -89px">Ingreso: 24/11/2021</label>--%>
      <label for='step-2' style="color:aqua">Mensajería</label>
         <%-- <label for='step-5' id="fechamensaje" style="padding-top:10px;">Salida: 24/11/2021</label>--%>
    </div>
    <div class='progress_inner__step'>
<%--          <label for='step-5' id="fechamesain" style="margin-top: -89px">Ingreso: 24/11/2021</label>--%>
      <label for='step-3'style="color:aqua">Mesa de QA</label>
     <%--     <label for='step-5' id="fechamesa" style="padding-top:10px;">Salida: 24/11/2021</label>--%>
    </div>
    <div class='progress_inner__step'>
    <%--     <label for='step-5' id="fechajuring" style="margin-top: -89px">Ingreso: 24/11/2021</label>--%>
      <label for='step-4' style="color:aqua">Juridico/ Mesa </label>
<%--          <label for='step-5' id="fechajur" style="padding-top:10px;">Salida: 24/11/2021</label>--%>
        

    </div>
    <div class='progress_inner__step'>
        <%--  <label for='step-5' id="fecharchin" style="margin-top: -89px">Ingreso: 24/11/2021</label>--%>
      <label for='step-5' style="color:aqua" > Mesa/Archivo</label>
      <%--  <label for='step-5' id="fecharch" style="padding-top:10px; ">Salida: 24/11/2021</label>--%>
    </div>
  
    <input checked='checked' id='step-1' name='step' type='radio'>
    <input id='step-2'  type='radio' disabled ="true">
    <input id='step-3' type='radio'>
    <input id='step-4' type='radio'>
    <input id='step-5'  type='radio'>

    <div id="progress" runat="server" class='progress_inner__bar'></div>
    <div class='progress_inner__bar--set'></div>
  </div>
</div>
<!-- partial -->   <br />   

        <div class="container">

  <div class="row">
      <center> <h3 id="encabselec" runat="server" style="margin-top:10%; margin-bottom: -100px">Registro del Expediente</h3></center>
       
    <div class="col-md-12" style="overflow-x: auto;" >
      <div style=" text-align: -webkit-center; margin-top: 11%;">
          <asp:GridView ID="DGVTRACK" CssClass="table table-striped" style="width: 400px; text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid"  AllowPaging="true" PageSize="10" OnPageIndexChanging="DGVTRACK_PageIndexChanging" >
                    <Columns>
                          <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No">
                           <ItemTemplate>
                           <asp:Label ID="hall"  Width="30px" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Fecha/Hora">
                           <ItemTemplate>
                           <asp:Label ID="lblfecha"  Width="150px" Text='<%# Eval("ex_fechaev") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Estado">
                           <ItemTemplate>
                           <asp:Label ID="lblevento"  Width="80px" Text='<%# Eval("ex_evento") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Etapa Actual">
                           <ItemTemplate>
                           <asp:Label ID="lblactual"  Width="90px" Text='<%# Eval("etapa_actual") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Etapa Siguiente">
                           <ItemTemplate>
                           <asp:Label ID="lblsig"  Width="110px" Text='<%# Eval("etapa_siguiente")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
         

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>
</div>
    </div>
        
  </div>
       

            <br /> <br />

          

                    

</div>

         <asp:LinkButton ID="btninicio" runat="server" OnClick="btnInicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnEXGEN_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnNuevo_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnpendiente" ClientIDMode="Static"></asp:LinkButton>

       <%--<asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnmoduloscrear_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton5" runat="server" OnClick="btnModapp_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton6" runat="server" OnClick="btnmodulospermisos_Clicl" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton7" runat="server" OnClick="btnappuser_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="LinkButton8" runat="server" OnClick="btnestadouser_Click" ClientIDMode="Static"></asp:LinkButton>--%>
 

      




        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../EXDiseños/scriptvalidar.js" type="text/javascript"></script>
		        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script><script  src="../../EXDiseños/scriptbarra.js"></script>
  
  
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
</body>
</html>
