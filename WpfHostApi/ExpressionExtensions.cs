using System;
using System.Linq.Expressions;

namespace WpfHostApi
{
    public static class ExpressionExtensions
    {
        public static string NameForProperty<TDelegate>(this Expression<TDelegate> propertyExpression)
        {
            var body = propertyExpression.Body is UnaryExpression expression
                ? expression.Operand
                : propertyExpression.Body;

            if (body is not MemberExpression member)
            {
                throw new ArgumentException("Property must be a MemberExpression");
            }

            return member.Member.Name;
        }
    }
}