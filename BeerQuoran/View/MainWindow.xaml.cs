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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeerQuoran
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window main;
        public MainWindow()
        {
            InitializeComponent();
            main = MainWindow.GetWindow(this);

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            main.Close();
        }

        private void btn_hide_Click(object sender, RoutedEventArgs e)
        {
            main.WindowState = WindowState.Minimized;
        }

        private void btn_resize_Click(object sender, RoutedEventArgs e)
        {
            switch (main.WindowState)
            {
                case WindowState.Normal:
                    main.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    main.WindowState = WindowState.Normal;
                    break;
            }
        }
    }
}
