<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArqueoTesoreria2.aspx.cs" Inherits="Modulo_de_arqueos.Views.ArqueoTesoreria2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
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
    <title>Tesoreria</title>
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
            width: 88%;
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
            width:100%;
        }
       table th{
           background-color:#0076DE;
           color: white;
           padding: 5px;
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
            <a class="active" href="MenuArqueos.Aspx">Inicio</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b runat="server" id="NombreUsuario"></b></span>
            <a href="../Sesion/CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
        </div>

      <a id="ayuda" runat="server" class="ayuda" style="right: 7%;position: absolute;margin-top: 1px;" target="_blank" href="Manual/ManualTesoreria.aspx" ><i class="fa fa-question" style='font-size:15px'></i>  Consultar Guía</a>
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
						<i class="fas fa-print"></i>
					</span>
				</a>
			</div>
    </div>
    <form id="form1" runat="server">
        <div class="arqueo">
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
               <%-- <input id="TDFechayhora" runat="server" type="datetime-local" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 10px;padding: 5px;width:42%" required/>--%>
                 <input id="TDFechayhora" runat="server" type="Text" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 10px;padding: 5px;width:42%" required/>
            </div>

             <div class="datosGenerales">
                  <div style="display:flex; flex-direction: row; width:100%; align-items:flex-end">
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start"><b> Código de agencia</b></label>
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start; margin-left:22%"><b>Nombre de la agencia</b></label>
                </div>
                   <div style="display:flex; flex-direction: row; width:100%">
                     <asp:DropDownList id="TDAgencia" OnSelectedIndexChanged="TDAgencia_SelectedIndexChanged" runat="server" class="etiquetas" AutoPostBack="true"></asp:DropDownList>
                      <input id="TDCodigoagencia" runat="server" readonly="true" type="text" placeholder="Nombre de agencia" class="etiquetas" required/>
                  </div>
                 <label style="width:100%; display:flex; justify-content:flex-start;margin-top:5px;"><b>Persona que realiza el arqueo</b></label>
                   <div style="display:flex; flex-direction: row; width:100%; align-items:flex-end; margin-top:3px;">
                    <label style="width:20%; font-size:12px; display:flex; justify-content:flex-start"><b>Nombre</b></label>
                     <label style="width:20%; font-size:12px; display:flex; justify-content:flex-start; margin-left:14%"><b>Operador</b></label>
                     <label style="width:20%; font-size:12px; display:flex; justify-content:flex-start; margin-left:13%"><b>Puesto</b></label>
                </div>
                  <div style="display:flex; flex-direction: row; width:100%; align-items:center">
                     <input id="TDNombreop" maxlength="50" runat="server" onkeypress="return sololetras(event);" type="text" placeholder="Nombres y apellidos (operador)" class="etiquetas" onchange="agregar(this.value)" required/>
                     <input id="TDNumoperador" maxlength="11" runat="server" type="text" placeholder="No. operador" class="etiquetas" required/>
                     <input id="TDPuestooperador" maxlength="50" runat="server" onkeypress="return sololetras(event);" type="text" placeholder="Puesto" class="etiquetas" onchange="agregar2(this.value)" required/>
                  </div>
                  <label style="width:100%; display:flex; justify-content:flex-start;margin-top:5px;"><b>Persona a quien se dirige el arqueo</b></label>
                   <div style="display:flex; flex-direction: row; width:100%; align-items:flex-end; margin-top:3px;">
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start"><b>Nombre</b></label>
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start; margin-left:22%"><b>Puesto</b></label>
                </div>
                 <div style="display:flex; flex-direction: row; width:100%; align-items:center">
                     <input id="TDNombreencargado" maxlength="50" runat="server" onkeypress="return sololetras(event);" type="text" placeholder="Nombres y apellidos" class="etiquetas" required/>
                     <input id="TDPuestoencargado" maxlength="50" runat="server" onkeypress="return sololetras(event);" type="text" placeholder="Puesto" class="etiquetas" onchange="agregar3(this.value)" required/>
                </div>
                 <div style="display:flex; flex-direction: row; width:100%; align-items:center">
                    <label class="etiquetas2"><b>Fondo: </b></label>
                   <%-- &nbsp;$<input id="TDReceptoria" runat="server" type="number" placeholder="Receptoría" class="etiquetas" required/>--%>
                    &nbsp;$<input id="TDTesoreria" runat="server" maxlength="11" type="text" placeholder="Tesorería" class="etiquetas" required/>
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
                    <input id="TDCantidadb1" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar1(this.value);"/>
                    <input id="TDCantidadb2" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar2(this.value);"/>
                    <input id="TDCantidadb3" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar3(this.value);"/>
                    <input id="TDCantidadb4" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar4(this.value);"/>
                    <input id="TDCantidadb5" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar5(this.value);"/>
                    <input id="TDCantidadb6" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar6(this.value);"/>
                    <input id="TDCantidadb7" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicar7(this.value);"/>
                </div>
                <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Denominación</b></label>
                    <label class="etiquetas2">$200.00</label>
                    <label class="etiquetas2">$100.00</label>
                    <label class="etiquetas2">$50.00</label>
                    <label class="etiquetas2">$20.00</label>
                    <label class="etiquetas2">$10.00</label>
                    <label class="etiquetas2">$5.00</label>
                    <label class="etiquetas2">$1.00</label>
                </div>
                 <div style="display:flex; flex-direction: column; width:5%">
                     <br /><br />
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                </div>
                 <div style="display:flex; flex-direction: column; width:88%">
                    <label class="etiquetas2"><b>Sub-total</b></label>
                    <span id="TDSubtotalb1" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalb2" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalb3" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalb4" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalb5" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalb6" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalb7" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <div class="solid" style="margin-top: 5px;"></div>
                </div>
                 <div style="display:flex; flex-direction: column; width:7%; margin-left:3px;">
                     <br /><br /><br />
                     <br /><br /><br />
                     <br /><br /><br />
                     <br /><br /><br />
                     <br /><br />
                     <label class="etiquetas4">$ </label>
                </div>
                 <div style="display:flex; flex-direction: column; width:87%; align-items:flex-end">
                    <label class="etiquetas2"><b>Total</b></label>
                     <br /><br /><br />
                     <br /><br /><br />
                     <br /><br /><br />
                     <br /><br /><br />
                      <span id="TDTtotalb" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                </div>
            </div>

             <div class="datosGenerales3" style="margin-top:25px; margin-bottom:25px">
                 <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Monedas</b></label>
                </div>
                 <div style="display:flex; flex-direction: column; width:100%; justify-content:center;">
                    <input id="TDCantidadm1" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicarm1(this.value);"/>
                    <input id="TDCantidadm2" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicarm2(this.value);"/>
                    <input id="TDCantidadm3" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicarm3(this.value);"/>
                    <input id="TDCantidadm4" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicarm4(this.value);"/>
                    <input id="TDCantidadm5" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicarm5(this.value);"/>
                    <input id="TDCantidadm6" runat="server" type="text" min="0" value="0" style="height:10px" class="etiquetas3" onchange="multiplicarm6(this.value);"/>
                </div>
                <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2">$1.00</label>
                    <label class="etiquetas2">$0.50</label>
                    <label class="etiquetas2">$0.25</label>
                    <label class="etiquetas2">$0.10</label>
                    <label class="etiquetas2">$0.05</label>
                    <label class="etiquetas2">$0.01</label>
                </div>
                  <div style="display:flex; flex-direction: column; width:7%">
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                    <label class="etiquetas2">$ </label>
                </div>
                <div style="display:flex; flex-direction: column; width:87%">
                    <span id="TDSubtotalm1" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalm2" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalm3" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalm4" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalm5" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <span id="TDSubtotalm6" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                    <div class="solid" style="margin-top: 5px;"></div>
                </div>
                 <div style="display:flex; flex-direction: column; width:4%">
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <label class="etiquetas4">$ </label>
                </div>
                 <div style="display:flex; flex-direction: column; width:100%; align-items:flex-end">
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <br /><br />
                     <br /><br />
                      <span id="TDTotalm" runat="server" disabled="disabled" type="number" value="0" class="etiquetas5">0.00</span>
                     <div class="solid" style="margin-top: 5px;width:85%"></div>
                </div>
            </div>

            <div class="datosGenerales3" style="margin-top:25px; margin-bottom:25px">
                 <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas4">Total efectivo</label>
                    <label class="etiquetas4">(+) Solicitud de efectivo</label>
                    <label class="etiquetas2">Depósito</label>
                </div>
                 <div style="display:flex; flex-direction: column; width:5%">
                    <label class="etiquetas4"><b>$ </b></label>
                    <label class="etiquetas4"><b>$ </b></label>
                    <br />
                    <label class="etiquetas4"><b>$ </b></label>
                    <br />
                </div>
                <div style="display:flex; flex-direction: column; width:20%">
                    <span id="TDTotal" runat="server" type="number" disabled="disabled" value="0" class="etiquetas5">0.00</span>
                    <input id="TDRemesa" runat="server" type="text" min="0" style="height:10px" value="0" class="etiquetas4" onchange="remesa(this.value);"/>
                    <div class="solid" style="margin-top: 5px;"></div>
                    <span id="TDDeposito" runat="server" type="number" disabled="disabled" style="height:10px" value="0" class="etiquetas5">0.00</span>
                    <div class="solid" style="margin-top: 5px;"></div>
                </div>
            </div>
              <label style="display:flex; justify-content:flex-start;font-size:20px;margin-bottom:15px;" class="etiquetas2"><b>Cheques</b></label>
            <table>
                <tr>
                    <th class="td2">Documento</th>
                    <th class="td2">Cantidad</th>
                    <th class="td2">Monto $</th>
                </tr>
                <tr>
                    <td class="td2">Cheques propios</td>
                    <td class="td2"><input id="TDChequesp" runat="server" type="text" min="0" value="0" style="height:10px;width:90%;" class="etiquetasTabla" onchange="cantidadcheques(this.value);"/></td>
                    <td class="td2"><input id="TDMontop" maxlength="11" runat="server" type="text" min="0" value="0" style="height:10px;width:90%;" class="etiquetasTabla" onchange="montocheques(this.value);"/></td>
                </tr>
                 <tr>
                    <td class="td4">Cheques ajenos</td>
                    <td class="td4"><input id="TDChequesa" runat="server" min="0" type="text" value="0" style="height:10px;width:90%;" class="etiquetasTabla" onchange="cantidadcheques2(this.value);"/></td>
                    <td class="td4"><input id="TDMontoa" maxlength="11" runat="server" min="0" type="text" value="0" style="height:10px;width:90%;" class="etiquetasTabla" onchange="montocheques2(this.value);"/></td>
                </tr>
                 <tr>
                    <td class="td">Totales</td>
                    <td class="td"><span id="TDTotalcheques" runat="server" type="number" value="0" style="height:10px;width:90%;display:flex; justify-content:flex-end" class="etiquetasTabla">0</span></td>
                    <td style="display:flex; flex-direction:row;" class="td"><b style="display:flex;align-items:center">$ </b><span id="TDTotalmonto" runat="server" type="number" value="0" style="height:10px;width:90%;display:flex; justify-content:flex-end" class="etiquetasTabla">0.00</span></td>
                </tr>
            </table>

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
            <div class="datosGenerales2">
                <%--<asp:LinkButton ID="atras" OnClick="atras_Click" runat="server" CssClass="boton" Text="< Atrás" />--%>
                <asp:Button ID="operar" OnClick="operar_Click" runat="server" CssClass="boton" Text="Guardar" />
            </div>
        </div>
    </form>
</body>
        <script type="text/javascript">
            function sololetras(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return true;

                return false;
            }
        </script>
    <script>
        var texto1 = document.querySelector('#TDCodigoagencia');
        var texto2 = document.querySelector('#TDNumoperador');
        var texto3 = document.querySelector('#TDCantidadb1');
        var texto4 = document.querySelector('#TDCantidadb2');
        var texto5 = document.querySelector('#TDCantidadb3');
        var texto6 = document.querySelector('#TDCantidadb4');
        var texto7 = document.querySelector('#TDCantidadb5');
        var texto8 = document.querySelector('#TDCantidadb6');
        var texto16 = document.querySelector('#TDCantidadb7');
        var texto9 = document.querySelector('#TDCantidadm1');
        var texto10 = document.querySelector('#TDCantidadm2');
        var texto11 = document.querySelector('#TDCantidadm3');
        var texto12 = document.querySelector('#TDCantidadm4');
        var texto13 = document.querySelector('#TDCantidadm5');
        var texto14 = document.querySelector('#TDCantidadm6');
        var texto15 = document.querySelector('#TDRemesa');
        var texto17 = document.querySelector('#TDChequesp');
        var texto18 = document.querySelector('#TDMontop');
        var texto19 = document.querySelector('#TDChequesa');
        var texto20 = document.querySelector('#TDMontoa');
        var texto21 = document.querySelector('#TDTesoreria');

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

        texto18.addEventListener('keypress', function (e) {
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

        texto19.addEventListener('keypress', function (e) {
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

        texto20.addEventListener('keypress', function (e) {
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

        texto21.addEventListener('keypress', function (e) {
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalb1').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb1').innerHTML;
                total = parseFloat(parseFloat(200.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb1').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb1').innerHTML;
                total = parseFloat(parseFloat(200.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb1').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalb2').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb2').innerHTML;
                total = parseFloat(parseFloat(100.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb2').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb2').innerHTML;
                total = parseFloat(parseFloat(100.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb2').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalb3').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb3').innerHTML;
                total = parseFloat(parseFloat(50.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb3').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb3').innerHTML;
                total = parseFloat(parseFloat(50.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb3').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalb4').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb4').innerHTML;
                total = parseFloat(parseFloat(20.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb4').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb4').innerHTML;
                total = parseFloat(parseFloat(20.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb4').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalb5').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb5').innerHTML;
                total = parseFloat(parseFloat(10.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb5').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb5').innerHTML;
                total = parseFloat(parseFloat(10.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb5').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalb6').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb6').innerHTML;
                total = parseFloat(parseFloat(5.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb6').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb6').innerHTML;
                total = parseFloat(parseFloat(5.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb6').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalb7').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb7').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb7').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalb7').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('TDSubtotalb7').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTtotalb').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTtotalb').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalm1').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm1').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('TDSubtotalm1').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm1').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('TDSubtotalm1').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalm2').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm2').innerHTML;
                total = parseFloat(parseFloat(0.50) * parseFloat(valor));
                document.getElementById('TDSubtotalm2').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm2').innerHTML;
                total = parseFloat(parseFloat(0.50) * parseFloat(valor));
                document.getElementById('TDSubtotalm2').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalm3').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm3').innerHTML;
                total = parseFloat(parseFloat(0.25) * parseFloat(valor));
                document.getElementById('TDSubtotalm3').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm3').innerHTML;
                total = parseFloat(parseFloat(0.25) * parseFloat(valor));
                document.getElementById('TDSubtotalm3').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalm4').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm4').innerHTML;
                total = parseFloat(parseFloat(0.10) * parseFloat(valor));
                document.getElementById('TDSubtotalm4').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm4').innerHTML;
                total = parseFloat(parseFloat(0.10) * parseFloat(valor));
                document.getElementById('TDSubtotalm4').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalm5').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm5').innerHTML;
                total = parseFloat(parseFloat(0.05) * parseFloat(valor));
                document.getElementById('TDSubtotalm5').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm5').innerHTML;
                total = parseFloat(parseFloat(0.05) * parseFloat(valor));
                document.getElementById('TDSubtotalm5').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
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
            var solicitud = 0;
            var entrega = 0;

            cantidad = document.getElementById('TDSubtotalm6').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm6').innerHTML;
                total = parseFloat(parseFloat(0.01) * parseFloat(valor));
                document.getElementById('TDSubtotalm6').innerHTML = total.toFixed(2);

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('TDSubtotalm6').innerHTML;
                total = parseFloat(parseFloat(0.01) * parseFloat(valor));
                document.getElementById('TDSubtotalm6').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('TDTotalm').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('TDTotalm').innerHTML = total2.toFixed(2);

                monedas = document.getElementById('TDTotalm').innerHTML;
                billetes = document.getElementById('TDTtotalb').innerHTML;
                billetes = (billetes == null || billetes == undefined || billetes == "") ? 0 : billetes;
                monedas = (monedas == null || monedas == undefined || monedas == "") ? 0 : monedas;
                monedas = (parseFloat(monedas) + parseFloat(billetes));
                document.getElementById('TDTotal').innerHTML = monedas.toFixed(2);

                entrega = document.getElementById('TDRemesa').value;
                entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
                totalefectivo = document.getElementById('TDTotal').innerHTML;
                totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
                totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
                document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
            }
        }

        //REMESA
        function remesa(valor) {
            var entrega = 0;
            var totalefectivo = 0;

            entrega = document.getElementById('TDRemesa').value;
            entrega = (entrega == null || entrega == undefined || entrega == "") ? 0 : entrega;
            totalefectivo = document.getElementById('TDTotal').innerHTML;
            totalefectivo = (totalefectivo == null || totalefectivo == undefined || totalefectivo == "") ? 0 : totalefectivo;
            totalefectivo = (parseFloat(totalefectivo) + parseFloat(entrega));
            document.getElementById('TDDeposito').innerHTML = totalefectivo.toFixed(2);
        }

        //CANTIDAD CHEQUES
        function cantidadcheques(valor1) {
            var total = 0;
            var suma = 0;
            var valor2 = 0;
            var cantidad = document.getElementById('TDTotalcheques').innerHTML;
            valor1 = parseInt(valor1);

            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor1 = parseInt(valor1);
                total = document.getElementById('TDTotalcheques').innerHTML;
                total = (total == null || total == undefined || total == "") ? 0 : total;
                total = (parseInt(valor1) + parseInt(0));
                document.getElementById('TDTotalcheques').innerHTML = total.toFixed(0);
            } else {
                valor2 = document.getElementById('TDChequesa').value;
                suma = (parseInt(valor2) + parseInt(valor1));
                document.getElementById('TDTotalcheques').innerHTML = suma.toFixed(0);
            }

        }

        function cantidadcheques2(valor1) {
            var total = 0;
            var suma = 0;
            var valor2 = 0;
            var cantidad = document.getElementById('TDTotalcheques').innerHTML;
            valor1 = parseInt(valor1);

            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor1 = parseInt(valor1);
                total = document.getElementById('TDTotalcheques').innerHTML;
                total = (total == null || total == undefined || total == "") ? 0 : total;
                total = (parseInt(valor1) + parseInt(0));
                document.getElementById('TDTotalcheques').innerHTML = total.toFixed(0);
            } else {
                valor2 = document.getElementById('TDChequesp').value;
                suma = (parseInt(valor2) + parseInt(valor1));
                document.getElementById('TDTotalcheques').innerHTML = suma.toFixed(0);
            }

        }

        //MONTO CHEQUES
        function montocheques(valor1) {
            var total = 0;
            var suma = 0;
            var valor2 = 0;
            var cantidad = document.getElementById('TDTotalmonto').innerHTML;
            valor1 = parseInt(valor1);

            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor1 = parseInt(valor1);
                total = document.getElementById('TDTotalmonto').innerHTML;
                total = (total == null || total == undefined || total == "") ? 0 : total;
                total = (parseInt(valor1) + parseInt(0));
                document.getElementById('TDTotalmonto').innerHTML = total.toFixed(2);
            } else {
                valor2 = document.getElementById('TDMontoa').value;
                suma = (parseInt(valor2) + parseInt(valor1));
                document.getElementById('TDTotalmonto').innerHTML = suma.toFixed(2);
            }

        }

        function montocheques2(valor1) {
            var total = 0;
            var suma = 0;
            var valor2 = 0;
            var cantidad = document.getElementById('TDTotalmonto').innerHTML;
            valor1 = parseInt(valor1);

            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor1 = parseInt(valor1);
                total = document.getElementById('TDTotalmonto').innerHTML;
                total = (total == null || total == undefined || total == "") ? 0 : total;
                total = (parseInt(valor1) + parseInt(0));
                document.getElementById('TDTotalmonto').innerHTML = total.toFixed(2);
            } else {
                valor2 = document.getElementById('TDMontop').value;
                suma = (parseInt(valor2) + parseInt(valor1));
                document.getElementById('TDTotalmonto').innerHTML = suma.toFixed(2);
            }

        }

        //NOMBRE FIRMA
        function agregar(valor1) {
            var nombre = "";
            valor1 = valor1.toString();

            nombre = document.getElementById('TDNombreop').innerHTML;
            nombre = valor1.toString();
            document.getElementById('NombreFirma2').innerHTML = nombre.toString();
        }

        function agregar2(valor1) {
            var nombre = "";
            valor1 = valor1.toString();

            nombre = document.getElementById('TDPuestooperador').innerHTML;
            nombre = valor1.toString();
            document.getElementById('puesto2').innerHTML = nombre.toString();
        }

        function agregar3(valor1) {
            var nombre = "";
            valor1 = valor1.toString();

            nombre = document.getElementById('TDPuestoencargado').innerHTML;
            nombre = valor1.toString();
            document.getElementById('puesto3').innerHTML = nombre.toString();
        }
    </script>
</html>

