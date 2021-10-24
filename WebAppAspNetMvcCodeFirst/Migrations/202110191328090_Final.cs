namespace WebAppAspNetMvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Groups", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "Sex", c => c.Int(nullable: false));
        }
    }
}
