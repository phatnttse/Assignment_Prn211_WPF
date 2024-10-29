using System.Windows;


namespace WpfApp_Assignment_SE173202_NguyenTranTanPhat
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void BtnUserManagement_Click(object sender, RoutedEventArgs e)
        {
            // Mở cửa sổ quản lý người dùng
            UserManagementWindow userManagementWindow = new UserManagementWindow();
            userManagementWindow.Show();
            this.Close(); // Đóng cửa sổ Menu
        }

        private void BtnClassManagement_Click(object sender, RoutedEventArgs e)
        {
            // Mở cửa sổ quản lý lớp học
            ClassManagementWindow classManagementWindow = new ClassManagementWindow();
            classManagementWindow.Show();
            this.Close(); // Đóng cửa sổ Menu
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            // Đóng ứng dụng
            Application.Current.Shutdown();
        }

        private void btnAssignStudentToClass_Click(object sender, RoutedEventArgs e)
        {
            UserClassManagementWindow userClassManagementWindow = new UserClassManagementWindow();
            userClassManagementWindow.Show();
            this.Close();
        }
    }
}
