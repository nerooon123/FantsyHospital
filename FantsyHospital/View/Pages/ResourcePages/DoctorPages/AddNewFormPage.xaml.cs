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
    /// Логика взаимодействия для AddNewFormPage.xaml
    /// </summary>
    public partial class AddNewFormPage : Page
    {
        Core db = new Core();
        public AddNewFormPage()
        {
            InitializeComponent();


            NamePatientComboBox.ItemsSource = db.context.Patients.ToList();
            NamePatientComboBox.DisplayMemberPath = "Name";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Forms newForm = new Forms()
                {
                    Patient = 1 + NamePatientComboBox.SelectedIndex,
                    Day = Convert.ToInt32(DayTextBox.Text),
                    NameForm = NumberTextBox.Text,
                    Pulse = PulseTextBox.Text,
                    BloodPressure = BloodPressureTextBox.Text,
                    Temperature = TemperatureTextBox.Text,
                    Breath = BreathTextBox.Text,
                    Weight = WeightTextBox.Text,
                    LiquidConsumed = LiquidConsumedTextBox.Text,
                    DailyAmountOfUrine = DailyAmountOfUrineTextBox.Text,
                    Chair = ChairTextBox.Text,
                    Bath = BathTextBox.Text

                };
                db.context.Forms.Add(newForm);
                db.context.SaveChanges();

                MessageBox.Show("Добавление выполнено успешно !",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

                this.NavigationService.Navigate(new TemperatureSheetPage());
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
