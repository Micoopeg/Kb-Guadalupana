<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_LeerBC.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_GenerarBC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="../../EXDiseños/estilolector.css" />
    <title>Generar Expediente</title>
</head>
<body>
    <form id="form1" runat="server">
          <div id="barcode">
        <video id="barcodevideo" autoplay ></video>
        <canvas id="barcodecanvasg"> </canvas>
        </div>
       <canvas id="barcodecanvas"></canvas>
        <div id="result"></div>
    </form>


        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/1.8.3/jquery.min.js'></script> <script type="text/javascript" src="../../EXDiseños/barcode.js"></script>
        <script type="text/javascript">
            var sound = new Audio('../../EXDiseños/barcode.wav');

            $(document).ready(function () {
                barcode.config.start = 0.1;
                barcode.config.end = 0.9;
                barcode.config.video = '#barcodevideo';
                barcode.config.canvas = '#barcodecanvas';
                barcode.config.canvasg = '#barcodecanvasg';
                barcode.setHandler(function (barcode) {
                    $('#result').html(barcode);
                })
                barcode.init();
                $('#result').bind('DOMSubtreeModified', function (e) {
                    sound.play();

                });
            });

        </script>
</body>
</html>
