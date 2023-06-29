using FantsyHospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FantsyHospital.View.Pages.ResourcePages.AdministrationPages
{
    /// <summary>
    /// Логика взаимодействия для UsersControlPage.xaml
    /// </summary>
    public partial class UsersControlPage : Page
    {
        Core db = new Core();
        public UsersControlPage()
        {
            InitializeComponent();


            AdministartionDataGrid.ItemsSource = db.context.Administrations.ToList();
            DoctorDataGrid.ItemsSource = db.context.Doctors.ToList();
            NurseDataGrid.ItemsSource = db.context.Nurses.ToList();
            PatientDataGrid.ItemsSource = db.context.Patients.ToList();
        }

        private void SearchAdminstartionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchAdminstartionTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var admin = new ObservableCollection<Administrations>(db.context.Administrations.ToList());
                AdministartionDataGrid.ItemsSource = admin;
            }
            else
            {
                var result = db.context.Administrations.Where(p => p.IdAdministration.ToString().Contains(searchText)
                    || p.Name.ToString().Contains(searchText)
                    || p.Surname.ToString().Contains(searchText)
                    || p.Patronymic.ToString().Contains(searchText)
                    || p.Login.ToString().Contains(searchText)
                    || p.Users.Password.ToString().Contains(searchText)).ToList();

                var admin = new ObservableCollection<Administrations>(result);
                AdministartionDataGrid.ItemsSource = admin;
            }
        }

        private void SearchDoctorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchDoctorTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var doctor = new ObservableCollection<Doctors>(db.context.Doctors.ToList());
                DoctorDataGrid.ItemsSource = doctor;
            }
            else
            {
                var result = db.context.Doctors.Where(p => p.IdDoctor.ToString().Contains(searchText)
                    || p.Name.ToString().Contains(searchText)
                    || p.Surname.ToString().Contains(searchText)
                    || p.Patronymic.ToString().Contains(searchText)
                    || p.Specializations.Specialization.ToString().Contains(searchText)
                    || p.Departments.Department.ToString().Contains(searchText)
                    || p.Login.ToString().Contains(searchText)
                    || p.Users.Password.ToString().Contains(searchText)).ToList();

                var doctor = new ObservableCollection<Doctors>(result);
                DoctorDataGrid.ItemsSource = doctor;
            }
        }

        private void SearchNurseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchNurseTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var nurse = new ObservableCollection<Nurses>(db.context.Nurses.ToList());
                NurseDataGrid.ItemsSource = nurse;
            }
            else
            {
                var result = db.context.Nurses.Where(p => p.IdNurse.ToString().Contains(searchText)
                    || p.Name.ToString().Contains(searchText)
                    || p.Surname.ToString().Contains(searchText)
                    || p.Patronymic.ToString().Contains(searchText)
                    || p.MedicalProcedures.MedicalProcedure.ToString().Contains(searchText)
                    || p.Departments.Department.ToString().Contains(searchText)
                    || p.Login.ToString().Contains(searchText)
                    || p.Users.Password.ToString().Contains(searchText)).ToList();

                var nurse = new ObservableCollection<Nurses>(result);
                NurseDataGrid.ItemsSource = nurse;
            }
        }

        private void SearchPatientTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchPatientTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var patient = new ObservableCollection<Patients>(db.context.Patients.ToList());
                PatientDataGrid.ItemsSource = patient;
            }
            else
            {
                var result = db.context.Patients.Where(p => p.IdPatient.ToString().Contains(searchText)
                    || p.Name.ToString().Contains(searchText)
                    || p.Surname.ToString().Contains(searchText)
                    || p.Patronymic.ToString().Contains(searchText)
                    || p.DateOfBirth.ToString().Contains(searchText)
                    || p.Genders.Gender.ToString().Contains(searchText)
                    || p.Addres.ToString().Contains(searchText)
                    || p.PhoneNumber.ToString().Contains(searchText)
                    || p.DateOfReceipt.ToString().Contains(searchText)
                    || p.DateOfDischarge.ToString().Contains(searchText)
                    || p.ICOD1.NameICOD.ToString().Contains(searchText)
                    || p.Statuses.Status.ToString().Contains(searchText)
                    || p.Login.ToString().Contains(searchText)
                    || p.Users.Password.ToString().Contains(searchText)).ToList();

                var patient = new ObservableCollection<Patients>(result);
                PatientDataGrid.ItemsSource = patient;
            }
        }

        private void AdminDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = AdministartionDataGrid.SelectedItem as Administrations;
                //проверка того, что пользователь выбрал строки для удаления
                if (item == null)
                {
                    MessageBox.Show("Вы не выбрали ни одной строки");
                    return;
                }
                else
                {
                    //выполним удаление только в том случае, если пользователь даст согласие на удаление
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        //удаляем выбранную строку
                        db.context.Administrations.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        AdministartionDataGrid.ItemsSource = db.context.Administrations.ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void DoctorDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = DoctorDataGrid.SelectedItem as Doctors;
                //проверка того, что пользователь выбрал строки для удаления
                if (item == null)
                {
                    MessageBox.Show("Вы не выбрали ни одной строки");
                    return;
                }
                else
                {
                    //выполним удаление только в том случае, если пользователь даст согласие на удаление
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        //удаляем выбранную строку
                        db.context.Doctors.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        DoctorDataGrid.ItemsSource = db.context.Doctors.ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void NurseDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = NurseDataGrid.SelectedItem as Nurses;
                //проверка того, что пользователь выбрал строки для удаления
                if (item == null)
                {
                    MessageBox.Show("Вы не выбрали ни одной строки");
                    return;
                }
                else
                {
                    //выполним удаление только в том случае, если пользователь даст согласие на удаление
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        //удаляем выбранную строку
                        db.context.Nurses.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        NurseDataGrid.ItemsSource = db.context.Nurses.ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void PatientDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = PatientDataGrid.SelectedItem as Patients;
                //проверка того, что пользователь выбрал строки для удаления
                if (item == null)
                {
                    MessageBox.Show("Вы не выбрали ни одной строки");
                    return;
                }
                else
                {
                    //выполним удаление только в том случае, если пользователь даст согласие на удаление
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        //удаляем выбранную строку
                        db.context.Patients.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        PatientDataGrid.ItemsSource = db.context.Patients.ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }
    }
}
