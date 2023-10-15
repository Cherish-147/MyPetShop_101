using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{
  protected void ImgbtnSearch_Click(object sender, ImageClickEventArgs e)
  {
    //如果搜索框不为空，以查询字符串形式传递搜索文本到Search.aspx
    string strQuery = "";
    if (txtSearch.Text.Trim() == "")
    {
      strQuery = "";
    }
    else
    {
      strQuery = "?SearchText=" + txtSearch.Text.Trim();
    }
    Response.Redirect("~/Search.aspx" + strQuery);
  }
  protected void LnkbtnRegister_Click(object sender, EventArgs e)
  {
    Session.Clear();  //注销当前用户
    Response.Redirect("~/NewUser.aspx");
  }
  protected void LnkbtnLogin_Click(object sender, EventArgs e)
  {
    Session.Clear();  //注销当前用户
    Response.Redirect("~/Login.aspx");
  }
}
