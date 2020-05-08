﻿using Auth.Application.Applications.Queries.Get.Models;
using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Applications.Queries.Get
{
    public class GetApplicationQueryHandler : IRequestHandler<GetApplicationQuery, ApplicationPermisionsVM>
    {
        private readonly IAppDbContext _context;
        public GetApplicationQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicationPermisionsVM> Handle(GetApplicationQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name;
            cancellationToken.ThrowIfCancellationRequested();
            var application = await _context.Applications.AsNoTracking()
                .Include(ap => ap.Permisions)
                .SingleOrDefaultAsync(ap => ap.Name == normalizedName, cancellationToken);            
            if (application == null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                throw new NotFoundException(nameof(Domain.Applications.Application), request.Name);
            }
            var result = application.ToMap();
            cancellationToken.ThrowIfCancellationRequested();
            return result;
        }
    }
}