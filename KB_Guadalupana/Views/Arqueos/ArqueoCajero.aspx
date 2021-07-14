<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArqueoCajero.aspx.cs" Inherits="Modulo_de_arqueos.Views.ArqueoCajero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
     <script src='https://kit.fontawesome.com/a076d05399.js'></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="css/animations.css"/>
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
        var op;
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
        .etiquetas{
            font-size: 15px;
            justify-content: flex-start;
            display: flex;
            margin: 3px;
            padding: 5px;
            width: 95%;
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
        .etiquetas4{
           font-size: 15px;
            justify-content: flex-end;
            display: flex;
            margin: 5px;
            padding: 5px;
            width: 85%;
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
        .solid {
            border-top: 3px solid #003563;
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
        .datosg{
            width: 50%;
        }

        .main-menu:hover,nav.main-menu.expanded {
        width:231px;
        overflow:visible;
        }
        #object{
	        background-color: #fe5652;

	        visibility: hidden;
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
    </div>

    <form id="form1" runat="server">
         <div style="flex-direction:column; display:flex; width:100%; margin-top:50px;">
            <asp:Button ID="Creararqueo" OnClick="creararqueo_Click" runat="server" CssClass="boton" Text="Crear nuevo arqueo" />
             <asp:Button ID="Buscararqueo" OnClick="buscararqueo_Click" runat="server" CssClass="boton" Text="Buscar arqueo" />
            </div><br />
        <div id="EBuscar" style="flex-direction:column; width:500px" runat="server" class="datosGenerales2">
            <label style="font-size:13px;display:flex;justify-content:flex-start; width:33%"><b>Fecha de realización</b></label>
             <input id="CABuscarfecha" runat="server" type="date" onchange="traerArqueos();" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 10px;padding: 5px;width:33%"/><br />

            <span id="TituloUsuario" runat="server" style="font-size:13px;display:flex;justify-content:flex-start; width:33%"><b>Usuario que lo realizó</b></span>
            <asp:DropDownList id="CAUsuario" OnSelectedIndexChanged="CAUsuario_SelectedIndexChanged" runat="server" Width="33%" class="etiquetas" AutoPostBack="true"></asp:DropDownList><br />

             <label style="font-size:13px;display:flex;justify-content:flex-start; width:33%"><b>Número de arqueo</b></label>
            <asp:DropDownList id="DropNumarqueo" runat="server" Width="35%" class="etiquetas" AutoPostBack="true"></asp:DropDownList>
            <asp:LinkButton ID="btnArqueos" runat="server" OnClick="btnArqueos_Click" ClientIDMode="Static"></asp:LinkButton><br />

            <asp:Button ID="Buscar" OnClick="buscar_Click" Width="30%" runat="server" CssClass="boton" Text="Buscar" />
            </div>
        <div id="arqueo" runat="server" class ="arqueo">
        <div id="area" runat="server">
            <div class="encabezado">
                 <img src="../../Imagenes/Logo2.png" style="top: 0; max-width: 170px; margin:30px; margin-left:20px;" />
                <h2 class="fs-title"><b>COOPERATIVA PARROQUIAL GUADALUPANA, R.L.</b></h2>
            </div>
            <p class="fs-title"><b>ARQUEO DE EFECTIVO Y VALORES</b></p>

            <div class="solid" style="margin-top: 5px;"></div>


            <p class="titulo"><b>DATOS GENERALES DEL REPORTE</b></p>
            
            <div class="datosGenerales2">
                 <label style="width:28%; display:flex; justify-content:flex-end"><b>Fecha y hora</b></label>&nbsp;&nbsp;
              <%--  <input type="datetime-local" id="CFecha" disabled="disabled" runat="server" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 10px;padding: 5px;width:30%" required/>--%>
                <input type="Text" id="CFecha" disabled="disabled" runat="server" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 10px;padding: 5px;width:30%"/>
            </div>

            <div class="datosGenerales">
                <div style="display:flex; flex-direction: row; width:100%; align-items:flex-end">
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start"><b> Código de agencia</b></label>
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start; margin-left:22%"><b>Nombre de la agencia</b></label>
                </div>
                <div style="display:flex; flex-direction: row; width:100%">
                    <asp:DropDownList id="CAgencia" OnSelectedIndexChanged="CAgencia_SelectedIndexChanged" runat="server" class="etiquetas" AutoPostBack="true"></asp:DropDownList>
                    <input id="CCAgencia" runat="server" readonly="true" type="text" placeholder="Nombre de agencia" class="etiquetas" required/>
                </div>
                <label style="width:100%; display:flex; justify-content:flex-start;margin-top:5px;"><b>Persona a quien se dirige el arqueo</b></label>
                 <div style="display:flex; flex-direction: row; width:100%; align-items:flex-end">
                    <label style="width:20%; font-size:12px; display:flex; justify-content:flex-start"><b>Nombre</b></label>
                    <label style="width:20%; font-size:12px; display:flex; justify-content:flex-start; margin-left:6%"><b>Usuario</b></label>
                     <label style="width:20%; font-size:12px; display:flex; justify-content:flex-start; margin-left:6%"><b>Operador</b></label>
                     <label style="width:20%; font-size:12px; display:flex; justify-content:flex-start; margin-left:4%"><b>Puesto</b></label>
                </div>
                 <div style="flex-direction:row; display:flex; width:100%">
                     <input id="CNombre" runat="server" onkeypress="return sololetras(event);" maxlength="50" type="text" placeholder="Nombre" class="etiquetas" required/>
                     <input id="CUsuario" runat="server" onkeypress="return sololetras(event);" maxlength="50" type="text" placeholder="Usuario" class="etiquetas" required/>
                     <input id="COperador" runat="server" maxlength="11" type="text" placeholder="Operador" class="etiquetas" required/>
                      <input id="CPuestooperador" onkeypress="return sololetras(event);" runat="server" maxlength="50" type="text" placeholder="Puesto" class="etiquetas" required/>
                 </div>
                 <label style="width:100%; display:flex; justify-content:flex-start;margin-top:5px;"><b>Persona que realiza el arqueo</b></label>
                 <div style="display:flex; flex-direction: row; width:100%; align-items:flex-end">
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start"><b>Nombre</b></label>
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start; margin-left:22%"><b>Puesto</b></label>
                </div>
                 <div style="display:flex; flex-direction: row; width:100%; align-items:center">
                     <input id="CJefe" onkeypress="return sololetras(event);" runat="server" maxlength="50" type="text" placeholder="Nombres y apellidos" class="etiquetas" onchange="agregar(this.value);" required/>
                     <input id="CPuestoencargado" runat="server" onkeypress="return sololetras(event);" maxlength="50" type="text" placeholder="Puesto" class="etiquetas" required/>
                   </div>
                <div style="display:flex; flex-direction: row; width:100%; align-items:flex-end">
                    <label style="width:28%; font-size:12px; display:flex; justify-content:flex-start;"><b>Comentario</b></label>
                </div>
                <div style="display:flex; flex-direction: row; width:100%">
                    <input id="CComentario" maxlength="50" style="width:100%" runat="server" onkeypress="return sololetras(event);" type="text" placeholder="Comentarios" class="etiquetas" required/>
                </div>
            </div>
           
            <div class="solid" style="margin-top: 5px;"></div>


            <p class="titulo2"><b>ARQUEO DE EFECTIVO EN QUETZALES</b></p>

            <div class="datosGenerales3">
                <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Descripción</b></label>
                    <label class="etiquetas2"><b>Billetes</b></label>
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
                <div style="display:flex; flex-direction: column; width:100%; justify-content:center; justify-items: center">
                    <label class="etiquetas2"><b>Cantidad</b></label>
                    <input id="CCantidad1" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicar1(this.value);"/>
                    <input id="CCantidad2" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicar2(this.value);"/>
                    <input id="CCantidad3" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicar3(this.value);"/>
                    <input id="CCantidad4" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicar4(this.value);"/>
                    <input id="CCantidad5" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicar5(this.value);"/>
                    <input id="CCantidad6" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicar6(this.value);"/>
                    <input id="CCantidad7" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicar7(this.value);"/>
                </div>
                <div style="display:flex; flex-direction: column; width:5%; padding-top:6px;">
                    <br />
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                </div>
                 <div style="display:flex; flex-direction: column; width:87%; justify-content:flex-end">
                    <label class="etiquetas2"><b>Total</b></label>
                    <span id="CBTotal1" runat="server" disabled="disabled" class="etiquetas4">0.00</span>
                    <span id="CBTotal2" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0" onchange="sumar();">0.00</span>
                    <span id="CBTotal3" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0" onchange="sumar();">0.00</span>
                    <span id="CBTotal4" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0" onchange="sumar();">0.00</span>
                    <span id="CBTotal5" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0" onchange="sumar();">0.00</span>
                    <span id="CBTotal6" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0" onchange="sumar();">0.00</span>
                    <span id="CBTotal7" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0" onchange="sumar();">0.00</span>
                </div>
            </div>

            <div class="datosGenerales3" style="margin-top:25px; margin-bottom:25px">
                 <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2"><b>Monedas</b></label>
                </div>
                <div style="display:flex; flex-direction: column; width:100%">
                    <label class="etiquetas2">Q1.00</label>
                    <label class="etiquetas2">Q0.50</label>
                    <label class="etiquetas2">Q0.25</label>
                    <label class="etiquetas2">Q0.10</label>
                    <label class="etiquetas2">Q0.05</label>
                    <label class="etiquetas2">Q0.01</label>
                </div>
                <div style="display:flex; flex-direction: column; width:100%; justify-content:center;">
                    <input id="CMCantidad1" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicarm1(this.value);"/>
                    <input id="CMCantidad2" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicarm2(this.value);"/>
                    <input id="CMCantidad3" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicarm3(this.value);"/>
                    <input id="CMCantidad4" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicarm4(this.value);"/>
                    <input id="CMCantidad5" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicarm5(this.value);"/>
                    <input id="CMCantidad6" runat="server" type="text" min="0" style="height:22px" class="etiquetas3" value="0" onchange="multiplicarm6(this.value);"/>
                </div>
                <div style="display:flex; flex-direction: column; width:5%; padding-top:0px;">
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                    <label class="etiquetas2">Q </label>
                </div>
                <div style="display:flex; flex-direction: column; width:87%">
                    <span id="CMTotal1" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0">0.00</span>
                    <span id="CMTotal2" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0">0.00</span>
                    <span id="CMTotal3" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0">0.00</span>
                    <span id="CMTotal4" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0">0.00</span>
                    <span id="CMTotal5" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0">0.00</span>
                    <span id="CMTotal6" runat="server" type="number" disabled="disabled" class="etiquetas4" value="0">0.00</span>
                </div>
            </div>

            <div class="datosGenerales2">
                 <label style="width:33%; display:flex; justify-content:flex-end"><b>Total efectivo al cierre:</b></label>&nbsp;&nbsp;
                <label style="width:5%" class="etiquetas2">Q </label>
                <span id="CTotalefectivo" runat="server" disabled="disabled" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 3px;padding: 5px;width:30%;height:22px" >0.00</span>
            </div>

            <br /><br />
             <div class="datosGenerales2">
                 <label style="width:40%; display:flex; justify-content:flex-end"><b>Total recibido de tesorería:</b></label>&nbsp;&nbsp;
                 <label style="width:5%" class="etiquetas2">Q </label>
                <input id="CTotalrecibido" runat="server" min="0" value="0" type="text" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 3px;padding: 5px;width:30%;height:22px" />
            </div>

            <div class="datosGenerales2">
                 <label style="width:40%; display:flex; justify-content:flex-end"><b>Total entregado a tesorería:</b></label>&nbsp;&nbsp;
                <label style="width:5%" class="etiquetas2">Q </label>
                <input id="CTotalentregado" min="0" runat="server" value="0" type="text" style="font-size: 15px;justify-content: flex-start;display: flex;margin: 3px;padding: 5px;width:30%;height:22px" />
            </div>
            </div>
            <br /><br />
            <div class="datosGenerales2">
                <asp:Button ID="operar" OnClick="operar_Click" runat="server" CssClass="boton" Text="Guardar" />
                <asp:Button ID="siguiente" OnClick="siguiente_Click" runat="server" CssClass="boton" Text="Siguiente >" />
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
        var texto1 = document.querySelector('#CCAgencia');
        var texto2 = document.querySelector('#COperador');
        var texto3 = document.querySelector('#CCantidad1');
        var texto4 = document.querySelector('#CCantidad2');
        var texto5 = document.querySelector('#CCantidad3');
        var texto6 = document.querySelector('#CCantidad4');
        var texto7 = document.querySelector('#CCantidad5');
        var texto8 = document.querySelector('#CCantidad6');
        var texto9 = document.querySelector('#CCantidad7');
        var texto10 = document.querySelector('#CMCantidad1');
        var texto11 = document.querySelector('#CMCantidad2');
        var texto12 = document.querySelector('#CMCantidad3');
        var texto13 = document.querySelector('#CMCantidad4');
        var texto14 = document.querySelector('#CMCantidad5');
        var texto15 = document.querySelector('#CMCantidad6');
        var texto16 = document.querySelector('#CTotalrecibido');
        var texto17 = document.querySelector('#CTotalentregado');

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
        //FUNCIONES DE BILLETES
        function multiplicar1(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CBTotal1').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal1').innerHTML;
                total = parseFloat(parseFloat(200.00) * parseFloat(valor));
                document.getElementById('CBTotal1').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal1').innerHTML;
                total = parseFloat(parseFloat(200.00) * parseFloat(valor));
                document.getElementById('CBTotal1').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
            
        }

        function multiplicar2(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CBTotal2').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal2').innerHTML;
                total = parseFloat(parseFloat(100.00) * parseFloat(valor));
                document.getElementById('CBTotal2').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal2').innerHTML;
                total = parseFloat(parseFloat(100.00) * parseFloat(valor));
                document.getElementById('CBTotal2').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        function multiplicar3(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CBTotal3').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal3').innerHTML;
                total = parseFloat(parseFloat(50.00) * parseFloat(valor));
                document.getElementById('CBTotal3').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal3').innerHTML;
                total = parseFloat(parseFloat(50.00) * parseFloat(valor));
                document.getElementById('CBTotal3').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        function multiplicar4(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CBTotal4').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal4').innerHTML;
                total = parseFloat(parseFloat(20.00) * parseFloat(valor));
                document.getElementById('CBTotal4').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal4').innerHTML;
                total = parseFloat(parseFloat(20.00) * parseFloat(valor));
                document.getElementById('CBTotal4').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        function multiplicar5(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CBTotal5').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal5').innerHTML;
                total = parseFloat(parseFloat(10.00) * parseFloat(valor));
                document.getElementById('CBTotal5').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal5').innerHTML;
                total = parseFloat(parseFloat(10.00) * parseFloat(valor));
                document.getElementById('CBTotal5').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        function multiplicar6(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CBTotal6').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal6').innerHTML;
                total = parseFloat(parseFloat(5.00) * parseFloat(valor));
                document.getElementById('CBTotal6').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal6').innerHTML;
                total = parseFloat(parseFloat(5.00) * parseFloat(valor));
                document.getElementById('CBTotal6').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        function multiplicar7(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CBTotal7').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal7').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('CBTotal7').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CBTotal7').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('CBTotal7').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        //FUNCIONES DE MONEDAS
        function multiplicarm1(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CMTotal1').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal1').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('CMTotal1').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal1').innerHTML;
                total = parseFloat(parseFloat(1.00) * parseFloat(valor));
                document.getElementById('CMTotal1').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        function multiplicarm2(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CMTotal2').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal2').innerHTML;
                total = parseFloat(parseFloat(0.50) * parseFloat(valor));
                document.getElementById('CMTotal2').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal2').innerHTML;
                total = parseFloat(parseFloat(0.50) * parseFloat(valor));
                document.getElementById('CMTotal2').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        function multiplicarm3(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CMTotal3').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal3').innerHTML;
                total = parseFloat(parseFloat(0.25) * parseFloat(valor));
                document.getElementById('CMTotal3').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal3').innerHTML;
                total = parseFloat(parseFloat(0.25) * parseFloat(valor));
                document.getElementById('CMTotal3').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        function multiplicarm4(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CMTotal4').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal4').innerHTML;
                total = parseFloat(parseFloat(0.10) * parseFloat(valor));
                document.getElementById('CMTotal4').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal4').innerHTML;
                total = parseFloat(parseFloat(0.10) * parseFloat(valor));
                document.getElementById('CMTotal4').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        function multiplicarm5(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CMTotal5').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal5').innerHTML;
                total = parseFloat(parseFloat(0.05) * parseFloat(valor));
                document.getElementById('CMTotal5').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal5').innerHTML;
                total = parseFloat(parseFloat(0.05) * parseFloat(valor));
                document.getElementById('CMTotal5').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

        function multiplicarm6(valor) {
            var cantidad = 0;
            var total = 0;
            var total2 = 0;
            var resta = 0;

            cantidad = document.getElementById('CMTotal6').innerHTML;
            if (cantidad == null || cantidad == undefined || cantidad == "") {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal6').innerHTML;
                total = parseFloat(parseFloat(0.01) * parseFloat(valor));
                document.getElementById('CMTotal6').innerHTML = total.toFixed(2);

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(total));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            } else {
                valor = parseFloat(valor);
                total = document.getElementById('CMTotal6').innerHTML;
                total = parseFloat(parseFloat(0.01) * parseFloat(valor));
                document.getElementById('CMTotal6').innerHTML = total.toFixed(2);

                resta = total - cantidad;

                total2 = document.getElementById('CTotalefectivo').innerHTML;
                total2 = (total2 == null || total2 == undefined || total2 == "") ? 0 : total2;
                total2 = (parseFloat(total2) + parseFloat(resta));
                document.getElementById('CTotalefectivo').innerHTML = total2.toFixed(2);
            }
        }

       //FIRMAS

        //function agregar(valor1) {
        //    var nombre = "";
        //    valor1 = valor1.toString();

        //    nombre = document.getElementById('CJefe').innerHTML;
        //    nombre = valor1.toString();
        //    document.getElementById('NombreFirma2').innerHTML = nombre.toString();
        //}
    </script>
</html>
