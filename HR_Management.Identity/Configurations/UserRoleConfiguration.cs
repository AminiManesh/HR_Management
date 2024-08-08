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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "c9d9b820-c3b6-4a0c-81fa-9b0b11e21b88",
                    UserId = "e8490e9b-4965-47b4-adb3-d155671ed8c8"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "9dd1e0e4-27e1-4fef-8e44-23d9f1dd2677",
                    UserId = "e0d0d5df-5c85-4476-90d7-089814fb65a6"
                }
            );
        }
    }
}
