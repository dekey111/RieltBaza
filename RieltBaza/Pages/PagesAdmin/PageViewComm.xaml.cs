using RieltBaza.dataFiles;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RieltBaza.Pages.PagesAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageViewComm.xaml
    /// </summary>
    public partial class PageViewComm : Page
    {
        public PageViewComm()
        {
            InitializeComponent();
            cmbSort.Text = "Сортировка";
            cmbFilt.Text = "Фильтрация по отзыву";
            tbSearch.Text = "Поиск";

            cmbSort.Items.Add("Сотрудник от А-Я");
            cmbSort.Items.Add("Сотрудник от Я-А");
            cmbSort.Items.Add("Клиент от А-Я");
            cmbSort.Items.Add("Клиент от Я-А");
            cmbSort.Items.Add("По рейтингу ↑");
            cmbSort.Items.Add("По рейтингу ↓");
            cmbSort.Items.Add("Показать все");

            var dist = ConnectHelper.entObj.Comment.Select(x => x.Name).Distinct().ToList();
            cmbFilt.ItemsSource = dist.ToList();


            lbDataComm.ItemsSource = ConnectHelper.entObj.comm.ToList();
        }

        private void btnNedvizh_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewNedvig());
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewClient());
        }

        private void btnMeet_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewVstrch());
        }

        private void btnEmp_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageMainAdmin());
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbSearch.Text != "Поиск")
            lbDataComm.ItemsSource = ConnectHelper.entObj.comm.Where(x => x.Name.Contains(tbSearch.Text)).ToList();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFilt.Text == "Фильтрация" &&  tbSearch.Text == "Поиск")
            {
                if (cmbSort.SelectedValue == "Сотрудник от А-Я")
                    lbDataComm.ItemsSource = ConnectHelper.entObj.comm.OrderBy(x => x.emp_SN).ToList();
                else if (cmbSort.SelectedValue == "Сотрудник от Я-А")
                    lbDataComm.ItemsSource = ConnectHelper.entObj.comm.OrderByDescending(x => x.emp_SN).ToList();
                else if (cmbSort.SelectedValue == "Клиент от А-Я")
                    lbDataComm.ItemsSource = ConnectHelper.entObj.comm.OrderBy(x => x.cnt_SN).ToList();
                else if (cmbSort.SelectedValue == "Клиент от Я-А")
                    lbDataComm.ItemsSource = ConnectHelper.entObj.comm.OrderByDescending(x => x.cnt_SN).ToList();
                else if (cmbSort.SelectedValue == "По рейтингу ↑")
                    lbDataComm.ItemsSource = ConnectHelper.entObj.comm.OrderByDescending(x => x.star).ToList();
                else if (cmbSort.SelectedValue == "По рейтингу ↓")
                    lbDataComm.ItemsSource = ConnectHelper.entObj.comm.OrderBy(x => x.star).ToList();
                else if (cmbSort.SelectedValue == "Показать все")
                {
                    lbDataComm.ItemsSource = ConnectHelper.entObj.comm.ToList();
                    cmbFilt.Text = "Фильтрация по отзыву";
                    cmbSort.Text = "Сортировка";
                    lbDataComm.SelectedIndex = 0;
                }
            }    
        }

        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = cmbFilt.SelectedItem.ToString();
            lbDataComm.ItemsSource = ConnectHelper.entObj.comm.Where(x => x.Name == selected).ToList();
        }
    }
}
