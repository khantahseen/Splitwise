using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class GroupMember
    {
        #region Properties
        public int Id { get; set; }
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Groups Group { get; set; }

        public string MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Users User { get; set; }
        #endregion
    }
}
