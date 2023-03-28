namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceExpenses", "Invoice_Id", "dbo.Invoices");
            DropIndex("dbo.InvoiceExpenses", new[] { "Invoice_Id" });
            RenameColumn(table: "dbo.InvoiceExpenses", name: "Invoice_Id", newName: "InvoiceId");
            AlterColumn("dbo.InvoiceExpenses", "InvoiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoiceExpenses", "InvoiceId");
            AddForeignKey("dbo.InvoiceExpenses", "InvoiceId", "dbo.Invoices", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceExpenses", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.InvoiceExpenses", new[] { "InvoiceId" });
            AlterColumn("dbo.InvoiceExpenses", "InvoiceId", c => c.Int());
            RenameColumn(table: "dbo.InvoiceExpenses", name: "InvoiceId", newName: "Invoice_Id");
            CreateIndex("dbo.InvoiceExpenses", "Invoice_Id");
            AddForeignKey("dbo.InvoiceExpenses", "Invoice_Id", "dbo.Invoices", "Id");
        }
    }
}
