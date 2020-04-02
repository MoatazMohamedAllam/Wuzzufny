namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmployeeTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        MilitaryStatus = c.String(),
                        MaritalStatus = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "User_Id" });
            DropTable("dbo.Employees");
        }
    }
}
