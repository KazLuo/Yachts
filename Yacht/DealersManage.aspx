<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DealersManage.aspx.cs" Inherits="Yacht.DealersManage1"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:PlaceHolder ID="contentPlaceHolder" runat="server">
    <div class="card mt-4">
        <h6 class="card-header">Add/Edit Dealers</h6>
        <div class="card-body">
            <%--有form的情況下會導致內文被清空影響postback--%>
            <%--<form >--%>
                <div class="form-group">
                    <label class="form-label">Country</label>
                   <%-- <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="country" DataValueField="country" CssClass="custom-select"></asp:DropDownList>--%>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="country" DataValueField="id" CssClass="custom-select"></asp:DropDownList>
                    <div class="clearfix"></div>
                </div>
                <div class="form-group">
                    <label class="form-label">City</label>
                    <asp:TextBox runat="server" class="form-control" ID="cityTB" EnableViewState="True" />
                    <div class="clearfix"></div>
                </div>
                <div class="form-group">
                    <label class="form-label">Name</label>
                    <asp:TextBox runat="server" class="form-control" ID="nameTB" />
                    <div class="clearfix"></div>
                </div>
                <div class="form-group">
                    <label class="form-label">Company</label>
                    <asp:TextBox runat="server" class="form-control" ID="companyTB" />
                    <div class="clearfix"></div>
                </div>
                <div class="form-group">
                    <label class="form-label">Address</label>
                    <asp:TextBox runat="server" class="form-control" ID="addressTB" />
                    <div class="clearfix"></div>
                </div>
                <div class="form-group">
                    <label class="form-label">Tel</label>
                    <asp:TextBox runat="server" class="form-control" ID="telTB" />
                    <div class="clearfix"></div>
                </div>
                <div class="form-group">
                    <label class="form-label">Fax</label>
                    <asp:TextBox runat="server" class="form-control" ID="faxTB" />
                    <div class="clearfix"></div>
                </div>
                <div class="form-group">
                    <label class="form-label">Website</label>
                    <asp:TextBox runat="server" class="form-control" ID="websiteTB" />
                    <div class="clearfix"></div>
                </div>
                <div class="form-group">
                    <label class="form-label">Mail</label>
                    <asp:TextBox runat="server" class="form-control" ID="mailTB" placeholder="Email" />
                    <div class="clearfix"></div>
                </div>
                <div class="form-group">
                    <label class="form-label">Graphpath</label>
                    <asp:TextBox runat="server" class="form-control" ID="graphpathTB" ReadOnly="True" />
                    <div class="clearfix"></div>
                </div>

                <asp:Label ID="Label2" runat="server" CssClass="form-text text-muted"></asp:Label>

            <%--</form>--%>
            <div class="form-group">
                <label class="form-label w-100">File Upload</label>
                <asp:FileUpload ID="FileUpload1" runat="server" class="form-group" />
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" CssClass="btn btn-primary" />
            </div>
           <asp:Button ID="Button3" runat="server" Text="Upload" CssClass="btn btn-primary" OnClick="BtnAddOrUpdate_Click" />
        </div>
    </div>
    <div class="card-body">
    </div>

    <%--<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowEditing="GridView2_RowEditing" class="card mt-4" >
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" ReadOnly="True" />
            <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" ReadOnly="True" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" ReadOnly="True" />
            <asp:BoundField DataField="company" HeaderText="company" SortExpression="company" ReadOnly="True" />
            <asp:BoundField DataField="graphpath" HeaderText="graphpath" SortExpression="graphpath" ReadOnly="True" />
        </Columns>
    </asp:GridView>--%>

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowEditing="GridView2_RowEditing" class="card mt-4" OnRowDeleting="GridView2_RowDeleting" OnRowDataBound="GridView2_RowDataBound">
        <Columns>
             <asp:CommandField ShowDeleteButton="True" ButtonType="Button"  />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" ReadOnly="True" />
            <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" ReadOnly="True" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" ReadOnly="True" />
            <asp:BoundField DataField="company" HeaderText="company" SortExpression="company" ReadOnly="True" />
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# ConvertToRelativePath(Eval("graphpath").ToString()) %>' Height="100px" />
                    <!-- You can adjust the height as needed -->
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="HiddenFieldDealerID" runat="server" />
    <asp:HiddenField ID="hdnOperationMode" runat="server" Value="Add" />
    <asp:HiddenField ID="hdnSelectedDealerID" runat="server" />


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YachtConnectionString %>" SelectCommand="SELECT [country], [id], [initDate] FROM [Country]" DeleteCommand="DELETE FROM [Country] WHERE [id] = @id" UpdateCommand="UPDATE [Country] SET [country] = @country WHERE [id] = @id" InsertCommand="INSERT INTO [Country] ([country], [initDate]) VALUES (@country, @initDate)">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="country" Type="String" />
            <asp:Parameter Name="initDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="country" Type="String" />
            <asp:Parameter Name="initDate" Type="DateTime" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:YachtConnectionString %>" DeleteCommand="DELETE FROM [Dealers] WHERE [id] = @id" InsertCommand="INSERT INTO [Dealers] ([country], [city], [name], [company], [graphpath]) VALUES (@country, @city, @name, @company, @graphpath)" SelectCommand="SELECT [id], [country], [city], [name], [company], [graphpath] FROM [Dealers]" UpdateCommand="UPDATE [Dealers] SET [country] = @country, [city] = @city, [name] = @name, [company] = @company, [graphpath] = @graphpath WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="country" Type="Int32" />
            <asp:Parameter Name="city" Type="String" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="company" Type="String" />
            <asp:Parameter Name="graphpath" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="country" Type="Int32" />
            <asp:Parameter Name="city" Type="String" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="company" Type="String" />
            <asp:Parameter Name="graphpath" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
         </asp:PlaceHolder>
</asp:Content>
