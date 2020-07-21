namespace Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Server3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        AcceptorId = c.Int(nullable: false),
                        IsAccept = c.Boolean(nullable: false),
                        Friend_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AcceptorId, cascadeDelete: false)
                .ForeignKey("dbo.Friends", t => t.Friend_Id)
                .ForeignKey("dbo.Users", t => t.SenderId, cascadeDelete: false)
                .Index(t => t.SenderId)
                .Index(t => t.AcceptorId)
                .Index(t => t.Friend_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 95),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Posts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Friends", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Friends", "Friend_Id", "dbo.Friends");
            DropForeignKey("dbo.Friends", "AcceptorId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Friends", new[] { "Friend_Id" });
            DropIndex("dbo.Friends", new[] { "AcceptorId" });
            DropIndex("dbo.Friends", new[] { "SenderId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Friends");
        }
    }
}
