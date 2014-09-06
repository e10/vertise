using System;

namespace Vertise.Core.Abstractions
{
    public interface ISoftDelete {
        bool IsDeleted { get; set; }
        DateTime? Deleted { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }

    public interface IHasModelConfiguration
    {
        
    }
}