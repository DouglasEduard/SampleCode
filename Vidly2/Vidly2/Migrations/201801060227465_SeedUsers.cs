namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6d2b9a69-eeb5-4ecb-937e-35db1ff52618', N'admin@vidly2.com', 0, N'ADRLpl3+vFmefb3i4Ql7DvLm/VO+W01rTe9v2ieGv9+LYD9tpiwGn6o17FhtaoPOSg==', N'd26b8b74-49eb-4b34-9794-6bedc68042fd', NULL, 0, 0, NULL, 1, 0, N'admin@vidly2.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9d28c703-facd-421d-a5db-db209c064781', N'guest@vidly2.com', 0, N'AI0RrxrzcGBoJoithfw0ExvPJSQAlV38qRkOQp7aOquUaOrLFbej7ssdazHTWO5pJw==', N'b0663570-c504-4ce5-9fd1-e010c160f139', NULL, 0, 0, NULL, 1, 0, N'guest@vidly2.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5530ec78-65a9-4094-96c4-a75de3687275', N'CanManageMovies')        
            ");
        }
        
        public override void Down()
        {
        }
    }
}
