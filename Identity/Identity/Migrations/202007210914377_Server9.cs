namespace Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Server9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "AcceptorId", "dbo.Users");
            DropForeignKey("dbo.Friends", "Friend_Id", "dbo.Friends");
            DropForeignKey("dbo.Friends", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Posts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropIndex("dbo.Friends", new[] { "SenderId" });
            DropIndex("dbo.Friends", new[] { "AcceptorId" });
            DropIndex("dbo.Friends", new[] { "Friend_Id" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "Post_Id" });
            DropTable("dbo.Friends");
            DropTable("dbo.Posts");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Posts", "Post_Id");
            CreateIndex("dbo.Posts", "UserId");
            CreateIndex("dbo.Friends", "Friend_Id");
            CreateIndex("dbo.Friends", "AcceptorId");
            CreateIndex("dbo.Friends", "SenderId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.Friends", "SenderId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Friends", "Friend_Id", "dbo.Friends", "Id");
            AddForeignKey("dbo.Friends", "AcceptorId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
