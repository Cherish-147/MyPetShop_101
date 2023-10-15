using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyPetShop.DAL;

namespace MyPetShop.BLL
{
  public class CartItemService
  {
    MyPetShopDataContext db = new MyPetShopDataContext();

    public CartItem Add(int customerId, int productId, int qty)
    {
      CartItem cartItem = null;

      Product product = (from p in db.Product
                         where p.ProductId == productId
                         select p).First();
      //当前需要添加的CartItem对象
      cartItem = new CartItem();
      cartItem.CustomerId = customerId;
      cartItem.ProId = product.ProductId;
      cartItem.ProName = product.Name;
      cartItem.ListPrice = product.ListPrice.Value;
      cartItem.Qty = qty;

      //如果客户当前宠物商品已在购物车内，则只要修改数量即可
      int ExistCartItemCount = (from c in db.CartItem
                                where c.CustomerId == customerId && c.ProId == productId
                                select c).Count();
      if (ExistCartItemCount > 0) //修改
      {
        CartItem existCartItem = (from c in db.CartItem
                                  where c.CustomerId == customerId && c.ProId == productId
                                  select c).First();
        existCartItem.Qty += qty;//添加
      }
      else
      {
        db.CartItem.InsertOnSubmit(cartItem);
      }

      db.SubmitChanges();
      return cartItem;
    }

    /// <summary>
    /// 更新购物车中购物项的数量
    /// </summary>
    public CartItem Update(int customerId, int productId, int qty)
    {
      CartItem cartItem = null;

      //如果客户当前宠物商品已在购物车内，则只要修改数量即可;数量为0时删除该购物项
      cartItem = (from c in db.CartItem
                  where c.CustomerId == customerId && c.ProId == productId
                  select c).First();
      if (cartItem != null)
      {
        cartItem.Qty = qty;
        //数量为0时删除
        if (cartItem.Qty <= 0)
        {
          db.CartItem.DeleteOnSubmit(cartItem);
        }
        db.SubmitChanges();
      }

      return cartItem;
    }

    /// <summary>
    /// 删除购物车中购物项
    /// </summary>
    public void Delete(int customerId, int productId)
    {
      CartItem cartItem = (from c in db.CartItem
                           where c.CustomerId == customerId && c.ProId == productId
                           select c).First();
      if (cartItem != null)
      {
        db.CartItem.DeleteOnSubmit(cartItem);
        db.SubmitChanges();
      }
    }

    /// <summary>
    /// 清除购物车中所有购物项
    /// </summary>
    public void Clear(int customerId)
    {
      List<CartItem> cartItemList = (from c in db.CartItem
                                     where c.CustomerId == customerId
                                     select c).ToList();
      foreach (CartItem cartItem in cartItemList)
      {
        db.CartItem.DeleteOnSubmit(cartItem);
      }
      db.SubmitChanges();
    }

    public List<CartItem> GetCartItemByCustomerId(int customerId)
    {
      return (from c in db.CartItem
              where c.CustomerId == customerId
              select c).ToList();
    }

    public decimal GetTotalPriceByCustomerId(int customerId)
    {
      List<CartItem> list = (from c in db.CartItem
                             where c.CustomerId == customerId
                             select c).ToList();

      return list.Sum(c => c.ListPrice * c.Qty);
    }


  }
}
