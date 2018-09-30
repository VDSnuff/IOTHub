namespace IOTHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NodeDotCarModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        LicensePlateNumber = c.String(nullable: false, maxLength: 50),
                        Brand = c.String(maxLength: 150),
                        Model = c.String(maxLength: 150),
                        Color = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NodeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Model = c.String(),
                        Place = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Country = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Street = c.String(),
                        Area = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nodes");
            DropTable("dbo.Dots");
            DropTable("dbo.Cars");
        }
    }
}
