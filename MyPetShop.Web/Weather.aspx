<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Weather.aspx.cs" Inherits="Weather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title>天气预报</title>
  <link href="Styles/weather.css" type="text/css" rel="stylesheet" />
</head>
<body>
  <form id="form1" runat="server">
    <table style="text-align: center; border: 0; width: 680px; margin: 0 auto;">
      <tr>
        <td style="text-align: center; height: 60px;">
          <asp:Label Font-Bold="True" ID="lblTitle" runat="server" Text="国内外主要城市  3天天气预报" />
        </td>
      </tr>
      <tr>
        <td>
          <table style="width: 100%; border: 0;">
            <tr>
              <td style="width: 25%;">
                <strong>选择省/洲</strong>
                <asp:DropDownList CssClass="list" ID="ddlProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                </asp:DropDownList>
              </td>
              <td>
                <strong>选择城市</strong>
                <asp:DropDownList CssClass="list" ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                </asp:DropDownList>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td>
          <table style="width: 100%; border: 2px solid #fff;">
            <tr>
              <td style="width: 15%; height: 30px;">&nbsp;
              </td>
              <td style="text-align: right;">
                <asp:Label ID="lblCity" runat="server" CssClass="bredfont" />
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top;">
                <strong>今日实况</strong>
              </td>
              <td class="hfont">
                <asp:Label ID="lblNow" runat="server" />
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top;">&nbsp;
              </td>
              <td>&nbsp;
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top;">
                <strong>天气预报</strong><span style="color: #FF0033">(今天)</span>
              </td>
              <td class="hfont">
                <asp:Label ID="lblToday" runat="server" />
                &nbsp;&nbsp;&nbsp;
              <asp:Image AlternateText="icon" ID="imgWeathertrendsTdS" ImageAlign="AbsMiddle" runat="server" />
                &nbsp;&nbsp;&nbsp;
              <asp:Image AlternateText="icon" ID="imgWeathertrendsTdE" ImageAlign="AbsMiddle" runat="server" />
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top;">
                <strong>今天指数</strong>
              </td>
              <td>&nbsp;
              </td>
            </tr>
            <tr>
              <td colspan="2" style="vertical-align: top;" class="hfont">
                <asp:Label ID="lblExponent" runat="server" />
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top;">&nbsp;
              </td>
              <td>&nbsp;
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top;">
                <strong>天气预报</strong><span style="color: #3333FF">(明天)</span>
              </td>
              <td class="hfont">
                <asp:Label ID="lblTomorrow" runat="server" />
                &nbsp;&nbsp;&nbsp;
                <asp:Image AlternateText="icon" ID="imgWeathertrendsTmS" ImageAlign="AbsMiddle" runat="server" />
                &nbsp;&nbsp;&nbsp;
                <asp:Image AlternateText="icon" ID="imgWeathertrendsTmE" ImageAlign="AbsMiddle" runat="server" />
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top;">&nbsp;
              </td>
              <td>&nbsp;
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top;">
                <strong>天气预报</strong><span style="color: #006633">(后天)</span>
              </td>
              <td class="hfont">
                <asp:Label ID="lblAfterTmr" runat="server" />
                &nbsp;&nbsp;&nbsp;
                <asp:Image AlternateText="icon" ID="imgWeathertrendsAfS" ImageAlign="AbsMiddle" runat="server" />
                &nbsp;&nbsp;&nbsp;
                <asp:Image AlternateText="icon" ID="imgWeathertrendsAfE" ImageAlign="AbsMiddle" runat="server" />
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top;">&nbsp;
              </td>
              <td>&nbsp;
              </td>
            </tr>
            <tr>
              <td colspan="2" style="vertical-align: top;">
                <strong>城市介绍</strong>
              </td>
            </tr>
            <tr>
              <td colspan="2" style="vertical-align: top;" class="hfont">
                <asp:Image CssClass="img" Height="105" ID="imgCityPhoto" ImageAlign="Left" runat="server"
                  Width="150" /><asp:Label ID="lblCityIntro" runat="server" />
              </td>
            </tr>
            <tr>
              <td colspan="2" style="vertical-align: bottom; text-align: right; height: 30px">
                <strong>预报时间</strong>：
                <asp:Label ID="lblTime" runat="server" />
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </form>
</body>
</html>
