using System.Collections.Generic;
using System.Windows;
using Services;
using Services.Interfaces;
using BusinessObjects.Models;
using System.Windows.Controls;

namespace WpfApp_Assignment_SE173202_NguyenTranTanPhat
{
    public partial class UserClassManagementWindow : Window
    {
        private readonly IUserClassService userClassService;
        private UserClass? selectedUserClass;

        public UserClassManagementWindow()
        {
            InitializeComponent();
            userClassService = new UserClassService();
            LoadUserClasses();
        }

        private void LoadUserClasses()
        {
            List<UserClass> userClasses = userClassService.GetAllUserClasses();
            dgUserClass.ItemsSource = userClasses;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedUserClass == null)
            {
                MessageBox.Show("Please select a user class!", "Warning Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this user class?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.userClassService.DeleteUserClass(this.selectedUserClass.UserClassId);
                LoadUserClasses();
            }
        } 

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void dgUserClass_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;

            if (dataGrid.SelectedItem == null)
                return;

            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.SelectedItem);
            if (row == null)
                return;

            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            if (RowColumn == null)
                return;

            int id = int.Parse(((TextBlock)RowColumn.Content).Text);
            UserClass userClass = this.userClassService.GetUserClassById(id);
            this.selectedUserClass = userClass;

        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            AssignUserToClassWindow assignUserToClassWindow = new AssignUserToClassWindow();
            assignUserToClassWindow.Show();
            this.Close();
        }
    }
}
