using FantsyHospital.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для MainWindowPatient.xaml
    /// </summary>
    public partial class MainWindowPatient : Page
    {
        Core db = new Core();
        public MainWindowPatient(Patients userPatient)
        {
            InitializeComponent();

            Name.Text = userPatient.Name;
            Surname.Text = userPatient.Surname;
            Patronymic.Text = userPatient.Patronymic;
            DateOfBirthday.Text = userPatient.DateOfBirth.ToString();
            Gender.Text = userPatient.Genders.Gender;
            Addres.Text = userPatient.Addres;
            NumberPhone.Text = userPatient.PhoneNumber;
            DateOfReceipt.Text = userPatient.DateOfReceipt.ToString();
            DateOfDischarge.Text = userPatient.DateOfDischarge.ToString();
            ICODs.Text = userPatient.ICOD.ToString();
            Status.Text = userPatient.Status.ToString();
        }
    }
}
