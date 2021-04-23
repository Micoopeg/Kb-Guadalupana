<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_pendienteAg.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_pendienteAg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <%-- <link rel="stylesheet" href="../../EXDiseños/EstiloTablas.css" />--%>
        <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'/><link rel="stylesheet" href="../../EXDiseños/stylebarra.css"/>
    
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
   <link rel="stylesheet" type="text/css" href="../../EXDiseños/ExtiloExEnvio.css" />
     <link type="text/css" rel="stylesheet" href="../../EXDiseños/estilolector.css" />
      

    <title>Pendientes de envío</title>
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
				<a href="javascript:void(0);" class="links">
					<span class="span fa fa-suitcase"></span>Expedientes
                    <span class="span fa fa-arrow-down"></span>
				</a>
                <ul class="children">
                    <li class="li">
						<a href="javascript:void(0);" onclick="redirigir2()" class="links" style="padding:10px">Expedientes General
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
         
         
           <div >
         <div class="row">
             <div class="col-md-9">
                  <center>

             <h3 style=" margin-left: 30%; margin-right: 30%;">Pendiente de envío</h3>
         </center>
             </div>
           <div class="col-md-2">

           <div class="form-group"> 

           <span id="span" runat="server" style="font-size:15px">Cod Mensajero: </span> <input id="txtcodigo" onkeypress="return numeros(event);"  runat="server" class="form-control" type="text" name="codigo" placeholder="Codigo Mensajero" required="required" tabindex="1" autofocus="autofocus"  />        
           
           </div>
               </div>
             </div>

             <div class="row">
           <div class="col-md-9"></div>
           <div class="col-md-2">
           <div class="form-group"> 
               <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btnorden_Click" class="btn btn-primary form-control" type="submit" Width="100%"  Text="Generar Orden" /> </asp:LinkButton>
          
           </div>
               </div>
             </div>
               </div>
                 
       </center>
       
        



    
        <br />
 
       

        <div class="container">

  <div class="row">
        <h3>Selección de Expedientes</h3>
    <div class="col-md-12" style="overflow-x: auto;" >
      
          <asp:GridView ID="DGRVWPEN" CssClass="table table-striped" style="width: 400px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid" OnSelectedIndexChanged="DGRVWPEN_SelectedIndexChanged" AllowPaging="true" PageSize="5" OnPageIndexChanging="DGRVWPEN_PageIndexChanging" >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Fecha/Hora Desembolso">
                           <ItemTemplate>
                           <asp:Label ID="lblfecha"  Width="150px" Text='<%# Eval("gen_fechaprestamo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="CIF">
                           <ItemTemplate>
                           <asp:Label ID="lblcif"  Width="80px" Text='<%# Eval("cifgeneral") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No. Prestamo">
                           <ItemTemplate>
                           <asp:Label ID="lblnumcred"  Width="90px" Text='<%# Eval("gen_numcredito") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Asociado">
                           <ItemTemplate>
                           <asp:Label ID="lblaso"  Width="250px" Text='<%# Eval("nombrecompleto")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Monto">
                           <ItemTemplate>
                           <asp:Label ID="lblmonto"  Width="90px" Text='<%# Eval("gen_monto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Tipo">
                           <ItemTemplate>
                           <asp:Label ID="lbltipo"  Width="100px" Text='<%# Eval("ex_nomtipo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     

                        <asp:ButtonField Text="Seleccionar" CommandName="Select" ItemStyle-Width="150" ItemStyle-CssClass="seleccionarregistrogridview">
                            <ItemStyle Width="150px" >  </ItemStyle>

                            </asp:ButtonField>
                   

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>

    </div>
        
  </div>

            <div class="row">
        <h3>Expedientes a enviar</h3>
    <div class="col-md-12" style="overflow-x: auto;" >
      
         <asp:GridView ID="GDVTEMP" CssClass="table table-striped" style="width: 400px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid" OnSelectedIndexChanged="GDVTEMP_SelectedIndexChanged" AllowPaging="true" PageSize="5" OnPageIndexChanging="DGRVWPEN_PageIndexChanging" >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Fecha/Hora Desembolso">
                           <ItemTemplate>
                           <asp:Label ID="lblfecha"  Width="150px" Text='<%# Eval("gen_fechaprestamo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="CIF">
                           <ItemTemplate>
                           <asp:Label ID="lblcif"  Width="80px" Text='<%# Eval("cifgeneral") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No. Prestamo">
                           <ItemTemplate>
                           <asp:Label ID="lblnumcred"  Width="90px" Text='<%# Eval("gen_numcredito") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Asociado">
                           <ItemTemplate>
                           <asp:Label ID="lblaso"  Width="250px" Text='<%# Eval("nombrecompleto")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Monto">
                           <ItemTemplate>
                           <asp:Label ID="lblmonto"  Width="90px" Text='<%# Eval("gen_monto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Tipo">
                           <ItemTemplate>
                           <asp:Label ID="lbltipo"  Width="100px" Text='<%# Eval("ex_nomtipo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     

                        <asp:ButtonField Text="Eliminar" CommandName="Select" ItemStyle-Width="150" ItemStyle-CssClass="seleccionarregistrogridview">
                            <ItemStyle Width="150px" >  </ItemStyle>

                            </asp:ButtonField>
                   

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

       <%--<asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnmoduloscrear_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton5" runat="server" OnClick="btnModapp_Click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton6" runat="server" OnClick="btnmodulospermisos_Clicl" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton7" runat="server" OnClick="btnappuser_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="LinkButton8" runat="server" OnClick="btnestadouser_Click" ClientIDMode="Static"></asp:LinkButton>--%>
         <%-- Javascript --%>

         <div id="barcode">
        <video id="barcodevideo" autoplay ></video>
        <canvas id="barcodecanvasg"> </canvas>
        </div>
       <canvas id="barcodecanvas"></canvas>
        
        <asp:Label id="result" runat="server"    > </asp:Label>
       <%-- <input type="text" value="" id="result" runat="server" onchange="cambio(this.value)"  > </input>--%>



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

     <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/1.8.3/jquery.min.js'></script> <script type="text/javascript" src="../../EXDiseños/barcode.js"></script>
        <script type="text/javascript">
            var sound = new Audio('../../EXDiseños/barcode.wav');

            $(document).ready(function () {
                barcode.config.start = 0.1;
                barcode.config.end = 0.9;
                barcode.config.video = '#barcodevideo';
                barcode.config.canvas = '#barcodecanvas';
                barcode.config.canvasg = '#barcodecanvasg';
                barcode.setHandler(function (barcode) {
                    $('#result').html(barcode);
                 
                 
                })
                barcode.init();
                $('#result').bind('DOMSubtreeModified', function (e) {
                    sound.play();
                   


                });


              
            });
          

                
         
          
        </script>

    <script type="text/javascript">

          
        

    </script>


</body>
</html>
