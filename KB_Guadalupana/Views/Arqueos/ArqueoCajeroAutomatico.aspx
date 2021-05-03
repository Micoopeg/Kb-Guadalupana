<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation = "false" CodeBehind="ArqueoCajeroAutomatico.aspx.cs" Inherits="Modulo_de_arqueos.Views.ArqueoCajeroAutomatico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
    <script src='https://kit.fontawesome.com/a076d05399.js'></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
    <script>
        function obtenerimagen() {
            takeScreenshot(function (screenshot) {
                printPage(screenshot);
            });
        }
    </script>
    
<script>
    function printPage(screenshot) {
        var win = window.open('EstadoPatrimonial', 'EstadoPatrimonial');
        win.document.write('<html>');
        win.document.write('<head></head>');
        win.document.write('<body>');
        win.document.write('<img src="' + screenshot + '"/>');
        win.document.write('</body>');
        win.document.write('</html>');
    }
</script>
<script>
    function printPage1(screenshot) {
        var win = window.open('EstadoPatrimonial', 'EstadoPatrimonial');
        win.document.write('<html>');
        win.document.write('<head></head>');
        win.document.write('<body>');
        win.document.write('<img src="' + screenshot + '"/>');
        win.document.write('</body>');
        win.document.write('</html>');
        win.print();
        win.close();
    }
