using BusinessObjects.Models;

namespace DAO
{
    public class ClassDAO
    {
        private AssignmentWPFDBContext _context;
        private static ClassDAO instance;

        public static ClassDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClassDAO();
                }
                return instance;
            }
        }

        public ClassDAO()
        {
            _context = new AssignmentWPFDBContext();
        }

        public List<Class> GetAllClasses()
        {
            try
            {
                return _context.Classes.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving classes: {ex.Message}");
                return new List<Class>(); 
            }
        }

        public Class GetClassById(int classId)
        {
            try
            {
                return _context.Classes.Find(classId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving class with ID {classId}: {ex.Message}");
                return null; 
            }
        }

        public void AddClass(Class cls)
        {
            try
            {
                _context.Classes.Add(cls);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding class: {ex.Message}");
            }
        }

        public void UpdateClass(Class cls)
        {
            try
            {
                _context.Classes.Update(cls);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating class: {ex.Message}");
            }
        }

        public void DeleteClass(int classId)
        {
            try
            {
                var cls = _context.Classes.Find(classId);
                if (cls != null)
                {
                    _context.Classes.Remove(cls);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting class with ID {classId}: {ex.Message}");
            }
        }
    }
}
