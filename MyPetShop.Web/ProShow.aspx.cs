using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MyPetShop.BLL;

public partial class ProShow : System.Web.UI.Page
{
  ProductService productSrv = new ProductService();
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Request.QueryString.Count == 0)
    {
      Response.Redirect("Default.aspx");
    }
    else
    {
      Bind();  //调用自定义方法Bind()
    }
  }

  /// <summary>
  /// 根据从NewProduct.ascx、Category.ascx、PetTree.ascx传递过来的ProductId或CategoryId值，显示与ProductId值相等的单个商品信息，或者显示CategoryId确定的分类中所有的商品信息
  /// </summary>
  protected void Bind()
  {
    gvProduct.DataSource = productSrv.GetProductByProductIdOrCategoryId(Request.QueryString["ProductId"], Request.QueryString["CategoryId"]);
    gvProduct.DataBind();
  }

  protected void gvProduct_PageIndexChanging(Object sender, GridViewPageEventArgs e)
  {
    gvProduct.PageIndex = e.NewPageIndex;
    Bind();  //调用自定义方法Bind()
  }
}