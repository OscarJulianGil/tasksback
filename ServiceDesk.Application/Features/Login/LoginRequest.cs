using System;
using MediatR;

namespace ServiceDesk.Application.Features.Login;

public record LoginRequest(string UserName,string Password):IRequest<LoginResponse>;


