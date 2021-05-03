<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteUsuarios.aspx.cs" Inherits="KBGuada.Reportes.ReporteUsuarios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
       <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
     <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>

    <title>Reportes</title>

     <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link type="text/css" rel="stylesheet" href="../AvDiseños/EstilosDash.css" />
       <link rel="stylesheet" href="../DiseñoCss/estilosav.css" />
    <link rel="stylesheet" href="../AvDiseños/Botones.css" />
    <link rel="stylesheet" href="../AvDiseños/estiloalert.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>

</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

           <div id="navegador" class="topnav">
            <a class="active" href="../Sesion/Inicio.aspx">Inicio</a>
               <a href="../Views/Agenda/AgendaPrin.aspx" > Agenda</a>
           <a href="../Views/Agenda/DashBoard.aspx" > Busqueda</a>
      <a  href="../Views/Agenda/NuevaTarea.aspx" > Nueva Tarea</a>
         <a id="ASIGHOME" runat="server" href="~/Views/Agenda/Av_AsignarTarea.aspx" > Asignar Tarea A</a>
          <a href="../Views/Sesion/CerrarSesion.aspx" style="">Cerrar Sesion</a>
          <span class="nav-text" style=" font-size: 25px; right: 3%; position: absolute; margin-top:5px; color: white; height: 20px;"><b runat="server" id="NombreUsuario"></b> </span>
         
      </div>

          <br />
        <br />
          <div class="container justify-content-center aling-items-center minh-100" style="max-width: 500px; max-height:30vh;">

              <div class="form-group" style="text-align: center">



                  <div class="form-group" style="text-align: center">
                  <label>
               <h1 style="border-top: double; border-bottom: double;font-size: 37px; font-family: Montserrat;  padding-bottom: 10px; " >Informes de Usuarios</h1>

                </label>
                  </div>

                  <div id="cabusuario" runat="server" class="form-group" style="text-align: center">
           
                <label for="exampleInputEmail1">
                    <h3>Usuario</h3>
                </label>
               <%-- <input  type="text"  class="form-control form-control-lg"  aria-describedby="emailHelp" placeholder="Ingrese el Titulo de la Tarea" style="text-align: center; "   />--%>
            <asp:TextBox ID="coduser" runat="server" CssClass="form-control form-control-lg" placeholder="Ingrese el Usuario" style="text-align: center; " OnTextChanged="activar_TextChanged" AutoPostBack="true"  ></asp:TextBox>
                  </div>
                  <div class="form-group" style="text-align: center">
                <label for="exampleInputPassword1">
                    <h3>Fecha de inicio</h3>
                </label>

                <input id="AVFECHAINI" runat="server" type="date"   class="form-control"   style="text-align: center;" />

            </div>
                   <div class="form-group" style="text-align: center">
                <label for="exampleInputPassword1">
                    <h3>Fecha Final</h3>
                </label>

                <input id="AVFECHAFIN" runat="server" type="date" class="form-control"   style=" text-align: center;"/>
            </div>

                    <div class="container">

              <asp:LinkButton ID="btnmostrar" runat="server" Cssclass="custom-btn btn-8" OnClick="btnmostrar_Click"  ><i class="fa fa-user " style="font-size:20px" > </i>&nbsp;Usuario </asp:LinkButton>
               <asp:LinkButton ID="btnmostrartodo" runat="server" Cssclass="custom-btn btn-8" OnClick="btnmostrartodo_Click" ><i class="fa fa-users " style="font-size:20px" > </i>&nbsp;Usuarios </asp:LinkButton>
               <asp:LinkButton ID="btnsolouser" runat="server" Cssclass="custom-btn btn-8" OnClick="btnmostrartodouno_Click" ><i class="fa fa-user " style="font-size:20px" > </i>&nbsp;Mi Reporte </asp:LinkButton>
                 <asp:LinkButton ID="btnmontos" runat="server" Cssclass="custom-btn btn-8" OnClick="btnmontos_Click" ><i class="fa fa-user " style="font-size:20px" > </i>&nbsp;Montos </asp:LinkButton>
            


            </div>

                  </div>
              </div>
        
        <br /><br /><br />
                   <center>
                  <div class="container " style="margin-top: 10%;"  >
     <rsweb:ReportViewer ID="ReportViewer1" runat="server" style="min-width:833px; max-width:937px;" ></rsweb:ReportViewer>

                  </div>
                  

    </center>



      
    </form>

  




</body>
</html>
