namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameMobileNumberInCompaniesTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "MobileNo", c => c.Byte(nullable: false));
            DropColumn("dbo.Companies", "MobileNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "MobileNumber", c => c.Byte(nullable: false));
            DropColumn("dbo.Companies", "MobileNo");
        }
    }
}
