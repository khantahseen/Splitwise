using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class LoginAC
    {
        #region Properties
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        #endregion
    }
}
