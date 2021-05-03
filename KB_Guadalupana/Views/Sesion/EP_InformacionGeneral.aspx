<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EP_InformacionGeneral.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.EP_InformacionGeneral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Estado Patrimonial</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <link rel="stylesheet" href="../../DiseñoForms/style.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link  rel="stylesheet" href="../../DiseñoCss/EstilosCss.css" type="text/css" />
    <link rel="stylesheet" href="../../DiseñosGrid/Grids.css" type="text/css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
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
  background-color: #B80416;
  color: White;
}

 .fa-check-circle::before 
 {
  font-family: "FontAwesome", sans-serif;
  content: "\f0a5";
  font-size: 17px;
  color: #003563;
}

.seleccionarcelulargridview
{
}
.seleccionarhijogridview
{

}
.seleccionarestudiogridview{

}
.seleccionarcuentaporcobrargridview{

}
.seleccionarbienesinmueblesgridview{

}
.seleccionarvehiculosgridview{

}
.seleccionarcuentasporpagargridview{

}
.seleccionarprestamogridview{

}
.seleccionartarjetasgridview{

}
.seleccionarcooperativasgridview{

}
.seleccionarcuentasvariasgridview{

}
.seleccionarinversionesgridview{

}
.seleccionarestudiougridview{

}
.prueba
{
    color: white;
    background-color: #003563;
    text-align: center;
    font-weight: bold;
}
.centrado
{
    text-align: center;
}
.diseño
.topnav a.active {
  background-color: #69a43c;
  color: white;
}

.content
{
    position: absolute;
    margin-left: -253px;
    margin-top: -75px;
    width: 25%;
    height: 106px;
    padding: 10px;
    background-color: #003563;
    color: white;
}

</style>
</head>


<body>
    <div class="topnav">
            <a class="active" href="MenuBarra.aspx">Inicio</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b runat="server" id="NombreUsuario"></b></span>
            <a href="CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
    </div>

    <div class="menu"></div>
<form id="msform" runat="server" class="forrmulario">
   <ul id="progressbar">
    <li class="active"></li>
    <li></li>
    <li></li>
    <li></li>
       <li class="estilo"></li>
    <li class="estilo"></li>
    <li class="estilo"></li>
    <li class="estilo"></li>
    <li class="estilo1"></li>
    <li class="estilo1"></li>
    <li class="estilo2"></li>
    <li class="estilo2"></li>
  </ul>
<!--  Area Informacion General y sus 4 Secciones    -->
    <fieldset style="margin-top: -18px;box-shadow: 0 0 15px 1px rgb(0 53 99);" id="primerof" >
    <h2 class="fs-title"><b>Información General</b></h2>
          <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: 0; right: 8px;max-width: 118px" />
      <br/>
     
        <input id="cifai" runat="server" type="number" visible="false"/>
     
      <input id="IGCIF" runat="server" type="number"  placeholder="CIF (Codigo Empleado)"  min="1" pattern="^[0-9]+" maxlength="10" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"  />
       <asp:DropDownList id="IGAgencia1"  OnSelectedIndexChanged="IGAgencia1_SelectedIndexChanged" runat="server" class="tampe" AutoPostBack="true" OnTextChanged="cbosucursal_Click"></asp:DropDownList>
       <asp:DropDownList id="IGADepa1" OnSelectedIndexChanged="IGADepa1_SelectedIndexChanged" runat="server" class="tampe" AutoPostBack="true" ></asp:DropDownList>
        <asp:DropDownList id="IGDPuestos" runat="server" class="tampe" AutoPostBack="true" ></asp:DropDownList>      
        
     <hr class="solid" style="margin-top: 5px;" />
         <input id="IGPApellido" runat="server" type="text" class="tam"   placeholder="Primer Apellido" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
         <input id="IGSApellido" runat="server" type="text" class="tam"   placeholder="Segundo Apellido" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
         <input id="IGPNombre" runat="server" type="text" class="tampe"   placeholder="Primer Nombre" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
         <input id="IGSNombre" runat="server" type="text" class="tampe"   placeholder="Segundo Nombre" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
         <input id="IGONombre" runat="server" type="text" class="tampe"   placeholder="Otros Nombres" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
       
      <asp:DropDownList id="IGPDepartamento1" runat="server" class="tampe" AutoPostBack="true" ></asp:DropDownList>
      <asp:DropDownList id="IGMunicipio1" runat="server" class="tampe" AutoPostBack="true" ></asp:DropDownList>
      <asp:DropDownList id="IGPAZona1" runat="server" class="tampe" AutoPostBack="true" ></asp:DropDownList>
      <input id="IGDireccion" runat="server" type="text"  placeholder="Direccion" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
      <asp:DropDownList id="IGDoc1" runat="server" class="tampe" AutoPostBack="true" ></asp:DropDownList> 
      <input id="IGNoDoc" runat="server" type="text" class="tam" style="width: 66%;"   placeholder="No. Documento Identificacion" maxlength="13" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
      <hr class="solid" style="margin-top: 5px;"/>
      <br/>
      <input type="button" name="next" style="background-color: #003563" class="next action-button" value="Siguiente >" />
  </fieldset>
    <fieldset id="segundof" style="box-shadow: 0 0 15px 1px rgb(0 53 99);" runat="server">
 
    <h2 class="fs-title"><b>Información General</b></h2>
                <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: 0; right: 8px;max-width: 118px" />
      <br />
      <label for="start">Fecha Nacimiento</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <input id="IGFNacimiento" runat="server" class="tam" type="date"  name="trip-start"
       value="2018-07-22"
       min="1950-01-01" max="2021-12-31" />
       <input id="IGNits" runat="server" type="text" class="tam"   placeholder="Nit" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
      <input id="IGNacionalidad" runat="server" type="text" class="tam"   placeholder="Nacionalidad" maxlength="15" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
      <input id="IGCorreo" runat="server" style="width: 36.5%;" type="email" class="tampe"   placeholder="Correo Electronico" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <input id="IGEstatura" runat="server" style="width: 20.0%;" type="number" class="tampe decimales"   placeholder="Estatura"   />
        <input id="IGPeso" runat="server" style="width: 20.0%;" type="number" class="tampe"   placeholder="Peso" maxlength="3" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
      <input id="IGReligion" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
       <input id="Text6" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />

      <hr class="solid" style="margin-top: 5px;" />
        
      <asp:DropDownList id="IGTCel1" runat="server" style="margin-left: 230px;" class="tampe" AutoPostBack="true"  onchange="javascript:cmbtipotelefono();" ></asp:DropDownList>
      <input id="IGCelular" runat="server" type="number" class="tampe"   placeholder="Numero" required minlength="8" maxlength="8"  oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
      <div id="AgregarIG" runat="server" style="position: absolute;margin-top: -64px; margin-left: 50px;">
             <a href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarcelular()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarIG" runat="server" style="position: absolute;margin-top: -45px; margin-left: 50px;">
             <a href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarcelular()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarIG" runat="server" style="position: absolute;margin-top: -26px; margin-left: 50px;">
             <a href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarcelular()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
    <div class="row">
        <div id="content" class="col-lg-12">
            <div class="content"style="text-align: justify"><b>Usuario:</b> para poder guardar tus datos debes dar click en la la opción Guardar/Agregar. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:red"></i></div>
        </div>
    </div>
        <%-- GRIDVIEW NUMEROS DE TELEFONO --%>
        <div id="divGridcelular" style="overflow: auto; height: 130px">
     <asp:GridView ID="GridViewcelular" CssClass="mGrid" style="width: 692px;text-align:center" runat="server"  HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedcelular" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="tipo de teléfono" Visible="False">
                           <ItemTemplate>
                           <asp:Label ID="lblcodeptelefono" Text='<%# Eval("codeptelefono") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="tipo de teléfono" Visible="False">
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
                            <asp:ButtonField   Text="Seleccionar" ItemStyle-CssClass="seleccionarcelulargridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>
            </div>
      <hr class="solid" style="margin-top: 5px;" />
      
      <br/>
      <input type="button" name="previous" class="previous action-button" style="background-color: #003563" value="< Anterior"  />
      <input type="button" name="next" class="next action-button" style="background-color: #003563" value="Siguiente >"  />
  </fieldset>
    <fieldset id="tercerof" style="box-shadow: 0 0 15px 1px rgb(0 53 99);">
    <h2 class="fs-title"><b>Información Familiar</b></h2>
      <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: 0; right: 8px;max-width: 118px" />
     <br/>
  
    <label for="start">Estado Civil</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
    <asp:DropDownList id="id_categoriaestadocivil" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbestadocivil();"  ></asp:DropDownList>

         
     <hr class="solid" style="margin-top: 5px;" />
         <input  type="text" class="tam"  id="IFNombre" runat="server"   placeholder="Nombre Completo Conyuge" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0,  this.maxLength);"  />
         <input  type="text" class="tam"  id="IFOcupacion" runat="server" placeholder="Ocupacion Conyuge" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"   />
          <input type="text" id="id_input5" style="margin-left: 5px;" runat="server" class="tampe"   placeholder="Apellido Casada" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"  />&nbsp;&nbsp;&nbsp; 
          <label for="start" style="margin-left: 56px;">Fecha Boda</label>&nbsp;&nbsp; 
          <input id="id_input6" class="tampe" style="margin-left: 69px;" runat="server"  type="date"  name="trip-start" value="2020-04-24" min="1950-01-01" max="2021-12-31" />
          <label for="start" style="margin-left: 68px;">Fecha Nacimiento Cónyuge</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
          <input class="tam" id="IFFecha" runat="server" style="margin-left: 69px;"  type="date"  value="2020-04-24" min="1950-01-01" max="2021-12-31" />
          <input id="Text7" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
       
        <div id="AgregarIF" runat="server" style="position: absolute;margin-top: 40px; margin-left: 30px;">
             <a id="btnAgregarIF" runat="server" href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarhijos()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarIF" runat="server"  style="position: absolute;margin-top: 63px; margin-left: 30px;">
             <a href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarhijos()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarIF" runat="server"  style="position: absolute;margin-top: 85px; margin-left: 30px;">
             <a href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarhijos()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
     
          <hr class="solid" style="margin-top: 5px;"/>

   <input  type="text" class="tam"  id="Text1" runat="server" style="margin-left: 163px;"  placeholder="Nombre Completo Hijo" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0,  this.maxLength);"  />
   <input  type="text" class="tam" style="max-width: 177px;"  id="Text2" runat="server" placeholder="Ocupación Hijo" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"   />
   <input  type="text" id="Text3" runat="server" style="max-width: 525px;margin-left: 163px;" placeholder="Comentarios" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"   />
   <label for="start" style="margin-left: 175px;">Fecha Nacimiento Hijo</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
   <input class="tam" id="Date1" runat="server" style="margin-left: 66px;max-width: 270px;"  type="date"  value="2020-04-25" min="1950-01-01" max="2021-12-31" />
       <%-- GRIDVIEW NUMEROS DE HIJOS --%>
        <div class="row">
        <div id="content" class="col-lg-12">
            <div class="content"style="text-align: justify"><b>Usuario:</b> para poder guardar tus datos debes dar click en la la opción Guardar/Agregar. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:red"></i></div>
        </div>
    </div>
        <div id="divGridhijos" style="overflow: auto; height: 130px">
     <asp:GridView ID="GridViewhijos" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedhijos" BorderStyle="Solid">
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
                         <asp:TemplateField HeaderText="Ocupacion">
                           <ItemTemplate>
                            <asp:Label ID="lblocupacionhijo" Text='<%# Eval("ep_infofamiliarocupacionhijos") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Comentario">
                           <ItemTemplate>
                            <asp:Label ID="lblcomentariohijo" Text='<%# Eval("ep_infofamiliarcomentario") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Fecha Nacimiento">
                           <ItemTemplate>
                               <asp:Label ID="lblfechanachijo" Text='<%# string.Format("{0: yyyy-MM-dd}",Eval("ep_infofamiliarfechanacimientohijo")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarhijogridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
            </div>
     <hr class="solid" style="margin-top: 5px;"/>
      <h3 class="fs-title"><b>En caso de emergencia llamar a:</b></h3>
     <input id="IFNombreCo" runat="server" type="text" class="tampe"   placeholder="Nombre Completo" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
      <input id="IFtel" runat="server" type="number" class="tampe"   placeholder="Numero Telefono" maxlength="8" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
      <input id="IFparenteso" runat="server" type="text" class="tampe"   placeholder="Parentesco" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
      <hr class="solid" style="margin-top: 5px;"/>

 
      <input type="button" name="previous" class="previous action-button" style="background-color: #003563" value="< Anterior" />
      <input type="button" name="next" class="next action-button" style="background-color: #003563" value="Siguiente >" />
    </fieldset>
    <fieldset id="cuartaf" runat="server" style="box-shadow: 0 0 15px 1px rgb(0 53 99);">
    <h2 class="fs-title"><b>Estudios Universitarios</b></h2>
            <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: 0; right: 8px;max-width: 118px" />
    <br/>

     <div id="Div1" runat="server" style="position: absolute;margin-top: 8px; margin-left: 50px;">
             <a href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarestudiosuni()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="Div2"  runat="server" style="position: absolute;margin-top: 32px; margin-left: 50px;">
             <a href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarestudiosuni()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="Div3" runat="server" style="position: absolute;margin-top: 56px; margin-left: 50px;">
             <a href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarestudiosuni()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>

    <input id="ENombreCarrera" runat="server" style="max-width: 250px;margin-left: 182px;" type="text" class="tam"   placeholder="Nombre Carrera" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
    <input id="ESemestre" runat="server" type="text" class="tam"  style="max-width: 250px" placeholder="Ultimo Semestre Cursado" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
    <input id="EAño" runat="server" type="number" class="tam" style="max-width: 250px;margin-left: 182px;"  placeholder="Ultimo Año Cursado" maxlength="4" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
    <%-- <input type="text" class="tam"  id="idiomaestudio" runat="server" placeholder="Idioma" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />--%>
    <input id="EUniversidad" runat="server" type="text" class="tam"  style="max-width: 250px" placeholder="Universidad" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
     <input visible="false" id="Text22" runat="server" type="text" class="tam"  style="max-width: 250px" placeholder="Universidad" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
  <%-- GRIDVIEW NUMEROS DE ESTUDIOS Univesitarios --%>
     <div class="row">
        <div id="content1" class="col-lg-12">
            <div class="content"style="text-align: justify"><b>Usuario:</b> para poder guardar tus datos debes dar click en la la opción Guardar/Agregar. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:red"></i></div>
        </div>
    </div>
         <div id="divGridestudiosU" style="overflow: auto; height: 130px">
    <asp:GridView ID="GridestudiosU" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedestudiosu" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Numero Universidad" Visible="False" >
                           <ItemTemplate>
                            <asp:Label ID="lblnumerouniversidad" Text='<%# Eval("codepestudio") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre de la Universidad">
                           <ItemTemplate>
                            <asp:Label ID="lblnombreuniversidad" Text='<%# Eval("ep_estudionombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Último Semestre Cursado">
                           <ItemTemplate>
                            <asp:Label ID="lblduracionuniversidad" Text='<%# Eval("ep_estudioduracion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Año Cursado">
                           <ItemTemplate>
                            <asp:Label ID="lblañouniversidad" Text='<%# Eval("ep_estudioaño") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Lugar de estudio">
                           <ItemTemplate>
                            <asp:Label ID="lbllugaruniversidad" Text='<%# Eval("ep_estudiolugar") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarestudiougridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
             </div>        


    <hr class="solid" style="margin-top: 5px;" />
    <h3 class="fs-title"><b>Otros Estudios:</b></h3>
     <input id="OECurso" runat="server" type="text" class="tam" style="max-width: 250px;margin-left: 185px;"  placeholder="Nombre Curso" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
     <input id="OEEstablecimiento" runat="server" type="text" class="tam"   style="max-width: 250px"  placeholder="Nombre Establecimiento" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
     <input id="OEModalidad" runat="server" type="text" class="tampe" style="    margin-left: 185px;max-width: 195px;"   placeholder="Modalidad" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
     <input id="OEAño" style="max-width: 150px;" runat="server" type="number" class="tampe"   placeholder="Año" maxlength="4" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
     <input id="OEDuracion" style="max-width: 150px;" runat="server" type="text" class="tampe"   placeholder="Duracion" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
     <input type="text"  id="Text4" style="max-width: 500px;margin-left: 185px;" runat="server" placeholder="Idioma" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
     <input id="Text12" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
         <hr class="solid" style="margin-top: 5px;"/>
    
         <div id="AgregarEU" runat="server" style="position: absolute;margin-top: -150px; margin-left: 50px;">
             <a href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarestudios()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarEU"  runat="server" style="position: absolute;margin-top: -125px; margin-left: 50px;">
             <a href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarestudios()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarIEU" runat="server" style="position: absolute;margin-top: -100px; margin-left: 50px;">
             <a href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarestudios()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
  

         <%-- GRIDVIEW NUMEROS DE ESTUDIOS --%>
         <div id="divGridestudio" style="overflow: auto; height: 130px">
    <asp:GridView ID="GridViewEstudios" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedestudios" BorderStyle="Solid">
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
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarestudiogridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
             </div>
      <br/>
     <div class="row">
        <div style="" class="col-lg-12">
            <div class="content" style="text-align: justify;background-color:#69a43c;height: 125px;width: 30%;    margin-top: -98px;    margin-left: -268px;"><b>Usuario:</b> Debes dar en Guardar para que tus datos se almacenen en el sistema y poder pasar a la siguiente seccion. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:#003563"></i></div>
        </div>
    </div>
      <input type="button" runat="server" name="next" class="next action-button" value="Guardar" onclick="guardarinformaciongeneral()"
             id="btnepigfinal" /> 
      <input type="button" name="previous" class="previous action-button " style="background-color: #003563" value="< Anterior"  />
      <input type="button" runat="server" name="next" id="boton1" class="next action-button sig1" style="background-color: #003563" value="Siguiente>" />
            </fieldset>
