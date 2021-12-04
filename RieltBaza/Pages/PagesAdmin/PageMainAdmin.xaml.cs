using RieltBaza.dataFiles;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RieltBaza.Pages.PagesAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageMainAdmin.xaml
    /// </summary>
    public partial class PageMainAdmin : Page
    {
        private int intCity = 0;

        public int IntCity { get => intCity; set => intCity = value; }

        public PageMainAdmin()
        {
            InitializeComponent();
            lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.ToList();

            cmbSort.Text = "Сортировка";
            cmbFilt.Text = "Фильтрация по городу";
            tbSearch.Text = "Поиск";

            cmbSort.Items.Add("От А-Я");
            cmbSort.Items.Add("От Я-А");
            cmbSort.Items.Add("По Дате рождения ↑");
            cmbSort.Items.Add("По Дате рождения ↓");
            cmbSort.Items.Add("По Email A-Z");
            cmbSort.Items.Add("По Email Z-A");
            cmbSort.Items.Add("Показать все");

            cmbFilt.SelectedValuePath = "ID_City";
            cmbFilt.DisplayMemberPath = "Name";
            
            cmbFilt.ItemsSource = ConnectHelper.entObj.City.ToList();
              
            

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
        private void btnComment_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewComm());
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
           if(tbSearch.Text != "Поиск")
           lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.Where(x => x.SecondName.Contains(tbSearch.Text) ||
           x.FirstName.Contains(tbSearch.Text) || x.Patronymic.Contains(tbSearch.Text) || x.Email.Contains(tbSearch.Text)).ToList();
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

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSort.SelectedValue == "От А-Я") lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.OrderBy(x => x.SecondName).ToList();
            else if (cmbSort.SelectedValue == "От Я-А") lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.OrderByDescending(x => x.SecondName).ToList();

            else if (cmbSort.SelectedValue == "По Дате рождения ↑") lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.OrderBy(x => x.Date_of_Birth).ToList();
            else if (cmbSort.SelectedValue == "По Дате рождения ↓") lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.OrderByDescending(x => x.Date_of_Birth).ToList();

            else if (cmbSort.SelectedValue == "По Email A-Z") lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.OrderBy(x => x.Email).ToList();
            else if (cmbSort.SelectedValue == "По Email Z-A") lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.OrderByDescending(x => x.Email).ToList();
            else if (cmbSort.SelectedValue == "Показать все")
            {
                cmbSort.Text = "Сортировка";
                cmbFilt.Text = "Фильтрация по городу";
                lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.ToList();
            }
        
        }

        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IntCity = Convert.ToInt32(cmbFilt.SelectedValue);
            lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.Where(x => x.ID_City == intCity).ToList();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Emp_Citys emp = lbDataEmp.SelectedItem as Emp_Citys;
            if (emp == null) MessageBox.Show("Запись не выбрана!", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (MessageBox.Show("Вы точно хотите удалить запись?\n" + emp.SecondName + " " + emp.FirstName + " " + emp.Patronymic, 
                "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ConnectHelper.entObj.Emp_Citys.Remove(emp);
                ConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information); 
                lbDataEmp.ItemsSource = ConnectHelper.entObj.Emp_Citys.ToList();
            }
        }
    }
}
