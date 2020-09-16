namespace Congreso_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
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
                "dbo.Congresses",
                c => new
                    {
                        CongressId = c.Int(nullable: false, identity: true),
                        CongressName = c.String(),
                        CongressTheme = c.String(),
                        CongressInitialDate = c.DateTime(nullable: false),
                        CongressFinalDate = c.DateTime(nullable: false),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CongressId);
            
            CreateTable(
                "dbo.Congress_Enterprise",
                c => new
                    {
                        CongressId = c.Int(nullable: false),
                        EnterpriseId = c.Int(nullable: false),
                        StandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CongressId, t.EnterpriseId, t.StandId })
                .ForeignKey("dbo.Congresses", t => t.CongressId, cascadeDelete: true)
                .ForeignKey("dbo.Enterprises", t => t.EnterpriseId, cascadeDelete: true)
                .ForeignKey("dbo.Stands", t => t.StandId, cascadeDelete: true)
                .Index(t => t.CongressId)
                .Index(t => t.EnterpriseId)
                .Index(t => t.StandId);
            
            CreateTable(
                "dbo.Enterprises",
                c => new
                    {
                        EnterpriseId = c.Int(nullable: false, identity: true),
                        EnterpiseNit = c.Int(nullable: false),
                        EnterpriseName = c.String(),
                        EnterprisePhoneNumber = c.String(),
                        EnterpriseEmail = c.String(),
                        Available = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnterpriseId);
            
            CreateTable(
                "dbo.Stands",
                c => new
                    {
                        Stand_id = c.Int(nullable: false, identity: true),
                        StandTypeId = c.Int(nullable: false),
                        EnterpriseLogo = c.String(),
                        EnterpriseBanner = c.String(),
                        StandColorA = c.String(),
                        StandColorB = c.String(),
                        StandColorC = c.String(),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Stand_id)
                .ForeignKey("dbo.Stand_Type", t => t.StandTypeId, cascadeDelete: true)
                .Index(t => t.StandTypeId);
            
            CreateTable(
                "dbo.Stand_Type",
                c => new
                    {
                        StandType = c.Int(nullable: false, identity: true),
                        StandName = c.String(),
                        StandDescription = c.String(),
                        ResourceQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StandType);
            
            CreateTable(
                "dbo.Digital_Resource",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        ResourceUrl = c.String(),
                        ResourceHtml = c.String(),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Available = c.Boolean(nullable: false),
                        Webinar_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Webinars", t => t.Webinar_Id, cascadeDelete: true)
                .Index(t => t.Webinar_Id);
            
            CreateTable(
                "dbo.Webinars",
                c => new
                    {
                        WebinarId = c.Int(nullable: false, identity: true),
                        WebinarTheme = c.String(),
                        WebinarInitialDate = c.DateTime(nullable: false),
                        WebinarEndDate = c.DateTime(nullable: false),
                        UserCount = c.Int(nullable: false),
                        available = c.Boolean(nullable: false),
                        CongressId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.WebinarId)
                .ForeignKey("dbo.Congresses", t => t.CongressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CongressId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Rol = c.Int(nullable: false),
                        EnterpriseId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Enterprises", t => t.EnterpriseId, cascadeDelete: true)
                .Index(t => t.EnterpriseId)
                .Index(t => t.CityId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
                "dbo.Stand_Resource",
                c => new
                    {
                        StandId = c.Int(nullable: false),
                        DResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StandId, t.DResourceId })
                .ForeignKey("dbo.Digital_Resource", t => t.DResourceId, cascadeDelete: true)
                .ForeignKey("dbo.Stands", t => t.StandId, cascadeDelete: true)
                .Index(t => t.StandId)
                .Index(t => t.DResourceId);
            
            CreateTable(
                "dbo.UserInteractions",
                c => new
                    {
                        UserInteractionsId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        StandId = c.Int(nullable: false),
                        StandCount = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                        ResourceCount = c.Int(nullable: false),
                        WebinarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserInteractionsId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInteractions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Stand_Resource", "StandId", "dbo.Stands");
            DropForeignKey("dbo.Stand_Resource", "DResourceId", "dbo.Digital_Resource");
            DropForeignKey("dbo.Schedules", "Webinar_Id", "dbo.Webinars");
            DropForeignKey("dbo.Webinars", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "EnterpriseId", "dbo.Enterprises");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Webinars", "CongressId", "dbo.Congresses");
            DropForeignKey("dbo.Congress_Enterprise", "StandId", "dbo.Stands");
            DropForeignKey("dbo.Stands", "StandTypeId", "dbo.Stand_Type");
            DropForeignKey("dbo.Congress_Enterprise", "EnterpriseId", "dbo.Enterprises");
            DropForeignKey("dbo.Congress_Enterprise", "CongressId", "dbo.Congresses");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.UserInteractions", new[] { "UserId" });
            DropIndex("dbo.Stand_Resource", new[] { "DResourceId" });
            DropIndex("dbo.Stand_Resource", new[] { "StandId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "CityId" });
            DropIndex("dbo.AspNetUsers", new[] { "EnterpriseId" });
            DropIndex("dbo.Webinars", new[] { "UserId" });
            DropIndex("dbo.Webinars", new[] { "CongressId" });
            DropIndex("dbo.Schedules", new[] { "Webinar_Id" });
            DropIndex("dbo.Stands", new[] { "StandTypeId" });
            DropIndex("dbo.Congress_Enterprise", new[] { "StandId" });
            DropIndex("dbo.Congress_Enterprise", new[] { "EnterpriseId" });
            DropIndex("dbo.Congress_Enterprise", new[] { "CongressId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.UserInteractions");
            DropTable("dbo.Stand_Resource");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Webinars");
            DropTable("dbo.Schedules");
            DropTable("dbo.Digital_Resource");
            DropTable("dbo.Stand_Type");
            DropTable("dbo.Stands");
            DropTable("dbo.Enterprises");
            DropTable("dbo.Congress_Enterprise");
            DropTable("dbo.Congresses");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
