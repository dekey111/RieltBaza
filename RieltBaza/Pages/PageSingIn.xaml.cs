using RieltBaza.dataFiles;
using RieltBaza.Pages.PagesAdmin;
using RieltBaza.Pages.PagesEmp;
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

namespace RieltBaza.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageSingIn.xaml
    /// </summary>
    public partial class PageSingIn : Page
    {
        public int random = new Random().Next(0, 56);
        public int count = 0;
        public string[] code = {"1","2","3","4","5","6","7","8","9","0",
                             "A","B","C","D","F","G","H","I","G","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                             "a","b","c","d","f","g","h","i","g","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                             "!","@","#","%","^","&","*","(",")","-","=","+","_",";","?","/", "'","|","[","]"
            };

        public PageSingIn()
        {
            InitializeComponent();


            while (txbCapcha.Text.Length < 10)
            {   random = new Random().Next(0, 56);
                txbCapcha.Text += code[random];
            }         

        }
        private void btnSingIn_Click(object sender, RoutedEventArgs e)
        {
            var empObj = ConnectHelper.entObj.User.FirstOrDefault(x=> x.Login == txbLogin.Text && x.Password == txbPass.Password);            
                
            var bc = new BrushConverter();
            if (txbLogin.Text.Length == 0 && txbPass.Password.Length == 0 && txbKapcha.Text.Length == 0)
            {
                MessageBox.Show("Поля не могут быть пустыми !", "Ошибка полей", MessageBoxButton.OK, MessageBoxImage.Error);
                txbLogin.Background = Brushes.IndianRed;
                txbPass.Background = Brushes.IndianRed;
                txbKapcha.Background = Brushes.IndianRed;

                txbLogin.ToolTip = "Заполните это поле!";
                txbPass.ToolTip = "Заполните это поле!";
                txbKapcha.ToolTip = "Заполните это поле!";
            }
            else if(txbLogin.Text.Length == 0)
            {
                MessageBox.Show("Поле Логин не может быть пустым!", "Ошибка полей", MessageBoxButton.OK, MessageBoxImage.Error);
                txbLogin.Background = Brushes.IndianRed;
                txbPass.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");
                txbKapcha.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");

                txbLogin.ToolTip = "Заполните это поле!";
                txbPass.ToolTip = "";
                txbKapcha.ToolTip = "";
            }
            else if (txbPass.Password.Length == 0)
            {
                MessageBox.Show("Поле Пароль не может быть пустым!", "Ошибка полей", MessageBoxButton.OK, MessageBoxImage.Error);
                txbLogin.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");
                txbPass.Background = Brushes.IndianRed;
                txbKapcha.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");

                txbLogin.ToolTip = "";
                txbPass.ToolTip = "Заполните это поле!";
                txbKapcha.ToolTip = "";
                count++;
                if (count == 3)
                {
                    txbPass.IsEnabled = false;
                    btnSingIn.IsEnabled = false;
                    MessageBox.Show("Вы ввели неправельный пароль 3 раза. \nПодождите 30 секунд ", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
                    count = 0;
                }
            }
            else if (txbKapcha.Text.Length == 0)
            {
                MessageBox.Show("Поле Капча не может быть пустым!", "Ошибка полей", MessageBoxButton.OK, MessageBoxImage.Error);
                txbLogin.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");
                txbPass.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");
                txbKapcha.Background = Brushes.IndianRed;

                txbLogin.ToolTip = "";
                txbPass.ToolTip = "";
                txbKapcha.ToolTip = "Заполните это поле!";
            }
            else if(txbCapcha.Text != txbKapcha.Text)
            {
                MessageBox.Show("Капча введена не правильно!", "Ошибка капчи", MessageBoxButton.OK, MessageBoxImage.Error);
                txbLogin.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");
                txbPass.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");
                txbKapcha.Background = Brushes.IndianRed;

                txbLogin.ToolTip = "";
                txbPass.ToolTip = "";
                txbKapcha.ToolTip = "Капча не совпадает!";
            }
            else
            {
                if (empObj == null) MessageBox.Show("Такого пользователя несуществует!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                else  {
                    switch (empObj.id_Role)
                    {
                        case 1:
                            MessageBox.Show("Авторизация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            FrameApp.frmObj.Navigate(new PageMainAdmin());
                            break;
                        case 2:
                            MessageBox.Show("Авторизация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            FrameApp.frmObj.Navigate(new PageMainEmp());
                            break;
                    }

                   
                    txbLogin.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");
                    txbPass.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");
                    txbKapcha.Background = (Brush)bc.ConvertFrom("#FFD8B5EA");

                    txbLogin.ToolTip = "";
                    txbPass.ToolTip = "";
                    txbKapcha.ToolTip = "";
                }
            }

        }

        private void txbKapcha_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txbCapcha.Text.Length == 0)
                 txbCapcha.Text = "Введите капчу";
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            for(int i = 0; i < 11; i++)
            {
                random = new Random().Next(0, 56);
                txbCapcha.Text += code[random];
                txbKapcha.Text += code[random];
            }
        }

        private void txbLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txbLogin.Text == "Введите Логин")
                txbLogin.Text = null;
        }

        private void txbLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            if (txbLogin.Text.Length == 0)
                txbLogin.Text = "Введите Логин";
        }

        private void txbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (txbLogin.Text == "Введите Логин")
                txbLogin.Text = null;
        }

        private void txbKapcha_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txbKapcha.Text == "Введите капчу")
                txbKapcha.Text = null;
        }

        private void txbKapcha_MouseLeave(object sender, MouseEventArgs e)
        {
            if (txbKapcha.Text.Length == 0)
                txbKapcha.Text = "Введите капчу";
        }

        private void txbKapcha_KeyDown(object sender, KeyEventArgs e)
        {
            if (txbKapcha.Text == "Введите капчу")
                txbKapcha.Text = null;
        }
    }
}
