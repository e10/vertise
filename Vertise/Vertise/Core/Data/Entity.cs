using System;
using Vertise.Core.Abstractions;

namespace Vertise.Core.Data
{
    public class Entity : IEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int Id { get; set; }
    }
}