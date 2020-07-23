namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        City_CityId = c.Int(),
                        Webinar_WebinarId = c.Int(),
                        Enterprise_EnterpriseId = c.Int(),
                        UserInteractions_UserInteractionsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_CityId)
                .ForeignKey("dbo.Webinars", t => t.Webinar_WebinarId)
                .ForeignKey("dbo.Enterprises", t => t.Enterprise_EnterpriseId)
                .ForeignKey("dbo.UserInteractions", t => t.UserInteractions_UserInteractionsId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.City_CityId)
                .Index(t => t.Webinar_WebinarId)
                .Index(t => t.Enterprise_EnterpriseId)
                .Index(t => t.UserInteractions_UserInteractionsId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Congresses",
                c => new
                    {
                        CongressId = c.Int(nullable: false, identity: true),
                        CongressName = c.String(),
                        CongressTheme = c.String(),
                        CongressInitialDate = c.DateTime(nullable: false),
                        CongressFinalDate = c.DateTime(nullable: false),
                        Available = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CongressId);
            
            CreateTable(
                "dbo.Webinars",
                c => new
                    {
                        WebinarId = c.Int(nullable: false, identity: true),
                        WebinarTheme = c.String(),
                        WebinarInitialDate = c.DateTime(nullable: false),
                        WebinarEndDate = c.DateTime(nullable: false),
                        UserCount = c.Int(nullable: false),
                        available = c.Int(nullable: false),
                        Congress_CongressId = c.Int(),
                    })
                .PrimaryKey(t => t.WebinarId)
                .ForeignKey("dbo.Congresses", t => t.Congress_CongressId)
                .Index(t => t.Congress_CongressId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Available = c.Int(nullable: false),
                        Webinar_Id = c.Int(nullable: false),
                        Webinar_WebinarId = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Webinars", t => t.Webinar_WebinarId)
                .Index(t => t.Webinar_WebinarId);
            
            CreateTable(
                "dbo.Congress_Enterprise",
                c => new
                    {
                        CongressId = c.Int(nullable: false, identity: true),
                        EnterpriseId = c.Int(nullable: false),
                        StandId = c.Int(nullable: false),
                        Congress_CongressId = c.Int(),
                        Stand_Stand_id = c.Int(),
                    })
                .PrimaryKey(t => t.CongressId)
                .ForeignKey("dbo.Congresses", t => t.Congress_CongressId)
                .ForeignKey("dbo.Enterprises", t => t.EnterpriseId, cascadeDelete: true)
                .ForeignKey("dbo.Stands", t => t.Stand_Stand_id)
                .Index(t => t.EnterpriseId)
                .Index(t => t.Congress_CongressId)
                .Index(t => t.Stand_Stand_id);
            
            CreateTable(
                "dbo.Enterprises",
                c => new
                    {
                        EnterpriseId = c.Int(nullable: false, identity: true),
                        EnterpiseNit = c.Int(nullable: false),
                        EnterpriseVerification = c.Int(nullable: false),
                        EnterpriseName = c.String(),
                        Available = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnterpriseId);
            
            CreateTable(
                "dbo.Stands",
                c => new
                    {
                        Stand_id = c.Int(nullable: false, identity: true),
                        StandTypeId = c.Int(nullable: false),
                        Available = c.Int(nullable: false),
                        Stand_Type_StandType = c.Int(),
                    })
                .PrimaryKey(t => t.Stand_id)
                .ForeignKey("dbo.Stand_Type", t => t.Stand_Type_StandType)
                .Index(t => t.Stand_Type_StandType);
            
            CreateTable(
                "dbo.Stand_Type",
                c => new
                    {
                        StandType = c.Int(nullable: false, identity: true),
                        StandName = c.String(),
                        EnterpriseLogo = c.String(),
                        EnterpriseBanner = c.String(),
                        StandBody = c.String(),
                        StandResourceA = c.String(),
                        StandResourceB = c.String(),
                        StandResourceC = c.String(),
                    })
                .PrimaryKey(t => t.StandType);
            
            CreateTable(
                "dbo.Digital_Resource",
                c => new
                    {
                        DresourceId = c.Int(nullable: false, identity: true),
                        ResourceUrl = c.String(),
                        ResourceHtml = c.String(),
                        Available = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DresourceId);
            
            CreateTable(
                "dbo.Stand_Resource",
                c => new
                    {
                        StandId = c.Int(nullable: false, identity: true),
                        DResourceId = c.Int(nullable: false),
                        Stand_Stand_id = c.Int(),
                    })
                .PrimaryKey(t => t.StandId)
                .ForeignKey("dbo.Digital_Resource", t => t.DResourceId, cascadeDelete: true)
                .ForeignKey("dbo.Stands", t => t.Stand_Stand_id)
                .Index(t => t.DResourceId)
                .Index(t => t.Stand_Stand_id);
            
            CreateTable(
                "dbo.UserInteractions",
                c => new
                    {
                        UserInteractionsId = c.Int(nullable: false, identity: true),
                        StandId = c.Int(nullable: false),
                        StandCount = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                        ResourceCount = c.Int(nullable: false),
                        WebinarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserInteractionsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserInteractions_UserInteractionsId", "dbo.UserInteractions");
            DropForeignKey("dbo.Stand_Resource", "Stand_Stand_id", "dbo.Stands");
            DropForeignKey("dbo.Stand_Resource", "DResourceId", "dbo.Digital_Resource");
            DropForeignKey("dbo.Stands", "Stand_Type_StandType", "dbo.Stand_Type");
            DropForeignKey("dbo.Congress_Enterprise", "Stand_Stand_id", "dbo.Stands");
            DropForeignKey("dbo.AspNetUsers", "Enterprise_EnterpriseId", "dbo.Enterprises");
            DropForeignKey("dbo.Congress_Enterprise", "EnterpriseId", "dbo.Enterprises");
            DropForeignKey("dbo.Congress_Enterprise", "Congress_CongressId", "dbo.Congresses");
            DropForeignKey("dbo.Webinars", "Congress_CongressId", "dbo.Congresses");
            DropForeignKey("dbo.AspNetUsers", "Webinar_WebinarId", "dbo.Webinars");
            DropForeignKey("dbo.Schedules", "Webinar_WebinarId", "dbo.Webinars");
            DropForeignKey("dbo.AspNetUsers", "City_CityId", "dbo.Cities");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Stand_Resource", new[] { "Stand_Stand_id" });
            DropIndex("dbo.Stand_Resource", new[] { "DResourceId" });
            DropIndex("dbo.Stands", new[] { "Stand_Type_StandType" });
            DropIndex("dbo.Congress_Enterprise", new[] { "Stand_Stand_id" });
            DropIndex("dbo.Congress_Enterprise", new[] { "Congress_CongressId" });
            DropIndex("dbo.Congress_Enterprise", new[] { "EnterpriseId" });
            DropIndex("dbo.Schedules", new[] { "Webinar_WebinarId" });
            DropIndex("dbo.Webinars", new[] { "Congress_CongressId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserInteractions_UserInteractionsId" });
            DropIndex("dbo.AspNetUsers", new[] { "Enterprise_EnterpriseId" });
            DropIndex("dbo.AspNetUsers", new[] { "Webinar_WebinarId" });
            DropIndex("dbo.AspNetUsers", new[] { "City_CityId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.UserInteractions");
            DropTable("dbo.Stand_Resource");
            DropTable("dbo.Digital_Resource");
            DropTable("dbo.Stand_Type");
            DropTable("dbo.Stands");
            DropTable("dbo.Enterprises");
            DropTable("dbo.Congress_Enterprise");
            DropTable("dbo.Schedules");
            DropTable("dbo.Webinars");
            DropTable("dbo.Congresses");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
