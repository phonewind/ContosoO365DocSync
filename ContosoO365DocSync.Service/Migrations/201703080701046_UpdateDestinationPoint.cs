namespace ContosoO365DocSync.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDestinationPoint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DestinationPoints", "Creator", c => c.String(maxLength: 255));
            AddColumn("dbo.DestinationPoints", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SourcePoints", "RangeId", c => c.String(maxLength: 255));
            AlterColumn("dbo.SourceCatalogs", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SourceCatalogs", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.SourcePoints", "RangeId", c => c.String());
            DropColumn("dbo.DestinationPoints", "Created");
            DropColumn("dbo.DestinationPoints", "Creator");
        }
    }
}
