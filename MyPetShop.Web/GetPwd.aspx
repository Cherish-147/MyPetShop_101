<%@ Page Title="找回用户密码" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GetPwd.aspx.cs" Inherits="GetPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <table style="border-collapse: collapse;">
        <tr>
          <td class="tdcenter" colspan="2">找回密码</td>
        </tr>
        <tr>
          <td class="tdright">用户名:</td>
          <td>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
          <td>
            <asp:RequiredFieldValidator ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" ID="rfvName" runat="server" ErrorMessage="必填"></asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
          <td class="tdright">邮箱:</td>
          <td>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
          <td>
            <asp:RequiredFieldValidator ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ID="rfvEmail" runat="server" ErrorMessage="必填"></asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
          <td class="tdright" colspan="2">
            <asp:RegularExpressionValidator ID="revEmail" runat="server"
              ErrorMessage="邮箱格式不正确！" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
          </td>
        </tr>
        <tr>
          <td class="tdright" colspan="2">
            <asp:Button ID="btnResetPwd" runat="server" Text="找回密码" OnClick="BtnResetPwd_Click" />
          </td>
        </tr>
        <tr>
          <td colspan="2">找回密码，需要验证邮箱！</td>
        </tr>
        <tr>
          <td colspan="2">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
      </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="Server">
</asp:Content>


