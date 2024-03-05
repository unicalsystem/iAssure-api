using backend_dotnet.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace backend_dotnet.Core.DbContext
{
    public class ApplicationDb : IdentityDbContext<AppUser>
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
        {
        }

        // Define DbSet for your entities
        public DbSet<Log> Logs { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<MeasureGroup> MeasureGroups { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<HeadOffice> HeadOffice { get; set; }
        public DbSet<Branch> Branch { get; set; }



        // Customize model creation
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Identity tables
            builder.Entity<AppUser>(e =>
            {
                e.ToTable("Users");
            });

            builder.Entity<IdentityUserClaim<string>>(e =>
            {
                e.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(e =>
            {
                e.ToTable("UserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(e =>
            {
                e.ToTable("UserTokens");
            });

            builder.Entity<IdentityRole>(e =>
            {
                e.ToTable("Roles");
            });

            builder.Entity<IdentityRoleClaim<string>>(e =>
            {
                e.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserRole<string>>(e =>
            {
                e.ToTable("UserRoles");
            });

            //Configure Relations

            builder.Entity<MeasureGroup>()
                .HasOne(measuregroup => measuregroup.Standard)
                .WithMany(standard => standard.MeasureGroups)
                .HasForeignKey(measuregroup => measuregroup.StandardId);

            builder.Entity<Measure>()
                .HasOne(measure => measure.MeasureGroup)
                .WithMany(measuregroup => measuregroup.Measures)
                .HasForeignKey(measure => measure.MeasureGroupId);

            builder.Entity<Branch>()
                .HasOne(branch => branch.HeadOffice)
                .WithMany(headOffice => headOffice.Branches)
                .HasForeignKey(branch => branch.HeadOfficeId);


        }
    }
}
