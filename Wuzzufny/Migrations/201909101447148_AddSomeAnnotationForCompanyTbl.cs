namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeAnnotationForCompanyTbl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Companies", "CompanyURL", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "CompanyURL", c => c.String());
            AlterColumn("dbo.Companies", "Name", c => c.String());
        }
    }
}
