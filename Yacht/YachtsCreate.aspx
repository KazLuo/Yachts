<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="YachtsCreate.aspx.cs" Inherits="Yacht.YachtsCreate" %>
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
                <asp:CheckBox ID="isTopTB" runat="server" style="margin-right:10px"/>
                <label class="form-label">New Build</label>
                <asp:CheckBox ID="isNewBuildTB" runat="server" style="margin-right:10px" />
                <label class="form-label">New Design</label>
                <asp:CheckBox ID="isNewDesignTB" runat="server" style="margin-right:10px" />
                <div class="clearfix"></div>
            </div>
            <div class="form-group">
                <label class="form-label">Model</label>
                <asp:TextBox runat="server" class="form-control" ID="modelTB" EnableViewState="True" Placeholder="ex.Tayana" />
                <div class="clearfix"></div>
            </div>
              <div class="form-group">
                <label class="form-label">Type</label>
                <asp:TextBox runat="server" class="form-control" ID="typeTB" EnableViewState="True" Placeholder="ex.58" />
                <div class="clearfix"></div>
            </div>
            <div class="form-group">
                <label class="form-label">Overview Content</label>
                <CKEditor:CKEditorControl ID="CKEditorControl1" BasePath="/Scripts/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                <div class="clearfix"></div>
            </div>
             <div class="form-group">
                <label class="form-label">Dimensions</label>
                <CKEditor:CKEditorControl ID="CKEditorControl2" BasePath="/Scripts/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                <div class="clearfix"></div>
            </div>
             <div class="form-group">
                <label class="form-label">Specification</label>
                <CKEditor:CKEditorControl ID="CKEditorControl3" BasePath="/Scripts/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                <div class="clearfix"></div>
            </div>
            <asp:Label ID="Label2" runat="server" CssClass="form-text text-muted"></asp:Label>

            <div class="form-group">
                <label class="form-label w-100">Layout Top</label>
                 <asp:TextBox runat="server" class="form-control" ID="layouttopTB" EnableViewState="True"  />
                <asp:FileUpload ID="FileUpload1" runat="server" class="form-group" />
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="layouttop_Click" CssClass="btn btn-primary" />
            </div>
            <div class="form-group">
                <label class="form-label w-100">Layout bottom</label>
                 <asp:TextBox runat="server" class="form-control" ID="layoutbottomTB" EnableViewState="True"  />
                <asp:FileUpload ID="FileUpload2" runat="server" class="form-group" />
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="layoutbottom_Click" CssClass="btn btn-primary" />
            </div>
                 <div class="form-group">
                <label class="form-label w-100">Yachts Banner</label>
                 <asp:TextBox runat="server" class="form-control" ID="bannerpathTB" EnableViewState="True"  />
                <asp:FileUpload ID="FileUpload3" runat="server" class="form-group" />
                <asp:Button ID="Button4" runat="server" Text="Submit"  OnClick="UploadBanner_Click" CssClass="btn btn-primary" />
            </div>
            <asp:Button ID="Button3" runat="server" Text="Button" CssClass="btn btn-primary" OnClick="BtnAddOrUpdate_Click" />
            <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="BtnDelete_Click" Visible="false" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="Cancel_Click" CausesValidation ="false"/>
        &nbsp;</div>
    </div>
    <div class="card-body">
    </div>
        </asp:PlaceHolder>
</asp:Content>
