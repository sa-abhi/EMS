namespace EventManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaID = c.Int(nullable: false, identity: true),
                        AreaName = c.String(nullable: false),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.ClientOrders",
                c => new
                    {
                        ClientOrderID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        EventTypeID = c.Int(nullable: false),
                        EventSubTypeID = c.Int(nullable: false),
                        EventName = c.String(nullable: false),
                        EventStartDate = c.DateTime(nullable: false),
                        EventEndDate = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                        VenueID = c.Int(nullable: false),
                        NoOfGuest = c.Int(nullable: false),
                        SpecialInstruction = c.String(),
                    })
                .PrimaryKey(t => t.ClientOrderID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .ForeignKey("dbo.EventSubTypes", t => t.EventSubTypeID)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeID)
                .ForeignKey("dbo.Venues", t => t.VenueID)
                .Index(t => t.ClientID)
                .Index(t => t.CityID)
                .Index(t => t.EventTypeID)
                .Index(t => t.EventSubTypeID)
                .Index(t => t.VenueID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        ClientKey = c.String(),
                        Name = c.String(nullable: false, maxLength: 10),
                        Organization = c.String(maxLength: 30),
                        Address = c.String(maxLength: 50),
                        CityID = c.Int(),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Email = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.EventRequests",
                c => new
                    {
                        EventRequestID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        AreaID = c.Int(nullable: false),
                        EventTypeID = c.Int(nullable: false),
                        EventSubTypeID = c.Int(nullable: false),
                        EventName = c.String(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        VenueID = c.Int(nullable: false),
                        Duration = c.String(nullable: false),
                        NoOfGuest = c.Int(nullable: false),
                        Budget = c.Double(nullable: false),
                        isSeen = c.Boolean(nullable: false),
                        Stage = c.Boolean(nullable: false),
                        Catering = c.Boolean(nullable: false),
                        SoundSystemAndMusic = c.Boolean(nullable: false),
                        Decoration = c.Boolean(nullable: false),
                        PhotographyAndCinematography = c.Boolean(nullable: false),
                        Invitation = c.Boolean(nullable: false),
                        SpecialInstruction = c.String(),
                    })
                .PrimaryKey(t => t.EventRequestID)
                .ForeignKey("dbo.Areas", t => t.AreaID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .ForeignKey("dbo.EventSubTypes", t => t.EventSubTypeID)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeID)
                .ForeignKey("dbo.Venues", t => t.VenueID)
                .Index(t => t.ClientID)
                .Index(t => t.CityID)
                .Index(t => t.AreaID)
                .Index(t => t.EventTypeID)
                .Index(t => t.EventSubTypeID)
                .Index(t => t.VenueID);
            
            CreateTable(
                "dbo.EventSubTypes",
                c => new
                    {
                        EventSubTypeID = c.Int(nullable: false, identity: true),
                        EventSubTypeName = c.String(nullable: false),
                        EventTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventSubTypeID)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeID)
                .Index(t => t.EventTypeID);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        EventTypeID = c.Int(nullable: false, identity: true),
                        EventTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventTypeID);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        VenueName = c.String(nullable: false),
                        CityID = c.Int(nullable: false),
                        AreaID = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        SeatCapacity = c.Int(nullable: false),
                        AirConditioned = c.Boolean(nullable: false),
                        Rent = c.Double(nullable: false),
                        Image = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VenueID)
                .ForeignKey("dbo.Areas", t => t.AreaID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .Index(t => t.CityID)
                .Index(t => t.AreaID);
            
            CreateTable(
                "dbo.EventSchedules",
                c => new
                    {
                        EventScheduleID = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        EventStartDate = c.DateTime(nullable: false),
                        EventEndDate = c.DateTime(nullable: false),
                        VenueID = c.Int(nullable: false),
                        Description = c.String(),
                        Color = c.String(),
                        isFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventScheduleID)
                .ForeignKey("dbo.Venues", t => t.VenueID)
                .Index(t => t.VenueID);
            
            CreateTable(
                "dbo.EventBills",
                c => new
                    {
                        EventBillID = c.Int(nullable: false, identity: true),
                        ClientOrderID = c.Int(nullable: false),
                        SubTotalAmount = c.Double(nullable: false),
                        vat = c.Double(),
                        Discount = c.Int(),
                        MadeBy = c.String(),
                    })
                .PrimaryKey(t => t.EventBillID)
                .ForeignKey("dbo.ClientOrders", t => t.ClientOrderID)
                .Index(t => t.ClientOrderID);
            
            CreateTable(
                "dbo.EventPayments",
                c => new
                    {
                        EventPaymentID = c.Int(nullable: false, identity: true),
                        ClientOrderID = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        PaidAmount = c.Double(nullable: false),
                        PaymentStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventPaymentID)
                .ForeignKey("dbo.ClientOrders", t => t.ClientOrderID)
                .Index(t => t.ClientOrderID);
            
            CreateTable(
                "dbo.EventsCaterings",
                c => new
                    {
                        EventsCateringID = c.Int(nullable: false, identity: true),
                        ClientOrderID = c.Int(nullable: false),
                        MealType = c.String(maxLength: 30),
                        FoodItems = c.String(maxLength: 30),
                        PerPersonCost = c.Double(nullable: false),
                        TotalCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EventsCateringID)
                .ForeignKey("dbo.ClientOrders", t => t.ClientOrderID)
                .Index(t => t.ClientOrderID);
            
            CreateTable(
                "dbo.EventsCinematographies",
                c => new
                    {
                        EventscinematographyID = c.Int(nullable: false, identity: true),
                        ClientOrderID = c.Int(nullable: false),
                        NumberOfTeaM = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EventscinematographyID)
                .ForeignKey("dbo.ClientOrders", t => t.ClientOrderID)
                .Index(t => t.ClientOrderID);
            
            CreateTable(
                "dbo.EventsDecorations",
                c => new
                    {
                        EventsDecorationID = c.Int(nullable: false, identity: true),
                        ClientOrderID = c.Int(nullable: false),
                        DecorationTypeID = c.Int(nullable: false),
                        DecorationImageID = c.Int(),
                        Price = c.Double(nullable: false),
                        CustomImage = c.String(),
                    })
                .PrimaryKey(t => t.EventsDecorationID)
                .ForeignKey("dbo.ClientOrders", t => t.ClientOrderID)
                .ForeignKey("dbo.DecorationImages", t => t.DecorationImageID)
                .ForeignKey("dbo.DecorationTypes", t => t.DecorationTypeID)
                .Index(t => t.ClientOrderID)
                .Index(t => t.DecorationTypeID)
                .Index(t => t.DecorationImageID);
            
            CreateTable(
                "dbo.DecorationImages",
                c => new
                    {
                        DecorationImageID = c.Int(nullable: false, identity: true),
                        DecorationImageKey = c.String(),
                        DecorationTypeID = c.Int(nullable: false),
                        Image = c.String(maxLength: 500),
                        ImageCode = c.String(),
                    })
                .PrimaryKey(t => t.DecorationImageID)
                .ForeignKey("dbo.DecorationTypes", t => t.DecorationTypeID)
                .Index(t => t.DecorationTypeID);
            
            CreateTable(
                "dbo.DecorationTypes",
                c => new
                    {
                        DecorationTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.DecorationTypeID);
            
            CreateTable(
                "dbo.EventServices",
                c => new
                    {
                        EventServicesID = c.Int(nullable: false, identity: true),
                        ClientOrderID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        ServiceProviderID = c.Int(),
                        Price = c.Double(),
                        Cost = c.Double(),
                    })
                .PrimaryKey(t => t.EventServicesID)
                .ForeignKey("dbo.ClientOrders", t => t.ClientOrderID)
                .ForeignKey("dbo.Services", t => t.ServiceID)
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProviderID)
                .Index(t => t.ClientOrderID)
                .Index(t => t.ServiceID)
                .Index(t => t.ServiceProviderID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ServiceID);
            
            CreateTable(
                "dbo.ServiceProviders",
                c => new
                    {
                        ServiceProviderID = c.Int(nullable: false, identity: true),
                        ServiceProviderKey = c.String(),
                        ServiceProviderName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceProviderID)
                .ForeignKey("dbo.Services", t => t.ServiceID)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.EventsPhotographies",
                c => new
                    {
                        EventsPhotographyID = c.Int(nullable: false, identity: true),
                        ClientOrderID = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        NumberOfTeam = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EventsPhotographyID)
                .ForeignKey("dbo.ClientOrders", t => t.ClientOrderID)
                .Index(t => t.ClientOrderID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceKey = c.String(),
                        ClientOrderID = c.Int(nullable: false),
                        PaymentType = c.String(),
                        PaidAmount = c.Double(nullable: false),
                        MadeBy = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.ClientOrders", t => t.ClientOrderID)
                .Index(t => t.ClientOrderID);
            
            CreateTable(
                "dbo.ClientFeedbacks",
                c => new
                    {
                        ClientFeedbackID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        FeedbackDate = c.DateTime(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ClientFeedbackID);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationID = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false),
                        BasicSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DesignationID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeKey = c.String(),
                        EmployeeName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Address = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Email = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        DesignationID = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Designations", t => t.DesignationID)
                .Index(t => t.DesignationID);
            
            CreateTable(
                "dbo.FoodCategories",
                c => new
                    {
                        FoodCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.FoodCategoryID);
            
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        FoodItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        FoodCategoryID = c.Int(nullable: false),
                        MealType = c.String(),
                        Cost = c.Double(nullable: false),
                        Image = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.FoodItemID)
                .ForeignKey("dbo.FoodCategories", t => t.FoodCategoryID)
                .Index(t => t.FoodCategoryID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Contact = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FoodItems", "FoodCategoryID", "dbo.FoodCategories");
            DropForeignKey("dbo.Employees", "DesignationID", "dbo.Designations");
            DropForeignKey("dbo.ClientOrders", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.Invoices", "ClientOrderID", "dbo.ClientOrders");
            DropForeignKey("dbo.EventsPhotographies", "ClientOrderID", "dbo.ClientOrders");
            DropForeignKey("dbo.EventServices", "ServiceProviderID", "dbo.ServiceProviders");
            DropForeignKey("dbo.ServiceProviders", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.EventServices", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.EventServices", "ClientOrderID", "dbo.ClientOrders");
            DropForeignKey("dbo.EventsDecorations", "DecorationTypeID", "dbo.DecorationTypes");
            DropForeignKey("dbo.EventsDecorations", "DecorationImageID", "dbo.DecorationImages");
            DropForeignKey("dbo.DecorationImages", "DecorationTypeID", "dbo.DecorationTypes");
            DropForeignKey("dbo.EventsDecorations", "ClientOrderID", "dbo.ClientOrders");
            DropForeignKey("dbo.EventsCinematographies", "ClientOrderID", "dbo.ClientOrders");
            DropForeignKey("dbo.EventsCaterings", "ClientOrderID", "dbo.ClientOrders");
            DropForeignKey("dbo.EventPayments", "ClientOrderID", "dbo.ClientOrders");
            DropForeignKey("dbo.EventBills", "ClientOrderID", "dbo.ClientOrders");
            DropForeignKey("dbo.EventSchedules", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.EventRequests", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.Venues", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Venues", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.EventSubTypes", "EventTypeID", "dbo.EventTypes");
            DropForeignKey("dbo.EventRequests", "EventTypeID", "dbo.EventTypes");
            DropForeignKey("dbo.ClientOrders", "EventTypeID", "dbo.EventTypes");
            DropForeignKey("dbo.EventRequests", "EventSubTypeID", "dbo.EventSubTypes");
            DropForeignKey("dbo.ClientOrders", "EventSubTypeID", "dbo.EventSubTypes");
            DropForeignKey("dbo.EventRequests", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.EventRequests", "CityID", "dbo.Cities");
            DropForeignKey("dbo.EventRequests", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.ClientOrders", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "CityID", "dbo.Cities");
            DropForeignKey("dbo.ClientOrders", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Areas", "CityID", "dbo.Cities");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FoodItems", new[] { "FoodCategoryID" });
            DropIndex("dbo.Employees", new[] { "DesignationID" });
            DropIndex("dbo.Invoices", new[] { "ClientOrderID" });
            DropIndex("dbo.EventsPhotographies", new[] { "ClientOrderID" });
            DropIndex("dbo.ServiceProviders", new[] { "ServiceID" });
            DropIndex("dbo.EventServices", new[] { "ServiceProviderID" });
            DropIndex("dbo.EventServices", new[] { "ServiceID" });
            DropIndex("dbo.EventServices", new[] { "ClientOrderID" });
            DropIndex("dbo.DecorationImages", new[] { "DecorationTypeID" });
            DropIndex("dbo.EventsDecorations", new[] { "DecorationImageID" });
            DropIndex("dbo.EventsDecorations", new[] { "DecorationTypeID" });
            DropIndex("dbo.EventsDecorations", new[] { "ClientOrderID" });
            DropIndex("dbo.EventsCinematographies", new[] { "ClientOrderID" });
            DropIndex("dbo.EventsCaterings", new[] { "ClientOrderID" });
            DropIndex("dbo.EventPayments", new[] { "ClientOrderID" });
            DropIndex("dbo.EventBills", new[] { "ClientOrderID" });
            DropIndex("dbo.EventSchedules", new[] { "VenueID" });
            DropIndex("dbo.Venues", new[] { "AreaID" });
            DropIndex("dbo.Venues", new[] { "CityID" });
            DropIndex("dbo.EventSubTypes", new[] { "EventTypeID" });
            DropIndex("dbo.EventRequests", new[] { "VenueID" });
            DropIndex("dbo.EventRequests", new[] { "EventSubTypeID" });
            DropIndex("dbo.EventRequests", new[] { "EventTypeID" });
            DropIndex("dbo.EventRequests", new[] { "AreaID" });
            DropIndex("dbo.EventRequests", new[] { "CityID" });
            DropIndex("dbo.EventRequests", new[] { "ClientID" });
            DropIndex("dbo.Clients", new[] { "CityID" });
            DropIndex("dbo.ClientOrders", new[] { "VenueID" });
            DropIndex("dbo.ClientOrders", new[] { "EventSubTypeID" });
            DropIndex("dbo.ClientOrders", new[] { "EventTypeID" });
            DropIndex("dbo.ClientOrders", new[] { "CityID" });
            DropIndex("dbo.ClientOrders", new[] { "ClientID" });
            DropIndex("dbo.Areas", new[] { "CityID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FoodItems");
            DropTable("dbo.FoodCategories");
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
            DropTable("dbo.ClientFeedbacks");
            DropTable("dbo.Invoices");
            DropTable("dbo.EventsPhotographies");
            DropTable("dbo.ServiceProviders");
            DropTable("dbo.Services");
            DropTable("dbo.EventServices");
            DropTable("dbo.DecorationTypes");
            DropTable("dbo.DecorationImages");
            DropTable("dbo.EventsDecorations");
            DropTable("dbo.EventsCinematographies");
            DropTable("dbo.EventsCaterings");
            DropTable("dbo.EventPayments");
            DropTable("dbo.EventBills");
            DropTable("dbo.EventSchedules");
            DropTable("dbo.Venues");
            DropTable("dbo.EventTypes");
            DropTable("dbo.EventSubTypes");
            DropTable("dbo.EventRequests");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientOrders");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
        }
    }
}
