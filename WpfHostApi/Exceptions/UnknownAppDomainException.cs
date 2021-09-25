using System;

namespace WpfHostApi.Exceptions
{
    public class UnknownAppDomainException : Exception
    {
        public UnknownAppDomainException(string message) : base(message)
        {
        }
    }
}