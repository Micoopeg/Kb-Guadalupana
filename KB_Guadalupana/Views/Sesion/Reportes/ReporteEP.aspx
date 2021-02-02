<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteEP.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.Reportes.ReporteEP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <link rel="stylesheet" href="../../../DiseñoForms/style.css" />
    <link rel="stylesheet" href="../../../Diseño/styleboton.css" />
    <link rel="stylesheet" href="../../../Diseño/StyleDatos.css" />
    <link rel="stylesheet" href="../../../Diseño/scriptDatos.js" />
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../../../DiseñoCss/StyleCss.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel="stylesheet" type="text/css" href="../../../Diseño/Print.css" media="print" />

    
<script>
    function obtenerimagen() {
        takeScreenshot(function (screenshot) {
            printPage(screenshot);
        });
    }
</script>
    
<script>
    function printPage(screenshot) {
        var win = window.open('EstadoPatrimonial', 'EstadoPatrimonial');
        win.document.write('<html>');
        win.document.write('<head></head>');
        win.document.write('<body>');
        win.document.write('<img src="' + screenshot + '"/>');
        win.document.write('</body>');
        win.document.write('</html>');

    }
</script>
<script>
    function printPage1(screenshot) {
        var win = window.open('EstadoPatrimonial', 'EstadoPatrimonial');
        win.document.write('<html>');
        win.document.write('<head></head>');
        win.document.write('<body>');
        win.document.write('<img src="' + screenshot + '"/>');
        win.document.write('</body>');
        win.document.write('</html>');
        win.print();
        win.close();
    }
</script>
<script>        
    function takeScreenshot(cb) {
        html2canvas(document.getElementById('area'),
            {
                onrendered: function (canvas) {
                    var image = canvas.toDataURL();
                    cb(image);

                }
            });
    }
</script>
    
</head>
    <style>
body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}

.topnav {
  overflow: hidden;
  background-color: #333;
}

.topnav a {
  float: left;
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
  background-color: #4CAF50;
  color: white;
}
.topnav {
  overflow: hidden;
  background-color: #003563;
}

.topnav a {
  float: left;
  color: #f2f2f2;
  text-align: center;
  padding: 15px 35px;
  text-decoration: none;
  font-size: 17px;
}

.topnav a:hover {
  background-color: #B80416;;
  color: White;
}

.topnav a.active {
  background-color: #69a43c;
  color: white;
}

 @media print 
 {
    @page 
        { 
            margin: 0;
            size: auto; 
        }
}
</style>


