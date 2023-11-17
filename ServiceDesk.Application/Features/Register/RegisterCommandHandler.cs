using System;
using MediatR;
using ServiceDesk.Application.Features.GenerateJWT;
using ServiceDesk.Application.Helpers;
using ServiceDesk.Domain.Models;
using ServiceDesk.Infrastructure.Repository;

namespace ServiceDesk.Application.Features.Register
{
	public class RegisterCommandHandler : IRequestHandler<RegisterRequest, RegisterResponse>
	{
        private readonly ServiceDeskDbContext db;
        private readonly IMediator mediator;
        public RegisterCommandHandler(ServiceDeskDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }


        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var exists = db.Users.Where(x => x.Email == request.Email).FirstOrDefault();

            if (exists is not null)
                return new RegisterResponse()
                {
                    Code = Enums.ApiResponses.ServerError,
                    Message = "This email is already registered"
                };

            

            User newUser = new User();
            newUser.Email = request.Email;
            newUser.Name = request.Name;
            newUser.Password = request.Password;

            db.Users.Add(newUser);
            await db.SaveChangesAsync();

            var accessToken = await mediator.Send(new GenerateJWTCommandHandlerRequest(newUser));

            return new RegisterResponse()
            {
                Code = Enums.ApiResponses.Ok,
                Message = "User registered successfully",
                Id = newUser.Id.ToString(),
                token = accessToken.Token
            };

        }
    }
}

