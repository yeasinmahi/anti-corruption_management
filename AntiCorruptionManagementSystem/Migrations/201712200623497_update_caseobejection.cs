namespace AntiCorruptionManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCaseobejection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_CaseObjection", "ERNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_CaseObjection", "ERNumber", c => c.Int(nullable: false));
        }
    }
}
