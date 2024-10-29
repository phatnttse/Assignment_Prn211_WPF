using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;


namespace DAO
{
    public class UserClassDAO
    {
        private AssignmentWPFDBContext _context;
        private static UserClassDAO instance;

        public static UserClassDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserClassDAO();
                }
                return instance;
            }
        }

        public UserClassDAO()
        {
            _context = new AssignmentWPFDBContext();
        }

        public List<UserClass> GetAllUserClasses()
        {
            try
            {
                return _context.UserClasses
                    .Include(u => u.User)
                    .Include(cls => cls.Class)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<UserClass>();
            }
        }

        public UserClass GetUserClassById(int userClassId)
        {
            try
            {
                return _context.UserClasses.Find(userClassId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public UserClass GetUserClassByUserIdAndClassId(int userId, int classId)
        {
            try
            {
                return _context.UserClasses
                    .Include(u => u.User)
                    .Include(cls => cls.Class)
                    .Where(uc => uc.UserId == userId && uc.ClassId == classId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public void AddUserClass(UserClass userClass)
        {
            try
            {
                _context.UserClasses.Add(userClass);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateUserClass(UserClass userClass)
        {
            try
            {
                _context.UserClasses.Update(userClass);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteUserClass(int userClassId)
        {
            try
            {
                var userClass = _context.UserClasses.Find(userClassId);
                if (userClass != null)
                {
                    _context.UserClasses.Remove(userClass);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
