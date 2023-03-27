namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesMoves", "Date_", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalesMoves", "_Date", c => c.DateTime(nullable: false));
        }
    }
}