<!--  Fin Area de Formulario Informacion General y sus 4 Secciones   -->
<!--  Area Formulario Activos y sus 4 Secciones    -->
    <fieldset id="quintof" style="box-shadow: 0 0 15px 1px rgb(0 112 209);">
            <h2 class="fs-title"><b>Activos</b></h2>
            <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: 0; right: 8px;max-width: 118px" />
        <label>Caja: </label>
        <input id="ACCaja" runat="server" type="number" class="tam"   placeholder="Caja" maxlength="4" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
         <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
     <h3 class="fs-title" style="margin-top:-10px"><b>Cuentas Bancarias</b></h3>
         <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
          <div class="col-12">
                                <br/>
                 <select class="tampe" id="DropDownList1" runat="server" style=" margin-left: 120px;">
                         <option disabled selected>[Tipo de cuenta]</option>
                         <option value="1">Monetaria</option>
                         <option value="2">Ahorro</option>
                 </select>
              <%--<asp:DropDownList style="max-width: 227px;margin-left: 120px;" id=" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbtipodecuentasactivo();" ></asp:DropDownList>--%>
              <asp:DropDownList style="max-width: 150px;" id="ACNBanco1" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbinstitucionactivo();"  ></asp:DropDownList>
              <asp:DropDownList style="max-width: 150px;" id="ACEstatus1" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbtipodeestadoactivo();"  ></asp:DropDownList>
              <br />
              <asp:DropDownList style="max-width: 150px; margin-left: 120px;" id="ACTMoneda1" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbtipomonedaactivo();"  ></asp:DropDownList>
              <input id="ACMonto" style="max-width: 32.5%;" runat="server" type="number" class="tam"   placeholder="Saldo en Cuenta" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
              <input id="ACOFondos" runat="server"  style="max-width: 150px;" type="text" class="tam"   placeholder="Origen Fondos" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
               <input id="Text13" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
              <br />

        <div id="AgregarAC" style="position: absolute;margin-top: -90px; margin-left: 10px;">
             <a id="AgregarAC1" runat="server" href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarcuenta()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarAC" style="position: absolute;margin-top: -65px; margin-left: 10px;">
             <a id="GuardarAC1" runat="server" href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarcuenta()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarAC" style="position: absolute;margin-top: -40px; margin-left: 10px;">
             <a id="EliminarAC1" runat="server" href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarcuenta()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
        </div>
         <div class="row">
        <div id="content3" class="col-lg-12">
            <div class="content"style="text-align: justify"><b>Usuario:</b> para poder guardar tus datos debes dar click en la la opción Guardar/Agregar. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:red"></i></div>
        </div>
    </div>
           <%-- GRIDVIEW NUMEROS DE CUENTAS --%>
        <div id="divGridcuentasvarias" style="overflow: auto; height: 130px">
                 <asp:GridView ID="GridViewcuentasvarias" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedcuentasvarias" BorderStyle="Solid">
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
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarcuentasvariasgridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
            </div>
                 <hr class="solid" style="margin-top: 5px;"/>
    <br/>
        <input type="button" name="previous" class="previous action-button" style="background-color: #0070D1" value="< Anterior" />
        <input type="button" name="next" class="next action-button" style="background-color: #0070D1" value="Siguiente >" />
  </fieldset> 
    <fieldset id="sextof" style="box-shadow: 0 0 15px 1px rgb(0 112 209);">
                   <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: 0px; right: 8px;max-width: 118px" />
        <br/>
        <br/>
        <br/>
             <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
     <h3 class="fs-title" style="margin-top:-10px"><b>Cuentas En Cooperativas</b></h3>
         <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
          <div class="col-12">
             <div id="AgregarACC" style="position: absolute;margin-top: 5px; margin-left: 50px;">
             <a id="AgregarACC1" runat="server" href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarcuentascoope()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarACC" style="position: absolute;margin-top: 28px; margin-left: 50px;">
             <a id="GuardarACC1" runat="server"  href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarcuentascoope()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarACC" style="position: absolute;margin-top: 50px; margin-left: 50px;">
             <a  id="EliminarACC1" runat="server" href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarcuentascoope()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
	   
                <br/>
                <div style="overflow-x:auto; margin-top: -25px;" >
                    <div class="card-body">
                         <asp:DropDownList id="ACCNBanco1" style="max-width: 150px;margin-left: 157px;" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbinstitucionctacoope();" ></asp:DropDownList>
                         <asp:DropDownList id="ACCTMoneda1" style="max-width: 150px;" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbmonedactacoope();" ></asp:DropDownList>
                         <asp:DropDownList id="ACCEstatus1" style="max-width: 150px;" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbestatusctacoope();" ></asp:DropDownList>
                        
                        <select class="tampe" id="Select1" runat="server" style="max-width: 150px;margin-left: 157px;">
                            <option  value="0">[Tipo de cuenta]</option>
                            <option value="1">Aportaciones</option>
                            <option value="2">Ahorro</option>
                       </select>
                       <input id="ACCMonto" runat="server" type="number" class="tam" style="max-width: 150px;"  placeholder="Saldo en Cuenta" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                       <input id="ACCOFondos" runat="server" type="text" class="tam"  style="max-width: 150px;" placeholder="Origen Fondos" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                 <input id="Text14" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                 <hr class="solid" style="margin-top: 5px;" />
                    </div>
                </div>
                <div class="MostrarCooperativas">
                </div> 
   <div class="row">
        <div id="content4" class="col-lg-12">
            <div class="content"style="text-align: justify"><b>Usuario:</b> para poder guardar tus datos debes dar click en la la opción Guardar/Agregar. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:red"></i></div>
        </div>
    </div>
                  <%-- GRIDVIEW NUMEROS DE CUENTAS POR COBRAR --%>
              <div id="divGridcuentacooperativa" style="overflow: auto; height: 130px">
                 <asp:GridView ID="GridViewcuentascooperativa" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedcuentascooperativa" BorderStyle="Solid">
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
                         <asp:TemplateField HeaderText="Numero cuenta cooperativa" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lbltipocuentascooperativas" Text='<%# Eval("codeptipocuentacooperativa") %>' runat="server" />
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
                  <asp:TemplateField HeaderText="Tipo de cuenta">
                           <ItemTemplate>
                            <asp:Label ID="lbltipodecuentacoope" Text='<%# Eval("ep_tipocuentacooperativanombre") %>' runat="server" />
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
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarcooperativasgridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                  </div>
              <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
     <h3 class="fs-title" style="margin-top:-10px"><b>Cuentas Por Cobrar</b></h3>
        
         <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
          <div class="col-12">
              <div id="AgregarAP" style="position: absolute;margin-top: 5px; margin-left: 50px;">
             <a id="AgregarAP1" runat="server" href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarcuentasporcobrar()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarAP" style="position: absolute;margin-top: 28px; margin-left: 50px;">
             <a id="GuardarAP1" runat="server" href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarcuentasporcobrar()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarAP" style="position: absolute;margin-top: 50px; margin-left: 50px;">
             <a id="EliminarAP1" runat="server" href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarcuentasporcobrar()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
                <br/>

                <div style="overflow-x:auto;margin-top: -25px;" >
                    <div class="card-body">
                       <input id="ACPNombre" runat="server" type="text" class="tam" style="max-width:250px;margin-left: 212px;"  placeholder="Nombre persona o entidad" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="ACPMonto" runat="server" type="number" class="tam" style="max-width:150px;"  placeholder="Monto" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="ACPMotivo" runat="server" type="text" style="max-width: 403px;margin-left: 214px;"  placeholder="Motivo" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                         <input id="Text15" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                                         <%-- GRIDVIEW NUMEROS DE CUENTAS POR COBRAR --%>

                        <div id="divGridcuentasporcobrar" style="overflow: auto; height: 130px">
                 <asp:GridView ID="GridViewcuentasporcobrar" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedcuentasporcobrar" BorderStyle="Solid">
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
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarcuentaporcobrargridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                            </div>
                 <hr class="solid" style="margin-top: 5px;"/>
                
                    </div>
                </div>
                <div class="MostrarPorCobrar">
              </div>
             <h3 class="fs-title" style="margin-top: 0px;"><b>Inventarios</b></h3>
              <input id="Text5" runat="server" type="text" class="tam"   placeholder="Tipo de mercadería (especifique)" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
              <input id="Number1" runat="server" type="number" class="tam"   placeholder="Monto" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
