using System.Data.Entity;
using Vertise.Core.Abstractions;
using Vertise.Core.Data;

namespace Vertise.Repositories
{
    public interface IMediaRepository : IRepository<Media>{}
    public class MediaRepository : EfRepository<Media>,IMediaRepository, IHasModelConfiguration {
        public MediaRepository(DbContext db) : base(db) { }
        internal static void InjectModelConfiguration(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Media>()
                .HasMany(x => x.Messages)
                .WithMany(x => x.Media)
                .Map(x => x.MapLeftKey("MediaId")
                    .MapRightKey("MsssageId")
                    .ToTable("MessageMediaMapping"));
        }
    }
}