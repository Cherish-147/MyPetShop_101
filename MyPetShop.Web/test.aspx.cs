using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ddlPagesize_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvproduct.PageSize = int.Parse(ddlPagesize.SelectedValue);
        gvproduct.DataBind();
    }

    protected void gvproduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        lblmsg.Text = "当前页为第" + (gvproduct.PageIndex + 1).ToString() + "页,共有" + (gvproduct.PageCount).ToString() + "页";
    }
}