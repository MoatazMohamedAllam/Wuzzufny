namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeColsToCompaniesTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "FirstName", c => c.String());
            AddColumn("dbo.Companies", "LastName", c => c.String());
            AddColumn("dbo.Companies", "JobRule", c => c.String());
            AddColumn("dbo.Companies", "MobileNumber", c => c.Byte(nullable: false));
            AddColumn("dbo.Companies", "CompanyName", c => c.String(maxLength: 255));
            DropColumn("dbo.Companies", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Name", c => c.String(maxLength: 255));
            DropColumn("dbo.Companies", "CompanyName");
            DropColumn("dbo.Companies", "MobileNumber");
            DropColumn("dbo.Companies", "JobRule");
            DropColumn("dbo.Companies", "LastName");
            DropColumn("dbo.Companies", "FirstName");
        }
    }
}
