<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformacionUsuario.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.Mantenimientos.InformacionUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Seguridad Proceso</title>

     <style>
           @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');

            html{
            width:100%;
            height:100%;
            }
        .general{
            display:flex;
            justify-content:center;
            align-content:center;
            align-items:flex-start;
            width:100%;
            height:auto;
            margin-top:25px;
        }

        .formularioCobros{
            display:flex;
            flex-direction:column;
            width:1000px;
        }

        .encabezado{
            padding:25px;
            background-color:lightgray;
            flex-direction:column;
            margin-top:10px;
        }
        .dis
        {
        padding: 8px;
            border: 1px solid #ccc;
            border-radius: 3px;
            margin-bottom: 10px;
            width: 101.5%;
            box-sizing: border-box;
            font-family: montserrat;
            color: #2C3E50;
            font-size: 13px;            
        }
        .dis2
        {
        padding: 8px;
            border: 1px solid #ccc;
            border-radius: 3px;
            margin-bottom: 10px;
            width: 50%;
            box-sizing: border-box;
            font-family: montserrat;
            color: #2C3E50;
            font-size: 13px;            
        }
        .dis3
        {
        padding: 8px;
            border: 1px solid #ccc;
            border-radius: 3px;
            margin-bottom: 10px;
            width: 100%;
            box-sizing: border-box;
            font-family: montserrat;
            color: #2C3E50;
            font-size: 13px;            
        }
        .BuscarM {
          padding: 0px;
          border: 1px solid rgba(0, 0, 0, 0.4);
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.4);
          box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.3), inset 0 10px 10px rgba(255, 255, 255, 0.1);
          border-radius: 0.3em;
          background: #69a43c;
          color: white;
          font-weight: bold;
          cursor: pointer;
          font-size: 13px;
          width:30%;
          height:35px;
        }
         .formatoinput {
            width: 46%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
        }

        .formatoinput2{
            width:98%;
            margin-top:8px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
        }

        .formatoinput3 {
            width: 29%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
        }
        .BuscarM:hover {
          box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.3), inset 0 -10px 10px rgba(255, 255, 255, 0.1);
        }
        .Modulos2{
            display:flex;
            flex-direction:row;
            justify-content:space-around;
            width:100%;
        }
        .row{
            display:flex;
            flex-direction:column;
            width:95%;
            justify-content:center;
            align-content:center;
            align-items:center;
            margin-left:0px;
        }
</style>
    </head>
   <div id="menu" runat="server" class="menu">hb</div>
<body>
     
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">
                <div class="encabezado">
                       <h1 style="color:white">Estado Usuarios Procesos Judiciales</h1>
        <div class="row">

          <div class="Modulos2">
              <asp:DropDownList ID="UsuarioPJ" runat="server" CssClass="dis2" AutoPostBack="false"></asp:DropDownList>
              <asp:Button ID="BuscarUsuario" runat="server" CssClass="BuscarM"  Text="Buscar Usuario" OnClick="BuscarUsuario_Click"></asp:Button>
          </div><br />

        <div class="row">
            <label  style="color:white">Seleccione área</label>
            <asp:DropDownList ID="Area" runat="server" CssClass="dis3" AutoPostBack="true" OnSelectedIndexChanged="Area_SelectedIndexChanged"></asp:DropDownList>
        </div>

          <div class="row">
            <label  style="color:white">Seleccione puesto</label>
            <asp:DropDownList ID="Puesto" runat="server" CssClass="dis3" AutoPostBack="false"></asp:DropDownList>
          </div>

           <div class="row">
               <label style="color:white">Seleccione rol</label>
               <asp:DropDownList ID="Rol" runat="server" CssClass="dis3" AutoPostBack="false"></asp:DropDownList>
           </div>

           <div class="row">
                <label style="color:white">Seleccione Estado</label>
                <asp:DropDownList ID="EstadoU" runat="server" CssClass="dis3" AutoPostBack="false"></asp:DropDownList>
           </div>
       </div>

          <div class="row">
            <asp:Button ID="btninsert" runat="server" CssClass="MGuardar" Text="Guardar Nuevo" OnClick="btninsert_Click"></asp:Button> <br />
              <asp:Button ID="Actualizar" runat="server" CssClass="MGuardar" Text="Actualizar datos" OnClick="Actualizar_Click"></asp:Button> <br />
          </div>
                </div>
            </div>
        </div>
        

          <script>
          $('#<%=UsuarioPJ.ClientID%>').chosen();
          </script>
        <script>
            $('#<%=Area.ClientID%>').chosen();
        </script>
        <script>
            $('#<%=Rol.ClientID%>').chosen();
        </script>
           <script>
               $(document).ready(function () {
                   $('.menu').load('../MenuPrincipal.aspx');
               });
           </script>
    </form>
</body>
</html>
