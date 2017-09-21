namespace AntiCorruptionManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_Sajeka", "Wings_Sl", "dbo.tbl_Wing");
            DropIndex("dbo.tbl_Sajeka", new[] { "Wings_Sl" });
            DropColumn("dbo.tbl_Sajeka", "WingId");
            RenameColumn(table: "dbo.tbl_Sajeka", name: "Wings_Sl", newName: "WingId");
            AlterColumn("dbo.tbl_Sajeka", "WingId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_Sajeka", "WingId");
            AddForeignKey("dbo.tbl_Sajeka", "WingId", "dbo.tbl_Wing", "Sl", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Sajeka", "WingId", "dbo.tbl_Wing");
            DropIndex("dbo.tbl_Sajeka", new[] { "WingId" });
            AlterColumn("dbo.tbl_Sajeka", "WingId", c => c.Int());
            RenameColumn(table: "dbo.tbl_Sajeka", name: "WingId", newName: "Wings_Sl");
            AddColumn("dbo.tbl_Sajeka", "WingId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_Sajeka", "Wings_Sl");
            AddForeignKey("dbo.tbl_Sajeka", "Wings_Sl", "dbo.tbl_Wing", "Sl");
        }
    }
}
