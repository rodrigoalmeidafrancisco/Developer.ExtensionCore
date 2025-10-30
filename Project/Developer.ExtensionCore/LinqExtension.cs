using System;
using System.Linq.Expressions;

namespace Developer.ExtensionCore
{
    public static class LinqExtension
    {
        public static Expression<Func<T, bool>> AddExpression<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.AndAlso(Expression.Invoke(expr1, parameter), Expression.Invoke(expr2, parameter));
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
