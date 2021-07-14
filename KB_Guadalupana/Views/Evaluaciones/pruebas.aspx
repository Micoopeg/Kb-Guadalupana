<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pruebas.aspx.cs" Inherits="KB_Guadalupana.Views.Evaluaciones.pruebas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
           <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link href="../../SQEstilos/Estilosmalla.css" rel="stylesheet" />
    <title></title>
</head>
   
<body>
    <form id="form1" runat="server">

<!-- partial:index.partial.html -->
<div class="paddingBlock">
  <h1>EQUAL HEIGHT COLUMNS</h1>
  <p>Simply add display:flex to the parent</p>
  <div class="equalHWrap eqWrap">
    <div class="equalH eq">boo <br> boo</div>
    <div class="equalH eq">shoo</div>
    <div class="equalH eq">clue</div>
  </div>
</div>            

<div class="paddingBlock">
  <h1>EQUAL HEIGHT + WIDTH COLUMNS</h1>
  <p>Add display:flex to the parent and flex:1 to the boxes</p>
  <div class="equalHWrap eqWrap">
    <div class="equalHW eq">boo <br> boo</div>
    <div class="equalHW eq">shoo</div>
    <div class="equalHW eq">clue</div>
  </div>
</div>            






<!-- partial -->
  


    </form>
</body>
</html>
