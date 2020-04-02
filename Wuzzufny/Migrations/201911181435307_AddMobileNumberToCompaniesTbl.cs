namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMobileNumberToCompaniesTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "MobileNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "MobileNo");
        }
    }
}
