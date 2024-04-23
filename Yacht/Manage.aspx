<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ApplyLayout2.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="card-block p-b-10">
                    <div class="table-responsive">
                        <div class="input-group mb-3">
                            <asp:TextBox ID="TBoxAddAccount" runat="server" type="text" class="form-control" placeholder="Account" ></asp:TextBox>
                            <asp:TextBox ID="TBoxAddPassword" runat="server" type="text" class="form-control" placeholder="Password" TextMode="Password" ></asp:TextBox>
                            <div class="input-group-append">
                                <asp:Button ID="BtnAddAccount" runat="server" Text="Add" class="btn btn-outline-primary btn-block" OnClick="BtnAddAccount_Click" />
                            </div>
                        </div>
                        <asp:Label ID="LabelAdd" runat="server" Visible="False"><span class="badge badge-pill badge-warning text-dark">* 使用者名稱重複，請重新輸入 !</span></asp:Label>
                    </div>
                </div>
    <div class="table" style="display: flex; display: flex;">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" CssClass="thead-dark" GridLines="None" OnDataBound="OnDataBind" >
        <Columns>
            <%--<asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />--%>
           <%-- <asp:TemplateField ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>--%>
            <asp:TemplateField ShowHeader="False">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"></asp:LinkButton>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
    </EditItemTemplate>
</asp:TemplateField>




            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="uname" HeaderText="uname" SortExpression="uname" />
            <asp:BoundField DataField="mail" HeaderText="mail" SortExpression="mail" />
            <asp:BoundField DataField="pw" HeaderText="pw" SortExpression="pw" />
            <asp:BoundField DataField="salt" HeaderText="salt" SortExpression="salt" />
            <asp:BoundField DataField="permission" HeaderText="permission" SortExpression="permission" />
        </Columns>
    </asp:GridView>
        </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LayoutAccountConnectionString %>" SelectCommand="SELECT [id], [uname], [mail], [pw], [salt], [permission] FROM [account]" DeleteCommand="DELETE FROM [account] WHERE [id] = @id" InsertCommand="INSERT INTO [account] ([uname], [mail], [pw], [salt], [permission]) VALUES (@uname, @mail, @pw, @salt, @permission)" UpdateCommand="UPDATE [account] SET [uname] = @uname, [mail] = @mail, [pw] = @pw, [salt] = @salt, [permission] = @permission WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="uname" Type="String" />
            <asp:Parameter Name="mail" Type="String" />
            <asp:Parameter Name="pw" Type="String" />
            <asp:Parameter Name="salt" Type="String" />
            <asp:Parameter Name="permission" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="uname" Type="String" />
            <asp:Parameter Name="mail" Type="String" />
            <asp:Parameter Name="pw" Type="String" />
            <asp:Parameter Name="salt" Type="String" />
            <asp:Parameter Name="permission" Type="Int32" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
        
</asp:SqlDataSource>
    </asp:Content>
