namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'34bd7dcd-07cc-48d6-a5d2-f28e2782d069', N'empleado@safabox.com', 0, N'AO2zSwrziaZcBUeLiSLn27z0KJE4c7sABal4wg7gViAjO7++sn+G4LAIz+hIlmwyZA==', N'e057223a-c83b-48b3-804a-189f3b4d2ca0', NULL, 0, 0, NULL, 1, 0, N'empleado@safabox.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'49f7df01-44f3-47e2-af2b-2c2c82d48202', N'socio@safabox.com', 0, N'AALBTMenXt2sNU7Nxbvomvp8k/4f9nqS47U19l2XR1YsU3Tfs+cnZgdAwiL7HMP7cQ==', N'2198995f-77ee-4d34-947b-4bfeab04aa33', NULL, 0, 0, NULL, 1, 0, N'socio@safabox.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7f3887a3-902e-41bd-8c1f-f5e1d4f0b2c2', N'coordinador@safabox.com', 0, N'ALH1Rqw66py7cBGawzrr32AO2t1B/4OQBUJHMMRcvQzobE06xcx4Dokxauzb5IW0xQ==', N'39d347b6-26bb-49bd-95a1-63068cebed03', NULL, 0, 0, NULL, 1, 0, N'coordinador@safabox.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dcf9d173-c5bc-4f3c-85b4-d77592d6a144', N'admin@safabox.com', 0, N'AP49DfzkpYY/chISw4KsODGXfzV4UsKYJkf6QS+urZ02aKltZNKgXqWhyl1qb4zEIg==', N'afac587a-b467-41d5-913d-81f76d68a26b', NULL, 0, 0, NULL, 1, 0, N'admin@safabox.com')
                

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6d52dfe9-2962-4616-949d-54dcee7c0a4d', N'Administrator')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fe91fd26-3702-41d2-8144-daeeff9380c5', N'Coordinador')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1ac48113-dd40-42a1-9864-8d550c1df4be', N'Empleado')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e2f0ee10-63ea-42a8-95a7-645e5ba63e2f', N'Socio')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'34bd7dcd-07cc-48d6-a5d2-f28e2782d069', N'1ac48113-dd40-42a1-9864-8d550c1df4be')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dcf9d173-c5bc-4f3c-85b4-d77592d6a144', N'6d52dfe9-2962-4616-949d-54dcee7c0a4d')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'49f7df01-44f3-47e2-af2b-2c2c82d48202', N'e2f0ee10-63ea-42a8-95a7-645e5ba63e2f')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7f3887a3-902e-41bd-8c1f-f5e1d4f0b2c2', N'fe91fd26-3702-41d2-8144-daeeff9380c5')

            ");

        }
        
        public override void Down()
        {
        }
    }
}
