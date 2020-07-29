namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webinar3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Webinars", "Congress_CongressId", "dbo.Congresses");
            DropIndex("dbo.Webinars", new[] { "Congress_CongressId" });
            RenameColumn(table: "dbo.Webinars", name: "Congress_CongressId", newName: "CongressId");
            AlterColumn("dbo.Webinars", "CongressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Webinars", "CongressId");
            AddForeignKey("dbo.Webinars", "CongressId", "dbo.Congresses", "CongressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Webinars", "CongressId", "dbo.Congresses");
            DropIndex("dbo.Webinars", new[] { "CongressId" });
            AlterColumn("dbo.Webinars", "CongressId", c => c.Int());
            RenameColumn(table: "dbo.Webinars", name: "CongressId", newName: "Congress_CongressId");
            CreateIndex("dbo.Webinars", "Congress_CongressId");
            AddForeignKey("dbo.Webinars", "Congress_CongressId", "dbo.Congresses", "CongressId");
        }
    }
}
