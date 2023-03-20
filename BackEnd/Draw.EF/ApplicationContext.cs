using Draw.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Draw.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Diagram> Diagram { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }




        protected override void OnModelCreating(ModelBuilder builder)
        {

            // One To Meny Relation
            builder.Entity<Diagram>()
                .HasOne(c => c.User)
                .WithMany(c => c.Diagrams)
                .HasForeignKey(c => c.FKUser_Id);


            base.OnModelCreating(builder);
        }
    }
}
