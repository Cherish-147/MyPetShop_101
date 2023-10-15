<%@ Page Title="历史订单" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="OrderList" %>

<%@ Register Src="UserControl/PetTree.ascx" TagName="PetTree" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc:PetTree runat="server" ID="PetTree1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
  <asp:GridView ID="gvOrderItem" runat="server" AutoGenerateColumns="False">
    <Columns>
      <asp:BoundField DataField="OrderId" HeaderText="订单号" />
      <asp:BoundField DataField="CustomerId" HeaderText="用户号" />
      <asp:BoundField DataField="UserName" HeaderText="用户名" />
      <asp:BoundField DataField="OrderDate" HeaderText="订单时间" />
      <asp:BoundField DataField="Addr1" HeaderText="用户地址" />
      <asp:BoundField DataField="City" HeaderText="城市" />
      <asp:BoundField DataField="Zip" HeaderText="邮编" />
      <asp:BoundField DataField="Phone" HeaderText="电话" />
      <asp:BoundField DataField="Status" HeaderText="状态" />
    </Columns>
    <HeaderStyle VerticalAlign="Middle" />
  </asp:GridView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="Server">
</asp:Content>
