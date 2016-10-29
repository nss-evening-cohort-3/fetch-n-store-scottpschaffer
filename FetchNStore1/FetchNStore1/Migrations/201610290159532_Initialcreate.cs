namespace FetchNStore1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        StatusCode = c.String(nullable: false),
                        URL = c.String(nullable: false),
                        ResponseTime = c.Int(nullable: false),
                        HTTPMethod = c.String(),
                        RequestTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Responses");
        }
    }
}
