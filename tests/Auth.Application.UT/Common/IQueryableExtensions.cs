using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.Application.UT.Common
{
    internal static class IQueryableExtensions
    {
        public static IQueryable<T> Initialize<T>(this IQueryable<T> dbSet, IQueryable<T> data) where T : class
        {
            dbSet.Provider.Returns(data.Provider);
            //dbSet.Expression.Returns(data.Expression);
            //dbSet.ElementType.Returns(data.ElementType);
            //dbSet.GetEnumerator().Returns(data.GetEnumerator());
            return dbSet;
        }
    }
}