</script>  
    <script>        
        function takeScreenshot(cb) {
            html2canvas(document.getElementById('area'),
                {
                    onrendered: function (canvas) {
                        var image = canvas.toDataURL();
                        cb(image);

                    }
                });
        }
    </script>
    <title>Cajero Automático</title>
    <style>
         body{
            display:flex;
            align-items:center;
            justify-content: center;
            font-family: Arial, Helvetica, sans-serif;
           flex-direction: column;
           margin:0px;
        }
        .arqueo{
            width: 660px;
            height: auto;
            box-shadow: 0 0 15px 1px rgb(0 53 99);
            padding: 20px;
            margin: 20px;
            display: flex;
            justify-content: center;
            flex-direction: column;
        }
        .encabezado{
            flex-direction: row;
            justify-content: space-between;
            display: flex;
            align-items:center;
            width: auto;
            height:auto;
            padding: 0px 10px;
        }
        .fs-title{
            font-size: 15px;
            justify-content: center;
            display: flex;
        }
        .titulo{
            font-size: 20px;
            justify-content: center;
            display: flex;
        }
        .titulo2{
            font-size: 18px;
            justify-content: center;
            display: flex;
        }
        .solid {
            border-top: 3px solid #003563;
        }
        .etiquetas{
            font-size: 15px;
            justify-content: flex-start;
            display: flex;
            margin: 3px;
            padding: 5px;
            width: 97%;
        }
        .etiquetas2{
            font-size: 15px;
            justify-content: center;
            display: flex;
            margin: 5px;
            padding: 5px;
            width: 95%;
            height: 14px;
        }
        .etiquetas3{
            font-size: 15px;
            justify-content: center;
            display: flex;
            margin: 5px;
            padding: 5px;
            width: 83%;
             height: 14px;
        }
         .etiquetas4{
            font-size: 15px;
            justify-content: center;
            display: flex;
            margin: 0px;
            padding: 5px;
            width: 95%;
             height: 14px;
        }
           .etiquetas5{
            font-size: 15px;
            justify-content: flex-end;
            display: flex;
            margin: 5px;
            padding: 5px;
            width: 83%;
             height: 14px;
        }
         .etiquetasTabla{
             font-size: 15px;
            justify-content: center;
            display: flex;
            margin: 5px;
            padding: 5px;
            width: 50px;
            height: 14px;
         }
        .datosGenerales{
            flex-direction: column;
            justify-content: space-between;
            display: flex;
            align-items:flex-start;
            width: auto;
            height:auto;
            padding: 0px 10px;
            margin-bottom: 10px;
        }
        .datosGenerales2{
            flex-direction: row;
            justify-content: center;
            display: flex;
            align-items:center;
            width: auto;
            height:auto;
            padding: 0px 10px;
        }
        .datosGenerales3{
            flex-direction: row;
            justify-content: center;
            display: flex;
            align-items:flex-start;
            width: auto;
            height:auto;
            padding: 0px 10px;
        }
          /*menu*/
      /*menu*/
        .topnav {
          overflow: hidden;
          background-color: #333;
          width:100%;
        }

        .topnav a {
          float: left;
          color: #f2f2f2;
          text-align: center;
          padding: 14px 16px;
          text-decoration: none;
          font-size: 17px;
        }

        .topnav a:hover {
          background-color: #ddd;
          color: black;
        }

        .topnav a.active {
          background-color: #4CAF50;
          color: white;
        }
        .topnav {
          overflow: hidden;
          background-color: #003563;
          width: 100%;
        }

        .topnav a {
          float: left;
          color: #f2f2f2;
          text-align: center;
          padding: 15px 35px;
          text-decoration: none;
          font-size: 17px;
        }
        .topnav a:hover {
          background-color: #B80416;
          color: White;
        }
        .topnav a.active {
              background-color: #69a43c;
              color: white;
        }
        /*TABLA*/
        .td{
            border: 1px solid black;
        }
        .td2{
            border-bottom:  0px;
            border-top:  1px solid black;
            border-right:  1px solid black;
            border-left:  1px solid black;
        }
         .td3{
            border-bottom:  0px;
            border-top:  0px;
            border-right:  1px solid black;
            border-left:  1px solid black;
        }
         .td4{
            border-bottom:  1px solid black;
            border-top:  0px;
            border-right:  1px solid black;
            border-left:  1px solid black;
        }
        table {
            border-collapse:collapse;
        }
       table th{
           background-color:#0076DE;
           color: white;
           padding: 5px;
       }
             .boton{
            background-color: #69A43C;
          border: none;
          color: white;
          padding: 12px 28px;
          text-align: center;
          font-size: 16px;
          margin: 4px 2px;
          transition: 0.3s;
          display: inline-block;
          text-decoration: none;
          cursor: pointer;
          opacity:0.6;
        }
        .boton:hover {
            opacity:1;
        }
        .icon{
            width:100px;
            height:100px;
        }
  /*BOTON EJEMPLO*/
        .boton2 {
          display: inline-block;
          border-radius: 4px;
          background-color: #0067C2;
          border: none;
          color: #FFFFFF;
          text-align: center;
          font-size: 12px;
          padding: 10px;
          width: 130px;
          height:30px;
          transition: all 0.5s;
          cursor: pointer;
          margin: 5px;
        }

        .boton2 span {
          cursor: pointer;
          display: inline-block;
          position: relative;
          transition: 0.5s;
        }

        .boton2 span:after {
          content: '\00bb';
          position: absolute;
          opacity: 0;
          top: 0;
          right: -20px;
          transition: 0.5s;
        }

        .boton2:hover span {
          padding-right: 25px;
        }

        .boton2:hover span:after {
          opacity: 1;
          right: 0;
        }
        .nombre{
            color: white;
            height:25px;
        }
        .nombre:hover{
            color: white;
        }
        .icon{
            color: white;
            height:50px;
            display:flex;
            align-items:center;
        }
       .ayuda 
        {
          background-color: #69a43c; 
          border: none;
          color: white;
          padding: 5px;
          text-align: center;
          text-decoration: none;
          display: flex;
          font-size: 10px;
          margin: 4px 2px;
          transition-duration: 0.4s;
          align-items: center;
          justify-content:center;
          align-content:center;
          cursor: pointer;
          width:70px;
          height:40px;
        }
        .ayuda:hover
        {
          background-color: #555555;
          color: white;
        }
    </style>
