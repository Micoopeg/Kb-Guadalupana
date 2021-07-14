<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequerimientoPago.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.RequerimientoPago" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Verificación requerimiento de pago</title>
         <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');



        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:"Montserrat";
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
            width:100%;
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
        }
        .header{ border-top:1px solid white;background:white; color:#333; height:0px; width:100%; font-family: 'Lobster', cursive; text-align:center}
.menu2{visibility:hidden; height:auto; width:17%; color:white; text-align:left;color:black; padding-top:5px; left:0; margin-left:0px;margin-top:125px;background-color:lightgray; border:2px #4B752B solid;padding-left:13px;}
.wrapper{ height:100px; width:100%; padding-top:20px}
 
.fixed{position:fixed; top:0;visibility:visible}

    </style>
</head>
     <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="general">
            <div class="formularioCobros">

                  <div style="display:flex; justify-content:center">
                    <label style="font-size:18px" class="titulos">Verificación del requerimiento de pago</label>
                 </div><br />

                <div class="encabezado">

                    <label class="titulos"><b>Factura</b></label><br /><br />

                    <div style="justify-content: center;display:flex" class="formato">
                        <div style="overflow: auto; height: 123px">
                        <asp:GridView ID="gridViewDocumentos" runat="server" AutoGenerateColumns="False" CssClass="tabla"
                            OnSelectedIndexChanged = "OnSelectedIndexChangedDocumento" BorderStyle="Solid">
                             <Columns>
                                <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No. documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblid" Text='<%# Eval("Codigo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Tipo documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lbltipodoc" Text='<%# Eval("TipoDocumento") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre documento">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnombredoc" Text='<%# Eval("Nombre") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField   Text="Ver Documento" ItemStyle-CssClass="celda fas fa-angle-double-right" CommandName="Select" ItemStyle-Width="90px" ControlStyle-ForeColor="Black">
                                    <ItemStyle Width="135px"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                             <HeaderStyle CssClass="prueba" Height="23px" ForeColor="White" BackColor="#0071D4"></HeaderStyle>
                        </asp:GridView>
                       </div>
                       </div><br />

                      <div style="display:flex; justify-content:center">
                        <label style="font-size:18px" class="titulos">Solicitud de cheque</label>
                    </div><br />

                   <div class="formatoTitulo" style="margin-bottom:5px">
                            <label class="titulos"><b>Cheque a nombre de </b></label>
                            <label class="titulos" style="margin-left:33%"><b>Registro contable</b></label>
                        </div>
                        <div class="formato">
                              <input id="NombreCheque" runat="server" type="text" class="formatoinput" placeholder="Ingrese nombre" maxlength="60" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                             <input id="RegistroContable" runat="server" type="text" class="formatoinput" placeholder="Ingrese registro contable" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                        </div><br />

                     <div class="formato3">
                        <label class="titulos"><b>Observaciones</b></label>
                        <input id="Observaciones" runat="server" type="text" class="formatoinput2" placeholder="Ingrese observaciones" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                    </div><br /><br />

                    <input id="NombreUsuario" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="FechaActual" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="ImporteTotal" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>
                    <input id="NumCredito" runat="server" type="text" class="formatoinput2" visible="false" readOnly="readOnly"/>

                         <div class="formato2">
                            <asp:Button ID="Generar" runat="server" Width="30%" Height="30px" CssClass="boton3" Text="Generar solictud de cheque" OnClick="Generar_Click" />
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
             var texto1 = document.querySelector('#RegistroContable');

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

         </script>
    </form>
</body>
</html>
