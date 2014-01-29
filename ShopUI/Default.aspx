﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShopUI._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Clothes Management:</h3>
    <div id ="viewTab">
        <div>
        <label id ="status" data-bind="text: status" hidden="hidden" ></label></div>
      
          <table id="clothesProducts">
          
            <thead>
                <tr>
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
                   
                    <td><input type="text" title="Code" id="code2" maxlength="10" /></td>
                    <td><input type="text" title="Name" id="name2"  maxlength="255"/></td>
                    <td><input type="text" title="Price" id="price2" /></td>
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
    </asp:Content>

