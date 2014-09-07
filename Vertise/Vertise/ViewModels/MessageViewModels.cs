using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vertise.Core.Data;

namespace Vertise.ViewModels {

    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserUserName { get; set; }
        public DateTime Created { get; set; }
    }

    public class MessageCreateModel
    {
        [MaxLength(420),Required]
        public string Body { get; set; }

        internal Message ToEntity(string user)
        {
            return new Message()
            {
                Body = this.Body,
                UserId = user
            };
        }
    }

    public class MessageResult : MessageViewModel {
        public IEnumerable<MessageViewModel> Replies { get; set; }
    }
}