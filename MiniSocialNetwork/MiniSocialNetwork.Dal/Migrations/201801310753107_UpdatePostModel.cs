namespace MiniSocialNetwork.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePostModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "AuthorName", c => c.String());
            AddColumn("dbo.Posts", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "AuthorId");
            AddForeignKey("dbo.Posts", "AuthorId", "dbo.UserProfiles", "Id");
            DropColumn("dbo.Posts", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Author", c => c.String());
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.UserProfiles");
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropColumn("dbo.Posts", "AuthorId");
            DropColumn("dbo.Posts", "AuthorName");
        }
    }
}
