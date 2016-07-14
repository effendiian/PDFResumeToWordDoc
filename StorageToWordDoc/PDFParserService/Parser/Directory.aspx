<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Directory.aspx.cs" Inherits="PDFParserService.Parser.Directory" %>

<%@ Import Namespace="System.IO" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <% foreach (var dir in new DirectoryInfo(Server.MapPath("~/")).GetDirectories()) { %>
        <div>Directory: <%= dir.Name %></div>
        <br />
        <% if(dir.GetFiles().Length > 0) { %>    
            <% foreach (var file in dir.GetFiles()) { %>
                <%= file.Name %><br />
            <% } %>
        <br />
            <% } %>
        <% } %>
</asp:Content>