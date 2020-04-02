namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingThreeColsInCompanyTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Title", c => c.String());
            AddColumn("dbo.Companies", "CompanyIndustry", c => c.String());
            AddColumn("dbo.Companies", "HearAboutUs", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "HearAboutUs");
            DropColumn("dbo.Companies", "CompanyIndustry");
            DropColumn("dbo.Companies", "Title");
        }
    }
}
