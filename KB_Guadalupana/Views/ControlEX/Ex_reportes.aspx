<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_reportes.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" ">
   <title>Imprimir Evaluación</title>
    <style>
           @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
        body{
      

     
            display:flex;
            align-content:center;
            align-items:center;
            justify-content:center;
            width:100%;
            height:100%;
            font-family:'Montserrat';
        }

        html{
             width:100%;
            height:100%;
        }

        .boton{
            background-color:#69A43C;
            border:0px;
            height:35px;
            width:250px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            color:white;
            font-family:'Montserrat';
        }

        .boton:hover{
             background-color:#4D782C;
            border:0px;
        }

        .titulo{
            color:#003563;
            font-family:'Montserrat';
            font-size:25px;
        }

        .general{
            display:flex;
            flex-direction:column;
            justify-content:center;
            align-content:center;
            align-items:center;
        }

        .formato{
            display:flex;
            align-content:center;
            justify-content:center;
            align-items:center;
            width:100%;
            margin:0px;
        }

        .reporte{
            display:flex;
            align-content:center;
            justify-content:center;
            align-items:center;
            margin:0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="general" style="margin-top:40px;">

   
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           

            <label class="titulo"><b>Reportes Sistema de expedientes</b></label>
            <br />
           </div>
           <div class="container">
  <div class="row">
    <div class="col">
        <label class="titulo"><b>Fecha Inicial</b></label>
            <asp:Calendar ID="fechain" runat="server" SelectionMode="Day" ShowNextPrevMonth="True" NextPrevFormat="FullMonth" SelectedDate="1/1/0001 00:00:00"></asp:Calendar>
              

    </div>

    <div class="col">
         <label class="titulo"><b>Fecha Final</b></label>
         <asp:Calendar ID="fechafi" runat="server" SelectionMode="Day" ShowNextPrevMonth="True" NextPrevFormat="FullMonth" SelectedDate="1/1/0001 00:00:00"></asp:Calendar>
            
    </div>
    <div class="col">
   
         
           <br /> <br /> <br />
           <div class="row">

                 <div class="form-group"> 

            <span id="span4" runat="server" style="font-size:15px">Estatus </span> <asp:DropDownList ID="estatus" runat="server" CssClass="dis" AutoPostBack="true" Width="160px" ></asp:DropDownList>
                     <br />
          <span id="span1" runat="server" visible="false" style="font-size:15px">Agencia </span> <asp:DropDownList ID="agenciass" runat="server" CssClass="dis" Visible="false" AutoPostBack="true" Width="160px" ></asp:DropDownList>
                     <br />
          <span id="span2" runat="server" visible="false" style="font-size:15px">Garantía </span> <asp:DropDownList ID="garantias" runat="server" CssClass="dis" Visible="false" AutoPostBack="true" Width="160px" ></asp:DropDownList>
                                <br />
         <span id="span3" runat="server" visible="false" style="font-size:15px">Etapa </span> <asp:DropDownList ID="estados" runat="server" Visible="false" CssClass="dis" AutoPostBack="true" Width="160px" ></asp:DropDownList>
                        
           </div>
            
              <asp:Button runat="server" ID="Imprimir" Text="Generar Reporte" CssClass="boton"  OnClick="Imprimir_Click" />
                 <asp:Button runat="server" ID="imprimirtodos" Text="Generar Conjunto" CssClass="boton"  OnClick="imprimirtodos_Click" />
                <asp:Button runat="server" ID="imprimirporcriterios" Text="Generar criterios" CssClass="boton"  OnClick="imprimirporcriterios_Click" />
               <asp:Button runat="server" ID="agenciasrepo" Text="Generar Agencias" CssClass="boton"  OnClick="agenciasrepo_Click" />
        </div>
   
            </div>
      
         

  </div>




               <br />

       

             <div class="formato" style="width:95%">
           
                <rsweb:reportviewer id="ReportViewer1" runat="server" CssClass="reporte" style="min-width: 80%; max-width: 80%; width: 80%; display:flex; justify-content:center;justify-items:center;align-content:center" showbackbutton="False" showrefreshbutton="False" showzoomcontrol="False" ShowPrintButton="True" ShowExportControls="True"></rsweb:reportviewer>
             </div>
        </div>
    </form>
</body>
</html>
