using FantsyHospital.Model;
using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для EditPatientPage.xaml
    /// </summary>
    public partial class EditPatientPage : Page
    {
        Core db = new Core();

        public EditPatientPage(Patients patient)
        {
            InitializeComponent();

            GenderComboBox.ItemsSource = db.context.Genders.ToList();
            GenderComboBox.DisplayMemberPath = "Gender";

            ICODComboBox.ItemsSource = db.context.ICOD.ToList();
            ICODComboBox.DisplayMemberPath = "NameICOD";

            StatusComboBox.ItemsSource = db.context.Statuses.ToList();
            StatusComboBox.DisplayMemberPath = "Status";

            IdTextBlock.Text = patient.IdPatient.ToString();
            NameTextBox.Text = patient.Name;
            SurnameTextBox.Text = patient.Surname;
            PatronymicTextBox.Text = patient.Patronymic;
            DateOfBirthdayPicker.SelectedDate = patient.DateOfBirth;
            GenderComboBox.SelectedIndex = patient.Gender - 1;
            AddresTextBox.Text = patient.Addres;
            NumberPhoneTextBox.Text = patient.PhoneNumber;
            DateOfReceiptPicker.SelectedDate = patient.DateOfReceipt;
            DateOfDischargePicker.SelectedDate = patient.DateOfDischarge;
            ICODComboBox.SelectedIndex = patient.ICOD1.IdICOD - 1;
            StatusComboBox.SelectedIndex = patient.Statuses.IdStatus - 1;
            LoginTextBlock.Text = patient.Login;


        }

        

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IdTextBlock.Text); // ID записи, которую нужно изменить

            // Получение объекта из базы данных по ID
            var objectToUpdate = db.context.Patients.FirstOrDefault(x => x.IdPatient == id);

            if (objectToUpdate != null)
            {


                if(NameTextBox.Text != String.Empty
                    && SurnameTextBox.Text != String.Empty
                    && PatronymicTextBox.Text != String.Empty
                    && DateOfBirthdayPicker.SelectedDate != null
                    && AddresTextBox.Text != String.Empty
                    && NumberPhoneTextBox.Text != String.Empty
                    && DateOfReceiptPicker.SelectedDate != null
                    && DateOfDischargePicker.SelectedDate != null)
                {
                    // Вносим изменения в свойства объекта
                    objectToUpdate.IdPatient = Convert.ToInt32(IdTextBlock.Text);
                    objectToUpdate.Name = NameTextBox.Text;
                    objectToUpdate.Surname = SurnameTextBox.Text;
                    objectToUpdate.Patronymic = PatronymicTextBox.Text;
                    objectToUpdate.DateOfBirth = Convert.ToDateTime(DateOfBirthdayPicker.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture));
                    objectToUpdate.Gender = 1 + GenderComboBox.SelectedIndex;
                    objectToUpdate.Addres = AddresTextBox.Text;
                    objectToUpdate.PhoneNumber = NumberPhoneTextBox.Text;
                    objectToUpdate.DateOfReceipt = Convert.ToDateTime(DateOfReceiptPicker.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture));
                    objectToUpdate.DateOfDischarge = Convert.ToDateTime(DateOfDischargePicker.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture));
                    objectToUpdate.ICOD = 1 + ICODComboBox.SelectedIndex;
                    objectToUpdate.Status = 1 + StatusComboBox.SelectedIndex;
                    objectToUpdate.Login = LoginTextBlock.Text;

                    // Сохраняем изменения в базе данных
                    try
                    {
                        db.context.SaveChanges();
                        MessageBox.Show("Данные успешно изменены.");
                        this.NavigationService.Navigate(new PatientsControlPage());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при изменении данных: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните пустые поле!");
                }
            }
        }
    }
}
