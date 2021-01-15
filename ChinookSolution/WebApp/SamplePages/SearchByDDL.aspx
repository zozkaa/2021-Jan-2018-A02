<%@ Page Title="Filter Search Demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByDDL.aspx.cs" Inherits="WebApp.SamplePages.SearchByDDL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Albums by Artist</h1>

    <%-- Search Area --%>
    <div class="row">
        <div class="offset-3">
            <asp:Label ID="Label1" runat="server" Text="Select an artist"></asp:Label> &nbsp;&nbsp;
            <asp:DropDownList ID="ArtistList" runat="server"></asp:DropDownList> &nbsp;&nbsp;
            <asp:LinkButton ID="SearchAlbums" runat="server" OnClick="SearchAlbums_Click"><i class="fa fa-search"></i> &nbsp; Search</asp:LinkButton>
        </div>
    </div>

    <br /><br />

    <div class="row">
        <div class="offset-3">
            <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="offset-3">
            <asp:GridView ID="ArtistAlbumList" runat="server" AutoGenerateColumns="False"
                CssClass="table table-striped"
                gridlines="Horizontal" BorderStyle="none">
                <Columns>
                    <asp:TemplateField HeaderText="Album">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Released">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Artist">
                            <ItemTemplate>
                                <asp:DropDownList ID="ArtistNameList" runat="server" DataSourceID="ArtistListODS" DataTextField="DisplayField" DataValueField="ValueField" selectedvalue='<%# Eval("ArtistId") %>' Width="400px">
                                </asp:DropDownList>
                            </ItemTemplate>
                    </asp:TemplateField>                   
                </Columns>
                <EmptyDataTemplate>
                    No albums for selected artist 
                </EmptyDataTemplate>
            </asp:GridView>
            
            <asp:ObjectDataSource ID="ArtistListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artist_DDLList" TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
        </div>
    </div>


</asp:Content>
