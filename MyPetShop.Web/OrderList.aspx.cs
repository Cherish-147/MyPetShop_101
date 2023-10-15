using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MyPetShop.BLL;

public partial class OrderList : System.Web.UI.Page
{
  OrderService orderSrv = new OrderService();

  protected void Page_Load(object sender, EventArgs e)
  {
    //如果匿名访问，转到登录页面
    if (Session["CustomerId"] == null)
    {
      Response.Redirect("~/Login.aspx");
    }
    Bind();  //调用自定义方法Bind()
  }

  /// <summary>
  /// 显示登录的用户名对应的订单列表
  /// 用户ID从Session中获取
  /// </summary>
  protected void Bind()
  {
    gvOrderItem.DataSource = orderSrv.GetOrderByCustomerId(Convert.ToInt32(Session["CustomerId"]));
    gvOrderItem.DataBind();
  }

  protected void GridView1_PageIndexChanging(Object sender, GridViewPageEventArgs e)
  {
    gvOrderItem.PageIndex = e.NewPageIndex;
    Bind();
  }
}