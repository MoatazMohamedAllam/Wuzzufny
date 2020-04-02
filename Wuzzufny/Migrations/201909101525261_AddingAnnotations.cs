namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Gender", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "MilitaryStatus", c => c.String(maxLength: 120));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "MilitaryStatus", c => c.String());
            AlterColumn("dbo.Employees", "Gender", c => c.String());
        }
    }
}
