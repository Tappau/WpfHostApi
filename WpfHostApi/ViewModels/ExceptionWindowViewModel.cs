using System;

namespace WpfHostApi.ViewModels
{
    public class ExceptionWindowViewModel : ViewModelBase
    {
        public Exception Exception { get; }

        public string ExceptionType { get; }

        public ExceptionWindowViewModel(Exception exception)
        {
            Exception = exception;
            ExceptionType = exception.GetType().FullName;
        }
    }
}