namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublisherID = c.String(maxLength: 128),
                        Description = c.String(),
                        Requirements = c.String(),
                        ExperinceNeeded = c.String(),
                        CareerLevel = c.String(),
                        JobType = c.String(),
                        Salary = c.Int(nullable: false),
                        Language = c.String(),
                        Vacancies = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.PublisherID)
                .Index(t => t.PublisherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "PublisherID", "dbo.Companies");
            DropIndex("dbo.Jobs", new[] { "PublisherID" });
            DropTable("dbo.Jobs");
        }
    }
}
