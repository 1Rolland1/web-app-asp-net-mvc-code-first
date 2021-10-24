namespace WebAppAspNetMvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Sex");
        }
    }
}
