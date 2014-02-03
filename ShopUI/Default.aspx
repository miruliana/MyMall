<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShopUI._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Clothes Management:</h3>
    <div id ="viewTab">
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
                  <td colspan="8" class="inline"><button data-bind="click: $root.previousPage, disable : (currentPageIndex() == 0)"><</button>
                      Page&nbsp;<label data-bind="text: $root.currentPageIndex() + 1" class="inlineLabel"></label>
                   <button data-bind="click: $root.nextPage, disable : (((currentPageIndex() + 1) * pageSize()) >= clothesProducts().length)">></button>
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

</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>

