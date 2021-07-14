<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQ_EvaluacionAsignacion.aspx.cs" Inherits="KB_Guadalupana.Views.Evaluaciones.SQ_EvaluacionAsignacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="container justify-content-center aling-items-center minh-100" style="max-width: 850px;">

         


            <div class="form-group" style="text-align: center">
           
                <label for="exampleInputEmail1">
                    <h1>Título de la pregunta</h1>
                </label>
                  <textarea id="Textarea1" runat="server" class="form-control form-control-lg" placeholder="Pregunta" rows="4" maxlength="250" required></textarea>
            </div>
               <div class="form-group" style="text-align: center">
                <label for="exampleFormControlTextarea1">
                    <h1>Información Extra</h1>
                </label>
                <textarea id="DESCRIP" runat="server" class="form-control form-control-lg" placeholder="Información extra de la pregunta (Opcional)"  rows="4" maxlength="250"></textarea>
            </div>
  
            <div class="form-group">
            
                <div class="row">
                    <div class="col-sm-4">
                         <h5>TIpo de pregunta</h5>
                         <asp:DropDownList  id="droptipo" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                        <h5>Orden de la pregunta</h5>
                         <asp:DropDownList  id="droporden" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                    </div>
                    <div class="col-sm-4">
                        
                         <h5>Evaluación</h5>
                         <asp:DropDownList  id="dropeval" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                        <h5>Estado</h5>
                         <asp:DropDownList  id="dropestado" runat="server"   CssClass="form-control" AutoPostBack="true"    ></asp:DropDownList>
                    
                       
                     
                        </div>
                        <div class="col-sm-2" style="margin-top:11%">
                        
          
            <div class="container">
                
              <asp:Button ID="btninsert" runat="server" Cssclass="custom-btn btn-8"  Text="Crear" />
                
            


            </div>
   
                        
                    </div>
                </div>
            </div>
      
           

          




        </div>
    </form>
</body>
</html>
