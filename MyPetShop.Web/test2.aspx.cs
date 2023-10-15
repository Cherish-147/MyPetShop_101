using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblproductId.Text = "您选择的productid为：";
        foreach (GridViewRow gvRow in gvproduct.Rows)
        {
            CheckBox chkItem = (CheckBox)gvRow.FindControl("chkItem");
            if (chkItem.Checked)
            {
                lblproductId.Text += gvRow.Cells[1].Text + "、";
            }
        }
    }

    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        //获取GridView标题行中chkAll对象  、
        CheckBox chkAll = (CheckBox)sender;
        foreach (GridViewRow gvRow in gvproduct.Rows)
        {
            //获取GridView数据行中chkItem对象
            CheckBox chkItem = (CheckBox)gvRow.FindControl("chkItem");
            chkItem.Checked = chkAll.Checked;
        }
    }

    protected void gvproduct_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvproduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)  //判断数据行
        {
            try
            {
                //获取“删除”链接
                LinkButton lnkbtnDelete = (LinkButton)e.Row.Cells[7].Controls[0];
                //添加JavaScript代码实现客户端信息的提示
                lnkbtnDelete.OnClientClick = "return confirm('您真要删除分类名为" +
                e.Row.Cells[1].Text + "的记录吗?');";
            }
            catch
            {
                //若try块有异常，则不做任何操作
            }
        }
    }
}