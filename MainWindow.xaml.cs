using System.Linq;
using System.Windows;
using BookAuthorization.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password))
            {
                ErrorTextBlock.Text = "Введите логин и пароль.";
                return;
            }

            using (var db = new BookDbContext())
            {
                var user = db.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(u =>
                        u.Login == login &&
                        u.Password == password);

                if (user == null)
                {
                    ErrorTextBlock.Text = "Неверный логин или пароль.";
                    return;
                }

                var roleWindow = new RoleWindow(user);
                roleWindow.Show();

                Close();
            }
        }
    }
}