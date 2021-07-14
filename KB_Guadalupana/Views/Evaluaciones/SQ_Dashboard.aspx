<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQ_Dashboard.aspx.cs" Inherits="KB_Guadalupana.Views.Evaluaciones.SQ_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet"  href="../../SQEstilos/EstilosDash.css" />
    <title>Dashboard</title>

</head>
  
       
<body>
   
    <form id="form1" runat="server">

       <section class="overview">
        <div class="wrapper">

			<h2 id="Date" runat="server" >sin fecha error</h2>
            <h2>Evaluación vigente junio</h2>
			
			<br />
            <div class="grid">
            <div class="card-small">
                <p class="card-small-views">Pendientes de respuesta</p>
                <p class="card-small-icon">
                     <span class="fa fa-question-circle "></span>
                </p>
                <p id="pendientes" runat="server" class="card-small-number">20</p>
                
            </div>
            <div class="card-small">
                <p class="card-small-views">Pasados de la fecha</p>
                <p class="card-small-icon">
                    <span class="fa fa-calendar-times-o"></span>
                </p>
                <p id="pasadosfecha" runat="server" class="card-small-number">4</p>
               
            </div>
            <div class="card-small">
                <p class="card-small-views">En Proceso</p>
                <p class="card-small-icon">
                     <span class="fa fa-clock-o"></span>
                </p>
                <p id="iniciados" runat="server" class="card-small-number">10</p>
               
            </div>
            <div class="card-small">
                <p class="card-small-views">Terminados</p>
                <p class="card-small-icon">
                     <span class="fa fa-check-square"></span>
                </p>
                <p id="terminados" runat="server" class="card-small-number">50</p>
              
            </div>
      
            
        </div>
            </div>
    </section>
        
        
    </form>
   
</body>
    
</html>
