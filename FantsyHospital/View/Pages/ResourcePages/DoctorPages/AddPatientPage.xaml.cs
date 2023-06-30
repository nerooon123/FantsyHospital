using FantsyHospital.Model;
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

namespace FantsyHospital.View.Pages.ResourcePages.DoctorPages
{
    /// <summary>
    /// Логика взаимодействия для AddPatientPage.xaml
    /// </summary>
    public partial class AddPatientPage : Page
    {
        Core db = new Core();
        public AddPatientPage()
        {
            InitializeComponent();

            GenderComboBox.ItemsSource = db.context.Genders.ToList();
            GenderComboBox.DisplayMemberPath = "Gender";

            ICODComboBox.ItemsSource = db.context.ICOD.ToList();
            ICODComboBox.DisplayMemberPath = "NameICOD";

            StatusComboBox.ItemsSource = db.context.Statuses.ToList();
            StatusComboBox.DisplayMemberPath = "Status";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patients newPatient = new Patients()
                {
                    Name = NameTextBox.Text,
                    Surname = SurnameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    DateOfBirth = Convert.ToDateTime(DateOfBirthdayPicker.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                    Gender = 1 + GenderComboBox.SelectedIndex,
                    Addres = AddresTextBox.Text,
                    PhoneNumber = NumberPhoneTextBox.Text,
                    DateOfReceipt = Convert.ToDateTime(DateOfReceiptPicker.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                    DateOfDischarge = Convert.ToDateTime(DateOfDischargePicker.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                    ICOD = 1 + ICODComboBox.SelectedIndex,
                    Status = 1 + ICODComboBox.SelectedIndex,
                    Login = LoginTextBox.Text,
                };
                Users newUser = new Users()
                {
                    Login = LoginTextBox.Text,
                    Password = PasswordTextBox.Text
                };

                db.context.Users.Add(newUser);
                db.context.Patients.Add(newPatient);
                db.context.SaveChanges();

                MessageBox.Show("Добавление выполнено успешно !",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения:" + ex.InnerException.ToString(),
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
            }
        }
    }
}
