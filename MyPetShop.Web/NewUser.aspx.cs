using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MyPetShop.BLL;
public partial class NewUser : System.Web.UI.Page
{
  //建立MyPetShop.BLL业务逻辑层中的CustomerService类实例customerSrv
  CustomerService customerSrv = new CustomerService();
  protected void BtnReg_Click(object sender, EventArgs e)
  {
    if (Page.IsValid)
    {
      //调用CustomerService类中的IsNameExist()方法判断用户名是否重名
      if (customerSrv.IsNameExist(txtName.Text.Trim()))
      {
        lblMsg.Text = "用户名已存在！";
      }
      else
      {
        //调用CustomerService类中的Insert()方法插入新用户记录
        customerSrv.Insert(txtName.Text.Trim(), txtPwd.Text.Trim(), txtEmail.Text.Trim());
        Response.Redirect("Login.aspx?name=" + txtName.Text);
      }
    }
  }
}