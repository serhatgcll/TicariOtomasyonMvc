namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesMoves", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SalesMoves", "Current_Id", "dbo.Currents");
            DropForeignKey("dbo.SalesMoves", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.SalesMoves", new[] { "Current_Id" });
            DropIndex("dbo.SalesMoves", new[] { "Employee_Id" });
            DropIndex("dbo.SalesMoves", new[] { "Product_Id" });
            RenameColumn(table: "dbo.SalesMoves", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.SalesMoves", name: "Current_Id", newName: "CurrentId");
            RenameColumn(table: "dbo.SalesMoves", name: "Employee_Id", newName: "EmployeeId");
            AlterColumn("dbo.SalesMoves", "CurrentId", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesMoves", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesMoves", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesMoves", "ProductId");
            CreateIndex("dbo.SalesMoves", "CurrentId");
            CreateIndex("dbo.SalesMoves", "EmployeeId");
            AddForeignKey("dbo.SalesMoves", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SalesMoves", "CurrentId", "dbo.Currents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SalesMoves", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesMoves", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SalesMoves", "CurrentId", "dbo.Currents");
            DropForeignKey("dbo.SalesMoves", "ProductId", "dbo.Products");
            DropIndex("dbo.SalesMoves", new[] { "EmployeeId" });
            DropIndex("dbo.SalesMoves", new[] { "CurrentId" });
            DropIndex("dbo.SalesMoves", new[] { "ProductId" });
            AlterColumn("dbo.SalesMoves", "ProductId", c => c.Int());
            AlterColumn("dbo.SalesMoves", "EmployeeId", c => c.Int());
            AlterColumn("dbo.SalesMoves", "CurrentId", c => c.Int());
            RenameColumn(table: "dbo.SalesMoves", name: "EmployeeId", newName: "Employee_Id");
            RenameColumn(table: "dbo.SalesMoves", name: "CurrentId", newName: "Current_Id");
            RenameColumn(table: "dbo.SalesMoves", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.SalesMoves", "Product_Id");
            CreateIndex("dbo.SalesMoves", "Employee_Id");
            CreateIndex("dbo.SalesMoves", "Current_Id");
            AddForeignKey("dbo.SalesMoves", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.SalesMoves", "Current_Id", "dbo.Currents", "Id");
            AddForeignKey("dbo.SalesMoves", "Product_Id", "dbo.Products", "Id");
        }
    }
}
