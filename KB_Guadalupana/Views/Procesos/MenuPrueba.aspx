<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrueba.aspx.cs" Inherits="KB_Guadalupana.Views.Procesos.MenuPrueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
.dropbtn {
  background-color: #04AA6D;
  color: white;
  padding: 16px;
  font-size: 16px;
  border: none;
}

.dropdown {
  position: relative;
  display: inline-block;
  flex-wrap:wrap;
  justify-content:space-between;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f1f1f1;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}

.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

.dropdown-content a:hover {background-color: #ddd;}

.dropdown:hover .dropdown-content {display: block;}

.dropdown:hover .dropbtn {background-color: #3e8e41;}

* {box-sizing: border-box}
body {font-family: "Lato", sans-serif;}

/* Style the tab */
.tab {
  float: left;
  border: 1px solid #ccc;
  background-color: #f1f1f1;
  width: 30%;
  height: 300px;
}

/* Style the buttons inside the tab */
.tab button {
  display: block;
  background-color: inherit;
  color: black;
  padding: 22px 16px;
  width: 100%;
  border: none;
  outline: none;
  text-align: left;
  cursor: pointer;
  font-size: 17px;
}

/* Change background color of buttons on hover */
.tab button:hover {
  background-color: #ddd;
}

/* Create an active/current "tab button" class */
.tab button.active {
  background-color: #ccc;
}

/* Style the tab content */
.tabcontent {
  float: left;
  padding: 0px 12px;
  border: 1px solid #ccc;
  width: 70%;
  border-left: none;
  height: 300px;
  display: none;
}

/* Clear floats after the tab */
.clearfix::after {
  content: "";
  clear: both;
  display: table;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
       <div  class="tab">
           <asp:Repeater ID="RepeaterCategoria" runat="server" OnItemDataBound="RepeaterCategoria_ItemDataBound" >
            <ItemTemplate>
          <button id="BotonCategoria" runat="server" class="tablinks" onmouseover="openCity(event, 'London')"><%# Eval("Categoria") %></button>
            </ItemTemplate>
            </asp:Repeater>
        </div>
<asp:Repeater ID="repeatercontenedor"  runat="server" OnItemDataBound="repeatercontenedor_ItemDataBound"> 
    <ItemTemplate>
        <asp:Label ID="control" runat="server" Visible="false"><%# Eval("Subcategoria") %> </asp:Label>
  <div id="London" runat="server" class="tabcontent">
      <h3>Gerencia Administrativa</h3>
 <asp:Repeater ID="RepeaterSubCategoria" runat="server">
     <ItemTemplate>
      
           
               
                    <div class="dropdown">
                  <label class="dropbtn"><%# Eval("Subcategoria") %></label>
                  <div class="dropdown-content">
                    <a href="#">Manual</a>
                    <a href="#">Política</a>
                    <a href="#">Otro</a>
                  </div>
                </div>
          
    
     </ItemTemplate>
            </asp:Repeater>

          </div>
        </ItemTemplate>
    </asp:Repeater>




        <div id="Paris" class="tabcontent">
          <h3>Paris</h3>
          <p>Paris is the capital of France.</p> 
        </div>

        <div id="Tokyo" class="tabcontent">
          <h3>Tokyo</h3>
          <p>Tokyo is the capital of Japan.</p>
        </div>


        <script>
            function openCity(evt, cityName) {
              var i, tabcontent, tablinks;
              tabcontent = document.getElementsByClassName("tabcontent");
              for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
              }
              tablinks = document.getElementsByClassName("tablinks");
              for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
              }
              document.getElementById(cityName).style.display = "block";
              evt.currentTarget.className += " active";
            }
        </script>

    </form>
</body>
</html>
