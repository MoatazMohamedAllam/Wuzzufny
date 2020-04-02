namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMobileNoColumnFromComapniesTbl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "PhoneNo", c => c.String());
            DropColumn("dbo.Companies", "MobileNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "MobileNo", c => c.Byte(nullable: false));
            AlterColumn("dbo.Companies", "PhoneNo", c => c.Byte(nullable: false));
        }
    }
}
