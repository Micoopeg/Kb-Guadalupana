<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarDocumentos.aspx.cs" Inherits="KB_Guadalupana.Views.Procesos.EditarDocumentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Editar</title>
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
            width: 21%;
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
             width:45%;
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
                    <label style="font-size:18px" class="titulos"><b>Editar Documento</b></label>
                 </div><br />

                 <div class="linea"></div>
                <div class="encabezado">
                     <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Código</b></label>
                        <label class="titulos" style="margin-left:46%"><b>Tipo de documento</b></label>
                    </div>
                     <div class="formato">
                        <input id="Codigo" runat="server" type="text" class="formatoinput" placeholder="Ingrese código" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                         <asp:DropDownList id="TipoDocumento" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>
                    </div><br />
                    <div class="formato3">
                        <label class="titulos"><b>Nombre del documento</b></label>
                        <input id="NombreDocumento" runat="server" type="text" class="formatoinput2" placeholder="Ingrese nombre del documento" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                    </div><br />
                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Versión</b></label>
                        <label class="titulos" style="margin-left:46%"><b>Fecha de aprobación</b></label>
                    </div>
                    <div class="formato">
                        <input id="Version" runat="server" type="text" class="formatoinput" placeholder="Ingrese versión" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                         <input id="FechaAprobacion" runat="server" type="date" class="formatoinput"/>
                    </div><br />
                      <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Estado</b></label>
                        <label class="titulos" style="margin-left:18%"><b>Origen</b></label>
                         <label class="titulos" style="margin-left:18%"><b>Dirigido a usuario:</b></label>
                         <label class="titulos" style="margin-left:7%"><b>Tipo de restricción:</b></label>
                    </div>
                     <div class="formato">
                         <asp:DropDownList id="Estado" runat="server" class="formatoinput4" AutoPostBack="false"></asp:DropDownList>
                         <asp:DropDownList id="Origen" runat="server" class="formatoinput4" AutoPostBack="false"></asp:DropDownList>
                         <asp:DropDownList id="UsuarioDirigido" runat="server" class="formatoinput4" AutoPostBack="false"></asp:DropDownList>
                         <asp:DropDownList id="TipoRestriccion" runat="server" class="formatoinput4" AutoPostBack="false"></asp:DropDownList>
                    </div><br />
                     <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Categoría</b></label>
                        <label class="titulos" style="margin-left:46%"><b>Subcategorías</b></label>
                    </div>
                    <div class="formato">
                         <asp:DropDownList id="Categoria" runat="server" class="formatoinput" AutoPostBack="true" OnSelectedIndexChanged="Categoria_SelectedIndexChanged"></asp:DropDownList>
                         <asp:DropDownList id="Subcategoria" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>
                    </div><br />

                     <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos" style="margin-left:70%"><b>Subir nuevo documento</b></label>
                    </div>

                    <div class="formato">
                        <asp:Button ID="VerDocumento" runat="server" CssClass="boton3" Text="Ver Documento" OnClick="VerDocumento_Click"/>
                        <asp:FileUpload id="FileUpload1" runat="server" class="formatoinput"></asp:FileUpload>
                    </div>
                    
                    <br /><br />

                    <div class="formato2">
                        <asp:Button ID="Actualizar" runat="server" CssClass="boton2" Text="Actualizar" OnClick="Actualizar_Click"/>
                        <asp:Button ID="EliminarDocumento" runat="server" CssClass="boton" Text="Eliminar Documento" OnClick="Eliminar_Click"/>
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

    </form>
</body>
</html>
