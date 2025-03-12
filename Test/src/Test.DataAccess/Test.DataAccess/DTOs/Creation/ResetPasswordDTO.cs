using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.DTOs.Creation;

public  class ResetPasswordDTO
{
    public required string Code { get; set; }
    public required string NewPassword { get; set; }
}
