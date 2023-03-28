namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "RowNo", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "RowNo", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
