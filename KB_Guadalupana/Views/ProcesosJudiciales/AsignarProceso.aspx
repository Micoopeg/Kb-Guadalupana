<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarProceso.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.AsignarProceso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Asignar Proceso</title>
        <style>

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
    </style>
</head>
      <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        <div class="general">
            <div class="formularioCobros">
                <div class="encabezado">
                    <div class="formato3">
                        <label class="titulos"><b>No. de crédito</b></label>
                         <input id="NumCredito" runat="server" type="number" class="formatoinput2" min="0" placeholder="Ingrese no. de crédito" maxlength="10" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    </div><br />
                     <div class="formato3">
                        <label class="titulos"><b>Primer nombre</b></label>
                         <input id="PrimerNombre" runat="server" type="text" class="formatoinput2" placeholder="Ingrese primer nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    </div><br />
                    <div class="formato3">
                        <label class="titulos"><b>Primer apellido</b</label>
                         <input id="PrimerApellido" runat="server" type="text" class="formatoinput2" placeholder="Ingrese primer apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                    </div>
                </div>

                 <div class="formato2">
                    <asp:Button ID="APBuscar" runat="server" CssClass="boton" Text="Buscar" OnClick="APBuscar_Click"/>
                    <asp:Button ID="APAsignar" runat="server" CssClass="boton2" Text="Asignar" OnClick="APAsignar_Click"/>
                 </div><br />

                <div id="formulario" runat="server" class="encabezado">
                        <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Nombre de agencia</b></label>
                            <label class="titulos" style="margin-left:38%"><b>Instrumento</b></label>
                        </div>
                        <div class="formato">
                              <input id="Agencia" runat="server" type="text" class="formatoinput" placeholder="Nombre de agencia" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                             <input id="Instrumento" runat="server"  type="text" class="formatoinput" placeholder="Instrumento" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                     <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Línea de crédito</b></label>
                            <label class="titulos" style="margin-left:40%"><b>Destino</b></label>
                        </div>
                        <div class="formato">
                              <input id="LineaCredito" runat="server"  type="text" class="formatoinput" placeholder="Línea de crédito" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                             <input id="destino" runat="server"  type="text" class="formatoinput" placeholder="Destino" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                     <div class="formato3">
                        <label class="titulos"><b>Garantía</b</label>
                         <input id="Garantia" runat="server"  type="text" class="formatoinput2" placeholder="Garantía" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Plazo en meses</b></label>
                        <label class="titulos" style="margin-left:23%"><b>Método de cálculo</b></label>
                        <label class="titulos" style="margin-left:21%"><b>Estado</b></label>
                    </div>

                    <div class="formato">
                        <input id="Plazomeses" runat="server"  type="number" class="formatoinput3" min="0" placeholder="Plazo en medes" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="Metodocalculo" runat="server"  type="text" class="formatoinput3" placeholder="Método cálculo" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                         <input id="Estado" runat="server"  type="text" class="formatoinput3" placeholder="Estado" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                       <div class="formatoTitulo" style="margin-bottom:5px">
                             <label class="titulos"><b>Moneda</b></label>
                            <label class="titulos" style="margin-left:46%"><b>Tasa</b></label>
                        </div>
                         <div class="formato">
                              <input id="Moneda" runat="server"  type="text" class="formatoinput" placeholder="Moneda" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                             <input id="Tasa" runat="server"  type="number" class="formatoinput" min="0" placeholder="Tasa" maxlength="10" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        </div><br />

                     <div class="formato3">
                        <label class="titulos"><b>Fecha solicitud</b</label>
                        <input id="FechaSolicitud" runat="server"  type="text" class="formatoinput2" placeholder="Fecha solicitud" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Fecha 1er. desembolso</b></label>
                        <label class="titulos" style="margin-left:35%"><b>Fecha último desembolso</b></label>
                    </div>

                    <div class="formato">
                           <input id="FechaDesembolso1" runat="server"  type="text" class="formatoinput" placeholder="Fecha 1er. desembolso" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="FechaUltimoDes" runat="server"  type="text" class="formatoinput" placeholder="Fecha último desembolso" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                     <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Fecha de vencimiento</b></label>
                        <label class="titulos" style="margin-left:35%"><b>Fecha última cuota</b></label>
                    </div>

                    <div class="formato">
                           <input id="FechaVencimiento" runat="server"  type="text" class="formatoinput" placeholder="Fecha vencimiento" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="FechaUltimaCuota" runat="server"  type="text" class="formatoinput" placeholder="Fecha última cuota" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                      <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Fecha de acta</b></label>
                        <label class="titulos" style="margin-left:42%"><b>Número de acta</b></label>
                    </div>

                    <div class="formato">
                           <input id="FechaActa" runat="server"  type="text" class="formatoinput" placeholder="Fecha de acta" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="NumActa" runat="server"  type="number" min="0" class="formatoinput" placeholder="Número de acta" maxlength="10" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                      <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Oficial - Primer Nombre</b></label>
                        <label class="titulos" style="margin-left:33%"><b>Oficial - Segundo Nombre</b></label>
                    </div>

                    <div class="formato">
                           <input id="OficialNombre1" runat="server"  type="text" class="formatoinput" placeholder="Primer nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="OficialNombre2" runat="server" type="text" class="formatoinput" placeholder="Segundo nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                      <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Oficial - Primer Apellido</b></label>
                        <label class="titulos" style="margin-left:33%"><b>Oficial - Segundo Apellido</b></label>
                    </div>

                    <div class="formato">
                           <input id="OficialApellido1" runat="server" type="text" class="formatoinput" placeholder="Primer Apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="OficialApellido2" runat="server" type="text" class="formatoinput" placeholder="Segundo Apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                         <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>No. de prestamo</b></label>
                        <label class="titulos" style="margin-left:22%"><b>Agencia cliente</b></label>
                        <label class="titulos" style="margin-left:23%"><b>Código cliente</b></label>
                    </div>

                    <div class="formato">
                        <input id="NumPrestamo" runat="server" type="number" class="formatoinput3" min="0" placeholder="No. prestamo" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="AgenciaCliente" runat="server" type="text" class="formatoinput3" placeholder="Agencia cliente" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                         <input id="CodigoCliente" runat="server" type="number" min="0" class="formatoinput3" placeholder="Código cliente" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                       <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Cliente - Primer Nombre</b></label>
                        <label class="titulos" style="margin-left:33%"><b>Cliente - Segundo Nombre</b></label>
                    </div>

                    <div class="formato">
                           <input id="ClienteNombre1" runat="server" type="text" class="formatoinput" placeholder="Primer nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="ClienteNombre2" runat="server" type="text" class="formatoinput" placeholder="Segundo nombre" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Cliente - Primer Apellido</b></label>
                        <label class="titulos" style="margin-left:33%"><b>Cliente - Segundo Apellido</b></label>
                    </div>

                    <div class="formato">
                           <input id="ClienteApellido1" runat="server" type="text" class="formatoinput" placeholder="Primer Apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                           <input id="ClienteApellido2" runat="server" type="text" class="formatoinput" placeholder="Segundo Apellido" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                   <div class="formatoTitulo" style="margin-bottom:5px">
                        <label class="titulos"><b>Monto original</b></label>
                        <label class="titulos" style="margin-left:23%"><b>Capital desembolsado</b></label>
                        <label class="titulos" style="margin-left:18%"><b>Saldo actual</b></label>
                    </div>

                    <div class="formato">
                        <input id="MontoOriginal" runat="server" type="number" class="formatoinput3" min="0" placeholder="Monto original" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="CapitalDesem" runat="server" type="number" class="formatoinput3" min="0" placeholder="Capital desembolsado" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                        <input id="SaldoActual" runat="server" type="number" min="0" class="formatoinput3" placeholder="Saldo actual" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br />

                    <div class="formato3">
                        <label class="titulos"><b>Descripción documento</b></label>
                         <input id="DescripcionDoc" runat="server" type="number" min="0" class="formatoinput2" placeholder="Código cliente" maxlength="11" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" readOnly="readOnly"/>
                    </div><br/>

                </div><br />

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
