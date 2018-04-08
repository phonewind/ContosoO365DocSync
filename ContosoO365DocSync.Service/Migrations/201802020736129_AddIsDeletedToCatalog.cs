namespace ContosoO365DocSync.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddIsDeletedToCatalog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DestinationCatalogs", "IsDeleted", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.SourceCatalogs", "IsDeleted", c => c.Boolean(nullable: false, defaultValue: false));
        }

        public override void Down()
        {
            DropColumn("dbo.SourceCatalogs", "IsDeleted");
            DropColumn("dbo.DestinationCatalogs", "IsDeleted");
        }
    }
}
