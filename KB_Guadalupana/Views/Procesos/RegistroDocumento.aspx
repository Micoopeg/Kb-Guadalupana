<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroDocumento.aspx.cs" Inherits="KB_Guadalupana.Views.Procesos.RegistroDocumento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Registro de la Documentación</title>
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
                    <label style="font-size:18px" class="titulos"><b>Registro de la Documentación</b></label>
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
                        <input id="NombreDocumento" runat="server" type="text" class="formatoinput2" placeholder="Ingrese nombre del documento" maxlength="500" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
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

                    <div class="formato">
                         <asp:FileUpload id="FileUpload1" runat="server" class="formatoinput2"></asp:FileUpload>
                    </div>
                    
                    <br /><br />

                    <div class="formato2">
                        <asp:Button ID="Guardar" runat="server" CssClass="boton" Text="Guardar" OnClick="Guardar_Click"/>
                    </div>
                </div>
                 <div class="linea"></div><br /><br />

                <div class="encabezado" style="width:140%">
                    <div style="justify-content: center;display:flex" class="formato">
                        <div>
                        <asp:GridView ID="gridViewDocumentos" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedDocumento" BorderStyle="Solid" AllowPaging="true" PageSize="10" OnPageIndexChanging="documento_PageIndexChanging">
                             <Columns>
                               <asp:TemplateField ControlStyle-CssClass="diseño" visible="false" HeaderText="Código">
                                    <ItemTemplate>
                                       <asp:Label ID="lblid" Text='<%# Eval("Id") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="Código">
                                    <ItemTemplate>
                                       <asp:Label ID="lblcodigo" Text='<%# Eval("Codigo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Tipo documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lbltipodoc" Text='<%# Eval("TipoDocumento") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnombredoc" Width="200px" Text='<%# Eval("Nombre") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Versión">
                                    <ItemTemplate>
                                       <asp:Label ID="lblversion" Text='<%# Eval("Version") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Fecha Aprobación">
                                    <ItemTemplate>
                                       <asp:Label ID="lblfecha" Text='<%# Eval("Fecha", "{0:d}") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Estado">
                                    <ItemTemplate>
                                       <asp:Label ID="lblestado" Text='<%# Eval("Estado") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                     <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Origen">
                                    <ItemTemplate>
                                       <asp:Label ID="lblorigen" Text='<%# Eval("Origen") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Usuario">
                                    <ItemTemplate>
                                       <asp:Label ID="lblusuario" Width="70px" Text='<%# Eval("Usuario") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Categoría">
                                    <ItemTemplate>
                                       <asp:Label ID="lblcategoria" Text='<%# Eval("Categoria") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Restricción">
                                    <ItemTemplate>
                                       <asp:Label ID="lblrestriccion" Text='<%# Eval("Restriccion") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                     <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Subcategoria">
                                    <ItemTemplate>
                                       <asp:Label ID="lblsubcategoria" Text='<%# Eval("Subcategoria") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Ver Documento" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="Black">
                                    <ItemStyle Width="80px" ForeColor="Black"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#003563"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div>
                </div>
            </div>
        </div>

           <script>
               $(document).ready(function () {
                   $('.menu').load('MenuPrincipal.aspx');
               });
           </script>

           <script>
               var texto1 = document.querySelector('#Version');
               var texto2 = document.querySelector('#CIF');

                texto1.addEventListener('keypress', function (e) {
                    // keyCode del punto decimal, también se puede cambiar por la coma que sería el 44
                    const decimalCode = 46;
                    // chequeo que el keyCode corresponda a las teclas de los números y al punto decimal
                    if ((e.keyCode < 48 || e.keyCode > 57) && e.keyCode != decimalCode) {
                        e.preventDefault();
                    }
                    // chequeo que sólo exista un punto decimal
                    else if (e.keyCode == decimalCode && /\./.test(this.value)) {
                        event.preventDefault();
                    }
                }, true)

                texto2.addEventListener('keypress', function (e) {
                    // keyCode del punto decimal, también se puede cambiar por la coma que sería el 44
                    const decimalCode = 46;
                    // chequeo que el keyCode corresponda a las teclas de los números y al punto decimal
                    if ((e.keyCode < 48 || e.keyCode > 57) && e.keyCode != decimalCode) {
                        e.preventDefault();
                    }
                    // chequeo que sólo exista un punto decimal
                    else if (e.keyCode == decimalCode && /\./.test(this.value)) {
                        event.preventDefault();
                    }
                }, true)
           </script>

    </form>
</body>
</html>
