namespace EventManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoiceNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Notes");
        }
    }
}
