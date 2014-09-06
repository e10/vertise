using System.Data.Entity;
using Vertise.Core.Data;
using Vertise.Models;

namespace Vertise.Repositories {
    public class MessageRepository : EfRepository<Message> {
        public MessageRepository(DbContext db) : base(db) { }
        internal static void InjectModelConfiguration(DbModelBuilder modelBuilder) {
            //do nothing
        }
    }
}