namespace WebAppAspNetMvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lessons", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lessons", "Name", c => c.Int(nullable: false));
        }
    }
}
