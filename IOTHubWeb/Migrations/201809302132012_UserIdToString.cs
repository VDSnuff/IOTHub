namespace IOTHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "OwnerId", c => c.String(nullable: false));
            AlterColumn("dbo.Nodes", "OwnerID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nodes", "OwnerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "OwnerId", c => c.Int(nullable: false));
        }
    }
}
