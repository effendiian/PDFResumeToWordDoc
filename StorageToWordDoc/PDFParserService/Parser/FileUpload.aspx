<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="PDFParserService.Parser.FileUpload" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" method="post" enctype="multipart/form-data" runat="server">
        <br />
        <div>
            <p>Please upload the resumes you'd like to test.</p>
        </div>
            <a href="Directory.aspx">See the files</a>
        <br />
        <hr />
        <div>
            <!-- File input -->
            <input type="file" dropzone="link" id="File1" name="File1" multiple="multiple" runat="server" />
            <br />
            <input type="submit" id="Submit1" value="Upload" name="Submit1" runat="server" />
            <input type="submit" id="Delete1" value="Clear" name="Delete1" runat="server" />
        </div>
    <asp:Label ID="Span1" runat="server"></asp:Label>
</asp:Content>
