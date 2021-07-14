<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="KB_Guadalupana.Views.Evaluaciones.Principal" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css'>
<link rel="stylesheet" href="../../SQEstilos/EstilosMenu.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css"/>
         <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet"  href="../../SQEstilos/EstilosDash.css" />

    <link rel="stylesheet" href="../../AvDiseños/Botones.css"   />
         <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
                      <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" type="text/javascript"></script>
                  <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
    
     
  
        
 
    <title>Evaluaciones Principal</title>
</head>
     <script>
       $(document).ready(function () {
           


             $('#data').hide();
            

                $("#dash").click(function (event) {
                
                    $('#data').show();
                    $('#encabezado').hide();
                    $('#subencabezado').hide();

                   $("#DASHBOARD").show();
                    $("#PUESTOSFORM").hide();   
                    $("#PREGUNTAS").hide();
                    $("#ASIGNADOS").hide();
                    $("#EVALUACIONMODI").hide();
                    $("#EVALUACIONCREAR").hide();
                    $("#REPORTESS").hide();
                    $("#ESCALASCREAR").hide();
                    $("#ESCALASMOD").hide();

                });

                $("#preguntasn").click(function (event) {
                    $('#data').show();
                    $('#encabezado').hide();
                    $('#subencabezado').hide();

                    $("#PREGUNTAS").show();
                    $("#PUESTOSFORM").hide();   
                    $("#DASHBOARD").hide();
                    $("#ASIGNADOS").hide();
                    $("#EVALUACIONMODI").hide();
                    $("#EVALUACIONCREAR").hide();
                    $("#REPORTESS").hide();
                    $("#ESCALASCREAR").hide();
                    $("#ESCALASMOD").hide();

                });


                $("#puestos").click(function (event) {
                    $('#data').show();
                    $('#encabezado').hide();
                    $('#subencabezado').hide();

                    $("#PUESTOSFORM").show();
                    $("#DASHBOARD").hide();
                    $("#PREGUNTAS").hide();
                    $("#ASIGNADOS").hide();
                    $("#EVALUACIONMODI").hide();
                    $("#EVALUACIONCREAR").hide();
                    $("#REPORTESS").hide();
                    $("#ESCALASCREAR").hide();
                    $("#ESCALASMOD").hide();
                });


             $("#asignados").click(function (event) {
                 $('#data').show();
                 $('#encabezado').hide();
                 $('#subencabezado').hide();

                 $("#ASIGNADOS").show();
                 $("#DASHBOARD").hide();
                 $("#PREGUNTAS").hide();
                 $("#PUESTOSFORM").hide();
                 $("#EVALUACIONMODI").hide();
                 $("#EVALUACIONCREAR").hide();
                 $("#REPORTESS").hide();
                 $("#ESCALASCREAR").hide();
                 $("#ESCALASMOD").hide();
              
             });

           $("#crear").click(function (event) {
               $('#data').show();
               $('#encabezado').hide();
               $('#subencabezado').hide();

               $("#EVALUACIONCREAR").show();
               $("#ASIGNADOS").hide();
               $("#DASHBOARD").hide();
               $("#PREGUNTAS").hide();
               $("#PUESTOSFORM").hide();
               $("#EVALUACIONMODI").hide();
               $("#REPORTESS").hide();
               $("#ESCALASCREAR").hide();
               $("#ESCALASMOD").hide();

           });

           $("#modificar").click(function (event) {
               $('#data').show();
               $('#encabezado').hide();
               $('#subencabezado').hide();

               $("#EVALUACIONMODI").show();
               $("#ASIGNADOS").hide();
               $("#DASHBOARD").hide();
               $("#PREGUNTAS").hide();
               $("#PUESTOSFORM").hide();
               $("#EVALUACIONCREAR").hide();
               $("#REPORTESS").hide();
               $("#ESCALASCREAR").hide();
               $("#ESCALASMOD").hide();


           });

           $("#modificarescala").click(function (event) {
               $('#data').show();
               $('#encabezado').hide();
               $('#subencabezado').hide();

               $("#ESCALASMOD").show();
               $("#ASIGNADOS").hide();
               $("#DASHBOARD").hide();
               $("#PREGUNTAS").hide();
               $("#PUESTOSFORM").hide();
               $("#EVALUACIONMODI").hide();
               $("#EVALUACIONCREAR").hide();
               $("#REPORTESS").hide();
               $("#ESCALASCREAR").hide();
             

           });

           $("#crearescala").click(function (event) {
               $('#data').show();
               $('#encabezado').hide();
               $('#subencabezado').hide();

               $("#ESCALASCREAR").show();
               $("#ASIGNADOS").hide();
               $("#DASHBOARD").hide();
               $("#PREGUNTAS").hide();
               $("#PUESTOSFORM").hide();
               $("#EVALUACIONMODI").hide();
               $("#EVALUACIONCREAR").hide();
               $("#REPORTESS").hide();
               
               $("#ESCALASMOD").hide();

           });

           $("#reportes").click(function (event) {
               $('#data').show();
               $('#encabezado').hide();
               $('#subencabezado').hide();

               $("#REPORTESS").show();
               $("#ASIGNADOS").hide();
               $("#DASHBOARD").hide();
               $("#PREGUNTAS").hide();
               $("#PUESTOSFORM").hide();
               $("#EVALUACIONMODI").hide();
               $("#EVALUACIONCREAR").hide();
             
               $("#ESCALASCREAR").hide();
               $("#ESCALASMOD").hide();

           });
                
            });

      
     </script>
    
    
      


