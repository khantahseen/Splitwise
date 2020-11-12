using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Groups
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Users User { get; set; }
        #endregion
    }
}
