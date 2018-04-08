namespace ContosoO365DocSync.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDefaultValueOfDestinationPointType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.[DestinationPoints] SET [DestinationType] = 0 WHERE [DestinationType] IS NULL");
        }
        
        public override void Down()
        {
        }
    }
}
