using System.Windows;

namespace WpfHostApi.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        protected override void ExecuteLoaded()
        {
            WindowState = WindowState.Minimized;
        }
    }
}