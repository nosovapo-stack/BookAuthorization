using System.Windows;
using BookAuthorization.Models;

namespace BookAuthorization
{
    public partial class RoleWindow : Window
    {
        public RoleWindow(User user)
        {
            InitializeComponent();

            WelcomeTextBlock.Text = user.FullName;
            RoleTextBlock.Text = $"Ваша роль: {user.Role?.Name}";

            switch (user.Role?.Name)
            {
                case "Администратор":
                    PanelTextBlock.Text =
                        "Вам доступна панель администратора.";
                    break;

                case "Менеджер":
                    PanelTextBlock.Text =
                        "Вам доступна панель менеджера.";
                    break;

                case "Авторизированный клиент":
                    PanelTextBlock.Text =
                        "Вам доступна панель клиента.";
                    break;

                default:
                    PanelTextBlock.Text =
                        "Роль пользователя не определена.";
                    break;
            }
        }
    }
}