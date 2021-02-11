<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AyudaPep.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.Ayudas.AyudaPep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Manual Usuario</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="../../DiseñoCss/StyleCss.css" type="text/css" />
</head>
    <style>
.tarjeta 
{
  width: 80%;
  min-height: 300px;
  background-color: white;
  display: grid;
  grid-template-columns: 2fr 3fr;
  grid-template-rows: 1fr;
}
.tarjeta1 
{
  width: 80%;
  min-height: 300px;
  background-color: white;
  display: grid;
  grid-template-columns: 2fr 1fr;
  grid-template-rows: 1fr;
}
.tarjeta2 
{
  width: 80%;
  min-height: 300px;
  background-color: white;
  display: grid;
  grid-template-columns: 2fr 3fr;
  grid-template-rows: 1fr;
}
.tarjeta3
{
  width: 80%;
  min-height: 300px;
  background-color: white;
  display: grid;
  grid-template-columns: 2fr 1fr;
  grid-template-rows: 1fr;
}

.foto 
{
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
    padding: 13px;
    width: 505px;
    height: 275px;
    background-size: 100% 100%;
    background-repeat: no-repeat;
}
.foto1 
{
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
    padding: 13px;
    width: 505px;
    height: 275px;
    background-size: 100% 100%;
    background-repeat: no-repeat;
}
.foto2 
{
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
    padding: 13px;
    width: 505px;
    height: 220px;
    background-size: 100% 100%;
    background-repeat: no-repeat;
}
.foto3
{
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
    padding: 13px;
    width: 505px;
    height: 210px;
    background-size: 100% 100%;
    background-repeat: no-repeat;
}

.frase {
  font-family: sans-serif;
  font-size: 2em;
  color: #77ce97;
}

.frase p {
  margin-bottom: 20px;
}

.boton {
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  text-decoration: none;
  font-family: sans-serif;
  font-size: .6em;
  padding: 10px;
  color: #fff;
  background-color: #77ce97;
  border-radius: 5%;
}

.texto {
    justify-content: center;
    align-items: center;
    padding: 4em;
    color: #333;
    text-align: center;
    font-size: 15px;
}
}

@media (max-width: 700px) {
  .tarjeta {
    grid-template-columns: 1fr;
    grid-template-rows: 2fr 3fr;
  }
  .foto {
    grid-column: 1 / 2;
    grid-row: 1 / 2;
    padding: 2em;
  }
  .texto {
    grid-column: 1 / 2;
    grid-row: 2 / 3;
    padding: 2em;
  }
  
}

* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

header {
  box-sizing: border-box;
  display: flex;
  flex-direction: row;
  justify-content: center;
  margin: 50px auto;
  width: 100%;
}

#contenedor-logo {
  border-right: 3px solid black;
  margin-right: 10px;
  padding-right: 20px;
  text-align: right;
}

#logo-ntln{  
  border-radius: 50%;
  max-width: 100px;
  height: auto;  
}

#contenedor-texto {
  display:flex;
  flex-direction: column;
  height:100px;
  justify-content: space-around;
  padding-left: 10px;
}

#contenedor-texto h1 {
  font-family: 'BenchNine', sans-serif;
  font-size: 3em;
  text-transform: capitalize;
}

#contenedor-texto p {
  font-family: 'BenchNine', sans-serif;
  font-size: 1.5em;
}

#contenedor-texto i{
  padding: 5px;
}

main {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
}

.descripcion {
  align-self: flex-end;
  color: #6d5f5e;
  font-family: 'Indie Flower';
  font-size: 1.5em;
  margin-left: 50px;
  padding-bottom: 20px;
}

.descripcion li {
  list-style: none;
}

.descripcion li::before {
  content: "- ";
}

.sombra{
  box-shadow: 0 1px 4px 0 rgba(0,0,0,.14);
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
        
</style>

<body>
     <form id="form1" runat="server">
       
    <div class="topnav">
            <a class="active" href="../MantenimientoCuentas.aspx" >Regresar</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b style="margin-left: -117px;">Manual De Usuario Mantenimiento Pep</b></span>
            <a href="../CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
    </div>
    <br>
    <br>
    <main>
        
<section class="tarjeta">
    <div>
        <img class="foto" src="../../../Imagenes/Imagenes/KB.PNG">
      <div class="frase">
      </div>
    </div>
    <p class="texto" >Al ingresar al sistema <b style="color:#003563">KB - Guadalupana</b> <i class="fa fa-sign-in" ></i> Area Administrativa, se podra visualizar 2 opciones de:
        <br>
        <br>
        <b>1. Mantenimiento Lotes</b>
        <br>
        <b>2. Area administrativa cumplimiento</b></p>
</section>
        
        
<section class="tarjeta1">
        <p class="texto" style="text-align: justify">Al ingresar a la opcion de Area Administrativa Cumplimiento <i class="fa fa-sign-in" ></i>Pep, se podran vizualizar los diccionarios del mantenimiento Pep que se le mostraran al usuario. </p>
    <div class="frase">
      <div >
            <img class="foto1" src="../../../Imagenes/Imagenes/MantenimientoPep.PNG">
      </div>
    </div>
</section>
        
        
<section class="tarjeta2">
    <div>
         <img class="foto2" src="../../../Imagenes/Imagenes/MantenimientoPep1.PNG">
      <div class="frase">
      </div>
    </div>
    <p class="texto" style="text-align: justify">Para poder agregar una nueva opcion se deben llenar los 2 campos del formulario luego se debe dar click en el icono de mas para poder guardar el registro.</p>
  </section>
        
<section class="tarjeta3">
        <p class="texto" style="text-align: justify">Para poder editar ya un registro existente se debe dar click en icono del lapiz, luego se habilitaran los campos de la fila seleccionada para poder realizar su edicion.</p>
    <div class="frase">
      <div >
           <img class="foto3" src="../../../Imagenes/Imagenes/MantenimientoPep2.PNG">
      </div>
    </div>
</section>
        
</main>
    
</form>
</body>
</html>
