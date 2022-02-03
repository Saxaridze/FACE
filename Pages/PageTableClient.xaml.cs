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
    /// Логика взаимодействия для PageTableClient.xaml
    /// </summary>
    public partial class PageTableClient : Page
    {
        Zadanie3Entities context;
        public PageTableClient()
        {
            context = new Zadanie3Entities();
            InitializeComponent();
            ShowTable();

        }
        public void ShowTable()
        {
            DataClient.ItemsSource = context.Clients.ToList();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
        private void BtnDeleteClientS_Click(object sender, RoutedEventArgs e)
        {
            var f1 = DataClient.SelectedItems.Cast<Client>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {f1.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Zadanie3Entities.GetContext().Clients.RemoveRange(f1);
                    Zadanie3Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DataClient.ItemsSource = Zadanie3Entities.GetContext().Clients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFraim.Navigate(new PageAddClient(null));
        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFraim.Navigate(new PageAddClient((sender as Button).DataContext as Client));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Zadanie3Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataClient.ItemsSource = Zadanie3Entities.GetContext().Clients.ToList();
            }
        }
    }
}
