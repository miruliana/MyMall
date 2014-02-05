<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShopUI.Account.Login" %>
<asp:Content ID="LoginContent" ContentPlaceHolderID="MainContent" runat="server">
     <header>
        <div class="content-wrapper">
          
            <div class="float-left">
                <section id="login">
                            <ul>
                                <li><a id="registerLink" runat="server" href="~/Register.aspx">Register</a></li>
                                <li><a id="loginLink" runat="server" href="~/Login.aspx">Log in</a></li>
                            </ul>
                </section>
            </div>
        </div>
    </header>
    <div id="body">
    <section class="content-wrapper main-content" >
       <div>
          
            <div>
        <table>
            
            <tr>
                <td>Username: </td>
                <td><input type ="text" id ="username"/></td>
            </tr>
            <tr>
                <td>Password: </td>
                <td> <input type ="password" id ="password"/></td>
            </tr>
              <tr style="height: 30px">
                <td colspan="2"></td>
            </tr>
            <tr><td colspan="2" class="centered"> <input type="button" value="Login"  data-bind="click: login" /></td></tr>
        </table>
            </div>
            </div>
         <span class ="centered">
            <p id ="P2" class="errorMessage"  data-bind="text: errorLoginMessage" ></p>
           </span>
   </section>
        </div>
</asp:Content>
