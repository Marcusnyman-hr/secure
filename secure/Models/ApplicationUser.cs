using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string BankName { get; set; }
        public long BankNumber { get; set; }
    }
}
