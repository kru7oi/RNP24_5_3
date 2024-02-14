using RNP24_5_3.AppData;
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

namespace RNP24_5_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> userList = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            userList = CSVHelper.Read().ToList();

            foreach (User user in userList)
            {
                UsersLv.Items.Add(user);
            }
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditUserWindow addEditUserWindow = new AddEditUserWindow(UsersLv);

            if (addEditUserWindow.ShowDialog() == true)
            {
                CSVHelper.Update(UsersLv);
            }
        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsersLv.SelectedItem != null)
            {
                AddEditUserWindow addEditUserWindow = new AddEditUserWindow(UsersLv.SelectedItem as User);

                if (addEditUserWindow.ShowDialog() == true)
                {
                    CSVHelper.Update(UsersLv);
                }
            }
            else
            {
                MessageBox.Show("Для изменения выберите пользователя из списка", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteUserBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены что хотите удалить пользователя?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                MessageBox.Show("Пользователь успешно удалён!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                UsersLv.Items.Remove(UsersLv.SelectedItem);

                CSVHelper.Update(UsersLv);
            }
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();

            Close();
        }
    }
}
