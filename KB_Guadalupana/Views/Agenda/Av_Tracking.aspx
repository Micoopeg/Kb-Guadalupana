<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Av_Tracking.aspx.cs" Inherits="KBGuada.Views.session.Av_Tracking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0/css/bootstrap.css'/>
    <link rel="stylesheet" href="../../AvDiseños/EstilosAVActividad.css" />
             
    <title>Tracking</title>
</head>
<body>
    <form id="form1" runat="server">
      
         
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="topnav">
      <a class="active" href="../Sesion/MenuBarra.aspx">Inicio</a>
         <a href="AgendaPrin.aspx"> Agenda</a>
        <a href="DashBoard.aspx"> Busqueda</a>
  <a href="NuevaTarea.aspx"> Nueva Tarea</a>
        <a id="ASIGHOME" runat="server" href="Av_AsignarTarea.aspx"> Asignar Tareas A</a>
  <a href="../Sesion/CerrarSesion.aspx" style="">Cerrar Sesion</a>
 <span class="nav-text" style=" font-size: 25px; right: 3%; position: absolute; margin-top:5px; color: white; height: 20px;"><b runat="server" id="UsuarioNom">Edgar Casasola</b></span>
      
</div>

        <div class="container justify-content-center aling-items-center minh-100" style="max-width: 1000px"; id="container">
            <div class="row">
                <div class="col">
                    <br>
                    <br>
                    <center>
      <h1>Actividades Realizadas</h1>
    </center>



    <div style="overflow-x:auto;">

    
      
      <table class="table table-hove table-striped table-bordered table-todo">
        <thead>
          <tr>
           
            <th >#</th>
            <th>Atividad</th>
            <th>fecha inicio</th>
            <th>fecha Final</th>
          </tr>
        </thead>
        <tbody>


                    <asp:Repeater ID="repetirsub" runat="server">

                        
                        <ItemTemplate>

                           
                            <tr class="table-todo-row">
                
                                <td class="num"><%# Eval("codsubtarea") %></td>
                                <td><%# Eval("av_descsubtarea") %></td>
                                <td>
                                    <center>
                
                        <input type="text" id="datei" value="<%# Eval("av_fechaini") %>"  disabled />
            </center>
                        </td>
                                <td>
                                    <center>
                                             
                                <input type="text" id="datef" value="<%# Eval("av_fechaini") %>"  disabled />
                        </center>
                         </td>

                    </tr>


                </ItemTemplate>



                    </asp:Repeater>

        </tbody>
      </table>

    </div>
                   
                    

  </div>
</div>



    </form>
        
	
     <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script>
<script src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0/js/bootstrap.min.js'></script><script src="../../DiseñosAv/script.js" ></script>





</body>
</html>
