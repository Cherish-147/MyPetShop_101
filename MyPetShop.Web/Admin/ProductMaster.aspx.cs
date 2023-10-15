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
using System.IO;

using MyPetShop.BLL;

public partial class Admin_ProductMaster : System.Web.UI.Page
{
  ProductService productSrv = new ProductService();
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
  /// 显示Product表数据
  /// </summary>
  protected void Bind()
  {
    var products = productSrv.GetAllProduct();
    if (products.Count() == 0)
    {
      pnlProduct.Visible = false;
      lblProErr.Text = "数据库中无商品，请添加！";
    }
    else
    {
      pnlProduct.Visible = true;
      lblProErr.Text = "";
    }
    gvProduct.DataSource = products;
    gvProduct.DataBind();
  }


  protected void gvProduct_PageIndexChanging(Object sender, GridViewPageEventArgs e)
  {
    gvProduct.PageIndex = e.NewPageIndex;
    Bind();  //调用自定义方法Bind()
  }

  protected void btnDelete_Click(object sender, EventArgs e)
  {
    int productId = 0;
    GridView gvProduct = new GridView();
    gvProduct = (GridView)Page.Master.FindControl("ContentPlaceHolder2").FindControl("gvProduct");
    if (gvProduct != null)
    {
      for (int i = 0; i < gvProduct.Rows.Count; i++)
      {
        CheckBox chkChoice = new CheckBox();
        chkChoice = (CheckBox)gvProduct.Rows[i].FindControl("chkChoice");
        if (chkChoice != null)
        {
          if (chkChoice.Checked)
          {
            productId = int.Parse(gvProduct.Rows[i].Cells[1].Text);
            productSrv.DeletePro(productId);  //调用方法DeletePro()
          }
        }

      }
    }
    Bind();  //调用自定义方法Bind()
  }


}