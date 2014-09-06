using System.Data.Entity;
using Vertise.Core.Abstractions;
using Vertise.Core.Data;

namespace Vertise.Repositories
{
    public class UserRepository : IHasModelConfiguration{
        internal static void InjectModelConfiguration(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Followers)
                .WithMany(x => x.Following)
                .Map(x => x.MapLeftKey("FollowerId")
                    .MapRightKey("FolloweeId")
                    .ToTable("Followers"));

        }
    }
}