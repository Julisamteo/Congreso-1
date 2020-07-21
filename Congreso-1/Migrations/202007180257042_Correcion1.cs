namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcion1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "City_CityId", c => c.Int());
            AddColumn("dbo.Webinars", "Congress_CongressId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "City_CityId");
            CreateIndex("dbo.Webinars", "Congress_CongressId");
            AddForeignKey("dbo.AspNetUsers", "City_CityId", "dbo.Cities", "CityId");
            AddForeignKey("dbo.Webinars", "Congress_CongressId", "dbo.Congresses", "CongressId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Webinars", "Congress_CongressId", "dbo.Congresses");
            DropForeignKey("dbo.AspNetUsers", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Webinars", new[] { "Congress_CongressId" });
            DropIndex("dbo.AspNetUsers", new[] { "City_CityId" });
            DropColumn("dbo.Webinars", "Congress_CongressId");
            DropColumn("dbo.AspNetUsers", "City_CityId");
        }
    }
}
