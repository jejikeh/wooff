using System;
using System.Collections.Generic;

namespace Wooff.ECS.Contexts
{
    public interface IQueryable<out T>
    {
        public IQueryable<T1> ContextSelectQuery<T1>(Func<T, T1> query);
        public IEnumerable<T> ContextWhereQuery(Func<T, bool> query);
    }
}