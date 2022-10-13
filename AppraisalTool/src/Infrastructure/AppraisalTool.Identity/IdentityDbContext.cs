using AppraisalTool.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Identity
{
    [ExcludeFromCodeCoverage]
    public class IdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Appraisal> Appraisal { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Kra> Kra { get; set; }
        public DbSet<FinancialYear> FinancialYear { get; set; }
        public DbSet<KraDetail> KraDetail { get; set; }
        public DbSet<Status> Status { get; set; }









    }
}
