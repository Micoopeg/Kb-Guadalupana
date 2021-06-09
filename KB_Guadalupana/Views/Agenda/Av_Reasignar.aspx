<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Av_Reasignar.aspx.cs" Inherits="KBGuada.Views.session.Av_Reasignar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reasignacion de Tareas</title>


     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
     <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
   <link rel="stylesheet" href="../../DiseñoCss/estilosav.css" />
    <link rel="stylesheet" href="../../AvDiseños/Botones.css"  />
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
</head>


       
    <style>
   body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}

.topnav {
  overflow: hidden;
  background-color: #003563;
}

.topnav a {
  float: left;
  display: block;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

.topnav a:hover {
  background-color: #ddd;
  color: black;
}

.topnav a.active {
  background-color: #69a43c;
  color: white;
}

.topnav .icon {
  display: none;
}

@media screen and (max-width: 600px) {
  .topnav a:not(:first-child) {display: none;}
  .topnav a.icon {
    float: right;
    display: block;
  }
}

@media screen and (max-width: 600px) {
  .topnav.responsive {position: relative;}
  .topnav.responsive .icon {
    position: absolute;
    right: 0;
    top: 0;
  }
  .topnav.responsive a {
    float: none;
    display: block;
    text-align: left;
  }
}
        .carta-box {
            margin: 25px;
            width: 200px;
            height: 200px;
            position: relative;
            perspective: 1000px;
        }

            .carta-box:hover .carta {
                transform: rotateY(180deg);
            }

        .carta {
            transform-style: preserve-3d;
            transition: all 0.5s linear;
        }

        .cara {
            position: absolute;
            backface-visibility: hidden;
        }

            .cara.detras {
                transform: rotateY(180deg);
            }

        .fade {
            opacity: 0.2;
            -webkit-transition: opacity 0.3s;
            transition: opacity 0.3s;
        }

            .fade:hover {
                opacity: 1;
            }

        div {
            display: none;
        }

        .minh-100 {
            height: 100vh;
        }

        .margenes {
            margin: 100px;
        }
    </style>


<body>
    <form id="form1" runat="server">

        
     <div class="topnav">
          <a class="active" href="../Sesion/MenuBarra.aspx">Inicio</a>
          <a href="AgendaPrin.aspx"> Agenda</a>
           <a href="DashBoard.aspx" > Busqueda</a>
            <a href="NuevaTarea.aspx" > Nueva Tarea</a>
         <a id="ASIGHOME" runat="server" href="Av_AsignarTarea.aspx" > Asignar Tarea A</a>
          <a href="../Sesion/CerrarSesion.aspx" style="">Cerrar Sesion</a>
          <span class="nav-text" style=" font-size: 25px; right: 3%; position: absolute; margin-top:5px; color: white; height: 20px;"><b runat="server" id="NombreUsuario"></b></span>
         
      </div>

        <br />
        <br />
            <div class="container justify-content-center aling-items-center minh-100" style="max-width: 500px;">

              <div class="form-group" style="text-align: center">
                  <label>
               <h1 style="border-top: double; border-bottom: double;font-size: 37px; font-family: Montserrat;  padding-bottom: 10px; " >Reasignar Tarea</h1>

                </label>
                  </div>


            <div class="form-group" style="text-align: center">
           
                <label for="exampleInputEmail1">
                    <h1>Titulo de la tarea</h1>
                </label>


                <input id="AVTITULO" type="text" runat="server" class="form-control form-control-lg"  aria-describedby="emailHelp" readonly style="text-align: center;"/>
            </div>
            <div class="form-group">
                     
                       <h1>Asignar A</h1>


                <div class="row">
                    <div class="col">
                        <span>Usuario</span>
                        <input id="NOMUSER" type="text" runat="server" class="form-control form-control-lg" placeholder="Nombre de Usuario"/>
                    </div>
                    <div class="col">
                        <span>CIF </span>
                        <input id="CIF" type="number" runat="server" class="form-control form-control-lg" maxlength="6" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" placeholder="000000"/>
                    </div>

                 
                </div>

            </div>
          
            <div class="form-group" style="text-align: center">
             <label for="exampleInputPassword1">
                    <h1>Asignados Actuales </h1>
                </label> 

                <ul class="list-group">
                       <asp:Repeater ID="repetidoruser" runat="server" >
                    <ItemTemplate>
  <li class="list-group-item "> <b>Usuario </b> <%# Eval("av_controlusuario") %>    <b>CIF:</b> <%# Eval("avcifgeneral") %>  </li>

                          
                    </ItemTemplate>


                </asp:Repeater>
               </ul>
            </div>

         
                <br />
    
            <center>
            <div class="container">

              <asp:LinkButton ID="btnreasignar"  runat="server" Cssclass="custom-btn btn-8" OnClick="btnreasignar_Click" Text="Reasignar Tarea" />
                
            


            </div>
          </center>




        </div>

        





    </form>

    <script type="text/javascript"> 
        $(document).ready(function () {
            $("div").fadeIn(2000);

        });
    </script>
</body>
</html>
