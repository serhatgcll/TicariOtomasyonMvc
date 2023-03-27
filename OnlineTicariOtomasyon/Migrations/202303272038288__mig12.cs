namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesMoves", "Date_", c => c.DateTime(nullable: false));
            DropColumn("dbo.SalesMoves", "_Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesMoves", "_Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.SalesMoves", "Date_");
        }
    }
}
