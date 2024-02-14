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
using System.Windows.Shapes;

namespace RNP24_5_3
{
    /// <summary>
    /// Interaction logic for AddEditUserWindow.xaml
    /// </summary>
    public partial class AddEditUserWindow : Window
    {
        ListView listToAdd = new ListView();
        public AddEditUserWindow(ListView listToAdd)
        {
            InitializeComponent();

            this.listToAdd = listToAdd;

            AddUserBtn.Visibility = Visibility.Visible;
            EditUserBtn.Visibility = Visibility.Collapsed;
        }

        public AddEditUserWindow(User currentUser)
        {
            InitializeComponent();

            DataContext = currentUser;

            AddUserBtn.Visibility = Visibility.Collapsed;
            EditUserBtn.Visibility = Visibility.Visible;
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User()
            {
                Name = NameTb.Text,
                Login = LoginTb.Text,
                Password = PasswordTb.Text,
            };

            listToAdd.Items.Add(newUser);

            MessageBox.Show("Пользователь успешно добавлен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данные пользователя успешно изменены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }
    }
}
