namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeChangesInAppUserTbleAndRoleUserTbl : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Role_Id", newName: "RoleId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Role_Id", newName: "IX_RoleId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_RoleId", newName: "IX_Role_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "RoleId", newName: "Role_Id");
        }
    }
}
