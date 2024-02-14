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
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Authorization();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Функция производит авторизацию в систему.
        /// </summary>
        /// <param name="login">Поле для ввода логина</param>
        /// <param name="password">Поле для ввода пароля</param>
        private void Authorization()
        {
            IEnumerable<User> userList = CSVHelper.Read();

            User currentUser = userList.FirstOrDefault(u => u.Login == LoginTb.Text && u.Password == PasswordPb.Password);

            if (currentUser != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                RememberUserData();

                Close();
            }
            else
            {
                MessageBox.Show("Пользователя с такими данными не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                LoginTb.Clear();
                PasswordPb.Clear();
            }
        }

        /// <summary>
        /// Функция производит запись данных пользователя в память приложения при нажатии на галочку "Запомнить меня".
        /// </summary>
        private void RememberUserData()
        {
            if (RememberMeCb.IsChecked == true)
            {
                Properties.Settings.Default.LoginValue = LoginTb.Text;
                Properties.Settings.Default.PasswordValue = PasswordPb.Password;
            }
            else
            {
                Properties.Settings.Default.LoginValue = string.Empty;
                Properties.Settings.Default.PasswordValue = string.Empty;
            }

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Функция производит загрузку данных пользователя из памяти приложения в поля для ввода.
        /// </summary>
        private void LoadUserData()
        {
            if (Properties.Settings.Default.LoginValue != string.Empty)
            {
                LoginTb.Text = Properties.Settings.Default.LoginValue;
                PasswordPb.Password = Properties.Settings.Default.PasswordValue;
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