</div>
    </div>
    <br/>
        <input type="button" name="previous" class="previous action-button" style="background-color: #0070D1" value="< Anterior" />
        <input type="button" name="next" class="next action-button" style="background-color: #0070D1" value="Siguiente >" />
    </fieldset>
    <fieldset id="septimof" style="box-shadow: 0 0 15px 1px rgb(0 112 209);">
           <h2 class="fs-title"><b>Inversiones</b></h2>
           <div class="col-12">
             <div id="AgregarBI11" style="position: absolute;margin-top: 2px; margin-left: 15px;">
             <a id="A1" runat="server" href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarinversion()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarBI11" style="position: absolute;margin-top: 25px; margin-left: 15px;">
             <a id="A2" runat="server"  href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarinversion()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarBI11" style="position: absolute;margin-top: 48px; margin-left: 15px;">
             <a id="A3" runat="server"  href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarinversiones()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
               </div>

           <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: -12px; right: 8px;max-width: 118px" />
            <asp:DropDownList  id="DropDownList2" runat="server" class="tampe" AutoPostBack="true" style="max-width: 200px;margin-left: 152px;" OnSelectedIndexChanged="tipoinstitucioninversion_SelectedIndexChanged" onchange="javascript:cmbtipoinstitucioninversion();" ></asp:DropDownList>              
            <asp:DropDownList  id="DropDownList3" runat="server" class="tampe" AutoPostBack="true" style="max-width:200px;" onchange="javascript:cmbtipoinstitucioninversion();"></asp:DropDownList>                     
           
        <input id="ACIPlazo" runat="server" type="text" class="tampe" style="max-width: 140px;"   placeholder="Plazo" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
        <asp:DropDownList id="ACIMoneda1" runat="server" class="tampe" style="max-width: 137px;margin-left: 150px;" AutoPostBack="true" onchange="javascript:cmbmonedainversiones();"  ></asp:DropDownList>
        <input id="ACIMonto" runat="server" type="text" class="tampe"  style="max-width: 125px;" placeholder="Monto" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
        <input id="ACIOrigeninv" runat="server" type="text" class="tampe"  style="max-width: 125px;" placeholder="Origen Fondos" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>  
        <input visible="false"  id="Text21" runat="server" type="text" class="tampe"  style="max-width: 164px;" placeholder="Monto" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
        
        <input id="Text24" runat="server" type="text" class="tampe"  style="max-width: 150px;" placeholder="No. Cuenta" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>  
        <label for="start" style="margin-left: 175px;">Fecha de Apertura</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
        <input class="tam" id="Date2" runat="server" style="margin-left: 66px;max-width: 270px;"  type="date"  value="2020-04-25" min="1950-01-01" max="2021-12-31" />   
          <div class="row">
        <div id="content4" class="col-lg-12">
            <div class="content"style="text-align: justify"><b>Usuario:</b> para poder guardar tus datos debes dar click en la la opción Guardar/Agregar. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:red"></i></div>
        </div>
    </div>
         <%-- GRIDVIEW Inversiones--%>
              <div id="divGridInversiones" style="overflow: auto; height: 130px" runat="server">
                 <asp:GridView ID="gridviewinversiones" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedinversiones" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Numero inversion" Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeroinversion" Text='<%# Eval("codepinversiones") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Numero tipo  institucion" Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotipoinstitucioninversion" Text='<%# Eval("codeptipoinstitucion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Numero institucion" Visible="false">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeroinstitucioninversion" Text='<%# Eval("codepinstitucion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Numero tipo moneda" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeromonedainversion" Text='<%# Eval("codeptipomoneda") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre tipo  Institución">
                           <ItemTemplate>
                            <asp:Label ID="lbltipoinstitucionnombre" Text='<%# Eval("ep_tipoinstitucionnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>    
                         <asp:TemplateField HeaderText="Nombre institucion">
                           <ItemTemplate>
                            <asp:Label ID="lblnombreinstitucion" Text='<%# Eval("ep_institucionnombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Moneda">
                           <ItemTemplate>
                            <asp:Label ID="lbltipomonedanombre" Text='<%# Eval("ep_tipomonedanombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Plazo">
                           <ItemTemplate>
                            <asp:Label ID="lblplazoinversion" Text='<%# Eval("ep_inversionesplazo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Monto">
                           <ItemTemplate>
                            <asp:Label ID="lblmontoinversion" Text='<%# Eval("ep_inversionesmonto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Origen de la inversión">
                           <ItemTemplate>
                            <asp:Label ID="lblorigeninversion" Text='<%# Eval("ep_inversionesorigen") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Numero de cuenta">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerodecuenta" Text='<%# Eval("ep_inversionesnumerocuenta") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarinversionesgridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                  </div>



        <hr class="solid" style="margin-top: 5px;" />
             <h2 class="fs-title"><b>Bienes Inmuebles</b></h2>
       <div class="col-12">
             <div id="AgregarBI" style="position: absolute;margin-top: 25px; margin-left: 50px;">
             <a id="AgregarBI1" runat="server" href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarbienesinmuebles()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarBI" style="position: absolute;margin-top: 48px; margin-left: 50px;">
             <a id="GuardarBI1" runat="server"  href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarbienesinmuebles()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarBI" style="position: absolute;margin-top: 72px; margin-left: 50px;">
             <a id="EliminarBI1" runat="server"  href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarbienesinmuebles()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
                <br/>
                <div style="overflow-x:auto; margin-top: -18px;">
                    <div class="card-body">


                <select class="tampe" id="Select2" runat="server" style="max-width:250px;margin-left: 220px;" >
                         <option disabled selected>[Presunción]</option>
                         <option value="1">Ajeno</option>
                         <option value="2">Propio</option>
                </select>
                       <asp:DropDownList id="ACTInmueble1" runat="server" class="tampe" style="max-width:150px" AutoPostBack="true"  onchange="javascript:cmbinmueble();" ></asp:DropDownList>
                       <input id="ACFinca" runat="server" type="text" class="tampe" style="max-width:150px;margin-left: 215px;"   placeholder="Finca" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>                      
                       <input id="ACFolio" runat="server" type="text" class="tampe" style="max-width:150px;"   placeholder="Folio" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                       <input id="ACLibro" runat="server" type="text" class="tampe" style="max-width:150px;"  placeholder="Libro" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                        <input id="ACDireccion" runat="server" type="text" class="tampe" style="max-width:150px;margin-left: 215px;"   placeholder="Direccion" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                       <input id="ACVActual" runat="server" type="text" class="tampe" style="max-width:150px;"  placeholder="Valor Actual" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="ACDes" runat="server" type="text" class="tampe" style="max-width:150px;" placeholder="Comentario" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="ACcomentarioinmueble" runat="server" type="text" class="tampe" style="max-width:150px;" placeholder="Comentario" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" hidden/>
                        <input id="Text16" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                              <%-- GRIDVIEW NUMEROS DE BIENES INMUEBLES --%>
                        <div id="divGridbienesinmueble" style="overflow: auto; height: 130px">
                 <asp:GridView ID="GridViewbienesinmuebles" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedbienesinmuebles" BorderStyle="Solid">
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
                                <asp:TemplateField HeaderText="Finca">
                           <ItemTemplate>
                            <asp:Label ID="lblinmueblefinca" Text='<%# Eval("ep_inmueblefinca") %>' runat="server" />
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
                 <asp:TemplateField HeaderText="Comentario">
                           <ItemTemplate>
                            <asp:Label ID="lblcomentarioinmueble" Text='<%# Eval("ep_inmueblecomentario") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarbienesinmueblesgridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                            </div>
                        <hr class="solid" style="margin-top: 5px;"/>         
                        </div>
                </div>
        </div>
             <h2 class="fs-title" style="margin-top: 3px;"><b>Vehículos</b></h2>
       <div class="col-12">
             <div id="AgregarV" style="position: absolute;margin-top: 67px; margin-left: 50px;">
             <a id="AgregarV1" runat="server" href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarvehiculos()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarV" style="position: absolute;margin-top: 95px; margin-left: 50px;">
             <a id="GuardarV1" runat="server"  href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarvehiculos()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarV" style="position: absolute;margin-top: 122px; margin-left: 50px;">
             <a id="EliminarV1" runat="server"  href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarvehiculos()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
                <br/>
       
                <div style="overflow-x:auto;margin-top: -16px;">
                    <div class="card-body">
                           <label for="start">El vehículo se encuentra a su nombre:</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
	                <b>Si</b><input name="intereses" type="radio" class="tampe" value="rbforaneo" style="margin-left: -63px;" onclick="Activarr()" id="Radio1" runat="server" />
	                <b>No</b><input name="intereses" type="radio" class="tampe" value="rblocal" style="margin-left: -63px;" onclick="Desactivarr()" id="Radio2" runat="server" />

                       <asp:DropDownList id="ACTVehiculo1" runat="server" class="tampe" style="max-width:150px;margin-left: 237px;" AutoPostBack="true" disabled  onchange="javascript:cmbvehiculo();" ></asp:DropDownList>
                       <input id="ACMarca" runat="server" type="text" class="tampe"  style="max-width:150px;"  placeholder="Marca" maxlength="100" disabled oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="ACLinea" runat="server" type="text" class="tampe" style="max-width:150px;"   placeholder="Linea" maxlength="100" disabled oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="ACModelo" runat="server" type="text" class="tam"  style="max-width:150px;margin-left: 237px;"  placeholder="Modelo" disabled maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                       <input id="ACPlaca" runat="server" type="text" class="tam"  style="max-width:150px;"  placeholder="No. Placa" maxlength="100" disabled oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="ACCome" runat="server" type="text" class="tam"  style="max-width:150px;"  placeholder="Comentarios" maxlength="100" disabled oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="Text17" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion"  disabled maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="Text27" runat="server" type="number" class="tam"  style="max-width: 236px; margin-left: 235px;" placeholder="Valor" maxlength="10" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                         
                        
                       <input id="Text25" runat="server" type="text" class="tam"  style="max-width: 236px; margin-left: 235px;" disabled placeholder="A nombre de quien se encuentra" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                       <input id="Text26" runat="server" type="text" class="tam"  style="max-width:225px;"  placeholder="Motivo/comentario" disabled  maxlength="100"  oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
 
                        
                        <%-- GRIDVIEW NUMEROS DE VEHICULOS --%>
                        <div id="divGridvehiculos" style="overflow: auto; height: 130px">
                 <asp:GridView ID="GridViewvehiculos" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedvehiculos" BorderStyle="Solid">
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
                           <asp:TemplateField HeaderText="Línea">
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
    <asp:TemplateField HeaderText="Comentario">
                           <ItemTemplate>
                            <asp:Label ID="lblcomentario" Text='<%# Eval("ep_vehiculocomentario") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                            <asp:TemplateField HeaderText="A quien esta">
                           <ItemTemplate>
                            <asp:Label ID="lblaquienesta" Text='<%# Eval("ep_vehiculoanombrede") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Motivo">
                           <ItemTemplate>
                            <asp:Label ID="lblmotivo" Text='<%# Eval("ep_vehiculomotivodeanombrede") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                <asp:TemplateField HeaderText="Monto">
                           <ItemTemplate>
                            <asp:Label ID="lblmonto" Text='<%# Eval("ep_vehiculomonto") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarvehiculosgridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                            </div>
                        <hr class="solid" style="margin-top: 5px;" />
                    </div>
                </div>
                <div class="MostrarVehiculos">
              </div>
        </div>
        
            <br/>
        <input type="button" name="previous" class="previous action-button" style="background-color: #0070D1" value="< Anterior" />
        <input type="button" name="next" class="next action-button" style="background-color: #0070D1" value="Siguiente >" />
    </fieldset>
    <fieldset id="octavof" style="box-shadow: 0 0 15px 1px rgb(0 112 209);">
           <h2 class="fs-title"><b>Maquinaria y Equipo</b></h2>
           <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: -11px; right: 8px;max-width: 118px" />
             <input id="ACTMAquinaria" runat="server" type="text" class="tam"   placeholder="Tipo de Maquinaria" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
             <input id="Number2" runat="server" type="number" class="tam"   placeholder="Valor actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
             <input id="ACComentarios" runat="server" type="text"    placeholder="Especifique" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
            <hr class="solid" style="margin-top: 5px;"/>
             <h2 class="fs-title"><b>Menaje (Bienes en su casa)</b></h2>
        <label for="start">Equipo de Cómputo</label>&nbsp;&nbsp;&nbsp;
        <label>Q</label>
        <input id="ACMEComputo" runat="server" type="number" class="tam"   placeholder="Valor Actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br />
        <label for="start">Amueblado Sala</label>&nbsp;&nbsp;&nbsp;
        <input id="ACMASala" runat="server" type="number" class="tam"  style="margin-left: 21px;" placeholder="Valor Actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
        <br />
        <label for="start">Amueblado Comedor</label>&nbsp;&nbsp;&nbsp;
        <input id="ACMAComedor" runat="server" type="number" class="tam"  style="margin-left: -7px;" placeholder="Valor Actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>

        <b style="margin-left: 91px;">Cantidad</b>
        <b style="margin-left: 110px;">Valor</b>
        <br />
        <label for="start" class="tampes">Televisor </label>&nbsp;&nbsp;&nbsp;
        <input id="ACMATelevisorC"  runat="server" type="number" class="tampes"  style="margin-left: 47px;width:20.5%"  placeholder="Cantidad" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <label >Q</label>
        <input id="ACMATelevisorV" style="width:20.5%" runat="server" type="number" class="tampes"   placeholder="Valor Actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
        <label for="start" class="tampes">Equipo de Sonido</label>&nbsp;&nbsp;&nbsp;
        <input id="ACMASonidoC"  runat="server" type="number" class="tampes"  style="margin-left: -10px;width:20.5%" placeholder="Cantidad" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
        <label >Q</label>
        <input id="ACMASonidoV" style="width:20.5%" runat="server" type="number" class="tampes"   placeholder="Valor Actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" /> 
        <br/>
        <label for="start" class="tampes">Lavadora</label>&nbsp;&nbsp;&nbsp;
        <input id="ACMALavadoraC"  runat="server" type="number" class="tampes" style="margin-left: 47px;width:20.5%"  placeholder="Cantidad" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <label >Q</label>
        <input id="ACMALavadoraV" style="width:20.5%" runat="server" type="number" class="tampes"   placeholder="Valor Actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
        <label for="start" class="tampes">Secadora</label>&nbsp;&nbsp;&nbsp;
        <input id="ACMASecadoraC"  runat="server" type="number" class="tampes"  style="margin-left: 47px;width:20.5%" placeholder="Cantidad" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <label >Q</label>
        <input id="ACMASecadoraV" style="width:20.5%" runat="server" type="number" class="tampes"   placeholder="Valor Actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
        <label for="start" class="tampes">Estufa</label>&nbsp;&nbsp;&nbsp;
        <input id="ACMAEstufaC" runat="server" type="number" class="tampes" style="margin-left: 68px;width:20.5%"  placeholder="Cantidad" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <label >Q</label>
        <input id="ACMAEstufaV" style="width:20.5%" runat="server" type="number" class="tampes"   placeholder="Valor Actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
        <label for="start" class="tampes">Refrigeradora</label>&nbsp;&nbsp;&nbsp;
        <input id="ACMARefrigeradoraC"  runat="server" type="number" class="tampes" style="margin-left: 20px;width:20.5%"  placeholder="Cantidad" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <label >Q</label>
        <input id="ACMARefrigeradoraV" style="width:20.5%" runat="server" type="number" class="tampes"   placeholder="Valor Actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
        <br/>
        <label for="start" class="tampes">Teléfono Móvil</label>&nbsp;&nbsp;&nbsp;
        <input id="ACMATMovilC"  runat="server" type="number" class="tampes" style="margin-left: 16px;width:20.5%"  placeholder="Cantidad" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
        <label >Q</label>
        <input id="ACMATMovilV" style="width:20.5%" runat="server" type="number" class="tampes"   placeholder="Valor Actual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
       <%--<br /> <label for="start" class="tampes">Otros </label>&nbsp;&nbsp;&nbsp;--%>
        <br/>
        
        
         <hr class="solid" style="margin-top: 5px;"/>
             <h2 class="fs-title"><b>Otros Activos (Cosechas,Ganados,etc)</b></h2>
        
        <label for="start" class="tampes">Otros </label>&nbsp;&nbsp;&nbsp;
        <input id="ACMAODes" runat="server" type="text" class="tampes" style="margin-left: 75px;"  placeholder="Descripcion" />
        <input id="ACMACantidadO" runat="server" type="number" class="tampes"   placeholder="Cantidad" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
            
        <label for="start" class="tampes">Fondo de retiro FENAFORE</label>&nbsp;&nbsp;&nbsp;
        <%--<input id="FenaDes" runat="server" type="text" class="tampes" style="margin-left: 0px;"  placeholder="Inversión fondo de retiro FENAFORE" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        --%><input id="FenaVal" runat="server" type="number" class="tampes"   placeholder="Saldo en Q y/o $" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
           
        <hr class="solid" style="margin-top: 5px;"/>
            <br/>
    <div class="row">
        <div style="" class="col-lg-12">
             <div class="content" style="text-align: justify;background-color:#69a43c;height: 125px;width: 30%;    margin-top: -98px;    margin-left: -268px;"><b>Usuario:</b> Debes dar en Guardar para que tus datos se almacenen en el sistema y poder pasar a la siguiente seccion. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:#003563"></i></div>
         </div>
    </div>
        <input runat="server" type="button" name="guardar" class="next action-button" value="Guardar" id="btnfinalactivo" onclick="btnguardaractivo()" /> 
        <input type="button" name="previous" class="previous action-button" style="background-color: #0070D1" value="< Anterior" />
        <input type="button" name="next" runat="server" id="buton2" class="next action-button" style="background-color: #0070D1" value="Siguiente >" />
    </fieldset>
