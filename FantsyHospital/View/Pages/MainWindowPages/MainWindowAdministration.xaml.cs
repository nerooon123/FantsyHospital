using FantsyHospital.Model;
using FantsyHospital.View.Pages.ResourcePages.AdministrationPages;
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

namespace FantsyHospital.View.Pages.MainWindowPages
{
    /// <summary>
    /// Логика взаимодействия для MainWindowAdministration.xaml
    /// </summary>
    public partial class MainWindowAdministration : Page
    {
        Core db = new Core();
        public MainWindowAdministration(Administrations userAdmin)
        {
            InitializeComponent();
        }

        private void AllUsersButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UsersControlPage());
        }
    }
}
