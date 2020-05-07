using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Auth.Application.Extensions;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace Auth.Application.Validators
{
    public class PermissionsExistsValidator
    {
        private readonly DbSet<Domain.Applications.Application> _applications;
        private readonly CancellationToken _cancellationToken;
        private readonly Dictionary<string, IEnumerable<string>> _permisions;
        public PermissionsExistsValidator(DbSet<Domain.Applications.Application> applications, Dictionary<string, IEnumerable<string>> permisions, CancellationToken cancellationToken)          
        {
            _applications = applications;
            _cancellationToken = cancellationToken;
            _permisions = permisions;
        }

        public async Task ValidAsync()
        {
            var IsValid = await IsValidAsync();
            if (!IsValid)
            {
                throw new ValidationException("Not matched permisions");
            }
        }
        protected async Task<bool> IsValidAsync()
        {
            var applicationExistQuery = BuildExpresion(_permisions, _cancellationToken);
            if (applicationExistQuery == null)
            {
                return true;
            }
            var numApp = await _applications.AsNoTracking()
                .Where(applicationExistQuery)
                .CountAsync(_cancellationToken);
            return numApp == _permisions.Count();
        }

        private Expression<Func<Domain.Applications.Application, bool>> BuildExpresion(Dictionary<string, IEnumerable<string>> permisions, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Applications.Application, bool>> whereExpresion = null;
            foreach (var app in permisions)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Expression<Func<Domain.Applications.Application, bool>> query = a => a.IsEnabled && a.Name == app.Key && app.Value.All(p => a.Permisions.Any(ap => ap.Name == p));
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
