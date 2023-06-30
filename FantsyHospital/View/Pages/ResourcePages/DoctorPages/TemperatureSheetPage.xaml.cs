using FantsyHospital.Model;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Diagnostics;
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

namespace FantsyHospital.View.Pages.ResourcePages.DoctorPages
{
    /// <summary>
    /// Логика взаимодействия для TemperatureSheetPage.xaml
    /// </summary>
    public partial class TemperatureSheetPage : System.Windows.Controls.Page
    {
        Core db = new Core();
        public TemperatureSheetPage()
        {
            InitializeComponent();
            FormDataGrid.ItemsSource = db.context.Forms.ToList();
        }

        private void Form004Button_Click(object sender, RoutedEventArgs e)
        {



        }

        private void OnSearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var form = new ObservableCollection<Forms>(db.context.Forms.ToList());
                FormDataGrid.ItemsSource = form;
            }
            else
            {
                var result = db.context.Forms.Where(p => p.IdForm.ToString().Contains(searchText)
                    || p.Patients.Name.ToString().Contains(searchText)
                    || p.NameForm.ToString().Contains(searchText)
                    || p.Pulse.ToString().Contains(searchText)
                    || p.BloodPressure.ToString().Contains(searchText)
                    || p.Temperature.ToString().Contains(searchText)
                    || p.Breath.ToString().Contains(searchText)
                    || p.Weight.ToString().Contains(searchText)
                    || p.LiquidConsumed.ToString().Contains(searchText)
                    || p.DailyAmountOfUrine.ToString().Contains(searchText)
                    || p.Chair.ToString().Contains(searchText)
                    || p.Bath.ToString().Contains(searchText)).ToList();

                var form = new ObservableCollection<Forms>(result);
                FormDataGrid.ItemsSource = form;
            }
        }

        private void FormDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = FormDataGrid.SelectedItem as Forms;
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
                        db.context.Forms.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        FormDataGrid.ItemsSource = db.context.Forms.ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void Form004PatientButton_Click(object sender, RoutedEventArgs e)
        {
            var item = FormDataGrid.SelectedItem as Forms;
            Word.Application application = new Word.Application();
            Word.Document document = application.Documents.Add();

            Word.Paragraph titleParagraph = document.Paragraphs.Add();
            Word.Range titleRange = titleParagraph.Range;
            titleRange.Text = "Температурный лист";
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.Bold = 1;
            titleRange.InsertParagraphAfter();

            Word.Paragraph titleParag = document.Paragraphs.Add();
            Word.Range title = titleParag.Range;
            title.Text = $"Карта №: {item.NameForm}\t\t\tФИО: {item.Patients.Name} {item.Patients.Surname} {item.Patients.Patronymic}\t\t\tПалата №: 1";
            title.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            title.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table titleTable = document.Tables.Add(tableRange, 11, 16);
            titleTable.Borders.InsideLineStyle = titleTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            titleTable.Columns[1].PreferredWidth = 100;
            tableRange.Font.Size = 9;
            for (int i = 2; i < 17; i++)
            {
                titleTable.Columns[i].PreferredWidth = 25;
            }

            for (int i = 2; i < 16; i++)
            {
                titleTable.Cell(2, i).Range.Font.Size = 9;
            }


            titleTable.Cell(2, 2).Range.Text = "1";
            titleTable.Cell(2, 3).Range.Text = "2";
            titleTable.Cell(2, 4).Range.Text = "3";
            titleTable.Cell(2, 5).Range.Text = "4";
            titleTable.Cell(2, 6).Range.Text = "5";
            titleTable.Cell(2, 7).Range.Text = "6";
            titleTable.Cell(2, 8).Range.Text = "7";
            titleTable.Cell(2, 9).Range.Text = "8";
            titleTable.Cell(2, 10).Range.Text = "9";
            titleTable.Cell(2, 11).Range.Text = "10";
            titleTable.Cell(2, 12).Range.Text = "11";
            titleTable.Cell(2, 13).Range.Text = "12";
            titleTable.Cell(2, 14).Range.Text = "13";
            titleTable.Cell(2, 15).Range.Text = "14";
            titleTable.Cell(2, 16).Range.Text = "15";

            for (int i = 1; i < 11; i++)
            {
                titleTable.Cell(i, 1).Range.Font.Size = 9;
            }

            titleTable.Cell(1, 1).Range.Text = "Дата";
            titleTable.Cell(2, 1).Range.Text = "День\nпребывания\nв стационаре";
            titleTable.Cell(3, 1).Range.Text = "Пульс";
            titleTable.Cell(4, 1).Range.Text = "Артериальное\nдавление";
            titleTable.Cell(5, 1).Range.Text = "Температура";
            titleTable.Cell(6, 1).Range.Text = "Дыхание";
            titleTable.Cell(7, 1).Range.Text = "Вес";
            titleTable.Cell(8, 1).Range.Text = "Выпито\nжидкости";
            titleTable.Cell(9, 1).Range.Text = "Суточное\nколичество\nмочи";
            titleTable.Cell(10, 1).Range.Text = "Стул";
            titleTable.Cell(11, 1).Range.Text = "Ванна";

            for (int i = 3; i < 11; i++)
            {
                titleTable.Cell(i, 2).Range.Font.Size = 9;
            }

            titleTable.Cell(3, 2).Range.Text = $"{item.Pulse}";
            titleTable.Cell(4, 2).Range.Text = $"{item.BloodPressure}";
            titleTable.Cell(5, 2).Range.Text = $"{item.Temperature}";
            titleTable.Cell(6, 2).Range.Text = $"{item.Breath}";
            titleTable.Cell(7, 2).Range.Text = $"{item.Weight}";
            titleTable.Cell(8, 2).Range.Text = $"{item.LiquidConsumed}";
            titleTable.Cell(9, 2).Range.Text = $"{item.DailyAmountOfUrine}";
            titleTable.Cell(10, 2).Range.Text = $"{item.Chair}";
            titleTable.Cell(11, 2).Range.Text = $"{item.Bath}";


            application.Visible = true;

        }
    }
}
