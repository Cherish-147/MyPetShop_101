using MyPetShop.BLL;
using System;
using System.Web.UI.WebControls;

public partial class Admin_CategoryMaster : System.Web.UI.Page
{
  ProductService productSrv = new ProductService();
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["AdminId"] == null)  //管理员用户未登录
    {
      Response.Redirect("~/Login.aspx");
    }
  }

  protected void DetailsView1_ItemDeleting(Object sender, DetailsViewDeleteEventArgs e)
  {
    var productCount = productSrv.GetProductCountByCategoryId(int.Parse(DetailsView1.DataKey.Value.ToString()));
    if (productCount != 0)
    {
      lblError.Text = "Error：该分类下有商品，要删除该分类请先删除商品！";
      e.Cancel = true;
    }
  }
}