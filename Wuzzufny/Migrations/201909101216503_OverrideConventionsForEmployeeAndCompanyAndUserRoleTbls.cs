namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForEmployeeAndCompanyAndUserRoleTbls : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Companies", new[] { "User_Id" });
            DropIndex("dbo.Employees", new[] { "User_Id" });
            AlterColumn("dbo.Companies", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserRoles", "RoleName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Companies", "User_Id");
            CreateIndex("dbo.Employees", "User_Id");
            AddForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "User_Id" });
            DropIndex("dbo.Companies", new[] { "User_Id" });
            AlterColumn("dbo.Employees", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserRoles", "RoleName", c => c.String());
            AlterColumn("dbo.Companies", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "User_Id");
            CreateIndex("dbo.Companies", "User_Id");
            AddForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