<!--  Fin Area de Formulario de Activos y sus 4 Secciones  -->
<!--  Area Pasivo y sus 2 Secciones    -->
    <fieldset id="novenof"  style="box-shadow: 0 0 15px 1px rgb(0 175 235);">
        <h2 class="fs-title"><b>Pasivo</b></h2>
           <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: 0; right: 8px;max-width: 118px" />
        <br/>
         <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
     <h3 class="fs-title" style="margin-top:-10px"><b>Cuentas Por Pagar </b></h3>
         <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
        <asp:DropDownList id="TipoCuenta" style="max-width: 160px;margin-left: 135px;" runat="server"  AutoPostBack="true" onchange="javascript:cmbtiplazo();" ></asp:DropDownList>
        <input id="PCPDes1" runat="server" type="text" class="tampes"   placeholder="Descripcion" maxlength="100" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <input id="PCPMonto1" runat="server" type="number" class="tampes"   placeholder="Monto en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <input id="Text18" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />   
        <div id="AgregarPC" style="position: absolute;margin-top: -64px; margin-left: 10px;">
        <a id="AgregarPC1" runat="server" href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarcuentasporpagar()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarPC" style="position: absolute;margin-top: -45px; margin-left: 10px;">
             <a id="GuardarPC1" runat="server"  href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarcuentasporpagar()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarPC" style="position: absolute;margin-top: -26px; margin-left: 10px;">
             <a id="EliminarPC1" runat="server"   href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarcuentasporpagar()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
        <br/>
   <div class="row">
        <div id="content4" class="col-lg-12">
            <div class="content"style="text-align: justify"><b>Usuario:</b> para poder guardar tus datos debes dar click en la la opción Guardar/Agregar. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:red"></i></div>
        </div>
    </div>
             <%-- GRIDVIEW NUMEROS DE CUENTAS POR PAGAR --%>
        <div id="divGridcuentasporpagar" style="overflow: auto; height: 130px">
                 <asp:GridView ID="GridViewcuentasporpagar" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedcuentasporpagar" BorderStyle="Solid">
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
                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarcuentasporpagargridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
            </div>
      <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
     <hr class="solid" style="margin-top: 5px;"/>
             <h3 class="fs-title" style="margin-top:-10px"><b>Préstamos</b></h3>
        <br/>
          <div class="col-12">
               <div id="AgregarPP" style="position: absolute;margin-top: 0px; margin-left: 50px;">
             <a id="AgregarPP1" runat="server" href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregarprestamos()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarPP" style="position: absolute;margin-top: 23px; margin-left: 50px;">
             <a id="GuardarPP1" runat="server"  href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="modificarprestamos()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarPP" style="position: absolute;margin-top: 45px; margin-left: 50px;">
             <a id="EliminarPP1" runat="server"  href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminarprestamos()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>
                <br/>
                <div style="overflow-x:auto;margin-top: -30px;">
                    <div class="card-body">

           <asp:DropDownList id="PTPrestamo1" runat="server"  style="max-width:150px;margin-left: 214px;" class="" AutoPostBack="true" onchange="javascript:cmbtipoprestamo();"></asp:DropDownList>
          <asp:DropDownList  id="PNEntidad1" runat="server" class="tampe" AutoPostBack="true" style="max-width:150px;" OnSelectedIndexChanged="PNEntidad1_SelectedIndexChanged" onchange="javascript:cmbtipoinstitucion();" ></asp:DropDownList>              
            <asp:DropDownList  id="PNPNEntidadnombre1" runat="server" class="tampe" AutoPostBack="true" style="max-width:150px;" onchange="javascript:cmbtipoinstitucion();"></asp:DropDownList>                     
           <input id="PMInicial" runat="server" type="number" style="max-width: 150px;    margin-left: 213px;" class="tampe"   placeholder="Monto Inicial" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
           <input id="PSActual" runat="server" type="number" style="max-width: 150px;" class="tampe"   placeholder="Saldo Actual" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
           <input id="PFDestino" runat="server" type="text" style="max-width: 150px;" class="tampe"   placeholder="Destino" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
            <input id="Text19" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />   

                <label for="start" style="margin-left: -18px;">Fecha Desembolso</label>
                <input id="Datedesembolso" runat="server" class="tam" type="date" style=" max-width: 144px;" name="trip-start" value="2018-07-22" min="1950-01-01" max="2021-12-31" />
          &nbsp;&nbsp; <label for="start">Fecha Finalización</label>
               <input id="Datefinalizacion" runat="server" class="tam" style=" max-width: 144px;" type="date"  name="trip-start" value="2018-07-22" min="1950-01-01" max="2021-12-31" />
             <%-- GRIDVIEW NUMEROS DE PRESTAMOS --%>
                        <div id="divGridprestamos" style="overflow: auto; height: 130px">
                 <asp:GridView ID="GridViewpasivos"  CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedpasivos" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Número préstamo" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumeroprestamo" Text='<%# Eval("codepprestamo") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Número Tipo préstamo" Visible="False">
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
                           <asp:TemplateField HeaderText="Tipo de préstamo">
                           <ItemTemplate>
                            <asp:Label ID="lbltipoprestamo" Text='<%# Eval("ep_tipoprestamonombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Tipo de institución">
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


                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionarprestamogridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                            </div>
                        <hr class="solid" style="margin-top: 5px;"/>
                    </div>
                </div>
                </div> 
    <br/>
        <input type="button" name="previous" class="previous action-button" style="background-color: #00AFEB" value="< Anterior" />
        <input type="button" name="next" class="next action-button" style="background-color: #00AFEB" value="Siguiente >" />
    </fieldset>
    <fieldset id="decimof"  style="box-shadow: 0 0 15px 1px rgb(0 175 235);">
        <h2 class="fs-title"><b>Tarjeta de Crédito</b></h2>
           <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: 0; right: 8px;max-width: 118px" />
        <br/>

     
          <div class="col-12">
               <div id="AgregarTC" style="position: absolute;margin-top: 0px; margin-left: 50px;">
             <a id="AgregarTC1" runat="server" href="javascript:void(0);" class="Inmuebles" title="Add field" onclick="agregartarjetacredito()">
                 <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Guardar/Agregar
             </a>
       </div>
        <div id="GuardarTC" style="position: absolute;margin-top: 25px; margin-left: 50px;">
             <a id="GuardarTC1" runat="server" href="javascript:void(0);"  class="Inmuebles" title="Add field"  onclick="modificartarjetacredito()">
                 <i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Actualizar
             </a>
       </div>
        <div  id="EliminarTC" style="position: absolute;margin-top: 50px; margin-left: 50px;">
             <a id="EliminarTC1" runat="server" href="javascript:void(0);"  class="Inmuebles" title="Add field" onclick="eliminartarjetacredito()">
                 <i class="fa fa-close" aria-hidden="true"></i>&nbsp;Eliminar
             </a>
       </div>

                <br/>
                <div style="overflow-x:auto;    margin-top: -28px;">
                    <div class="card-body">
                   <asp:DropDownList style="max-width: 250px;margin-left: 120px; margin-left: 166px;" id="PTTEntidad1" runat="server" class="tampe" AutoPostBack="true" OnSelectedIndexChanged="PTTEntidad1_SelectedIndexChanged" onchange="javascript:cmbtipoprestamotarjeta();" ></asp:DropDownList>
                   <asp:DropDownList style="max-width: 250px;" id="PTTNombre1" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbnombreprestamotarjeta();" ></asp:DropDownList>
              
                   <input id="PTTLimite" runat="server" style="max-width:150px;margin-left: 167px;" type="number" class="tampe"   placeholder="Limite en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                   <input id="PTTLimite2" runat="server" style="max-width:150px;" type="number" class="tampe"   placeholder="Limite en $" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                   <input id="PTTSaldo" runat="server" style="max-width:150px;" type="number" class="tampe"   placeholder="Saldo Actual" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                   <input id="Text20" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"   placeholder="Religion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                      
    
                        <%-- GRIDVIEW NUMEROS DE TARJETAS --%>
                      <div id="divGridtarjetas" style="overflow: auto; height: 130px">
                 <asp:GridView ID="GridViewtarjetas" CssClass="mGrid" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False" OnSelectedIndexChanged = "OnSelectedIndexChangedtarjetas" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField HeaderText="Número de tarjeta" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotarjeta" Text='<%# Eval("codeptrajetadecredito") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Tipo institucion" Visible="False">
                           <ItemTemplate>
                            <asp:Label ID="lblnumerotipoinstituciontarjeta" Text='<%# Eval("codeptipoinstitucion") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="ID institucion">
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

                            <asp:ButtonField Text="Seleccionar" ItemStyle-CssClass="seleccionartarjetasgridview fa-check-circle" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="150px"></ItemStyle>
                             </asp:ButtonField>
                     </Columns>
