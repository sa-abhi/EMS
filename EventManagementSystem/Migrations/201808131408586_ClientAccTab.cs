namespace EventManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientAccTab : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Clients", "Organization", c => c.String(maxLength: 50));
            AlterColumn("dbo.Clients", "Phone", c => c.String(nullable: false, maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Phone", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Clients", "Organization", c => c.String(maxLength: 30));
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
