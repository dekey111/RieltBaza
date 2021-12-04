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
    /// Логика взаимодействия для PageViewComm.xaml
    /// </summary>
    public partial class PageViewComm : Page
    {
        public PageViewComm()
        {
            InitializeComponent();
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
    }
}
