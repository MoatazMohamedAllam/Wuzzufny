namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCompanyTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        PhoneNo = c.Byte(nullable: false),
                        CompanyURL = c.String(),
                        CompanySize = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Companies", new[] { "User_Id" });
            DropTable("dbo.Companies");
        }
    }
}
