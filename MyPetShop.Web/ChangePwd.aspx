<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="ChangePwd" Title="修改用户密码" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <table style="border-collapse: collapse;">
    <tr>
      <td class="tdcenter" colspan="2">修改密码</td>
    </tr>
    <tr>
      <td class="tdright">原密码:</td>
      <td>
        <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox></td>
      <td>
        <asp:RequiredFieldValidator ControlToValidate="txtOldPwd" Display="Dynamic" ForeColor="Red" ID="rfvOldPwd" runat="server" ErrorMessage="必填">
        </asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td class="tdright">新密码:</td>
      <td>
        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox></td>
      <td>
        <asp:RequiredFieldValidator ControlToValidate="txtPwd" Display="Dynamic" ForeColor="Red" ID="rfvPwd" runat="server" ErrorMessage="必填">
        </asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td class="tdright">确认新密码:</td>
      <td>
        <asp:TextBox ID="txtPwdAgain" runat="server" TextMode="Password"></asp:TextBox></td>
      <td>
        <asp:RequiredFieldValidator ControlToValidate="txtPwdAgain" Display="Dynamic" ForeColor="Red" ID="rfvPwdAgain" runat="server" ErrorMessage="必填">
        </asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td class="tdright" colspan="2">
        <asp:CompareValidator ControlToValidate="txtPwdAgain" ControlToCompare="txtPwd" Display="Dynamic" ForeColor="Red" ID="cvPwd" runat="server" ErrorMessage="2次新密码不一致"></asp:CompareValidator>
      </td>
    </tr>
    <tr>
      <td class="tdright" colspan="2">
        <asp:Button ID="btnChangePwd" runat="server" Text="确认修改" OnClick="BtnChangePwd_Click" />
      </td>
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


