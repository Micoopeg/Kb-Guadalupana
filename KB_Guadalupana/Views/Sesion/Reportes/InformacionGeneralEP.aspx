<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformacionGeneralEP.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.Reportes.InformacionGeneralEP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Reporte Informacion General</title>
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
            <a class="active" style="border: black 2px solid;"  href="../MenuBarra.aspx">Inicio</a>
            <a class="active" style="border: black 2px solid;    background-color: #003563;" href="InformacionGeneralEP.aspx">Informacion General</a>
            <%--<a class="active" style="border: black 2px solid;" href="../Inicio.aspx">Estado Patrimonial</a>--%>
            <a class="active" style="border: black 2px solid;" href="ReporteEP.aspx">Declaracion de Bienes</a>
               <a class="active" style="border: black 2px solid;" href="ReporteT.aspx">Estado Patrimonial</a>
            <a href="../CerrarSesion.aspx" style="right: 0%;position: absolute;border: black 2px solid;">Cerrar Sesion</a>
          </div>
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
     <div class="col-md-3" style="display: flex;justify-content: center;align-items: center;">
         <a  style="cursor:pointer;" class="fancy-button medium wisteria bounce bell infinite ">
             <asp:Button ID="confirmar" runat="server" style="background-color: #69a43c;border-color: #69a43c;margin-top: -10px;    margin-top: -11px;margin-left: -2px;" CssClass="fancy-button medium wisteria bounce bell infinite " OnClick="confirmarep_Click" Text="Confirmar" />
					<span class="icon" style="margin-top: -33px;position: absolute; right: 29px;">
							<i class="fa fa-check"></i>
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
                <h2>ESTADO PATRIMONIAL EMPLEADOS</h2>
            </div> 
            <div class="encabezado2">
                <h2 style="font-size: 20px;color: white;">En cumplimiento al  artículo 19,  de la Ley contra el Lavado de Dinero u Otros Activos y 10 de su Reglamento declaro:</h2>
            </div>
            <div class="formulario" style="margin-left: 75px;margin-top: 15px;">
                    <div class="campo" style="margin-left: 120px;">
                        <input style="border: 0" class="col-sm-2" value="Prueba" type="text" runat="server" id="id" hidden/>
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
                <h2 style="font-size: 25px;color: white;">Información General</h2>
            </div>
                <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Agencia:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="AgenciaIG" disabled/>
                        <center><label class="col-sm-2" for="apellido">Área:</label></center> 
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
                        <center><label class="col-sm-2" for="apellido">Dirección:</label></center> 
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
                        <center><label class="col-sm-3" for="apellido" style="margin-top: -7px;">No. Documento Identificación:</label></center> 
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
                        <center><label class="col-sm-2" for="apellido">Religión:</label></center> 
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
                        <asp:TemplateField HeaderText="Tipo de teléfono">
                            <ItemTemplate>
                                <asp:Label ID="lblnombretelefono" Text='<%# Eval("ep_tipotelefononombre") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Número de teléfono">
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
                <h2 style="font-size: 25px;color: white;">Información Familiar</h2>
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
                       <center><label class="col-sm-3" for="apellido">Nombre Cónyuge:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="NombreCF" disabled/>
                        <center><label class="col-sm-3" for="apellido" style="margin-top: -7px;">Ocupacion Cónyuge</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="OcupacionCIF" disabled/> 
                   </div>
                   <div class="campo" style="margin-left:80px;" >
                    <br>
                       <center><label class="col-sm-5" for="apellido" style="margin-top: -7px;">Fecha Nacimiento Cónyuge</label></center> 
                        <input style="border: 0" class="col-sm-3" type="text" runat="server" id="FechaCIF" disabled/> 
                   </div>
                <br />
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Hijos:</h2>
            </div>
                <br />
    <!-- Grid Informacion Familiar Hijos-->
                <center><h4 id="titulo" runat="server" visible="false"><b>N/A</b></h4></center>

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
        <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">En caso de emergencia llamar a:</h2>
            </div>
                  <div class="campo" style="margin-left: -5px;" >
                        <center><label class="col-sm-2" for="apellido">Nombre:</label></center>
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="NombreEC" disabled/>
                        <center><label class="col-sm-2" for="apellido">Teléfono:</label></center> 
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
                        <center><label class="col-sm-3" for="apellido" style="">Semestre Cursado:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="SemestreEU" disabled/> 
                       
                   </div>
                 <div class="campo" style="margin-left:80px;" >
                    <br/>
                      <center><label class="col-sm-3" for="apellido">Año Cursado:</label></center> 
                        <input style="border: 0" class="col-sm-2" type="text" runat="server" id="AñoEU" disabled/>
                        <center><label class="col-sm-2" for="apellido">Universidad:</label></center>
                        <input style="border: 0" class="col-sm-4" type="text" runat="server" id="UniverEU" disabled/>
                     
                    </div> 
                <br>
            <div class="encabezado3">
                <h2 style="font-size: 25px;color: white;">Otros Estudios:</h2>
            </div>
 <!-- Grid Informacion Otros Estudios-->
                <br />
                <center><h4 id="Titulo1" runat="server" visible="false"><b>N/A</b></h4></center>
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
                <hr style="border-color:#003563;">
                 <div class="encabezado2">
                <h2 style="font-size: 20px;color: white;">Declaro bajo juramento que los datos consignados en el presente documento, son verdaderos y ciertos y me someto  a lo establecido en las leyes del país, en caso de perjurio.</h2>
            </div>
                 <div class="campo" style="margin-left:25px;" >
                        <center><label class="col-sm-8" for="apellido">Usuario:</label></center>
                         <input  style="border: 0;margin-left: -122px;background-color: white;font-weight: bold;font-size: 20px;margin-top: -16px;"  class="col-sm-4" type="text"  runat="server" id="Text2" disabled/>
                         <input  style="border: 0;margin-left: 461px; margin-top: -5px; background-color: white;font-weight: bold;"  class="col-sm-4" type="text"  runat="server" id="Text1" disabled/>
                 </div>
                <br />
                <br />
                </div>
            </div>
        </div>

    </form>
</body>
</html>
