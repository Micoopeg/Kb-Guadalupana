<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_AgenciaHallazgos.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_AgenciaHallazgos" %>

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

    <title>Hallazgos en expedientes</title>
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

			<li class="li ">
				<a href="javascript:void(0);" onclick="redirigir2()" class="links">
					<span class="span fa fa-suitcase"></span>Expedientes General
                 
				</a>
               
			</li>

			<li class="li" id="legalizados" runat="server" >
				<a href="javascript:void(0);" onclick="redirigir5()" class="links">
					<span class="span fa fa-eye"></span>Expedientes Legalizados
				</a>
			</li>

			<li class="li" id="pendientes" runat="server">
				<a href="javascript:void(0);" class="links" onclick="redirigir3()" >
					<span class="span fa fa-location-arrow"></span>Pendientes de envío
				</a>
			</li>
		<li class="li">
				<a href="javascript:void(0);" onclick="redirigir4()" class="links" >
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

             <h3 style=" font-size:20px; margin-left: 30%; margin-right: 30%;">Retenidos por hallazgos</h3>
         </center>
             </div>
   
             </div>

             <div class="row">
           <div class="col-md-9">
           
               <span id="alerta5"  runat="server" style="font-size:25px; color:white;"><b>Seleccione el expediente para ver la lista de hallazgos</b> </span>
       
              
            
              
               
           </div>
           <div class="col-md-2">
  <div class="form-group">

 
                <div id="btndivhall" visible="false"  runat="server" style=" margin-left: -266%;position: absolute; margin-top: 14%;"> <span> Hallazgos del credito: <h5 id="numcredito" runat="server"> </h5> </span> <asp:LinkButton  ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" class="btn btn-primary form-control" type="submit" Width="100%"  Text="Consultar Hallazgos" /> 
                   </div>


  </div>


               </div>
             </div>
               </div>
                 
       </center>
       
         <br />     <br />  <br />     <br />
             <div class="container">


            <div class="row">
                <h3 id="ajuridico" runat="server">Lista de expedientes con hallazgos</h3>
                 <div class="col-md-12" style="overflow-x: auto;" >
                <asp:GridView ID="DGVCONHALLAZGO" CssClass="table table-striped" style="width: 400px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid"  AllowPaging="true" PageSize="10" OnPageIndexChanging="DGVCONHALLAZGO_PageIndexChanging" OnSelectedIndexChanged="DGVCONHALLAZGO_SelectedIndexChanged" >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Fecha/Hora Desembolso">
                           <ItemTemplate>
                           <asp:Label ID="lblfecha"  Width="150px" Text='<%# Eval("gen_fecha_creacion") %>' runat="server" />
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
                       <asp:ButtonField Text="Ver Hallazgo" CommandName="Select" ItemStyle-Width="150" ItemStyle-CssClass="seleccionarregistrogridview">
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
        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btncerrar_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" ClientIDMode="Static"></asp:LinkButton>
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
