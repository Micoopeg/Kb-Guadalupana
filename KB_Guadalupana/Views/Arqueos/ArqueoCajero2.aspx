<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArqueoCajero2.aspx.cs" Inherits="Modulo_de_arqueos.Views.ArqueoCajero2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src='https://kit.fontawesome.com/a076d05399.js'></script>
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
    <title>Cajero</title>
    <style>
        body{
          display:flex;
          align-items:center;
          justify-content: center;
          font-family: Arial, Helvetica, sans-serif;
          flex-direction:column;
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
            font-size: 17px;
            justify-content: flex-start;
            display: flex;
            margin-left: 15px;
        }
        .titulo2{
            font-size: 18px;
            justify-content: center;
            display: flex;
        }
        .solid {
            border-top: 3px solid #003563;
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
        .etiquetas2{
            font-size: 15px;
            justify-content: center;
            display: flex;
            margin: 5px;
            padding: 5px;
            width: 95%;
            height: 22px;
        }
        .etiquetas3{
            font-size: 15px;
            justify-content: center;
            display: flex;
            margin: 5px;
            padding: 5px;
            width: 83%;
            height: 22px;
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
        p{
            text-align: justify;
            padding: 5px 13px;
            font-size: small;
        }
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
          width: 150px;
          height:50px;
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
        }
        .nombre:hover{
            color: white;
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

        <a class="ayuda" style="right: 7%;position: absolute;margin-top: 1px;" target="_blank" href="Manual/ManualCajero.aspx" ><i class="fa fa-question" style='font-size:15px'></i>  Consultar Guía</a>
         <div style="display: flex;justify-content: center;align-items: center;">
    <div id="visualizar" runat="server" class="boton2" style="display: flex;justify-content: center;align-items: center;" onclick="obtenerimagen();">
				<a style="cursor:pointer;" class="nombre">
					Visualizar  &nbsp;
					<span class="icon">
						<i class="fa fa-file"></i>
					</span>
				</a>
			</div>
    <div id="imprimir" runat="server" class="boton2" style="display: flex;justify-content: center;align-items: center;">
				<a onclick="printPage1();" style="cursor:pointer;" class="nombre">
					Guardar / Imprimir  &nbsp;
					<span class="icon" >
						<i class="fa fa-print"></i>
					</span>
				</a>
			</div>
    </div>
    <form id="form1" runat="server">
        <div id="arqueo" runat="server" class="arqueo">
            <div id="area" runat="server">
            <div class="encabezado">
                 <img src="../../Imagenes/Logo2.png" style="top: 0; max-width: 170px; margin:30px; margin-left:20px;" />
                <h2 class="fs-title"><b>COOPERATIVA PARROQUIAL GUADALUPANA, R.L.</b></h2>
            </div>

            <p class="fs-title"><b>MANEJO DE CHEQUES</b></p>

            <div class="solid" style="margin-top: 5px;"></div>

            <p class="titulo"><b>Cheques Propios</b></p>

             <div class="datosGenerales3">
                <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Moneda</b></label>
                    <label class="etiquetas2">Quetzales</label>
                    <label class="etiquetas2">Dólares</label>
                </div>
                <div style="display:flex; flex-direction: column; width:100%; justify-content:center;">
                    <label class="etiquetas2"><b>Cantidad</b></label>
                    <input id="CPCantidad" runat="server" type="text" value="0" style="height:22px" class="etiquetas3"/>
                    <input id="CPCantidadDo" runat="server" type="text" value="0" min="0" style="height:22px" class="etiquetas3"/>
                </div>
                 <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Monto</b></label>
                     <div style="display:flex; flex-direction: row; width:100%">
                         <label style="width:5%" class="etiquetas2">Q </label>
                        <input id="CPMonto" runat="server" type="text" value="0" min="0" style="height:22px" class="etiquetas3" onchange="sumarmontoq(this.value);"/>
                     </div>
                     <div style="display:flex; flex-direction: row; width:100%">
                          <label style="width:5%" class="etiquetas2">$ </label>
                    <input id="CPMontoDo" runat="server" value="0" min="0" type="text" style="height:22px" class="etiquetas3" onchange="sumarmontod(this.value);"/>
                     </div>
                </div>
            </div>

            <br />
            <p class="titulo"><b>Cheques Ajenos</b></p>
              <div class="datosGenerales3">
                <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Moneda</b></label>
                    <label class="etiquetas2">Quetzales</label>
                    <label class="etiquetas2">Dólares</label>
                </div>
                <div style="display:flex; flex-direction: column; width:100%; justify-content:center;">
                    <label class="etiquetas2"><b>Cantidad</b></label>
                    <input id="CACantidad" runat="server" value="0" min="0" type="text" style="height:22px" class="etiquetas3"/>
                    <input id="CACantidadDo" runat="server" value="0" min="0" type="text" style="height:22px" class="etiquetas3"/>
                </div>
                 <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Monto</b></label>
                     <div style="display:flex; flex-direction: row; width:100%">
                        <label style="width:5%" class="etiquetas2">Q </label>
                        <input id="CAMonto" runat="server" value="0" min="0" type="text" style="height:22px" class="etiquetas3" onchange="sumarmontoq2(this.value);"/>
                     </div >
                     <div style="display:flex; flex-direction: row; width:100%">
                        <label style="width:5%" class="etiquetas2">$ </label>
                        <input id="CAMontoDo" runat="server" value="0" min="0" type="text" style="height:22px" class="etiquetas3" onchange="sumarmontod2(this.value);"/>
                     </div>
                </div>
            </div>

            <br /><br />
            <div class="datosGenerales2">
                 <label style="width:40%; display:flex; justify-content:flex-end"><b>Total cheques en Quetzales:</b></label>&nbsp;&nbsp;
                 <label style="width:5%" class="etiquetas2">Q </label>
                <span id="CQTotal" runat="server" type="text" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 3px;padding: 5px;width:30%;height:22px" >0.00</span>
            </div>

            <div class="datosGenerales2">
                 <label style="width:40%; display:flex; justify-content:flex-end"><b>Total cheques en Dólares:</b></label>&nbsp;&nbsp;
                 <label style="width:5%" class="etiquetas2">$ </label>
                <span id="CDTotal" runat="server" type="text" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 3px;padding: 5px;width:30%;height:22px" >0.00</span>
            </div>
            <br /><br />

            <div class="datosGenerales2">
                 <label style="width:40%; display:flex; justify-content:flex-end"><b>Boletas utilizadas:</b></label>&nbsp;&nbsp;
                <input id="CBUtilizadas" runat="server" type="text" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 3px;padding: 5px;width:30%;height:22px" />
            </div>

            <div class="datosGenerales2">
                 <label style="width:40%; display:flex; justify-content:flex-end"><b>Boletas reversadas:</b></label>&nbsp;&nbsp;
                <input id="CBReservadas" runat="server" type="text" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 3px;padding: 5px;width:30%;height:22px" />
            </div>

            <div class="datosGenerales2">
                 <label style="width:40%; display:flex; justify-content:flex-end"><b>Boletas anuladas:</b></label>&nbsp;&nbsp;
                <input id="CBAnuladas" runat="server" type="text" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 3px;padding: 5px;width:30%;height:22px" />
            </div><br />

             <div class="solid" style="margin-top: 5px;"></div>

            <p>El usuario <span id="usuarioDescripcion" runat="server"></span> con   No.  de  operador   <span id="operadorDescripción" runat="server"></span> bajo    supervisión   del    Jefe  y/o Auxiliar de Agencia,  CERTIFICAN:  Las  
                transacciones   integradas  por:   cheques y  efectivo  recibido  y  entregado en cada  una  de  las  transacciones,  concuerdan  con  
                los registros   del  sistema de cómputo BankWorks. Así  mismo, efectuaron  el  buen  uso   de   las boletas  utilizadas  en  forma  
                correlativa  que  se  mencionan  en   este arqueo  de  efectivo  y  valores.    Los  abajo firmantes nos sometemos  a  las responsabilidades 
                de cada puesto por el manejo incorrecto de los documentos y efectivo que representan.</p><br /><br />

            <div class="datosGenerales2">
                <label style="width:50%; display:flex; justify-content:center"><b>________________________</b></label>&nbsp;&nbsp;
                 <label style="width:50%; display:flex; justify-content:center"><b>________________________</b></label>&nbsp;&nbsp;
            </div><br />

             <div class="datosGenerales2">
                <span id="Nombrefirma2" runat="server" style="width:50%; display:flex; justify-content:center"></span>&nbsp;&nbsp;
                <span id="NombreFirma" runat="server" style="width:50%; display:flex; justify-content:center"/>&nbsp;&nbsp;
            </div>

            <div class="datosGenerales2">
                <b><span id="puesto2" runat="server" style="width:300px; display:flex; justify-content:center"><b></b></span></b>&nbsp;&nbsp;
                <b><span id="puesto" runat="server" style="width:300px; display:flex; justify-content:center"><b></b></span></b>&nbsp;&nbsp;
            </div><br />
                </div>
            <br /><br />
            <div class="datosGenerales2">
              <%--  <asp:Button ID="anterior" OnClick="anterior_Click" runat="server" CssClass="boton" Text="< Anterior" />--%>
                <asp:Button ID="operar" OnClick="operar_Click" runat="server" CssClass="boton" Text="Guardar" />
            </div>
        </div>
    </form>
</body>
    <script>
        var texto1 = document.querySelector('#CPCantidad');
        var texto2 = document.querySelector('#CPCantidadDo');
        var texto3 = document.querySelector('#CPMonto');
        var texto4 = document.querySelector('#CPMontoDo');
        var texto5 = document.querySelector('#CACantidad');
        var texto6 = document.querySelector('#CACantidadDo');
        var texto7 = document.querySelector('#CAMonto');
        var texto8 = document.querySelector('#CAMontoDo');
        var texto9 = document.querySelector('#CACantidadm1');
        var texto10 = document.querySelector('#CACantidadm2');
        var texto11 = document.querySelector('#CACantidadm3');
        var texto12 = document.querySelector('#CACantidadm4');
        var texto13 = document.querySelector('#CACantidadm5');
        var texto14 = document.querySelector('#CACantidadm6');
        var texto15 = document.querySelector('#CAEfectivoreporte');

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
    </script>
    <script>
        function sumarmontoq(valor1) {
            var total = 0;
            var suma = 0;
            var valor2 = 0;
            var cantidad = document.getElementById('CQTotal').innerHTML;

            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor1 = parseInt(valor1);
                total = document.getElementById('CQTotal').innerHTML;
                total = (total == null || total == undefined || total == "") ? 0 : total;
                total = (parseInt(valor1) + parseInt(0));
                document.getElementById('CQTotal').innerHTML = total.toFixed(2);
            } else {
                valor2 = document.getElementById('CAMonto').value;
                valor2 = (valor2 == null || valor2 == undefined || valor2 == "") ? 0 : valor2;
                suma = (parseInt(valor2) + parseInt(valor1));
                document.getElementById('CQTotal').innerHTML = suma.toFixed(2);
            }
            
        }

        function sumarmontoq2(valor1) {
            var total = 0;
            var suma = 0;
            var valor2 = 0;
            var cantidad = document.getElementById('CQTotal').innerHTML;

            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor1 = parseInt(valor1);
                total = document.getElementById('CQTotal').innerHTML;
                total = (total == null || total == undefined || total == "") ? 0 : total;
                total = (parseInt(valor1) + parseInt(0));
                document.getElementById('CQTotal').innerHTML = total.toFixed(2);
            } else {
                valor2 = document.getElementById('CPMonto').value;
                valor2 = (valor2 == null || valor2 == undefined || valor2 == "") ? 0 : valor2;
                suma = (parseInt(valor2) + parseInt(valor1));
                document.getElementById('CQTotal').innerHTML = suma.toFixed(2);
            }
        }

        function sumarmontod(valor1) {
            var total = 0;
            var suma = 0;
            var valor2 = 0;
            var cantidad = document.getElementById('CDTotal').innerHTML;

            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor1 = parseInt(valor1);
                total = document.getElementById('CDTotal').innerHTML;
                total = (total == null || total == undefined || total == "") ? 0 : total;
                total = (parseInt(valor1) + parseInt(0));
                document.getElementById('CDTotal').innerHTML = total.toFixed(2);
            } else {
                valor2 = document.getElementById('CAMontoDo').value;
                valor2 = (valor2 == null || valor2 == undefined || valor2 == "") ? 0 : valor2;
                suma = (parseInt(valor2) + parseInt(valor1));
                document.getElementById('CDTotal').innerHTML = suma.toFixed(2);
            }
        }

        function sumarmontod2(valor1) {
            var total = 0;
            var suma = 0;
            var valor2 = 0;
            var cantidad = document.getElementById('CDTotal').innerHTML;

            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor1 = parseInt(valor1);
                total = document.getElementById('CDTotal').innerHTML;
                total = (total == null || total == undefined || total == "") ? 0 : total;
                total = (parseInt(valor1) + parseInt(0));
                document.getElementById('CDTotal').innerHTML = total.toFixed(2);
            } else {
                valor2 = document.getElementById('CPMontoDo').value;
                valor2 = (valor2 == null || valor2 == undefined || valor2 == "") ? 0 : valor2;
                suma = (parseInt(valor2) + parseInt(valor1));
                document.getElementById('CDTotal').innerHTML = suma.toFixed(2);
            }
        }
    </script>
</html>
