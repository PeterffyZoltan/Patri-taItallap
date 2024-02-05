using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shell;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace BeerQuoran.ViewModel
{
    public class WindowCommands : ObservableRecipient
    {
        Window mainWindow;
        Values VALS;
        public ICommand Minimize { get; }
        public ICommand Resize { get; }
        public ICommand ChangeHeight { get; }
        public ICommand Search { get; }
        public ICommand SearchBarAnimation { get; }

        public event EventHandler StartFilterAnimationRequested;
        public event EventHandler StartSearchBoxAnimationRequested;

        public WindowCommands()
        {
            mainWindow = App.Current.MainWindow;
            VALS = new Values();
            Minimize = new RelayCommand(MinimizeWindow);
            Resize = new RelayCommand(ResizeWindow);
            ChangeHeight = new RelayCommand(ChangeFilterHeight);
            Search = new RelayCommand(ExecuteMakeQuery);
            SearchBarAnimation = new RelayCommand(ExecuteSearchBarAnimation);
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

        private void ChangeFilterHeight()
        {
            StartFilterAnimationRequested?.Invoke(this, EventArgs.Empty);            
        }

        public void ExecuteMakeQuery()
        {
            VALS.MakeQuery();
        }

        private void ExecuteSearchBarAnimation()
        {
            StartSearchBoxAnimationRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
