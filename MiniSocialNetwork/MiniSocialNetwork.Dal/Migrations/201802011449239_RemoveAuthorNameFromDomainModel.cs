namespace MiniSocialNetwork.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAuthorNameFromDomainModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "AuthorName");
            DropColumn("dbo.Posts", "AuthorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "AuthorName", c => c.String());
            AddColumn("dbo.Comments", "AuthorName", c => c.String());
        }
    }
}
