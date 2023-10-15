using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyPetShop.DAL;

namespace MyPetShop.BLL
{

  public class SupplierService
  {
    MyPetShopDataContext db = new MyPetShopDataContext();
    public List<Supplier> GetAllSupplier()
    {
      return (from c in db.Supplier
              select c).ToList();
    }
    public void InSertSupplier(int suppId, string name, 
      string addr1,string addr2,string city,string state,string zip,string phone)
    {
      Supplier supplier = new Supplier();
      supplier.SuppId = suppId;
      supplier.Name = name;
      supplier.Addr1 = addr1;
      supplier.Addr2 = addr2;
      supplier.City = city;
      supplier.State = state;
      supplier.Zip = zip;
      supplier.Phone = phone;

      db.Supplier.InsertOnSubmit(supplier);
      db.SubmitChanges();
    }
    public void UpdateSupplier(int suppId, string name, 
      string addr1,string addr2,string city,string state,string zip,string phone)
    {
      Supplier supplier = (from c in db.Supplier
                           where c.SuppId == suppId
                           select c).First();
      supplier.Name = name;
      supplier.Addr1 = addr1;
      supplier.Addr2 = addr2;
      supplier.City = city;
      supplier.State = state;
      supplier.Zip = zip;
      supplier.Phone = phone;
      db.SubmitChanges();
    }
    public void DeleteSupplier(int suppId)
    {
      Supplier supplier = (from c in db.Supplier
                           where c.SuppId == suppId
                           select c).First();
      db.Supplier.DeleteOnSubmit(supplier);
      db.SubmitChanges();
    }
  }
}
