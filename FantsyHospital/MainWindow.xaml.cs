﻿using FantsyHospital.View.Pages;
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

namespace FantsyHospital
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.NavigationService.Navigate(new AuthorizationPage());


            // время
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { PresentTime.Content = DateTime.Now.ToString("HH:mm:ss"); };
            timer.Start();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainFrame.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Вы больше не можете вернуться назад!",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
