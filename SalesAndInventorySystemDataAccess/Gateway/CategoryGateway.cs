using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemDataAccess.Gateway
{
    public class CategoryGateway
    {
        public bool CheckCategory(Category category)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    Category aCompany = dataContext.Categoets.FirstOrDefault(b => b.Name == category.Name && b.CompanyID==category.CompanyID);
                    if (aCompany == null)
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

        public bool AddCategory(Category category)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    dataContext.Categoets.Add(category);
                    dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    dataContext.Categoets.Attach(category);
                    dataContext.Entry(category).State = EntityState.Modified;
                    dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    dataContext.Categoets.Attach(category);
                    dataContext.Entry(category).State = EntityState.Deleted;
                    dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<Category> GetCategoriesByID()
        {
            try
            {
                List<Category> categories = null;
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {

                    categories = dataContext.Categoets.ToList();
                    return categories;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        } 

        public List<Category> GetCategoriesByID(int CategoryID)
        {
            try
            {
                List<Category> categories = null;
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {

                    categories = dataContext.Categoets.Where(x => x.CompanyID == CategoryID).ToList();
                    return categories;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

        public Category GetCategoryByID(int CategoryID)
        {
            try
            {
                Category category = null;
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {

                    category = dataContext.Categoets.SingleOrDefault(x => x.CategoryID == CategoryID);
                    return category;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        } 
    }
 }

