namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesMoves", "_Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalesMoves", "_Date", c => c.DateTime(nullable: false));
        }
    }
}