<body>
  <form id="form1" runat="server">
    <div class="topnav">
            <a class="active" href="../Inicio.aspx">Inicio</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b runat="server" id="NombreUsuario"></b></span>
            <a href="../CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
    </div>
    <br/>
 <div style="display: flex;justify-content: center;align-items: center;">
    <div class="col-md-3" style="display: flex;justify-content: center;align-items: center;" onclick="obtenerimagen();">
				<a href="#" style="cursor:pointer;" class="fancy-button medium half-left-rounded orange rotate shadow">
					Visualizar  &nbsp;
					<span class="icon">
						<i class="fa fa-rotate-right"></i>
					</span>
				</a>
			</div>
    <div class="col-md-3" style="display: flex;justify-content: center;align-items: center;">
				<a onclick="printPage1();" style="cursor:pointer;" class="fancy-button medium wisteria bounce bell infinite ">
					Guardar / Imprimir  &nbsp;
					<span class="icon" >
						<i class="fa fa-bell"></i>
					</span>
				</a>
			</div>
    </div>

    <div i class="menu"></div>
    <div id="area" class="container">
    <br/>
    <br/>
        <div class="contenedor">
            <div class="encabezado">
               <img src="../../../Imagenes/Logotipo.png" alt="Guadalupana" style="width: 724px;height: 100px;margin-left: -24px;margin-top: -14px;">
            </div>
           <div class="encabezado1">
                <h2>ESTADO PATRIMONIAL DIRIGENTES Y EMPLEADOS</h2>
            </div> 
            <div class="encabezado2">
                <h2 style="font-size: 20px;color: white;">En cumplimiento al  articulo 19,  de la Ley contra el Lavado de Dinero u Otros Activos y 10 de su Reglamento declaro:</h2>
            </div>
            <div class="formulario" style="margin-left: 75px;margin-top: 15px;">
                    <div class="campo" style="margin-left: 120px;">
                        <center><label  class="col-sm-2" for="rut">CIF:</label></center> 
                        <input style="border: 0" class="col-sm-2" value="Prueba" type="text" runat="server" id="CIF" disabled/>
                        <center><label class="col-sm-2" for="nombre">Nombre:</label></center> 
                        <input  style="border: 0"  class="col-sm-4" type="text"  runat="server" id="NombreC" disabled/>
                    </div>
                <div class="campo" style="margin-left: 120px;">
                    <br/>
                        <center><label class="col-sm-2" for="apellido">Nit:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="Nit1IG" disabled/>
                    </div>
               <br/>
            <div class="encabezado2">
                <h2 style="font-size: 25px;color: white;">Informacion General</h2>
            </div>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Agencia:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="AgenciaIG" disabled/>
                        <center><label class="col-sm-2" for="apellido">Area:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="AreaIG" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Puesto:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="PuestoIG" disabled/>
                    </div>
                
                <div class="campo" style="margin-left: -5px;" >
                    <br>
                        <center><label class="col-sm-2" for="apellido">Departamento:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="DepaIG" disabled/>
                        <center><label class="col-sm-2" for="apellido">Municipio:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="MuniIG" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Zona:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="ZonaIG" disabled/>
                    <br>
                    <br>
                        <center><label class="col-sm-2" for="apellido">Direccion:</label></center> 
                        <input style="border: 0" class="col-sm-10" type="text" runat="server" id="DireccIG" disabled/>
                    </div>
                <div class="campo" style="margin-left:80px;" >
                    <br>
                        <center><label class="col-sm-3" for="apellido">Primer Apellido:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="PApellidoIG" disabled/>
                        <center><label class="col-sm-3" for="apellido">Segundo Apellido:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="SApellidoIG" disabled/> 
                    </div>
                <br/>
                <div class="campo" style="margin-left:80px;" >
                    <br/>
                        <center><label class="col-sm-3" for="apellido">Primer Nombre:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="PNombreIG" disabled/>
                        <center><label class="col-sm-3" for="apellido">Segundo Nombre:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="SNombreIG" disabled/>  
                    </div> 
               <br/>
                <div class="campo" style="margin-left:80px;" >
                    <br/>
                        <center><label class="col-sm-3" for="apellido">Tipo Documento:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="TipoIdeIG" disabled/>
                        <center><label class="col-sm-3" for="apellido" style="margin-top: -7px;">No Documento Identificacion:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="NoDocIG" disabled/> 
                    </div> 
                <div class="campo" style="margin-left:80px;" >
                    <br/>
                    <br/>
                        <center><label style="    margin-left: 54px;" class="col-sm-6" for="apellido">Fecha de Nacimiento:</label></center>
                        <input style="border: 0;  margin-left: -44px;" class="col-sm-3" type="text" runat="server" id="FechaIG" disabled/>
                    </div>
                <div class="campo" style="margin-left: -5px;" >
                    <br/>
                    <br/>
                        <center><label class="col-sm-2" for="apellido">Nit:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="Nit2IG" disabled/>
                        <center><label class="col-sm-2" for="apellido">Nacionalidad:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="NacionalidadIG" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Religion:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="ReligionIG" disabled/>
                    </div>  
                <div class="campo" style="margin-left: -5px;" >
                    <br/>
                        <center><label class="col-sm-2" for="apellido">Estatura</label></center>
                        <input style="border: 0" class="col-sm-1" type="text" runat="server" id="EstaturaIG" disabled/>
                        <center><label class="col-sm-2" for="apellido">Peso:</label></center> 
                        <input style="border: 0" class="col-sm-1" type="text" runat="server" id="PesoIG" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Correo:</label></center> 
                        <input style="border: 0" class="col-sm-3" type="text" runat="server" id="CorreoIG" disabled/>
                    </div>
        
              <br />  
              <br />  
                <br />
<!-- Grid Informacion General Telefono-->
 <asp:GridView ID="GridViewcelular" style="margin-left:auto;margin-right:auto" runat="server" HeaderStyle-BackColor="#003563" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" >
                     <Columns>
                         <asp:TemplateField HeaderText="tipo de telefono" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lbltipotelefono" Text='<%# Eval("codeptipotelefono") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo de telefono">
                            <ItemTemplate>
                                <asp:Label ID="lblnombretelefono" Text='<%# Eval("ep_tipotelefononombre") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Numero de telefono">
                            <ItemTemplate>
                                <asp:Label ID="lblnumerotelefono" Text='<%# Eval("ep_telefononumero") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                     </Columns>
                <HeaderStyle BackColor="#003563" ForeColor="White"></HeaderStyle>
        </asp:GridView>
