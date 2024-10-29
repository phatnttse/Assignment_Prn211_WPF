using BusinessObjects.Models;
using Microsoft.Win32;
using Services;
using Services.Interfaces;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_Assignment_SE173202_NguyenTranTanPhat
{
    public partial class ClassManagementWindow : Window
    {
        private readonly IClassService classService;
        private Class? selectedClass;

        public ClassManagementWindow()
        {
            InitializeComponent();
            classService = new ClassService();  
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadClassData();
        }

        private void LoadClassData()
        {
            dtgClasses.ItemsSource = classService.GetAllClasses();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgClasses.SelectedItem == null)
                return;

            selectedClass = dtgClasses.SelectedItem as Class;
            if (selectedClass == null)
                return;

            txtClassName.Text = selectedClass.ClassName;
        }

        private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            // Mở hộp thoại chọn ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                // Đường dẫn gốc
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string imagesFolder = System.IO.Path.Combine(projectPath, "Images");

                // Tạo thư mục "Images" nếu chưa tồn tại
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                // Lưu ảnh vào thư mục
                string imageName = System.IO.Path.GetFileName(openFileDialog.FileName);
                string destFilePath = System.IO.Path.Combine(imagesFolder, imageName);
                File.Copy(openFileDialog.FileName, destFilePath, true);

                // Cập nhật đường dẫn ảnh vào TextBox
                txtImageUrl.Text = destFilePath;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClassName.Text))
            {
                MessageBox.Show("Please provide all class details!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Class newClass = new Class
            {
                ClassName = txtClassName.Text,
                ImageUrl = txtImageUrl.Text
            };

            classService.AddClass(newClass);
            LoadClassData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClass == null)
            {
                MessageBox.Show("Please select a class to update!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Class updatedClass = classService.GetClassById(this.selectedClass.ClassId);

            updatedClass.ClassName = txtClassName.Text;
            updatedClass.ImageUrl = txtImageUrl.Text;

            classService.UpdateClass(updatedClass);
            LoadClassData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClass == null)
            {
                MessageBox.Show("Please select a class to delete!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this class?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                classService.DeleteClass(selectedClass.ClassId);
                LoadClassData();
                this.resetData();
            }
        }

        private void resetData()
        {
            this.selectedClass = null;
            txtClassName.Text = string.Empty;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }
    }
}
