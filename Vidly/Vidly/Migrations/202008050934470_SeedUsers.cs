namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'47c42c6c-055e-4ab4-8e5c-cc488a0070e3', N'guest@vidly.com', 0, N'AIdduaw6iiYuBqebmRP/yZilsmntCEy0jVzE0S4joXxresT9ZHMOgl1keN0D/99exQ==', N'9ddb316d-6bbd-43fb-aaa9-3f1dbcac3305', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6d339fb4-6ed3-4a2b-b20b-0548b051c17f', N'admin@vidly.com', 0, N'AK4SfCymodvbNGvlotMNGKBnHl2EO9QFkRxnrKJJ18FNfRGSKOU6TD5z+0ehxtMU1w==', N'cd7e4399-a365-44c3-9bf8-be01476dba4f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e48eb87c-90bb-4b3a-bd17-fe745786912c', N'CanManageMovie')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6d339fb4-6ed3-4a2b-b20b-0548b051c17f', N'e48eb87c-90bb-4b3a-bd17-fe745786912c')
  
        

            ");
        }
        
        public override void Down()
        {
        }
    }
}
