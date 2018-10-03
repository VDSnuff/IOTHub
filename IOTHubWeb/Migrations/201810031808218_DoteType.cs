namespace IOTHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoteType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dots", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dots", "Type");
        }
    }
}