<body>
    <form id="form1" runat="server">

      
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <%--      <script type="text/javascript" >   
  Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(pageLoaded);

              
                function pageLoaded(sender, args) {
                    enlazarEventos();
                }

                $(function () {
                    enlazarEventos();
                });

                function enlazarEventos() {
                    $("#dgvevaluador").chose();
                   
                }


            </script>   --%>

      

      
   
        <%-- MENU PRINCIPAL --%>
         <nav class="navbar navbar-default no-margin">
      <!-- Brand and toggle get grouped for better mobile display -->
      <div class="navbar-header fixed-brand">
         <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" id="menu-toggle">
<span class="glyphicon glyphicon-th-large" aria-hidden="true"></span>
</button>
         <a class="navbar-brand" style="font-size:15px" ><i class="fa fa-rocket fa-4"></i> Sistema De Evaluaciones</a>
      </div>
      <!-- navbar-header-->
      <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
         <ul class="nav navbar-nav">
            <li class="active">
               <button class="navbar-toggle collapse in" data-toggle="collapse" id="menu-toggle-2"> <span class="glyphicon glyphicon-th-large" aria-hidden="true"></span>
               </button>
            </li>
         </ul>
      </div>
      <!-- bs-example-navbar-collapse-1 -->
   </nav>

        <%-- OPCIONES DEL MENU --%>
   <div id="wrapper">
       <%-- MENU --%>
      <div id="sidebar-wrapper">
         <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
            <li class="active">
               <a href="../Sesion/MenuBarra.aspx"><span class="fa-stack fa-lg pull-left"><i class="fa fa-home fa-stack-1x "></i></span> Inicio</a>
              
            </li>
          <%--  <li>
               <a id="dash"  href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-dashboard fa-stack-1x "></i></span>Dashboard</a>
              
            </li>--%>
            <li>
               <a href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-question-circle fa-stack-1x "></i></span>Configurar Preguntas</a>
                 <ul class="nav-pills nav-stacked" style="list-style-type:none;">
                  <li><a id="preguntasn" href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span>Preguntas Existentes</a></li>
        
                     
               </ul>
            </li>
                    <li>
               <a id="evaluaciones"  href="#"><span class="fa-stack fa-lg pull-left"><i class="	fa fa-book fa-stack-1x "></i></span>Evaluaciones</a>
                 <ul class="nav-pills nav-stacked" style="list-style-type:none;">
                     <li><a id="crear" href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span> Crear</a></li>
                      <li><a id="modificar" href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span> Modificar</a></li>
                  <li><a id="previewgerente" href="SQ_Evaluacion.aspx" ><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span> Evaluación Gerencia</a></li>
                   <%--  <li><a id="previewjefe" href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span> Evaluación Jefatura</a></li>
                     <li><a id="previewsub" href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span>  Evaluación Sub</a></li>--%>
               </ul>
            </li>
               <li>
               <a id="escalas"  href="#"><span class="fa-stack fa-lg pull-left"><i class="	fa fa-sort-amount-asc fa-stack-1x "></i></span>Escalas</a>
               <ul class="nav-pills nav-stacked" style="list-style-type:none;">
                    <li><a id="crearescala" href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span>Crear Escala </a></li>
                  <li><a id="modificarescala" href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span>Datos de la Escala</a></li>
                     

               </ul>
            </li>
               <%-- <li>
               <a id="permisos"  href="#"><span class="fa-stack fa-lg pull-left"><i class="	fa fa-group fa-stack-1x "></i></span>Permisos</a>
              
            </li>--%>
               <li>
               <a id="mantenimientos"  href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-pencil fa-stack-1x "></i></span>Mantenimientos</a>
               <ul class="nav-pills nav-stacked" style="list-style-type:none;">
                  <li><a id="tipoeval" href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span>Tipo de evaluación</a></li>
                     <li><a id="puestos" href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span>Puestos</a></li>
                    <li><a id="asignados" href="#"><span class="fa-stack fa-lg pull-left"><i class="fa fa-edit fa-stack-1x "></i></span>Asignados</a></li>
               </ul>
            </li>
                <li>
               <a id="reportes"  href="#"><span class="fa-stack fa-lg pull-left"><i class="	fa fa-line-chart fa-stack-1x "></i></span>Reportes</a>
              
            </li>
         </ul>
      </div>
  <%-- CONTENIDO DE LA PAGINA --%>
      <div id="page-content-wrapper">
         <div class="container-fluid xyz">
            <div class="row">
               <div class="col-lg-12">
                  <h1 id="encabezado" >Administración de Sistema de Evaluaciones<a ></a></h1>
                  <p id="subencabezado">Bienvenido, puedes administrar los parametros de tus evaluaciones.
                      
                  </p>
                      
               </div>
        
                <div id="data" runat="server" class="menu">  
                   <%-- PUESTOS --%>
                <div id="PUESTOSFORM" runat="server" >  
               <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
               <ContentTemplate>
       <div class="container justify-content-center aling-items-center minh-100" style="max-width: 850px;">
          
             <div class="form-group">
            
                <div class="row">
                    <div class="col-sm-4">
                         <h5>Puesto</h5>
                         <input id="puesto" type="text" runat="server" onkeypress="return soloLetras(event);" class="form-control form-control-lg" placeholder="Descripción del Puesto" tabindex="0" autofocus="autofocus" required="required"/>
                        <h5>Cantidad</h5>
                 <input id="cantidad" type="text" runat="server" class="form-control form-control-lg" onkeypress="return numeros(event);" placeholder="Cantidad" required="required"/>
                        </div>
                 
                        <div class="col-sm-2" style="margin-top:11%">
                        
          
            <div class="container">
            <%--    
             <asp:LinkButton ID="btnpuestos" runat="server" CssClass="custom-btn btn-8" ClientIDMode="AutoID" Text="ingresar" OnClick="btnpuestos_Click" style="text-align:center; text-decoration:none;" > </asp:LinkButton>--%>

            <%--    <button id="datos" runat="server" class="custom-btn btn-8" onclick="insertados()" >Insertar </button>--%>
                <%-- <asp:Button ID="btninserta" runat="server" OnClick="btnpuestos_Click" Text="Insertar" CssClass="custom-btn btn-8"  PostBackUrl="~/Views/Evaluaciones/Principal.aspx"/>--%>
                <asp:LinkButton ID="btninserta" runat="server" OnClick="btnpuestos_Click" Text="Insertar" CssClass="custom-btn btn-8" style="text-align:center; text-decoration:none;"  ></asp:LinkButton>
                <asp:LinkButton ID="btnmodificar" runat="server" OnClick="btnmodificar_Click" Text="Modificar" CssClass="custom-btn btn-8" style="text-align:center; text-decoration:none;" Visible ="false" ></asp:LinkButton>
                <asp:LinkButton ID="btneliminar" runat="server" OnClick="btneliminar_Click" Text="Eliminar" CssClass="custom-btn btn-8" style="text-align:center; text-decoration:none;" Visible ="false" ></asp:LinkButton>
            </div>
   
                        
                    </div>
                </div>
            </div>
             </div>

         <div class="row">
        <h3 id="encabselec" runat="server" style="text-align:center">Puestos Actuales</h3>
    <div class="col-md-12" style="overflow-x: auto;" >
      <div style=" text-align: -webkit-center; margin-top: 1%;">
          <asp:GridView ID="DGVPUESTOS" CssClass="table table-striped" style="width: 860px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid" OnSelectedIndexChanged="DGVPUESTOS_SelectedIndexChanged" AllowPaging="true" PageSize="10" OnPageIndexChanging="DGVPUESTOS_PageIndexChanging"   >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No" Visible="false">
                           <ItemTemplate>
                           <asp:Label ID="idpuesto"  Width="30px" Text='<%# Eval("codsqpuesto") %>' runat="server" Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No">
                           <ItemTemplate>
                           <asp:Label ID="id"  Width="30px" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Puesto">
                           <ItemTemplate>
                           <asp:Label ID="puesto"  Width="150px" Text='<%# Eval("puestodescrip") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Cantidad">
                           <ItemTemplate>
                           <asp:Label ID="cantidad"  Width="150px" Text='<%# Eval("puestocant") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                      
                     

                        <asp:ButtonField Text="Editar" CommandName="Select" ItemStyle-Width="150" ItemStyle-CssClass="seleccionarregistrogridview">
                            <ItemStyle Width="150px" >  </ItemStyle>

                            </asp:ButtonField>
                   

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>
          </div>
    </div>
        
  </div>

                   </ContentTemplate>
               <Triggers>

                   <asp:AsyncPostBackTrigger ControlID="btninserta" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID ="btnmodificar" EventName ="Click" />
                     <asp:AsyncPostBackTrigger ControlID ="btneliminar" EventName ="Click" />
               </Triggers>
      </asp:UpdatePanel>
                </div>
                    <%-- DASHBOARD --%>
                <div id="DASHBOARD" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                        <ContentTemplate>
     <section class="overview">
        <div class="wrapper">

			<h2 id="Date" runat="server" >sin fecha error</h2>
            <h2>Evaluación vigente junio</h2>
			
			<br />
            <div class="grid">
            <div class="card-small">
                <p class="card-small-views">Pendientes de respuesta</p>
                <p class="card-small-icon">
                     <span class="fa fa-question-circle "></span>
                </p>
                <p id="pendientes" runat="server" class="card-small-number">20</p>
                
            </div>
            <div class="card-small">
                <p class="card-small-views">Pasados de la fecha</p>
                <p class="card-small-icon">
                    <span class="fa fa-calendar-times-o"></span>
                </p>
                <p id="pasadosfecha" runat="server" class="card-small-number">4</p>
               
            </div>
            <div class="card-small">
                <p class="card-small-views">En Proceso</p>
                <p class="card-small-icon">
                     <span class="fa fa-clock-o"></span>
                </p>
                <p id="iniciados" runat="server" class="card-small-number">10</p>
               
            </div>
            <div class="card-small">
                <p class="card-small-views">Terminados</p>
                <p class="card-small-icon">
                     <span class="fa fa-check-square"></span>
                </p>
                <p id="terminados" runat="server" class="card-small-number">50</p>
              
            </div>
      
            
        </div>
            </div>
    </section>

                        </ContentTemplate>
                    
                    </asp:UpdatePanel>

                </div>
                    <%-- PREGUNTAS --%>

                    <div id="PREGUNTAS" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                    <div class="container justify-content-center aling-items-center minh-100" style="max-width: 850px;">

         


            <div class="form-group" style="text-align: center">
           
                <label for="exampleInputEmail1">
                    <h1>Título de la pregunta</h1>
                </label>
                  <textarea id="titulopregunta" runat="server" class="form-control form-control-lg" style="max-height:32px; min-height:32px; max-width:819px; min-width:819px;" placeholder="Pregunta" rows="4" maxlength="500" required></textarea>
            </div>
               <div class="form-group" style="text-align: center">
                <label for="exampleFormControlTextarea1">
                    <h1>Información Extra</h1>
                </label>
                <textarea id="infoextrapregunta" runat="server" class="form-control form-control-lg" style="max-height:49px; min-height:49px; max-width:820px; min-width:820px;" placeholder="Información extra de la pregunta (Opcional)"  rows="4" maxlength="500"></textarea>
            </div>
  
            <div class="form-group">
            
                <div class="row">
                    <div class="col-sm-4">
                         <h5>TIpo de pregunta</h5>
                         <asp:DropDownList  id="droptipo" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                        <h5>Orden de la pregunta</h5>
                         <asp:DropDownList  id="droporden" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                          <h5>Escala</h5>
                         <asp:DropDownList  id="dropescala" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                    
                    </div>
                    <div class="col-sm-4">
                        
                         <h5>Evaluación</h5>
                         <asp:DropDownList  id="dropeval" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                        <h5>Estado</h5>
                         <asp:DropDownList  id="dropestado" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                      
                       
                     
                        </div>
                        <div class="col-sm-2" style="margin-top:11%">
                        
          
            <div class="container">
                

     <asp:LinkButton ID="btnpreguntasinsert" runat="server" CssClass="custom-btn btn-8" Text="Insertar Pregunta" OnClick="btninsertpregunta_Click" style="text-align:center; text-decoration:none;"> </asp:LinkButton>
                 <asp:LinkButton ID="btnmodpregunta" runat="server" CssClass="custom-btn btn-8" Text="Modificar" OnClick="btnmodificarpregunta_Click" style="text-align:center; text-decoration:none;" Visible="false"> </asp:LinkButton>
                 <asp:LinkButton ID="btneliminarpregunta" runat="server" CssClass="custom-btn btn-8" Text="Eliminar" OnClick="btneliminarpregunta_Click" style="text-align:center; text-decoration:none;" Visible="false"> </asp:LinkButton>
            


            </div>
   
                        
                    </div>
                </div>
            </div>

        </div>
                                  <div class="row">
        <h3 id="H2" runat="server" style="text-align:center">Preguntas</h3>
    <div class="col-md-12" style="overflow-x: auto;" >
      <div style=" text-align: -webkit-center; margin-top: 1%;">
          <asp:GridView ID="DGVPREGUNTAS" CssClass="table table-striped" style="width: 860px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid" OnSelectedIndexChanged="DGVPREGUNTAS_SelectedIndexChanged" AllowPaging="true" PageSize="1" OnPageIndexChanging="DGVPREGUNTAS_PageIndexChanging"   >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No" Visible="false">
                           <ItemTemplate>
                           <asp:Label ID="idpregunta"  Width="30px" Text='<%# Eval("codsqpregunta") %>' runat="server" Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No">
                           <ItemTemplate>
                           <asp:Label ID="id"  Width="30px" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Pregunta">
                           <ItemTemplate>
                           <asp:Label ID="pregunta"  Width="150px" Text='<%# Eval("pregunta") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Info Extra">
                           <ItemTemplate>
                           <asp:Label ID="infoextra"  Width="150px" Text='<%# Eval("InfoExtrapregunta") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Evaluación">
                           <ItemTemplate>
                           <asp:Label ID="evaluacion"  Width="150px" Text='<%# Eval("codsqeval") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Tipo de Pregunta">
                           <ItemTemplate>
                           <asp:Label ID="tipopregunta"  Width="150px" Text='<%# Eval("tipopregunta") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Orden">
                           <ItemTemplate>
                           <asp:Label ID="ordenpregunta"  Width="150px" Text='<%# Eval("ordenpregunta") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Escala">
                           <ItemTemplate>
                           <asp:Label ID="escala"  Width="150px" Text='<%# Eval("nombreescala") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Estado">
                           <ItemTemplate>
                           <asp:Label ID="estado"  Width="150px" Text='<%# Eval("estado") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      
                     

                        <asp:ButtonField Text="Editar" CommandName="Select" ItemStyle-Width="150" ItemStyle-CssClass="seleccionarregistrogridview">
                            <ItemStyle Width="150px" >  </ItemStyle>

                            </asp:ButtonField>
                   

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>
          </div>
    </div>
        
  </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnpreguntasinsert" EventName="Click" />

                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                    <%-- EVALUACIONESMOD --%>

                    <div id="EVALUACIONMODI" runat="server"> 
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                             <div class="container justify-content-center aling-items-center minh-100" style="max-width: 850px;">



            <div class="form-group" >
           
                <div class="row"> 
                     <div class="col-sm-4">
                         <h5>Evaluación</h5>
                         <asp:DropDownList  id="dropevaluacionexistente" runat="server" AutoPostBack="true"  CssClass="form-control" OnSelectedIndexChanged="dropevaluacionexistente_SelectedIndexChanged"    ></asp:DropDownList>
               
                    </div>

                </div>
          </div>
          
           <div class="form-group" style="text-align: center">
           
                <label for="exampleInputEmail1">
                    <h1>Configuración de la evaluación</h1>
                </label>
            <h5>Nombre de Evaluación</h5>
                         <input id="nombreeval" type="text" runat="server" onkeypress="return soloLetras(event);" class="form-control form-control-lg" placeholder="Nombre de Evaluación" tabindex="0" autofocus="autofocus" required="required"/>
                  
                 <h5>Comentario</h5>
                  <textarea id="comentariomod" runat="server" class="form-control form-control-lg" placeholder="Pregunta" rows="4" maxlength="250" required></textarea>
            </div>
  
            <div class="form-group">
            
                <div class="row">
                    <div class="col-sm-4">
                        
                              <label for="exampleInputPassword1">
                    <h1>Fecha de inicio</h1>
                </label>

                <input id="fechainicialmodeval" runat="server" type="datetime-local"   class="form-control"   style="text-align: center;" />
                                   <label for="exampleInputPassword1">
                    <h1>Fecha final</h1>
                </label>

                <input id="fechafinalmodeval" runat="server" type="datetime-local"   class="form-control"   style="text-align: center;" />
                            <h5>Tipo Evaluación</h5>
                         <asp:DropDownList  id="dropevaluaciontipomod" runat="server"   CssClass="form-control"  ></asp:DropDownList>
                          <h5>Estado</h5>
                         <asp:DropDownList  id="dropestadoevalestadomod" runat="server"   CssClass="form-control"    ></asp:DropDownList>
                      
                       
                     
                        </div>
                        <div class="col-sm-2" style="margin-top:11%">
                        
          
            <div class="container">
                

                 <asp:LinkButton ID="btnmodeval" runat="server" CssClass="custom-btn btn-8" Text="Modificar Evaluación" OnClick="btninsertpregunta_Click" style="text-align:center; text-decoration:none; width:158px;"> </asp:LinkButton>
            


            </div>
   
                        
                    </div>
                </div>
            </div>
      
           

          




        </div>

                        </ContentTemplate>
                       <Triggers>

                           <asp:AsyncPostBackTrigger ControlID="btnmodeval" EventName="Click" />
                           <asp:AsyncPostBackTrigger ControlID="dropevaluacionexistente" EventName="SelectedIndexChanged" />
                       </Triggers>
                     </asp:UpdatePanel>



                    </div>





                    <%-- EVALUACION CREAR --%>

                        <div id="EVALUACIONCREAR" runat="server"> 
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                             <div class="container justify-content-center aling-items-center minh-100" style="max-width: 850px;">

         


            <div class="form-group" style="text-align: center">
           
                <label for="exampleInputEmail1">
                    <h1>Configuración de la evaluación</h1>
                </label>
                 <h5>Comentario</h5>
                  <textarea id="comentarioeval" runat="server" class="form-control form-control-lg" placeholder="Pregunta" rows="4" maxlength="250" required></textarea>
            </div>
          
  
            <div class="form-group">
            
                <div class="row">
                    <div class="col-sm-4">
                        
                              <label for="exampleInputPassword1">
                    <h1>Fecha de inicio</h1>
                </label>

                <input id="fechainicial" runat="server" type="datetime-local"   class="form-control"   style="text-align: center;" />
                                   <label for="exampleInputPassword1">
                    <h1>Fecha final</h1>
                </label>

                <input id="fechafinal" runat="server" type="datetime-local"   class="form-control"   style="text-align: center;" />
                          <h5>Estado</h5>
                         <asp:DropDownList  id="dropestadoevaluacion" runat="server"   CssClass="form-control"  ></asp:DropDownList>
                    
                           <h5>Tipo Evaluación</h5>
                         <asp:DropDownList  id="droptipoevalmod" runat="server"   CssClass="form-control"  ></asp:DropDownList>
                       
                     
                        </div>
                        <div class="col-sm-2" style="margin-top:11%">
                        
          
            <div class="container">
                
    

            
                    <asp:LinkButton ID="btncreareval" runat="server" CssClass="custom-btn btn-8" Text="Crear Evaluación" OnClick="btninsertpregunta_Click" style="text-align:center; text-decoration:none;"> </asp:LinkButton>

            </div>
   
                        
                    </div>
                </div>
            </div>
      
           

          




        </div>

                        </ContentTemplate>
                       <Triggers>

                           <asp:AsyncPostBackTrigger ControlID="btncreareval" EventName="Click" />
                       </Triggers>
                     </asp:UpdatePanel>


                    </div>






                    <%-- REPORTES --%>

                    <div id="REPORTESS" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                             <asp:LinkButton ID="generarrepo" runat="server" CssClass="custom-btn btn-8" Text="Reporte de Pendientes" OnClick="generarrepo_Click" style="text-align:center; text-decoration:none; width:182px"> </asp:LinkButton>
                             <asp:LinkButton ID="generarreponotas" runat="server" CssClass="custom-btn btn-8" Text="Reporte de Calificaciones" OnClick="generarreponotas_Click" style="text-align:center; text-decoration:none; width:182px"> </asp:LinkButton>
                           <br />
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Width="100%" Height =" 700px"></rsweb:ReportViewer>

                        </ContentTemplate>
                  
                     </asp:UpdatePanel>
                    </div>




                    <%-- ESCALAS --%>


                    <div id="ESCALASCREAR" runat="server">
                         <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                              <div class="container justify-content-center aling-items-center minh-100" style="max-width: 850px;">
          
             <div class="form-group">
            
                <div class="row">
                    <div class="col-sm-4">
                         <h5>Nombre de la Escala</h5>
                         <input id="nombreescala" type="text" runat="server"  class="form-control form-control-lg" placeholder="Nombre de la escala" tabindex="0" autofocus="autofocus" required="required"/>
                         <h5>Estado</h5>
                         <asp:DropDownList  id="dropestadoescala" runat="server"   CssClass="form-control" AutoPostBack="false"    ></asp:DropDownList>
                        </div>
                 
                        <div class="col-sm-2" style="margin-top:11%">
                        
          
            <div class="container">
            <%--    
             <asp:LinkButton ID="btnpuestos" runat="server" CssClass="custom-btn btn-8" ClientIDMode="AutoID" Text="ingresar" OnClick="btnpuestos_Click" style="text-align:center; text-decoration:none;" > </asp:LinkButton>--%>

            <%--    <button id="datos" runat="server" class="custom-btn btn-8" onclick="insertados()" >Insertar </button>--%>
                <%-- <asp:Button ID="btninserta" runat="server" OnClick="btnpuestos_Click" Text="Insertar" CssClass="custom-btn btn-8"  PostBackUrl="~/Views/Evaluaciones/Principal.aspx"/>--%>
                <asp:LinkButton ID="btninsertescala" runat="server" OnClick="btninsertescala_Click" Text="Insertar" CssClass="custom-btn btn-8" style="text-align:center; text-decoration:none;"  ></asp:LinkButton>
                <asp:LinkButton ID="btnmodescala" runat="server" OnClick="btnmodescala_Click" Text="Modificar" CssClass="custom-btn btn-8" style="text-align:center; text-decoration:none;" Visible ="false" ></asp:LinkButton>
                <asp:LinkButton ID="btnelimescala" runat="server" OnClick="btnelimescala_Click" Text="Eliminar" CssClass="custom-btn btn-8" style="text-align:center; text-decoration:none;" Visible ="false" ></asp:LinkButton>
            </div>
   
                        
                    </div>
                </div>
            </div>
             </div>

         <div class="row">
        <h3 id="H3" runat="server" style="text-align:center">Escalas Actuales</h3>
    <div class="col-md-12" style="overflow-x: auto;" >
      <div style=" text-align: -webkit-center; margin-top: 1%;">
          <asp:GridView ID="DGVESCALAS" CssClass="table table-striped" style="width: 860px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid" OnSelectedIndexChanged="DGVESCALAS_SelectedIndexChanged" AllowPaging="true" PageSize="10" OnPageIndexChanging="DGVESCALAS_PageIndexChanging"   >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No" Visible="false">
                           <ItemTemplate>
                           <asp:Label ID="idescala"  Width="30px" Text='<%# Eval("codsqescala") %>' runat="server" Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No">
                           <ItemTemplate>
                           <asp:Label ID="id"  Width="30px" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Nombre Esala">
                           <ItemTemplate>
                           <asp:Label ID="nombreescala"  Width="150px" Text='<%# Eval("nombreescala") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Estado">
                           <ItemTemplate>
                           <asp:Label ID="estadoescala"  Width="150px" Text='<%# Eval("estadoeval") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                      
                     

                        <asp:ButtonField Text="Editar" CommandName="Select" ItemStyle-Width="150" ItemStyle-CssClass="seleccionarregistrogridview">
                            <ItemStyle Width="150px" >  </ItemStyle>

                            </asp:ButtonField>
                   

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>
          </div>
    </div>
        
  </div>

                        </ContentTemplate>
                   <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="btninsertescala" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnmodescala" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnelimescala" EventName="Click" />
                   </Triggers>
                     </asp:UpdatePanel>



                     </div>


                    <%-- ESCALASMOD --%>


                    <div id="ESCALASMOD" runat="server"> 

                         <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                             <div class="container justify-content-center aling-items-center minh-100" style="max-width: 850px;">

         


            <div class="form-group" style=" text-align: -webkit-center;">
           
                <label for="exampleInputEmail1">
                    <h1>Rango numérico</h1>
                </label>
                  <textarea id="rangonumerico" runat="server" class="form-control form-control-lg" style="max-height:32px; min-height:32px; max-width:200px; min-width:200px;" placeholder="Por Ejemplo 0-1-2 o bien 3-4  " rows="4" maxlength="500" required></textarea>
            </div>
               <div class="form-group" style="text-align: center">
                <label for="exampleFormControlTextarea1">
                    <h1>Valor Textual de la Escala</h1>
                </label>
                <textarea id="valortextual" runat="server" class="form-control form-control-lg" style="max-height:49px; min-height:49px; max-width:820px; min-width:820px;" placeholder="Información del significado del rango"  rows="4" maxlength="500"></textarea>
           
                   <div class="row"> 
                            <div class="col-sm-4">
                        
                     
                        <h5>Escala</h5>
                         <asp:DropDownList  id="dropescaladatos" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                      
                        <h5>Estado</h5>
                         <asp:DropDownList  id="dropestadodatos" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                      
                       
                       
                     
                        </div>
                         <div class="col-sm-4" style="margin-top:11%">
                        
          
        
                

                 <asp:LinkButton ID="btninsertescaladatos" runat="server" CssClass="custom-btn btn-8" Text="Insertar Datos" OnClick="btninsertescaladatos_Click" style="text-align:center; text-decoration:none;"> </asp:LinkButton>
                 <asp:LinkButton ID="btnmodescaladatos" runat="server" CssClass="custom-btn btn-8" Text="Modificar" OnClick="btnmodescaladatos_Click" style="text-align:center; text-decoration:none;" Visible="false"> </asp:LinkButton>
                 <asp:LinkButton ID="btneliminarescaladatos" runat="server" CssClass="custom-btn btn-8" Text="Eliminar" OnClick="btnelimescaladatos_Click" style="text-align:center; text-decoration:none;" Visible="false"> </asp:LinkButton>
            


   
                        
                    </div>

                   </div>

                   </div>
  
          

        </div>
                                  <div class="row">
        <h3 id="H4" runat="server" style="text-align:center">Datos de la escala</h3>
    <div class="col-md-12" style="overflow-x: auto;" >
      <div style=" text-align: -webkit-center; margin-top: 1%;">
          <asp:Label ID="lbl" runat="server" Text="Rango" > </asp:Label>
          <asp:TextBox ID="bbuscar" runat="server" ></asp:TextBox>
           <asp:Label ID="Label1" runat="server" Text="Texto" > </asp:Label>
          <asp:TextBox ID="buscartexto" runat="server"  ></asp:TextBox>
          <asp:Label ID="Label2" runat="server" Text="Escala" > </asp:Label>
          <asp:TextBox ID="escalanombrebus" runat="server"  ></asp:TextBox>
          <asp:LinkButton ID="buscardatos" runat="server" CssClass="custom-btn btn-8" Text="Buscar" OnClick="buscardatos_Click" style="text-align:center; text-decoration:none;"> </asp:LinkButton>
          <asp:GridView ID="DGVDATOSESC" CssClass="table table-striped" style="width: 860px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid" OnSelectedIndexChanged="DGVDATOSESC_SelectedIndexChanged" AllowPaging="true" PageSize="3" OnPageIndexChanging="DGVDATOSESC_PageIndexChanging"   >
                    <Columns>
                        
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No" Visible="false">
                           <ItemTemplate>
                           <asp:Label ID="idescaladatos"  Width="30px" Text='<%# Eval("codsqescalaid") %>' runat="server" Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No">
                           <ItemTemplate>
                           <asp:Label ID="id"  Width="30px" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Escala">
                           <ItemTemplate>
                           <asp:Label ID="nombreescala"  Width="150px" Text='<%# Eval("nombreescala") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Rango">
                           <ItemTemplate>
                           <asp:Label ID="rango"  Width="150px" Text='<%# Eval("rangonumerico") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Texto de la Escala">
                           <ItemTemplate>
                           <asp:Label ID="valortexto"  Width="150px" Text='<%# Eval("valortexto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Estado">
                           <ItemTemplate>
                           <asp:Label ID="estadoescaladato"  Width="150px" Text='<%# Eval("estadoeval") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      
                     

                        <asp:ButtonField Text="Editar" CommandName="Select" ItemStyle-Width="150" ItemStyle-CssClass="seleccionarregistrogridview">
                            <ItemStyle Width="150px" >  </ItemStyle>

                            </asp:ButtonField>
                   

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>
 
          </div>
    </div>
        
  </div>

                        </ContentTemplate>
                             <Triggers>
                                 <asp:AsyncPostBackTrigger ControlID="buscardatos" EventName="Click" />
                                  
                             </Triggers>
                    
                     </asp:UpdatePanel>


                    </div>










                    <%-- ASIGNACION --%>

                     <div id="ASIGNADOS" runat="server" >  
               <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
               <ContentTemplate>
                 
                   

                <%--<script type="text/javascript">
                    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
               
                    function EndRequestHandler(sender, args) {
                        $('#<%=dgvevaluado.ClientID%>').chosen();
                        $('#<%=dgvevaluador.ClientID%>').chosen();

                    }
                </script>--%>
       <div class="container justify-content-center aling-items-center minh-100" style="max-width: 850px;">
          
             <div class="form-group">
            
                <div class="row">
                    <div class="col-sm-4">
                         <h5>Evaluador</h5>
                         <asp:DropDownList  id="dgvevaluador" runat="server"   CssClass="form-control" AutoPostBack="false"    ></asp:DropDownList>
                          <h5>Evaluado</h5>
                         <asp:DropDownList  id="dgvevaluado" runat="server"   CssClass="form-control" AutoPostBack="false"    ></asp:DropDownList>
                        </div>
                 
                        <div class="col-sm-2" style="margin-top:11%">
                        
          
            <div class="container">
            <%--    
             <asp:LinkButton ID="btnpuestos" runat="server" CssClass="custom-btn btn-8" ClientIDMode="AutoID" Text="ingresar" OnClick="btnpuestos_Click" style="text-align:center; text-decoration:none;" > </asp:LinkButton>--%>

            <%--    <button id="datos" runat="server" class="custom-btn btn-8" onclick="insertados()" >Insertar </button>--%>
                <%-- <asp:Button ID="btninserta" runat="server" OnClick="btnpuestos_Click" Text="Insertar" CssClass="custom-btn btn-8"  PostBackUrl="~/Views/Evaluaciones/Principal.aspx"/>--%>
                <asp:LinkButton ID="btninsertarevalua" runat="server" OnClick="btninsertarevalua_Click" Text="Insertar" CssClass="custom-btn btn-8" style="text-align:center; text-decoration:none;"  ></asp:LinkButton>
                <asp:LinkButton ID="btnmodevalua" runat="server" OnClick="btnmodevalua_Click" Text="Modificar" CssClass="custom-btn btn-8" style="text-align:center; text-decoration:none;" Visible ="false" ></asp:LinkButton>
                <asp:LinkButton ID="btneliminarevalua" runat="server" OnClick="btneliminarevalua_Click" Text="Eliminar" CssClass="custom-btn btn-8" style="text-align:center; text-decoration:none;" Visible ="false" ></asp:LinkButton>
            </div>
   
                        
                    </div>
                </div>
            </div>
             </div>

         <div class="row">
        <h3 id="H1" runat="server" style="text-align:center">Asignados</h3>
    <div class="col-md-12" style="overflow-x: auto;" >
      <div style=" text-align: -webkit-center; margin-top: 1%;">
          <asp:GridView ID="dgvevaluadores" CssClass="table table-striped" style="width: 860px;text-align:center" runat="server"  HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid" OnSelectedIndexChanged="dgvevaluadores_SelectedIndexChanged" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvevaluadores_PageIndexChanging"   >
                    <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No" Visible="false">
                           <ItemTemplate>
                           <asp:Label ID="idasignado"  Width="30px" Text='<%# Eval("codsqorganigrama") %>' runat="server" Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No">
                           <ItemTemplate>
                           <asp:Label ID="id"  Width="30px" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Superior">
                           <ItemTemplate>
                           <asp:Label ID="puesto"  Width="150px" Text='<%# Eval("puesto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Inferior">
                           <ItemTemplate>
                           <asp:Label ID="cantidad"  Width="150px" Text='<%# Eval("subpuesto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                      
                     

                        <asp:ButtonField Text="Editar" CommandName="Select" ItemStyle-Width="150" ItemStyle-CssClass="seleccionarregistrogridview">
                            <ItemStyle Width="150px" >  </ItemStyle>

                            </asp:ButtonField>
                   

                     </Columns>
        <HeaderStyle CssClass="prueba" Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>
          </div>
    </div>
        
  </div>

                   </ContentTemplate>
               <Triggers>

                   <asp:AsyncPostBackTrigger ControlID="btninserta" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID ="btnmodificar" EventName ="Click" />
                     <asp:AsyncPostBackTrigger ControlID ="btneliminar" EventName ="Click" />
               </Triggers>
      </asp:UpdatePanel>
                </div>
                </div>



               
                



               
            </div>
         </div>
      </div>
      <!-- /#page-content-wrapper -->
   </div>
           
    
                 
  <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js'></script><script  src="../../SQEstilos/jsmenu.js"></script>
   

    </form>


   
     
    <script>

        function numeros(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) //if not a number
                { return false } //disable key press    
            }
        }

        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
            especiales = "8-37-39-46";

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }

    </script>

   
   
</body>
       
</html>
