<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipalProcesos.aspx.cs" Inherits="KB_Guadalupana.Views.ProcesosJudiciales.MenuPrincipalProcesos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Menu Principal</title>
    <style>
        .imagen{
           width:900px;
        }

        body{
            font-family:"Montserrat";
            background-color:#34495E;
            color:white;
        }

        .formato{
            display:flex;
            align-content:center;
            align-items:center;
            justify-content:center;
            width:100%;
            height:600px;
            flex-direction:column;
        }

         html{
            width:100%;
            height:100%;
        }

           .general{
            display:flex;
            justify-content:center;
            align-content:center;
            align-items:flex-start;
            width:100%;
            height:100%;
            margin-top:25px;
        }

         .titulos{
             font-size:22px;
         }
    </style>
</head>
    <div id="menu" runat="server" class="menu"></div>
<body>
    <form id="form1" runat="server">
        
        <div class="formato">
              <label class="titulos"><b>BIENVENIDO A</b></label>
            <br />
            <img class="imagen" src="../../Imagenes/Imagenes_procesos/PJ-GUADALUPANA-BLANCO.PNG"/>
        </div>

         <script>
           $(document).ready(function () {
               $('.menu').load('MenuPrincipal.aspx');
           });
         </script>
    </form>
</body>
</html>
