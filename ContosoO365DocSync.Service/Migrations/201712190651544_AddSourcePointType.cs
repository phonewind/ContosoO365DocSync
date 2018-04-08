namespace ContosoO365DocSync.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddSourcePointType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SourcePoints", "SourceType", c => c.Int(nullable: false, defaultValue: 1));
        }

        public override void Down()
        {
            DropColumn("dbo.SourcePoints", "SourceType");
        }
    }
}
