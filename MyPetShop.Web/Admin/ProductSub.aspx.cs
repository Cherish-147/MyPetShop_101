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
public partial class Admin_ProductSub : System.Web.UI.Page
{

  ProductService productSrv = new ProductService();
  CategoryService categorySrv = new CategoryService();
  SupplierService supplierSrv = new SupplierService();
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
  /// 根据从ProductMaster.aspx传递过来的ProductId值，显示与ProductId值相等的商品信息
  /// </summary>
  protected void Bind()
  {
    if (Request.QueryString["ProductId"] == null)
    {
      pnlProduct.Visible = false;
    }
    else
    {
      int productId = int.Parse(Request.QueryString["ProductId"]);
      var product = productSrv.GetProductByProductId(productId);

      var categories = categorySrv.GetAllCategory();
      foreach (var category in categories)
      {
        ddlCategoryId.Items.Add(new ListItem(category.Name, category.CategoryId.ToString()));
      }

      var suppliers = supplierSrv.GetAllSupplier();
      foreach (var supplier in suppliers)
      {
        ddlSuppId.Items.Add(new ListItem(supplier.Name, supplier.SuppId.ToString()));
      }

      txtName.Text = product.Name;
      ddlCategoryId.SelectedValue = product.CategoryId.ToString();
      txtListPrice.Text = product.ListPrice.ToString();
      txtUnitCost.Text = product.UnitCost.ToString();
      ddlSuppId.SelectedValue = product.SuppId.ToString();
      txtDescn.Text = product.Descn;
      txtQty.Text = product.Qty.ToString();
      imgImage.ImageUrl = product.Image;
    }
  }

  protected void btnUpdate_Click(object sender, EventArgs e)
  {
    if (Request.QueryString["ProductId"] != null)
    {
      int productId = int.Parse(Request.QueryString["ProductId"]);
      

      productSrv.Update(productId,txtName.Text.Trim(),
        int.Parse(ddlCategoryId.SelectedValue),int.Parse(ddlSuppId.SelectedValue),
      decimal.Parse(txtListPrice.Text.Trim()),decimal.Parse(txtUnitCost.Text.Trim()),
      txtDescn.Text.Trim(),int.Parse(txtQty.Text.Trim()));

      //如果有上传文件，就删除原来的图片，保存上传的图片
      if (fupImage.PostedFile.ContentLength != 0)
      {
        string filePath = Server.MapPath("~/") + productSrv.GetProductByProductId(productId).Image.Substring(2);
        File.Delete(filePath);
        fupImage.PostedFile.SaveAs(filePath);
      }
            
      //清空页面缓存
      Response.Buffer = true;
      //重定向到Admin文件夹中的Default.aspx
      Response.Redirect("ProductMaster.aspx");
    }
  }
}