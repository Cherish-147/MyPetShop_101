﻿<%@ Page Title="商品管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductMaster.aspx.cs" Inherits="Admin_ProductMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <a href="CategoryMaster.aspx">分类管理</a>
  <br />
  <br />
  <a href="SupplierMaster.aspx">供应商管理</a>
  <br />
  <br />
  <a href="ProductMaster.aspx">商品管理</a>
  <br />
  <br />
  <a href="OrderMaster.aspx">订单管理</a>
  <br />
  <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
  <a href="AddPro.aspx">添加商品</a>
  <br />
  <asp:Panel ID="pnlProduct" runat="server">
    <asp:GridView ID="gvProduct" runat="server" Width="100%" AutoGenerateColumns="false" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvProduct_PageIndexChanging" PagerSettings-Mode="NextPrevious">
      <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPrevious" NextPageText="下一页"
        Position="TopAndBottom" PreviousPageText="上一页" />
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
            <asp:CheckBox ID="chkChoice" runat="server" />
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="ProductId" HeaderText="商品ID" />
        <asp:HyperLinkField DataTextField="Name" DataTextFormatString="{0:c}" DataNavigateUrlFields="ProductId"
          DataNavigateUrlFormatString="~/Admin/ProductSub.aspx?ProductId={0}" HeaderText="商品名称" />
        <asp:BoundField DataField="ListPrice" HeaderText="商品价格" DataFormatString="{0:c}" />
        <asp:BoundField DataField="Qty" HeaderText="库存" />
      </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnDelete" runat="server" Text="删除商品" OnClick="btnDelete_Click" />
  </asp:Panel>
  <asp:Label ID="lblProErr" runat="server"></asp:Label>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="Server">
</asp:Content>


