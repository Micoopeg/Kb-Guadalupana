<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarProceso.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.AsignarProceso" %>

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
    <title>Asignar Proceso</title>
        <style>
            @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:'Montserrat';
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
            background-color:lightgray;
            flex-direction:column;
            margin-top:10px;
        }

        .formato{
            display:flex;
            flex-direction:row;
            justify-content: space-between;
        }

          .formato3{
            display:flex;
            flex-direction:column;
            width:100%;
        }
             .formato4{
            display:flex;
            flex-direction:column;
            justify-content:center;
            align-items:center;
            width:45%;
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
            text-transform:uppercase;
        }

        .formatoinput2{
            width:98%;
            margin-top:8px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            height: 30px;
            border-color: transparent;
            text-transform:uppercase;
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
         }

        .formatoTitulo{
            display:flex;
            flex-direction:row;
            justify-content: flex-start;
        }

        .tabla{
            width:100%;
            text-align:center;
        }
        .tabla td{
            padding:5px;
        }
    </style>
</head>
      <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">
                <div class="encabezado">
                         <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>No. de crédito</b></label>
                            <label class="titulos" style="margin-left:40%"><b>CIF</b></label>
                        </div>

                     <div class="formato">
                         <input id="NumCredito" runat="server" type="text" class="formatoinput" min="0" placeholder="Ingrese no. de crédito" maxlength="10" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                         <input id="CIF" runat="server" type="text" class="formatoinput" min="0" placeholder="Ingrese CIF" maxlength="10" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    </div><br />

                       <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Primer Nombre</b></label>
                            <label class="titulos" style="margin-left:38%"><b>Segundo Nombre</b></label>
                        </div>

                    <div class="formato">
                         <input id="PrimerNombre" runat="server" onkeyup="javascript:this.value=this.value.toUpperCase();" onkeypress="return sololetras(event);"  type="text" class="formatoinput" placeholder="Ingrese nombres" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                         <input id="SegundoNombre" runat="server" onkeyup="javascript:this.value=this.value.toUpperCase();" onkeypress="return sololetras(event);"  type="text" class="formatoinput" placeholder="Ingrese nombres" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    </div><br />

                        <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Primer Apellido</b></label>
                            <label class="titulos" style="margin-left:38%"><b>Segundo Apellido</b></label>
                        </div>

                      <div class="formato">
                       <input id="PrimerApellido" runat="server" onkeyup="javascript:this.value=this.value.toUpperCase();" onkeypress="return sololetras(event);"  type="text" class="formatoinput" placeholder="Ingrese apellidos" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="SegundoApellido" runat="server" onkeyup="javascript:this.value=this.value.toUpperCase();" onkeypress="return sololetras(event);"  type="text" class="formatoinput" placeholder="Ingrese apellidos" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    </div><br />
                </div>

                 <div class="formato2">
                    <asp:Button ID="APBuscar" runat="server" CssClass="boton" Text="Buscar" OnClick="APBuscar_Click"/>
                  <%--  <asp:Button ID="APAsignar" runat="server" CssClass="boton2" Text="Asignar" OnClick="APAsignar_Click"/>--%>
                      <%-- <asp:Button ID="Prueba" runat="server" CssClass="boton2" Text="Asignar" OnClick="Prueba_Click"/>--%>
                 </div><br /><br /><br />

     <div id="divgridviewprospectos2" runat="server" style="overflow: auto; height: 300px">
     <asp:GridView ID="gridview2" CssClass="tabla" runat="server"  HeaderStyle-ForeColor="Black"
    AutoGenerateColumns="False" OnSelectedIndexChanged="OnSelectedIndexChangedprospectos" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. de crédito" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lblnumerocred" Text='<%# Eval("COLNUMDOCUMEN") %>' runat="server" />
                        </ItemTemplate>

<ControlStyle CssClass="dise&#241;o"></ControlStyle>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="CIF" Visible="True">
                           <ItemTemplate>
                           <asp:Label ID="lbltipotelefono" Text='<%# Eval("CIFCODCLIENTE") %>' runat="server" />
                        </ItemTemplate>

<ControlStyle CssClass="dise&#241;o"></ControlStyle>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre completo">
                           <ItemTemplate>
                            <asp:Label ID="lblnombretelefono" Text='<%# Eval("CIFNOMBRECLIE") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="DPI">
                           <ItemTemplate>
                            <asp:Label ID="lblnombretelefono2" Text='<%# Eval("CIFDOCIDENT06") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarcelulargridview icon-prev"  CommandName="Select" ItemStyle-Width="120">
                            <ItemStyle Width="120px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White" BackColor="#0069C4"></HeaderStyle>
        </asp:GridView>
                </div>

                <br /><br /><br />
                 <div style="display:flex; justify-content:center">
                        <label style="font-size:18px" class="titulos">Créditos devueltos</label>
                    </div><br />

                <div id="tablaC" runat="server" style="overflow: auto; height: 300px">
                        <asp:GridView ID="gridViewCreditos" runat="server" CssClass="tabla" AutoGenerateColumns="False"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedCreditos" BorderStyle="Solid">
                            <Columns>
                                  <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="No. de crédito">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnumcredito" Text='<%# Eval("Credito") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnombre" Text='<%# Eval("Nombre") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Estado">
                                    <ItemTemplate>
                                       <asp:Label ID="lblestado" Text='<%# Eval("Estado") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Del área de">
                                    <ItemTemplate>
                                       <asp:Label ID="lbldeArea" Text='<%# Eval("DeArea") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Comentario">
                                    <ItemTemplate>
                                       <asp:Label ID="lblcomentario" Text='<%# Eval("Comentario") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Fecha">
                                    <ItemTemplate>
                                       <asp:Label ID="lblfecha" Text='<%# Eval("Fecha") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Ver crédito" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="Black">
                                    <ItemStyle Width="100px"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba"  ForeColor="White" BackColor="#0069C4"></HeaderStyle>
                        </asp:GridView>
                    </div><br /><br />

            </div>
        </div>

         <script>
           $(document).ready(function () {
               $('.menu').load('MenuPrincipal.aspx');
           });
         </script>
            <script type="text/javascript">
                function sololetras(evt) {
                    var charCode = (evt.which) ? evt.which : event.keyCode
                    if (charCode > 31 && (charCode < 48 || charCode > 57))
                        return true;

                    return false;
                }
            </script>

        <script>
            var texto1 = document.querySelector('#NumCredito');
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
          <%--  <script>
                $('#<%=DropNombre.ClientID%>').chosen();
            </script>--%>
    </form>
</body>
</html>
