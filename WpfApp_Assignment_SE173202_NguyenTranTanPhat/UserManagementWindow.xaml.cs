using BusinessObjects.Models;
using Services;
using Services.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_Assignment_SE173202_NguyenTranTanPhat
{
    /// <summary>
    /// Interaction logic for UserManagementWindow.xaml
    /// </summary>
    public partial class UserManagementWindow : Window
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private User? selectedUser;
        public UserManagementWindow()
        {
            InitializeComponent();
            userService = new UserService();
            roleService = new RoleService();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadInitData();
        }

        private void LoadInitData()
        {
            this.dtgUsers.ItemsSource = this.userService.GetUsersByRole((int)RoleName.Student);
            List<Role> roles = this.roleService.GetAllRoles();
            if (roles.Count > 0)
            {
                this.cboRole.ItemsSource = roles;
                this.cboRole.DisplayMemberPath = "RoleName";
                this.cboRole.SelectedValuePath = "RoleId";
                this.cboRole.SelectedIndex = 0;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgUsers.SelectedItem == null)
                return;

            this.selectedUser = dtgUsers.SelectedItem as User;
            if (this.selectedUser == null)
                return;

            txtUserName.Text = selectedUser.UserName;
            txtPassword.Password = selectedUser.Password;
            txtName.Text = selectedUser.Name;
            txtEmail.Text = selectedUser.Email;
            dpDateOfBirth.SelectedDate = selectedUser.DateOfBirth;
            cboRole.SelectedValue = selectedUser.RoleId;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Password) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(dpDateOfBirth.Text) || string.IsNullOrEmpty(cboRole.Text) || cboRole.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User user = new User
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Password,
                Name = txtName.Text,
                Email = txtEmail.Text,
                DateOfBirth = (DateTime)dpDateOfBirth.SelectedDate.Value,
                RoleId = (int)cboRole.SelectedValue
            };

            this.userService.AddUser(user);
            this.resetData();
            this.LoadInitData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User updateUser = this.userService.GetUserById(this.selectedUser.UserId);

            updateUser.UserName = txtUserName.Text;
            updateUser.Password = txtPassword.Password;
            updateUser.Name = txtName.Text;
            updateUser.Email = txtEmail.Text;
            updateUser.DateOfBirth = (DateTime)dpDateOfBirth.SelectedDate.Value;
            updateUser.RoleId = (int)cboRole.SelectedValue;

            this.userService.UpdateUser(updateUser);
            this.LoadInitData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận xóa", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.OK)
            {
                this.userService.DeleteUser(this.selectedUser.UserId);
                this.resetData();
                this.LoadInitData();
            }
        }

        private void resetData()
        {
            this.selectedUser = null;
            txtEmail.Text = "";
            txtName.Text = "";
            txtPassword.Password = "";
            txtUserName.Text = "";
            dpDateOfBirth.SelectedDate = null;
            cboRole.SelectedIndex = 0;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();

        }
    }
}
