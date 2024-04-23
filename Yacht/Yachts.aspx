<%@ Page Title="" Language="C#" MasterPageFile="~/YachtsPage.Master" AutoEventWireup="true" CodeBehind="Yachts.aspx.cs" Inherits="Yacht.Yachts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--------------------------------內容開始---------------------------------------------------->
    <!--次選單-->
<div class="menu_y">
    <ul>
        <li class="menu_y00">YACHTS</li>
        <li><a class="menu_yli01" href='<%= "Yachts.aspx?id=" + Request.QueryString["id"] %>'>Yachts.aspx</a></li>
        <li><a class="menu_yli02" href='<%= "YachtsLayout.aspx?id=" + Request.QueryString["id"] %>'>Layout & deck plan</a></li>
        <li><a class="menu_yli03" href='<%= "YachtsSpec.aspx?id=" + Request.QueryString["id"] %>'>Specification</a></li>
    </ul>
</div>

    <div class="box2_list">
        <ul>
            <asp:Literal ID="YachtsContent" runat="server"></asp:Literal>
        </ul>
        <%--<div class="pagenumber">
           <uc1:WebUserControl_Page runat="server" ID="WebUserControl_Page" />
        </div>--%>
    </div>

    <!--次選單-->

    <p class="topbuttom">
        <img src="Yatchassets/images/top.gif" alt="top" />
    </p>

    <!--下載開始-->
    <div class="downloads">
        <p>
            <img src="Yatchassets/images/downloads.gif" alt="&quot;&quot;" />
        </p>
        <ul>
            <li><a href="#">Downloads 001</a></li>
            <li><a href="#">Downloads 001</a></li>
            <li><a href="#">Downloads 001</a></li>
            <li><a href="#">Downloads 001</a></li>
            <li><a href="#">Downloads 001</a></li>

        </ul>
    </div>
    <!--下載結束-->
    <!--------------------------------內容結束------------------------------------------------------>
</asp:Content>
