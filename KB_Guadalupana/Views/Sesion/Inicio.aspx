<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Login_Web.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <title></title>
       <style>  
   
</style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="menu"></div>
         <img src="../../Imagenes/f_logo.png" alt="Nature" class="responsive"  style="width: 255px; position: absolute; top: 40%;left: 46%; margin-top: -75px; margin-left: -75px;" />
    </form>
</body>
   <script>
       $(document).ready(function () {
           $('.menu').load('MenuBarra.aspx');
       });
   </script>
</html>

