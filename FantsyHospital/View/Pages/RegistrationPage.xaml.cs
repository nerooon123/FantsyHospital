using FantsyHospital.View.Pages.RegistrationPages;
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

namespace FantsyHospital.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void DoctorButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DoctorRegPage());
        }

        private void NurseButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NurseRegPage());
        }

        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PatientRegPage());
        }

        private void Administration_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdministrationRegPage());
        }
    }
}
