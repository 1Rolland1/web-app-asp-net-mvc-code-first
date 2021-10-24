namespace WebAppAspNetMvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Groups = c.String(),
                        FIO = c.String(),
                        Age = c.Int(),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Teacher = c.String(),
                        number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LessonGroups",
                c => new
                    {
                        Lesson_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lesson_Id, t.Group_Id })
                .ForeignKey("dbo.Lessons", t => t.Lesson_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.Lesson_Id)
                .Index(t => t.Group_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.LessonGroups", "Lesson_Id", "dbo.Lessons");
            DropIndex("dbo.LessonGroups", new[] { "Group_Id" });
            DropIndex("dbo.LessonGroups", new[] { "Lesson_Id" });
            DropTable("dbo.LessonGroups");
            DropTable("dbo.Lessons");
            DropTable("dbo.Groups");
        }
    }
}
