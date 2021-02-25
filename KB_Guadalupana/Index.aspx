<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login_Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<link href='https://fonts.googleapis.com/css?family=Pacifico' rel='stylesheet' type='text/css' />
<link href='https://fonts.googleapis.com/css?family=Arimo' rel='stylesheet' type='text/css' />
<link href='https://fonts.googleapis.com/css?family=Hind:300' rel='stylesheet' type='text/css' />
<link href='https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css' />
<link rel="stylesheet" href="Diseño/stylelogin.css" />
<style> 
  
body, html 
{
  height: 100%;
  margin: 0;
}

.bg
{
  background-image: url("Imagenes/Fondo.png");
  height: 100%; 
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}
.sobre 
    {
    position: absolute;
    top: 6%;
    left: 25%;
    margin-top: -75px;
    margin-left: -75px;
    max-width: 60%;
}
</style>
</head>
<body  class="bg">
    <img class="sobre" src="Imagenes/barra.png"  />
    <form id="form1" runat="server">
     <div id="login-button">
        <img src="https://dqcgrsy5v35b9.cloudfront.net/cruiseplanner/assets/img/icons/login-w-icon.png" />
     </div>
    
<div id="container">
    <h1>Ingreso</h1>
    <span class="close-btn">
        <img src="https://cdn4.iconfinder.com/data/icons/miu/22/circle_close_delete_-128.png" />
    </span>
      
               <input   id="IdUser" runat="server"  placeholder="Usuario"/>
               <input   type="password" id="PSUser" runat="server" placeholder="Contraseña" onchange="iniciar_sesion2()" />
                <a runat="server"  onclick="iniciar_sesion()" style="cursor:pointer;">Iniciar Sesion</a>
</div>

<script src='https://cdnjs.cloudflare.com/ajax/libs/gsap/1.16.1/TweenMax.min.js'></script>
<script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script  src="Diseño/scriptlogin.js"></script>
        <asp:LinkButton ID="iniciarsesion" runat="server" OnClick="iniciarsesion_Click" ClientIDMode="Static" style="background: border-box;"></asp:LinkButton>
     <br />
        </form>
    <script type="text/javascript">
        function iniciar_sesion2() {
            iniciar_sesion();
        }
        function iniciar_sesion() {
            document.getElementById('iniciarsesion').click();
        }
      
    </script>
</body>
</html>
