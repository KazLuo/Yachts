<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DealersCreate.aspx.cs" Inherits="Yacht.DealersCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="contentPlaceHolder" runat="server">
    <div class="card mt-4">
        <h6 class="card-header">Add Dealers</h6>
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
        </asp:PlaceHolder>
</asp:Content>
