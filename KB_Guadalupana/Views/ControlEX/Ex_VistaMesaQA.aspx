<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_VistaMesaQA.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_VistaMesaQA" %>

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
    <title>Expedientes para Archivo</title>
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
					<span class="span fa fa-suitcase"></span>Expedientes General
               
				</a>
             
			</li>

			

			<li class="li" id="pendientes" runat="server">
				<a href="javascript:void(0);" class="links" onclick="redirigir5()" >
					<span class="span fa fa-location-arrow"></span>Pendientes de envío
				</a>
			</li>
		<li class="li">
				<a href="javascript:void(0);" onclick="redirigir6()" class="links">
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
                  <center>

             <h3 style=" font-size:20px; margin-left: 30%; margin-right: 30%;">Expedientes legalizados</h3>
         </center>
             </div>
           <div class="col-md-2">

           <div class="form-group"> 


          
                <span id="span" runat="server" style="font-size:15px">Código Mensajero: </span> <input id="txtcodigo" onkeypress="return numeros(event);"  runat="server" class="form-control" type="text" name="codigo" placeholder="Codigo Mensajero" required="required" tabindex="1" autofocus="autofocus"  />   
               <span id="span4" runat="server" style="font-size:15px">Lote Recibido: </span> <input id="txtlote" onkeypress="return numeros(event);"  runat="server" class="form-control" type="text" name="codigo" placeholder="Número de lote" required="required" tabindex="1" autofocus="autofocus"  />   
               <span id="span1" runat="server" style="font-size:15px">1. Validar Ingreso de Expedientes: </span><asp:TextBox ID="txtbarras" runat="server" onkeypress="return numeros(event);" CssClass="form-control" AutoPostBack="true"  OnTextChanged="txtbarras_TextChanged" required  autofocus =" autofocus" ></asp:TextBox >
                <span id="span2" runat="server" style="font-size:15px">2. Leer para Validar Expediente: </span><asp:TextBox ID="txtbarras2" runat="server" onkeypress="return numeros(event);" CssClass="form-control" AutoPostBack="true"  OnTextChanged="txtbarras2_TextChanged" required  autofocus =" autofocus" ></asp:TextBox >

                
           
           </div>
               </div>
             </div>

             <div class="row">
           <div class="col-md-9"><span id="alerta" runat="server" style="font-size:25px; width:25%; color: orangered;">Verifique los expendientes antes de generar la orden, no olvide descargar los documentos. </span>
               <span visible="false" id="alerta2" runat="server" style="font-size:15px; color: lawngreen;">Seleccione únicamente los expedientes que desea cargar a la Orden de envio </span>
            <span id="alerta7" visible="false" runat="server" style="font-size:20px; color:white;"><b>¿Desea Generar la carta de transporte con los expedientes seleccionados?</b> </span>
               <span id="alerta5" visible="false" runat="server" style="font-size:25px; color:white;"><b>Ingrese o consulte los hallazgos del expediente</b> </span>
               <br />
               <label visible="false" id="encabasignados" runat="server" style="color:white; font-size:15px">Usuario</label><br />
               
                 <div style="  margin-left: -220px;">
                 <span id="span3" runat="server" style="font-size:15px; margin-left:-25%" visible="false">No. Prestamo: <h5 style="font-size:15px; margin-top:-19px; margin-left: -116px " id="num" runat="server" ></h5>  </span><textarea visible="false" id="hallazgo" placeholder="Hallazgos encontrados" runat="server"    class="form-control" style="max-width:671px; height:88px; min-width: 671px;min-height: 100px; margin-left:220px "   required  ></textarea>


            </div>
              
               
           </div>
           <div class="col-md-2">
           <div class="form-group"> 
               <asp:LinkButton ID="btnorden" runat="server" OnClick="btnorden_Click" class="btn btn-primary form-control" type="submit" Width="100%"  Text="Generar Orden" /> </asp:LinkButton>
                <div id="btndiv" visible="false" runat="server" style=" margin-left: -184%;position: absolute; margin-top: 2%;"> <asp:LinkButton ID="btnhallazgo" runat="server" OnClick="btnhallazgo_Click" class="btn btn-primary form-control" type="submit" Width="111%"  Text="Insertar Hallazgo" /> 
                   </div>
                <div id="btndivhall" visible="false" runat="server" style=" margin-left: -284%;position: absolute; margin-top: 2%;"> <asp:LinkButton  ID="consultahall" runat="server" OnClick="consultahall_Click" class="btn btn-primary form-control" type="submit" Width="100%"  Text="Consultar Hallazgos" /> 
                   </div>
                  <div visible="false" id="divuserbtn" runat="server" style=" margin-left: -184%;position: absolute; margin-top: 26%;"> <asp:LinkButton  ID="btnasignaruser" runat="server" OnClick="btnasignaruser_Click" class="btn btn-primary form-control" type="submit" Width="100%"  Text="Asignar" /> 
                   </div>
                <div visible="false" id="divbtnverificar" runat="server" style=" margin-left: -46%;position: absolute; margin-top: -36%;"> <asp:LinkButton  ID="btnverificar" runat="server" OnClick="btnverificar_Click" class="btn btn-primary form-control" type="submit" Width="100%"  Text="Validar" /> 
                   </div>
            <div visible="false" id="divsi" runat="server" style=" margin-left: -615px;position: absolute; margin-top: -2%;"> <asp:LinkButton  ID="si" runat="server" OnClick="si_Click" class="btn btn-primary form-control" type="submit" Width="100%"  Text="Si" /> 
                   </div>
            <div visible="false" id="divno" runat="server" style=" margin-left: -566px;position: absolute; margin-top: -2%;"> <asp:LinkButton  ID="no" runat="server" OnClick="no_Click" class="btn btn-primary form-control" type="submit" Width="100%"  Text="No" /> 
                   </div>
               <div visible="false" id="divrecib" runat="server" style=" margin-left: -566px;position: absolute; margin-top: -2%;"> <asp:LinkButton  ID="btnmensajero" runat="server" OnClick="btnmensajero_Click" class="btn btn-primary form-control" type="submit" Width="100%"  Text="Validar Recepción" /> 
                   </div>
           </div>
               </div>
             </div>
               </div>
                 
       </center>
       
        
             <div class="container">

  <div class="row">
        <h3 id="encabselec" runat="server">Selección de Expedientes</h3>
    <div class="col-md-12" style="overflow-x: auto;" >
      
          <asp:GridView ID="DGVSELECT" CssClass="table table-striped" style="width: 400px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid" OnSelectedIndexChanged="DGVSELECT_SelectedIndexChanged" AllowPaging="true" PageSize="5" OnPageIndexChanging="DGVSELECT_PageIndexChanging" >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Fecha/Hora Desembolso">
                           <ItemTemplate>
                           <asp:Label ID="lblfecha"  Width="150px" Text='<%# Eval("gen_fechadesembolso") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="CIF">
                           <ItemTemplate>
                           <asp:Label ID="lblcif"  Width="80px" Text='<%# Eval("cifgeneral") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No. Préstamo">
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
                <h3 id="ajuridico" runat="server">Expedientes Asignados</h3>
                 <div class="col-md-12" style="overflow-x: auto;" >
                <asp:GridView ID="DGVCONHALLAZGO" CssClass="table table-striped" style="width: 400px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid"  AllowPaging="true" PageSize="5" OnPageIndexChanging="DGVCONHALLAZGO_PageIndexChanging" OnSelectedIndexChanged="DGVCONHALLAZGO_SelectedIndexChanged" >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Fecha/Hora Desembolso">
                           <ItemTemplate>
                           <asp:Label ID="lblfecha"  Width="150px" Text='<%# Eval("gen_fechadesembolso") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="CIF">
                           <ItemTemplate>
                           <asp:Label ID="lblcif"  Width="80px" Text='<%# Eval("cifgeneral") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No. Préstamo">
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
                       <asp:ButtonField Text="Hallazgo" CommandName="Select" ItemStyle-Width="150" ItemStyle-CssClass="seleccionarregistrogridview">
                            <ItemStyle Width="150px" >  </ItemStyle>

                            </asp:ButtonField>
                   

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                   
</div>
            </div>
                 <div class="row">
  
               
    <div class="col-md-12" style="overflow-x: auto;" >
      
      

         <asp:GridView ID="DGVAMARCAR" CssClass="table table-striped" style="width: 400px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid"  AllowPaging="true" PageSize="5" OnPageIndexChanging="DGVAMARCAR_PageIndexChanging" >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Fecha/Hora Desembolso">
                           <ItemTemplate>
                           <asp:Label ID="lblfecha"  Width="150px" Text='<%# Eval("gen_fechadesembolso") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="CIF">
                           <ItemTemplate>
                           <asp:Label ID="lblcif"  Width="80px" Text='<%# Eval("cifgeneral") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No. Préstamo">
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
                     

                       
                   

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>


    </div>
        
  </div>



            <div class="row">
        <h3 id="encabenvio" runat="server">Añadidos a la Orden</h3>
               
    <div class="col-md-12" style="overflow-x: auto;" >
      
      

         <asp:GridView ID="DGVOREN" CssClass="table table-striped" style="width: 400px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid" AllowPaging="true" PageSize="5" OnPageIndexChanging="DGVOREN_PageIndexChanging" >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Fecha/Hora Desembolso">
                           <ItemTemplate>
                           <asp:Label ID="lblfecha"  Width="150px" Text='<%# Eval("gen_fechadesembolso") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="CIF">
                           <ItemTemplate>
                           <asp:Label ID="lblcif"  Width="80px" Text='<%# Eval("cifgeneral") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No. Préstamo">
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
        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click" ClientIDMode="Static"></asp:LinkButton>
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
