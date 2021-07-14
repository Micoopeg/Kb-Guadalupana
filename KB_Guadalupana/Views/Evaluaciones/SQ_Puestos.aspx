<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQ_Puestos.aspx.cs" Inherits="KB_Guadalupana.Views.Evaluaciones.SQ_Puestos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">


    <link rel="stylesheet" href="../../AvDiseños/Botones.css"   />
   <title>Mantenimiento puestos</title>
</head>
<body>

    <form id="form1" runat="server" >
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
               <ContentTemplate>
       <div class="container justify-content-center aling-items-center minh-100" style="max-width: 850px;">
          
             <div class="form-group">
            
                <div class="row">
                    <div class="col-sm-4">
                         <h5>Puesto</h5>
                         <input id="puesto" type="text" runat="server" onkeypress="return soloLetras(event);" class="form-control form-control-lg" placeholder="Descripción del Puesto"/>
                        <h5>Cantidad</h5>
                 <input id="cantidad" type="text" runat="server" class="form-control form-control-lg" onkeypress="return numeros(event);" placeholder="Cantidad"/>
                        </div>
                 
                        <div class="col-sm-2" style="margin-top:11%">
                        
          
            <div class="container">
            <%--    
             <asp:LinkButton ID="btnpuestos" runat="server" CssClass="custom-btn btn-8" ClientIDMode="AutoID" Text="ingresar" OnClick="btnpuestos_Click" style="text-align:center; text-decoration:none;" > </asp:LinkButton>--%>

            <%--    <button id="datos" runat="server" class="custom-btn btn-8" onclick="insertados()" >Insertar </button>--%>
                <%-- <asp:Button ID="btninserta" runat="server" OnClick="btnpuestos_Click" Text="Insertar" CssClass="custom-btn btn-8"  PostBackUrl="~/Views/Evaluaciones/Principal.aspx"/>--%>
                <asp:LinkButton ID="btninserta" runat="server" OnClick="btnpuestos_Click" Text="Insertar" CssClass="custom-btn btn-8"  ></asp:LinkButton>
            </div>
   
                        
                    </div>
                </div>
            </div>
             </div>
                   </ContentTemplate>
               <Triggers>

                   <asp:AsyncPostBackTrigger ControlID="btninserta" EventName="Click" />
               </Triggers>
      </asp:UpdatePanel>
    </form>



   
    <script>

        function numeros(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) //if not a number
                { return false } //disable key press    
            }
        }

        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
            especiales = "8-37-39-46";

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }

    </script>
</body>
</html>
