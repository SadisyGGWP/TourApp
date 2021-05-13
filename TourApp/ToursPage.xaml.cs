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
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        public ToursPage()
        {
            InitializeComponent();
            var allTypes = CheChnyaEntities1.GetContext().Type.ToList();
            allTypes.Insert(0, new Type
            {
                Name = "Все типы"
            });

            CheckActual.IsChecked = true;
            ComboType.SelectedIndex = 0;

            ComboType.ItemsSource = allTypes;
            UpdateTours();
        }

        private void UpdateTours()
        {
            var currentTours = CheChnyaEntities1.GetContext().Tour.ToList();

            if(ComboType.SelectedIndex > 0)
            {
                currentTours = currentTours.Where(p => p.Type.Contains(ComboType.SelectedItem as Type)).ToList();
            }
            if (CheckActual.IsChecked.Value)
            {
                currentTours = currentTours.Where(p => p.ItActual).ToList();
            }
            LviewTours.ItemsSource = currentTours.OrderBy(p => p.TickerCount).ToList();
        }
        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }
    }
}
