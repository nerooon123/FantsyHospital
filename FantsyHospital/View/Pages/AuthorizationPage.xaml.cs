﻿using FantsyHospital.Model;
using FantsyHospital.View.Pages.MainWindowPages;
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

namespace FantsyHospital.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        Core db = new Core();
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text.Length > 0) // проверяем введён ли логин     
            {
                if (PasswordTextBox.Password.Length > 0) // проверяем введён ли пароль         
                {
                    try
                    {
                        //считаем количество записей в таблице с заданными параметрами (логин, пароль)
                        var authUser = db.context.Users.Where(
                        x => x.Login == LoginTextBox.Text && x.Password == PasswordTextBox.Password
                        ).FirstOrDefault();

                        if (authUser == null)
                        {
                            MessageBox.Show("Такой пользователь отсутствует!",
                            "Уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

                        }
                        else
                        {
                            var userDoctor = db.context.Doctors.Where(
                            x => x.Login == authUser.Login
                            ).FirstOrDefault();

                            var userAdmin = db.context.Administrations.Where(
                            x => x.Login == authUser.Login
                            ).FirstOrDefault();

                            var userPatient = db.context.Patients.Where(
                            x => x.Login == authUser.Login
                            ).FirstOrDefault();

                            var userNurse = db.context.Nurses.Where(
                            x => x.Login == authUser.Login
                            ).FirstOrDefault();

                            if (userDoctor != null)
                            {
                                this.NavigationService.Navigate(new MainWindowDoctor(userDoctor));
                            }
                            if (userAdmin != null)
                            {
                                this.NavigationService.Navigate(new MainWindowAdministration(userAdmin));
                            }
                            if (userPatient != null)
                            {
                                this.NavigationService.Navigate(new MainWindowPatient(userPatient));
                            }
                            if (userNurse != null)
                            {
                                this.NavigationService.Navigate(new MainWindowNurse(userNurse));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Критический сбор в работе приложения:" + ex.Message.ToString(),
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    }
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку    
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPage());
        }
    }
}
