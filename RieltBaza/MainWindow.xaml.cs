using RieltBaza.dataFiles;
using RieltBaza.Pages;
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

namespace RieltBaza
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectHelper.entObj = new RieltorEntities();
            FrameApp.frmObj = FrmMain;
            FrameApp.frmObj.Navigate(new PageSingIn());

        }
    }
}
