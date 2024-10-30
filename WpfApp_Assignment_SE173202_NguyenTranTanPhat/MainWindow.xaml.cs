using BusinessObjects.Models;
using Services;
using Services.Interfaces;
using System.Windows;



namespace WpfApp_Assignment_SE173202_NguyenTranTanPhat
{
    public partial class MainWindow : Window
    {
        private readonly IUserService userService;
        public MainWindow()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User account = userService.GetUserByUserName(username);

            if (account == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (account != null && !account.Password.Equals(password))
            {
                MessageBox.Show("Mật khẩu không đúng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

            if (account != null && account.Password.Equals(password))
            {
                if (account.Role.RoleId == 1)
                {
                    LoggedInUser.Name = account.Name;
                    LoggedInUser.UserId = account.UserId;
                    MenuWindow menuWindow = new MenuWindow();
                    menuWindow.Show();
                    this.Close();
                }       
            }
        }
    }
}
