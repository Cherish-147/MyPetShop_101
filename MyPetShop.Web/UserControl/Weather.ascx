<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Weather.ascx.cs" Inherits="UserControl_Weather" %>
<table style="width: 100%; border: 0; padding-right: 2px; padding-left: 2px; margin-right: 2px; margin-left: 2px;">
  <tr>
    <td>
      <strong>选择省/洲&nbsp; </strong>
      <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
      </asp:DropDownList>
      <strong>&nbsp; 选择城市</strong>&nbsp;&nbsp;
        <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
        </asp:DropDownList>
      &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCity" runat="server" ForeColor="#CC0033" />
    </td>
  </tr>
  <tr>
    <td>
      <strong>今日实况&nbsp; </strong>
      <asp:Label ID="lblNow" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <strong>天气预报</strong><span style="color: #FF0033">(今天)</span>&nbsp;&nbsp;
        <asp:Label ID="lblToday" runat="server" />
      &nbsp;&nbsp;&nbsp;
        <asp:Image ID="imgWeathertrendsTdS" runat="server" AlternateText="icon" ImageAlign="AbsMiddle" />
      &nbsp;&nbsp;&nbsp;
        <asp:Image ID="imgWeathertrendsTdE" runat="server" AlternateText="icon" ImageAlign="AbsMiddle" />&nbsp;
    </td>
  </tr>
  <tr>
    <td>
      <strong>天气预报</strong><span style="color: #3333FF">(明天)</span>&nbsp;&nbsp;
        <asp:Label ID="lblTomorrow" runat="server" />
      &nbsp;&nbsp;&nbsp;
        <asp:Image ID="imgWeathertrendsTmS" runat="server" AlternateText="icon" ImageAlign="AbsMiddle" />
      &nbsp;&nbsp;&nbsp;
        <asp:Image ID="imgWeathertrendsTmE" runat="server" AlternateText="icon" ImageAlign="AbsMiddle" />
    </td>
  </tr>
  <tr>
    <td>
      <strong>天气预报</strong><span style="color: #006633">(后天)</span>&nbsp;&nbsp;
        <asp:Label ID="lblAfterTmr" runat="server" />
      &nbsp;&nbsp;&nbsp;
        <asp:Image ID="imgWeathertrendsAfS" runat="server" AlternateText="icon" ImageAlign="AbsMiddle" />
      &nbsp;&nbsp;&nbsp;
        <asp:Image ID="imgWeathertrendsAfE" runat="server" AlternateText="icon" ImageAlign="AbsMiddle" Height="16px" />
      &nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="hlkMore" runat="server" ForeColor="#666666" NavigateUrl="~/Weather.aspx" Target="_blank">更多信息</asp:HyperLink>
      &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </td>
  </tr>
</table>
