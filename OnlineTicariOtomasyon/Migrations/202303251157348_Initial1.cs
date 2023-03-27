namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Currents", "SalesMove_Id", "dbo.SalesMoves");
            DropForeignKey("dbo.Employees", "SalesMove_Id", "dbo.SalesMoves");
            DropForeignKey("dbo.Products", "SalesMove_Id", "dbo.SalesMoves");
            DropIndex("dbo.Products", new[] { "SalesMove_Id" });
            DropIndex("dbo.Currents", new[] { "SalesMove_Id" });
            DropIndex("dbo.Employees", new[] { "SalesMove_Id" });
            AddColumn("dbo.SalesMoves", "Current_Id", c => c.Int());
            AddColumn("dbo.SalesMoves", "Employee_Id", c => c.Int());
            AddColumn("dbo.SalesMoves", "Product_Id", c => c.Int());
            CreateIndex("dbo.SalesMoves", "Current_Id");
            CreateIndex("dbo.SalesMoves", "Employee_Id");
            CreateIndex("dbo.SalesMoves", "Product_Id");
            AddForeignKey("dbo.SalesMoves", "Current_Id", "dbo.Currents", "Id");
            AddForeignKey("dbo.SalesMoves", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.SalesMoves", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Products", "SalesMove_Id");
            DropColumn("dbo.Currents", "SalesMove_Id");
            DropColumn("dbo.Employees", "SalesMove_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "SalesMove_Id", c => c.Int());
            AddColumn("dbo.Currents", "SalesMove_Id", c => c.Int());
            AddColumn("dbo.Products", "SalesMove_Id", c => c.Int());
            DropForeignKey("dbo.SalesMoves", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SalesMoves", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.SalesMoves", "Current_Id", "dbo.Currents");
            DropIndex("dbo.SalesMoves", new[] { "Product_Id" });
            DropIndex("dbo.SalesMoves", new[] { "Employee_Id" });
            DropIndex("dbo.SalesMoves", new[] { "Current_Id" });
            DropColumn("dbo.SalesMoves", "Product_Id");
            DropColumn("dbo.SalesMoves", "Employee_Id");
            DropColumn("dbo.SalesMoves", "Current_Id");
            CreateIndex("dbo.Employees", "SalesMove_Id");
            CreateIndex("dbo.Currents", "SalesMove_Id");
            CreateIndex("dbo.Products", "SalesMove_Id");
            AddForeignKey("dbo.Products", "SalesMove_Id", "dbo.SalesMoves", "Id");
            AddForeignKey("dbo.Employees", "SalesMove_Id", "dbo.SalesMoves", "Id");
            AddForeignKey("dbo.Currents", "SalesMove_Id", "dbo.SalesMoves", "Id");
        }
    }
}
