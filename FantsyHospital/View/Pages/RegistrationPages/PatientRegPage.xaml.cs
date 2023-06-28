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

namespace FantsyHospital.View.Pages.RegistrationPages
{
    /// <summary>
    /// Логика взаимодействия для PatientRegPage.xaml
    /// </summary>
    public partial class PatientRegPage : Page
    {
        Core db = new Core();
        public PatientRegPage()
        {
            InitializeComponent();

            GenderComboBox.ItemsSource = db.context.Genders.ToList();
            GenderComboBox.DisplayMemberPath = "Gender";
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
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
                    PhoneNumber = NumberPhoneTextBox.Text,
                    Addres = AddresTextBox.Text,
                    Login = LoginTextBox.Text,
                };
                Users newUser = new Users()
                {
                    Login = LoginTextBox.Text,
                    Password = PasswordTextBox.Password
                };

                db.context.Users.Add(newUser);
                db.context.Patients.Add(newPatient);
                db.context.SaveChanges();

                MessageBox.Show("Добавление выполнено успешно !",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения:" + ex.Message.ToString(),
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
            }
        }
    }
}
