<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_verhallazgos.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_verhallazgos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'/><link rel="stylesheet" href="../../EXDiseños/stylebarra.css"/>
    
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
   <link rel="stylesheet" type="text/css" href="../../EXDiseños/ExtiloExEnvio.css" />
     <link type="text/css" rel="stylesheet" href="../../EXDiseños/estilolector.css" />
          <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" type="text/javascript"></script>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
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
				<a href="javascript:void(0);" onclick="redirigir2()" class="links">
					<span class="span fa fa-suitcase"></span>Expedientes
                    <span class="span fa fa-arrow-down"></span>
				</a>
                <ul class="children">
                    <li class="li">
						<a href="javascript:void(0);" onclick="redirigir4()" class="links" style="padding:10px">Control de Negocios
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
      
        

         <center>
         
         
           <div class="containter" id="val" runat="server" >
         <div class="row">
             <div class="col-md-9">
                
             </div>
           <div class="col-md-2">
                   <span id="nota" runat="server"> Nota: Valide únicamente si ya tiene los documentos correctos</span>
           <div class="form-group"> 

          <br /> 
           
            </div>
               </div>
             </div>

             <div class="row">
        
           <div class="col-md-2">
               
           <div class="form-group"> 
         
          <div visible="false" id="divbtnverificar" runat="server" style=" border: solid white 0.1px; left:0; margin-left:100px; position: absolute; margin-top: 9%;">  <span>Hallazgo: <h5 id="datoshall" runat="server" style="width: 380px; "> datos </h5></span>     <asp:LinkButton  ID="btnlisto" runat="server" OnClick="btnlisto_Click" class="btn btn-primary form-control" type="submit" Width="100%"  Text="Validar" /> 
             
          
          
          </div>
          
           </div>
               </div>
             </div>
               </div>
                 
       </center>
       
        



            <center><h3 id="numeroexp" runat="server" style="width:30%; margin-top: 0px; margin-bottom: 0px;" >Expediente Agencia</h3></center>
        <center><h3 id="procesoesp" runat="server" style="width:30%; margin-top: 0px; margin-bottom: 0px;">proceso especifico en el que se encuentra</h3></center>
         <center><h3 id="nocred" runat="server" style="width:30%; margin-bottom:0; margin-top:0px " >04005878</h3></center>
    
        <br />
 
       

        <div class="container">

  <div class="row">
        <h3 id="encabselec" runat="server">Lista de Hallazgos</h3>

    
    <div class="col-md-12" style="overflow-x: auto; padding-left: 20%" >
      
          <asp:GridView ID="DGVHALL" CssClass="table table-striped" style="width: 400px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid"  AllowPaging="true" PageSize="10" OnPageIndexChanging="DGVHALL_PageIndexChanging" OnSelectedIndexChanged="DGVHALL_SelectedIndexChanged" >
                    <Columns>
                          <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No" Visible="false">
                           <ItemTemplate>
                           <asp:Label ID="lblnumhall"  Width="30px" Text='<%# Eval("codexhall") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No">
                           <ItemTemplate>
                           <asp:Label ID="hall"  Width="30px" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Hallazgos del expediente">
                           <ItemTemplate>
                           <asp:Label ID="lblcif"  Width="480px" Text='<%# Eval("hallazgo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:ButtonField Text="Listo" CommandName="Select" ItemStyle-Width="150" ItemStyle-CssClass="seleccionarregistrogridview">
                            <ItemStyle Width="150px" >  </ItemStyle>

                            </asp:ButtonField>

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>
        
          <asp:GridView ID="DGVHALLVISTA" CssClass="table table-striped" style="width: 400px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid"  AllowPaging="true" PageSize="10" OnPageIndexChanging="DGVHALLVISTA_PageIndexChanging"  >
                    <Columns>
                          <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No" Visible="false">
                           <ItemTemplate>
                           <asp:Label ID="lblnumhall"  Width="30px" Text='<%# Eval("codexhall") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No">
                           <ItemTemplate>
                           <asp:Label ID="hall"  Width="30px" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Hallazgos del expediente">
                           <ItemTemplate>
                           <asp:Label ID="lblcif"  Width="300px" Text='<%# Eval("hallazgo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>
    </div>
   
  </div>

          

</div>
        <br />
          
       
  <asp:LinkButton ID="btninicio" runat="server" OnClick="btnInicio_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnEXGEN_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnNuevo_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="LinkButton5" runat="server" OnClick="btnpendiente" ClientIDMode="Static"></asp:LinkButton>

       <%--<asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnmoduloscrear_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton5" runat="server" OnClick="btnModapp_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton6" runat="server" OnClick="btnmodulospermisos_Clicl" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton7" runat="server" OnClick="btnappuser_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="LinkButton8" runat="server" OnClick="btnestadouser_Click" ClientIDMode="Static"></asp:LinkButton>--%>
         <%-- Javascript --%>

      
       <%-- <input type="text" value="" id="result" runat="server" onchange="cambio(this.value)"  > </input>--%>


        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../EXDiseños/scriptvalidar.js" type="text/javascript"></script>

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
