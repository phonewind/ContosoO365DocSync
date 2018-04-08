namespace ContosoO365DocSync.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomFormat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomFormats", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomFormats", "Description");
        }
    }
}
