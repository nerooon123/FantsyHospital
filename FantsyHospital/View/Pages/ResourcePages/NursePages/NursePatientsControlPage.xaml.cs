using FantsyHospital.Model;
using FantsyHospital.View.Pages.ResourcePages.DoctorPages;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Word = Microsoft.Office.Interop.Word;

namespace FantsyHospital.View.Pages.ResourcePages.NursePages
{
    /// <summary>
    /// Логика взаимодействия для NursePatientsControlPage.xaml
    /// </summary>
    public partial class NursePatientsControlPage : System.Windows.Controls.Page
    {
        Core db = new Core();
        public NursePatientsControlPage()
        {
            InitializeComponent();
            PatientDataGrid.ItemsSource = db.context.Patients.ToList();
        }

        private void OnSearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower().Trim();

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

        private void excel_Click(object sender, RoutedEventArgs e)
        {
            using (var excelPackage = new ExcelPackage())
            {
                var data = db.context.Patients.ToList();
                var worksheet = excelPackage.Workbook.Worksheets.Add("Название листа");

                // добавляем заголовки таблицы
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Имя";
                worksheet.Cells[1, 3].Value = "Фамилия";
                worksheet.Cells[1, 4].Value = "Отчество";
                worksheet.Cells[1, 5].Value = "Дата рождения";
                worksheet.Cells[1, 6].Value = "Пол";
                worksheet.Cells[1, 7].Value = "Жилой Адрес";
                worksheet.Cells[1, 8].Value = "Номер Телефона";
                worksheet.Cells[1, 9].Value = "Дата записи";
                worksheet.Cells[1, 10].Value = "Дата выписки";
                worksheet.Cells[1, 11].Value = "МКБ";
                worksheet.Cells[1, 12].Value = "Статус";
                // ...

                // заполняем таблицу данными
                int row = 2;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.IdPatient;
                    worksheet.Cells[row, 2].Value = item.Name;
                    worksheet.Cells[row, 3].Value = item.Surname;
                    worksheet.Cells[row, 4].Value = item.Patronymic;
                    worksheet.Cells[row, 5].Value = item.DateOfBirth.ToString();
                    worksheet.Cells[row, 6].Value = item.Genders.Gender.ToString();
                    worksheet.Cells[row, 7].Value = item.Addres;
                    worksheet.Cells[row, 8].Value = item.PhoneNumber;
                    worksheet.Cells[row, 9].Value = item.DateOfReceipt.ToString();
                    worksheet.Cells[row, 10].Value = item.DateOfDischarge.ToString();
                    worksheet.Cells[row, 11].Value = item.ICOD;
                    worksheet.Cells[row, 12].Value = item.Status;
                    // ...

                    row++;
                }

                // сохраняем файл на диск

                // Сохраняем документ Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (saveFileDialog.ShowDialog() == true)
                {
                    // Сохраняем документ Excel в выбранное место
                    File.WriteAllBytes(saveFileDialog.FileName, excelPackage.GetAsByteArray());
                }

                // Очищаем пакет Excel
                excelPackage.Dispose();
            }
        }

        private void AddNewPatient_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddPatientPage());
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

        private void PatientEditButton_Click(object sender, RoutedEventArgs e)
        {
            var item = PatientDataGrid.SelectedItem as Patients;
            this.NavigationService.Navigate(new EditPatientPage(item));
        }

        private void Forma003Button_Click(object sender, RoutedEventArgs e)
        {
            Word.Application application = new Word.Application();
            Word.Document document = application.Documents.Open($"{AppDomain.CurrentDomain.BaseDirectory}\\forma003u.doc");
            application.Visible = true;
        }
    }
}
