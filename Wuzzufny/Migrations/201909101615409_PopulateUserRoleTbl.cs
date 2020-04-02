namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserRoleTbl : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserRoles (Id , RoleName) VALUES (1 , 'Employee')");
            Sql("INSERT INTO UserRoles (Id , RoleName) VALUES (2 , 'Company')");
            Sql("INSERT INTO UserRoles (Id , RoleName) VALUES (3 , 'Admin')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM UserRoles WHERE Id IN(1,2,3)");
        }
    }
}
