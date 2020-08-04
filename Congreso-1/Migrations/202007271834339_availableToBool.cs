namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class availableToBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Webinars", "available", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Webinars", "available", c => c.Int(nullable: false));
        }
    }
}
