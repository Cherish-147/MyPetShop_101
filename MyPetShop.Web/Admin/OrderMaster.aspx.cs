using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using MyPetShop.BLL;


public partial class Admin_OrderMaster : System.Web.UI.Page
{
  OrderService orderSrv = new OrderService();

  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["AdminId"] == null)  //管理员用户未登录
    {
      Response.Redirect("~/Login.aspx");
    }

    if (!IsPostBack)
    {
      Bind();  //调用自定义方法Bind()
    }
  }

  /// <summary>
  /// 显示Order表数据
  /// </summary>
  protected void Bind()
  {
    var orders = orderSrv.GetAllOrder();
    if (orders.Count() == 0)
    {
      pnlOrder.Visible = false;
      lblOrder.Text = "尚无订单！";
    }
    else
    {
      pnlOrder.Visible = true;
      lblOrder.Text = "";
    }
    gvOrder.DataSource = orders;
    gvOrder.DataBind();
  }

  protected void gvOrder_PageIndexChanging(Object sender, GridViewPageEventArgs e)
  {
    gvOrder.PageIndex = e.NewPageIndex;
    Bind();  //调用自定义方法Bind()
  }

  protected void btnAudit_Click(object sender, EventArgs e)
  {
    GridView gvOrder = new GridView();
    gvOrder = (GridView)Page.Master.FindControl("ContentPlaceHolder2").FindControl("gvOrder");
    if (gvOrder != null)
    {
      for (int i = 0; i < gvOrder.Rows.Count; i++)
      {
        CheckBox chkChoice = new CheckBox();
        chkChoice = (CheckBox)gvOrder.Rows[i].FindControl("chkChoice");
        if (chkChoice != null)
        {
          if (chkChoice.Checked)
          {
            int OrderId = int.Parse(gvOrder.Rows[i].Cells[2].Text);
            orderSrv.UpdateOrder(OrderId);  //调用自定义方法UpdateOrder(）
          }
        }
      }
    }
    Bind();  //调用自定义方法Bind()
  }

}