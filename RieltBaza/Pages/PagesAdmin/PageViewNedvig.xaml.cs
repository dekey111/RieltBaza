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
    /// Логика взаимодействия для PageViewNedvig.xaml
    /// </summary>
    public partial class PageViewNedvig : Page
    {
        public PageViewNedvig()
        {
            InitializeComponent();
            lbObjectData.ItemsSource = ConnectHelper.entObj.Objects.ToList();
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

        private void btnComment_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageViewComm());
        }
    }
}
