namespace Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Server6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 4000));
        }
    }
}
