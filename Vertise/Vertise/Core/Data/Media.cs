using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vertise.Core.Data
{
    public class Media {
        public int Id { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }

        public IList<Message> Messages { get; set; }
    }
}