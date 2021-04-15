<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="KBGuada.Views.session.DashBoard"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css"/>
     

    <title>Busqueda</title>

     <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link type="text/css" rel="stylesheet" href="../../AvDiseños/EstilosDash.css" />
       <link rel="stylesheet" href="../../DiseñoCss/estilosav.css" />
    <link rel="stylesheet" href="../../AvDiseños/Botones.css" />
    <link rel="stylesheet" href="../../AvDiseños/estiloalert.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

             <div id="navegador" class="topnav ">
       <a class="active" href="../Sesion/MenuBarra.aspx">Inicio</a>
                  <a href="AgendaPrin.aspx"> Agenda</a>
          <a href="NuevaTarea.aspx" > Nueva Tarea</a>
             <a id="ASIGHOME" runat="server" href="Av_AsignarTarea.aspx" > Asignar Tareas A</a>
          <a href="../Sesion/CerrarSesion.aspx">Cerrar Sesion</a>
            
          <span class="nav-text" style=" font-size: 25px; right: 3%; position: absolute; margin-top:5px; color: white; height: 20px;"><b runat="server" id="NombreUsuario">Edgar Casasola</b></span>
         

      </div>
    
             <div class="form-control" style="text-align:center;" >
            
               <h1 style="font-size: 37px; font-family: Montserrat;  padding-bottom: 10px; color:black; text-align:center;" >Busqueda</h1>
                 
                </div>



       <div id="main-container">

           <div id="alerta" runat="server" class="alert" style="display:none;"  >
               <span class="closebtn"  onclick="this.parentElement.style.display='none';">&times;</span>
               <strong>¡Alerta!</strong> Por Favor llenar los campos para buscar.
           </div>



      
             <div id="ENCABCIF" runat="server" class="tab tabSelected" style="border-top: double; border-bottom: double;"> 
                <h3>Buscar por CIF</h3>
                <a href="#3" class="notification"></a>         
            </div>
            <div id="BODYCIF" runat="server" class="tabBody" >
                <ul class="tabBodyOptions">
                   <input id="BUSCARCIF" runat="server" style=" max-width: 437px;margin-left: 5px;margin-top:4px;" class="w3-input w3-border w3-round" name="first"  maxlength="6"  oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" type="number"/>
                </ul>                
            </div>
            <div id="ENCABAREA" runat="server" class="tab tabNoSelected" style="border-top: double; border-bottom: double;" > 
                <h3>Buscar por Area</h3>
                <a href="#1" class="notification"></a>
            </div>
            <div id="BODYAREA" runat="server" class="tabBody"  >
                <ul class="tabBodyOptions">
                    <center>
                     <asp:DropDownList  id="DropDownArea" runat="server"  class="form-control" AutoPostBack="false"  style=" max-width:435px;margin-left: 5px; margin-top:8px; width:200px; height:28px ; "  ></asp:DropDownList>
                   </center>
                </ul>                
            </div>

            <div id="ENCABFECHA" runat="server" class="tab tabNoSelected" style="border-top: double; border-bottom: double;"> 
                <h3>Buscar por Fecha</h3>
                <a href="#2" class="notification"></a>
            </div>
            <div id="BODYFECHA" runat="server" class="tabBody" > 
                <ul class="tabBodyOptions">
                   <input id="FECHAIBUSCAR" runat="server" style=" max-width: 215px;margin-left: 10px;margin-top:1px;" class="w3-input w3-border w3-round" name="first" type="date">
                   <input id="FECHAFBUSCAR" runat="server" style=" max-width: 210px;margin-left: 230px;margin-top:-35px;" class="w3-input w3-border w3-round" name="first" type="date">
                </ul>                
            </div>

            <div id="ENCABESTADO" runat="server" class="tab tabNoSelected" style="border-top: double; border-bottom: double;"> 
                <h3>Buscar por Proceso</h3>
                <a href="#3" class="notification"></a>                
            </div>
            <div id="BODYESTADO" runat="server" class="tabBody" >
                <ul class="tabBodyOptions">
                    <center>
                     <asp:DropDownList  id="DropDownEstado" runat="server"   class="form-control" AutoPostBack="false"  style=" max-width:435px;margin-left: 5px; margin-top:8px; width:200px; height:28px ; "  ></asp:DropDownList>
                   </center>
                        <%-- <input style=" max-width:435px;margin-left: 5px;margin-top:4px;" class="w3-input w3-border w3-round" name="first" type="text">--%>
                </ul>                
            </div>
     <div class="container" style="text-align:center;">

              
                <asp:LinkButton ID="btnbuscar" runat="server" CssClass="custom-btn btn-8 " OnClick="btnbuscar_Click" Text="Buscar" ClientIDMode="Static"></asp:LinkButton>
            


            </div>

        </div> 
        <%-- para buscar tareas por ESTADO Y POR RANGO DE FECHAS --%>
         
        <br /><br /><br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"  >
            <ContentTemplate>
                <center>
      <h1 id="CABI" runat="server"  style="font-family:Montserrat ;"></h1>
    </center>
                 <br/> <br/> 
        <div class="container-fluid ">

            <div class="row justify-content-center aling-items-center minh-100  ">
         

                <asp:Repeater ID="repetidor1" runat="server" OnItemDataBound="repetir_ItemDataBound"  >
                    <ItemTemplate>


                        <div class="col-md-auto" style="height:450px">
                            <br />
                          
                           
                            <%--separadores entre cartas--%>
                            <div class="carta-box">
                                <div class="carta">
                                    <div class="cara">


                                        <div id="cartafront" runat="server" class="card text-center "  style=" max-width: 209px; max-height: 350px; width: 209px; height: 350px;">
                                            <div class="card-header">
                                                <asp:Label ID="lblId" runat="server" Visible="false" Text='<%# Eval("codavtarea") %>'></asp:Label>
                                                <%-- <asp:LinkButton  ID="btnactividades" runat="server" OnClick="btnTarea_Click"  ></asp:LinkButton>
                                                --%>
                                                <h2>Fecha Inicial </h2>
                                                <h3> <%# Eval("fechaini") %></h3>
                                            </div>
                                            <div class="card-body">
                                                <h3 id="TITLE" runat="server" class="card-title"> <%# Eval("av_titulo") %></h3>
                                                <br />
                                              <h5 class="card-text"><%# Eval("av_descripcion") %></h5>
                                            </div>
                                            <div class="card-footer text-muted">
                                               <h2> Fecha Final </h2>
                                                <h3> <%# Eval("fechafin") %></h3>

                                                
                                            </div>
                                        </div>

                                    </div>

                                     <div class="cara detras">
                                        <div class="card text-center " style=" max-width: 209px; max-height: 350px; width: 209px; height: 350px;">
                                            <div class="card-header">
                                               <h2>Fecha Inicial </h2>
                                                <h3> <%# Eval("fechaini") %></h3>
                                            </div>
                                            <div class="card-body">
                                                

                                               
                                                     <asp:LinkButton ClientIDMode="AutoID" id="btnadd" CssClass="custom-btn btn-8 " runat="server"  ToolTip="Agregar Actividades" OnClick="btnTarea_Click"  >  <i class="fa fa-plus-square " style="font-size:20px" > </i>  </asp:LinkButton>
                                                     <asp:LinkButton ClientIDMode="AutoID" id="btnmod" CssClass="custom-btn btn-8" runat="server" ToolTip="Modificar Tarea" OnClick="btnmod_Click"   >  <i class="fa fa-pencil-square " style="font-size:20px" > </i>  </asp:LinkButton>
                                                 <asp:LinkButton ClientIDMode="AutoID" id="btnreas" CssClass="custom-btn btn-8" runat="server" ToolTip="Reasignar" OnClick="btnreasig_Click"  >  <i class="fa fa-group " style="font-size:20px" > </i>  </asp:LinkButton>
                                                 <asp:LinkButton ClientIDMode="AutoID"  id="btntrack" CssClass="custom-btn btn-8" runat="server"  ToolTip="Ver Tracking" OnClick="btntrack_Click" >  <i class="fa fa-percent " style="font-size:20px" > </i>  </asp:LinkButton>
                                                   
                                           
                                              

                                            </div>
                                            <br /><br />
                                             <div class="card-footer text-muted">
                                               <h2> Fecha Final </h2>
                                                <h3> <%# Eval("fechafin") %></h3>
                                            </div>
                                        </div>


                                    </div>
                                    
                                </div>
                            </div>

                        </div>

                        <%-- Area de botones --%>
                      

                    </ItemTemplate>


                </asp:Repeater>

                 <asp:Repeater ID="repetidor2" runat="server" OnItemDataBound="repetir_ItemDataBound2"  >
                    <ItemTemplate>


                        <div class="col-md-auto" style="height:450px">
                            <br />
                          
                           
                            <%--separadores entre cartas--%>
                            <div class="carta-box">
                                <div class="carta">
                                    <div class="cara">


                                        <div id="cartafront" runat="server" class="card text-center "  style=" max-width: 209px; max-height: 350px; width: 209px; height: 350px;">
                                            <div class="card-header">
                                                <asp:Label ID="lblId" runat="server" Visible="false" Text='<%# Eval("codavtarea") %>'></asp:Label>
                                                <%-- <asp:LinkButton  ID="btnactividades" runat="server" OnClick="btnTarea_Click"  ></asp:LinkButton>
                                                --%>
                                                <h2>Fecha Inicial </h2>
                                                <h3> <%# Eval("fechaini") %></h3>
                                            </div>
                                            <div class="card-body">
                                                <h3 id="TITLE" runat="server" class="card-title"> <%# Eval("av_titulo") %></h3>
                                                <br />
                                              <h5 class="card-text"><%# Eval("av_descripcion") %></h5>
                                            </div>
                                            <div class="card-footer text-muted">
                                               <h2> Fecha Final </h2>
                                                <h3> <%# Eval("fechafin") %></h3>

                                                
                                            </div>
                                        </div>

                                    </div>

                                     <div class="cara detras">
                                        <div class="card text-center " style=" max-width: 209px; max-height: 350px; width: 209px; height: 350px;">
                                            <div class="card-header">
                                               <h2>Fecha Inicial </h2>
                                                <h3> <%# Eval("fechaini") %></h3>
                                            </div>
                                            <div class="card-body">
                                                

                                               
                                                     <asp:LinkButton ClientIDMode="AutoID" id="btnadd" CssClass="custom-btn btn-8 " runat="server"  ToolTip="Agregar Actividades" OnClick="btnTarea_Click"  >  <i class="fa fa-plus-square " style="font-size:20px" > </i>  </asp:LinkButton>
                                                     <asp:LinkButton ClientIDMode="AutoID" id="btnmod" CssClass="custom-btn btn-8" runat="server" ToolTip="Modificar Tarea" OnClick="btnmod_Click"   >  <i class="fa fa-pencil-square " style="font-size:20px" > </i>  </asp:LinkButton>
                                                 <asp:LinkButton ClientIDMode="AutoID" id="btnreas" CssClass="custom-btn btn-8" runat="server" ToolTip="Reasignar" OnClick="btnreasig_Click"  >  <i class="fa fa-group " style="font-size:20px" > </i>  </asp:LinkButton>
                                                 <asp:LinkButton ClientIDMode="AutoID"  id="btntrack" CssClass="custom-btn btn-8" runat="server"  ToolTip="Ver Tracking" OnClick="btntrack_Click" >  <i class="fa fa-percent " style="font-size:20px" > </i>  </asp:LinkButton>
                                                   
                                           
                                              

                                            </div>
                                            <br /><br />
                                             <div class="card-footer text-muted">
                                               <h2> Fecha Final </h2>
                                                <h3> <%# Eval("fechafin") %></h3>
                                            </div>
                                        </div>


                                    </div>
                                    
                                </div>
                            </div>

                        </div>

                        <%-- Area de botones --%>
                      

                    </ItemTemplate>


                </asp:Repeater>
            </div>


        </div>


            </ContentTemplate>
            <Triggers>

                <asp:AsyncPostBackTrigger ControlID="btnbuscar" EventName="Click"  />
           
            </Triggers>
        </asp:UpdatePanel>               
      

         <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script><script  src="../../AvDiseños/scriptdas.js"></script>
    </form>

 
</body>


</html>
