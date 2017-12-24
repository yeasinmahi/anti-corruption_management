namespace AntiCorruptionManagementSystem.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_AccusedPersonInfo",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Designation = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        DateofCaseSubmission = c.DateTime(nullable: false),
                        CaseShortDescription = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CaseId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.tbl_Case", t => t.CaseId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_Employee", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.CaseId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.tbl_Case",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        CaseNumber = c.Int(nullable: false),
                        CaseDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        DateofIOTaken = c.DateTime(nullable: false),
                        ProgressDetails = c.String(nullable: false),
                        Remarks = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        WingId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.tbl_Employee", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_Wing", t => t.WingId, cascadeDelete: false)
                .Index(t => t.WingId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.tbl_Employee",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Designation = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        EmployeeId = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        WingId = c.Int(nullable: false),
                        SajekaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.tbl_Sajeka", t => t.SajekaId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_Wing", t => t.WingId, cascadeDelete: false)
                .Index(t => t.WingId)
                .Index(t => t.SajekaId);
            
            CreateTable(
                "dbo.tbl_Sajeka",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        WingId = c.Int(nullable: false),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.tbl_Wing", t => t.WingId, cascadeDelete: false)
                .Index(t => t.WingId);
            
            CreateTable(
                "dbo.tbl_Wing",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Sl);
            
            CreateTable(
                "dbo.tbl_Accuser",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Sl);
            
            CreateTable(
                "dbo.tbl_CaseObjection",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        ERNumber = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Designation = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        DateofObjection = c.DateTime(nullable: false),
                        ObjectionDetails = c.String(nullable: false),
                        InquiryMemorandumNumber = c.Int(nullable: false),
                        InquiryDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        WingId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.tbl_Employee", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_Wing", t => t.WingId, cascadeDelete: false)
                .Index(t => t.WingId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.tbl_InquiryWorkProgress",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        FileNumber = c.Int(nullable: false),
                        DateofInquiryOrder = c.DateTime(nullable: false),
                        ComplainDescription = c.String(nullable: false),
                        CurrentStatus = c.String(nullable: false),
                        Remarks = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AccuserId = c.Int(nullable: false),
                        WingId = c.Int(nullable: false),
                        SubWingId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.tbl_Accuser", t => t.AccuserId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_Employee", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_SubWing", t => t.SubWingId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_Wing", t => t.WingId, cascadeDelete: false)
                .Index(t => t.AccuserId)
                .Index(t => t.WingId)
                .Index(t => t.SubWingId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.tbl_SubWing",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        WingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.tbl_Wing", t => t.WingId, cascadeDelete: false)
                .Index(t => t.WingId);
            
            CreateTable(
                "dbo.tbl_InvestigationWorkProgress",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        FileNumber = c.Int(nullable: false),
                        DateofInvestigateOrder = c.DateTime(nullable: false),
                        ComplainDescription = c.String(nullable: false),
                        CurrentStatus = c.String(nullable: false),
                        Remarks = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AccuserId = c.Int(nullable: false),
                        WingId = c.Int(nullable: false),
                        SubWingId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.tbl_Accuser", t => t.AccuserId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_Employee", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_SubWing", t => t.SubWingId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_Wing", t => t.WingId, cascadeDelete: false)
                .Index(t => t.AccuserId)
                .Index(t => t.WingId)
                .Index(t => t.SubWingId)
                .Index(t => t.EmployeeId);
            
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
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                    })
                .PrimaryKey(t => t.Id)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tbl_InvestigationWorkProgress", "WingId", "dbo.tbl_Wing");
            DropForeignKey("dbo.tbl_InvestigationWorkProgress", "SubWingId", "dbo.tbl_SubWing");
            DropForeignKey("dbo.tbl_InvestigationWorkProgress", "EmployeeId", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_InvestigationWorkProgress", "AccuserId", "dbo.tbl_Accuser");
            DropForeignKey("dbo.tbl_InquiryWorkProgress", "WingId", "dbo.tbl_Wing");
            DropForeignKey("dbo.tbl_InquiryWorkProgress", "SubWingId", "dbo.tbl_SubWing");
            DropForeignKey("dbo.tbl_SubWing", "WingId", "dbo.tbl_Wing");
            DropForeignKey("dbo.tbl_InquiryWorkProgress", "EmployeeId", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_InquiryWorkProgress", "AccuserId", "dbo.tbl_Accuser");
            DropForeignKey("dbo.tbl_CaseObjection", "WingId", "dbo.tbl_Wing");
            DropForeignKey("dbo.tbl_CaseObjection", "EmployeeId", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_AccusedPersonInfo", "EmployeeId", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_AccusedPersonInfo", "CaseId", "dbo.tbl_Case");
            DropForeignKey("dbo.tbl_Case", "WingId", "dbo.tbl_Wing");
            DropForeignKey("dbo.tbl_Case", "EmployeeId", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_Employee", "WingId", "dbo.tbl_Wing");
            DropForeignKey("dbo.tbl_Employee", "SajekaId", "dbo.tbl_Sajeka");
            DropForeignKey("dbo.tbl_Sajeka", "WingId", "dbo.tbl_Wing");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.tbl_InvestigationWorkProgress", new[] { "EmployeeId" });
            DropIndex("dbo.tbl_InvestigationWorkProgress", new[] { "SubWingId" });
            DropIndex("dbo.tbl_InvestigationWorkProgress", new[] { "WingId" });
            DropIndex("dbo.tbl_InvestigationWorkProgress", new[] { "AccuserId" });
            DropIndex("dbo.tbl_SubWing", new[] { "WingId" });
            DropIndex("dbo.tbl_InquiryWorkProgress", new[] { "EmployeeId" });
            DropIndex("dbo.tbl_InquiryWorkProgress", new[] { "SubWingId" });
            DropIndex("dbo.tbl_InquiryWorkProgress", new[] { "WingId" });
            DropIndex("dbo.tbl_InquiryWorkProgress", new[] { "AccuserId" });
            DropIndex("dbo.tbl_CaseObjection", new[] { "EmployeeId" });
            DropIndex("dbo.tbl_CaseObjection", new[] { "WingId" });
            DropIndex("dbo.tbl_Sajeka", new[] { "WingId" });
            DropIndex("dbo.tbl_Employee", new[] { "SajekaId" });
            DropIndex("dbo.tbl_Employee", new[] { "WingId" });
            DropIndex("dbo.tbl_Case", new[] { "EmployeeId" });
            DropIndex("dbo.tbl_Case", new[] { "WingId" });
            DropIndex("dbo.tbl_AccusedPersonInfo", new[] { "EmployeeId" });
            DropIndex("dbo.tbl_AccusedPersonInfo", new[] { "CaseId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.tbl_InvestigationWorkProgress");
            DropTable("dbo.tbl_SubWing");
            DropTable("dbo.tbl_InquiryWorkProgress");
            DropTable("dbo.tbl_CaseObjection");
            DropTable("dbo.tbl_Accuser");
            DropTable("dbo.tbl_Wing");
            DropTable("dbo.tbl_Sajeka");
            DropTable("dbo.tbl_Employee");
            DropTable("dbo.tbl_Case");
            DropTable("dbo.tbl_AccusedPersonInfo");
        }
    }
}
