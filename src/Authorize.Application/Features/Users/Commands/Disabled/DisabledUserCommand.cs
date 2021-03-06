﻿using Authorize.Application.Attributtes;
using MediatR;

namespace Authorize.Application.Features.Users.Commands.Disabled
{
    [Authorize(AuthPermissions.UserDisabled)]
    public class DisabledUserCommand : IRequest
    {
        public string UserName { get; set; }
    }
}
