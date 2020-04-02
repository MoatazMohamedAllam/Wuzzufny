namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCountryColumnToCompanyTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Country");
        }
    }
}
