<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PDFParserService._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Resume Parser</h1>
        <p class="lead">This program takes a PDF or Word document and attempts to parse its information in order to format it.</p>
        <p><a href="#" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Test the API</h2>
            <p>
                Test the API by using a series of practiced documents.
            </p>
            <p>
                <a class="btn btn-default" href="#">Test here. &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
