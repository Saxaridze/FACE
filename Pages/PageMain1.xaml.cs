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

namespace FACE.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain1 : Page
    {
        public PageMain1()
        {
            InitializeComponent();
            Zadanie3Entities context = new Zadanie3Entities();
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная функция находится в разработке");
        }

        private void BtnVisior_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная функция находится в разработке");
        }
    }
}
