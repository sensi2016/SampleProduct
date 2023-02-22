using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SampleProduct.Application.Common;
using SampleProduct.Application.Common.Mappings;
using SampleProduct.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleProduct.Application.Products.Commands.ProductCustomer;

public record LoginUserCommand : IRequest<BaseResponseDto>
{
    public string UserName { get; set; }
    public string Password { get; set; }

}

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly  IConfiguration _configuration;

    public LoginUserCommandHandler(IApplicationDbContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<BaseResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        //var pp = GenerateToken(new User());
        var password= Helpers.CreateHashPassword(request.Password);
        var user =await _context.User.Where(d=>d.UserName==request.UserName && d.Password== password)
                                            .Include(d=>d.UserRoles)
                                            .ThenInclude(d=>d.Role)
                                            .FirstOrDefaultAsync();

        if (user is null)
            throw new NotFoundException("user not found");

        return new BaseResponseDto
        {
            Status=ResponseStatus.Success,
            Data= GenerateToken(user)
        };
    }

    private string GenerateToken(User user)
    {
        TimeSpan ExpiryDuration = new TimeSpan(24, 30, 0);
        var claims = new[]
        {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,
                user.Id.ToString()),
      
            new Claim(ClaimTypes.Role,user.UserRoles.FirstOrDefault().Role.Name),
  

             };

        var secretKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

      
        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            IssuedAt = DateTime.Now,
            // NotBefore = DateTime.Now.AddMinutes(_siteSetting.JwtSettings.NotBeforeMinutes),
            Expires = DateTime.Now.Add(ExpiryDuration),
            SigningCredentials = signingCredentials,
         
            Subject = new ClaimsIdentity(claims)
        };

        //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        //var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
        //    expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials,);
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(descriptor);
        string encryptedJwt = tokenHandler.WriteToken(securityToken);

        return encryptedJwt;


    }
}

