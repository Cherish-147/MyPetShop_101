<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="test2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:GridView ID="gvproduct" runat="server" AutoGenerateColumns="False" AllowPaging="True"
         DataSourceID="ldsproduct" DataKeyNames="ProductId" PageSize="5" 
        OnRowDataBound="gvproduct_RowDataBound" 
        OnSelectedIndexChanged="gvproduct_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="CheckBoxAll" runat="server" AutoPostBack="True" Text="全选" OnCheckedChanged="CheckBoxAll_CheckedChanged" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkItem" runat="server" Text="checkitem111" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="商品编号" ReadOnly="True" InsertVisible="False" DataField="ProductId" />
            <asp:TemplateField HeaderText="商品分类编号">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlcategoryID" runat="server"
                        AutoPostBack="True" DataValueField="CategoryId"
                        DataSourceID="ldsCategory" DataTextField="Name" 
                        SelectedValue='<%# Bind("CategoryId") %>'>
                    </asp:DropDownList>
                    <asp:LinqDataSource ID="ldsCategory" runat="server" 
                        ContextTypeName="MyPetShop.DAL.MyPetShopDataContext" EntityTypeName="" 
                        TableName="Category"></asp:LinqDataSource>
                </EditItemTemplate>
                <FooterTemplate>
                    &nbsp;
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCategoryid" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ListPrice" HeaderText="商品价格" />
            <asp:BoundField DataField="Name" HeaderText="商品名称" />
            <asp:BoundField DataField="Qty" HeaderText="库存" />
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
        </Columns>
        
    </asp:GridView>
    <asp:LinqDataSource ID="ldsproduct" runat="server" 
        ContextTypeName="MyPetShop.DAL.MyPetShopDataContext" EnableUpdate="True" EntityTypeName="" 
        TableName="Product" EnableDelete="True"></asp:LinqDataSource>
    <asp:Button ID="btnSubmit" runat="server" Text="确定" OnClick="btnSubmit_Click" />
    <asp:Label ID="lblproductId" runat="server" ></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

