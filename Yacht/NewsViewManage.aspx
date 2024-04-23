<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewsViewManage.aspx.cs" Inherits="Yacht.NewsViewManage" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>News</h2>
        <h3>內文修改 :</h3>
        <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/Scripts/ckeditor/" Height="300px " Width="600px"></CKEditor:CKEditorControl>
        <asp:Label ID="UploadAboutUsLab" runat="server" Visible="false" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
        <asp:Button ID="UploadAboutUsBtn" runat="server" Text="Upload " class="btn btn-outline-primary btn-block mt-3" OnClick="UploadAboutUsBtn_Click" Width="200px" />
    </div>
</asp:Content>