<HeaderStyle BackColor="#3AC0F2" CssClass="prueba" ForeColor="White"></HeaderStyle>
        </asp:GridView>
                            </div>
                    <hr class="solid" style="margin-top: 5px;"/>
                           <h2 class="fs-title"><b>Otras Deudas</b></h2>
                           <input id="PODeudas" runat="server"  type="text" class="tam"   placeholder="Especifique" maxlength="200"  />
                           <input id="POMonto" runat="server" type="number" class="tampe"   placeholder="Monto" maxlength="20" />
                
                    <hr class="solid" style="margin-top: 5px;" />
                           <h2 class="fs-title"><b>Pasivo Contingente</b></h2>
                           <input id="PTNEntidad" runat="server"  type="text" class="tam"   placeholder="Nombre Entidad" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                           <input id="PTNDeudor" runat="server"   type="text" class="tam"   placeholder="Nombre Deudor" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                           <input id="PTRelacion" runat="server"  type="text" class="tam"   placeholder="Relacion con Deudor" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                           <input id="PTSaldo" runat="server"  type="number" class="tam"   placeholder="Saldo en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
     
                 
                       
                     
                    </div>
                        <label for="start" style="margin-left: -18px;">Fecha Desembolso</label>&nbsp;&nbsp;                    
                       <input id="fechadembolso" runat="server"  class="tampe" style="max-width:150px;"  type="date"  name="trip-start" value="2020-04-24" min="1950-01-01" max="2021-12-31" />
                        &nbsp; &nbsp; <label for="start">Fecha Finalización</label>&nbsp;&nbsp;                        
                        <input id="fechafinalizacion" runat="server" class="tampe" style="max-width:150px;" type="date"  name="trip-start" value="2020-04-24" min="1950-01-01" max="2021-12-31" />
                 <hr class="solid" style="margin-top: 5px;"/>
                </div>
                <div class="MostrarCooperativas">
                </div> 
    </div>
    <br/>
         <div class="row">
        <div style="" class="col-lg-12">
           <div class="content" style="text-align: justify;background-color:#69a43c;height: 125px;width: 30%;    margin-top: -98px;    margin-left: -268px;"><b>Usuario:</b> Debes dar en Guardar para que tus datos se almacenen en el sistema y poder pasar a la siguiente seccion. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:#003563"></i></div>
         </div>
    </div>
        <input type="button" runat="server" name="guardar" class="next action-button" value="Guardar" onclick="guardarepfinalpasivos()" id="btnguardarpasivo"/>
        <input type="button" name="previous" class="previous action-button" style="background-color: #00AFEB" value="< Anterior" />
        <input type="button" name="next" runat="server" id="buton3" class="next action-button" style="background-color: #00AFEB" value="Siguiente >" />
    </fieldset>
<!--  Fin Area Pasivos y sus 2 Secciones  -->
<!--  Area Ingresos y Egresos y sus 2 Secciones    -->
    <fieldset  id="onceavof" style="box-shadow: 0 0 15px 1px rgb(0 228 235);">
        <h2 class="fs-title"><b>Ingresos</b></h2>
           <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: 0; right: 8px;max-width: 118px" />
        <br/>
            <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
          <label for="start">Ingresos Mensuales en la Cooperativa Guadalupana</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <br />
                 <input id="ISBase" runat="server" type="number" class="tampe"   placeholder="Sueldo Base" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
                 <input id="IBoni" runat="server" type="number" class="tampe"   placeholder="Bonificaciones" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
                 <input id="ICMensuales" runat="server" type="number" class="tampe"   placeholder="Comisiones Mensuales" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
           <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
          <label for="start">Tiene negocio propio:</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
	<b>Si</b><input name="intereses1" type="radio" class="tampe" value="rbforaneo" style="margin-left: -63px;" onclick="Activar()" id="rdbsinegociopropio" runat="server" />
	<b>No</b><input name="intereses1" type="radio" class="tampe" value="rblocal" style="margin-left: -63px;" onclick="Desactivar()" id="rdbnonegociopropio" runat="server" checked />


            <select class="tampe" id="ITNegocio" runat="server" >
                         <option disabled selected>[Tipo de Negocio]</option>
                         <option value="1">Informal</option>
                         <option value="2">Formal</option>
                </select>
	<%--<input id="ITNegocio" runat="server" type="text" class="tampe"   placeholder="Tipo de Negocio" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />--%>
	<input id="ITNNegocio" runat="server" type="text" class="tampe"   placeholder="Nombre Negocio" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
	<input id="ITpatente" runat="server" type="text" class="tampe"   placeholder="No. Patente" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
	<input id="ITNEmpleados" runat="server" type="number" class="tampe"   placeholder="No. Empleados" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
	<input id="ITONegocio" runat="server" type="text" class="tampe"   placeholder="Objeto del Negocio" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
	<input id="ITIMensuales" runat="server" type="number" class="tampe"   placeholder="Ingresos Mensuales" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
	<input id="ITEMensuales" runat="server" type="number" class="tampe"   placeholder="Egresos Mensuales" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
	<input id="ITDireccion" runat="server" type="text" class="tam"   placeholder="Direccion" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
  <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;" />
          <label for="start">Remesas:</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
	<b>Si</b><input name="intereses" type="radio" class="tampe" value="rbforaneo" style="margin-left: -63px;" onclick="Activar1()" id="rdbsiRemesas" runat="server" />
	<b>No</b><input name="intereses" type="radio" class="tampe" value="rblocal" style="margin-left: -63px;" onclick="Desactivar1()" id="rdbnoRemesas" runat="server" checked />
            <br/>
    <input id="ISRNombre" runat="server" type="text" class="tam"   placeholder="Nombre Remitente" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
    <input id="ISRRelacion" runat="server" type="text" class="tam"   placeholder="Relacion Remitente" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
    <input id="ISRMonto" runat="server" type="number" class="tam"   placeholder="Promedio Mensual en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
    <asp:DropDownList  class="tampe" id="ISRPeriodo" runat="server">
           <asp:ListItem Value="0">[Periodo Recepción]</asp:ListItem>
        <asp:ListItem Value="1">Diario</asp:ListItem>
        <asp:ListItem Value="2">Semanual</asp:ListItem>
        <asp:ListItem Value="3">Mensual</asp:ListItem>
        <asp:ListItem Value="4">Trimestral</asp:ListItem>
        <asp:ListItem Value="5">Semestral</asp:ListItem>
          <asp:ListItem Value="6">Anual</asp:ListItem>
    </asp:DropDownList>
        
        <hr class="solid" style="margin-top: 5px;"/>
    <br/>
        <input type="button" name="previous" class="previous action-button" style="background-color: #00AFEB" value="< Anterior" />
        <input type="button" name="next" class="next action-button" style="background-color: #00AFEB" value="Siguiente >" />
    </fieldset>
    <fieldset id="doceavof" style="box-shadow: 0 0 15px 1px rgb(0 228 235);">
        <h2 class="fs-title"><b>Egresos</b></h2>
           <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="position: absolute; top: 0; right: 8px;max-width: 118px" />
        <br/>
          <label for="start">Alimentación</label>&nbsp;&nbsp;&nbsp;
        <input id="ITAlimen" runat="server" type="number" class="tampe"  style="margin-left: -7px;" placeholder="Valor en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
         <label for="start" style="margin-left: -57px;">Transporte o Gasolina</label>&nbsp;&nbsp;&nbsp;
        <input id="ITTras" runat="server" type="number" class="tampe"  style="margin-left: -7px;" placeholder="Valor en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
        <label for="start">Pago Estudios</label>&nbsp;&nbsp;&nbsp;
        <input id="ITPago" runat="server" type="number" class="tampe"  style="margin-left: -7px;" placeholder="Valor en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
        <label for="start" style="margin-left: 26px;">Préstamos</label>&nbsp;&nbsp;&nbsp;
        <input id="ITPrestamos" runat="server" type="number" class="tampe"  style="margin-left: -7px;" placeholder="Valor en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/> 
        <label for="start" style="margin-left: -20px;">Tarjeta de Crédito</label>&nbsp;&nbsp;&nbsp;
        <input id="ITTarjeta" runat="server" type="number" class="tampe"  style="margin-left: -7px;" placeholder="Valor en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
        <label for="start" style="margin-left: 35px;">Vestuario</label>&nbsp;&nbsp;&nbsp;
        <input id="ITVestuario" runat="server" type="number" class="tampe"  style="margin-left: -7px;" placeholder="Valor en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
        <label for="start" style="margin-left: 23px;">Recreación</label>&nbsp;&nbsp;&nbsp;
        <input id="ITRecreacion" runat="server" type="number" class="tampe"  style="margin-left: -7px;" placeholder="Valor en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>
        <label for="start" style="margin-left: 2px;">Otros Egresos</label>&nbsp;&nbsp;&nbsp;
        <input id="ITOtros" runat="server" type="number" class="tampe"  style="margin-left: -7px;" placeholder="Valor en Q" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <br/>

  <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
          <label for="start">Es usted una Persona Expuesta Políticamente (PEP):</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
        <br/>
	<b>Si</b><input name="intereses2" type="radio" class="tampe" value="rbforaneo" style="margin-left: -63px;" onclick="Activar11()" id="rdbsiinteres" runat="server" />
	<b>No</b><input name="intereses2" type="radio" class="tampe" value="rblocal" style="margin-left: -63px;" onclick="Desactivar11()" id="rdbnointeres" runat="server" checked />
            <br/>
    <input id="ENIns" runat="server" type="text" class="tampe"   placeholder="Nombre Institucion" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
    <input id="EPuesto" runat="server" type="text" class="tampe"   placeholder="Puesto" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
    <input id="EPais" runat="server" type="text" class="tampe"   placeholder="Pais de la Institucion" maxlength="20" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
        <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
         
    <label for="start">Tiene usted algún parentesco con una Persona Expuesta Políticamente (PEP):</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
	<br /><b>Si</b><input name="intereses4" type="radio" class="tampe" value="rbforaneo" style="margin-left: -63px;" onclick="Activar111()" id="rdbsipep" runat="server" />
	<b>No</b><input name="intereses4" type="radio" class="tampe" value="rblocal" checked style="margin-left: -63px;" onclick="Desactivar111()" id="rdbnopep" runat="server" />
       <br /> 
        <asp:DropDownList id="EParentesco1" runat="server" class="tampe"  AutoPostBack="true" onchange="javascript:cmbnacionalidad1();" ></asp:DropDownList>
        <asp:DropDownList id="Modalidad1" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbparentesco1();"  ></asp:DropDownList>
        <input id="Text8" runat="server" type="text" class="tampe"   placeholder="Nombre Completo" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <input id="Text9" runat="server" type="text" class="tampe"   placeholder="Nombre Institucion" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <input id="Text10" runat="server" type="text" class="tampe"   placeholder="Puesto" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <input id="Text11" runat="server" type="text" class="tampe"   placeholder="Pais" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
        
        <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
        <label for="start">Es usted asociado cercano de una Persona Expuesta Políticamente (PEP):</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
	<br /><b>Si</b><input name="intereses3" type="radio" class="tampe" value="rbforaneo" style="margin-left: -63px;" onclick="Activar1111()" id="rdbsiasociadopep" runat="server" />
	<b>No</b><input name="intereses3" type="radio" class="tampe" value="rblocal" style="margin-left: -63px;" onclick="Desactivar1111()"  id="rdbnoasociadopep" runat="server" checked/>
        <br/>
        <asp:DropDownList id="EParentesco2" runat="server" class="tampe" AutoPostBack="true" onchange="javascript:cmbnacionalidad2();"></asp:DropDownList>
        <asp:DropDownList id="Modalidad2" runat="server" class="tampe" AutoPostBack="true"  onchange="javascript:cmbparentesco2();" ></asp:DropDownList>
        <input id="EMotivos" runat="server" type="text" class="tampe"   placeholder="Motivos" maxlength="200" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"/>
        <input id="ENombres" runat="server" type="text" class="tampe"   placeholder="Nombre Completo" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <input id="EINombre" runat="server" type="text" class="tampe"   placeholder="Nombre Institucion" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <input id="EIPuesto1" runat="server" type="text" class="tampe"   placeholder="Puesto" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
        <input id="EPPais1" runat="server" type="text" class="tampe"   placeholder="Pais" maxlength="50" oninput="if(this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" />
            <br/>
   <hr class="solid" style="margin-top: 5px;border-top: 2px solid #69a43c;"/>
        <label for="start">Es usted Contratista y Proveedores del Estado (CPE):</label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
         <asp:DropDownList id="Dropdownlist23" runat="server" class="tampe"  AutoPostBack="true" onchange="javascript:cmbproveedordelestado();" >
             <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>  
             <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="2"></asp:ListItem>
         </asp:DropDownList>
       
        <br/>
              <hr class="solid" style="margin-top: 5px;"/>
    <br/>
        <div class="row">
        <div style="" class="col-lg-12">
            <div class="content" style="text-align: justify;background-color:orangered"><b>Usuario:</b>Al dar click en Terminar,tus datos se guardarán y ya no se podran Modificar. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="fa fa-mail-forward" style="font-size:25px;color:#003563"></i></div>
        </div>
    </div>
        <input type="button" name="previous" class="previous action-button" style="background-color: #00AFEB" value="< Anterior" />
        <input type="button" runat="server" name="guardar" class="next action-button" value="Terminar" onclick="guardarepfinalyenviado()" id="btnguardaringreso" />
    </fieldset>
