using System;

namespace WpfHostApi.Exceptions
{
    public class SampleException : Exception
    {
        public SampleException(string message) : base(message)
        {
        }
    }
}