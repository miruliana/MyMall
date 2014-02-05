<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ShopUI.Account.Register" %>

<asp:Content ID="RegisterContent" ContentPlaceHolderID="MainContent" runat="server">
     <header>
        <div class="content-wrapper">
          
            <div class="float-left">
                <section id="login">
                            <ul>
                                <li><a id="registerLink" runat="server" href="~/Account/Register.aspx">Register</a></li>
                                <li><a id="loginLink" runat="server" href="~/Account/Login.aspx">Log in</a></li>
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
                <td>Username</td>
                <td><input type ="text" id ="username1" /></td>
            </tr>
            <tr>
                <td>Email</td>
                <td><input type ="text" id ="email1" /></td>
            </tr>
             <tr>
                <td>Password</td>
                <td><input type ="password" id ="password1" /></td>
            </tr>
              <tr>
                <td>Confirm password</td>
                <td><input type ="password" id ="password2" /></td>
            </tr>
             <tr style="height: 30px">
                <td colspan="2"></td>
            </tr>
            <tr><td colspan="2" class="centered"> <input type="button" value="Register"  data-bind="click: register" /></td></tr>
        </table>
            </div>
            </div>
        <span class ="centered">
            <p id ="P1" class="errorMessage"  data-bind="text: errorRegisterMessage" ></p>
           </span>
        </section>
        </div>
</asp:Content>
