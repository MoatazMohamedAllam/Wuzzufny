namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropUserRolesTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.UserRoles");
            DropIndex("dbo.AspNetUsers", new[] { "Role_Id" });
            DropColumn("dbo.AspNetUsers", "Role_Id");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Role_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Role_Id");
            AddForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.UserRoles", "Id", cascadeDelete: true);
        }
    }
}
