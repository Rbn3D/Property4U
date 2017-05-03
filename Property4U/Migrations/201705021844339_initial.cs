namespace Property4U.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Number = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        AreaName = c.String(nullable: false),
                        Block = c.String(nullable: false, maxLength: 1),
                        Street = c.String(nullable: false, maxLength: 180),
                        City = c.String(nullable: false, maxLength: 100),
                        State = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 100),
                        PostalCode = c.String(nullable: false, maxLength: 5),
                        ZipCode = c.String(nullable: false, maxLength: 5),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AgentID = c.String(nullable: false, maxLength: 128),
                        AddressID = c.Int(nullable: false),
                        OfTypeID = c.Int(nullable: false),
                        OfSubType = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 120),
                        Seller = c.String(nullable: false, maxLength: 120),
                        Locality = c.String(nullable: false, maxLength: 120),
                        CoveredAreaMeasurement = c.Double(),
                        CoveredAreaUnits = c.Int(),
                        Condition = c.Int(),
                        Furnished = c.Int(),
                        Stories = c.Int(),
                        FloorNo = c.Int(),
                        Flooring = c.Int(),
                        Baths = c.Int(),
                        Kitchens = c.Int(),
                        DrawingRooms = c.Int(),
                        DiningRooms = c.Int(),
                        LivingRooms = c.Int(),
                        NumberOfRooms = c.Int(),
                        StoreRooms = c.Int(),
                        ServantQuarters = c.Int(),
                        Lawn = c.Int(),
                        CarSpaces = c.Int(),
                        Build = c.DateTime(),
                        AreaMeasurement = c.Double(nullable: false),
                        AreaUnits = c.Int(nullable: false),
                        AreaDiLength = c.Double(nullable: false),
                        AreaDiWidth = c.Double(nullable: false),
                        Price = c.Int(nullable: false),
                        For = c.Int(nullable: false),
                        AllowBidding = c.Int(nullable: false),
                        Availability = c.Int(nullable: false),
                        Views = c.Int(),
                        Status = c.Int(),
                        Discount = c.Int(),
                        Featured = c.Int(),
                        Flags = c.Int(),
                        PublishOn = c.DateTime(nullable: false),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.AddressID)
                .ForeignKey("dbo.AspNetUsers", t => t.AgentID)
                .ForeignKey("dbo.OfType", t => t.OfTypeID)
                .Index(t => t.AgentID)
                .Index(t => t.AddressID)
                .Index(t => t.OfTypeID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        HomeTown = c.String(),
                        BirthDate = c.DateTime(),
                        ProfileImage = c.String(),
                        JoinedDate = c.DateTime(),
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Bidding",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 90),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MinExp = c.Double(nullable: false),
                        MaxExp = c.Double(nullable: false),
                        WinningBid = c.Int(),
                        PostedOn = c.DateTime(nullable: false),
                        BiddingStatus = c.Int(nullable: false),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.Bid",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BiddingID = c.Int(nullable: false),
                        MemberID = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 90),
                        Description = c.String(nullable: false, maxLength: 250),
                        Price = c.Double(nullable: false),
                        BidOn = c.DateTime(nullable: false),
                        BidStatus = c.Int(nullable: false),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bidding", t => t.BiddingID)
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID)
                .Index(t => t.BiddingID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Feature",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ImageIcon = c.String(),
                        ImageSize = c.Double(),
                        Description = c.String(nullable: false, maxLength: 250),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        MemberID = c.String(nullable: false, maxLength: 128),
                        For = c.Int(nullable: false),
                        Title = c.String(maxLength: 90),
                        Description = c.String(nullable: false, maxLength: 250),
                        AgentRating = c.Int(),
                        AgentReview = c.String(maxLength: 250),
                        OverallExperience = c.Int(),
                        FeedbackOn = c.DateTime(nullable: false),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.OfType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ImageFile = c.String(),
                        ImageSize = c.Double(),
                        Description = c.String(maxLength: 250),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        PhotoTitle = c.String(nullable: false, maxLength: 50),
                        AltText = c.String(),
                        Caption = c.String(),
                        UploadedFrom = c.String(nullable: false),
                        UploadedTo = c.String(),
                        Size = c.Double(),
                        Extension = c.String(),
                        UploadedOn = c.DateTime(nullable: false),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.Renewal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 300),
                        Price = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        Dated = c.DateTime(nullable: false),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 128),
                        PropertyID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 90),
                        Description = c.String(nullable: false, maxLength: 250),
                        VisitingDate = c.DateTime(nullable: false),
                        VisitingTime = c.DateTime(nullable: false),
                        RequestOn = c.DateTime(nullable: false),
                        RequestStatus = c.Int(nullable: false),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.MemberID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.Response",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestID = c.Int(nullable: false),
                        AgentID = c.String(maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 90),
                        Description = c.String(nullable: false, maxLength: 250),
                        ResponseOn = c.DateTime(nullable: false),
                        ResponseStatus = c.Int(nullable: false),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.AgentID)
                .ForeignKey("dbo.Request", t => t.RequestID)
                .Index(t => t.RequestID)
                .Index(t => t.AgentID);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 90),
                        EmailAddress = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 250),
                        ReviewOn = c.DateTime(nullable: false),
                        IPAddress = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AgentID = c.String(nullable: false, maxLength: 128),
                        ReviewID = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 250),
                        ReplyOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.AgentID)
                .ForeignKey("dbo.Review", t => t.ReviewID)
                .Index(t => t.AgentID)
                .Index(t => t.ReviewID);
            
            CreateTable(
                "dbo.Ad",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdminID = c.String(nullable: false, maxLength: 128),
                        OrderID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 90),
                        WebsiteURL = c.String(nullable: false),
                        Path = c.String(nullable: false),
                        ImageSize = c.Double(),
                        AdDuration = c.Int(nullable: false),
                        AdStatus = c.Int(nullable: false),
                        Remedies = c.String(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminID)
                .ForeignKey("dbo.Order", t => t.OrderID)
                .Index(t => t.AdminID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AgentID = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        Size = c.Int(nullable: false),
                        NumberOfAds = c.Int(nullable: false),
                        ZipFilePath = c.String(nullable: false),
                        ZipFileSize = c.Double(),
                        AdsDuration = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        Remedies = c.String(),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.AgentID)
                .Index(t => t.AgentID);
            
            CreateTable(
                "dbo.Configuration",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ConfigAdminID = c.String(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 60),
                        ShortTitle = c.String(nullable: false, maxLength: 20),
                        Tagline = c.String(nullable: false, maxLength: 160),
                        WebsiteURL = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PublicPhoneNo = c.String(),
                        OfficeAddress = c.String(nullable: false),
                        LogoPath = c.String(nullable: false),
                        Favicon = c.String(nullable: false),
                        ThemeColor = c.Int(nullable: false),
                        PropertyRenewal = c.Int(nullable: false),
                        RenewalCost = c.Double(nullable: false),
                        TimeZoneId = c.String(nullable: false),
                        CompanyDescription = c.String(nullable: false, maxLength: 160),
                        Keywords = c.String(nullable: false),
                        FacebookAppId = c.String(),
                        FacebookAppSecret = c.String(),
                        GoogleClientId = c.String(),
                        GoogleClientSecret = c.String(),
                        FacebookURL = c.String(),
                        TwitterURL = c.String(),
                        GooglePlusURL = c.String(),
                        LinkedInURL = c.String(),
                        DribbbleURL = c.String(),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OfSubType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OfTypeID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        ImageFile = c.String(),
                        ImageSize = c.Double(),
                        Description = c.String(maxLength: 250),
                        LastEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OfType", t => t.OfTypeID)
                .Index(t => t.OfTypeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Responsibilities = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.FeatureProperty",
                c => new
                    {
                        Feature_ID = c.Int(nullable: false),
                        Property_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Feature_ID, t.Property_ID })
                .ForeignKey("dbo.Feature", t => t.Feature_ID, cascadeDelete: true)
                .ForeignKey("dbo.Property", t => t.Property_ID, cascadeDelete: true)
                .Index(t => t.Feature_ID)
                .Index(t => t.Property_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OfSubType", "OfTypeID", "dbo.OfType");
            DropForeignKey("dbo.Order", "AgentID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ad", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Ad", "AdminID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reply", "ReviewID", "dbo.Review");
            DropForeignKey("dbo.Reply", "AgentID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Review", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Response", "RequestID", "dbo.Request");
            DropForeignKey("dbo.Response", "AgentID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Request", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Request", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Renewal", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Photo", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Property", "OfTypeID", "dbo.OfType");
            DropForeignKey("dbo.Feedback", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Feedback", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.FeatureProperty", "Property_ID", "dbo.Property");
            DropForeignKey("dbo.FeatureProperty", "Feature_ID", "dbo.Feature");
            DropForeignKey("dbo.Bidding", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Bid", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bid", "BiddingID", "dbo.Bidding");
            DropForeignKey("dbo.Property", "AgentID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Property", "AddressID", "dbo.Address");
            DropIndex("dbo.FeatureProperty", new[] { "Property_ID" });
            DropIndex("dbo.FeatureProperty", new[] { "Feature_ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OfSubType", new[] { "OfTypeID" });
            DropIndex("dbo.Order", new[] { "AgentID" });
            DropIndex("dbo.Ad", new[] { "OrderID" });
            DropIndex("dbo.Ad", new[] { "AdminID" });
            DropIndex("dbo.Reply", new[] { "ReviewID" });
            DropIndex("dbo.Reply", new[] { "AgentID" });
            DropIndex("dbo.Review", new[] { "PropertyID" });
            DropIndex("dbo.Response", new[] { "AgentID" });
            DropIndex("dbo.Response", new[] { "RequestID" });
            DropIndex("dbo.Request", new[] { "PropertyID" });
            DropIndex("dbo.Request", new[] { "MemberID" });
            DropIndex("dbo.Renewal", new[] { "PropertyID" });
            DropIndex("dbo.Photo", new[] { "PropertyID" });
            DropIndex("dbo.Feedback", new[] { "MemberID" });
            DropIndex("dbo.Feedback", new[] { "PropertyID" });
            DropIndex("dbo.Bid", new[] { "MemberID" });
            DropIndex("dbo.Bid", new[] { "BiddingID" });
            DropIndex("dbo.Bidding", new[] { "PropertyID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Property", new[] { "OfTypeID" });
            DropIndex("dbo.Property", new[] { "AddressID" });
            DropIndex("dbo.Property", new[] { "AgentID" });
            DropTable("dbo.FeatureProperty");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OfSubType");
            DropTable("dbo.Configuration");
            DropTable("dbo.Order");
            DropTable("dbo.Ad");
            DropTable("dbo.Reply");
            DropTable("dbo.Review");
            DropTable("dbo.Response");
            DropTable("dbo.Request");
            DropTable("dbo.Renewal");
            DropTable("dbo.Photo");
            DropTable("dbo.OfType");
            DropTable("dbo.Feedback");
            DropTable("dbo.Feature");
            DropTable("dbo.Bid");
            DropTable("dbo.Bidding");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Property");
            DropTable("dbo.Address");
        }
    }
}