</head>
<body>
    <div class="topnav">
            <a class="active" href="MenuArqueos.aspx">Inicio</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b runat="server" id="NombreUsuario"></b></span>
            <a href="../Sesion/CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
        </div>

   <a class="ayuda" style="right: 7%;position: absolute;margin-top: 1px;" target="_blank" href="Manual/ManualCajeroAutomatico.aspx" ><i class="fa fa-question" style='font-size:15px'></i>  Consultar Guía</a>
    <div style="display: flex;justify-content: center;align-items: center; flex-direction:row; width:500px;">
    <div id="visualizar" runat="server" class="boton2" style="display: flex;justify-content: center;align-items: center;" onclick="obtenerimagen();">
				<a style="cursor:pointer;" class="nombre">
					Visualizar
					<span class="icon">
						<i class="fa fa-file"></i>
					</span>
				</a>
			</div>
    <div id="imprimir" runat="server" class="boton2" style="display: flex;justify-content: center;align-items: center; width:150px;">
				<a onclick="printPage1();" style="cursor:pointer;" class="nombre">
					Guardar / Imprimir
					<span class="icon" >
						<i class="fas fa-print"></i>
					</span>
				</a>
			</div>

        <%--PRUEBA 2--%>
       <%-- <asp:Panel ID="panelPDF" runat="server">
            <h1>PRUEBA 2 DEL ARCHIVO PDF</h1>
        </asp:Panel>--%>
    <%--    <br /><br />
        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"/>
         <asp:Button ID="btnPrint" OnClick="btnPrint_Click" runat="server" CssClass="boton" Text="Print" />--%>


      <%--  PRUEBA 1--%>
       <%-- <script src="../../bower_components/jquery/dist/jquery.min.js"></script>
        <button id="btnPdf" class="btn btn-primary">GENERATE PDF</button>
        <div id="pdfContainer">
            <h1>ESTO ES UN PDF</h1>
        </div>

        <script type="text/javascript">
            $("btnPdf").click(function () {
                var sHtml = $("#pdfContainer").html();
                sHtml = sHtml.replace(/</g, "StrTag").replace(/>/g, "EndTag");
                window.open('../../Controllers/GeneratePdf?html=' + sHtml, '_blank');
            })
        </script>--%>
    </div>
    <form id="form1" runat="server">
        <div style="flex-direction:column; display:flex; width:100%; margin-top:50px;">
            <asp:Button ID="Creararqueo" OnClick="creararqueo_Click" runat="server" CssClass="boton" Text="Crear nuevo arqueo" />
             <asp:Button ID="Buscararqueo" OnClick="buscararqueo_Click" runat="server" CssClass="boton" Text="Buscar arqueo" />
            </div><br />
        <div id="EBuscar" style="flex-direction:column; width:500px" runat="server" class="datosGenerales2">
             <label style="font-size:13px;display:flex;justify-content:flex-start; width:33%"><b>Fecha de realización</b></label>
            <input id="CABuscarfecha" runat="server" type="date" onchange="traerArqueos();" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 10px;padding: 5px;width:33%" /><br />

            <span id="TituloUsuario" runat="server" style="font-size:13px;display:flex;justify-content:flex-start; width:33%"><b>Usuario que lo realizó</b></span>
             <asp:DropDownList id="CAUsuario" OnSelectedIndexChanged="CAUsuario_SelectedIndexChanged" runat="server" Width="35%" class="etiquetas" AutoPostBack="true"></asp:DropDownList><br />

             <label style="font-size:13px;display:flex;justify-content:flex-start; width:33%"><b>Número de arqueo</b></label>
             <asp:DropDownList id="DropNumarqueo" runat="server" Width="35%" class="etiquetas" AutoPostBack="true"></asp:DropDownList>
              <asp:LinkButton ID="btnArqueos" runat="server" OnClick="btnArqueos_Click" ClientIDMode="Static"></asp:LinkButton><br />

            <asp:Button ID="Buscar" OnClick="buscar_Click" Width="30%" runat="server" CssClass="boton" Text="Buscar" />
            </div>
        
        <div id="arqueo" runat="server" class="arqueo">
            <asp:Panel ID="panelPDF" runat="server">
        <div id="area" runat="server">
            <div class="encabezado">
                <img src="../../Imagenes/Logo2.png" style="top: 0; max-width: 170px; margin:30px; margin-left:20px;" />
                <h2 class="fs-title"><b>COOPERATIVA PARROQUIAL GUADALUPANA, R.L.</b></h2>
            </div>

            <p class="fs-title"><b>ARQUEO DE EFECTIVO Y VALORES</b></p>

            <div class="solid" style="margin-top: 5px;"></div>

            <br />
            <div class="datosGenerales2">
                 <label style="width:28%; display:flex; justify-content:flex-end"><b>Fecha y hora</b></label>&nbsp;&nbsp;
               <%-- <input id="CAFecha" runat="server" disabled="disabled" type="datetime-local" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 10px;padding: 5px;width:30%" required/>--%>
                 <input id="CAFecha" runat="server" disabled="disabled" type="Text" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 10px;padding: 5px;width:30%"/>
            </div>

             <div class="datosGenerales">
                <div style="display:flex; flex-direction: row; width:100%; align-items:flex-end">
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start"><b> Código de agencia</b></label>
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start; margin-left:22%"><b>Nombre de la agencia</b></label>
                </div>
                 <div style="display:flex; flex-direction: row; width:100%; align-items:center">
                     <asp:DropDownList id="CAAgencia" OnSelectedIndexChanged="CAAgencia_SelectedIndexChanged" runat="server" class="etiquetas" AutoPostBack="true"></asp:DropDownList>
                    <input id="CACodigoagencia" runat="server" type="text" readonly="true" placeholder="Nombre de agencia" class="etiquetas" />
                </div>
                   <label style="width:100%; display:flex; justify-content:flex-start;margin-top:5px;"><b>Persona a quien se dirige el arqueo</b></label>
                 <div style="display:flex; flex-direction: row; width:100%; align-items:flex-end; margin-top:3px;">
                    <label style="width:20%; font-size:12px; display:flex; justify-content:flex-start"><b>Nombre</b></label>
                     <label style="width:20%; font-size:12px; display:flex; justify-content:flex-start; margin-left:14%"><b>Operador</b></label>
                     <label style="width:20%; font-size:12px; display:flex; justify-content:flex-start; margin-left:13%"><b>Puesto</b></label>
                </div>
                  <div style="display:flex; flex-direction: row; width:100%">
                     <input id="CAOperador" runat="server" type="text" onkeypress="return sololetras(event);" maxlength="50" placeholder="Nombres y apellidos (operador)" class="etiquetas" onchange="agregar(this.value);" required/>
                     <input id="CANumperador" min="0" runat="server" type="text" maxlength="11" placeholder="No. operador" class="etiquetas" pattern="[0-9]*" required/>
                      <input id="CAPuestooperador" runat="server" onkeypress="return sololetras(event);" maxlength="50" type="text" placeholder="Puesto" class="etiquetas" onchange="agregar2(this.value);" required/>
                  </div>
                 <label style="width:100%; display:flex; justify-content:flex-start;margin-top:5px;"><b>Persona que realiza el arqueo</b></label>
                <div style="display:flex; flex-direction: row; width:100%; align-items:flex-end; margin-top:3px;">
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start"><b>Nombre</b></label>
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start; margin-left:22%"><b>Puesto</b></label>
                </div>
                 <div style="display:flex; flex-direction: row; width:100%; align-items:center">
                     <input id="CANombreencargado" runat="server" onkeypress="return sololetras(event);" maxlength="50" type="text" placeholder="Nombres y apellidos" class="etiquetas" required/>
                     <input id="CAPuestoencargado" runat="server" onkeypress="return sololetras(event);" maxlength="50" type="text" placeholder="Puesto" class="etiquetas" onchange="agregar3(this.value);" required/>
                </div>
                 <div style="display:flex; flex-direction: row; width:100%; align-items:center">
                    <label class="etiquetas2"><b>Fondo: </b></label>
                    &nbsp;<b>ATM</b> &nbsp;<b>Q</b><input id="CAAtm" runat="server" type="text" value="20000.00" class="etiquetas" />
                </div>
            </div>
            <div class="solid" style="margin-top: 5px;"></div>

            <div class="datosGenerales3">
                <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Descripción</b></label>
                    <label class="etiquetas2"><b>Billetes</b></label>
                </div>
                 <div style="display:flex; flex-direction: column; width:100%; justify-content:center;">
                    <label class="etiquetas2"><b>Cantidad</b></label>
                    <input id="CACantidad1" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar1(this.value);"/>
                    <input id="CACantidad2" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar2(this.value);"/>
                    <input id="CACantidad3" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar3(this.value);"/>
                    <input id="CACantidad4" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar4(this.value);"/>
                    <input id="CACantidad5" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar5(this.value);"/>
                    <input id="CACantidad6" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar6(this.value);"/>
                    <input id="CACantidad7" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar7(this.value);"/>
                </div>
                <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Denominación</b></label>
                    <label class="etiquetas2">Q200.00</label>
                    <label class="etiquetas2">Q100.00</label>
                    <label class="etiquetas2">Q50.00</label>
                    <label class="etiquetas2">Q20.00</label>
                    <label class="etiquetas2">Q10.00</label>
                    <label class="etiquetas2">Q5.00</label>
                    <label class="etiquetas2">Q1.00</label>
                </div>
                 <div style="display:flex; flex-direction: column; width:5%">
                     <br /><br />
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                </div>
                 <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Sub-total</b></label>
                    <span id="CASubtotalb1" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalb2" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalb3" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalb4" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalb5" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalb6" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalb7" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <div class="solid" style="margin-top: 5px;"></div>
                </div>
                 <div style="display:flex; flex-direction: column; width:4%">
                     <br /><br /><br />
                     <br /><br /><br />
                     <br /><br /><br />
                     <br /><br />
                     <br /><br />
                     <label class="etiquetas4">Q </label>
                </div>
                 <div style="display:flex; flex-direction: column; width:100%; align-items:flex-end">
                    <label class="etiquetas2"><b>Total</b></label>
                     <br /><br /><br />
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <span id="CATotalb" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                </div>
            </div>

             <div class="datosGenerales3" style="margin-top:25px; margin-bottom:25px">
                 <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Monedas</b></label>
                </div>
                 <div style="display:flex; flex-direction: column; width:100%; justify-content:center;">
                    <input id="CACantidadm1" runat="server" min="0" type="text" style="height:10px" value="0" class="etiquetas3" onchange="multiplicarm1(this.value);"/>
                    <input id="CACantidadm2" runat="server" min="0" type="text" style="height:10px" value="0" class="etiquetas3" onchange="multiplicarm2(this.value);"/>
                    <input id="CACantidadm3" runat="server" min="0" type="text" style="height:10px" value="0" class="etiquetas3" onchange="multiplicarm3(this.value);"/>
                    <input id="CACantidadm4" runat="server" min="0" type="text" style="height:10px" value="0" class="etiquetas3" onchange="multiplicarm4(this.value);"/>
                    <input id="CACantidadm5" runat="server" min="0" type="text" style="height:10px" value="0" class="etiquetas3" onchange="multiplicarm5(this.value);"/>
                    <input id="CACantidadm6" runat="server" min="0" type="text" style="height:10px" value="0" class="etiquetas3" onchange="multiplicarm6(this.value);"/>
                </div>
                <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2">Q1.00</label>
                    <label class="etiquetas2">Q0.50</label>
                    <label class="etiquetas2">Q0.25</label>
                    <label class="etiquetas2">Q0.10</label>
                    <label class="etiquetas2">Q0.05</label>
                    <label class="etiquetas2">Q0.01</label>
                </div>
                  <div style="display:flex; flex-direction: column; width:5%">
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                </div>
                <div style="display:flex; flex-direction: column; width:100%">
                    <span id="CASubtotalm1" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalm2" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalm3" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalm4" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalm5" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="CASubtotalm6" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <div class="solid" style="margin-top: 5px;"></div>
                </div>
                 <div style="display:flex; flex-direction: column; width:4%">
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <label class="etiquetas4">Q </label>
                </div>
                 <div style="display:flex; flex-direction: column; width:100%; align-items:flex-end">
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <br />
                      <span id="CATotalm" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                     <div class="solid" style="margin-top: 5px;width:85%"></div>
                </div>
            </div>

            <div class="datosGenerales3" style="margin-top:25px; margin-bottom:25px">
                 <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas4">Total efectivo</label>
                    <label class="etiquetas4">Efectivo según reporte</label><br />
                    <label class="etiquetas4">Diferencia</label>
                </div>
                 <div style="display:flex; flex-direction: column; width:5%">
                    <label class="etiquetas2"><b>Q </b></label>
                    <label class="etiquetas2">Q </label>
                    
                    <label class="etiquetas2"><b>Q </b></label>
                    <br />
                </div>
                <div style="display:flex; flex-direction: column; width:20%">
                    <span id="CATotalefectivo" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <input id="CAEfectivoreporte" runat="server" min="0" type="text" value="0" style="height:10px" class="etiquetas4" onchange="total(this.value);"/>
                    <div class="solid" style="margin-top: 5px;"></div>
                     <span id="CADiferencia" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <div class="solid" style="margin-top: 5px;"></div>
                </div>
            </div>

            <b>Observaciones: </b><input id="CAComentario" runat="server" onkeypress="return sololetras(event);" type="text" style="height:10px" class="etiquetas2"/>

            <br /><br /><br />
             <div class="datosGenerales2">
                <label style="width:50%; display:flex; justify-content:center"><b>________________________</b></label>&nbsp;&nbsp;
                 <label style="width:50%; display:flex; justify-content:center"><b>________________________</b></label>&nbsp;&nbsp;
            </div><br />

             <div class="datosGenerales2">
                <span id="NombreFirma2" runat="server" style="width:50%; display:flex; justify-content:center"></span>&nbsp;&nbsp;
                 <span id="NombreFirma" runat="server" style="width:50%; display:flex; justify-content:center"></span>&nbsp;&nbsp;
            </div>

            <div class="datosGenerales2">
                <b><span id="puesto2" runat="server" style="width:300px; display:flex; justify-content:center"><b></b></span></b>&nbsp;&nbsp;
                 <b><span id="puesto3" runat="server" style="width:300px; display:flex; justify-content:center"><b></b></span></b>&nbsp;&nbsp;
            </div><br />
            </div>
                </asp:Panel>
            <div class="datosGenerales2">
                <asp:Button ID="operar" OnClick="operar_Click" runat="server" CssClass="boton" Text="Guardar" />
              <%--  <br />
                <asp:Button ID="prueba" OnClick="prueba_Click" runat="server" CssClass="boton" Text="Imprimir" />--%>
             
            </div>
        </div>
             <script>
                 $('#<%=CAUsuario.ClientID%>').chosen();
             </script>
    </form>
