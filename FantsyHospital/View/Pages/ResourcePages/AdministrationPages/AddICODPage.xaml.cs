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

namespace FantsyHospital.View.Pages.ResourcePages.AdministrationPages
{
    /// <summary>
    /// Логика взаимодействия для AddICODPage.xaml
    /// </summary>
    public partial class AddICODPage : Page
    {
        Core db = new Core();
        public AddICODPage()
        {
            InitializeComponent();
            ICODDataGrid.ItemsSource = db.context.ICOD.ToList();
        }


        private void ICODDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = ICODDataGrid.SelectedItem as ICOD;
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
                        db.context.ICOD.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        ICODDataGrid.ItemsSource = db.context.ICOD.ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ICOD newICOD = new ICOD()
                {
                    NameICOD = NameICODTextBox.Text,
                    DescriptionICOD = DescriptionICODTextBox.Text,
                };

                db.context.ICOD.Add(newICOD);
                db.context.SaveChanges();

                MessageBox.Show("Добавление выполнено успешно !",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                //обновление DataGrid
                ICODDataGrid.ItemsSource = db.context.ICOD.ToList();
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
