<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="News Manage.aspx.cs" Inherits="Yacht.News_Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:PlaceHolder ID="contentPlaceHolder" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="GridView1_RowCommand" CssClass="table">
        <Columns>
             <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-primary" CommandArgument='<%# Eval("id") %>' />

                    <!-- You can adjust the height as needed -->
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="postDate" HeaderText="postDate" SortExpression="postDate" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
             <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# ConvertToRelativePath(Eval("graphpath").ToString()) %>' Height="100px" />
                    <!-- You can adjust the height as needed -->
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YachtConnectionString %>" SelectCommand="SELECT [id], [postDate], [title], [graphpath] FROM [News]"></asp:SqlDataSource>
         </asp:PlaceHolder>
</asp:Content>
