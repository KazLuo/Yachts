<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="YachtsManage.aspx.cs" Inherits="Yacht.YachtsManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="contentPlaceHolder" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" DataKeyNames="id" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="false"  Text="EDIT" CommandName="Edit" CssClass="btn btn-primary" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="model" HeaderText="model" SortExpression="model" />
            <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
            <asp:CheckBoxField DataField="newBuild" HeaderText="newBuild" SortExpression="newBuild" />
            <asp:CheckBoxField DataField="newDesign" HeaderText="newDesign" SortExpression="newDesign" />
            <asp:CheckBoxField DataField="top" HeaderText="top" SortExpression="top" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YachtConnectionString %>" SelectCommand="SELECT [id], [model], [type], [newBuild], [newDesign], [top] FROM [Yachts]"></asp:SqlDataSource>
        </asp:PlaceHolder>
</asp:Content>
