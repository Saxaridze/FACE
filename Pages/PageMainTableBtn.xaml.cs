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
using FACE.Tables;

namespace FACE.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMainTableBtn.xaml
    /// </summary>
    public partial class PageMainTableBtn : Page
    {
        public PageMainTableBtn()
        {
            InitializeComponent();
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClientService_Click(object sender, RoutedEventArgs e)
        {
            var f1 = new TableClientService();
            f1.ShowDialog();
        }

        private void BtnGender_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
