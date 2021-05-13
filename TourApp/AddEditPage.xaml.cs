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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel _currentHotel = new Hotel();
        public AddEditPage()
        {
            InitializeComponent();
            DataContext = _currentHotel;
            ComboCountries.ItemsSource = CheChnyaEntities1.GetContext().Coutnry.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentHotel.Name))
            {
                errors.AppendLine("Укажите название отеля");
                
            }
            if (_currentHotel.CoverOfStars < 1 || _currentHotel.CoverOfStars > 5)
            {
                errors.AppendLine("Количество звезд - от 1 до 5");

            }
            if(_currentHotel.Coutnry == null)
            {
                errors.AppendLine("Выберите страну");
            }
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(_currentHotel.id == 0)
            {
                CheChnyaEntities1.GetContext().Hotel.Add(_currentHotel);

            }
            try
            {
                CheChnyaEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Meneger.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
    }
}
