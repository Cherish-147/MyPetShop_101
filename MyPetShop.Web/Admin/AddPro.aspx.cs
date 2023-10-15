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

public partial class Admin_AddPro : System.Web.UI.Page
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
      if (productSrv.IsExitCS())  //调用方法IsExitCS()
      {
        pnlProductMaster.Visible = false;
        lblMsg.Text = "请先添加分类和提供商！";
      }
      else
      {
        pnlProductMaster.Visible = true;
        lblMsg.Text = "";
        Bind();  //调用自定义方法Bind()
      }
    }
  }

  /// <summary>
  /// 自定义方法Bind()用于填充“商品分类”下拉列表和“提供商”下拉列表的值
  /// </summary>
  protected void Bind()
  {
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
  }

  protected void btnAdd_Click(object sender, EventArgs e)
  {
    if (productSrv.IsExitProduct(txtName.Text.Trim()))  //输入的商品名已存在
    {
      lblNameErr.Text = "商品已经存在";
    }
    else  //添加商品到Product表
    {
      string fileName;
      string fileFolder;
      string dateTime = "";
      fileName = Path.GetFileName(fupImage.PostedFile.FileName);
      dateTime += DateTime.Now.Year.ToString();
      dateTime += DateTime.Now.Month.ToString();
      dateTime += DateTime.Now.Day.ToString();
      dateTime += DateTime.Now.Hour.ToString();
      dateTime += DateTime.Now.Minute.ToString();
      dateTime += DateTime.Now.Second.ToString();
      fileName = dateTime + fileName;
      fileFolder = Server.MapPath("~/") + "Prod_Images\\" + ddlCategoryId.SelectedItem.Text + "\\";
      fileFolder = fileFolder + fileName;
      fupImage.PostedFile.SaveAs(fileFolder);

      productSrv.Add("~\\Prod_Images\\" + ddlCategoryId.SelectedItem.Text + "\\" + fileName,
                    txtName.Text.Trim(),
                    int.Parse(ddlCategoryId.SelectedValue),int.Parse(ddlSuppId.SelectedValue),
                    decimal.Parse(txtListPrice.Text.Trim()),decimal.Parse(txtUnitCost.Text.Trim()),
                    txtDescn.Text.Trim(),int.Parse(txtQty.Text.Trim()));

      Response.Redirect("ProductMaster.aspx");
    }
  }
}