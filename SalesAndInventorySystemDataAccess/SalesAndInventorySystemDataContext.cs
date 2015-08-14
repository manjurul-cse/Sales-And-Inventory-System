using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAndInventorySystemModel;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemDataAccess
{
     
    public class SalesAndInventorySystemDataContext : DbContext
    {
        public DbSet<PersonType> Companies { get; set; }
        public DbSet<Category> Categoets { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<SellProduct> SellProducts { get; set; }
        public DbSet<User> Users { get; set; }

        public SalesAndInventorySystemDataContext() : base("SalesAndInventorySystemBD")
        {
            Database.SetInitializer<SalesAndInventorySystemDataContext>(new DropCreateDatabaseIfModelChanges<SalesAndInventorySystemDataContext>());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //   // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
