namespace SalesAndInventorySystemDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abcd1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "BuyPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Discount");
            DropColumn("dbo.Products", "BuyPrice");
        }
    }
}
