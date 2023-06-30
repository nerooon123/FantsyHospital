using FantsyHospital.Model;
using FantsyHospital.View.Pages.RegistrationPages;
using FantsyHospital.View.Pages.ResourcePages.AdministrationPages;
using FantsyHospital.View.Pages.ResourcePages.DoctorPages;
using FantsyHospital.View.Pages.ResourcePages.NursePages;
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

        private void AllPatientsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PatientsControlPage());
        }

        private void NurseAllPatientsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NursePatientsControlPage());
        }

        private void ICOD_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddICODPage());
        }

        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DoctorRegPage());
        }

        private void AddNurse_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NurseRegPage());
        }

        private void Specialization_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddSpecializationPage());
        }

        private void Department_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddDepartmentPage());
        }
    }
}
