using MyPetShop.DAL;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;

namespace MyPetShop.BLL
{
  public class ProductService
  {
    MyPetShopDataContext db = new MyPetShopDataContext();

    public void Add(string imageFile,string name ,int categoryId,int supplierId,
      decimal listPrice,decimal unitCost,string descn,int qty)
    {
      Product product = new Product();
      product.Image = imageFile;
      product.Name = name;
      product.CategoryId = categoryId;
      product.SuppId = supplierId;
      product.ListPrice = listPrice;
      product.UnitCost = unitCost;
      product.Descn = descn;
      product.Qty = qty;

      db.Product.InsertOnSubmit(product);
      db.SubmitChanges();
    }

    public void Update(int productId,string name,int categoryId,int suppId,decimal listPrice,
      decimal UnitCost,string descn,int qty)
    {
      Product product = (from p in db.Product
                         where p.ProductId == productId
                         select p).First();
      product.Name = name;
      product.CategoryId = categoryId;
      product.SuppId = suppId;
      product.ListPrice = listPrice;
      product.UnitCost = UnitCost;
      product.Descn = descn;
      product.Qty = qty;

      db.SubmitChanges();
    }

    public List<Product> GetAllProduct()
    {
      return (from p in db.Product
              select p).ToList();
    }
    public Product GetProductByProductId(int productId)
    {
      return (from p in db.Product
              where p.ProductId == productId
              select p).First();
    }
    public List<Product> GetProductByCategoryId(int categoryId)
    {
      return (from p in db.Product
              where p.CategoryId == categoryId
              select p).ToList();
    }

    public List<Product> GetNewProduct(int count)
    {
      return (from p in db.Product
              orderby p.ProductId descending
              select p).Take(count).ToList();
    }

    public List<Product> GetProductByProductIdOrCategoryId(string productId, string categoryId)
    {
      if (!string.IsNullOrEmpty(productId))
	    {
        return (from p in db.Product
                where p.ProductId == int.Parse(productId)
                select p).ToList();
	    }
      else
      {
        return  (from p in db.Product
                 where p.CategoryId == int.Parse(categoryId)
                 select p).ToList();
      }
    }

    /// <summary>
    /// 模糊查找商品名中包含指定文本的商品，再返回满足条件的商品列表
    /// </summary>
    /// <param name="searchText">指定的文本</param>
    /// <returns>满足条件的商品列表</returns>
    public List<Product> GetProductBySearchText(string searchText)
    {
        return   (from p in db.Product
                  where SqlMethods.Like(p.Name, "%" + searchText + "%")
                  select p).ToList();
    }

    public int GetProductCountByCategoryId(int categoryId)
    {
      return (from p in db.Product
              where p.CategoryId == categoryId
              select p).Count();
    }
    public int GetProductCountBySupplierId(int supplierId)
    {
      return (from p in db.Product
              where p.SuppId == supplierId
              select p).Count();
    }
    /// <summary>
    /// IsExitCS()方法判断Category和Supplier表中是否已有数据
    /// </summary>
    /// <returns>返回值true表示Category或Supplier表中无数据；返回值false表示Category和Supplier表中都有数据</returns>
    public bool IsExitCS()
    {
      var categories = from c in db.Category
                       select c;
      var suppliers = from c in db.Supplier
                      select c;
      if (categories.Count() == 0 || suppliers.Count() == 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// IsExitProduct()判断是否存在指定的商品
    /// </summary>
    /// <param name="name">指定的商品名</param>
    /// <returns>返回值true表示Product表中存在指定的商品；返回值false表示Product表中不存在指定的商品</returns>
    public bool IsExitProduct(string name)
    {
      var products = from c in db.Product
                     where c.Name == name
                     select c;
      if (products.Count() != 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public void DeletePro(int productId)
    {

      var product = (from p in db.Product
                     where p.ProductId == productId
                     select p).First();

      //产品如果已经有用户放入购物车或者下达了订单，该产品删除失败（外键约束）
      //异常: "The DELETE statement conflicted with the REFERENCE constraint "FK__CartItem__ProId". 
      //异常: "The DELETE statement conflicted with the REFERENCE constraint "FK__OrderItem__ProId". 
      db.Product.DeleteOnSubmit(product);
      db.SubmitChanges();
    }
  }
}
