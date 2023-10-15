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

public partial class Admin_SupplierMaster : System.Web.UI.Page
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

    var productCount = productSrv.GetProductCountBySupplierId(int.Parse(DetailsView1.DataKey.Value.ToString()));
    if (productCount != 0)
    {
      lblError.Text = "Error：该分类下有商品，请先删除商品！";
      e.Cancel = true;
    }
  }
}