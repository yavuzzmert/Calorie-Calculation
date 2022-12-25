using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Base.EntityFrameWork
{
    public static class QuerableExtension
    {
        public static IQueryable<T> MyIncludes<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (a, b) => a.Include(b));
            }

            return query;
        }
    }
}
