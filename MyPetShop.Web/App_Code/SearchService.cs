using MyPetShop.BLL;
using System;
using System.Collections.Generic;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class SearchService : System.Web.Services.WebService
{
  public SearchService()
  {
    //如果使用设计的组件，请取消注释以下行 
    //InitializeComponent(); 
  }
  /// <summary>
  /// 模糊查找商品名中包含关联文本框输入值的商品，再返回满足条件的商品名列表
  /// </summary>
  /// <param name="prefixText">关联文本框输入值</param>
  /// <returns>满足条件的商品名列表</returns>
  [WebMethod]
  public string[] GetStrings(string prefixText, int count)
  {
    ProductService productSrv = new ProductService();
    //调用ProductService类中的GetProductBySearchText()方法模糊查找商品名中包含关联文本框输入值的商品
    var products = productSrv.GetProductBySearchText(prefixText);
    //将查找到商品的商品名填充到列表类中
    List<String> list = new List<String>(count);
    foreach (var product in products)
    {
      list.Add(product.Name);
    }
    return list.ToArray();
  }
}

