using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Authorize.Application.Extensions;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace Authorize.Application.Validators
{
    public class PermissionsExistsValidator
    {
        private readonly DbSet<Domain.Applications.Application> _applications;
        private readonly CancellationToken _cancellationToken;
        private readonly Dictionary<string, IEnumerable<string>> _permissions;
        public PermissionsExistsValidator(DbSet<Domain.Applications.Application> applications,
            Dictionary<string, IEnumerable<string>> permissions, CancellationToken cancellationToken)          
        {
            _applications = applications;
            _cancellationToken = cancellationToken;
            _permissions = permissions;
        }

        public async Task ValidAsync()
        {
            var IsValid = await IsValidAsync();
            if (!IsValid)
            {
                throw new ValidationException("Not matched permissions");
            }
        }
        protected async Task<bool> IsValidAsync()
        {
            var applicationExistQuery = BuildExpresion(_permissions, _cancellationToken);
            if (applicationExistQuery == null)
            {
                return true;
            }
            var numApp = await _applications.AsNoTracking()
                .Where(applicationExistQuery)
                .CountAsync(_cancellationToken);
            return numApp == _permissions.Count();
        }

        private Expression<Func<Domain.Applications.Application, bool>> BuildExpresion(Dictionary<string,
            IEnumerable<string>> permissions, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Applications.Application, bool>> whereExpresion = null;
            foreach (var app in permissions)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Expression<Func<Domain.Applications.Application, bool>> query = 
                                    a => a.IsEnabled &&
                                    a.Name == app.Key &&
                                    app.Value.All(p => a.Permissions.Any(ap => ap.Name == p));
                if (whereExpresion != null)
                {
                    whereExpresion.Or(query);
                }
                else
                {
                    whereExpresion = query;
                }
            }
            return whereExpresion;
        }
    }

    
}
