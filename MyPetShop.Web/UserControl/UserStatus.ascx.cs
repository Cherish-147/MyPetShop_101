using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_UserStatus : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["AdminId"] != null || Session["CustomerId"] != null)  //用户已登录
    {
      if (Session["AdminId"] != null)  //管理员用户
      {
        lblWelcome.Text = "您好, " + Session["AdminName"].ToString();
        lnkbtnManage.Visible = true;
      }
      else if (Session["CustomerId"] != null)  //一般用户
      {
        lblWelcome.Text = "您好, " + Session["CustomerName"].ToString();
        lnkbtnPwd.Visible = true;
        lnkbtnOrder.Visible = true;
      }
      lnkbtnLogout.Visible = true;
    }
  }
  protected void LnkbtnLogout_Click(object sender, EventArgs e)
  {
    Session.Clear();
    Response.Redirect("~/Default.aspx");
  }
}