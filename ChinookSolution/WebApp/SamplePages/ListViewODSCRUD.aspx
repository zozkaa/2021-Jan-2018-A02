﻿<%@ Page Title="List View ODS CRUD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListViewODSCRUD.aspx.cs" Inherits="WebApp.SamplePages.ListViewODSCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Single Record CRUD using ODS(only) : ListView</h1>
    <div class="row">
        <div class="offset-2">
            <blockquote class="alert alert-info"> 
                This sample will use the asp:ListView control. <br />
                This sample will use ObjectDataSource for the ListView control. <br />
                This sample will use minimal code behind. <br />
                This sample will use the course MessageUserControl for error handling. <br />
                This sample will use validation on the ListView control. 
            </blockquote>
        </div>
    </div>
    <div class="row">
        <asp:ListView ID="ListView1" runat="server"></asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
    </div>
</asp:Content>
