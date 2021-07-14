<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoUsuarios.aspx.cs" Inherits="KB_Guadalupana.Views.Procesos.MantenimientoUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
    <title>Usuarios</title>
     <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:"Montserrat";
        }

        .formularioCobros{
            display:flex;
            flex-direction:column;
            width:750px;
            justify-items: center;
            align-content: center;
            justify-content: center;
            align-items: center;
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

        .encabezado{
            padding:25px;
            flex-direction:column;
            margin:15px;
            width: 80%;
        }

        .linea{
            border-bottom: 3px #69A43C solid;
            height:5px;
            width:100%;
        }

         .formatoinput {
            width: 46%;
            border: 0.5px black solid;
            height: 30px;
            display: flex;
            align-items: center;
            align-content:center;
        }

        .formatoinput2{
            width:99%;
            margin-top:8px;
            border: 0.5px black solid;
            height: 30px;
        }

        .formatoinput3 {
            width: 29%;
            border: 0.5px black solid;
            height: 30px;
            display: flex;
            align-items: center;
            align-content:center;
        }

          .formatoinput4 {
            width: 23%;
            border: 0.5px black solid;
            height: 30px;
            display: flex;
            align-items: center;
            align-content:center;
        }

        .formato{
            display:flex;
            flex-direction:row;
            justify-content: space-between;
            width:100%;
        }

        .formato2{
            display:flex;
            flex-direction:row;
            justify-content: space-around;
        }

        .formato3{
            display:flex;
            flex-direction:column;
            width:100%;
        }

         .titulos{
             font-size:13px;
             display:flex;
            align-items:center;
            align-content:center;
         }

        .formatoTitulo{
            display:flex;
            flex-direction:row;
            justify-content: flex-start;
        }

                .boton{
            background-color: #69A43C;
            color: white;
            border:0px;
            width:45%;
            margin-top:15px;
            height: 30px;
        }

        .boton:hover {
             background-color: white; 
             color: black; 
             border: 2px solid #69A43C;
        }

         .boton2{
             background-color: white; 
             color: black; 
             border: 2px solid #69A43C;
            width:45%;
            margin-top:15px;
            height: 30px;
        }

        .boton2:hover {
            background-color: #69A43C;
            color: white;
            border:0px;
        }

         .boton3{
            background-color: #003A6E;
            color: white;
            border:0px;
             width:22%;
             display: flex;
             align-items: center;
            align-content:center;
            justify-content:center;
             height: 25px;
        }

        .boton3:hover {
             background-color: white; 
             color: black; 
             border: 2px solid #003A6E;
            
        }

        .tabla{
            width:100%;
        }

      .tabla td{
            padding:7px;
        }
    </style>
</head>
<body>
    <div id="menu" runat="server" class="menu"></div>
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">
                 <div style="display:flex; justify-content:center">
                    <label style="font-size:18px" class="titulos"><b>Mantenimiento de Usuarios</b></label>
                 </div><br />

                  <div class="linea"></div>

                <div class="encabezado">
                     <div class="formato">
                        <asp:DropDownList ID="UsuarioPJ" runat="server" CssClass="formatoinput" AutoPostBack="false"></asp:DropDownList>
                        <asp:Button ID="BuscarUsuario" runat="server" CssClass="boton" Text="Buscar Usuario" OnClick="BuscarUsuario_Click"></asp:Button>
                     </div><br />

                    <div id="datos" runat="server">
                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Categoría</b></label>
                        <label class="titulos" style="margin-left:43%"><b>Subcategoría</b></label>
                    </div>
                     <div class="formato">
                        <asp:DropDownList ID="Categoria" runat="server" CssClass="formatoinput" AutoPostBack="true" OnSelectedIndexChanged="Categoria_SelectedIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="Subcategoria" runat="server" CssClass="formatoinput" AutoPostBack="false"></asp:DropDownList>
                    </div><br />

                    <div class="formato3">
                        <label class="titulos"><b>Puesto</b></label>
                        <asp:DropDownList ID="Puesto" runat="server" CssClass="formatoinput2" AutoPostBack="false"></asp:DropDownList>
                    </div><br />

                     <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Tipo de usuario</b></label>
                        <label class="titulos" style="margin-left:38%"><b>Estado</b></label>
                    </div>
                    <div class="formato">
                        <asp:DropDownList ID="TipoUsuario" runat="server" CssClass="formatoinput" AutoPostBack="false"></asp:DropDownList>
                        <asp:DropDownList ID="Estado" runat="server" CssClass="formatoinput" AutoPostBack="false"></asp:DropDownList>
                    </div><br />
                        </div>

                      <div class="formato2">
                        <asp:Button ID="Actualizar" runat="server" CssClass="boton" Text="Actualizar" OnClick="Actualizar_Click"/>
                        <asp:Button ID="btninsert" runat="server" CssClass="boton" Text="Guardar" OnClick="btninsert_Click"/>
                    </div>
                </div>

                 <div class="linea"></div><br /><br />
            </div>
        </div>

        <script>
               $(document).ready(function () {
                   $('.menu').load('MenuPrincipal.aspx');
               });
        </script>

        <script>
            $('#<%=UsuarioPJ.ClientID%>').chosen();
            $('#<%=Puesto.ClientID%>').chosen();
        </script>
        
    </form>
</body>
</html>
