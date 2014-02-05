<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShopUI._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     <header>
        <div class="content-wrapper"  data-bind =" visible : isAuthenticated()">
          
            <div class="float-left">
                <section id="login" >
                            <ul>
                                <li><a id="loginLink" runat="server" href="~/LogIn.aspx" data-bind ="click : logout">Log out</a></li>
                            </ul>
                </section>
                <nav>
                   <ul id="menu">
                        <li><a id="clothesLink" runat="server" href="~/Default.aspx">Clothes</a></li>
                    </ul>
                </nav>
            </div>
        </div>
    </header>
     <div id="body">
     <section class="content-wrapper main-content" >
    <%--<p  class="centered" style="color: red">Unauthorized access!</p>--%>
    <div id ="viewTab" data-bind =" visible : isAuthenticated()">
         <h3>Clothes Management:</h3>
        <div>
        <p id ="status" class="errorMessage"  data-bind="text: errorMessage"></p></div>
          
          <table id="clothesProducts">
          <thead>
                <tr>
                    <th>Code</th>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Brand</th>
                    <th>Category</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody data-bind="template: { name: 'products-template', foreach: topTweets }" >
            </tbody>  
               <tfoot>
                <tr>
                  <td colspan="8"><p class="centered"><button data-bind="click: $root.previousPage, disable : (currentPageIndex() == 0)"><</button>
                      Page&nbsp;<label data-bind="text: $root.currentPageIndex() + 1" class="inlineLabel"></label>
                   <button data-bind="click: $root.nextPage, disable : (((currentPageIndex() + 1) * pageSize()) >= clothesProducts().length)">></button></p>
                  </td>
                </tr>
            </tfoot>   
               <tr>
                    <td><input type="text" title="Code" id="code2" maxlength="10" /></td>
                    <td><input type="text" title="Name" id="name2"  maxlength="255"/></td>
                    <td><input type="text" title="Price" id="price2" /></td>
                    <td>
                           <input data-bind="autoComplete: brands, value: myBrandSelectedOption, optionsText: 'Name', optionsValue: 'Id', autoCompleteOptions: {autoFocus: false}" id = "brand2" /> 
                    </td>
                     <td>
                           <input data-bind="autoComplete: categories, value: myCategorySelectedOption, optionsText: 'Name', optionsValue: 'Id', autoCompleteOptions: {autoFocus: false}" id = "category2" /> 
                    </td>
                    <td><a href="#" data-bind="click: create">Add</a></td>
                    <td>
                      
                    </td>
                    <td></td>
               </tr>
        </table>
       
    </div>
   
    <div>
        
    </div>
   </section>
   </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>

