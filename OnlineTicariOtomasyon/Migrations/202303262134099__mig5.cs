namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DepartmantId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "DepartmantId");
        }
    }
}
