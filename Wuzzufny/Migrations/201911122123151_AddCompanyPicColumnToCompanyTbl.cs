namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyPicColumnToCompanyTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "CompanyLogo", c => c.String());
            AddColumn("dbo.Companies", "Companybanner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Companybanner");
            DropColumn("dbo.Companies", "CompanyLogo");
        }
    }
}
