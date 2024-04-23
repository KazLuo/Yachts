<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewsCreate.aspx.cs" Inherits="Yacht.NewsCreat" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="contentPlaceHolder" runat="server">
    <div class="card mt-4">
        <h6 class="card-header">
            <asp:Literal ID="litHeader" runat="server" /></h6>
        <div class="card-body">
            <div class="form-group">
                <label class="form-label">Top</label>
                <asp:CheckBox ID="isTopTB" runat="server" />
                <div class="clearfix"></div>
            </div>
            <div class="form-group">
                <label class="form-label">PostDate</label>
                <asp:TextBox runat="server" class="form-control" ID="pstDateTB" EnableViewState="True" Placeholder="yyyy-MM-dd" />
                <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="pstDateTB" ErrorMessage="請輸入日期" Display="Dynamic" ForeColor="Red">不可為空</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revDate" runat="server" ControlToValidate="pstDateTB" ValidationExpression="^\d{4}-\d{2}-\d{2}$" ErrorMessage="日期格式必須為 yyyy-MM-dd" Display="Dynamic" ForeColor="Red">日期格式必須為 yyyy-MM-dd</asp:RegularExpressionValidator>
                <asp:TextBox ID="TextBox1" runat="server" Type="Date" ></asp:TextBox>
                <div class="clearfix"></div>
            </div>
            <div class="form-group">
                <label class="form-label">Title</label>
                <asp:TextBox runat="server" class="form-control" ID="titleTB" />
                <div class="clearfix"></div>
            </div>
            <div class="form-group">
                <label class="form-label">Title Content</label>
                <asp:TextBox runat="server" class="form-control" ID="titleContentTB" />
                <div class="clearfix"></div>
            </div>
            <div class="form-group">
                <label class="form-label">Content</label>
                <CKEditor:CKEditorControl ID="CKEditorControl1" BasePath="/Scripts/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                <div class="clearfix"></div>
            </div>
            <div class="form-group">
                <label class="form-label">Cover</label>
                <asp:TextBox runat="server" class="form-control" ID="graphpathTB" ReadOnly="True" />
                <div class="clearfix"></div>
            </div>

            <asp:Label ID="Label2" runat="server" CssClass="form-text text-muted"></asp:Label>

            <div class="form-group">
                <label class="form-label w-100">File Upload</label>
                <asp:FileUpload ID="FileUpload1" runat="server" class="form-group" />
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" CssClass="btn btn-primary" />
            </div>
            <asp:Button ID="Button3" runat="server" Text="Button" CssClass="btn btn-primary" OnClick="BtnAddOrUpdate_Click" />
            <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="BtnDelete_Click" Visible="false" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="Cancel_Click" CausesValidation ="false"/>
        </div>
    </div>
    <div class="card-body">
    </div>
        </asp:PlaceHolder>
</asp:Content>
