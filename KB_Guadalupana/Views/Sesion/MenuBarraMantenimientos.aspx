<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuBarraMantenimientos.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.MenuBarraMantenimientos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <title></title>
       <style>  
        .responsive 
        {
            max-width: 100%;
            height: auto;
        }
        .sobre 
        {
        position: absolute;
        top: 6%;
        left: 25%;
        margin-top: -40px;
        margin-left: -35px;
        max-width: 60%;
        /*width: 100px;
        height: 50px;*/
        }
        .btn-group {
           display: flex;
            flex-direction: row;
            justify-content: center;
            align-content: center;
            align-items:center;
            padding: 30px;
            /*position: absolute; */
            left: 30%;
            /*margin-left: 400px;*/
            margin-bottom: 125px;
            margin-top: 125px;
            margin-right: 150px;
            height: 400px;
            width: 600px;
            position: absolute;
        }

        .btn-group button {
          background-color: #0066BF; /* Green background */
          border: 0px; /* Green border */
          color: white; /* White text */
          padding: 10px 24px; /* Some padding */
          cursor: pointer; /* Pointer/hand icon */
          float: left; /* Float the buttons side by side */
          padding: 23px;
          margin: 8px;
          width: 250px;
          height: 150px;
          font-family: 'Montserrat';
          font-size: 18px;
        }

        .btn-group button:not(:last-child) {
          border-right: none; /* Prevent double borders */
        }

        /* Clear floats (clearfix hack) */
        .btn-group:after {
          content: "";
          clear: both;
          display: table;
        }

        /* Add a background color on hover */
        .btn-group button:hover {
          background-color: #69A43C;
        }

         .cumplimiento:hover {
          background-color: #69A43C;
          color: white;
        }

        /*Menu mantenimientos*/


</style>
</head>
<body>
    <img class="sobre" src="../../Imagenes/EP-Guadalupana.png"/>
    <form id="form1" runat="server">
       <div class="menu"></div>
         <div class="btn-group">
          <%--<button>Verificación y Reportes Estado Patrimonial</button>
          <button>Imprimir Estado Patrimonial</button>--%>
          <button>
              <a class="cumplimiento" href="MantenimientoLotes.aspx">Mantenimiento Lotes</a>
          </button>
             <%--<a href="MantenimientoVehiculos.aspx">--%>
              <%--<button id="MantenimientoVehiculos" onclick= "MantenimientoVehiculos()">Area Administrativa Cumplimiento</button>--%>
            <%-- </a>--%>
              <button>
                  <a class="cumplimiento" href="MantenimientoVehiculos.aspx" id="MantenimientoVehiculos" onclick= "MantenimientoVehiculos()">Area Administrativa Cumplimiento</a>
              </button>
           </div>
       <%--  <asp:LinkButton ID="mantenimiento_Vehiculos" runat="server" OnClick="MantenimientoVehiculos_Click" ClientIDMode="Static"></asp:LinkButton>--%>

    </form>
</body>
   <script>
       $(document).ready(function () {
           $('.menu').load('MenuBarra.aspx');
       });

       function MantenimientoVehiculos() {
           document.getElementById('mantenimiento_Vehiculos').click();
       }


   </script>
</html>
