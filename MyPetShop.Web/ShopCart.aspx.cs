using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using MyPetShop.BLL;

public partial class ShopCart : System.Web.UI.Page
{
  CartItemService cartSrv = new CartItemService();
  ProductService productSrv = new ProductService();
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      if (Session["CustomerId"] == null)//用户未登录
      {
        Response.Redirect("~/Login.aspx");
      }

      if (Request.QueryString["ProductId"] != null)
      {
        int productId = int.Parse(Request.QueryString["ProductId"]);
        // 将指定商品号的商品添加到购物车
        cartSrv.Add(Convert.ToInt32(Session["CustomerId"]), productId, 1);
      }
      lblHint.Text = "温馨提示：更改购买数量后，请单击'重新计算'按钮进行更新！";
      Bind();
    }
  }

  protected void Bind()
  {
    lblTotalPrice.Text = cartSrv.GetTotalPriceByCustomerId(Convert.ToInt32(Session["CustomerId"])).ToString();

    gvCart.DataSource = cartSrv.GetCartItemByCustomerId(Convert.ToInt32(Session["CustomerId"]));
    gvCart.DataBind();

    if (gvCart.Rows.Count != 0)
    {
      pnlCart.Visible = true;
      lblCart.Text = "";
    }
    else
    {
      pnlCart.Visible = false;
      lblCart.Text = "购物车内无商品，请先购物！";
    }
  }

  /// <summary>
  /// 计算购物车中购物总金额
  /// </summary>
  /// <returns>返回总金额</returns>
  protected decimal TotalPrice()
  {
    return cartSrv.GetTotalPriceByCustomerId(Convert.ToInt32(Session["CustomerId"]));
  }

  /// <summary>
  /// 循环利用FindControl()找到CheckBox控件chkProduct，然后判断其Checked值，若为True，则执行删除操作
  /// </summary>
  protected void btnDelete_Click(object sender, EventArgs e)
  {
    int productId = 0;
    GridView gvCart = new GridView();
    gvCart = (GridView)Page.Master.FindControl("ContentPlaceHolder2").FindControl("gvCart");
    if (gvCart != null)
    {
      for (int i = 0; i < gvCart.Rows.Count; i++)
      {
        CheckBox chkProduct = new CheckBox();
        chkProduct = (CheckBox)gvCart.Rows[i].FindControl("chkProduct");
        if (chkProduct != null)
        {
          if (chkProduct.Checked)
          {
            productId = int.Parse(gvCart.Rows[i].Cells[1].Text);
            cartSrv.Delete(Convert.ToInt32(Session["CustomerId"]),productId); //删除购物车中指定商品编号的商品
          }
        }
      }
    }
    Bind();  //调用自定义方法Bind()显示购物车中商品
  }


  protected void btnClear_Click(object sender, EventArgs e)
  {
    cartSrv.Clear(Convert.ToInt32(Session["CustomerId"]));
    Response.Redirect("Default.aspx");
  }

  protected void btnComputeAgain_Click(object sender, EventArgs e)
  {
    lblError.Text = "";
    //循环利用FindControl()找到TextBox控件txtQty，然后判断是否为空值，若非空，则在Product表中查找txtQty所在行商品编号确定的商品，从而比较txtQty中的输入值和商品的库存量
    GridView gvCart = new GridView();
    gvCart = (GridView)Page.Master.FindControl("ContentPlaceHolder2").FindControl("gvCart");
    if (gvCart != null)
    {
      for (int i = 0; i < gvCart.Rows.Count; i++)
      {
        TextBox txtQty = new TextBox();
        txtQty = (TextBox)gvCart.Rows[i].FindControl("txtQty");
        if (txtQty != null)
        {
          var product = productSrv.GetProductByProductId(Convert.ToInt32(gvCart.Rows[i].Cells[1].Text));

          if (int.Parse(txtQty.Text) > product.Qty)  //库存不足
          {
            lblError.Text += "Error：库存不足，商品名为 " + product.Name + " 的库存数量为 " + product.Qty.ToString() + "<br />";
          }
          else
          {
            cartSrv.Update(Convert.ToInt32(Session["CustomerId"]), product.ProductId, Convert.ToInt32(txtQty.Text));  //更新购买数量
          }
        }

      }
    }
    Bind();  //调用自定义方法Bind()显示购物车中商品
  }



  protected void btnSettle_Click(object sender, EventArgs e)
  {
    //如果不为匿名访问，则转到订单地址提交页面，否则转到登录页面
    if (Session["CustomerId"]!=null)
    {
      Response.Redirect("SubmitCart.aspx");
    }
    else
    {
      Response.Redirect("Login.aspx");
    }
  }
}