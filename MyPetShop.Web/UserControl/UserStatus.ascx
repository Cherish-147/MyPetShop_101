<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserStatus.ascx.cs" Inherits="UserControl_UserStatus" %>

<asp:Label ID="lblWelcome" runat="server" Text="您还未登录！"></asp:Label>
<asp:LinkButton ID="lnkbtnPwd" runat="server" ForeColor="White" Visible="False" PostBackUrl="~/ChangePwd.aspx">密码修改</asp:LinkButton>
<asp:LinkButton ID="lnkbtnManage" runat="server" ForeColor="White" Visible="False" PostBackUrl="~/Admin/Default.aspx">系统管理</asp:LinkButton>
<asp:LinkButton ID="lnkbtnOrder" runat="server" ForeColor="White" Visible="False" PostBackUrl="~/OrderList.aspx">购物记录</asp:LinkButton>
<asp:LinkButton ID="lnkbtnLogout" runat="server" ForeColor="White" Visible="False" OnClick="LnkbtnLogout_Click">退出登录</asp:LinkButton>