<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="KB_Guadalupana.Views.PaginaDeError.Error404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <title>ERROR 404</title>
<style type="text/css">
    
body {
  font-family: 'Arvo', serif;
  background: #ABCDEF;
  display: flex;
  align-items: center;
  justify-content: center;
  min-height: 90vh;
  transition: 1s;
}
.error {
  color: #20293F;
  box-shadow: 0 5px 0px -2px #20293F;
  text-align: center;
  animation: fadein 1.2s ease-in;
}
.error > .code {
  font-size: 10.5em;
  text-shadow:  0 6px 1px rgba(0,0,0,0.0980392) , 0 0 5px rgba(0,0,0,0.0980392) , 0 1px 3px rgba(0,0,0,0.298039) , 0 3px 5px rgba(0,0,0,0.2) , 0 5px 10px rgba(0,0,0,0.247059) , 0 10px 10px rgba(0,0,0,0.2) , 0 20px 20px rgba(0,0,0,0.14902) ;
  margin: 0;
}
.error > .desc {
  text-shadow: 0px 3px 5px rgba(0,0,0,0.5), 0px 6px 20px rgba(0,0,0,0.3);
  font-weight: 400;
}
@keyframes fadein {
  0% {
    margin-top: -50px;
    opacity: 0;
  }
  50% {
    opacity: 0.5;
  }
  100% {
    opacity: 1;
  }
}
footer {
  position: absolute;
  bottom: 0px;
}
</style>
</head>
<body>
    <div class='error'>
  <h1 class='code'>404</h1>
  <h2 class='desc'>Actualmente el sistema se encuentra en mantenimiento.</h2>
</div>
<footer>
  <p>OFICINAS CENTRALES · 14 Avenida 1-65 Zona 14, Ciudad de Guatemala, GT 01014
     ©2019. Cooperativa Guadalupana. Reservados Todos los Derechos.</p>
</footer>
</body>
</html>
