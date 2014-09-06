using System.Data.Entity;
using Vertise.Core.Abstractions;
using Vertise.Core.Data;
using Vertise.Models;

namespace Vertise.Repositories {
    public interface IMessageRepository : IRepository<Message> {}
    public class MessageRepository : EfRepository<Message>,IMessageRepository, IHasModelConfiguration {
        public MessageRepository(DbContext db) : base(db) { }
        internal static void InjectModelConfiguration(DbModelBuilder modelBuilder) {
            //do nothing
        }
    }
}