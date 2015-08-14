using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemDataAccess.Gateway
{
    public class SellProductGateway
    {
        public List<SellProduct> GetAllProducts()
        {
            List<SellProduct> sellProducts = null;
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    sellProducts = dataContext.SellProducts.ToList();
                    return sellProducts;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }


    }
}
