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
    /// Логика взаимодействия для NurseRegPage.xaml
    /// </summary>
    public partial class NurseRegPage : Page
    {
        Core db = new Core();
        public NurseRegPage()
        {
            InitializeComponent();

            MedicalProceduresComboBox.ItemsSource = db.context.MedicalProcedures.ToList();
            MedicalProceduresComboBox.DisplayMemberPath = "MedicalProcedure";

            DepartmentComboBox.ItemsSource = db.context.Departments.ToList();
            DepartmentComboBox.DisplayMemberPath = "Department";
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Nurses newNurse= new Nurses()
                {
                    Name = NameTextBox.Text,
                    Surname = SurnameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    Department = 1 + DepartmentComboBox.SelectedIndex,
                    MedicalProcedure = 1 + MedicalProceduresComboBox.SelectedIndex,
                    Login = LoginTextBox.Text,
                };
                Users newUser = new Users()
                {
                    Login = LoginTextBox.Text,
                    Password = PasswordTextBox.Password
                };

                db.context.Users.Add(newUser);
                db.context.Nurses.Add(newNurse);
                db.context.SaveChanges();

                MessageBox.Show("Добавление выполнено успешно !",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            catch (Exception ex) {
                MessageBox.Show("Критический сбор в работе приложения:" + ex.Message.ToString(),
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
            }
            
        }
    }
}
