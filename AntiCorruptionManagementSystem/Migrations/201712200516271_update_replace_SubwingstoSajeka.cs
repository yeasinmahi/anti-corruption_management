namespace AntiCorruptionManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReplaceSubwingstoSajeka : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_SubWing", "WingId", "dbo.tbl_Wing");
            DropForeignKey("dbo.tbl_InquiryWorkProgress", "SubWingId", "dbo.tbl_SubWing");
            DropForeignKey("dbo.tbl_InvestigationWorkProgress", "SubWingId", "dbo.tbl_SubWing");
            DropIndex("dbo.tbl_InquiryWorkProgress", new[] { "SubWingId" });
            DropIndex("dbo.tbl_SubWing", new[] { "WingId" });
            DropIndex("dbo.tbl_InvestigationWorkProgress", new[] { "SubWingId" });
            AddColumn("dbo.tbl_Case", "SajekaId", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_Accuser", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_InquiryWorkProgress", "SajekaId", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_InvestigationWorkProgress", "SajekaId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_Case", "SajekaId");
            CreateIndex("dbo.tbl_InquiryWorkProgress", "SajekaId");
            CreateIndex("dbo.tbl_InvestigationWorkProgress", "SajekaId");
            AddForeignKey("dbo.tbl_Case", "SajekaId", "dbo.tbl_Sajeka", "Sl", cascadeDelete: true);
            AddForeignKey("dbo.tbl_InquiryWorkProgress", "SajekaId", "dbo.tbl_Sajeka", "Sl", cascadeDelete: true);
            AddForeignKey("dbo.tbl_InvestigationWorkProgress", "SajekaId", "dbo.tbl_Sajeka", "Sl", cascadeDelete: true);
            DropColumn("dbo.tbl_InquiryWorkProgress", "SubWingId");
            DropColumn("dbo.tbl_InvestigationWorkProgress", "SubWingId");
            DropTable("dbo.tbl_SubWing");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tbl_SubWing",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        WingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl);
            
            AddColumn("dbo.tbl_InvestigationWorkProgress", "SubWingId", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_InquiryWorkProgress", "SubWingId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tbl_InvestigationWorkProgress", "SajekaId", "dbo.tbl_Sajeka");
            DropForeignKey("dbo.tbl_InquiryWorkProgress", "SajekaId", "dbo.tbl_Sajeka");
            DropForeignKey("dbo.tbl_Case", "SajekaId", "dbo.tbl_Sajeka");
            DropIndex("dbo.tbl_InvestigationWorkProgress", new[] { "SajekaId" });
            DropIndex("dbo.tbl_InquiryWorkProgress", new[] { "SajekaId" });
            DropIndex("dbo.tbl_Case", new[] { "SajekaId" });
            DropColumn("dbo.tbl_InvestigationWorkProgress", "SajekaId");
            DropColumn("dbo.tbl_InquiryWorkProgress", "SajekaId");
            DropColumn("dbo.tbl_Accuser", "IsActive");
            DropColumn("dbo.tbl_Case", "SajekaId");
            CreateIndex("dbo.tbl_InvestigationWorkProgress", "SubWingId");
            CreateIndex("dbo.tbl_SubWing", "WingId");
            CreateIndex("dbo.tbl_InquiryWorkProgress", "SubWingId");
            AddForeignKey("dbo.tbl_InvestigationWorkProgress", "SubWingId", "dbo.tbl_SubWing", "Sl", cascadeDelete: true);
            AddForeignKey("dbo.tbl_InquiryWorkProgress", "SubWingId", "dbo.tbl_SubWing", "Sl", cascadeDelete: true);
            AddForeignKey("dbo.tbl_SubWing", "WingId", "dbo.tbl_Wing", "Sl", cascadeDelete: true);
        }
    }
}
