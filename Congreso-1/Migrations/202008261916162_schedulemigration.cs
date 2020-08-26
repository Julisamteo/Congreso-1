namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schedulemigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "Available", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "Available", c => c.Int(nullable: false));
        }
    }
}
