namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameBirthDateInEmployeesTbl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "birthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "birthDate", c => c.DateTime(nullable: false));
        }
    }
}
