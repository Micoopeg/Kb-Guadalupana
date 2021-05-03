<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteAdmin3.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.ReportesAdmin.ReporteAdmin3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Reporte Informacion General</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <link rel="stylesheet" href="../../../DiseñoForms/style.css" />
    <link rel="stylesheet" href="../../../Diseño/styleboton.css" />
    <link rel="stylesheet" href="../../../Diseño/StyleDatos.css" />
    <link rel="stylesheet" href="../../../Diseño/scriptDatos.js" />
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../../../DiseñoCss/StyleCss.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel="stylesheet" type="text/css" href="../../../Diseño/Print.css" media="print" />

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
    
</head>
    <style>
body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}

.topnav {
  overflow: hidden;
  background-color: #333;
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
  background-color: #B80416;;
  color: White;
}

.topnav a.active {
  background-color: #69a43c;
  color: white;
}

 @media print 
 {
    @page 
        { 
            margin: 0;
            size: auto; 
        }
}
</style>

<body>
      <center><img class="sobre" src="../../../Imagenes/barra.png"/></center>
    <form id="form1" runat="server">
           <div class="topnav">
            <a class="active" style="border: black 2px solid;"  href="ReporteAdmin.aspx">Regresar</a>
            <a class="active" style="border: black 2px solid;  " href="ReporteAdmin1.aspx">Informacion General</a>
            <a class="active" style="border: black 2px solid;" href="ReporteAdmin2.aspx">Declaracion de Bienes</a>
            <a class="active" style="border: black 2px solid;   background-color: #003563; " href="ReporteAdmin3.aspx">Estado Patrimonial</a>
        
            <a href="../CerrarSesion.aspx" style="right: 0%;position: absolute;border: black 2px solid;">Cerrar Sesion</a>
    </div>
    <br/>
 <div style="display: flex;justify-content: center;align-items: center;">
    <div class="col-md-3" style="display: flex;justify-content: center;align-items: center;" onclick="obtenerimagen();">
				<a href="#" style="cursor:pointer;" class="fancy-button medium half-left-rounded orange rotate shadow">
					Visualizar  &nbsp;
					<span class="icon">
						<i class="fa fa-rotate-right"></i>
					</span>
				</a>
			</div>
    <div class="col-md-3" style="display: flex;justify-content: center;align-items: center;">
				<a onclick="printPage1();" style="cursor:pointer;" class="fancy-button medium wisteria bounce bell infinite ">
					Guardar / Imprimir  &nbsp;
					<span class="icon" >
						<i class="fa fa-bell"></i>
					</span>
				</a>
			</div>
    </div>

    <div id="area" class="container">
    <br/>
    <br/>
        <div class="contenedor">
            <div class="encabezado">
               <img src="../../../Imagenes/Logotipo.png" alt="Guadalupana" style="width: 724px;height: 100px;margin-left: -24px;margin-top: -14px;">
            </div>
           <div class="encabezado1">
                <h2>ESTADO PATRIMONIAL EMPLEADOS</h2>
            </div> 
            <div class="encabezado2">
                <h2 style="font-size: 20px;color: white;">En cumplimiento al  articulo 19,  de la Ley contra el Lavado de Dinero u Otros Activos y 10 de su Reglamento declaro:</h2>
            </div>
            <div class="formulario" style="margin-left: 75px;margin-top: 15px;">
                
            <div class="encabezado2">
                <h2 style="font-size: 25px;color: white;">Activos</h2>
            </div>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -30px;">Efectivo en Caja:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0;margin-left: 10px;" class="col-sm-4" type="text" runat="server" id="EfectivoCaja" disabled/>
                    </div>
                  <br/>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Cuentas en Bancos:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-3" type="text" runat="server" placeholder="0" id="CuentasBancos" disabled/>  
                        <center><label class="col-sm-1" for="apellido">$</label></center>
                        <input style="border: 0;margin-left: -20px;" class="col-sm-3" type="text" runat="server" placeholder="0" id="CuentasBancos1" disabled/>
                    </div>
                  <br/>
               <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido">Cuentas en Cooperativas:</label></center>
                        <center><label class="col-sm-1" for="apellido">Q</label></center>
                        <input style="border: 0;margin-left: -20px;" class="col-sm-3" type="text" placeholder="0" runat="server" id="CuentasCope" disabled/>
                        <center><label class="col-sm-1" for="apellido">$</label></center>
                        <input style="border: 0;margin-left: -20px;" class="col-sm-3" type="text" placeholder="0" runat="server" id="CuentasCope1" disabled/>
                    </div>
                  <br/>
              <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Cuentas por cobrar:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="CuentasPC" disabled/>
                    </div>
                  <br/>
              <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Inventarios:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Inventario" disabled/>
                    </div>
               <br/>
               <br/>  
           <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Activos Fijos</h2>
            </div>
                    <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Bienes Inmuebles:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Inmueble" disabled/>
                    </div>
                  <br/>
                    <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Vehiculos:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Vehiculo" disabled/>
                    </div>
                  <br/>
                    <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Maquinaria y Equipo:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Maquinaria" disabled/>
                    </div>
                <br/>
                 <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Inversiones:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Text1" disabled/>
                    </div>
                <br />
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Fondo FENAFORE:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Text4" disabled/>
                    </div>
                <br/>  
                <br/>  
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Mobiliario y Equipo</h2>
            </div>
                 <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Equipo Computo:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Computo" disabled/>
                    </div>
                  <br/>
                    <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Amueblado Sala:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="sala" disabled/>
                    </div>
                  <br/>
                    <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Amueblado Comedor:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="comedor" disabled/>
                    </div>
                  <br/>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Televisor:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="TV" disabled/>
                    </div>
                  <br/>
                  <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Equipo de Sonido:</label></center>
                      <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="EquipoS" disabled/>
                    </div>
                  <br/>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Lavadora:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="lava" disabled/>
                    </div>
                  <br/>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Secadora:</label></center>
                         <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="SECA" disabled/>
                    </div>
                  <br/>
                  <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Estufa:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Estufa" disabled/>
                    </div>
                  <br/>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Refrigeradora:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Refri" disabled/>
                    </div>
                <br/>
                 <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Telefono Movil:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Movil" disabled/>
                    </div>
                <br/>
                 <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;">Otros Activos:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="otross" disabled/>
                    </div>
                 <br/>
                <hr style="border-color:#003563;">
                  <div class="campo" style="margin-left: -5px;" >

                        <center><label class="col-sm-4" for="apellido" style="margin-left: -20px;color: #69a43c;    font-size: 22px;">Total Activo:</label></center>
                        <center><label class="col-sm-1" for="apellido" style="text-align: right">Q</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" placeholder="0" id="Text14" disabled/>
                        <center><label class="col-sm-1" for="apellido">$</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" placeholder="0" id="Text23" disabled/>
                    </div><br>
                <hr style="border-color:#003563;">
                <div class="encabezado2">
                <h2 style="font-size: 25px;color: white;">Pasivos</h2>
            </div>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-5" for="apellido" style="">Cuentas por pagar:</label></center>
                        <input style="border: 0;" class="col-sm-4" type="text" placeholder="0" runat="server" id="CuentaPP" disabled/>
                    </div>
                  <br/>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-5" for="apellido" style="">Prestamos:</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="Pres" disabled/>
                    </div>
                  <br/>
               <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-5" for="apellido">Tarjetas de Credito:</label></center>
                        <input style="border: 0;" class="col-sm-4" type="text" placeholder="0" runat="server" id="TC" disabled/>
                    </div>
                  <br/>
              <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-5" for="apellido" style="">Otras deudas:</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="ode" disabled/>
                    </div>
                 <br/>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-5" for="apellido" style="">Pasivo Contigente:</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0"  id="pasc" disabled/>
                    </div>
               <br/>
                  <hr style="border-color:#003563;">
                  <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-5" for="apellido" style="margin-left: -20px;color: #69a43c;    font-size: 22px;">Total Pasivo:</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="TotalPasivo" disabled/>
                    </div><br>
                <hr style="border-color:#003563;">
                <hr style="border-color:#003563;">
                  <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-5" for="apellido" style="margin-left: -20px;color: #69a43c;    font-size: 22px;">Patrimonio (Activo - Pasivo):</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" placeholder="0" id="pat" disabled/>
                    </div>
                 <br /><hr style="border-color:#003563;">
           
                <hr style="border-color:#003563;">
                 <div class="encabezado2">
                <h2 style="font-size: 20px;color: white;">Declaro bajo juramento que los datos consignados en el presente documento, son verdaderos y ciertos y me someto  a lo establecido en las leyes del país, en caso de perjurio.</h2>
            </div>
                 <div class="campo" style="margin-left:25px;" >
                        <center><label class="col-sm-8" for="apellido">Usuario:</label></center>
                         <input   style="border: 0;margin-left: -122px;background-color: white;font-weight: bold;font-size: 20px;margin-top: -16px;"  class="col-sm-4" type="text"  runat="server" id="Text2" disabled/>
                         <input  style="border: 0;margin-left: 461px; margin-top: -5px; background-color: white;font-weight: bold;"  class="col-sm-4" type="text"  runat="server" id="Text3" disabled/>
                 </div>
                <br />
                <br />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
