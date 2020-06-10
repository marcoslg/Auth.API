//using Authorize.Application.Attributtes;
//using Authorize.Application.Contracts;
//using Authorize.Application.Exceptions;
//using Authorize.Application.Features.Permissions.Queries.GetByUser.Models;
//using MediatR;
//using MediatR.Pipeline;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Authorize.Application.Behaviours
//{
//    public class RequestAuthPreProcessorBehavior<TRequest> : IRequestPreProcessor<TRequest>       
//    {
//        private readonly IMediator _mediator;
//        private readonly ICurrentUserService _currentUserService;
//        private readonly IAuthConfiguration _authConfig;
//        public RequestAuthPreProcessorBehavior(IMediator mediator, ICurrentUserService currentUserService, IAuthConfiguration authConfig)
//        {
//            _mediator = mediator;
//            _currentUserService = currentUserService;
//            _authConfig = authConfig;
//        }

//        public async Task Process(TRequest request, CancellationToken cancellationToken)
//        {
//            var authorizeAttrs = request.GetType()
//                .GetCustomAttributes(true)
//                .OfType<AuthorizeAttribute>();
//            if (authorizeAttrs == null || !authorizeAttrs.Any())
//            {
//                return;
//            }

//            var username = _currentUserService.UserName;
//            var appName = _authConfig.ApplicationName;
//            var response = await _mediator.Send(new GetPermissionsQuery(username, appName));
//            if (!response.Any(r=> authorizeAttrs.Any(a=> a.Permission == r.Name)))
//            {
//                throw new ForbiddenException(typeof(TRequest).Name);
//            }
//        }
//    }
//}
