using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace AppraisalTool.Identity.Configurations
{
    [ExcludeFromCodeCoverage]
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Viewer",
                    NormalizedName = "VIEWER"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "ReportingAuthority",
                    NormalizedName = "REPORTINGAUTHORITY"
                },
                new IdentityRole
                {
                    Name = "ReviewingAuthority",
                    NormalizedName = "REVIEWINGAUTHORITY"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
            );

          
        }
    }
}
