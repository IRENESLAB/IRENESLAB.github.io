using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthWebAPI.Models
{
    public class AppUserModel : LoginModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string FullName
        {
            get
            {
                return string.Concat(FirstName, LastName);
            }
        }
    }
}
