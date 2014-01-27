<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShopUI._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Clothes Management:</h3>
    <div id ="viewTab">
        <div>Status:
        <label id ="status" data-bind="text: status"></label></div>
         
          <table id="clothesProducts">
            <thead>
                <tr><th style="width:20px">ID</th>
                    <th>Code</th>
                    <th>Name</th>
                    <th>Price</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody data-bind="template: { name: 'products-template', foreach: clothesProducts }" >
            </tbody>           
               <tr>
                    <td style="width:20px"> </td>
                    <td><input type="text" title="Code" id="code2" /></td>
                    <td><input type="text" title="Name" id="name2" /></td>
                    <td><input type="number" title="Price" id="price2" /></td>
                    <td><a href="#" data-bind="click: create">Add</a></td>
                    <td></td>
                    <td></td>
               </tr>
        </table>
      
      
    </div>
   
    <div>
        
    </div>

</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1
        {
            width: 15px;
        }
        .auto-style5
        {
            width: 184px;
        }
        .auto-style6
        {
            width: 165px;
        }
        .auto-style7
        {
            width: 141px;
        }
        .auto-style8
        {
            width: 167px;
        }
        .auto-style9
        {
            width: 182px;
        }
        .auto-style10
        {
            width: 176px;
        }
    </style>
</asp:Content>

