<%@ Page Title="" Language="C#" MasterPageFile="~/YachtsPage.Master" AutoEventWireup="true" CodeBehind="YachtsLayout.aspx.cs" Inherits="Yacht.YachtsLayout" %>

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
    <div class="box6">
        <p>Layout &amp; deck plan</p>
        <ul>
            <li>
                <asp:Image ID="Image1" runat="server" />
            <li>
                <asp:Image ID="Image2" runat="server" />
        </ul>
    </div>
</asp:Content>