<!--  Fin Grid Informacion General Telefono          -->
                <br />
           <div class="encabezado2">
                <h2 style="font-size: 25px;color: white;">Informacion Familiar</h2>
            </div>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Estado Civil:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="EstadoCIF" disabled/>
                        <center><label class="col-sm-2" for="apellido" style=" margin-top: -10px;">Apellido Casada:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="ApellidoCIF" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Fecha Boda:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="FechaBIF" disabled/>
                   </div>
                <div class="campo" style="margin-left:80px;" >
                    <br>
                       <center><label class="col-sm-3" for="apellido">Nombre Conyuge:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="NombreCF" disabled/>
                        <center><label class="col-sm-3" for="apellido" style="margin-top: -7px;">Ocupacion Conyuge</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="OcupacionCIF" disabled/> 
                   </div>
                   <div class="campo" style="margin-left:80px;" >
                    <br>
                       <center><label class="col-sm-5" for="apellido" style="margin-top: -7px;">Fecha Nacimiento Conyuge</label></center> 
                        <input style="border: 0" class="col-sm-3" type="text" runat="server" id="FechaCIF" disabled/> 
                   </div>
                <br />
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Hijos:</h2>
            </div>
                <br />
    <!-- Grid Informacion Familiar Hijos-->
     <asp:GridView ID="GridViewhijos" CssClass="mGrid" style="margin-left:auto;margin-right:auto"  runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Numero hijo" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerohijo" Text='<%# Eval("codepinfofamiliar") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre">
                           <ItemTemplate>
                            <asp:Label ID="lblnombrehijo" Text='<%# Eval("ep_infofamiliarnombrehijos") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Ocupación">
                           <ItemTemplate>
                            <asp:Label ID="lblocupacionhijo" Text='<%# Eval("ep_infofamiliarocupacionhijos") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Comentarios">
                           <ItemTemplate>
                            <asp:Label ID="lblcomentariohijo" Text='<%# Eval("ep_infofamiliarcomentario") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Fecha de nacimiento">
                           <ItemTemplate>
                            <asp:Label ID="lblfechanachijo" Text='<%# string.Format("{0: yyyy-MM-dd}",Eval("ep_infofamiliarfechanacimientohijo")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
<!-- Fin Grid Informacion Famliar Hijos-->    
                <br/>
                <br/>
        <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">En caso de emergencia llamar a:</h2>
            </div>
                  <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Nombre:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="NombreEC" disabled/>
                        <center><label class="col-sm-2" for="apellido">Telefono:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="NumeroEC" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Parentesco:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="ParentescoEC" disabled/>
                   </div>
                <br>
            <div class="encabezado2">
                <h2 style="font-size: 25px;color: white;">Estudios Universitarios</h2>
            </div>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Carrera:</label></center>
                        <input style="border: 0" class="col-sm-3" type="text" runat="server" id="CarreraEU" disabled/>
                        <center><label class="col-sm-2" for="apellido" style="margin-top: -11px;">Semestre Cursado:</label></center> 
                        <input style="border: 0" class="col-sm-1" type="text" runat="server" id="SemestreEU" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Año Cursado:</label></center> 
                        <input style="border: 0" class="col-sm-1" type="text" runat="server" id="AñoEU" disabled/>
                   </div>
                 <div class="campo" style="margin-left:80px;" >
                    <br/>
                        <center><label class="col-sm-3" for="apellido">Universidad:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="UniverEU" disabled/>
                        <center><label class="col-sm-3" for="apellido">Idioma:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="IdiomaEU" disabled/>  
                    </div> 
                <br>
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Otros Estudios:</h2>
            </div>
 <!-- Grid Informacion Otros Estudios-->
                <br />
      <asp:GridView ID="GridViewEstudios" CssClass="mGrid" style="margin-left:auto;margin-right:auto" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False"  BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Numero Curso" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerocurso" Text='<%# Eval("codepestudio") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre del Curso">
                           <ItemTemplate>
                            <asp:Label ID="lblnombrecurso" Text='<%# Eval("ep_estudionombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Nombre del Establecimiento">
                           <ItemTemplate>
                            <asp:Label ID="lbllugar" Text='<%# Eval("ep_estudiolugar") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Tipo de Modalidad">
                           <ItemTemplate>
                            <asp:Label ID="lblmodalidad" Text='<%# Eval("ep_estudiomodalidad") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Año Cursado">
                           <ItemTemplate>
                            <asp:Label ID="lblaniocursado" Text='<%# Eval("ep_estudioaño") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Duración">
                           <ItemTemplate>
                            <asp:Label ID="lblduracion" Text='<%# Eval("ep_estudioduracion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Idioma">
                           <ItemTemplate>
                            <asp:Label ID="lblidioma" Text='<%# Eval("ep_estudioidioma") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
