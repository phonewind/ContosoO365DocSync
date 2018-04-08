namespace ContosoO365DocSync.Service
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using ContosoO365DocSync.Entity;
    public class ContosoO365DocSyncDbContext : System.Data.Entity.DbContext
    {
        // Your context has been configured to use a 'dbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ContosoO365DocSync.Service.dbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'dbContext' 
        // connection string in the application configuration file.
        public ContosoO365DocSyncDbContext()
            : base((new ConfigService()).DatabaseConnectionString)
        {
            //Database.SetInitializer<ContosoO365DocSyncDbContext>(new SmartlinkDbContextInitializer());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<SourceCatalog> SourceCatalogs { get; set; }
        public virtual DbSet<SourcePoint> SourcePoints { get; set; }
        public virtual DbSet<SourcePointGroup> SourcePointGroups { get; set; }
        public virtual DbSet<PublishedHistory> PublishedHistories { get; set; }
        public virtual DbSet<DestinationPoint> DestinationPoints { get; set; }
        public virtual DbSet<DestinationCatalog> DestinationCatalogs { get; set; }
        public virtual DbSet<CustomFormat> CustomFormats { get; set; }
        public virtual DbSet<RecentFile> RecentFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}