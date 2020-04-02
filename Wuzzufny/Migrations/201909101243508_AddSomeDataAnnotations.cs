namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.UserRoles");
            DropIndex("dbo.AspNetUsers", new[] { "Role_Id" });
            DropPrimaryKey("dbo.UserRoles");
            AlterColumn("dbo.AspNetUsers", "Role_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.UserRoles", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.UserRoles", "Id");
            CreateIndex("dbo.AspNetUsers", "Role_Id");
            AddForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.UserRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.UserRoles");
            DropIndex("dbo.AspNetUsers", new[] { "Role_Id" });
            DropPrimaryKey("dbo.UserRoles");
            AlterColumn("dbo.UserRoles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AspNetUsers", "Role_Id", c => c.Int());
            AddPrimaryKey("dbo.UserRoles", "Id");
            CreateIndex("dbo.AspNetUsers", "Role_Id");
            AddForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.UserRoles", "Id");
        }
    }
}
