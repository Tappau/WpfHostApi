using System;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using System.Windows;

namespace WpfHostApi
{
    public static class Extensions
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

        public static void ThrowOnDispatcher(this Exception e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                ExceptionDispatchInfo.Capture(e).Throw();
            }));
        }
    }
}