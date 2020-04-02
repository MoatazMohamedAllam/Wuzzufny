namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDayMonthYearToEmployeeTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Year");
            DropColumn("dbo.Employees", "Month");
            DropColumn("dbo.Employees", "Day");
        }
    }
}
