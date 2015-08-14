namespace SalesAndInventorySystemDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CompanyID = c.Int(nullable: false),
                        PersonType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.PersonTypes", t => t.PersonType_ID)
                .Index(t => t.PersonType_ID);
            
            CreateTable(
                "dbo.PersonTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Description = c.String(),
                        InsertDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        BarCode = c.String(),
                        Color = c.String(),
                        Size = c.String(),
                        Invoice_InvoiceID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID)
                .Index(t => t.CategoryID)
                .Index(t => t.Invoice_InvoiceID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(),
                        InvoiceDate = c.DateTime(nullable: false),
                        CostPrice = c.Double(nullable: false),
                        vat = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Due = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            CreateTable(
                "dbo.SellProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Size = c.String(),
                        Quantiry = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellProducts", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Products", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "PersonType_ID", "dbo.PersonTypes");
            DropIndex("dbo.SellProducts", new[] { "InvoiceID" });
            DropIndex("dbo.Products", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Categories", new[] { "PersonType_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.SellProducts");
            DropTable("dbo.Invoices");
            DropTable("dbo.Products");
            DropTable("dbo.PersonTypes");
            DropTable("dbo.Categories");
        }
    }
}
