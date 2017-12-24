namespace AntiCorruptionManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCaseobejection1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_CaseObjection", "InquiryMemorandumNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_CaseObjection", "InquiryMemorandumNumber", c => c.Int(nullable: false));
        }
    }
}
