using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.DTOs.Register
{
    public  class LoginUser
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
