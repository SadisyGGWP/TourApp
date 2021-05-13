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

namespace TourApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainKolyaPaje.Navigate(new KolyaPaje());
            Meneger.MainFrame = MainKolyaPaje;

            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Meneger.MainFrame.GoBack();
        }

        private void MainKolyaPaje_ContentRendered(object sender, EventArgs e)
        {
            if (MainKolyaPaje.CanGoBack)
            {
                button.Visibility = Visibility.Visible;
            }
            else
            {
                button.Visibility = Visibility.Hidden;
            }
        }

        private void MainKolyaPaje_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
