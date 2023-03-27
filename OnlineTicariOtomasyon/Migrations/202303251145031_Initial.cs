namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 30, unicode: false),
                        Password = c.String(maxLength: 30, unicode: false),
                        Authority = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 40, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 50, unicode: false),
                        Brand = c.String(maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                        BuyingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        İmageUrl = c.String(maxLength: 250, unicode: false),
                        Stock = c.Short(nullable: false),
                        CriticalCount = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                        SalesMove_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.SalesMoves", t => t.SalesMove_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.SalesMove_Id);
            
            CreateTable(
                "dbo.SalesMoves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _Date = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentName = c.String(maxLength: 30, unicode: false),
                        CurrentSurname = c.String(maxLength: 30, unicode: false),
                        CurrentDescription = c.String(maxLength: 100, unicode: false),
                        City = c.String(maxLength: 40, unicode: false),
                        Email = c.String(maxLength: 40, unicode: false),
                        Status = c.Boolean(nullable: false),
                        SalesMove_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalesMoves", t => t.SalesMove_Id)
                .Index(t => t.SalesMove_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(maxLength: 50, unicode: false),
                        EmployeeSurname = c.String(maxLength: 50, unicode: false),
                        ImageUrl = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        Department_Id = c.Int(),
                        SalesMove_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.SalesMoves", t => t.SalesMove_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.SalesMove_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenditures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        _Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceExpenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        Amount = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .Index(t => t.Invoice_Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        RowNo = c.String(maxLength: 10, unicode: false),
                        _Date = c.DateTime(nullable: false),
                        TaxOffice = c.String(maxLength: 50, unicode: false),
                        _Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceExpenses", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.Products", "SalesMove_Id", "dbo.SalesMoves");
            DropForeignKey("dbo.Employees", "SalesMove_Id", "dbo.SalesMoves");
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Currents", "SalesMove_Id", "dbo.SalesMoves");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.InvoiceExpenses", new[] { "Invoice_Id" });
            DropIndex("dbo.Employees", new[] { "SalesMove_Id" });
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            DropIndex("dbo.Currents", new[] { "SalesMove_Id" });
            DropIndex("dbo.Products", new[] { "SalesMove_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceExpenses");
            DropTable("dbo.Expenditures");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Currents");
            DropTable("dbo.SalesMoves");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
