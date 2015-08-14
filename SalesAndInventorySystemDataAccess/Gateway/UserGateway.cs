using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemDataAccess.Gateway
{
    public class UserGateway
    {
        private SalesAndInventorySystemDataContext dataContext;
        public UserGateway()
        {
            dataContext=new SalesAndInventorySystemDataContext();
        }
        public bool Login(User user)
        {
            try
            {
                User aUser =
                dataContext.Users.SingleOrDefault(
                    u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password));
                if (aUser != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            
        }
    }
}
