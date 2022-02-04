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
        string currentLetter = "";
        public PageTableClient()
        {
            InitializeComponent();
            ShowLetters();
            context = new Zadanie3Entities();       
            ShowTable();
        }
        /// <summary>
        /// Вывод таблицы на страницу и применение поиска и фильтрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowTable()
        {
            if (TxtEmail.Text == null && TxtPhone.Text == null)
                return;
            List<Client> listClient = context.Clients.ToList();
            listClient = listClient.Where(x => x.Email.ToLower().Contains(TxtEmail.Text.ToLower())).ToList();
            listClient = listClient.Where(x => x.Phone.ToLower().Contains(TxtPhone.Text.ToLower())).ToList();
            if (currentLetter.Count() == 1)
            {
                listClient = listClient.Where(x => x.FirstName.Contains(currentLetter)).ToList();
            }
            DataClient.ItemsSource = listClient.OrderBy(x => x.FirstName).ToList();
        }

        /// <summary>
        /// Добавляет на Страницу TextBlock от а до я 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowLetters()
        {
            for (char i = 'А'; i <= 'Я'; i++)
            {
                TextBlock letter = new TextBlock
                {
                    Text = i.ToString(),
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                letter.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;
                StackLetters.Children.Add(letter);
            }
        }

        /// <summary>
        /// Выбранный символ становиться цвета Gold
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var label = (TextBlock)sender;
            currentLetter = label.Text;
            foreach (TextBlock letter in StackLetters.Children)
            {
                letter.Foreground = Brushes.White;
            }
            label.Foreground = Brushes.Gold;
            ShowTable();
        }

        /// <summary>
        /// По нажатию на кнопку Удалить удаляет выбраную строку 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// По нажатию на кнопку Добавить переходит на форму создания клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFraim.Navigate(new PageAddClient(new Client()));
        }

        /// <summary>
        /// По нажатию на изменение в таблице переходит на форму редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFraim.Navigate(new PageAddClient((sender as Button).DataContext as Client));
        }

        /// <summary>
        /// Обновляет страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Zadanie3Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataClient.ItemsSource = Zadanie3Entities.GetContext().Clients.ToList();
            }
        }

        /// <summary>
        /// Поиск по Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        /// <summary>
        /// Поиск по Телефону
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }
    }
}
