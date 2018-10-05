namespace IOTHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dot_FK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Dots", name: "Type_Id", newName: "Type");
            RenameIndex(table: "dbo.Dots", name: "IX_Type_Id", newName: "IX_Type");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Dots", name: "IX_Type", newName: "IX_Type_Id");
            RenameColumn(table: "dbo.Dots", name: "Type", newName: "Type_Id");
        }
    }
}
