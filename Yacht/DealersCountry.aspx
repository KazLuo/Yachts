<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DealersCountry.aspx.cs" Inherits="Yacht.DealersCountry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="contentPlaceHolder" runat="server">
         <div class="card mt-4">
        <h6 class="card-header">Add Conutry</h6>
        <div class="card-body">
            <%--<form>--%>
                <div class="form-group">
                    <label class="form-label">Please enter the name of the country</label>
                    <asp:TextBox ID="Addcountry" runat="server" placeholder="ex:USA" CssClass="form-control"></asp:TextBox>
                    <div class="clearfix"></div>
                </div>
                <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Button1_Click" />
            <%--</form>--%>
            <asp:GridView ID="GridView1" CssClass="table table-striped mt-4" runat="server" DataKeyNames="id" DataSourceID="SqlDataSource1" >
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="initDate" HeaderText="initDate" SortExpression="initDate" ConvertEmptyStringToNull="False" ReadOnly="True" />--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    
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
