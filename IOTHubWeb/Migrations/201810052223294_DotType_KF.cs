namespace IOTHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DotType_KF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IPCamDots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DotId = c.Int(nullable: false),
                        IP = c.String(),
                        Port = c.Int(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IPCamDots");
        }
    }
}
