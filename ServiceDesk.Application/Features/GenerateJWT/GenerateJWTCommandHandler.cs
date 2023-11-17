using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceDesk.Application.Features.Login;
using ServiceDesk.Domain.Models;

namespace ServiceDesk.Application.Features.GenerateJWT
{
	public class GenerateJWTCommandHandler : IRequestHandler<GenerateJWTCommandHandlerRequest, GenerateJWTCommandHandlerResponse>
    {

        private readonly IConfiguration configuration;

		public GenerateJWTCommandHandler(IConfiguration configuration)
		{
            this.configuration = configuration;
		}

        public async Task<GenerateJWTCommandHandlerResponse> Handle(GenerateJWTCommandHandlerRequest request, CancellationToken cancellationToken)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,request.User.Email)
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new GenerateJWTCommandHandlerResponse()
            {
                Code = Enums.ApiResponses.Ok,
                Message = "ok",
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}

