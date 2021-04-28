<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_VistaMensajeria.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_VistaMensajeria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.css'><link rel="stylesheet" href="../../EXDiseños/EstilosMensajeria.css">

</head>
<body>
    <form id="form1" runat="server">
        
        
        
        
        <div class="center">
<div id="form-main">
  <div id="form-div">
    <form class="form" id="form1">
      
      <p class="name">
          <span id="span1" runat="server" style="font-size:15px; color:white; " >Número de Lote: </span>  <asp:TextBox ID="name" name="name"  onkeypress="return numeros(event);"  runat="server"  Width="20%" > </asp:TextBox>

      
      </p>
    

     
    
      
      <div class="submit">
        
          <asp:LinkButton Text="Validar Lote" ID="buttoblue" runat="server" OnClick="envio_Click"   > </asp:LinkButton>
        <div class="ease"></div>
      </div>
    </form>
  </div>
</div>
            </div>
    </form>

    <script type="text/javascript" src="../../EXDiseños/scriptvalidar.js" >  </script>
</body>
</html>
