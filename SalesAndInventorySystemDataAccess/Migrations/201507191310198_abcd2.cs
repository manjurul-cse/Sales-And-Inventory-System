namespace SalesAndInventorySystemDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abcd2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Vat", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Vat");
        }
    }
}
