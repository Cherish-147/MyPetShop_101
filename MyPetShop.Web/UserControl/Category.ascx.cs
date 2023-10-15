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

public partial class UserControl_Category : System.Web.UI.UserControl
{
    CategoryService categorySrv = new CategoryService();
    protected void Page_Load(object sender, EventArgs e)
    {

        gvCategory.DataSource = categorySrv.GetAllCategory();
        gvCategory.DataBind();
    }

    /// <summary>
    /// 显示分类的商品数量
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    protected string GetProductCountByCategoryId(string id)
    {
        return "("
                + categorySrv.GetProductCountByCategoryId(int.Parse(id)).ToString()
                + ")";
    }

}