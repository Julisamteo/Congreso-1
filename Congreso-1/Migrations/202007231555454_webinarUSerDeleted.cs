namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webinarUSerDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Webinar_WebinarId", "dbo.Webinars");
            DropIndex("dbo.AspNetUsers", new[] { "Webinar_WebinarId" });
            DropColumn("dbo.AspNetUsers", "Webinar_WebinarId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Webinar_WebinarId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Webinar_WebinarId");
            AddForeignKey("dbo.AspNetUsers", "Webinar_WebinarId", "dbo.Webinars", "WebinarId");
        }
    }
}
