namespace Dworki.Blog.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 20),
                        Contents = c.String(),
                        Visibility = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 20),
                        Contents = c.String(),
                        Visibility = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 20));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pages", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.PostTags", new[] { "TagId" });
            DropIndex("dbo.PostTags", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "ApplicationUserId" });
            DropIndex("dbo.Pages", new[] { "ApplicationUserId" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
            DropTable("dbo.Posts");
            DropTable("dbo.Pages");
        }
    }
}
