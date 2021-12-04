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

namespace RieltBaza.Pages.PagesEmp
{
    /// <summary>
    /// Логика взаимодействия для PageMainEmp.xaml
    /// </summary>
    public partial class PageMainEmp : Page
    {
        public static bool buttonsEmp = true;
        public PageMainEmp()
        {
            InitializeComponent();
            buttonsEmp = true;
        }
        public static bool GetButtont()
        {
            return buttonsEmp;
        }
    }
}
