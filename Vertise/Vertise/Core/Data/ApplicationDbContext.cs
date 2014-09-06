using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vertise.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<User> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
            }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Media> Media { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }
    }
}