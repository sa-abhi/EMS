namespace EventManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SerProCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProviders", "CityID", c => c.String(nullable: false));
            AddColumn("dbo.ServiceProviders", "City_CityID", c => c.Int());
            CreateIndex("dbo.ServiceProviders", "City_CityID");
            AddForeignKey("dbo.ServiceProviders", "City_CityID", "dbo.Cities", "CityID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceProviders", "City_CityID", "dbo.Cities");
            DropIndex("dbo.ServiceProviders", new[] { "City_CityID" });
            DropColumn("dbo.ServiceProviders", "City_CityID");
            DropColumn("dbo.ServiceProviders", "CityID");
        }
    }
}
