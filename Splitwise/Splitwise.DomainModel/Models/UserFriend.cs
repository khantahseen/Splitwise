using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class UserFriend
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }

        public string FriendId { get; set; }
        [ForeignKey("FriendId")]
        public Users Friend { get; set; }
    }
}
