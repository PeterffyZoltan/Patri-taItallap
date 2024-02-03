using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace BeerQuoran.ViewModel
{
    public class WindowCommands : ObservableRecipient
    {
        Window mainWindow;
        public ICommand Minimize { get; }
        public ICommand Resize { get; }

        public WindowCommands()
        {
            mainWindow = App.Current.MainWindow;
            Minimize = new RelayCommand(MinimizeWindow);
            Resize = new RelayCommand(ResizeWindow);
        }

        private void ResizeWindow()
        {
            switch (mainWindow.WindowState)
            {
                case WindowState.Maximized:
                    mainWindow.WindowState = WindowState.Normal;
                    break;
                default:
                    mainWindow.WindowState = WindowState.Maximized;
                    break;
            }
        }

        private void MinimizeWindow()
        {
            mainWindow.WindowState = WindowState.Minimized;
        }
    }
}
