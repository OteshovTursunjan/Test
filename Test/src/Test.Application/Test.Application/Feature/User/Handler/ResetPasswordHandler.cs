using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.User.Command;
using Test.DataAccess;

namespace Test.Application.Feature.User.Handler;

public  class ResetPasswordHandler : IRequestHandler<ResetPassowrdCommand, string>
{
    private readonly DatabaseContext _context;
    public ResetPasswordHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(ResetPassowrdCommand request, CancellationToken cancellationToken)
    {
        var token = await _context.passwordResetTokens.
            FirstOrDefaultAsync(t => t.Code == request.ResetPasswordDTO.Code 
            && t.ExpiryDate > DateTime.UtcNow);

        if (token == null)
        {
            return ("Invalid or expired code");
        }
        var user = await _context.Users.FindAsync(token.UserId);
        if (user == null)
            return ("User not found");
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.ResetPasswordDTO.NewPassword);
        await _context.SaveChangesAsync();
        return ("Password has been rest");
    }
}
