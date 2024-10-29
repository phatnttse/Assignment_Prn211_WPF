using System.Collections.Generic;
using System.Windows;
using Services;
using Services.Interfaces;
using BusinessObjects.Models;

namespace WpfApp_Assignment_SE173202_NguyenTranTanPhat
{
    public partial class AssignUserToClassWindow : Window
    {
        private readonly IClassService classService;
        private readonly IUserService userService;
        private readonly IUserClassService userClassService;

        public AssignUserToClassWindow()
        {
            InitializeComponent();
            classService = new ClassService();
            userService = new UserService();
            userClassService = new UserClassService();

            LoadClasses();
            LoadStudents();
        }

        private void LoadClasses()
        {
            // Lấy danh sách các lớp từ service và gán vào ComboBox
            cbClasses.ItemsSource = classService.GetAllClasses();
        }

        private void LoadStudents()
        {
            lbStudents.ItemsSource = userService.GetUsersByRole((int)RoleName.Student);
        }

        private void cbClasses_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            if (cbClasses.SelectedItem == null)
            {
                MessageBox.Show("Please select a class!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Class selectedClass = cbClasses.SelectedItem as Class;

            // Lấy danh sách các học sinh được chọn
            List<User> selectedStudents = new List<User>();
            foreach (User student in lbStudents.SelectedItems)
            {
                selectedStudents.Add(student);
            }

            if (selectedStudents.Count == 0)
            {
                MessageBox.Show("Please select at least one student to assign!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Thực hiện gán học sinh vào lớp
            foreach (User student in selectedStudents)
            {
                if (userClassService.GetUserClassByUserIdAndClassId(student.UserId, selectedClass.ClassId) != null)
                {
                    MessageBox.Show($"The student {student.Name} has already been assigned to the class!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                UserClass userClass = new UserClass
                {
                    UserId = student.UserId,
                    ClassId = selectedClass.ClassId
                };

               this.userClassService.AddUserClass(userClass);
            }

            MessageBox.Show("Students have been successfully assigned to the class!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            UserClassManagementWindow userClassManagementWindow = new UserClassManagementWindow();
            userClassManagementWindow.Show();
            this.Close();
        }
    }
}
