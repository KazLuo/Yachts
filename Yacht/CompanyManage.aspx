<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CompanyManage.aspx.cs" Inherits="ApplyLayout2.YachtsManage" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="contentPlaceHolder" runat="server">
    <div>
        <h2>About US:</h2>
        <h3>Content :</h3>
        <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/Scripts/ckeditor/" Height="300px " Width="600px"></CKEditor:CKEditorControl>
        <asp:Label ID="UploadAboutUsLab" runat="server" Visible="false" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
        <asp:Button ID="UploadAboutUsBtn" runat="server" Text="Upload About Us Content" class="btn btn-outline-primary btn-block mt-3" OnClick="UploadAboutUsBtn_Click" Width="200px" />
    </div>
    <div>
        <div>
            <h2>Certificat:</h2>
            <h3>Content :</h3>
            <asp:TextBox ID="certificatTbox" runat="server" type="text" class="form-control" placeholder="Enter certificat text" TextMode="MultiLine" Height="300px"></asp:TextBox>
            <asp:Label ID="uploadCertificatLab" runat="server" Visible="False" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
            <asp:Button ID="uploadCertificatBtn" runat="server" Text="Upload Certificat Text" class="btn btn-outline-primary btn-block mt-3" OnClick="uploadCertificatBtn_Click" />
        </div>
        <div style="padding-top: 50px;">
            <h6>Upload Vertical Group Image :</h6>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <div class="input-group my-3">
                <asp:FileUpload ID="imageUploadV" runat="server" class="form-group" AllowMultiple="True" />

                <asp:Button ID="UploadVBtn" runat="server" Text="Upload" class="btn btn-outline-primary btn-block mt-3" OnClick="UploadVBtn_Click" />
            </div>
            <h6>Vertical Image List :</h6>
            <%--<asp:RadioButtonList ID="RadioButtonListV" runat="server" class="my-3 mx-auto" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListV_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatColumns="3" CellPadding="10" Width="132px"></asp:RadioButtonList>--%>
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" DataSourceID="SqlDataSource1" GroupItemCount="3">
                <AlternatingItemTemplate>
                    <td runat="server" style="background-color: transparent; border-color: #716aca;">
                        <asp:Image ImageUrl='<%# Eval("certfilepath") %>' runat="server" Width="100px" />
                        <%--<asp:Label ID="certfilepathLabel" runat="server" Text='<%# Eval("certfilepath") %>' />--%>
                        <br />
                        <%--  id:
                        <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                        <br />--%>
                        <br />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" class="btn btn-danger btn-sm" />
                        <br />
                    </td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="background-color: #008A8C; color: #FFFFFF;">certfilepath:
                        <asp:TextBox ID="certfilepathTextBox" runat="server" Text='<%# Bind("certfilepath") %>' />
                        <br />
                        id:
                        <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                        <br />
                    </td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;" runat="server">
                        <tr>
                            <td>未傳回資料。</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <InsertItemTemplate>
                    <td runat="server" style="">certfilepath:
                        <asp:TextBox ID="certfilepathTextBox" runat="server" Text='<%# Bind("certfilepath") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                        <br />
                    </td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="background-color: transparent; color: #000000; border-color: #716aca;">
                        <asp:Image ImageUrl='<%# Eval("certfilepath") %>' runat="server" Width="100px" />
                        <%-- <asp:Label ID="certfilepathLabel" runat="server" Text='<%# Eval("certfilepath") %>' />--%>
                        <br />
                        <%--id:
                        <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />--%>
                        <br />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" class="btn btn-danger btn-sm" />
                        <br />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: transparent; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif; width: 400px;">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: transparent; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">certfilepath:
                        <asp:Label ID="certfilepathLabel" runat="server" Text='<%# Eval("certfilepath") %>' />
                        <br />
                        id:
                        <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                        <br />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
                        <br />
                    </td>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:Button ID="DelVImageBtn" runat="server" Text="Delete Image" type="button" class="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete？')" Visible="False" OnClick="DelVImageBtn_Click" />
        </div>
    </div>
    



                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YachtConnectionString %>" SelectCommand="SELECT [certfilepath], [id] FROM [Cert]" DeleteCommand="DELETE FROM [Cert] WHERE [id] = @id" InsertCommand="INSERT INTO [Cert] ([certfilepath]) VALUES (@certfilepath)" UpdateCommand="UPDATE [Cert] SET [certfilepath] = @certfilepath WHERE [id] = @id">
                    <DeleteParameters>
                        <asp:Parameter Name="id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="certfilepath" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="certfilepath" Type="String" />
                        <asp:Parameter Name="id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
        </asp:PlaceHolder>
</asp:Content>
