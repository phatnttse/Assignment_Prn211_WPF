using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore; 

namespace DAO
{
    public class UserDAO
    {
        private AssignmentWPFDBContext _context;
        private static UserDAO instance;

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public UserDAO()
        {
            _context = new AssignmentWPFDBContext();
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _context.Users
                    .Include(u => u.Role) 
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<User>();
            }
        }

        public List<User> GetUsersByRole(int roleId) {
            try
            {
                return _context.Users
                    .Include(u => u.Role)
                    .Where(u => u.RoleId == roleId)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<User>();
            }
        }

        public User GetUserById(int userId)
        {
            try
            {
                return _context.Users
                    .Include(u => u.Role) // Bao gồm thông tin Role
                    .FirstOrDefault(u => u.UserId == userId);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ ở đây
                Console.WriteLine($"An error occurred while retrieving user with ID {userId}: {ex.Message}");
                return null; 
            }
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                return _context.Users
                    .Include(u => u.Role) 
                    .FirstOrDefault(u => u.UserName == username);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving user with username {username}: {ex.Message}");
                return null; 
            }
        }

        public void AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding user: {ex.Message}");
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating user: {ex.Message}");
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                var user = _context.Users.Find(userId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting user with ID {userId}: {ex.Message}");
            }
        }
    }
}
