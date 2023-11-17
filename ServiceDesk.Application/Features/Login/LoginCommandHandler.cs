﻿using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.Features.GenerateJWT;
using ServiceDesk.Infrastructure.Repository;

namespace ServiceDesk.Application.Features.Login
{
	public class LoginCommandHandler : IRequestHandler<LoginRequest, LoginResponse>
	{
        private readonly ServiceDeskDbContext db;
        private readonly IMediator mediator;

        public LoginCommandHandler(ServiceDeskDbContext db, IMediator mediator)
		{
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {

            var exists = await db.Users.Where(x => x.Email == request.UserName && x.Password == request.Password).FirstOrDefaultAsync();

            if(exists is null)
                return new LoginResponse() { Code = Enums.ApiResponses.NotFoundRecords, Message="User not found" };


            var token = await mediator.Send(new GenerateJWTCommandHandlerRequest(exists));

            return new LoginResponse() { Code = Enums.ApiResponses.Ok, Message = "User found",Token= token.Token,Id = exists.Id.ToString() };
        }
    }
}

