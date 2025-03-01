using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.DTOs.Register
{
    public class RefreshToken
    {
        
            public int Id { get; set; }
            public string Token { get; set; } = null!;
            public string UserId { get; set; } = null!;
            public DateTime ExpiresAt { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            public bool Revoked { get; set; } = false;
        }

    }

