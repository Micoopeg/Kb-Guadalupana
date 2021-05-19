<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarHallazgos.aspx.cs" Inherits="KB_Guadalupana.Views.Hallazgos.ConsultarHallazgos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Consultar Hallazgos</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
</head>
<style>

        form 
{
  background: #003563;
  width: 400px;
  margin: 120px auto;
  border-radius: 0.4em;
  border: 1px solid #191919;
  overflow: hidden;
  position: relative;
  box-shadow: 0 5px 10px 5px rgba(0, 0, 0, 0.2);
}

form:after {
  content: "";
  display: block;
  position: absolute;
  height: 1px;
  width: 100px;
  left: 20%;
  background: linear-gradient(to right, #111111, #444444, #b6b6b8, #444444, #111111);
  top: 0;
}

form:before {
  content: "";
  display: block;
  position: absolute;
  width: 8px;
  height: 5px;
  border-radius: 50%;
  left: 34%;
  top: -7px;
  box-shadow: 0 0 6px 4px #fff;
}

.inset {
  padding: 20px;
  border-top: 1px solid #19191a;
}

form h1 {
  font-size: 18px;
  text-shadow: 0 1px 0 black;
  text-align: center;
  padding: 15px 0;
  border-bottom: 1px solid black;
  position: relative;
}

form h1:after {
  content: "";
  display: block;
  width: 250px;
  height: 100px;
  position: absolute;
  top: 0;
  left: 50px;
  pointer-events: none;
  transform: rotate(70deg);
  background: linear-gradient(50deg, rgba(255, 255, 255, 0.15), rgba(0, 0, 0, 0));
}

label {
  color: #666;
  display: block;
  padding-bottom: 9px;
}

input[type=text],
input[type=password] {
  width: 100%;
  padding: 8px 5px;
  background: white;
  border: 1px solid #222;
  box-shadow: 0 1px 0 rgba(255, 255, 255, 0.1);
  border-radius: 0.3em;
  margin-bottom: 20px;
}

label[for=remember] {
  color: white;
  display: inline-block;
  padding-bottom: 0;
  padding-top: 5px;
}

input[type=checkbox] {
  display: inline-block;
  vertical-align: top;
}

.p-container {
  padding: 0 20px 20px 20px;
}

.p-container:after {
  clear: both;
  display: table;
  content: "";
}

.p-container span {
  display: block;
  float: left;
  color: #0d93ff;
  padding-top: 8px;
}

input[type=submit] {
  padding: 10px 40px;
  border: 1px solid rgba(0, 0, 0, 0.4);
  text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.4);
  box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.3), inset 0 10px 10px rgba(255, 255, 255, 0.1);
  border-radius: 0.3em;
  background: #69a43c;
  color: white;
  float:left;
  font-weight: bold;
  cursor: pointer;
  font-size: 13px;
   margin-left: 125px;
}

input[type=submit]:hover {
  box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.3), inset 0 -10px 10px rgba(255, 255, 255, 0.1);
}

input[type=text]:hover,
input[type=password]:hover,
label:hover ~ input[type=text],
label:hover ~ input[type=password] {
  background:gray;
}
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
    .bo
    {
    padding: 10px 40px;
    border: 1px solid rgba(0, 0, 0, 0.4);
    text-shadow: 0 -1px 0 rgb(0 0 0 / 40%);
    box-shadow: inset 0 1px 0 rgb(255 255 255 / 30%), inset 0 10px 10px rgb(255 255 255 / 10%);
    border-radius: 0.3em;
    background: #69a43c;
    color: white;
    float: left;
    font-weight: bold;
    cursor: pointer;
    font-size: 13px;
    margin-left: 125px;
    }       
.dis
{
    padding: 8px;
    border: 1px solid #ccc;
    border-radius: 3px;
    margin-bottom: 10px;
    width: 101.5%;
    box-sizing: border-box;
    
    color: #2C3E50;
    font-size: 13px;            
}
</style>


