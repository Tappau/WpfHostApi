using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfHostApi.Windows
{
    /// <summary>
    /// Interaction logic for ExceptionWindow.xaml
    /// </summary>
    public partial class ExceptionWindow : Window
    {
        public ExceptionWindow()
        {
            InitializeComponent();
        }

        // In a real world application we would use a command
        // property on the viewmodel and some sort of system
        // service that we iject into the viewmodel to exit the
        // application.
        private void OnExitAppClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnExceptionWindowClosed(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
