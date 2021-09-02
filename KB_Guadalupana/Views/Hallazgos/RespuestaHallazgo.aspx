<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RespuestaHallazgo.aspx.cs" Inherits="KB_Guadalupana.Views.Hallazgos.RespuestaHallazgo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Crear Hallazgos</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="../../DiseñoForms/style.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
    <style>

.content 
{
    position: absolute;
    margin-top: 238px;
    width: 18%;
    height: 103px;
    padding: 10px;
    background-color: #69a43c;
    color: white;
    right: 59px;
}
form 
{
  background: #003563;
  width: 800px;
  margin: 30px 170px;
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
        
.dis
{
padding: 8px;
    border: 1px solid #ccc;
    border-radius: 3px;
    margin-bottom: 10px;
    width: 100%;
    box-sizing: border-box;
    font-family: montserrat;
    color: #2C3E50;
    font-size: 13px;            
}
        .button {
      display: inline-block;
    border-radius: 4px;
    background-color: #69A43C;
    border: none;
    color: #FFFFFF;
    text-align: center;
    font-size: 28px;
    padding: 5px;
    width: 353px;
    transition: all 0.5s;
    cursor: pointer;
    margin: 5px;
}

.button span {
  cursor: pointer;
  display: inline-block;
  position: relative;
  transition: 0.5s;
}

.button span:after {
  content: '\00bb';
  position: absolute;
  opacity: 0;
  top: 0;
  right: -20px;
  transition: 0.5s;
}

.button:hover span {
  padding-right: 25px;
}

.button:hover span:after {
  opacity: 1;
  right: 0;
}
.button {
    display: inline-block;
    padding: 0px 1px;
    font-size: 23px;
    max-width: 154px;
    cursor: pointer;
    text-align: center;
    text-decoration: none;
    outline: none;
    color: #fff;
    background-color: #6EAB3F;
    border: none;
    border-radius: 15px;
}

.button:hover {background-color: #44AB3E}

.button:active {
  background-color: #3e8e41;
  box-shadow: 0 5px #666;
  transform: translateY(4px);
}
</style>

<body>
    <div class="topnav">
            <a class="active" href="VistaHallazgo1.aspx">Regresar</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 12.6%;height: -14px;margin-top: -41px;max-width: 150px;">
             <center><img class="sobre" src="Imagenes/SH-Guadalupana1.png"/></center></span>
            <a href="../Sesion/CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
    </div>
    <div class="row" style="margin-right: 0px;" >
  
    <div class="col-md-1">
        <form id="form1" runat="server" style="margin-top: 13px;">
             <h1 style="color:white"> Hallazgo</h1>
  <div class="inset">
      <div class="row">
         <p class="col-md-2">
            <label style="color:white">ID</label>
            <input style="height: 36px;" type="text"  id="ID" runat="server" disabled/>
        </p>
        <p class="col-md-2">
            <label style="color:white">Mes </label>
                <select id="MesH" runat="server" class="dis" disabled>
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
          <p class="col-md-2">
            <label style="color:white">Año </label>
                <select id="Año" runat="server" class="dis" disabled>
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
        
          <p class="col-md-3">
            <label style="color:white">Rubro</label>
            <input style="height: 36px;" type="text"  id="Rubro" runat="server" disabled/>
        </p>
         <p class="col-md-3" id="Subir" runat="server">
            <label style="color:white">Cargar Imagen</label>
            <br>
            <asp:FileUpload id="FileUpload1" style="margin-top: 25px;margin-left: -197px;color: white;" runat="server"  />
        </p>
        <p class="col-md-3" id="Archivo" runat="server">
            <label style="color:white">Ver Archivo</label>
            <br>
             <asp:LinkButton ID="guardarinformacion" runat="server" class="button" Text="Abrir Archivo" style="margin-left: 5px;margin-top: 0px;background-color: orange;" OnClick="Guardar_Hallazgo_Click" ClientIDMode="Static"></asp:LinkButton>
        </p>
        <p class="col-md-6">
            <label style="color:white">Hallazgo</label>
               <textarea id="Hallazgo" runat="server" name="texto" rows="3" cols="42" disabled></textarea>
        </p> 
           <p class="col-md-6">
            <label style="color:white">Recomendación</label>
            <textarea id="Recomendacion" runat="server" name="texto" rows="3" cols="42" disabled></textarea>
        </p> 
    <div id="bloqueo" runat="server">
        <p class="col-md-6">
            <label style="color:white">Solución</label>
            <textarea id="Textarea1" runat="server" name="texto" rows="3" cols="42" maxlength="1500" placeholder="HASTA 1,500 CARACTERES"></textarea>
        </p> 
       <p class="col-md-6" style="margin-top: -142px;margin-left: 394px;">
            <label style="color:white">Cargar Imagen</label>
            <br>
            <asp:FileUpload id="FileUpload2" runat="server" style="color: white;" />
             <%-- <input  type="hidden" name="MAX_FILE_SIZE" value="9194304" />--%>
             <%-- <input style="color: white;" type="file" />--%>
        </p>  
          <p class="col-md-12" style="margin-top: -35px;">
             <input type="button" style="margin-left: 300px;margin-top: 80px;" class="button" Value="Actualizar"  name="next" onclick="GuardarHallazgo()"/>
        </p>
        </div>
</div>
  </div>
         <asp:LinkButton ID="guardar" runat="server" OnClick="Guardarse_Hallazgo_Click" ClientIDMode="Static"></asp:LinkButton>
        </form>
    </div>
</div> 

     <script type="text/javascript">
      
         function Guardar()
         {
             document.getElementById('guardarinformacion').click();
         }

         function Eliminar() {
             document.getElementById('eliminar').click();
         }
         function GuardarHallazgo() {
             document.getElementById('guardar').click();
         }
      
     </script>
</body>
</html>
