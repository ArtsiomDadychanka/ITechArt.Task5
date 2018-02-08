namespace MiniSocialNetwork.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dialogs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OneUserId = c.String(maxLength: 128),
                        OtherUserId = c.String(maxLength: 128),
                        UserProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.OneUserId)
                .ForeignKey("dbo.UserProfiles", t => t.OtherUserId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .Index(t => t.OneUserId)
                .Index(t => t.OtherUserId)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        Time = c.DateTime(nullable: false),
                        DialogId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dialogs", t => t.DialogId)
                .Index(t => t.DialogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "DialogId", "dbo.Dialogs");
            DropForeignKey("dbo.Dialogs", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Dialogs", "OtherUserId", "dbo.UserProfiles");
            DropForeignKey("dbo.Dialogs", "OneUserId", "dbo.UserProfiles");
            DropIndex("dbo.Messages", new[] { "DialogId" });
            DropIndex("dbo.Dialogs", new[] { "UserProfile_Id" });
            DropIndex("dbo.Dialogs", new[] { "OtherUserId" });
            DropIndex("dbo.Dialogs", new[] { "OneUserId" });
            DropTable("dbo.Messages");
            DropTable("dbo.Dialogs");
        }
    }
}
