using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemDataAccess.Gateway
{
    public class CompanyGateway
    {
       
        public bool CheckCompany(PersonType company)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    PersonType aCompany = dataContext.Companies.Where(b => b.Name == company.Name).FirstOrDefault();
                    if (aCompany==null)
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

        public bool AddCompany(PersonType company)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    dataContext.Companies.Add(company);
                    dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public bool UpdateCompany(PersonType company)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    dataContext.Companies.Attach(company);
                    dataContext.Entry(company).State = EntityState.Modified;
                    dataContext.SaveChanges();
                    return true;

                    //_cnt.Users.Attach(user);
                    //_cnt.Entry<User>(user).Property(u => u.PasswordHash).IsModified = true;
                    //_cnt.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public bool DeleteCompany(PersonType company)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    dataContext.Companies.Attach(company);
                    dataContext.Entry(company).State=EntityState.Deleted;
                    dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<PersonType> GetCompanies()
        {
            try
            {
                List<PersonType> companies = null;
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    
                    companies = dataContext.Companies.ToList();
                    return companies;
                }
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }

        public PersonType GetCompanies(int CompanyID)
        {
            try
            {
                PersonType company = null;
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {

                    company = dataContext.Companies.SingleOrDefault(x => x.ID==CompanyID);
                    return company;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

        public List<PersonType> GetListCompaniesByID(int CompanyID)
        {
            try
            {
                List<PersonType> companies = null;
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {

                    companies = dataContext.Companies.Where(x => x.ID == CompanyID).ToList();
                    return companies;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

        public PersonType GetCompaniesByID(int CompanyID)
        {
            try
            {
                PersonType company = null;
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {

                    company = dataContext.Companies.SingleOrDefault(x => x.ID == CompanyID);
                    return company;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
    }
}
