namespace WebAppAspNetMvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "NumberOfStudents", c => c.Int(nullable: false));
            DropColumn("dbo.Groups", "FIO");
            DropColumn("dbo.Groups", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "Age", c => c.Int());
            AddColumn("dbo.Groups", "FIO", c => c.String(nullable: false));
            DropColumn("dbo.Groups", "NumberOfStudents");
        }
    }
}
