namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserRoleTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Role_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Role_Id");
            AddForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.UserRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.UserRoles");
            DropIndex("dbo.AspNetUsers", new[] { "Role_Id" });
            DropColumn("dbo.AspNetUsers", "Role_Id");
            DropTable("dbo.UserRoles");
        }
    }
}