<body >
        <div class="topnav">
            <a class="active" href="MenuHallazgos.aspx">Regresar</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 12.6%;height: -14px;margin-top: -41px;max-width: 150px;">
             <center><img class="sobre" src="Imagenes/SH-Guadalupana1.png"/></center></span>
            <a href="../Sesion/CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
    </div>
  
<div class="row" style="margin-right: 0px;" >
    <div class="col-md-6">
        <form action="Seguridad2.aspx" method="post" style="    width: 440px;margin-top: 70px;">
            <div class="inset">
                <div class="row" >
                    <p class="col-md-6">
                        <label  style="color:white;text-align: center;">No se obtuvo Respuesta</label>
                        <input style="color:Red;background-color:#003563;font-weight: bold;text-align: center;font-size: 30px;" type="text" runat="server" id="noini" disabled/>
                    </p>
                    <p class="col-md-6">
                        <label style="color:white;text-align: center;">En proceso</label>
                        <input style="color:yellow;background-color:#003563;font-weight: bold;text-align: center;font-size: 30px;" type="text" runat="server" id="ini" disabled/>
                    </p>
                     <p class="col-md-6">
                        <label style="color:white;text-align: center;">Solucionados</label>
                        <input style="color:greenyellow;background-color:#003563;font-weight: bold;text-align: center;font-size: 30px;" type="text" runat="server" id="ter" disabled/>
                    </p>
                     <p class="col-md-6">
                        <label style="color:white;text-align: center;">Nuevos</label>
                        <input style="color:greenyellow;background-color:#003563;font-weight: bold;text-align: center;font-size: 30px;" type="text" runat="server" id="Text1" disabled/>
                    </p>
                     <p class="col-md-6">
                        <label style="color:white;text-align: center;">Total Hallazgos</label>
                        <input style="color:darkorange;background-color:#003563;font-weight: bold;text-align: center;font-size: 30px;" type="text" runat="server" id="Totales" disabled/>
                    </p>
                     <p class="col-md-6">
                        <label style="color:white;text-align: center;">Eliminados</label>
                        <input style="color:#FF0B00;background-color:#003563;font-weight: bold;text-align: center;font-size: 30px;" type="text" runat="server" id="Text2" disabled/>
                    </p>
                   <p class="col-md-6">
                        <label style="color:white;text-align: center;">Solución Parcial</label>
                        <input style="color:aliceblue;background-color:#003563;font-weight: bold;text-align: center;font-size: 30px;" type="text" runat="server" id="txtsolucionparcial" disabled/>
                    </p>
                        <p class="col-md-6">
                        <label style="color:white;text-align: center;">No solucionado</label>
                        <input style="color:coral;background-color:#003563;font-weight: bold;text-align: center;font-size: 30px;" type="text" runat="server" id="txtnosolucionado" disabled/>
                    </p>
                </div>
            </div>
        </form>
    </div>
     <p class="p-container">
                <a runat="server" class="bo" style="margin-left: -430px; margin-top: 13px;position: absolute;" onclick="eliminados()"  >Reporte Eliminados</a>
            </p>
    <div class="col-md-1">
        <form id="form1" runat="server" style="margin-top: 45px;">
            <h1 style="color:white">Ver Hallazgos</h1>
                <div class="inset">
                    <div class="form-group">
                        <center><label for="isProductDiscounted" class="text-uppercase font-weight-bold;" style="color: white;">¿Desea todos los filtros?</label></center>
                            <div class="btn-group w-100" data-toggle="buttons" name="isProductDiscounted">
                                <label style="color: white;"  class="btn btn btn-blue-grey waves-effect w-50 form-check-label active">
                                    <input id="isDiscounted" class="form-check-input" style="color:white" name="isDiscounted" type="radio" /> No 
                                </label>
                                <label style="color: white;" class="btn btn btn-blue-grey waves-effect form-check-label w-50">
                                    <input id="isNotDiscounted" runat="server"  class="form-check-input" style="color:white" name="isDiscounted" type="radio"  />Si
                                </label>
                            </div>
                    </div>
                    <p>
                          <label style="color:white">Gerencia</label>
                      <asp:DropDownList id="IGAgencia1"  OnSelectedIndexChanged="IGAgencia1_SelectedIndexChanged" runat="server" class="dis" AutoPostBack="true"></asp:DropDownList>
                           
                        <label style="color:white">Area/Departamento</label>
                         <asp:DropDownList id="IGADepa1" runat="server" class="dis" AutoPostBack="true" ></asp:DropDownList>                         
                         <label style="color:white">Estado</label>                       
                        <asp:DropDownList id="cmbestado" runat="server" class="dis" AutoPostBack="true" ></asp:DropDownList>
                         
                    </p>
                    <p class="col-md-6">
                        <label style="color:white">Mes</label>
                              <select id="Mes" runat="server" class="dis">
                                <option disabled selected>Mes</option>
                                <option  value="Enero">Enero</option>
                                <option  value="Febrero">Febrero</option>
                                <option  value="Marzo">Marzo</option>
                                <option  value="Abril">Abril</option>
                                <option  value="Mayo">Mayo</option>
                                <option  value="Junio">Junio</option>
                                <option  value="Julio">Julio</option>
                                <option  value="Agosto">Agosto</option>
                                <option  value="Septiembre">Septiembre</option>
                                <option  value="Octubre">Octubre</option>
                                <option  value="Noviembre">Noviembre</option>
                                <option  value="Diciembre">Diciembre</option>
                             </select>
                             </p>
                        <p class="col-md-6" style="margin-top: -102px;margin-left: 186px;">
                        <label style="color:white">Año</label>
                            <select class="dis" runat="server" id="año" required>
                                <option disabled selected>Año</option>
                                <option  value="2020">2020</option>
                                <option  value="2021">2021</option>
                                <option  value="2022">2022</option>
                                <option  value="2023">2023</option>
                                <option  value="2024">2024</option>
                                <option  value="2025">2025</option>
                                <option  value="2026">2026</option>
                                <option  value="2027">2027</option>
                                <option  value="2028">2028</option>
                                <option  value="2029">2029</option>
                                <option  value="2030">2030</option>
                            </select>
                             </p>
                </div>
            <p class="p-container">
                <a runat="server" class="bo"  onclick="iniciar()" >Consultar</a>
            </p>
            <asp:LinkButton ID="iniciar" runat="server" OnClick="iniciar_Click" ClientIDMode="Static" style="background: border-box;"></asp:LinkButton>
            <asp:LinkButton ID="eli" runat="server" OnClick="elimi_Click" ClientIDMode="Static" style="background: border-box;"></asp:LinkButton>
        </form>
    </div>
</div>    


    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

 <script type="text/javascript">
     function iniciar()
     {
         document.getElementById('iniciar').click();
     }
     function eliminados() {
         document.getElementById('eli').click();
     }


     var discounted = document.getElementById('isDiscounted');
     var no_discounted = document.getElementById('isNotDiscounted')
     var discount_percentage = document.getElementById('IGAgencia1')
     var discount_percentage1 = document.getElementById('IGADepa1')
     var discount_percentage2 = document.getElementById('cmbestado')

     function updateStatus() {
         if (discounted.checked) {
             discount_percentage.disabled = true;
             discount_percentage1.disabled = true;
             discount_percentage2.disabled = true;
         }
         else {
             discount_percentage.disabled = false;
             discount_percentage1.disabled = false;
             discount_percentage2.disabled = false;
         }
     }

     discounted.addEventListener('change', updateStatus)
     no_discounted.addEventListener('change', updateStatus)
 </script>
</body>
</html>

