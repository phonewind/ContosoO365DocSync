namespace ContosoO365DocSync.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddDestinationType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DestinationPoints", "DestinationType", c => c.Int(nullable: false, defaultValue: 0));
        }

        public override void Down()
        {
            DropColumn("dbo.DestinationPoints", "DestinationType");
        }
    }
}
