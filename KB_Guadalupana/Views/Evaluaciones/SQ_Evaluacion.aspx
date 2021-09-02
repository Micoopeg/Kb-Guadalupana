<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQ_Evaluacion.aspx.cs" Inherits="KB_Guadalupana.Views.Evaluaciones.SQ_Evaluacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css"/>
           <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="../../SQEstilos/Estiloseval.css" />
       <link href="../../SQEstilos/Estilosmalla.css" rel="stylesheet" />
    <title>Evaluación</title>
</head>

    
<body>
    <form id="msform" style="width:90%; height:100%; display: flex;align-items: center;align-content: center;justify-content: center;flex-direction: column;" runat="server">

          <div id="botones" runat="server" style="display:flex;flex-direction:column;align-content:center;justify-content:center;align-items:center">
            <asp:Button runat="server" ID="Autoevaluacion" Text="Autoevaluación" Width="300px" CssClass="previous action-button" OnClick="Autoevaluacion_Click" /><br /><br />
            <asp:Button runat="server" ID="EcaluacionJefe" Text="Evalución Jefe" Width="300px" CssClass="previous action-button" OnClick="EcaluacionJefe_Click"/><br /><br />
            <asp:Button runat="server" ID="EvaluacionPersonas" Text="Evaluación de personas a cargo" Width="300px" CssClass="previous action-button" OnClick="EvaluacionPersonas_Click"/>
        </div>

          <div id="evaluacion" style="width:95%" runat="server">
        <center>
            <br />
        <h3>Seleccione persona a evaluar: </h3>
          <asp:DropDownList  ID="Persona" runat="server" CssClass="dis" Width="177px" AutoPostBack="false"></asp:DropDownList>
             <asp:DropDownList  ID="personacargo" Visible="false"  runat="server" CssClass="dis" Width="177px" AutoPostBack="true" OnSelectedIndexChanged="Persona_SelectedIndexChanged" ></asp:DropDownList>
        </center>
        <br /><br />
     <!-- progressbar -->
         <ul id="progressbar">
        <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound" >
            <ItemTemplate>
                   
    <%--<li class="active">Primer Pregunta</li>--%>
                <asp:Label ID="lblpregunta" runat="server" Text='<%# Eval("codsqpregunta") %> ' Visible="false" ></asp:Label>
    <li id="barra" runat="server"> <%# Eval("pregunta") %></li>
    
 
            </ItemTemplate>

        </asp:Repeater>
              </ul>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" >
            <ItemTemplate>
               

   <fieldset>
    <asp:Label ID="lblrp2" runat="server" visible="false" Text='<%# Eval("codsqpregunta") %> ' ></asp:Label>
       <asp:Label  ID="orden" runat="server" Text='<%# Eval("ordenpregunta") %>' ></asp:Label>
    <h2 class="fs-title">  <%# Eval("pregunta") %></h2>
    <h3 class="fs-subtitle" style="text-align:justify" ><%# Eval("InfoExtraPregunta") %></h3>
    <div id="dropcalifica" runat="server"> 
       <asp:DropDownList  ID="valores" runat="server" CssClass="dis" Width="177px"   ></asp:DropDownList>
        </div>
        <div id="comentariodiv" runat="server" class="form-group" style="text-align: center">
           
                <label for="exampleInputEmail1">
                    <h5>Comentario</h5>
                </label>
                  <textarea id="campocomentario" runat="server" class="form-control form-control-lg" style="max-height:101px; min-height:101px; max-width:819px; min-width:819px;" placeholder="Respuesta" rows="4" maxlength="500" required></textarea>
            </div>
    <%--   <div class="paddingBlock">

  <div class="equalHWrap eqWrap">
    <div class="equalHW eq">boo <br> boo</div>
    <div class="equalHW eq">shoo</div>
    <div class="equalHW eq">clue</div>
  </div>
</div> --%>     
       <div id="Escala" runat="server" class="paddingBlock">

  <div class="equalHWrap eqWrap">
     <asp:Repeater ID="Repeater3" runat="server" OnItemDataBound="Repeater3_ItemDataBound">
         <ItemTemplate>     <div class="equalH eq"> <%# Eval("rangonumerico") %> <br><%# Eval("valortexto") %></div></ItemTemplate>

      </asp:Repeater> 
  </div>
