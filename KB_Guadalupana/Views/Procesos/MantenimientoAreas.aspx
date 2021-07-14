<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoAreas.aspx.cs" Inherits="KB_Guadalupana.Views.Procesos.MantenimientoAreas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Áreas</title>
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
                    <label style="font-size:18px" class="titulos"><b>Mantenimiento de Áreas</b></label>
                 </div><br />

                  <div class="linea"></div>

                <div class="encabezado">
                    <div class="formato3">
                        <label class="titulos"><b>Seleccione acción a realizar</b></label>
                        <asp:DropDownList id="Accion" runat="server" class="formatoinput" AutoPostBack="true" OnSelectedIndexChanged="Accion_SelectedIndexChanged"></asp:DropDownList>
                    </div><br />

                    <div id="CrearCategoria" runat="server">

                        <div id="actualizarcat" runat="server">
                             <label class="titulos"><b>Categoría</b></label>
                             <div class="formato">
                                <asp:DropDownList id="CategoriaBuscar" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>
                                 <asp:Button ID="BuscarCategoria" runat="server" CssClass="boton" Text="Buscar Categoría" OnClick="BuscarCategoria_Click"/>
                            </div><br />
                        </div>

                        <div class="formato">
                            <label class="titulos"><b>Nombre de categoría</b></label>
                            <input id="NombreCategoria" runat="server" type="text" class="formatoinput2" placeholder="Ingrese nombre de categoría" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div>
                    </div><br /><br />

                    

                    <div id="CrearSubcategoria" runat="server">
                            <div id="actualizarsub" runat="server">
                             <label class="titulos"><b>Subcategoría</b></label>
                             <div class="formato">
                                <asp:DropDownList id="SubcategoriaBuscar" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>
                                 <asp:Button ID="BuscarSubcategoria" runat="server" CssClass="boton" Text="Buscar Subcategoría" OnClick="BuscarSubcategoria_Click"/>
                            </div><br />
                        </div>

                        <div class="formato3">
                            <label class="titulos"><b>Categoría a la que pertenece</b></label>
                            <asp:DropDownList id="Categoria" runat="server" class="formatoinput" AutoPostBack="false"></asp:DropDownList>
                        </div><br />
                         <div class="formato3">
                            <label class="titulos"><b>Nombre de subcategoría</b></label>
                             <input id="Subcategoria" runat="server" type="text" class="formatoinput2" placeholder="Ingrese nombre de subcategoría" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                               <input id="IdSub" runat="server" type="text" class="formatoinput2" visible="false"/>
                        </div><br />
                    </div>

                    <div class="formato2">
                        <asp:Button ID="GuardarCategoria" runat="server" CssClass="boton" Text="Guardar Categoría" OnClick="GuardarCategoria_Click"/>
                        <asp:Button ID="ActualizarCategoria" runat="server" CssClass="boton" Text="Actualizar Categoría" OnClick="ActualizarCategoria_Click"/>
                        <asp:Button ID="GuardarSubcategoria" runat="server" CssClass="boton" Text="Guardar Subcategoría" OnClick="GuardarSubcategoria_Click"/>
                        <asp:Button ID="ActualizarSubcategoria" runat="server" CssClass="boton" Text="Actualizar Subcategoría" OnClick="ActualizarSubcategoria_Click"/>
                    </div>
                </div>

                <div class="linea"></div>
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
