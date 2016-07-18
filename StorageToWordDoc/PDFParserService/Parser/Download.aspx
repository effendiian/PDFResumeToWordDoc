<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="PDFParserService.Parser.Download" %>

<%@ Import Namespace="System.IO" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <br />
    <br />
    <br />
    <br />
    <br />

    <% foreach (var dir in new DirectoryInfo(Server.MapPath("~/")).GetDirectories()) { %>
       
        <% if(dir.GetFiles().Length > 0 && dir.Name == "Data") { %>    
           <div>Directory: <%= dir.Name %></div>
            <br />
            <% foreach (var file in dir.GetFiles()) { %>
                <%= file.Name %><br />
            <% } %>
        <br />
            <% } %>
        <% } %>
    
        <div>
            <!-- File input -->
             <asp:DropDownList ID="DropDownList1" runat="server">
             </asp:DropDownList>
            <br />
            <input type="submit" id="Submit1" value="Download" name="Submit1" runat="server" />
        </div>
     
         <asp:Label ID="Span1" runat="server"></asp:Label>
        <asp:Label ID="Span2" runat="server"></asp:Label>
</asp:Content>