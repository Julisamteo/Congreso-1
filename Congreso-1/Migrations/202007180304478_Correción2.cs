namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correción2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Digital_Resource", "Stand_Stand_id", "dbo.Stands");
            DropIndex("dbo.Digital_Resource", new[] { "Stand_Stand_id" });
            DropColumn("dbo.Digital_Resource", "Stand_Stand_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Digital_Resource", "Stand_Stand_id", c => c.Int());
            CreateIndex("dbo.Digital_Resource", "Stand_Stand_id");
            AddForeignKey("dbo.Digital_Resource", "Stand_Stand_id", "dbo.Stands", "Stand_id");
        }
    }
}
