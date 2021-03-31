namespace Book_Raven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3244ecb3-556f-4ed5-b65c-34e58d368d70', N'admin@mail.com', 0, N'AHjDyEYenyTXGhvthy0/Qns1T/porA2F08DaYVnLXKp879iK67au160S9xMCEJcwdg==', N'295e8d19-f7c1-4c2b-bfe8-7c2951c8534b', NULL, 0, 0, NULL, 1, 0, N'admin@mail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'35ea3110-5561-45e6-9bd2-d43f668d594d', N'guest@mail.com', 0, N'AFs6dT+im44fxr9joC3L2q4vdYDafy+en8ULeGXUEQd1pywsqC1I9Oh4WLi/ni8JYQ==', N'b381c74c-e421-4065-b4f7-09e6d9ef5c22', NULL, 0, 0, NULL, 1, 0, N'guest@mail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f1bc1457-bbf0-4d31-a5a2-57de16e56678', N'CanManageBooks')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3244ecb3-556f-4ed5-b65c-34e58d368d70', N'f1bc1457-bbf0-4d31-a5a2-57de16e56678')

");         
        }
        
        public override void Down()
        {
        }
    }
}
