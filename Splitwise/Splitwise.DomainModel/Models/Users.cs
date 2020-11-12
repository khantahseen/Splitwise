using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Users : IdentityUser
    {
        #region Properties
        public string Name { get; set; }
        #endregion
    }

}
