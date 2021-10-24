namespace WebAppAspNetMvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "GroupName", c => c.String(nullable: false));
            AddColumn("dbo.Lessons", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Groups", "FIO", c => c.String(nullable: false));
            DropColumn("dbo.Groups", "Groups");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "Groups", c => c.String());
            AlterColumn("dbo.Groups", "FIO", c => c.String());
            DropColumn("dbo.Lessons", "Name");
            DropColumn("dbo.Groups", "GroupName");
        }
    }
}
