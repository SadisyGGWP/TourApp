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
    /// Логика взаимодействия для KolyaPaje.xaml
    /// </summary>
    public partial class KolyaPaje : Page
    {
        public KolyaPaje()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Meneger.MainFrame.Navigate(new AddEditPage());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Meneger.MainFrame.Navigate(new AddEditPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Hotel>().ToList();

            if(MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CheChnyaEntities1.GetContext().Hotel.RemoveRange(hotelsForRemoving);
                    CheChnyaEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridHotels.ItemsSource = CheChnyaEntities1.GetContext().Hotel.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }
            }

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                CheChnyaEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotels.ItemsSource = CheChnyaEntities1.GetContext().Hotel.ToList();
            }
        }
    }
}
