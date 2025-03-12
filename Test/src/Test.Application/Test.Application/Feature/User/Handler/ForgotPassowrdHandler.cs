using MailKit.Net.Smtp;
using MailKit.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Net.Mail;
using Test.Application.Feature.User.Command;
using Test.DataAccess;

namespace Test.Application.Feature.User.Handler;

public class ForgotPassowrdHandler : IRequestHandler<ForgotPassowrdCommand, string>
{
    private readonly DatabaseContext _context;
    public ForgotPassowrdHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<string> Handle(ForgotPassowrdCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.ForgotPassowrdDTO.Email);
        if (user == null)
        {
            return ("User not found");
        }
        var resetCode = new Random().Next(1000, 9999).ToString();
       
       var newpassw = new  Tests.Core.Enteties.PasswordResetToken()
        {
            UserId = user.Id,
            Code = resetCode,
            ExpiryDate = DateTime.UtcNow.AddMinutes(5)
        };
        await _context.passwordResetTokens.AddAsync(newpassw);
        await _context.SaveChangesAsync();  


        await SendEmialAsync(user.Email, "Password Reset Code", $"Your code: {resetCode}");
        return ("Reset code sent to email");
    }

    public async Task SendEmialAsync(string email, string subject, string message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Admin", "hanslandass44@gmail.com"));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart("plain") { Text = message };
        using (var client = new MailKit.Net.Smtp.SmtpClient())
        {
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("your-email@example.com", "your-email-password");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
