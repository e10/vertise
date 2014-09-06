using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vertise.Core.Data
{
    public class Message : Entity {
        [MaxLength(420)]
        public string Body { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public bool IsReply { get; set; }
        public IList<Message> Replies { get; set; }
        public IList<Media> Media { get; set; }

        public Message Parent { get; set; }
        public int? ParentId { get; set; }

    }
}