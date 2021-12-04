using RieltBaza.dataFiles;
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

namespace RieltBaza.Pages.PagesAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageViewClient.xaml
    /// </summary>
    public partial class PageViewClient : Page
    {
        public PageViewClient()
        {
            InitializeComponent();
            lbDataClient.ItemsSource = ConnectHelper.entObj.Client.ToList();

            cmbSort.Text = "Сортировка";
            cmbFilt.Text = "Фильтрация по городу";
            tbSearch.Text = "Поиск";

            cmbSort.Items.Add("От А-Я");
            cmbSort.Items.Add("От Я-А");
            cmbSort.Items.Add("По Дате рождения ↑");
            cmbSort.Items.Add("По Дате рождения ↓");
            cmbSort.Items.Add("По Email A-Z");
            cmbSort.Items.Add("По Email Z-A");
            cmbSort.Items.Add("Показать всё");

            cmbFilt.SelectedValuePath = "ID_Adress";
            cmbFilt.DisplayMemberPath = "Name";
            cmbFilt.ItemsSource = ConnectHelper.entObj.Client_City.ToList();
        }

        private void btnNedvizh_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewNedvig());
        }

        private void btnMeet_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewVstrch());
        }

        private void btnEmp_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageMainAdmin());
        }

        private void btnComment_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewComm());
        }
        private void tbSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            if (tbSearch.Text == "Поиск")
                tbSearch.Text = null;
        }

        private void tbSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            if (tbSearch.Text.Length == 0)
                tbSearch.Text = "Поиск";
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbSearch.Text == "Поиск")
                tbSearch.Text = null;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSearch.Text != "Поиск")
                lbDataClient.ItemsSource = ConnectHelper.entObj.Client.Where(x => x.SecondName.Contains(tbSearch.Text) ||
                x.FirstName.Contains(tbSearch.Text) || x.Patronymic.Contains(tbSearch.Text) || x.Email.Contains(tbSearch.Text)).ToList();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSort.SelectedValue == "От А-Я") lbDataClient.ItemsSource = ConnectHelper.entObj.Client.OrderBy(x => x.SecondName).ToList();
            else if (cmbSort.SelectedValue == "От Я-А") lbDataClient.ItemsSource = ConnectHelper.entObj.Client.OrderByDescending(x => x.SecondName).ToList();
            else if (cmbSort.SelectedValue == "По Дате рождения ↑") lbDataClient.ItemsSource = ConnectHelper.entObj.Client.OrderBy(x => x.Date_of_Birth).ToList();
            else if (cmbSort.SelectedValue == "По Дате рождения ↓") lbDataClient.ItemsSource = ConnectHelper.entObj.Client.OrderByDescending(x => x.Date_of_Birth).ToList();
            else if (cmbSort.SelectedValue == "По Email A-Z") lbDataClient.ItemsSource = ConnectHelper.entObj.Client.OrderBy(x => x.Email).ToList();
            else if (cmbSort.SelectedValue == "По Email Z-A") lbDataClient.ItemsSource = ConnectHelper.entObj.Client.OrderByDescending(x => x.Email).ToList();
            else if (cmbSort.SelectedValue == "Показать всё")
            {
                cmbSort.Text = "Сортировка";
                cmbFilt.Text = "Фильтрация по городу";
                lbDataClient.ItemsSource = ConnectHelper.entObj.Client.ToList();
            }
        }

        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedcmb = Convert.ToInt32(cmbFilt.SelectedValue);
            lbDataClient.ItemsSource = ConnectHelper.entObj.Client.Where(x => x.id_Adress == selectedcmb).ToList();
        }
    }
}

