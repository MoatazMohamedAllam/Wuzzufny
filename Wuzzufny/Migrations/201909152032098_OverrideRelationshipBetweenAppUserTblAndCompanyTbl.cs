namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideRelationshipBetweenAppUserTblAndCompanyTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Companies", new[] { "User_Id" });
            RenameColumn(table: "dbo.Companies", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Companies", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Companies", "UserId");
            AddForeignKey("dbo.Companies", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Companies", new[] { "UserId" });
            AlterColumn("dbo.Companies", "UserId", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.Companies", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Companies", "User_Id");
            AddForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
