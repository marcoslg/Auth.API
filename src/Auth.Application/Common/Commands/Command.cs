using MediatR;

namespace Auth.Application.Common.Commands
{
    public class Command<TReturn> : IRequest<TReturn>
    {
    }
}
