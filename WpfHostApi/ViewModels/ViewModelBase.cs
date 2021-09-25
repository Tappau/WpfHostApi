using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using WpfHostApi.Annotations;
using WpfHostApi.Core;

namespace WpfHostApi.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private NotifyIconWrapper.NotifyRequestRecord _notifyRequest;
        private bool _showInTaskbar;
        private WindowState _windowState;

        public ViewModelBase()
        {
            LoadedCommand = new RelayCommand(ExecuteLoaded);
            ClosingCommand = new RelayCommand<CancelEventArgs>(ExecuteClosing);
            ExitCommand = new RelayCommand(ExecuteExitCommand);
            NotifyCommand = new RelayCommand(() => ExecuteNotify(new Notification(){Message = "Hello from WPF!"}));
            OpenCommand = new RelayCommand(() => { WindowState = WindowState.Normal; });
        }

        public WindowState WindowState
        {
            get => _windowState;
            set
            {
                ShowInTaskbar = true;
                SetProperty(ref _windowState, value);
                ShowInTaskbar = value != WindowState.Minimized;
            }
        }

        public bool ShowInTaskbar
        {
            get => _showInTaskbar;
            set => SetProperty(ref _showInTaskbar, value);
        }

        public NotifyIconWrapper.NotifyRequestRecord NotifyRequest
        {
            get => _notifyRequest;
            set => SetProperty(ref _notifyRequest, value);
        }

        public ICommand NotifyCommand { get; }
        public ICommand OpenCommand { get; }

        private void ExecuteNotify([NotNull] Notification obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            NotifyRequest = new NotifyIconWrapper.NotifyRequestRecord
            {
                Title = obj.Title, 
                Text = obj.Message,
                Duration = obj.Duration
            };
        }

        protected virtual void ExecuteClosing(CancelEventArgs? eventArgs)
        {
            if (eventArgs == null)
            {
                return;
            }

            eventArgs.Cancel = true;
            WindowState = WindowState.Minimized;
        }

        protected virtual void ExecuteLoaded()
        {
        }

        protected virtual void ExecuteExitCommand()
        {
            Application.Current.Shutdown();
        }

        public ICommand LoadedCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand ClosingCommand { get; }
    }
}