using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelBuilding
{
    public class SeedConfigurator
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            UserSeed(modelBuilder);
        }

        private static void UserSeed(ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new()
                {
                    Id = 1,
                    UserName = "icko15.8@gmail.com",
                    NormalizedUserName = "ICKO15.8@GMAIL.COM",
                    Email = "icko15.8@gmail.com",
                    NormalizedEmail = "ICKO15.8@GMAIL.COM",
                    PasswordHash =
                        "AQAAAAIAAYagAAAAENiNPb3FcFuhzPcO8DoEvBPAgJpINHNVLQX/UlIhdcpqdZWICDasSvDpEVMu1g/W4g==",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    SecurityStamp = "f5bd309e-5ebc-40dd-b0fc-655cfea70a70",
                    ConcurrencyStamp = "4ea1a2fc-a47c-44fe-b404-a70225b2b390"
                }
            };

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}