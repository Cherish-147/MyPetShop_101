<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewProduct.ascx.cs" Inherits="UserControl_NewProduct" %>
<asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
  <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
  <RowStyle BackColor="#E3EAEB" />
  <Columns>
    <asp:TemplateField>
      <ItemTemplate>
        <asp:Image ID="imgArrow" runat="server" ImageUrl="~/Images/arrow.gif" />
      </ItemTemplate>
    </asp:TemplateField>
    <asp:HyperLinkField DataTextField="Name" DataTextFormatString="{0:c}" DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="~/ProShow.aspx?ProductId={0}" HeaderText="商品名称" />
    <asp:BoundField DataField="ListPrice" HeaderText="商品价格" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Width="90px">
<HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
      <ItemStyle HorizontalAlign="Center" />
      </asp:BoundField>
  </Columns>
  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
  <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
  <HeaderStyle BackColor="#ccccd4" Font-Bold="True" ForeColor="Black" />
  <EditRowStyle BackColor="#7C6F57" />
  <AlternatingRowStyle BackColor="White" />
</asp:GridView>
