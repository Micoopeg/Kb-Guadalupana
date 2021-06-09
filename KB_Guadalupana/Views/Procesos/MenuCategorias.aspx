<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuCategorias.aspx.cs" Inherits="KB_Guadalupana.Views.Procesos.MenuCategorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap" rel="stylesheet"/>
    <title>Menú</title>
        <style>
         @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;400&display=swap');
        html{
            width:100%;
            height:100%;
        }

        body{
            font-family:"Montserrat";
        }

        .formularioCobros{
            display:flex;
            flex-direction:column;
            width:750px;
            justify-items: center;
            align-content: center;
            justify-content: center;
            align-items: center;
        }

        .general{
            display:flex;
            justify-content:center;
            align-content:center;
            align-items:flex-start;
            width:100%;
            height:auto;
            margin-top:35px;
        }

        .formato3{
            display:flex;
            flex-direction:column;
            width:100%;
            flex-wrap:wrap;
        }

      /*MENU*/
      .accordion {
          background-color: #eee;
          color: #444;
          cursor: pointer;
          padding: 18px;
          width: 100%;
          border: none;
          text-align: left;
          outline: none;
          font-size: 15px;
          transition: 0.4s;
        }

       .accordion2 {
          background-color: #eee;
          color: #444;
          cursor: pointer;
          padding: 18px;
          width: 100%;
          border: none;
          text-align: left;
          outline: none;
          font-size: 15px;
          transition: 0.4s;
        }

       .accordion2:hover {
          background-color: #ccc; 
        }

        .accordion3 {
          background-color: #eee;
          cursor: pointer;
          padding: 18px;
          width: 45%;
          border: none;
          text-align: left;
          outline: none;
          font-size: 15px;
          transition: 0.4s;
        }

       .accordion3:hover {
          background-color: #ccc; 
        }

        .active, .accordion:hover {
          background-color: #ccc; 
        }

        .panel {
          padding: 0 18px;
          display: none;
          background-color: white;
          overflow: hidden;
          width:100%;
        }
    </style>
</head>
<body>
    <div id="menu" runat="server" class="menu"></div>
    <form id="form1" runat="server">
            <div class="general">
        <div class="formularioCobros">
            <a class="accordion" runat="server">Gerencia Administrativa</a>
                    <div class="panel">
                      <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="formato3">
                                   <%-- <a id="subcategoria1" runat="server" class="accordion"> <%# Eval("Subcategoria") %> </a>--%>
                                    <asp:Button ID="subcategoria1" CssClass="accordion3" runat="server" OnClick="subcategoria1_Click" Text='<%# Eval("Subcategoria") %>'/>
                                </div><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                   <a class="accordion" runat="server">Gerencia de Negocios y Mercadeo</a>
                    <div class="panel">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <div class="formato3">
                                   <%-- <a id="subcategoria2" runat="server" class="accordion"> <%# Eval("Subcategoria") %> </a>--%>
                                      <asp:Button ID="subcategoria2" CssClass="accordion3" runat="server" OnClick="subcategoria2_Click" Text='<%# Eval("Subcategoria") %>'/>
                                </div><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                     <a class="accordion" runat="server">Gerencia Jurídica</a>
                    <div class="panel">
                      <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <div class="formato3">
                                   <%-- <a id="subcategoria3" runat="server" class="accordion"> <%# Eval("Subcategoria") %> </a>--%>
                                     <asp:Button ID="subcategoria3" CssClass="accordion3" runat="server" OnClick="subcategoria3_Click" Text='<%# Eval("Subcategoria") %>'/>
                                </div><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <a class="accordion" runat="server">Gerencia Financiera</a>
                    <div class="panel">
                        <asp:Repeater ID="Repeater4" runat="server">
                            <ItemTemplate>
                                <div class="formato3">
                                   <%-- <a id="subcategoria4" runat="server" class="accordion"> <%# Eval("Subcategoria") %> </a>--%>
                                     <asp:Button ID="subcategoria4" CssClass="accordion3" runat="server" OnClick="subcategoria4_Click" Text='<%# Eval("Subcategoria") %>'/>
                                </div><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <a class="accordion2" onclick="redirigir()" runat="server">Unidad de Cumplimiento</a>

                    <a class="accordion2" onclick="redirigir2()" runat="server">Comisión de Vigilancia</a>

                    <a class="accordion2" onclick="redirigir3()" runat="server">Gerencia General</a>

                    <a class="accordion2" onclick="redirigir4()" runat="server">Consejo de Administración</a>

                    <a class="accordion2" onclick="redirigir5()" runat="server">Auditoría Interna</a>

             <br /><br />

            <asp:LinkButton ID="categoria" runat="server" OnClick="categoria_Click" ClientIDMode="Static"></asp:LinkButton>
             <asp:LinkButton ID="categoria2" runat="server" OnClick="categoria2_Click" ClientIDMode="Static"></asp:LinkButton>
             <asp:LinkButton ID="categoria3" runat="server" OnClick="categoria3_Click" ClientIDMode="Static"></asp:LinkButton>
             <asp:LinkButton ID="categoria4" runat="server" OnClick="categoria4_Click" ClientIDMode="Static"></asp:LinkButton>
             <asp:LinkButton ID="categoria5" runat="server" OnClick="categoria5_Click" ClientIDMode="Static"></asp:LinkButton>
        </div>
               
    </div>
        <br /><br />
         <script>
             $(document).ready(function () {
                 $('.menu').load('MenuPrincipal.aspx');
             });
         </script>
    </form>
    <script type="text/javascript">
        function redirigir() {
            document.getElementById('categoria').click();
        }

        function redirigir2() {
            document.getElementById('categoria2').click();
        }

        function redirigir3() {
            document.getElementById('categoria3').click();
        }

        function redirigir4() {
            document.getElementById('categoria4').click();
        }

        function redirigir5() {
            document.getElementById('categoria5').click();
        }
    </script>
         
            <script>
                var acc = document.getElementsByClassName("accordion");
                var i;

                for (i = 0; i < acc.length; i++) {
                    acc[i].addEventListener("click", function () {
                        this.classList.toggle("active");
                        var panel = this.nextElementSibling;
                        if (panel.style.display === "block") {
                            panel.style.display = "none";
                        } else {
                            panel.style.display = "block";
                        }
                    });
                }
            </script>
</body>
</html>
