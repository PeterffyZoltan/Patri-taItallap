using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace BeerQuoran.ViewModel
{
    public class WindowCommands : ObservableRecipient
    {
        Window MainWindow;
        public ICommand Minimize { get; }
        public ICommand Resize { get; }

        public WindowCommands()
        {
            Minimize = new RelayCommand(MinimizeWindow);
            Resize = new RelayCommand(ResizeWindow);
        }

        private void ResizeWindow()
        {
            switch (App.Current.MainWindow.WindowState)
            {
                case WindowState.Maximized:
                    App.Current.MainWindow.WindowState = WindowState.Normal;
                    break;
                default:
                    App.Current.MainWindow.WindowState = WindowState.Maximized;
                    break;
            }
        }

        private void MinimizeWindow()
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
