namespace MiniSocialNetwork.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikesAndComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AuthorName = c.String(),
                        Text = c.String(),
                        PostedTime = c.DateTime(nullable: false),
                        PostId = c.String(maxLength: 128),
                        AuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .ForeignKey("dbo.UserProfiles", t => t.AuthorId)
                .Index(t => t.PostId)
                .Index(t => t.AuthorId);
            
            AddColumn("dbo.Posts", "Likes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.UserProfiles");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropColumn("dbo.Posts", "Likes");
            DropTable("dbo.Comments");
        }
    }
}