</div>      


           <input id="ante" runat="server" type="button" name="previous" class="previous action-button" value="Anterior" />
    <input id="sig" runat="server" type="button" name="next" class="next action-button" value="Siguiente"/>
        <input id="envio" runat="server" type="submit" name="submit" class="submit action-button" value="Enviar" onclick="enviar()"/>
     <asp:LinkButton ID="btnsig" runat="server" OnClick="btnsig_Click" ClientIDMode="Static"></asp:LinkButton>
       <asp:LinkButton ID="btnenviar" runat="server" OnClick="btnenviar_Click" ClientIDMode="Static"></asp:LinkButton>
  </fieldset>

            </ItemTemplate>
            
        </asp:Repeater>
 
  <!-- fieldsets -->
 <%--     <ul id="progressbar">
    <li class="active">Primer Pregunta</li>
    <li>Segunda Pregunta</li>
    <li>Tercer Pregunta</li>
    <li>Cuarta Pregunta</li>
    <li>Quinta Pregunta</li>
    
  </ul>
  <fieldset>
    <h2 class="fs-title">1. Identificación con la Cooperativa</h2>
    <h3 class="fs-subtitle">This is step 1</h3>
    <input type="text" name="email" placeholder="Email" />
    <input type="password" name="pass" placeholder="Password" />
    <input type="password" name="cpass" placeholder="Confirm Password" />
    <input type="button" name="next" class="next action-button" value="Next" />
  </fieldset>
           
  <fieldset>
    <h2 class="fs-title">Social Profiles</h2>
    <h3 class="fs-subtitle">Your presence on the social network</h3>
    <input type="text" name="twitter" placeholder="Twitter" />
    <input type="text" name="facebook" placeholder="Facebook" />
    <input type="text" name="gplus" placeholder="Google Plus" />
    <input type="button" name="previous" class="previous action-button" value="Previous" />
    <input type="button" name="next" class="next action-button" value="Next" />
  </fieldset>

         <fieldset>
    <h2 class="fs-title">Social Profiles</h2>
    <h3 class="fs-subtitle">Your presence on the social network</h3>
    <input type="text" name="twitter" placeholder="Twitter" />
    <input type="text" name="facebook" placeholder="Facebook" />
    <input type="text" name="gplus" placeholder="Google Plus" />
    <input type="button" name="previous" class="previous action-button" value="Previous" />
    <input type="button" name="next" class="next action-button" value="Next" />
  </fieldset>
        
         <fieldset>
    <h2 class="fs-title">Social Profiles</h2>
    <h3 class="fs-subtitle">Your presence on the social network</h3>
    <input type="text" name="twitter" placeholder="Twitter" />
    <input type="text" name="facebook" placeholder="Facebook" />
    <input type="text" name="gplus" placeholder="Google Plus" />
    <input type="button" name="previous" class="previous action-button" value="Previous" />
    <input type="button" name="next" class="next action-button" value="Next" />
  </fieldset>
  <fieldset>
    <h2 class="fs-title">Personal Details</h2>
    <h3 class="fs-subtitle">We will never sell it</h3>
    <input type="text" name="fname" placeholder="First Name" />
    <input type="text" name="lname" placeholder="Last Name" />
    <input type="text" name="phone" placeholder="Phone" />
    <textarea name="address" placeholder="Address"></textarea>
    <input type="button" name="previous" class="previous action-button" value="Previous" />
    <input type="submit" name="submit" class="submit action-button" value="Submit" />
  </fieldset>--%>
             </div>

        <br /><br /><br /><br />

               <div id="tablapersonas" runat="server" style=" height: 400px; width:50%; align-content:center;align-items:center;justify-content:center">
                           <asp:Label ID="lbll" runat="server" CssClass="fs-title" Text="Personal con autoevaluación completa">  </asp:Label>    
                   <asp:GridView ID="gridViewPersonas" runat="server" CssClass="tabla" AutoGenerateColumns="False" ForeColor="Black" Width="100%"
                            BorderStyle="Solid">
                            <Columns>
                          
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre">
                                    <ItemTemplate>
                                       <asp:Label ID="lblnombre" Text='<%# Eval("Nombre") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Puesto">
                                    <ItemTemplate>
                                       <asp:Label ID="lblpuesto" Text='<%# Eval("Puesto") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Autoevaluación">
                                    <ItemTemplate>
                                       <asp:Label ID="lblevaluacion" Text='<%# Eval("Autoevaluacion") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                             <HeaderStyle CssClass="prueba"  ForeColor="White" BackColor="#003563"></HeaderStyle>
                        </asp:GridView>
                    </div>
              
              <script>
                  $('#<%=Persona.ClientID%>').chosen();
                  $('#<%=personacargo.ClientID%>').chosen();
           
              </script>
    </form>
  <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
<script src='https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js'></script><script  src="../../SQEstilos/jseval.js"></script>

    <script type="text/javascript">
        function sig() {
            document.getElementById('btnsig').click();
        }

        function enviar() {
            document.getElementById('btnenviar').click();
        }
    </script>
</body>
</html>
