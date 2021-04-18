<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Av_Subtareas.aspx.cs" Inherits="KBGuada.Views.session.Av_Subtareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0/css/bootstrap.css'/>
    <link rel="stylesheet" href="../../AvDiseños/EstilosAVActividad.css" />
    <link rel="stylesheet" href="../../AvDiseños/Botones.css" />
             
    <title>Actividades</title>
</head>




<body>
    <form id="form3" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div class="topnav">
    <a class="active" href="../Sesion/MenuBarra.aspx">Inicio</a>
         <a href="AgendaPrin.aspx"> Agenda</a>
         <a href="DashBoard.aspx"> Busqueda</a>
  <a href="NuevaTarea.aspx"> Nueva Tarea</a>
  <a id="ASIGHOME" runat="server" href="Av_AsignarTarea.aspx"> Asignar Tarea A</a>
  <a href="../Sesion/CerrarSesion.aspx" style="">Cerrar Sesion</a>
   <span class="nav-text" style=" font-size: 25px; right: 3%; position: absolute; margin-top:5px; color: white; height: 20px;"><b runat="server" id="NombreUsuario">Edgar Casasola</b></span>
         
</div>

        <div class="container justify-content-center aling-items-center minh-100" style="max-width: 1000px"; id="container">
  <div class="row">
    <div class="col">
      <br> <br>
      <center>
      <h1>Planifica tus Actividades</h1>
    </center>

        
                 <div id="cabredito" runat="server" class="form-group" style="text-align: center;" >
           
                <label for="exampleInputEmail1">
                    <h3>Numero de Credito</h3>
                </label>

                      <input id="Credit" runat="server" type="number" class="form-control form-control-lg" placeholder="Ingrese el numero de credito" style="text-align: center;     width: auto;  margin: auto; "  />
                      
               <%-- <input  type="text"  class="form-control form-control-lg"  aria-describedby="emailHelp" placeholder="Ingrese el Titulo de la Tarea" style="text-align: center; "   />--%>
           
                       <asp:LinkButton ID="btncredito" runat="server" ClientIDMode="AutoID" CssClass="custom-btn btn-8" OnClick="btncredito_Click"> Insertar Credito</asp:LinkButton>
                  </div>
                    <div class="form-group" style="text-align: center">
                <label for="exampleFormControlTextarea1">
                    <h4>Comentario de tarea</h4>
                </label>
                <textarea id="AVCOMENT" runat="server" class="form-control form-control-lg"   rows="3" maxlength="130" style="width: auto; margin: auto; font-size:15px"></textarea>
                <asp:LinkButton ID="terminar" runat="server" ClientIDMode="AutoID" CssClass="custom-btn btn-8" OnClick="insertarcomentario_Click"> Terminar Tarea</asp:LinkButton>
                 <asp:LinkButton ID="btnanular" runat="server" ClientIDMode="AutoID" CssClass="custom-btn btn-8" OnClick="anular_Click" Visible ="false"> Anular Tarea</asp:LinkButton>
            </div>
          
           
       

        
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
        <div style="overflow-x:auto;">
    <table class="table table-dark table-new-task table-hove table-striped ">
        <tr>
          <td class="input-group">
            <input id="INACTIVIDAD" runat="server" class="form-control new-task-input " type="text" placeholder="Agregar Actividades" style="width:250px" required/>
          </td>
               <td> 
          <center>
          <input type="datetime-local" min='<%=fechamaxconcat%>' id="FECHAINIC" runat="server"   required />
        </center>
        </td>
            <td> 
          <center>
          <input type="datetime-local"  id="FECHAFINAL" runat="server" required />
        </center>
        </td>
          <td class="td-btn">
            <%--<input id="BTNINSERT" type="button" onclick="actividadespage()"  class="btn btn-primary "   value="Agregar Actividad "   /> --%>
              <asp:Button ID="BTNINSERT"  runat="server" OnClick="btnInsertarsub_Click" CssClass="btn btn-primary" Text="Agregar nueva actividad"  />
       
              
          </td>
         
        </tr>
      </table>
    </div>

    <div style="overflow-x:auto;">

    
      
      <table class="table table-hove table-striped table-bordered table-todo">
        <thead>
          <tr>
           
            <th >#</th>
            <th>Atividad</th>
            <th>fecha inicio</th>
            <th>fecha Final</th>
            <th >Accion</th>
       
          </tr>
        </thead>
        <tbody>


           

                    <asp:Repeater ID="repetirsub" runat="server">

                        
                        <ItemTemplate>

                            <asp:UpdatePanel ID="UpdatePane2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                            <tr class="table-todo-row">
                                <asp:Label ID="idsubtarea" runat="server" Visible="false" Text='<%# Eval("codsubtarea") %>'></asp:Label>
                                <td class="num"><%# Eval("codsubtarea") %></td>
                                <td><%# Eval("av_descsubtarea") %></td>
                                <td>
                                    <center>
        <%--<input type="datetime-local"  id="datei"  value="<%# Eval("av_fechaini") %>"  />--%>
            <input type="text" id="datei" value="<%# Eval("av_fechaini") %>"  disabled />
      </center>
                                </td>
                                <td>
                                    <center>
         <%-- <input type="datetime-local"  id="datef"   value="<%# Eval("av_fechafin") %>"/>--%>
               <input type="text" id="datef" value="<%# Eval("av_fechafin") %>"  disabled />
        </center>
                                </td>
                                <td style="text-align: center;">

                                    <asp:LinkButton ID="btnterminar" runat="server" ClientIDMode="AutoID" CssClass="btn btn-success btn-copy" OnClick="btnlisto_Click"> Terminar</asp:LinkButton>
                                    <%--<asp:LinkButton ID="btneliminar"  runat="server" ClientIDMode="AutoID" CssClass="btn btn-success btn-copy">Eliminar </asp:LinkButton>--%>
                                  
                                </td>
                            </tr>
                                    </ContentTemplate>
                                <Triggers>

                                    <asp:AsyncPostBackTrigger ControlID="btnterminar" EventName="Click"/>

                                </Triggers>
                                </asp:UpdatePanel>

                        </ItemTemplate>



                    </asp:Repeater>

                




        </tbody>
      </table>

    </div>
                   
                    
</ContentTemplate>

                <Triggers>

                    <asp:AsyncPostBackTrigger ControlID="BTNINSERT" EventName="Click" />
            
                    
                </Triggers>
            </asp:UpdatePanel>
    </div>
  </div>
</div>


      



            <%-- <asp:LinkButton  ID="btnactividades" runat="server" OnClick="btnInsertarsub_Click"  ></asp:LinkButton>--%>
        








        
    </form>
	
     <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script>
<script src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0/js/bootstrap.min.js'></script><script src="../../DiseñosAv/script.js" ></script>
	
</body>


     
    

</html>
