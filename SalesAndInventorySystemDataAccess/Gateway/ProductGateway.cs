using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemDataAccess.Gateway
{
    public class ProductGateway
    {
        public bool CheckProduct(Product product)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    Product aProduct = dataContext.Products.FirstOrDefault(x => x.ProductName == product.ProductName && x.CategoryID == product.CategoryID);
                    if (aProduct == null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }

        }

        public bool AddProduct(Product product)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    dataContext.Products.Add(product);
                    dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }

        }

        public bool UpdateProduct(Product product)
        {

            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    int noOfRowUpdated =
                        dataContext.Database.ExecuteSqlCommand("Update student set studentname ='changed student by command' where studentid=1");


                    //dataContext.Products.Attach(product);
                    //dataContext.Entry<Product>(product).Property()

                    return true;
                }
            }

            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            //_cnt.Users.Attach(user);
            //_cnt.Entry<User>(user).Property(u => u.PasswordHash).IsModified = true;
            //_cnt.SaveChanges();
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    dataContext.Products.Attach(product);
                    dataContext.Entry(product).State = EntityState.Deleted;
                    dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = null;
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    products = dataContext.Products.ToList();
                    return products;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
        public List<Product> GetAllProducts(int ProductID)
        {
            return null;
        }

        public bool CheckBarCode(Product product)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    Product aProduct = dataContext.Products.FirstOrDefault(x => x.BarCode == product.BarCode);
                    if (aProduct == null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

        public Product GetDataBarCode(string barCode)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    Product aProduct = dataContext.Products.FirstOrDefault(x => x.BarCode == barCode);
                    return aProduct;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

        public bool CheckNewBarCode(string barcode)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    Product aProduct = dataContext.Products.FirstOrDefault(x => x.BarCode == barcode);
                    if (aProduct == null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
    }
}
