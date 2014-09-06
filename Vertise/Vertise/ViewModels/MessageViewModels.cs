using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vertise.ViewModels {

    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
    }
    public class MessageResult : MessageViewModel {
        public IEnumerable<MessageViewModel> Replies { get; set; }
    }
}