<%@ Page Title="" Language="C#" MasterPageFile="~/YachtsPage.Master" AutoEventWireup="true" CodeBehind="YachtsSpec.aspx.cs" Inherits="Yacht.YachtsSpec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="menu_y">
    <ul>
        <li class="menu_y00">YACHTS</li>
        <li><a class="menu_yli01" href='<%= "Yachts.aspx?id=" + Request.QueryString["id"] %>'>Yachts.aspx</a></li>
        <li><a class="menu_yli02" href='<%= "YachtsLayout.aspx?id=" + Request.QueryString["id"] %>'>Layout & deck plan</a></li>
        <li><a class="menu_yli03" href='<%= "YachtsSpec.aspx?id=" + Request.QueryString["id"] %>'>Specification</a></li>
    </ul>
</div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
