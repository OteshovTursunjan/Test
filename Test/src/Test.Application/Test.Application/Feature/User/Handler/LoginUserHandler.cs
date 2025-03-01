using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Test.Application.Feature.User.Command;
using Test.DataAccess.DTOs.Register;
using Tests.Core.Enteties;
using Test.DataAccess;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, ReturnRegisterModel>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly DatabaseContext _context; // Контекст базы данных

    public LoginUserHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration, DatabaseContext context)
    {
        _userManager = userManager;
        _configuration = configuration;
        _context = context;
    }

    public async Task<ReturnRegisterModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.LoginUser.Email);
       // if (user == null || !await _userManager.CheckPasswordAsync(user, request.LoginUser.Password))
         //   return null;

        var jwtSecret = _configuration["JwtOptions:SecretKey"] 
            ?? throw new InvalidOperationException("JWT Secret Key is not configured");
        var jwtIssuer = _configuration["JwtOptions:Issuer"] 
            ?? throw new InvalidOperationException("JWT Issuer is not configured");
        var jwtAudience = _configuration["JwtOptions:Audience"] 
            ?? throw new InvalidOperationException("JWT Audience is not configured");
        var jwtExpiryMinutes = _configuration["JwtOptions:ExpirationInMinutes"] 
            ?? throw new InvalidOperationException("JWT Expiration In Minutes is not configured");

        var claims = new List<Claim>
        {
            new Claim(CustomClaim.Email, user.Email),
            new Claim(ClaimTypes.Role, "Student"),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName),
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        var accessToken = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtExpiryMinutes)),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        // 🔹 Генерация Refresh Token
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), // Случайный токен
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(7) // Живёт 7 дней
        };

        // 🔹 Сохраняем Refresh Token в БД
        await _context.AddAsync(refreshToken);
        await _context.SaveChangesAsync();

        return new ReturnRegisterModel
        {
            Email = request.LoginUser.Email,
            Token = new JwtSecurityTokenHandler().WriteToken(accessToken),
            RefreshToken = refreshToken.Token, // Отправляем клиенту
            DateTime = accessToken.ValidTo,
            LastName = user.LastName,
            FirstName = user.FirstName
        };
    }
}
