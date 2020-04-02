namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobRequestTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(maxLength: 128),
                        CompanyId = c.String(maxLength: 128),
                        JobId = c.Int(nullable: false),
                        RequestDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CompanyId)
                .Index(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobRequests", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.JobRequests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.JobRequests", "CompanyId", "dbo.Companies");
            DropIndex("dbo.JobRequests", new[] { "JobId" });
            DropIndex("dbo.JobRequests", new[] { "CompanyId" });
            DropIndex("dbo.JobRequests", new[] { "EmployeeId" });
            DropTable("dbo.JobRequests");
        }
    }
}
