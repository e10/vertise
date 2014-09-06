using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Vertise.Core.Helpers;

namespace Vertise.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<User> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
            }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            BackendDatabaseHelper.InjectModels(modelBuilder);
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Vertise.Core.Data.Message> Messages { get; set; }
    }
}