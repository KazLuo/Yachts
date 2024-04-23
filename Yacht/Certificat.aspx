<%@ Page Title="" Language="C#" MasterPageFile="~/Company.Master" AutoEventWireup="true" CodeBehind="Certificat.aspx.cs" Inherits="Yacht.Certificat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="crumb">
        </asp:GridView>
              <a href="index.aspx">Home</a> >> <a href="AboutUs.aspx">Company  </a>>> <a href="#"><span class="on1">Certificat</span></a>
    </div>
    <div class="right">
        <div class="right1">
            <div class="title"><span>Certificat</span></div>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <%--<asp:GridView ID="GridView1" runat="server"></asp:GridView>--%>
            
            <br />
            <asp:ListView ID="ListView1" runat="server" GroupItemCount="3">
                <AlternatingItemTemplate>
                    <td runat="server" style="">
                        <%--<asp:Label ID="certfilepathLabel" runat="server" Text='<%# Eval("certfilepath") %>' />--%>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("certfilepath") %>'  Width="50%" />
                        <br /></td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="">certfilepath:
                        <asp:TextBox ID="certfilepathTextBox" runat="server" Text='<%# Bind("certfilepath") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                        <br /></td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
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
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="">
                        <%--<asp:Label ID="certfilepathLabel" runat="server" Text='<%# Eval("certfilepath") %>' />--%>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("certfilepath") %>'  Width="50%" />
                        <br /></td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style=""></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="">certfilepath:
                        <asp:Label ID="certfilepathLabel" runat="server" Text='<%# Eval("certfilepath") %>' />
                        <br /></td>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YachtConnectionString %>" SelectCommand="SELECT [certfilepath] FROM [Cert]"></asp:SqlDataSource>

            
</asp:Content>
