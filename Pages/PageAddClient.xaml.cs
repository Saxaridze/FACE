using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для PageAddClient.xaml
    /// </summary>
    public partial class PageAddClient : Page
    {
        private Client currentClient = new Client();
        bool isEdited = false;
        private Client Client { get; set; }

        /// <summary>
        /// Конструктор страницы
        /// </summary>
        /// <param name="client"></param>
        public PageAddClient(Client client)
        {
            InitializeComponent();
            Client = client;
            if (client != null)
            {
                currentClient = client;
                isEdited = true;
            }
            DataContext = currentClient;
            CmbGender.ItemsSource = Zadanie3Entities.GetContext().Genders.ToList();
        }

        /// <summary>
        /// Сохраняет продукцию по клику на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //сообщения об вводимых значениях
            if (string.IsNullOrWhiteSpace(currentClient.FirstName))
                errors.AppendLine("Укажите Фамилию");
            if (string.IsNullOrWhiteSpace(currentClient.LastName))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(currentClient.Patronymic))
                errors.AppendLine("Укажите Отчество");
            if (currentClient.RegistrationDate == null)
                errors.AppendLine("Укажите дату регистрации");
            if (string.IsNullOrWhiteSpace(currentClient.Phone))
                errors.AppendLine("Укажите телефон");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (!isEdited)
            {
                //добавление данных в БД таблицу Client
                currentClient.ID = Zadanie3Entities.GetContext().Clients.ToArray()[Zadanie3Entities.GetContext().Clients.ToArray().Length - 1].ID + 1;
                Zadanie3Entities.GetContext().Clients.Add(currentClient);
            }
            try
            {
                //сообщение об добавленных данных
                Zadanie3Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFraim.GoBack();
            }
            catch (DbUpdateException dbu)
            {
                //сообщение об ошибке
                MessageBox.Show("Ошибка метода SaveChanges\n" + dbu.Message.ToString());
                var exception = HandleDbUpdateException(dbu);
                throw exception;
            }
            
        }
        /// <summary>
        /// Cообщение об ошибках при загрузке данных
        /// </summary>
        /// <param name="dbu"></param>
        private Exception HandleDbUpdateException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            string message = builder.ToString();
            return new Exception(message, dbu);
        }

        /// <summary>
        /// По клику на кнопку показывает окно выбора изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            var window = new ImagesWindow();
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                Client.PhotoPath = window.ImgUri;
                DataContext = null;
                DataContext = Client;
            }
        }

        private void tbImage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}