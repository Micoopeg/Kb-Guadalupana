<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="barra.aspx.cs" Inherits="KB_Guadalupana.Views.test.administracion.barra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../../estatico/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../estatico/css/bootstrap.min.js"></script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   
    <div class="completo">


    <link href="../../../estatico/css/barra.css" rel="stylesheet" />
    <nav class="navbar navbar-expand-lg navbar-light bg-light">

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="../Home/Index">Home <span class="sr-only">(current)</span></a>
                    
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="usuarios" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Colaborador
                    </a>
                    <div class="dropdown-menu" aria-labelledby="colaborador">
                        <a class="dropdown-item" href="../usuario/registrocolaborador">Crear</a>
                        
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../usuario/vistageneral">Vista general</a>
                    </div>
                </li>

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="test" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Test
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="../test/creaciontest">Crear</a>
                        
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../test/vistageneral">Vista General</a>
                    </div>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="test" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Administración
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="../administracion/crearpregunta">Preguntas</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../administracion/creararea">Areas</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../administracion/agregarsucursal">Unidad Operativa</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../administracion/agregarroles">Roles</a>
                    </div>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="config" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Configuración
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="../usuario/agregarusuario">Agregar usuario</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../usuario/vistausuarios">Vista Usuarios</a>
                    </div>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="repo" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Evaluaciones
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">

                        <a class="dropdown-item" href="../evaluaciones/crear">Crear Evaluación</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../evaluaciones/vistageneralevaluaciones">Vista Evaluaciones</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../evaluaciones/evaluacionesgenerales">Evaluaciones Generales</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../evaluaciones/evaluacionesgeneralvista">Evaluaciones Generales Vista</a>
                    </div>
                </li>

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="repo" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Reportes
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="../reporte/porarea">Reporte por área</a>
                        <div class="dropdown-divider"></div>
                        
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../reporte/porfec">Reporte por Fechas</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="../reporte/porareageneral">Reporte área resumen</a>
                        <div class="dropdown-divider"></div>

                    </div>
                </li>
            </ul>
            <form class="form-inline my-2 my-lg-0">
                <a  href="../Home/Index"  class="btn btn-link" ><img src="../../../estatico/imagenes/salir.png" class="logo" style="max-width:30px; " /></a>
            </form>
        </div>
    </nav>



</div>

</body>
</html>
