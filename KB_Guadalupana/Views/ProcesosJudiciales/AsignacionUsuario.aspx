<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionUsuario.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.AsignacionUsuario" %>

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
    <title>Asignación Usuarios</title>
    <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');

        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:"Montserrat";
            background-color:#34495E;
            color:white;
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
            width:750px;
        }

        .encabezado{
            padding:25px;
            background-color:#435F7A;
            flex-direction:column;
            margin-top:10px;
        }

        .formato{
            display:flex;
            flex-direction:row;
            justify-content: space-between;
            width:100%;
            align-items: center;
        }

          .formato3{
            display:flex;
            flex-direction:column;
            width:100%;
        }

        .formato4{
             display:flex;
            flex-direction:row;
            justify-content: center;
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
             margin-top:8px;
        }

        .formatoinput2{
            width:99%;
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

        .formatoinput4 {
            width: 21%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
        }

        .formatoinput6 {
            width: 17%;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 25px;
            border-color: transparent;
            display: flex;
            align-items: center;
            align-content:center;
            justify-content:flex-end;
            text-align:right
        }

        .formato2{
            display:flex;
            flex-direction:row;
            justify-content: space-around;
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

         .pagina{
            display:flex;
            flex-direction:row;
        }

         .header{
             background-color:#004078;
             color:white;
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

        .tabla{
            width:100%;
        }

        .tabla td{
            padding:7px;
        }
           .ventana{
             display:flex;
             align-content:flex-start;
             justify-content:flex-start;
             justify-items:flex-start;
             flex-direction:column;
             margin-left:0px;
         }
         .formatoinput5{
            width:90%;
            margin-top:8px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            font-family:"Montserrat";
            max-width: 90%;
            min-width: 90%;
            max-height:30px;
            min-height:30px;
        }

        .formatocheckbox {
            width: 25px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 25px;
            border-color: transparent;
            display: flex;
            align-items: flex-start;
            align-content:flex-start;
            justify-content:flex-start;
        }

        .formatocheck{
            display:flex;
            justify-content:space-between;
            flex-direction:row;
            width:100%;
            margin-bottom: 5px;
        }

        .formatocheck2{
            display:flex;
            flex-direction:row;
            width:30%;
        }

        .header{ border-top:1px solid white;background:white; color:#333; height:0px; width:100%; font-family: 'Montserrat', cursive; text-align:center}
.menu2{visibility:hidden; height:auto; width:17%; color:white; text-align:left; padding-top:5px; left:0; margin-left:0px;margin-top:75px;background-color:#435F7A; border:2px #4B752B solid;padding-left:13px;}
.wrapper{ height:100px; width:100%; padding-top:20px}
 
.fixed{position:fixed; top:0;visibility:visible}

    </style>
</head>
    <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">
                <div style="display:flex; justify-content:center">
                    <label style="font-size:18px" class="titulos">Asignación de usuarios</label>
                 </div><br />

                <div class="encabezado">
                    <div class="formatoTitulo">
                        <label class="titulos"><b>Usuario</b></label>
                    </div>

                    <div class="formato">
                        <asp:DropDownList id="Usuario" runat="server" class="formatoinput"></asp:DropDownList>
                        <asp:Button ID="Buscar" runat="server" Width="30%" CssClass="boton3" Text="Buscar" OnClick="Buscar_Click" />
                    </div>
                    <br /><br />

                    <div id="infoUsuario" runat="server">
                        <div class="formatoTitulo">
                            <label class="titulos"><b>Área</b></label>
                            <label class="titulos" style="margin-left:50%"><b>Rol</b></label>
                        </div>
                        <div class="formato">
                            <asp:DropDownList id="Area" runat="server" class="formatoinput"></asp:DropDownList>
                            <asp:DropDownList id="Rol" runat="server" class="formatoinput"></asp:DropDownList>
                        </div>
                        <br /><br />

                        <div class="formatoTitulo">
                            <label class="titulos"><b>Estado</b></label>
                            <label class="titulos" style="margin-left:48%"><b>Puesto</b></label>
                        </div>
                        <div class="formato">
                            <asp:DropDownList id="Estado" runat="server" class="formatoinput"></asp:DropDownList>
                            <asp:DropDownList id="Puesto" runat="server" class="formatoinput"></asp:DropDownList>
                        </div>
                        <br /><br />

                        <div class="formatoTitulo">
                            <label class="titulos"><b>Aplicación</b></label>
                        </div>
                        <div class="formato">
                            <asp:DropDownList id="Aplicacion" runat="server" class="formatoinput"></asp:DropDownList>
                            <asp:Button ID="Asignar" runat="server" CssClass="boton" Width="18%" Text="Asignar" OnClick="Asignar_Click" />
                            <asp:Button ID="Desasignar" runat="server" CssClass="boton" Width="18%" Text="Desasignar" OnClick="Desasignar_Click" />
                        </div>
                        <br /><br />
                        <div style="justify-content: center;display:flex" class="formato">
                            <div style="overflow: auto; height: 150px; width:100%">
                        <asp:GridView ID="gridViewAsignacion" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            BorderStyle="Solid">
                             <Columns>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Usuario">
                                    <ItemTemplate>
                                       <asp:Label ID="lblusuario" Text='<%# Eval("Usuario") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Opción">
                                    <ItemTemplate>
                                       <asp:Label ID="lblopcion" Text='<%# Eval("Opcion") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Estado">
                                    <ItemTemplate>
                                       <asp:Label ID="lblestado" Text='<%# Eval("Estado") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div><br /><br /><br />

                    </div>
                </div>

                <div class="formato2">
                    <asp:Button ID="Guardar" runat="server" CssClass="boton" Text="Guardar" OnClick="Guardar_Click" />
                    <asp:Button ID="Actualizar" runat="server" CssClass="boton" Text="Actualizar" OnClick="Actualizar_Click" />
                </div><br />

            </div>
        </div>

        <script>
            $('#<%=Usuario.ClientID%>').chosen();
        </script>

        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    </form>
</body>
</html>
