namespace Wuzzufny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRequestStatusColumnToJobRequestsTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobRequests", "RequestStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobRequests", "RequestStatus");
        }
    }
}
