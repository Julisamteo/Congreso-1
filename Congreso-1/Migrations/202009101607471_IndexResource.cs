namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexResource : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Digital_Resource", "Index", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Digital_Resource", "Index");
        }
    }
}
