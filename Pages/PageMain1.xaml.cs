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
        private void BtnVisior_Click(object sender, RoutedEventArgs e)
        {
            string Email = "1";
            string Password = "1";
            if (TxtLogin.Text == Email && TxtPassword.Text == Password)
                MessageBox.Show("Добро пожаловать, Администратор");
            else
                MessageBox.Show("Не получилось аутентифицировать пользователя. Введены некорректные e-mail или пароль");
        }

        private void BtnEntry_Click(object sender, RoutedEventArgs e)
        {   
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
