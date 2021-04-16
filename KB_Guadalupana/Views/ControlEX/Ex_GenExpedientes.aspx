﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_GenExpedientes.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_GenExpedientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../../EXDiseños/EstilosGenExp.css" />
    <link rel="stylesheet" href="../../AvDiseños/Botones.css"   />


     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
      <link rel="stylesheet"  href="../../EXDiseños/EstilosDashboard.css" />
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'/><link rel="stylesheet" href="../../EXDiseños/stylebarra.css"/>
    
    <title>Nuevo Expediente</title>
   
    
  
</head>

<body>
   
 
    
    <form id="form1" runat="server" >
<header class="encabezado">
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

			<li class="li submenu">
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-suitcase"></span>Expedientes
                    <span class="span fa fa-arrow-down"></span>
				</a>
                <ul class="children">
                    <li class="li">
						<a href="javascript:void(0);" onclick="redirigir2()" class="links">Expedientes General
							<span class="span fa fa-play"></span>
						</a>
					</li>  
					<li class="li">
						<a href="javascript:void(0);" class="links" onclick="redirigir3()" >Generar nuevo
							<span class="span fa fa-play"></span>
						</a>
					</li>  
					<li class="li">
						<a href="javascript:void(0);" class="links">Enviar Expediente
							<span class="span fa fa-play"></span>
						</a>
					</li>  
					
				</ul>
			</li>

			<li class="li">
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-eye"></span>Expedientes con Hallazgos
					
				</a>

				
			</li>

			<li class="li">
				<a href="javascript:void(0);" class="links" onclick="redirigir5()" >
					<span class="span fa fa-location-arrow"></span>Pendientes de envío
				</a>
			</li>
		<li class="li">
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-user"></span>Cerrar Sesion
				</a>
			</li>
		</ul>
	</nav>
</header>
        <br/><br /> <br />
     <div class="container justify-content-center aling-items-center minh-100" style="max-width: 850px;">

         


            <div class="form-group" style="text-align: center">
           
                <label for="exampleInputEmail1">
                    <h1>Nuevo expediente</h1>
                </label>
                <input id="NOEXP" type="text" runat="server" disabled="disabled" class="form-control form-control-lg"  aria-describedby="emailHelp" placeholder="Numero del expediente" style="text-align: center;"/>
            </div>
            <div class="form-group">
                     
                       <h1>Información General</h1>

                <div class="row">
                    <div class="col">

                        <input id="PNOMBRE" type="text" runat="server" class="form-control form-control-lg" placeholder="Primer Nombre" required />
                        <input id="PAPELL" type="text" runat="server" class="form-control form-control-lg" placeholder="Primer Apellido" required />
                      <h5 style="text-align:end; margin-top:15px;" >CIF</h5>
                    </div>
                     <div class="col">
                          <input id="SNOMBRE" type="text" runat="server" class="form-control form-control-lg" placeholder="Segundo Nombre" required />
                
                        <input id="SAPELL" type="text" runat="server" class="form-control form-control-lg" placeholder="Segundo Apellido" required />
                          <input id="CIFN" runat="server" class="form-control form-control-lg"  maxlength="6" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" type="number" min="0" required />
                    </div>
               

                 
                </div>

            </div>
            <div class="form-group">
            
                <div class="row">
                    <div class="col">
                         <h5>Tipo de credito</h5>
                         <asp:DropDownList  id="DropDownTipocredito" runat="server"   CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="tipoex"  ></asp:DropDownList>
                         <h5>Monto</h5>
                        <span class="input-group-text" id="basic-addon1">GTQ</span>
                        <input id="MONTO" runat="server" class="form-control form-control-lg"  maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" type="number" min="0" required />
                    </div>
                    <div class="col">
                        
                        <h5>Numero de credito</h5>
                        <input id="NCRED" runat="server" class="form-control form-control-lg"  maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" type="number" min="0" required />
                      
                       
                     
                        </div>
                </div>
            </div>
      


            <div class="form-group" style="text-align: center">
                <label for="exampleFormControlTextarea1">
                    <h1>Comentario</h1>
                </label>
                <textarea id="DESCRIP" runat="server" class="form-control form-control-lg"  rows="4" maxlength="250"></textarea>
            </div>
            <center>
            <div class="container">

              <asp:Button ID="btninsert" runat="server" Cssclass="custom-btn btn-8" OnClick="btngenerar_Click" Text="Generar" />
                
            


            </div>
          </center>




        </div>
        

         <asp:LinkButton ID="btninicio" runat="server" OnClick="btnInicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnEXGEN_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnNuevo_Click" ClientIDMode="Static"></asp:LinkButton>
      
         <%--<asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnmoduloscrear_Click" ClientIDMode="Static"></asp:LinkButton>--%>
           <asp:LinkButton ID="LinkButton5" runat="server" OnClick="btnPendientes_Click" ClientIDMode="Static"></asp:LinkButton>
        <%-- <asp:LinkButton ID="LinkButton6" runat="server" OnClick="btnmodulospermisos_Clicl" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton7" runat="server" OnClick="btnappuser_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="LinkButton8" runat="server" OnClick="btnestadouser_Click" ClientIDMode="Static"></asp:LinkButton>--%>
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
