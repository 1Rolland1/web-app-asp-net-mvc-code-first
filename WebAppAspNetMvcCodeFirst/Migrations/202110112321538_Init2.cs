namespace WebAppAspNetMvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        Data = c.Binary(nullable: false),
                        ContentType = c.String(maxLength: 100),
                        DateChanged = c.DateTime(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            AddColumn("dbo.Lessons", "TeacherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Groups", "Sex", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "TeacherId");
            AddForeignKey("dbo.Lessons", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            DropColumn("dbo.Lessons", "Teacher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Teacher", c => c.String());
            DropForeignKey("dbo.TeacherImages", "Id", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.TeacherImages", new[] { "Id" });
            DropIndex("dbo.Lessons", new[] { "TeacherId" });
            AlterColumn("dbo.Groups", "Sex", c => c.String());
            DropColumn("dbo.Lessons", "TeacherId");
            DropTable("dbo.TeacherImages");
            DropTable("dbo.Teachers");
        }
    }
}
