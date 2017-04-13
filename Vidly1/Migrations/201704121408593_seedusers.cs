namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8b6c72f8-9e64-4410-8ccd-b635d736a92f', N'admin@vidly.com', 0, N'AEa18wg0xJbKN3Rrf5Aj+/yKqodo82db0DaNwEFj6P4NbhlZGCWhQOn92/PbnCs1Mg==', N'42a6d5d2-ebe6-4585-97c4-f82267b90d32', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
              INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'de519a88-94bc-4632-a83c-3a5ce7dafd17', N'guest@vidly.com', 0, N'AFK2Lf3J58kcRAkyAsSImxrGvQ9HniIngvKkfGRfv4DjAGiLzwZko5xi3Y8KOg2u4Q==', N'9ee388e4-ef46-4b4d-bebd-0045bbe976e7', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'33e5fdc7-beb6-4302-891b-c454ba7ac53c', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8b6c72f8-9e64-4410-8ccd-b635d736a92f', N'33e5fdc7-beb6-4302-891b-c454ba7ac53c')


");
        }
        
        public override void Down()
        {
        }
    }
}