<!--  Fin Area Ingresos y Egresos y sus 2 Secciones  -->
<!-- FUNCIONES DE CARGA -->
    <asp:LinkButton ID="combosucursal" runat="server" OnClick="cbosucursal_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="comboarea" runat="server" OnClick="cboarea_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combodepartamento" runat="server" OnClick="cbodepartamento_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combomunicipio" runat="server" OnClick="cbomunicipio_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combozona" runat="server" OnClick="cbozona_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combotipodoc" runat="server" OnClick="cbotipodoc_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="comboestadocivil" runat="server" OnClick="cboestadocivil_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combotipotelefono" runat="server"  OnClick="cbotipotelefono_Click" ClientIDMode="Static"></asp:LinkButton>

    <asp:LinkButton ID="combotipomoneda1" runat="server" OnClick="cbotipomoneda1_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combotipomoneda3" runat="server" OnClick="cbotipomoneda3_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combotipomoneda4" runat="server" OnClick="cbotipomoneda4_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combotipoestatus1" runat="server" OnClick="cbotipoestatus1_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combotipoestatus3" runat="server" OnClick="cbotipoestatus3_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combotipoinmueble" runat="server" OnClick="cbotipoinmueble_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="combotipovehiculo" runat="server" OnClick="cbotipovehiculo_Click" ClientIDMode="Static"></asp:LinkButton>


    <asp:LinkButton ID="btnguardaryenviar" runat="server" OnClick="btnguardarepfinyenviar_Click" ClientIDMode="Static"></asp:LinkButton>
    <%-- FORMULARIO FINAL --%>
    <asp:LinkButton ID="btnguardainfogeneral" runat="server" OnClick="btnepguardarinfogeneral_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="guardarepfinalpasivos1" runat="server" OnClick="guardarepfinalpasivos1_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btnguardaractivo" runat="server" OnClick="btnguardaractivo_Click" ClientIDMode="Static"></asp:LinkButton>

    <%-- BOTONES DE GUARDAR GRIDVIEW --%>
    <asp:LinkButton ID="btnguardarcelular" runat="server" OnClick="btnguardarcelular1_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="btnguardarhijos" runat="server" OnClick="btnguardarhijos_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btnguardarestudios" runat="server" OnClick="btnguardarestudios_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="btnguardarcuenta" runat="server" OnClick="btnguardarcuenta_Click" ClientIDMode="Static"></asp:LinkButton>
      <asp:LinkButton ID="btnguardarinversiones" runat="server" OnClick="btnguardarinversiones_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btnguardarestudiosuni" runat="server" OnClick="btnguardarestudiosuni_Click" ClientIDMode="Static"></asp:LinkButton>

        <%-- BOTONES DE GUARDAR GRIDVIEW --%>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnguardarcelular1_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btnguardarhijos_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnguardarestudios_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnguardarcuenta_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btnguardarcuentascoope" runat="server" OnClick="btnguardarcuentascoope_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btnguardarcuentasporcobrar" runat="server" OnClick="btnguardarcuentasporcobrar_Click" ClientIDMode="Static"></asp:LinkButton>
 <asp:LinkButton ID="btnguardarbienesinmuebles" runat="server" OnClick="btnguardarbienesinmuebles_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btnguardarvehiculos" runat="server" OnClick="btnguardarvehiculos_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btnagregarcuentasporpagar" runat="server" OnClick="btnagregarcuentasporpagar_Click" ClientIDMode="Static"></asp:LinkButton>
        <asp:LinkButton ID="btnagregarprestamo" runat="server" OnClick="btnagregarprestamo_Click" ClientIDMode="Static"></asp:LinkButton>
            <asp:LinkButton ID="btnagregartarjeta" runat="server" OnClick="btnagregartarjeta_Click" ClientIDMode="Static"></asp:LinkButton>
     
     <%-- BOTONES DE MODIFICAR GRIDVIEW --%>
    <asp:LinkButton ID="btnmodificarcelular" runat="server" OnClick="btnmodificarcelular_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btnmodificarhijos" runat="server" OnClick="btnmodificarhijos_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btnmodificarestudios" runat="server" OnClick="btnmodificarestudios_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btnmodificarcuenta" runat="server" OnClick="btnmodificarcuenta_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btnmodificarcuentascoope" runat="server" OnClick="btnmodificarcuentascoope_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btnmodificarcuentasporcobrar" runat="server" OnClick="btnmodificarcuentasporcobrar_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btnmodificarbienesinmuebles" runat="server" OnClick="btnmodificarbienesinmuebles_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btnmodificarvehiculos" runat="server" OnClick="btnmodificarvehiculos_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btnmodificarcuentasporpagar" runat="server" OnClick="btnmodificarcuentasporpagar_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btnmodificarprestamos" runat="server" OnClick="btnmodificarprestamos_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btnmodificartarjetacredito" runat="server" OnClick="btnmodificartarjetacredito_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btnmodificarinversiones" runat="server" OnClick="btnmodificarinversiones_Click" ClientIDMode="Static"></asp:LinkButton>
      <asp:LinkButton ID="btnmodificarestudiosuni" runat="server" OnClick="btnmodificarestudiosuni_Click" ClientIDMode="Static"></asp:LinkButton>


     <%-- BOTONES DE ELIMINAR GRIDVIEW --%>
    <asp:LinkButton ID="btneliminarcelular" runat="server" OnClick="btneliminarcelular_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btneliminarhijos" runat="server" OnClick="btneliminarhijos_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btneliminarestudios" runat="server" OnClick="btneliminarestudios_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btneliminarcuenta" runat="server" OnClick="btneliminarcuenta_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btneliminarcuentascoope" runat="server" OnClick="btneliminarcuentascoope_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btneliminarcuentasporcobrar" runat="server" OnClick="btneliminarcuentasporcobrar_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btneliminarbienesinmuebles" runat="server" OnClick="btneliminarbienesinmuebles_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btneliminarvehiculos" runat="server" OnClick="btneliminarvehiculos_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btneliminarcuentasporpagar" runat="server" OnClick="btneliminarcuentasporpagar_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btneliminarprestamos" runat="server" OnClick="btneliminarprestamos_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btneliminartarjetacredito" runat="server" OnClick="btneliminartarjetacredito_Click" ClientIDMode="Static"></asp:LinkButton>
    <asp:LinkButton ID="btneliminarinversion" runat="server" OnClick="btneliminarinversion_Click" ClientIDMode="Static"></asp:LinkButton>
     <asp:LinkButton ID="btneliminarestudiosuni" runat="server" OnClick="btneliminarestudiosuni_Click" ClientIDMode="Static"></asp:LinkButton>