</body>
  
    <script type="text/javascript"> 
        function traerArqueos() {
            //alert("FUNCIONA");
            document.getElementById('btnArqueos').click();
        }
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
    var texto1 = document.querySelector('#CANumperador');
    var texto2 = document.querySelector('#CACodigoagencia');
    var texto3 = document.querySelector('#CACantidad1');
    var texto4 = document.querySelector('#CACantidad2');
    var texto5 = document.querySelector('#CACantidad3');
    var texto6 = document.querySelector('#CACantidad4');
    var texto7 = document.querySelector('#CACantidad5');
    var texto8 = document.querySelector('#CACantidad6');
    var texto16 = document.querySelector('#CACantidad7');
    var texto9 = document.querySelector('#CACantidadm1');
    var texto10 = document.querySelector('#CACantidadm2');
    var texto11 = document.querySelector('#CACantidadm3');
    var texto12 = document.querySelector('#CACantidadm4');
    var texto13 = document.querySelector('#CACantidadm5');
    var texto14 = document.querySelector('#CACantidadm6');
    var texto15 = document.querySelector('#CAEfectivoreporte');
    var texto17 = document.querySelector('#CAAtm');

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

    texto3.addEventListener('keypress', function (e) {
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

    texto4.addEventListener('keypress', function (e) {
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

    texto5.addEventListener('keypress', function (e) {
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

    texto6.addEventListener('keypress', function (e) {
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

    texto7.addEventListener('keypress', function (e) {
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

    texto8.addEventListener('keypress', function (e) {
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

    texto9.addEventListener('keypress', function (e) {
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

    texto10.addEventListener('keypress', function (e) {
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

    texto11.addEventListener('keypress', function (e) {
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

    texto12.addEventListener('keypress', function (e) {
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

    texto13.addEventListener('keypress', function (e) {
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

    texto14.addEventListener('keypress', function (e) {
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

    texto15.addEventListener('keypress', function (e) {
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


    texto16.addEventListener('keypress', function (e) {
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

    texto17.addEventListener('keypress', function (e) {
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
    <script>
        //SUMA DE BILLETES
        function multiplicar1(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalb1').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb1').innerHTML;
                total = parseFloat(parseFloat(200.00) * parseFloat(valor));
                document.getElementById('CASubtotalb1').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb1').innerHTML;
                total = parseFloat(parseFloat(200.00) * parseFloat(valor));
                document.getElementById('CASubtotalb1').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicar2(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalb2').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb2').innerHTML;
                total = parseFloat(parseFloat(100.00) * parseFloat(valor));
                document.getElementById('CASubtotalb2').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb2').innerHTML;
                total = parseFloat(parseFloat(100.00) * parseFloat(valor));
                document.getElementById('CASubtotalb2').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicar3(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalb3').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb3').innerHTML;
                total = parseFloat(parseFloat(50.00) * parseFloat(valor));
                document.getElementById('CASubtotalb3').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb3').innerHTML;
                total = parseFloat(parseFloat(50.00) * parseFloat(valor));
                document.getElementById('CASubtotalb3').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicar4(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalb4').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb4').innerHTML;
                total = parseFloat(parseFloat(20.00) * parseFloat(valor));
                document.getElementById('CASubtotalb4').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb4').innerHTML;
                total = parseFloat(parseFloat(20.00) * parseFloat(valor));
                document.getElementById('CASubtotalb4').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicar5(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalb5').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb5').innerHTML;
                total = parseFloat(parseFloat(10.00) * parseFloat(valor));
                document.getElementById('CASubtotalb5').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb5').innerHTML;
                total = parseFloat(parseFloat(10.00) * parseFloat(valor));
                document.getElementById('CASubtotalb5').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicar6(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalb6').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb6').innerHTML;
                total = parseFloat(parseFloat(5.00) * parseFloat(valor));
                document.getElementById('CASubtotalb6').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb6').innerHTML;
                total = parseFloat(parseFloat(5.00) * parseFloat(valor));
                document.getElementById('CASubtotalb6').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicar7(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalb7').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb7').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('CASubtotalb7').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalb7').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('CASubtotalb7').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        //SUMA DE MONEDAS
        function multiplicarm1(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalm1').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm1').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('CASubtotalm1').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm1').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('CASubtotalm1').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicarm2(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalm2').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm2').innerHTML;
                total = parseFloat(parseFloat(0.50) * parseFloat(valor));
                document.getElementById('CASubtotalm2').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm2').innerHTML;
                total = parseFloat(parseFloat(0.50) * parseFloat(valor));
                document.getElementById('CASubtotalm2').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicarm3(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalm3').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm3').innerHTML;
                total = parseFloat(parseFloat(0.25) * parseFloat(valor));
                document.getElementById('CASubtotalm3').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm3').innerHTML;
                total = parseFloat(parseFloat(0.25) * parseFloat(valor));
                document.getElementById('CASubtotalm3').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicarm4(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalm4').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm4').innerHTML;
                total = parseFloat(parseFloat(0.10) * parseFloat(valor));
                document.getElementById('CASubtotalm4').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm4').innerHTML;
                total = parseFloat(parseFloat(0.10) * parseFloat(valor));
                document.getElementById('CASubtotalm4').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicarm5(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalm5').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm5').innerHTML;
                total = parseFloat(parseFloat(0.05) * parseFloat(valor));
                document.getElementById('CASubtotalm5').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm5').innerHTML;
                total = parseFloat(parseFloat(0.05) * parseFloat(valor));
                document.getElementById('CASubtotalm5').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        function multiplicarm6(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;
            var monedas = 0;
            var billetes = 0;
            var totalefectivo = 0;
            var reporte = 0;

            cantidad = document.getElementById('CASubtotalm6').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm6').innerHTML;
                total = parseFloat(parseFloat(0.01) * parseFloat(valor));
                document.getElementById('CASubtotalm6').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CASubtotalm6').innerHTML;
                total = parseFloat(parseFloat(0.01) * parseFloat(valor));
                document.getElementById('CASubtotalm6').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CATotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CATotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('CATotalm').innerHTML;
                billetes = document.getElementById('CATotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('CATotalefectivo').innerHTML = monedas.toFixed(2);

                totalefectivo = document.getElementById('CATotalefectivo').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                reporte = document.getElementById('CAEfectivoreporte').innerHTML;
                reporte = (reporte == null || reporte == undefined || reporte == "") ? 0 : reporte;
                reporte = (parseFloat(totalefectivo) - parseFloat(reporte));
                document.getElementById('CADiferencia').innerHTML = reporte.toFixed(2);
            }
        }

        //TOTAL
        function total(valor) {
            var total = 0;
            var efectivo = 0;

            valor = parseFloat(valor);
            efectivo = document.getElementById('CATotalefectivo').innerHTML;
            total = document.getElementById('CAEfectivoreporte').innerHTML;
            total = (total == null || total == undefined || total == "") ? 0 : total;
            total = (parseFloat(efectivo) - parseFloat(valor));
            document.getElementById('CADiferencia').innerHTML = total.toFixed(2);
        }

        //NOMBRE DE FIRMA
        function agregar(valor1) {
            var nombre = "";
            valor1 = valor1.toString();

            nombre = document.getElementById('CAOperador').innerHTML;
            nombre = valor1.toString();
            document.getElementById('NombreFirma2').innerHTML = nombre.toString();
        }

        function agregar2(valor1) {
            var nombre = "";
            valor1 = valor1.toString();

            nombre = document.getElementById('CAPuestooperador').innerHTML;
            nombre = valor1.toString();
            document.getElementById('puesto2').innerHTML = nombre.toString();
        }

        function agregar3(valor1) {
            var nombre = "";
            valor1 = valor1.toString();

            nombre = document.getElementById('CAPuestoencargado').innerHTML;
            nombre = valor1.toString();
            document.getElementById('puesto3').innerHTML = nombre.toString();
        }
    </script>
</html>

