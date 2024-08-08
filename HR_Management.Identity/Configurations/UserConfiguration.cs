using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "e0d0d5df-5c85-4476-90d7-089814fb65a6",
                    Email = "aztecgoodamin1@gmail.com",
                    NormalizedEmail = "AZTECGOODAMIN1@GMAIL.COM",
                    FirstName = "Amin",
                    LastName = "Amini",
                    UserName = "AminJP",
                    NormalizedUserName = "AMINJP",
                    PasswordHash = hasher.HashPassword(null, "P@ssword123"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "e8490e9b-4965-47b4-adb3-d155671ed8c8",
                    Email = "aztecgoodamin@gmail.com",
                    NormalizedEmail = "AZTECGOODAMIN@GMAIL.COM",
                    FirstName = "Amin",
                    LastName = "Amini",
                    UserName = "AminJP",
                    NormalizedUserName = "AMINJP",
                    PasswordHash = hasher.HashPassword(null, "P@ssword123"),
                    EmailConfirmed = true,
                }
            );
        }
    }
}