</form>

    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js'></script>
    <script  src="../../DiseñoForms/script.js"></script>


    <script>
        $(function () {
            $("#ITNegocio").change(function () {
                if ($(this).val() === "1") {
                    $("#ITpatente").prop("disabled", true);
                    $("#ITNEmpleados").prop("disabled", true);
                } else {
                    $("#ITpatente").prop("disabled", false);
                    $("#ITNEmpleados").prop("disabled", false);
                }
            });
        });
    </script>

    <script>
        $(function () {
            $("#Select2").change(function () {
                if ($(this).val() === "1") {
                    $("#ACLibro").prop("disabled", true);
                    $("#ACFolio").prop("disabled", true);
                    $("#ACFinca").prop("disabled", true);
                } else {
                    $("#ACLibro").prop("disabled", false);
                    $("#ACFolio").prop("disabled", false);
                    $("#ACFinca").prop("disabled", false);
                }
            });
        });

    </script>

  <script>
      $('.decimales').on('input', function () {
          this.value = this.value.replace(/[^0-9,.]/g, '').replace(/,/g, '.');
      });
  </script>
    <script>
        function Activar() {
            document.getElementById("ITNegocio").disabled = false;
            document.getElementById("ITNNegocio").disabled = false;
            document.getElementById("ITpatente").disabled = false;
            document.getElementById("ITNEmpleados").disabled = false;
            document.getElementById("ITONegocio").disabled = false;
            document.getElementById("ITIMensuales").disabled = false;
            document.getElementById("ITEMensuales").disabled = false;
            document.getElementById("ITDireccion").disabled = false;

        }
        function Desactivar() {
            document.getElementById("ITNegocio").disabled = true;
            document.getElementById("ITNNegocio").disabled = true;
            document.getElementById("ITpatente").disabled = true;
            document.getElementById("ITNEmpleados").disabled = true;
            document.getElementById("ITONegocio").disabled = true;
            document.getElementById("ITIMensuales").disabled = true;
            document.getElementById("ITEMensuales").disabled = true;
            document.getElementById("ITDireccion").disabled = true;
        }
        function Activarr() {
            document.getElementById("ACTVehiculo1").disabled = false;
            document.getElementById("ACMarca").disabled = false;
            document.getElementById("ACLinea").disabled = false;
            document.getElementById("ACModelo").disabled = false;
            document.getElementById("ACPlaca").disabled = false;
            document.getElementById("ACCome").disabled = false;
            document.getElementById("Text25").disabled = true;
            document.getElementById("Text26").disabled = true;
        }
        function Desactivarr() {
            document.getElementById("ACTVehiculo1").disabled = false;
            document.getElementById("ACMarca").disabled = false;
            document.getElementById("ACLinea").disabled = false;
            document.getElementById("ACModelo").disabled = false;
            document.getElementById("ACPlaca").disabled = false;
            document.getElementById("ACCome").disabled = false;
            document.getElementById("Text25").disabled = false;
            document.getElementById("Text26").disabled = false;
        }
        function Activar1() {
            document.getElementById("ISRNombre").disabled = false;
            document.getElementById("ISRRelacion").disabled = false;
            document.getElementById("ISRMonto").disabled = false;
            document.getElementById("ISRPeriodo").disabled = false;

        }
        function Desactivar1() {
            document.getElementById("ISRNombre").disabled = true;
            document.getElementById("ISRRelacion").disabled = true;
            document.getElementById("ISRMonto").disabled = true;
            document.getElementById("ISRPeriodo").disabled = true;

        }
        function Activar11() {
            document.getElementById("ENIns").disabled = false;
            document.getElementById("EPuesto").disabled = false;
            document.getElementById("EPais").disabled = false;

        }
        function Desactivar11() {
            document.getElementById("ENIns").disabled = true;
            document.getElementById("EPuesto").disabled = true;
            document.getElementById("EPais").disabled = true;

        }
        function Activar111() {
            document.getElementById("EParentesco1").disabled = false;
            document.getElementById("Modalidad1").disabled = false;
            document.getElementById("Text8").disabled = false;
            document.getElementById("Text9").disabled = false;
            document.getElementById("Text10").disabled = false;
            document.getElementById("Text11").disabled = false;

        }
        function Desactivar111() {
            document.getElementById("EParentesco1").disabled = true;
            document.getElementById("Modalidad1").disabled = true;
            document.getElementById("Text8").disabled = true;
            document.getElementById("Text9").disabled = true;
            document.getElementById("Text10").disabled = true;
            document.getElementById("Text11").disabled = true;
        }
        function Activar111() {
            document.getElementById("EParentesco1").disabled = false;
            document.getElementById("Modalidad1").disabled = false;
            document.getElementById("Text8").disabled = false;
            document.getElementById("Text9").disabled = false;
            document.getElementById("Text10").disabled = false;
            document.getElementById("Text11").disabled = false;

        }
        function Desactivar111() {
            document.getElementById("EParentesco1").disabled = true;
            document.getElementById("Modalidad1").disabled = true;
            document.getElementById("Text8").disabled = true;
            document.getElementById("Text9").disabled = true;
            document.getElementById("Text10").disabled = true;
            document.getElementById("Text11").disabled = true;
        }
        function Activar1111() {
            document.getElementById("EParentesco2").disabled = false;
            document.getElementById("Modalidad2").disabled = false;
            document.getElementById("EMotivos").disabled = false;
            document.getElementById("ENombres").disabled = false;
            document.getElementById("EINombre").disabled = false;
            document.getElementById("EIPuesto1").disabled = false;
            document.getElementById("EPPais1").disabled = false;

        }
        function Desactivar1111() {
            document.getElementById("EParentesco2").disabled = true;
            document.getElementById("Modalidad2").disabled = true;
            document.getElementById("EMotivos").disabled = true;
            document.getElementById("ENombres").disabled = true;
            document.getElementById("EINombre").disabled = true;
            document.getElementById("EIPuesto1").disabled = true;
            document.getElementById("EPPais1").disabled = true;
        }


    </script>

    <script>
        $(document).ready(function () {
            if (sessionStorage.getItem('bandera') == 1) {
                $("#progressbar li").eq($("fieldset").index('#primerof')).addClass("active");
                $('#primerof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#primerof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                document.getElementById("IGAgencia1").focus();
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 2) {
                $("#progressbar li").eq($("fieldset").index('#primerof')).addClass("active");
                $('#primerof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#primerof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                document.getElementById("IGADepa1").focus();
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 3) {
                $("#progressbar li").eq($("fieldset").index('#primerof')).addClass("active");
                $('#primerof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#primerof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                document.getElementById("IGPDepartamento1").focus();
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 4) {
                $("#progressbar li").eq($("fieldset").index('#primerof')).addClass("active");
                $('#primerof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#primerof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                document.getElementById("IGMunicipio1").focus();
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 5) {
                $("#progressbar li").eq($("fieldset").index('#primerof')).addClass("active");
                $('#primerof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#primerof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                document.getElementById("IGPAZona1").focus();
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 6) {
                $("#progressbar li").eq($("fieldset").index('#primerof')).addClass("active");
                $('#primerof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#primerof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                document.getElementById("IGDoc1").focus();
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 7) {
                $("#progressbar li").eq($("fieldset").index('#segundof')).addClass("active");
                $('#segundof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#segundof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                document.getElementById("IGTCel1").focus();
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 8) {
                $("#progressbar li").eq($("fieldset").index('#primerof')).addClass("active");
                $("#progressbar li").eq($("fieldset").index('#segundof')).addClass("active");
                $('#tercerof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#tercerof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                document.getElementById("id_categoria1").focus();
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 9) {
                $("#progressbar li").eq($("fieldset").index('#primerof')).addClass("active");
                $("#progressbar li").eq($("fieldset").index('#segundof')).addClass("active");
                $('#tercerof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#tercerof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });

                sessionStorage.setItem('bandera', 0);
                document.getElementById("Text1").focus();
            }
            if (sessionStorage.getItem('bandera') == 10) {
                $("#progressbar li").eq($("fieldset").index('#cuartaf')).addClass("active");
                $('#cuartaf').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        left = (now * 50) + "%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#cuartaf').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("OECurso").focus();
            }
            if (sessionStorage.getItem('bandera') == 11) {
                $("#progressbar li").eq($("fieldset").index('#sextof')).addClass("active");
                $('#sextof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#sextof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACPNombre").focus();
            }
            if (sessionStorage.getItem('bandera') == 12) {
                $("#progressbar li").eq($("fieldset").index('#septimof')).addClass("active");
                $('#septimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#septimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });

                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACTInmueble1").focus();
            }
            if (sessionStorage.getItem('bandera') == 13) {
                $("#progressbar li").eq($("fieldset").index('#septimof')).addClass("active");
                $('#septimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#septimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });

                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACTInmueble1").focus();
            }
            if (sessionStorage.getItem('bandera') == 14) {
                $("#progressbar li").eq($("fieldset").index('#septimof')).addClass("active");
                $('#septimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#septimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACTVehiculo1").focus();
            }
            if (sessionStorage.getItem('bandera') == 15) {
                $("#progressbar li").eq($("fieldset").index('#septimof')).addClass("active");
                $('#septimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#septimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACIMoneda1").focus();
            }
            if (sessionStorage.getItem('bandera') == 16) {
                $("#progressbar li").eq($("fieldset").index('#novenof')).addClass("active");
                $('#novenof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#novenof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("TipoCuenta").focus();
            }
            if (sessionStorage.getItem('bandera') == 17) {
                $("#progressbar li").eq($("fieldset").index('#novenof')).addClass("active");
                $('#novenof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#novenof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("PNEntidad1").focus();
            }
            if (sessionStorage.getItem('bandera') == 18) {
                $("#progressbar li").eq($("fieldset").index('#novenof')).addClass("active");
                $('#novenof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#novenof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("PTPrestamo1").focus();
            }
            if (sessionStorage.getItem('bandera') == 19) {
                $("#progressbar li").eq($("fieldset").index('#novenof')).addClass("active");
                $('#novenof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#novenof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("PTPrestamo1").focus();
            }
            if (sessionStorage.getItem('bandera') == 20) {
                $("#progressbar li").eq($("fieldset").index('#decimof')).addClass("active");
                $('#decimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#decimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("PTTEntidad1 ").focus();
            }
            if (sessionStorage.getItem('bandera') == 21) {
                $("#progressbar li").eq($("fieldset").index('#decimof')).addClass("active");
                $('#decimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#decimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("PTTNombre1 ").focus();
            }
            if (sessionStorage.getItem('bandera') == 22) {
                $("#progressbar li").eq($("fieldset").index('#decimof')).addClass("active");
                $('#decimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#decimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("PTTEntidad1 ").focus();
            }
            if (sessionStorage.getItem('bandera') == 23) {
                $("#progressbar li").eq($("fieldset").index('#sextof')).addClass("active");
                $('#sextof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#sextof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACCNBanco1 ").focus();
            }
            if (sessionStorage.getItem('bandera') == 24) {
                $("#progressbar li").eq($("fieldset").index('#sextof')).addClass("active");
                $('#sextof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#sextof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACCTMoneda1 ").focus();
            }
            if (sessionStorage.getItem('bandera') == 25) {
                $("#progressbar li").eq($("fieldset").index('#sextof')).addClass("active");
                $('#sextof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#sextof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACCEstatus1 ").focus();
            }
            if (sessionStorage.getItem('bandera') == 26) {
                $("#progressbar li").eq($("fieldset").index('#quintof')).addClass("active");
                $('#quintof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#quintof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("DropDownList1 ").focus();
            }
            if (sessionStorage.getItem('bandera') == 27) {
                $("#progressbar li").eq($("fieldset").index('#quintof')).addClass("active");
                $('#quintof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#quintof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACNBanco1 ").focus();
            }
            if (sessionStorage.getItem('bandera') == 28) {
                $("#progressbar li").eq($("fieldset").index('#quintof')).addClass("active");
                $('#quintof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#quintof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACEstatus1 ").focus();
            }
            if (sessionStorage.getItem('bandera') == 29) {
                $("#progressbar li").eq($("fieldset").index('#quintof')).addClass("active");
                $('#quintof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#quintof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("ACTMoneda1 ").focus();
            }
            if (sessionStorage.getItem('bandera') == 30) {
                $("#progressbar li").eq($("fieldset").index('#octavof')).addClass("active");
                $('#octavof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#octavof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("btnfinalactivo ").focus();
            }
            if (sessionStorage.getItem('bandera') == 31) {
                $("#progressbar li").eq($("fieldset").index('#doceavof')).addClass("active");
                $('#doceavof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#doceavof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("btnguardaringreso ").focus();
            }
            if (sessionStorage.getItem('bandera') == 32) {
                $("#progressbar li").eq($("fieldset").index('#doceavof')).addClass("active");
                $('#doceavof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#doceavof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("EParentesco1").focus();
            }
            if (sessionStorage.getItem('bandera') == 33) {
                $("#progressbar li").eq($("fieldset").index('#doceavof')).addClass("active");
                $('#doceavof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#doceavof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("Modalidad1").focus();
            }
            if (sessionStorage.getItem('bandera') == 34) {
                $("#progressbar li").eq($("fieldset").index('#doceavof')).addClass("active");
                $('#doceavof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#doceavof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("EParentesco2").focus();
            }
            if (sessionStorage.getItem('bandera') == 35) {
                $("#progressbar li").eq($("fieldset").index('#doceavof')).addClass("active");
                $('#doceavof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#doceavof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("Modalidad2").focus();
            }
            if (sessionStorage.getItem('bandera') == 36) {
                $("#progressbar li").eq($("fieldset").index('#septimof')).addClass("active");
                $('#septimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#septimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("DropDownList2").focus();
            }
            if (sessionStorage.getItem('bandera') == 37) {
                $("#progressbar li").eq($("fieldset").index('#septimof')).addClass("active");
                $('#septimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#septimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("DropDownList3").focus();
            }
            if (sessionStorage.getItem('bandera') == 38) {
                $("#progressbar li").eq($("fieldset").index('#cuartaf')).addClass("active");
                $('#cuartaf').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        scale = 1 - (1 - now) * 0.2;
                        left = (now * 50) + "%";
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#cuartaf').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 0,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
                document.getElementById("ENombreCarrera").focus();
            }

            if (sessionStorage.getItem('bandera') == 39) {
            $("#progressbar li").eq($("fieldset").index('#doceavof')).addClass("active");
            $('#doceavof').show();
            $('#primerof').animate({ opacity: 0 }, {
                step: function (now, mx) {
                    scale = 1 - (1 - now) * 0.2;
                    left = (now * 50) + "%";
                    opacity = 1 - now;
                    $('#primerof').css({
                        'transform': 'scale(' + scale + ')',
                        'position': 'absolute'
                    });
                    $('#doceavof').css({ 'left': left, 'opacity': opacity });
                },
                duration: 0,
                complete: function () {
                    $('#primerof').hide();
                    animating = false;
                },
                easing: 'easeInOutBack'
            });
            sessionStorage.setItem('bandera', 0);
            document.getElementById("Dropdownlist23").focus();
        }  



            if (sessionStorage.getItem('bandera') == 210) {
                console.log("probando cbo");
                $("#progressbar li").eq($("fieldset").index('#quintof')).addClass("active");
                $('#quintof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        left = (now * 50) + "%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#quintof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 130) {
                console.log("probando cbo");
                $("#progressbar li").eq($("fieldset").index('#sextof')).addClass("active");
                $('#sextof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        left = (now * 50) + "%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#sextof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 140) {
                console.log("probando cbo");
                $("#progressbar li").eq($("fieldset").index('#septimof')).addClass("active");
                $('#septimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        left = (now * 50) + "%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#septimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 150) {
                console.log("probando cbo");
                $("#progressbar li").eq($("fieldset").index('#quintof')).addClass("active");
                $('#quintof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        left = (now * 50) + "%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#quintof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 160) {
                console.log("probando cbo");
                $("#progressbar li").eq($("fieldset").index('#quintof')).addClass("active");
                $('#quintof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        left = (now * 50) + "%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#quintof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 170) {
                console.log("probando cbo");
                $("#progressbar li").eq($("fieldset").index('#sextof')).addClass("active");
                $('#sextof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        left = (now * 50) + "%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#sextof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 180) {
                console.log("probando cbo");
                $("#progressbar li").eq($("fieldset").index('#septimof')).addClass("active");
                $('#septimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        left = (now * 50) + "%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#septimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 190) {
                console.log("probando cbo");
                $("#progressbar li").eq($("fieldset").index('#septimof')).addClass("active");
                $('#septimof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        left = (now * 50) + "%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#septimof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
            }
            if (sessionStorage.getItem('bandera') == 200) {
                console.log("probando cbo");
                $("#progressbar li").eq($("fieldset").index('#octavof')).addClass("active");
                $('#octavof').show();
                $('#primerof').animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        left = (now * 50) + "%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        $('#primerof').css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        $('#octavof').css({ 'left': left, 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        $('#primerof').hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
                sessionStorage.setItem('bandera', 0);
            }
        });
    </script>        
  
  
      <!--   ////////////////////////////////////////////////////  -->
    <script type="text/javascript">
        function cmbsucursal() {
            sessionStorage.setItem('bandera', '1');
        }
        function cmbarea() {
            sessionStorage.setItem('bandera', '2');
        }
        function cmbdepartamento() {
            sessionStorage.setItem('bandera', '3');
        }
        function cmbmunicipio() {
            sessionStorage.setItem('bandera', '4');
        }
        function cmbzona() {
            sessionStorage.setItem('bandera', '5');
        }
        function cmbtipodoc() {
            sessionStorage.setItem('bandera', '6');
        }
        function cmbtipotelefono() {
            sessionStorage.setItem('bandera', '7');

        }
        function cmbestadocivil() {
            sessionStorage.setItem('bandera', '8');
        }
        function cmbtipoinmueble() {
            sessionStorage.setItem('bandera', '7');
        }
        function cmbinmueble() {
            sessionStorage.setItem('bandera', '12');
        }
        function cmbvehiculo() {
            sessionStorage.setItem('bandera', '14');
        }
        function cmbmonedainversiones(){
            sessionStorage.setItem('bandera', '15');
        }
        function cmbtiplazo() {
            sessionStorage.setItem('bandera', '16');
        }
        function cmbtipoinstitucion() {
            sessionStorage.setItem('bandera', '17');

        }
        function cmbtipoprestamo() {
            sessionStorage.setItem('bandera', '18');
        }
        function cmbtipoprestamotarjeta() {
            sessionStorage.setItem('bandera', '20');
        }
        function cmbnombreprestamotarjeta() {
            sessionStorage.setItem('bandera', '21');
        }
        function cmbinstitucionctacoope() {
            sessionStorage.setItem('bandera', '23');
        }
        function cmbmonedactacoope() {
            sessionStorage.setItem('bandera', '24');
        }
        function cmbestatusctacoope() {
            sessionStorage.setItem('bandera', '25');
        }
        function cmbtipodecuentasactivo() {
            sessionStorage.setItem('bandera', '26');
        }
        function cmbinstitucionactivo() {
            sessionStorage.setItem('bandera', '27');
        }
        function cmbtipodeestadoactivo() {
            sessionStorage.setItem('bandera', '28');
        }
        function cmbtipomonedaactivo() {
            sessionStorage.setItem('bandera', '29');
        }


        function confirmselect() {
            sessionStorage.setItem('bandera', '12');
        }       
        function guardarepinicial() {
            document.getElementById("btnguardarinicio").click();
            //sessionStorage.setItem('bandera', '1');
            sessionStorage.setItem('bandera', '8');
        };
        function guardarepmedio() {
            document.getElementById('btnguardarmedio').click();
            sessionStorage.setItem('bandera', '9');
        }
        function guardarinformaciongeneral() {
            document.getElementById('btnguardainfogeneral').click();
            sessionStorage.setItem('bandera', '10');
           
        }
        function cmbtipomoneda1() {
            document.getElementById('combotipomoneda1').click();
            sessionStorage.setItem('bandera', '11');
        }
        function cmbtipomoneda2() {
            document.getElementById('combotipomoneda2').click();
            sessionStorage.setItem('bandera', '12');
        }
        function cmbtipomoneda3() {
            document.getElementById('combotipomoneda3').click();
            sessionStorage.setItem('bandera', '13');
        }
        function cmbtipomoneda4() {
            document.getElementById('combotipomoneda4').click();
            sessionStorage.setItem('bandera', '14');
        }
        function cmbtipoestatus1() {
            document.getElementById('combotipoestatus1').click();
            sessionStorage.setItem('bandera', '15');
        }
        function cmbtipoestatus2() {
            document.getElementById('combotipoestatus2').click();
            sessionStorage.setItem('bandera', '16');
        }
        function cmbtipoestatus3() {
            document.getElementById('combotipoestatus3').click();
            sessionStorage.setItem('bandera', '17');
        }
        function cmbtipoinmueble() {
            document.getElementById('combotipoinmueble').click();
            sessionStorage.setItem('bandera', '18');
        }
        function cmbtipovehiculo() {
            document.getElementById('combotipovehiculo').click();
            sessionStorage.setItem('bandera', '19');
        }
        function btnguardaractivo() {
            document.getElementById('btnguardaractivo').click();
            sessionStorage.setItem('bandera', '30');
        }
        function guardarepfinalyenviado() {
            document.getElementById('btnguardaryenviar').click();
            sessionStorage.setItem('bandera', '31');
        }
        function guardarepfinalpasivos() {
            document.getElementById('guardarepfinalpasivos1').click();
            sessionStorage.setItem('bandera', '20');
        }
        function cmbnacionalidad1() {
            sessionStorage.setItem('bandera', '32');
        }
        function cmbparentesco1() {
            sessionStorage.setItem('bandera', '33');
        }
        function cmbnacionalidad2() {
            sessionStorage.setItem('bandera', '34');
        }
        function cmbparentesco2() {
            sessionStorage.setItem('bandera', '35');
        }
        function cmbtipoinstitucioninversion() {
            sessionStorage.setItem('bandera', '36');
        }
        function cmbproveedordelestado() {
            sessionStorage.setItem('bandera', '39');
        }
      
    </script>

    <%-- REDIRECCION DE FIELDSET GRIDVIEW --%>
    <script type="text/javascript">
        $(".seleccionarcelulargridview").click(function () {
            sessionStorage.setItem('bandera', '7');
        }); 
        $(".seleccionarhijogridview").click(function () {
            sessionStorage.setItem('bandera', '9');
        }); 
        $(".seleccionarestudiogridview").click(function () {
            sessionStorage.setItem('bandera', '10');
        }); 
        $(".seleccionarcuentaporcobrargridview").click(function () {
            sessionStorage.setItem('bandera', '11');
        }); 
        $(".seleccionarbienesinmueblesgridview").click(function () {
            sessionStorage.setItem('bandera', '13');
        }); 
        $(".seleccionarvehiculosgridview").click(function () {
            sessionStorage.setItem('bandera', '14');
        }); 
        $(".seleccionarcuentasporpagargridview").click(function () {
            sessionStorage.setItem('bandera', '16');
        }); 
        $(".seleccionarprestamogridview").click(function () {
            sessionStorage.setItem('bandera', '19');
        }); 
        $(".seleccionartarjetasgridview").click(function () {
            sessionStorage.setItem('bandera', '22');
        }); 
        $(".seleccionarcooperativasgridview").click(function () {
            sessionStorage.setItem('bandera', '23');
        }); 
        $(".seleccionarcuentasvariasgridview").click(function () {
            sessionStorage.setItem('bandera', '26');
        }); 
        $(".seleccionarinversionesgridview").click(function () {
            sessionStorage.setItem('bandera', '36');
        }); 
        $(".seleccionarestudiougridview").click(function () {
            sessionStorage.setItem('bandera', '38');
        }); 

        

        

        
        
        

        
        

    </script>

    <script type="text/javascript">

        function agregarcelular() {

            document.getElementById('btnguardarcelular').click();
            sessionStorage.setItem('bandera', '7');
        }

        function agregarhijos() {

            document.getElementById('btnguardarhijos').click();
            sessionStorage.setItem('bandera', '8');
        }

        function agregarestudios() {

            document.getElementById('btnguardarestudios').click();
            sessionStorage.setItem('bandera', '10');
        }
        function agregarcuenta() {

            document.getElementById('btnguardarcuenta').click();
            sessionStorage.setItem('bandera', '26');
        }

        function agregarcuentascoope() {
            document.getElementById('btnguardarcuentascoope').click();
            sessionStorage.setItem('bandera', '11');
        }

        function agregarcuentasporcobrar() {
            document.getElementById('btnguardarcuentasporcobrar').click();
            sessionStorage.setItem('bandera', '11');
        }

        function agregarbienesinmuebles() {
            document.getElementById('btnguardarbienesinmuebles').click();
            sessionStorage.setItem('bandera', '13');
        }
        function agregarvehiculos() {
            document.getElementById('btnguardarvehiculos').click();
            sessionStorage.setItem('bandera', '14');
        }
        function agregarcuentasporpagar() {
            document.getElementById('btnagregarcuentasporpagar').click();
            sessionStorage.setItem('bandera', '16');
        }
        function agregarprestamos() {
            document.getElementById('btnagregarprestamo').click();
            sessionStorage.setItem('bandera', '17');
        }
        function agregartarjetacredito() {
            document.getElementById('btnagregartarjeta').click();
            sessionStorage.setItem('bandera', '20');
        }
        function agregarinversion() {

            document.getElementById('btnguardarinversiones').click();
            sessionStorage.setItem('bandera', '36');
        }
        function agregarestudiosuni() {

            document.getElementById('btnguardarestudiosuni').click();
            sessionStorage.setItem('bandera', '38');
        }

        function modificarcelular() {
            document.getElementById('btnmodificarcelular').click();
            sessionStorage.setItem('bandera', '7');
        }

        function modificarhijos() {
            document.getElementById('btnmodificarhijos').click();
            sessionStorage.setItem('bandera', '8');
        }

        function modificarestudios() {
            document.getElementById('btnmodificarestudios').click();
            sessionStorage.setItem('bandera', '10');
        }

        function modificarcuenta() {
            document.getElementById('btnmodificarcuenta').click();
            sessionStorage.setItem('bandera', '26');
        }

        function modificarcuentascoope() {
            document.getElementById('btnmodificarcuentascoope').click();
            sessionStorage.setItem('bandera', '11');
        }

        function modificarcuentasporcobrar() {
            document.getElementById('btnmodificarcuentasporcobrar').click();
            sessionStorage.setItem('bandera', '11');
        }

        function modificarbienesinmuebles() {
            document.getElementById('btnmodificarbienesinmuebles').click();
            sessionStorage.setItem('bandera', '13');
        }

        function modificarvehiculos() {
            document.getElementById('btnmodificarvehiculos').click();
            sessionStorage.setItem('bandera', '14');
        }

        function modificarcuentasporpagar() {
            document.getElementById('btnmodificarcuentasporpagar').click();
            sessionStorage.setItem('bandera', '16');
        }

        function modificarprestamos() {
            document.getElementById('btnmodificarprestamos').click();
            sessionStorage.setItem('bandera', '17');
        }

        function modificartarjetacredito() {
            document.getElementById('btnmodificartarjetacredito').click();
            sessionStorage.setItem('bandera', '20');
        }
        function modificarinversion() {
            document.getElementById('btnmodificarinversiones').click();
            sessionStorage.setItem('bandera', '36');
        }
        function modificarestudiosuni() {
            document.getElementById('btnmodificarestudiosuni').click();
            sessionStorage.setItem('bandera', '38');
        }

        function eliminarcelular() {
            document.getElementById('btneliminarcelular').click();
            sessionStorage.setItem('bandera', '7');
        }

        function eliminarhijos() {
            document.getElementById('btneliminarhijos').click();
            sessionStorage.setItem('bandera', '8');
        }

        function eliminarestudios() {
            document.getElementById('btneliminarestudios').click();
            sessionStorage.setItem('bandera', '10');
        }

        function eliminarcuenta() {
            document.getElementById('btneliminarcuenta').click();
            sessionStorage.setItem('bandera', '26');
        }

        function eliminarcuentascoope() {
            document.getElementById('btneliminarcuentascoope').click();
            sessionStorage.setItem('bandera', '11');
        }

        function eliminarcuentasporcobrar() {
            document.getElementById('btneliminarcuentasporcobrar').click();
            sessionStorage.setItem('bandera', '11');
        }

        function eliminarbienesinmuebles() {
            document.getElementById('btneliminarbienesinmuebles').click();
            sessionStorage.setItem('bandera', '13');
        }

        function eliminarvehiculos() {
            document.getElementById('btneliminarvehiculos').click();
            sessionStorage.setItem('bandera', '14');
        }

        function eliminarcuentasporpagar() {
            document.getElementById('btneliminarcuentasporpagar').click();
            sessionStorage.setItem('bandera', '16');
        }

        function eliminarprestamos() {
            document.getElementById('btneliminarprestamos').click();
            sessionStorage.setItem('bandera', '17');
        }

        function eliminartarjetacredito() {
            document.getElementById('btneliminartarjetacredito').click();
            sessionStorage.setItem('bandera', '20');
        }

        function eliminarinversiones() {
            document.getElementById('btneliminarinversion').click();
            sessionStorage.setItem('bandera', '36');
        }
        function eliminarestudiosuni() {
            document.getElementById('btneliminarestudiosuni').click();
            sessionStorage.setItem('bandera', '38');
        }
    </script>

    <%-- No Permitir Numeros Negativos --%>
    <script>
          function el(el) {
              return document.getElementById(el);
          }

          el('IGCIF').addEventListener('input', function () {
              var val = this.value;
              this.value = val.replace(/\D|\-/, '');
          });
      </script>  
    <script>
        function el(el) {
            return document.getElementById(el);
        }

        el('IGNoDoc').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
    </script>  
    <script>
        function el(el) {
            return document.getElementById(el);
        }

        el('IGCelular').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
    </script>  
    <script>
        function el(el) {
            return document.getElementById(el);
        }

        el('OEAño').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
    </script>
    <script>
        function el(el) {
            return document.getElementById(el);
        }

        el('OEDuracion').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
    </script> 
    <script>
        function el(el) {
            return document.getElementById(el);
        }

        el('ACCMonto').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
    </script>
    <script>
        function el(el) {
            return document.getElementById(el);
        }

        el('ACPMonto').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
    </script>
    <script>
        function el(el) {
            return document.getElementById(el);
        }

        el('ACVActual').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
    </script>
    <script>
        function el(el) {
            return document.getElementById(el);
        }

        el('ACIMonto').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });

        function el(el) {
            return document.getElementById(el);
        }

        el('ACMEComputo').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMASala').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMAComedor').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMATelevisorC').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMATelevisorV').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMASonidoC').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMASonidoV').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMALavadoraC').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMALavadoraV').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMASecadoraC').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMASecadoraV').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMAEstufaC').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMAEstufaV').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMARefrigeradoraC').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMARefrigeradoraV').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMATMovilC').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });


        function el(el) {
            return document.getElementById(el);
        }

        el('ACMACantidadO').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMACantidadO').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('PMInicial').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ISBase').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('IBoni').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ICMensuales').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITNEmpleados').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITIMensuales').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITEMensuales').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ISRMonto').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITAlimen').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITTras').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITPago').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITPrestamos').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITTarjeta').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITVestuario').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITRecreacion').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ITOtros').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('Number1').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('Number2').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMATMovilV').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('PCPMonto1').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('PTTLimite').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('PTTLimite2').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('PTTSaldo').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('POMonto').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('PTSaldo').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACCMonto').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACMonto').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('ACCaja').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
        function el(el) {
            return document.getElementById(el);
        }

        el('IFtel').addEventListener('input', function () {
            var val = this.value;
            this.value = val.replace(/\D|\-/, '');
        });
    </script>
</body>
</html>