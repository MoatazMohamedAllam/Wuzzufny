namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideRelationBetweenAppUserAndEmployeeTbls : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "User_Id" });
            RenameColumn(table: "dbo.Employees", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Employees", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "UserId");
            AddForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "UserId" });
            AlterColumn("dbo.Employees", "UserId", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.Employees", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Employees", "User_Id");
            AddForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
