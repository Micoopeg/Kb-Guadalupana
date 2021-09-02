<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeguimientoLead.aspx.cs" Inherits="KB_Guadalupana.Views.CRM_SISTEMA.JefesDeAgencia.SeguimientoLead" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRM - Seguimiento Lead</title>
    <link rel="shortcut icon" href="../../../../Imagenes/logo.jpeg" />
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css' />
    <link rel="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../../CRM-Estilos/EstiloSeguimientoLead.css" type="text/css" />
    
</head>
<body style="background-color:#2c3e50">
    <form id="form1" runat="server">
                <header style="background-color:#69a43c">
  <div class="row">
    <div class="col-sm-4" >
        <asp:LinkButton ID="LinkButton1" class="btn btn-success" style=" background-color:#003561; margin-left:-9px; margin-top:-9px; border-radius:0px; border-color:#003561; text-decoration:none; width:100%" value="Menu Principal" type="button" runat="server" tabindex="35" name="Guardar" title="Guardar" OnClick="btnmenuprincipal_Click" >Regresar</asp:LinkButton>
    </div>
  </div>
        </header>
        <%-- TERMINA HEADER --%>
        <div>
             <div id="content-wrapper" style="height: 1931px">
            <div class="wrapper">
                <div style="border: 1px #e8e8e8 solid; width: 100%; height: 1148px; float: right; margin: 10px 0px 10px 0px">
                    <div style="border-bottom: 1px #e8e8e8 solid; background-color: #f3f3f3; padding: 8px; font-size: 13px; font-weight: 700; color: #45484d;">
                        CONTROL DE PROSPECTOS
                    </div>
                    <div style="padding: 8px; font-size: 13px;">
                        <h4 style="text-align: left">INFORMACIÓN GENERAL</h4>
                        <input id="txtnumerogeneral" style="margin-left: 1%;" placeholder="DPI" visible="false" runat="server" type="text" tabindex="1" class="inputscortos" autofocus="autofocus" />
                        <input id="txtnumeroderegistro" style="margin-left: 1%;" placeholder="DPI" visible="false" runat="server" type="text" tabindex="1" class="inputscortos" autofocus="autofocus" />

                        <span>Documento DPI:</span>
                        <input id="txtnumerodpi" disabled="disabled" onkeypress="return numeros(event);" style="margin-left: 112px; width:296px; font-size:26px;text-align:center" placeholder="DPI" runat="server" type="text" tabindex="1" class="inputscortos" autofocus="autofocus" />
                        <br />
                        <span>Nombre Completo:</span>
                        <input id="txtnombrecompleto" onkeypress="return soloLetras(event)" style="margin-left: 99px; width:296px; text-align:center" placeholder="Nombre Completo" runat="server" type="text" tabindex="2" class="inputslargos" autofocus="autofocus" />
                        <br />
                        <span>Numero de teléfono:</span>
                        <input id="txttelefono" onkeypress="return numeros(event);" style="margin-left: 91px; width:296px; text-align:center" placeholder="Teléfono" runat="server" type="text" tabindex="3" class="inputscortos" maxlength="8" autofocus="autofocus" />
                        <br />
                        <span>Correo Electrónico:</span>
                        <input id="txtemail" style="margin-left: 95px;width:296px; text-align:center; " placeholder="Correo electrónico" runat="server" type="text" tabindex="4" class="inputslargos" autofocus="autofocus" />
                        <br />
                        <span>Monto:</span>
                        <span style="margin-left: 141px; font-size: 16px">Q</span><input id="txtmonto" style="width:296px; font-size:18px; text-align:center; margin-left:7px" placeholder="Q - Monto" runat="server" type="text" tabindex="5" class="inputscortos" autofocus="autofocus" />
                        <br />
                    </div>
                    <%-- AREA DE INGRESOS --%>
                    <h4 style="text-align: left">ÁREA DE INGRESOS</h4>
                    <span>Ingresos:</span>
                    <span style="margin-left: 2%; font-size: 16px">Q</span><input id="txtingreso" onkeypress="return solonumeros(event);" style="width: 296px; margin-left:109px; text-align:center" placeholder="Q - Ingresos" runat="server" type="text" tabindex="6" class="inputscortos" autofocus="autofocus" />
                    <br />
                    <span>Egresos:</span>
                    <span style="margin-left: 2%; font-size: 16px">Q</span><input id="txtegresos" onkeypress="return solonumeros(event);" style="width: 296px; margin-left:111px; text-align:center" placeholder="Q - Egresos" runat="server" type="text" tabindex="7" class="inputscortos" autofocus="autofocus" />
                    <br />
                    <div style="padding: 2px; font-size: 13px;">
                        <%-- AREA DE EMPLEADOS --%>
                        <h4 style="text-align: left">ÁREA DE EMPLEO</h4>
                        <span>Años laborados</span>
                        <input id="txtañoslaborados" onkeypress="return numeros(event);" style="margin-left: 118px; width: 296px;" placeholder="Años laborados" runat="server" type="text" tabindex="8" class="inputscortos" autofocus="autofocus" />
                        <br />
                        <span>¿Trabaja actualmente?</span>
                        <asp:DropDownList ID="combotienetrabajo" runat="server" Style="margin-left: 82px; width: 296px;" TabIndex="9" CssClass="inputscortos">
                            <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <span>¿En que empresa labora o que actividad realiza?</span>
                        <input id="txttabajoactual" style="margin-left: 6px; width: 237px" placeholder="Trabajo actual" runat="server" type="text" tabindex="10" class="inputscortos" autofocus="autofocus" />
                        <br />
                        <span>¿Cuenta con IGSS?</span>
                        <asp:DropDownList ID="combocuentaigss" runat="server" Style="margin-left: 96px; width: 299px;" TabIndex="11" CssClass="inputscortos">
                            <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </div>
                    <%-- AREA DE SEGUIMIENTOS --%>
                    <h4 style="text-align: left">Área de seguimiento</h4>
                    <span>Tipo de servicio:</span>
                    <asp:DropDownList ID="combotiposervicio" runat="server" OnSelectedIndexChanged="tiposervicio_SelectedIndexChanged" AutoPostBack="true" Style="margin-left: 123px; width: 249px; text-align:center" TabIndex="12" CssClass="inputscortos">
                        <asp:ListItem Text="Tipo de servicio" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>Destino o Finalidad de servicio:</span>
                    <select id="combofinalidaddeservicio" runat="server" style="margin-left: 26px; width: 249px; text-align:center" tabindex="13" class="inputscortos">
                        <option value="0">Seleccione la finalidad del servicio </option>
                    </select>
                    <br />
                    <span>Estado de la llamada:</span>
                    <asp:DropDownList ID="combocontactollamadas" runat="server" Style="margin-left: 92px; width: 249px; text-align:center" TabIndex="14" CssClass="inputscortos">
                        <asp:ListItem Text="Estado de la llamada" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>Primera llamada</span>
                    <input id="txtfechainicio" style="margin-left: 123px; width: 249px; text-align:center" runat="server" type="date" tabindex="15" class="inputscortos" value="2020-04-25" min="1950-01-01" max="2021-12-31" autofocus="autofocus" />
                    <br />
                    <span>Ultima llamada</span>
                    <input id="txtfechafin" style="margin-left: 129px; width: 249px; text-align:center" runat="server" type="date" tabindex="16" class="inputscortos" value="2020-04-25" min="1950-01-01" max="2021-12-31" autofocus="autofocus" />
                    <hr style="border: groove" />
                    <br />
                    <span>Color de semáforo:</span>
                    <asp:DropDownList ID="combosemaforoestado" OnSelectedIndexChanged="seleccionsemaforo_SelectedIndexChanged" AutoPostBack="true" runat="server" Style="margin-left: 96px; width: 250px;" TabIndex="17" CssClass="inputscortos">
                        <asp:ListItem Text="Seleccione el color" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox Style="margin-left: 5%;" Width="30px" Height="30px" ID="txtcolorestado" Enabled="false" runat="server" TabIndex="18"></asp:TextBox>
                    <br />
                    <span>Motivo del estado:</span>
                    <asp:DropDownList ID="combosemaforodescripcion" runat="server" Style="margin-left: 100px; width: 250px; text-align: center;" TabIndex="19" CssClass="inputscortos">
                        <asp:ListItem Text="Motivo del estado" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <hr style="border: groove" />
                    <h4 style="text-align: left">INFORMACIÓN ADCIONAL</h4>
                    <span>Tipo de domicilio:</span>
                    <asp:DropDownList ID="combotipodomicilio" runat="server" Style="margin-left: 112px; width: 250px;" TabIndex="20" CssClass="inputscortos">
                        <asp:ListItem Text="Tipo del domicilio" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>¿Años en domicilio?</span>
                    <input id="txtañodomicilio" onkeypress="return numeros(event);" style="margin-left: 97px; width: 250px;" placeholder="¿Años de residencia?" runat="server" type="text" tabindex="21" class="inputscortos" autofocus="autofocus" />
                    <br />
                    <span>¿Posee cuenta en cooperativa?</span>
                    <asp:DropDownList ID="comboposeecuentacoope" runat="server" Style="margin-left: 33px; width: 250px;" TabIndex="22" CssClass="inputscortos">
                        <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>Sucursal más cercana:</span>
                    <asp:DropDownList ID="combosucursalmascerca" runat="server" Style="margin-left: 85px; width: 250px;" TabIndex="23" CssClass="inputscortos">
                        <asp:ListItem Text="¿Sucursal más cercana?" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Central" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>Contactado por:</span>
                    <input id="txtcontactadopor" style="margin-left: 123px; width: 250px;" placeholder="Contactado Por:" runat="server" type="text" tabindex="24" class="inputscortos" autofocus="autofocus" />
                    <br />
                    <span>DPI de referencia:</span>
                    <input id="txtdpireferencia" maxlength="13" onkeypress="return numeros(event);" style="margin-left: 109px; width: 250px;" placeholder="DPI de referencia" runat="server" type="text" tabindex="25" class="inputscortos" autofocus="autofocus" />
                    <%-- AREA DE COMENTARIOS / DESCRIPCIÓN --%>
                    <div class="form-group" style="float: none">
                        <textarea class="form-control rounded-0" style="margin-left: 28px; width: 95%; text-align:center" placeholder="Descripción" tabindex="26" id="exampleFormControlTextarea1" runat="server" rows="5" maxlength="150"></textarea>
                    </div>
                    <br />
                    <%-- AREA DE BOTONES --%>
                    <center>
   
   
         <asp:LinkButton ID="LinkButton3" class="btn btn-success" style=" text-decoration:none; width:45%" value="Guardar" type="button" runat="server" tabindex="27" name="Guardar" title="Guardar" OnClick="Btn_Guardarprospecto_Click" >Guardar</asp:LinkButton>
   
   
         </center>

                    <%-- AREA DEL GRIDVIEW --%>
                </div>
            </div>
        </div>
        </div>
        </div>

        <br />
        <br />
        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="../../../CRM-Script/Script.js" type="text/javascript"></script>
    </form>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script>
        $("#txtmonto").on({
            "focus": function (event) {
                $(event.target).select();
            },
            "keyup": function (event) {
                $(event.target).val(function (index, value) {
                    return value.replace(/\D/g, "")
                        .replace(/([0-9])([0-9]{2})$/, '$1,$2')
                        .replace(/\B(?=(\d{3})+(?!\d)\,?)/g, ",");
                });
            }
        });
        $("#txtingreso").on({
            "focus": function (event) {
                $(event.target).select();
            },
            "keyup": function (event) {
                $(event.target).val(function (index, value) {
                    return value.replace(/\D/g, "")
                        .replace(/([0-9])([0-9]{2})$/, '$1,$2')
                        .replace(/\B(?=(\d{3})+(?!\d)\,?)/g, ",");
                });
            }
        });
        $("#txtegresos").on({
            "focus": function (event) {
                $(event.target).select();
            },
            "keyup": function (event) {
                $(event.target).val(function (index, value) {
                    return value.replace(/\D/g, "")
                        .replace(/([0-9])([0-9]{2})$/, '$1,$2')
                        .replace(/\B(?=(\d{3})+(?!\d)\,?)/g, ",");
                });
            }
        });
    </script>

    <script>
        posicionarMenu();
        $(window).scroll(function () {
            posicionarMenu();
        });

        function posicionarMenu() {
            var altura_del_header = 35;
            var altura_del_menu = $('.menu').outerHeight(true);

            if ($(window).scrollTop() >= altura_del_header) {
                $('.menu').addClass('fixed');
                $('.wrapper').css('margin-top', (altura_del_menu) + 'px');
            } else {
                $('.menu').removeClass('fixed');
                $('.wrapper').css('margin-top', '0');
            }
        }

    </script>
</body>
</html>
