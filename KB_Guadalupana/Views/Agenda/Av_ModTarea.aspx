<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Av_ModTarea.aspx.cs" Inherits="KBGuada.Views.session.Av_ModTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">




<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
     <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>

    <title>Nueva Tarea</title>
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
          <a id="ASIGHOME" runat="server" href="Av_AsignarTarea.aspx" > Asignar Tareas A</a>
          <a href="../Sesion/CerrarSesion.aspx" style="">Cerrar Sesion</a>
          <span class="nav-text" style=" font-size: 25px; right: 3%; position: absolute; margin-top:5px; color: white; height: 20px;"><b runat="server" id="NombreUsuario"></b></span>
         
      </div>



        <br />
        <br />

        <div class="container justify-content-center aling-items-center minh-100" style="max-width: 500px;">



          

            <div class="form-group" style="text-align: center">
                <label>
               <h1 style="border-top: double; border-bottom: double;font-size: 37px; font-family: Montserrat;  padding-bottom: 10px; " >Modificar Tarea</h1>

                </label>
                    </div>
                <div class="form-group" style="text-align: center">
                <label for="exampleInputEmail1">
                    <h1>Titulo de la tarea</h1>
                </label>
                <input id="AVTITULO" type="text" runat="server" class="form-control form-control-lg"  aria-describedby="emailHelp" placeholder="Ingrese el Titulo de la Tarea" style="text-align: center;"/>
            </div>
            <div class="form-group">
                     
                       <h1>Primer Nombre y Primer Apellido</h1>


                <div class="row">
                    <div class="col">
                        <input id="AVPNOMBRE" type="text" runat="server" class="form-control form-control-lg" placeholder="Primer Nombre"/>
                    </div>
                    <div class="col">
                        <input id="AVPAPELLIDO" type="text" runat="server" class="form-control form-control-lg" placeholder="Primer Apellido"/>
                    </div>

                 
                </div>

            </div>
            <div class="form-group">
                <h1>Telefono</h1>
                <div class="row">
                    <div class="col">
                         <h5>Telefono</h5>
                        <input id="AVTEL" runat="server" class="form-control form-control-lg"  maxlength="8" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" type="number"  />
                          <h5>Monto</h5>
                        <span class="input-group-text" id="basic-addon1">GTQ</span>
                        <input id="Monto" runat="server" class="form-control form-control-lg"  maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" type="number"  />
                    </div>
                    <div class="col">

                        <asp:DropDownList  id="DropDownTipoTarea" runat="server"   class="form-control" AutoPostBack="false"  ></asp:DropDownList>
                         <asp:DropDownList  id="DropDownPrioridad" runat="server"   class="form-control" AutoPostBack="false"  ></asp:DropDownList>
                            <asp:DropDownList  id="DropDownEstado" runat="server"   class="form-control" AutoPostBack="false"  ></asp:DropDownList>
                     <asp:DropDownList  id="DropDownAcceso" runat="server"   class="form-control" AutoPostBack="false"  ></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group" style="text-align: center">
                <label for="exampleInputPassword1">
                    <h1>Fecha de inicio</h1>
                </label>

                <input id="AVFECHAINI" runat="server" type="datetime-local"   class="form-control"  value="2014-01-02T11:42" style="text-align: center;" />
            </div>

            <div class="form-group" style="text-align: center">
                <label for="exampleInputPassword1">
                    <h1>Fecha Final</h1>
                </label>

                <input id="AVFECHAFIN" runat="server" type="datetime-local" class="form-control"   style=" text-align: center;"/>
            </div>

            <div class="form-group" style="text-align: center">
                <label for="exampleFormControlTextarea1">
                    <h1>Descripcion de tarea</h1>
                </label>
                <textarea id="AVDESCRIP" runat="server" class="form-control form-control-lg"  rows="3" maxlength="130"></textarea>
            </div>
            <center>
            <div class="container">

              
                <asp:LinkButton ID="btnmodi" runat="server" CssClass="custom-btn btn-8 " OnClick="modificar_Click" Text="Modificar Tarea" ClientIDMode="Static"></asp:LinkButton>
            


            </div>
          </center>




        </div>

        

    </form>


     <%-- scrits --%>
    <script type="text/javascript"> 
        $(document).ready(function () {
            $("div").fadeIn(2000);

        });
    </script>

   
</body>
</html>
