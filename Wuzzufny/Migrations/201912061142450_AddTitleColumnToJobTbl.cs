namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitleColumnToJobTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Title");
        }
    }
}
