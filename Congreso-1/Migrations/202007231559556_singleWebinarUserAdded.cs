namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class singleWebinarUserAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Webinars", "User_ID_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Webinars", "User_ID_Id");
            AddForeignKey("dbo.Webinars", "User_ID_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Webinars", "User_ID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Webinars", new[] { "User_ID_Id" });
            DropColumn("dbo.Webinars", "User_ID_Id");
        }
    }
}
