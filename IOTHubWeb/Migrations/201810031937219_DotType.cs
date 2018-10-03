namespace IOTHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DotType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DotTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Dots", "Type_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Dots", "Type_Id");
            AddForeignKey("dbo.Dots", "Type_Id", "dbo.DotTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Dots", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dots", "Type", c => c.String(nullable: false));
            DropForeignKey("dbo.Dots", "Type_Id", "dbo.DotTypes");
            DropIndex("dbo.Dots", new[] { "Type_Id" });
            DropColumn("dbo.Dots", "Type_Id");
            DropTable("dbo.DotTypes");
        }
    }
}
