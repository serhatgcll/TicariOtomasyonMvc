namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currents", "CurrentPassword", c => c.String(maxLength: 40, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Currents", "CurrentPassword");
        }
    }
}
