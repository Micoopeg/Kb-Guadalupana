<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgendaPrin.aspx.cs" Inherits="KBGuada.Views.Index" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css"/>
     

    <title>Agenda Virtual</title>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
   <link rel="stylesheet" href="../../DiseñoCss/estilosav.css" />
    <link rel="stylesheet" href="../../AvDiseños/AvIndex.css" />
    <link rel="stylesheet" href="../../AvDiseños/Botones.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>

    </head>
    

        <style>
        @media screen and (min-width: 600px) and (max-width:1000px) {
    #NombreUsuario{
        font-size:15px;
    }
}


</style>


<body>



    <form id="form1" runat="server">
           
  

           <div id="navegador" class="topnav">
         <a class="active" href="../Sesion/MenuBarra.aspx">Inicio</a>
         <a href="DashBoard.aspx" > Busqueda</a>
          <a  href="NuevaTarea.aspx" > Nueva Tarea</a>
          <a id="asignhome" runat="server" href="Av_AsignarTarea.aspx" > Asignar Tareas A</a>
          <a id="a1" runat="server" href="~/ReportesAv/ReporteUsuarios.aspx" >Reportes </a>
          <a href="../Sesion/CerrarSesion.aspx"  >Cerrar Sesion</a>
             
          <span class="nav-text" style=" font-size: 25px; right: 3%; position: absolute; margin-top:5px; color: white; height: 20px;"><b runat="server" id="NombreUsuario">Edgar Casasola</b></span>
         

      </div>
        <br />
        <br />
                <br> <br>
      <center>
      <h1 id="CABI" runat="server"  style="font-family:Montserrat ;"></h1>
    </center>
                 <br> <br>
        <div class="container-fluid ">

            <div class="row justify-content-center aling-items-center minh-100  ">
         

                <asp:Repeater ID="repetir" runat="server" OnItemDataBound="repetir_ItemDataBound"  EnableViewState="False">
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
                                                

                                               
                                                     <asp:LinkButton  id="btnadd" CssClass="custom-btn btn-8 " runat="server"  ToolTip="Agregar Actividades" OnClick="btnTarea_Click" ClientIDMode="AutoID" >  <i class="fa fa-plus-square " style="font-size:20px" > </i>  </asp:LinkButton>
                                                     <asp:LinkButton id="btnmod" CssClass="custom-btn btn-8" runat="server" ToolTip="Modificar Tarea" OnClick="btnmod_Click" ClientIDMode="AutoID"  >  <i class="fa fa-pencil-square " style="font-size:20px" > </i>  </asp:LinkButton>
                                                 <asp:LinkButton id="btnreas" CssClass="custom-btn btn-8" runat="server" ToolTip="Reasignar" OnClick="btnreasig_Click" ClientIDMode="AutoID" >  <i class="fa fa-group " style="font-size:20px" > </i>  </asp:LinkButton>
                                                 <asp:LinkButton id="btntrack" CssClass="custom-btn btn-8" runat="server"  ToolTip="Ver Tracking"  OnClick="btntrack_Click" ClientIDMode="AutoID">  <i class="fa fa-percent " style="font-size:20px" > </i>  </asp:LinkButton>
                                                   
                                           
                                              

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

                    <asp:Repeater ID="reptir2" runat="server" OnItemDataBound="repetir_ItemDataBound2"  EnableViewState="False">
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
                                                <h3  id="TITLE" runat="server" class="card-title"> <%# Eval("av_titulo") %></h3>
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
                                                

                                               
                                                      <asp:LinkButton id="btnadd" CssClass="custom-btn btn-8 " runat="server"  ToolTip="Agregar Actividades" OnClick="btnTarea_Click" ClientIDMode="AutoID" >  <i class="fa fa-plus-square " style="font-size:20px" > </i>  </asp:LinkButton>
                                                     <asp:LinkButton id="btnmod" CssClass="custom-btn btn-8" runat="server" ToolTip="Modificar Tarea" OnClick="btnmod_Click" ClientIDMode="AutoID"  >  <i class="fa fa-pencil-square " style="font-size:20px" > </i>  </asp:LinkButton>
                                                 <asp:LinkButton id="btnreas" CssClass="custom-btn btn-8" runat="server" ToolTip="Reasignar" OnClick="btnreasig_Click" ClientIDMode="AutoID" >  <i class="fa fa-group " style="font-size:20px" > </i>  </asp:LinkButton>
                                                 <asp:LinkButton id="btntrack" CssClass="custom-btn btn-8" runat="server"  ToolTip="Ver Tracking"  OnClick="btntrack_Click" ClientIDMode="AutoID">  <i class="fa fa-percent " style="font-size:20px" > </i>  </asp:LinkButton>
                                                   
                                           
                                              

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



        


    </form>

  


</body>
     

    <script type="text/javascript"> 

       

        $(document).ready(function () {
            $("div").fadeIn(2000);

        });

    
     </script>

   

</html>
