namespace AntiCorruptionManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInvestigationandinquiry1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_InquiryWorkProgress", "FileNumber", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_InvestigationWorkProgress", "FileNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_InvestigationWorkProgress", "FileNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_InquiryWorkProgress", "FileNumber", c => c.Int(nullable: false));
        }
    }
}
