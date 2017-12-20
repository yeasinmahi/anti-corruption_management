namespace AntiCorruptionManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_casenumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Case", "CaseNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Case", "CaseNumber", c => c.Int(nullable: false));
        }
    }
}
