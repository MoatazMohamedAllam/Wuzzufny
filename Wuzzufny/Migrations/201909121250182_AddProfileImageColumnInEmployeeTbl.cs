namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileImageColumnInEmployeeTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ProfileImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ProfileImage");
        }
    }
}
