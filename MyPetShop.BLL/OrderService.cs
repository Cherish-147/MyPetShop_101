using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyPetShop.DAL;
using System.Transactions;

namespace MyPetShop.BLL
{
  public class OrderService
  {
    MyPetShopDataContext db = new MyPetShopDataContext();
    public List<Order> GetAllOrder()
    {
      return db.Order.ToList();
    }
    public List<Order> GetOrderByCustomerId(int customerId)
    {
      return db.Order.Where(o => o.CustomerId == customerId)
                      .OrderByDescending(o => o.CustomerId)
                        .ToList();
    }

    public Order GetOrderByOrderId(int orderId)
    {
      return (from o in db.Order
              where o.OrderId == orderId
              select o).First();
    }
    public List<Order> GetOrderListByOrderId(int orderId)
    {
      return (from o in db.Order
              where o.OrderId == orderId
              select o).ToList();
    }

    public List<OrderItem> GetOrderItemByOrderId(int orderId)
    {
      return (from o in db.OrderItem
              where o.OrderId == orderId
              select o).ToList();
    }

    public void CreateOrderFromCart(int cutomerId, string customerName, string addr1, string addr2,
      string city, string state, string zip, string phone)
    {
      //本项目使用数据库事务，需要在项目中添加引用动态链接库System.Transactions，并在本页代码上 using System.Transactions;
      using (TransactionScope ts = new TransactionScope())
      {
        //获取购物车内商品项目
        List<CartItem> cartItemList = (from c in db.CartItem
                                       where c.CustomerId == cutomerId
                                       select c).ToList();

        //根据送货地址信息创建订单头，状态为“未审核”
        Order order = new Order();
        order.CustomerId = cutomerId;
        order.UserName = customerName;
        order.OrderDate = DateTime.Now;
        order.Addr1 = addr1;
        order.Addr2 = addr2;
        order.City = city;
        order.State = state;
        order.Zip = zip;
        order.Phone = phone;
        order.Status = "未审核";

        //根据购物车商品清单创建订单明细
        OrderItem orderItem = null;
        Product product = null;
        foreach (CartItem cartItem in cartItemList) 
        {
          //依次添加每件商品为订单明细
          orderItem = new OrderItem();
          orderItem.OrderId = order.OrderId;
          orderItem.ProName = cartItem.ProName;
          orderItem.ListPrice = cartItem.ListPrice;
          orderItem.Qty = cartItem.Qty;
          orderItem.TotalPrice = cartItem.Qty * cartItem.ListPrice;
          order.OrderItem.Add(orderItem);

          //修改Product表的商品库存
          product = (from p in db.Product
                     where p.ProductId == cartItem.ProId
                     select p).First();
          product.Qty = product.Qty - cartItem.Qty;

          //从购物车中删除购物项
          db.CartItem.DeleteOnSubmit(cartItem);
        }
        
        db.Order.InsertOnSubmit(order);
        db.SubmitChanges();
        ts.Complete(); //提交事务
      }
    }

    /// <summary>
    /// 将指定orderId的订单状态设置为“已审核”
    /// </summary>
    /// <param name="orderId">订单编号</param>
    public void UpdateOrder(int orderId)
    {
      Order order = (from o in db.Order
                     where o.OrderId == orderId
                     select o).First();
      order.Status = "已审核";
      db.SubmitChanges();
    }
  }
}