<!-- Fin Grid Informacion Otros Estudios-->  
                <br/>
            <div class="encabezado2">
                <h2 style="font-size: 25px;color: white;">Activos</h2>
            </div>
                 <div class="campo" style="margin-left:175px;" >
                        <center><label class="col-sm-4" for="apellido">Caja:</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" id="CajaA" disabled/>
                </div>
                <br/>
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Cuentas:</h2>
            </div>
                <br />
 <!-- Grid Activos Cuentas-->
   <asp:GridView ID="GridViewcuentasvarias" CssClass="mGrid" style="margin-left:auto;margin-right:auto" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Número cuenta" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerocuentasvarias" Text='<%# Eval("codepcuentas") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Número  tipocuenta" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lbltipocuentasvarias" Text='<%# Eval("codeptipocuenta") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>   
                         <asp:TemplateField HeaderText="Numero  institucion" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lbltipoinstitucionvarias" Text='<%# Eval("codepinstitucion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>                  
                          <asp:TemplateField HeaderText="Número tipo estatus">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeroestatusvarias" Text='<%# Eval("codeptipoestatuscuenta") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Número tipo moneda">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeromonedavarias" Text='<%# Eval("codeptipomoneda") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Tipo de Cuenta">
                           <ItemTemplate>
                            <asp:Label ID="lblcuentavarias" Text='<%# Eval("ep_tipocuentanombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Institución">
                           <ItemTemplate>
                            <asp:Label ID="lblinstitucionvarias" Text='<%# Eval("ep_institucionnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Estatus">
                           <ItemTemplate>
                            <asp:Label ID="lblestatusvarias" Text='<%# Eval("ep_tipoestatuscuentanombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Moneda">
                           <ItemTemplate>
                            <asp:Label ID="lblmonedavarias" Text='<%# Eval("ep_tipomonedanombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Monto">
                           <ItemTemplate>
                            <asp:Label ID="lblmontovarias" Text='<%# Eval("ep_cuentasmonto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Origen de fondo">
                           <ItemTemplate>
                            <asp:Label ID="lblorigendefondovarias" Text='<%# Eval("ep_cuentasorigen") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
 <!-- Grid Fin Activos Cuentas-->
                <br/>
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Cuentas En Cooperativas:</h2>
            </div>
                <br />
 <!-- Grid Activos Cuentas Cooperativas-->
    <asp:GridView ID="GridViewcuentascooperativa" CssClass="mGrid" style="margin-left:auto;margin-right:auto"  runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Numero Cuentacooperativa" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerocuentacoope" Text='<%# Eval("codepcuentas") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Numero institucion" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeroinsticuentacoope" Text='<%# Eval("codepinstitucion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Numero moneda" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeromonedacuentacoope" Text='<%# Eval("codeptipomoneda") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Numero Estatus" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeroestatuscuentacoope" Text='<%# Eval("codeptipoestatuscuenta") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre Institución">
                           <ItemTemplate>
                            <asp:Label ID="lblinstitucioncuentacoope" Text='<%# Eval("ep_institucionnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>    
                         <asp:TemplateField HeaderText="Tipo de Moneda">
                           <ItemTemplate>
                            <asp:Label ID="lblmonedacuentacoope" Text='<%# Eval("ep_tipomonedanombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Estatus">
                           <ItemTemplate>
                            <asp:Label ID="lblestatuscuentacoope" Text='<%# Eval("ep_tipoestatuscuentanombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Monto">
                           <ItemTemplate>
                            <asp:Label ID="lblmontocuentacoope" Text='<%# Eval("ep_cuentasmonto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Origen de fondo">
                           <ItemTemplate>
                            <asp:Label ID="lblorigencuentacoope" Text='<%# Eval("ep_cuentasorigen") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
 <!-- Grid Fin Activos Cuentas Cooperativas-->  
                <br/>
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Cuentas Por Cobrar:</h2>
            </div>
                <br />
 <!-- Grid Activos Cuentas Por Cobrar-->
           <asp:GridView ID="GridViewcuentasporcobrar" style="margin-left:auto;margin-right:auto" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False"  BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Numero Cuentaporcobrar" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerocuentapc" Text='<%# Eval("codepcuentas") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre de la cuenta">
                           <ItemTemplate>
                            <asp:Label ID="lblnombrecuentapc" Text='<%# Eval("ep_cuentasnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Monto de la cuenta">
                           <ItemTemplate>
                            <asp:Label ID="lblmontocuentapc" Text='<%# Eval("ep_cuentasmonto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Motivo">
                           <ItemTemplate>
                            <asp:Label ID="lblmotivocuentapc" Text='<%# Eval("ep_cuentasorigen") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>                 
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
 <!-- Grid Fin Activos Cuentas Por Cobrar-->  
                <br>
             <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Inventarios:</h2>
            </div>
                <br />
                  <div class="campo" style="margin-left:80px;" >
                        <center><label class="col-sm-3" for="apellido">Tipo Mercaderia:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="NombreM" disabled/>
                        <center><label class="col-sm-3" for="apellido">Monto:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="MontoM" disabled/>  
                    </div>
                <br/>
                <br/>
         <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Inversiones:</h2>
            </div>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Nombre Entidad:</label></center>
                        <input style="border: 0" class="col-sm-3" type="text" runat="server" id="Text1" disabled/>
                        <center><label class="col-sm-2" for="apellido">Plazo:</label></center> 
                        <input style="border: 0" class="col-sm-1" type="text" runat="server" id="Text2" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Monto</label></center> 
                        <input style="border: 0" class="col-sm-1" type="text" runat="server" id="Text3" disabled/>
                   </div>
                 <div class="campo" style="margin-left:80px;" >
                    <br/>
                        <center><label class="col-sm-3" for="apellido">Monto en Q:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="Text4" disabled/>
                        <center><label class="col-sm-3" for="apellido">Origen Fondos:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="Text5" disabled/>  
                    </div> 
                <br />
           <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Inmuebles:</h2>
            </div>
                <br/>
 <!-- Grid Activos Inmuebles-->
    <asp:GridView ID="GridViewbienesinmuebles" style="margin-left:auto;margin-right:auto" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False"  BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Numero Bien Inmueble" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerodeinmueble" Text='<%# Eval("codepinmueble") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Número Tipo Inmueble" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lbltipodeinmueble" Text='<%# Eval("codeptipoinmueble") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre del inmueble">
                           <ItemTemplate>
                            <asp:Label ID="lblnombreinmueble" Text='<%# Eval("ep_tipoinmueblenombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Número de folio">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerofolio" Text='<%# Eval("ep_inmueblefolio") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Número de libro">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerodelibro" Text='<%# Eval("ep_inmueblelibro") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>   
                             <asp:TemplateField HeaderText="Dirección">
                           <ItemTemplate>
                            <asp:Label ID="lbldireccioninmueble" Text='<%# Eval("ep_inmuebledireccion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                             <asp:TemplateField HeaderText="Valor">
                           <ItemTemplate>
                            <asp:Label ID="lblvalorimnmueble" Text='<%# Eval("ep_inmueblevalor") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                             <asp:TemplateField HeaderText="Descripción">
                           <ItemTemplate>
                            <asp:Label ID="lbldescripcioninmueble" Text='<%# Eval("ep_inmuebledescripcion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                <br />
 <!-- Fin Grid Activos Inmuebles--> 
    <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Vehiculos:</h2>
            </div>
                <br/>
 <!-- Grid Activos Vehiculos-->
       <asp:GridView ID="GridViewvehiculos" style="margin-left:auto;margin-right:auto" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Numero de Vehículo" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerodeinmueble" Text='<%# Eval("codepvehiculo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Numero Tipo Inmueble" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotipovehiculo" Text='<%# Eval("codeptipovehiculo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Tipo de Vehículo">
                           <ItemTemplate>
                            <asp:Label ID="lbltipovehiculo" Text='<%# Eval("ep_tipovehiculonombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Marca">
                           <ItemTemplate>
                            <asp:Label ID="lblmarca" Text='<%# Eval("ep_vehiculomarca") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Linea">
                           <ItemTemplate>
                            <asp:Label ID="lbllineavehiculo" Text='<%# Eval("ep_vehiculolinea") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>   
                             <asp:TemplateField HeaderText="Modelo">
                           <ItemTemplate>
                            <asp:Label ID="lblmodelo" Text='<%# Eval("ep_vehiculomodelo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                             <asp:TemplateField HeaderText="Número de placa">
                           <ItemTemplate>
                            <asp:Label ID="lblplaca" Text='<%# Eval("ep_vehiculoplaca") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                <br />
 <!-- Fin Grid Activos Vehiculos-->
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Maquinaria y Equipo:</h2>
            </div>
                  <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Tipo Maquinaria:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="TMaquinaria" runat="server" disabled/>
                        <center><label class="col-sm-2" for="apellido">Monto:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="TMaquinariaMonto" runat="server" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Especificacion:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="TMaquinariaEs" runat="server" disabled/>
                   </div>
                <br>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Equipo Computo:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="EComputo" runat="server" disabled/>
                        <center><label class="col-sm-2" for="apellido">Amueblado Sala:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="AmuebladoS" runat="server" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Amueblado Comedor:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="AmuebladoCom" runat="server" disabled/>
                   </div>
                <div class="campo"  >
                    <br>
                    <br>
                        <center><label style="    " class="col-sm-8" for="apellido">Televisor:</label></center>
                        <input style="border: 0;  margin-left: -120px;max-width: 35px;" class="col-sm-2" type="text" id="TelevisorC" runat="server" disabled/> 
                        <input style="border: 0;  margin-left: -76px;max-width: 85px;" class="col-sm-2" type="text" id="TelevisorM" runat="server" disabled/>
                        <input style="border: 0;  margin-left: 8px;max-width: 85px;" class="col-sm-2" type="text" id="TelevisorT" runat="server" disabled/>
                    </div>
                <div class="campo"  >
                    <br>
                        <center><label style="    " class="col-sm-8" for="apellido">Equipo de Sonido:</label></center>
                        <input style="border: 0;  margin-left: -120px;max-width: 35px;" class="col-sm-2" type="text" id="EquipoSC" runat="server" disabled/> 
                        <input style="border: 0;  margin-left: -76px;max-width: 85px;" class="col-sm-2" type="text" id="EquipoSM" runat="server" disabled/>
                        <input style="border: 0;  margin-left: 8px;max-width: 85px;" class="col-sm-2" type="text" id="EquipoST" runat="server" disabled/>
                </div>
                <div class="campo"  >
                    <br>
                        <center><label style="    " class="col-sm-8" for="apellido">Lavadora:</label></center>
                        <input style="border: 0;  margin-left: -120px;max-width: 35px;" class="col-sm-2" type="text" id="LavadoraC" runat="server" disabled/> 
                        <input style="border: 0;  margin-left: -76px;max-width: 85px;" class="col-sm-2" type="text" id="LavadoraM" runat="server" disabled/>
                        <input style="border: 0;  margin-left: 8px;max-width: 85px;" class="col-sm-2" type="text" id="LavadoraT" runat="server" disabled/>
                </div>
                 <div class="campo"  >
                    <br/>
                        <center><label style="    " class="col-sm-8" for="apellido">Secadora:</label></center>
                        <input style="border: 0;  margin-left: -120px;max-width: 35px;" class="col-sm-2" type="text" id="SecadoraC" runat="server" disabled/> 
                        <input style="border: 0;  margin-left: -76px;max-width: 85px;" class="col-sm-2" type="text" id="SecadoraM" runat="server" disabled/>
                        <input style="border: 0;  margin-left: 8px;max-width: 85px;" class="col-sm-2" type="text" id="SecadoraT" runat="server" disabled/>
                </div> 
                <div class="campo"  >
                    <br/>
                        <center><label style="    " class="col-sm-8" for="apellido">Estufa:</label></center>
                        <input style="border: 0;  margin-left: -120px;max-width: 35px;" class="col-sm-2" type="text" id="EstufaC" runat="server"  disabled/> 
                        <input style="border: 0;  margin-left: -76px;max-width: 85px;" class="col-sm-2" type="text" id="EstufaM" runat="server" disabled/>
                        <input style="border: 0;  margin-left: 8px;max-width: 85px;" class="col-sm-2" type="text" id="EstufaT" runat="server" disabled/>
                </div>  
                <div class="campo"  >
                    <br>
                        <center><label style="    " class="col-sm-8" for="apellido">Refrigeradora:</label></center>
                        <input style="border: 0;  margin-left: -120px;max-width: 35px;" class="col-sm-2" type="text" id="RefriC" runat="server" disabled/> 
                        <input style="border: 0;  margin-left: -76px;max-width: 85px;" class="col-sm-2" type="text" id="RefriM" runat="server" disabled/>
                        <input style="border: 0;  margin-left: 8px;max-width: 85px;" class="col-sm-2" type="text" id="RefriT" runat="server" disabled/>
                </div>
                <div class="campo"  >
                    <br/>
                        <center><label style="    " class="col-sm-8" for="apellido">Telefono Movil:</label></center>
                        <input style="border: 0;  margin-left: -120px;max-width: 35px;" class="col-sm-2" type="text" id="TMC" runat="server" disabled/> 
                        <input style="border: 0;  margin-left: -76px;max-width: 85px;" class="col-sm-2" type="text" id="TMM" runat="server" disabled/>
                        <input style="border: 0;  margin-left: 8px;max-width: 85px;" class="col-sm-2" type="text" id="TMT" runat="server" disabled/>
                </div>
                <div class="campo"  >
                    <br/>
                        <center><label style="    " class="col-sm-8" for="apellido">Otros:</label></center>
                        <input style="border: 0;  margin-left: -120px;max-width: 35px;" class="col-sm-2" type="text" id="OtrosC" runat="server" disabled/> 
                        <input style="border: 0;  margin-left: -76px;max-width: 85px;" class="col-sm-2" type="text" id="OtrosM" runat="server" disabled/>
                        <input style="border: 0;  margin-left: 8px;max-width: 85px;" class="col-sm-2" type="text" id="OtrosT"  runat="server" disabled/>
                </div>
                <br/>
                <br/>
            <div class="encabezado2">
                <h2 style="font-size: 25px;color: white;">Pasivos</h2>
            </div>
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Cuentas por Pagar:</h2>
            </div>
                <br />
 <!-- Grid Pasivo Cuentas por Pagar-->
      <asp:GridView ID="GridViewcuentasporpagar" style="margin-left:auto;margin-right:auto" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="NÚmero Cuenta" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerocuentasporpagar" Text='<%# Eval("codepcuentasporpagar") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Tipo Cuenta" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lbltipocuentasporpagar" Text='<%# Eval("codeptipocuentasporpagar") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre del Plazo">
                           <ItemTemplate>
                            <asp:Label ID="lblnombreplazo" Text='<%# Eval("ep_tipocuentaspopagarnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Descripción">
                           <ItemTemplate>
                            <asp:Label ID="lbldescripcion" Text='<%# Eval("ep_cuentasporpagardescripcion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Monto">
                           <ItemTemplate>
                            <asp:Label ID="lblmonto" Text='<%# Eval("ep_cuentasporpagarmonto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>   
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
 <!-- Fin Grid Pasivo Cuentas por Pagar-->
                <br/>
             <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Prestamos:</h2>
            </div>
                <br />
 <!-- Grid Pasivo Prestamos-->
    <asp:GridView ID="GridViewpasivos"  CssClass="mGrid" style="margin-left:auto;margin-right:auto" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False"  BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Número prestamo" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeroprestamo" Text='<%# Eval("codepprestamo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Número Tipo prestamo" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotipoprestamo" Text='<%# Eval("codeptipoprestamo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Número de institución" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerodelainstitucion" Text='<%# Eval("codepinstitucion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Número Tipo de institución" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumtipodeinstitucion" Text='<%# Eval("codeptipoinstitucion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Tipo de prestamo">
                           <ItemTemplate>
                            <asp:Label ID="lbltipoprestamo" Text='<%# Eval("ep_tipoprestamonombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Tipo de institucion">
                           <ItemTemplate>
                            <asp:Label ID="lbltipoinstitucion" Text='<%# Eval("ep_tipoinstitucionnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Nombre de la institución">
                           <ItemTemplate>
                            <asp:Label ID="lblnombreinstitucion" Text='<%# Eval("ep_institucionnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Monto Inicial">
                           <ItemTemplate>
                            <asp:Label ID="lblmontoinicial" Text='<%# Eval("ep_prestamomomentoinicial") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Saldo Actual">
                           <ItemTemplate>
                            <asp:Label ID="lblsaldoactual" Text='<%# Eval("ep_prestamosaldoactual") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Destino ">
                           <ItemTemplate>
                            <asp:Label ID="lbldestinoprestamo" Text='<%# Eval("ep_prestamodestino") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Fecha de desembolso">
                           <ItemTemplate>
                            <asp:Label ID="lblfechadesembolso" Text='<%# string.Format("{0: yyyy-MM-dd}",Eval("ep_prestamofechadesembolso")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Fecha de finalización">
                           <ItemTemplate>
                            <asp:Label ID="lblfechafinalizacion" Text='<%# string.Format("{0: yyyy-MM-dd}",Eval("ep_prestamofechadefinalizacion")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
 <!-- Fin Grid Pasivo Prestamos-->
                <br/>
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Tarjetas de Credito:</h2>
            </div>
                <br />
 <!-- Grid Pasivo Tarjetas-->
       <asp:GridView ID="GridViewtarjetas" CssClass="mGrid" style="margin-left:auto;margin-right:auto" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False"  BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Número de tarjeta" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotarjeta" Text='<%# Eval("codeptrajetadecredito") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Número Tipo institucion" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotipoinstituciontarjeta" Text='<%# Eval("codeptipoinstitucion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Número institucion">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeroinstituciontarjeta" Text='<%# Eval("codepinstitucion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Tipo de institución">
                           <ItemTemplate>
                            <asp:Label ID="lblnombretipoinstituciontarjeta" Text='<%# Eval("ep_tipoinstitucionnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Nombre Institución">
                           <ItemTemplate>
                            <asp:Label ID="lblnombreinstituciontarejta" Text='<%# Eval("ep_institucionnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Monto en Q">
                           <ItemTemplate>
                            <asp:Label ID="lblmontoqtarjeta" Text='<%# Eval("ep_tarjetadecreditomonedaqtz") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Monto en $">
                           <ItemTemplate>
                            <asp:Label ID="lblmontousdtarjeta" Text='<%# Eval("ep_tarjetadecreditomonedausd") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                   <asp:TemplateField HeaderText="Saldo actual">
                           <ItemTemplate>
                            <asp:Label ID="lblsaldoactualtarjeta" Text='<%# Eval("ep_tarjetadecreditosaldoactual") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                <br />
 <!-- Fin Grid Pasivo Prestamos-->
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Otras Deudas:</h2>
            </div>
                  <div class="campo" style="margin-left:80px;" >
                        <center><label class="col-sm-2" for="apellido">Especificacion:</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" id="EspD"  runat="server" disabled/>
                        <center><label class="col-sm-3" for="apellido">Monto:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="EspM"  runat="server" disabled/>  
                    </div>
                <br/>
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Pasivo Contigente:</h2>
            </div>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Nombre Entidad:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="NombreEN"  runat="server" disabled/>
                        <center><label class="col-sm-2" for="apellido">Nombre Deudor:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="NombreD"  runat="server" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Relacion Deudor:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="RelacionD"  runat="server" disabled/>
                   </div>
                <br/>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Saldo:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="SaldoD"  runat="server" disabled/>
                        <center><label class="col-sm-2" for="apellido" style="margin-top: -10px;">Fecha Desembolso:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="FechaDD"  runat="server" disabled/> 
                        <center><label class="col-sm-2" for="apellido" style="margin-top: -10px;">Fecha Finalizacion:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="FechaFina"  runat="server" disabled/>
                   </div>
                <br>
             <div class="encabezado2">
                <h2 style="font-size: 25px;color: white;">Ingresos</h2>
            </div>
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Ingresos Mensuales en la Cooperativa Guadalupana:</h2>
            </div>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Sueldo Base:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="SuelB"  runat="server" disabled/>
                        <center><label class="col-sm-2" for="apellido">Bonificaciones:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="SBoni"  runat="server" disabled/> 
                        <center><label class="col-sm-2" for="apellido" style="margin-top: -8px;">Comisiones Mensuales:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="CMensua"  runat="server" disabled/>
                   </div>
                <br>
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Negocio Propio:</h2>
            </div>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Tipo Negocio:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text"  id="TipoNeg"  runat="server" disabled/>
                        <center><label class="col-sm-2" for="apellido">Nombre Negocio:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text"  id="NombreNeg"  runat="server" disabled/> 
                        <center><label class="col-sm-2" for="apellido">No. Patente:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text"  id="NoNeg"  runat="server" disabled/>
                   </div>
                <br/>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">No Empleados:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text"  id="EmpleNeg"  runat="server" disabled/>
                        <center><label class="col-sm-2" for="apellido">Obj del Negocio:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text"  id="ObjNeg"  runat="server" disabled/> 
                        <center><label class="col-sm-2" for="apellido">Ingresos Mensuales:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="IngeNeg"  runat="server" disabled/>
                   </div>
                <br/>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido" style="margin-top: -10px;">Egresos Mensuales:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text"  id="EgrNeg"  runat="server" disabled/>
                        <center><label class="col-sm-2" for="apellido">Direccion:</label></center> 
                        <input style="border: 0" class="col-sm-6" type="text"  id="DireNeg"  runat="server" disabled/>
                   </div>
                <br/>
                <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Remesas</h2>
            </div>
               <div class="campo" style="margin-left:80px;" >
                        <center><label class="col-sm-3" for="apellido" style="margin-top: -10px;">Nombre Remitente:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="NomRem"  runat="server" disabled/>
                        <center><label class="col-sm-3" for="apellido"  style="margin-top: -10px;">Relacion Remitente:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="RelaRem"  runat="server" disabled/>  
                    </div> 
                <div class="campo" style="margin-left:80px;" >
                    <br>
                        <center><label class="col-sm-3" for="apellido">Monto:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="MontoRem"  runat="server" disabled/>
                        <center><label class="col-sm-3" for="apellido">Periodo Recepcion:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="PeriRem"  runat="server" disabled/>  
                    </div> 
                <br>
                <br>
             <div class="encabezado2">
                <h2 style="font-size: 25px;color: white;">Egresos</h2>
            </div>
               <div class="campo" style="margin-left:80px;" >
                        <center><label class="col-sm-3" for="apellido">Aliementación:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="Alimen"  runat="server" disabled/>
                        <center><label class="col-sm-5" for="apellido">Transporte o Gasolina:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="Gas"  runat="server" disabled/>  
                    </div>
                <br>
                 <div class="campo" style="margin-left:80px;" >
                        <center><label class="col-sm-3" for="apellido">Prestamos:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="Presta"  runat="server" disabled/>
                        <center><label class="col-sm-5" for="apellido">Pago Estudios:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="PagoEstud"  runat="server" disabled/>  
                    </div>
                <br>
                 <div class="campo" style="margin-left:80px;" >
                        <center><label class="col-sm-3" for="apellido">Vestuario:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="Vestuar"  runat="server" disabled/>
                        <center><label class="col-sm-5" for="apellido">Tarjeta de Credito:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="TarCre"  runat="server" disabled/>  
                    </div>
                  <br>
                 <div class="campo" style="margin-left:80px;" >
                        <center><label class="col-sm-3" for="apellido">Recreacion:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="Recrea"  runat="server" disabled/>
                        <center><label class="col-sm-5" for="apellido">Otros Egresos:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="Otros"  runat="server" disabled/>  
                    </div>
                <br>
            <div class="encabezado2">
                <h2 style="font-size: 25px;color: white;">Patrimonio</h2>
            </div>
                 <div class="campo" style="margin-left:80px;" >
                        <center><label class="col-sm-3" for="apellido">Total Pasivo:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" id="apellido" disabled/>
                        <center><label class="col-sm-5" for="apellido">Total Activo:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" id="apellido" disabled/>  
                    </div>
                <br/>
                <div class="campo" style="margin-left:25px;" >
                        <center><label class="col-sm-8" for="apellido">Patrimonio (Activo - Pasivo):</label></center>
                        <input style="border: 0" class="col-sm-3" type="text" id="apellido" disabled/>
                      
                    </div>
                <br/>
                <div class="encabezado2">
                <h2 style="font-size: 20px;color: white;">Declaro bajo juramento que los datos consignados en el presente documento, son verdaderos y ciertos y me someto  a lo establecido en las leyes del país, en caso de perjurio.</h2>
            </div>
                 <div class="campo" style="margin-left:25px;" >
                        <center><label class="col-sm-8" for="apellido">Firma del Empleado:</label></center>
                        <input  class="col-sm-2" type="text" id="FRmE" style="margin-left: -90px;max-width: 83px;border: 0" runat="server" disabled/>
                        <input style="border: 0" class="col-sm-3" type="text" id="FRmE1"  runat="server" disabled/>
                 </div>
                <br/>
                 <div class="campo" style="margin-left:25px;" >
                        <center><label class="col-sm-8" for="apellido">Lugar y Fecha de Elaboracion:</label></center>
                        <input style="border: 0;margin-left: -90px;" class="col-sm-4" type="text" id="apellido" disabled/>
                 </div>
                <br/>
            </div>
        </div>
    </div>

    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js'></script>
    <script  src="../../../DiseñoForms/script.js"></script>
      </form>
</body>
</html>
